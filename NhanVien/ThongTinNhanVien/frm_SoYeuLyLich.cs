using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace QuanLyNhanSu.NhanVien.ThongTinNhanVien
{
    public partial class frm_SoYeuLyLich : Form
    {
        private string connectString =
            @"Data Source=ADMIN\PHANTAN1;Initial Catalog=QUAN_LY_NHAN_VIEN_CMC;Integrated Security=True;TrustServerCertificate=True";

        public frm_SoYeuLyLich()
        {
            InitializeComponent();
            this.Load += frm_SoYeuLyLich_Load;
        }

        private void frm_SoYeuLyLich_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadPositions();
            LoadStaticCombobox();
            SetReadOnlyControls();
            LoadThongTinNhanVienDangNhap();
        }

        private void LoadDepartments()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT Ma_phong_ban, Ten_phong_ban FROM PHONG_BAN ORDER BY Ten_phong_ban";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbDepartment.DataSource = dt;
                    cmbDepartment.DisplayMember = "Ten_phong_ban";
                    cmbDepartment.ValueMember = "Ma_phong_ban";
                    cmbDepartment.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải phòng ban: " + ex.Message);
            }
        }

        private void LoadPositions()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT Ma_chuc_vu, Ten_chuc_vu FROM CHUC_VU ORDER BY Ten_chuc_vu";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbPosition.DataSource = dt;
                    cmbPosition.DisplayMember = "Ten_chuc_vu";
                    cmbPosition.ValueMember = "Ma_chuc_vu";
                    cmbPosition.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chức vụ: " + ex.Message);
            }
        }

        private void LoadStaticCombobox()
        {
            cmbGender.Items.Clear();
            cmbGender.Items.Add("Nam");
            cmbGender.Items.Add("Nữ");
            cmbGender.Items.Add("Khác");

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Đang làm");
            cmbStatus.Items.Add("Tạm nghỉ");
            cmbStatus.Items.Add("Nghỉ việc");
        }

        private void SetReadOnlyControls()
        {
            txtMaNhanVien.ReadOnly = true;
            txtFullName.ReadOnly = true;
            txtCCCD.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtLuongCoBan.ReadOnly = true;

            cmbGender.Enabled = false;
            cmbDepartment.Enabled = false;
            cmbPosition.Enabled = false;
            cmbStatus.Enabled = false;

            dtpBirthDate.Enabled = false;
            dtpNgayVaoLam.Enabled = false;

            btnThemAnh.Visible = false;
        }

        private void LoadThongTinNhanVienDangNhap()
        {
            if (session.MaNhanVien <= 0)
            {
                MessageBox.Show("Chưa xác định được nhân viên đăng nhập.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            Ma_nhan_vien,
                            Ten_nhan_vien,
                            Ngay_sinh,
                            Gioi_tinh,
                            CCCD,
                            Dia_chi,
                            SDT,
                            Email,
                            Ngay_vao_lam,
                            Ma_chuc_vu,
                            Ten_chuc_vu,
                            Ma_phong_ban,
                            Ten_phong_ban,
                            Luong_co_ban,
                            Tinh_trang,
                            Anh_nv
                        FROM NHAN_VIEN
                        WHERE Ma_nhan_vien = @Ma_nhan_vien";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma_nhan_vien", session.MaNhanVien);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtMaNhanVien.Text = reader["Ma_nhan_vien"].ToString();
                                txtFullName.Text = reader["Ten_nhan_vien"].ToString();
                                txtCCCD.Text = reader["CCCD"].ToString();
                                txtPhone.Text = reader["SDT"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                txtAddress.Text = reader["Dia_chi"].ToString();
                                txtLuongCoBan.Text = reader["Luong_co_ban"].ToString();

                                cmbGender.Text = reader["Gioi_tinh"].ToString();
                                cmbStatus.Text = reader["Tinh_trang"].ToString();

                                if (reader["Ngay_sinh"] != DBNull.Value)
                                    dtpBirthDate.Value = Convert.ToDateTime(reader["Ngay_sinh"]);

                                if (reader["Ngay_vao_lam"] != DBNull.Value)
                                    dtpNgayVaoLam.Value = Convert.ToDateTime(reader["Ngay_vao_lam"]);

                                if (reader["Ma_phong_ban"] != DBNull.Value)
                                    cmbDepartment.SelectedValue = Convert.ToInt32(reader["Ma_phong_ban"]);

                                if (reader["Ma_chuc_vu"] != DBNull.Value)
                                    cmbPosition.SelectedValue = Convert.ToInt32(reader["Ma_chuc_vu"]);

                                string imagePath = reader["Anh_nv"] == DBNull.Value ? "" : reader["Anh_nv"].ToString();
                                LoadEmployeeImage(imagePath);
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin nhân viên.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin nhân viên: " + ex.Message);
            }
        }

        private void LoadEmployeeImage(string path)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        pictureBoxAnh.Image = Image.FromStream(fs);
                    }
                }
                else
                {
                    pictureBoxAnh.Image = null;
                }
            }
            catch
            {
                pictureBoxAnh.Image = null;
            }
        }

        private void dtpNgayVaoLam_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}