using System;
using System.Data;
using QuanLyNhanSu.BLL;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyNhanSu
{
    public partial class frm_DanhSachNV : Form
    {
        private readonly NhanVienBLL nhanVienBLL = new NhanVienBLL();
        private readonly DanhMucBLL danhMucBLL = new DanhMucBLL();

        private string connectstring =
            @"Data Source=ADMIN\PHANTAN1;Initial Catalog=QUAN_LY_NHAN_VIEN_CMC;Integrated Security=True;TrustServerCertificate=True";

        private string selectedImagePath = "";

        public frm_DanhSachNV()
        {
            InitializeComponent();
        }

        private void frm_DanhSachNV_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadPositions();
            LoadStaticCombobox();
            LoadFilterCombobox();
            LoadEmployeeData();
            ConfigureDataGridView();
        }

        // ================= LOAD DANH SACH =================
        private void LoadEmployeeData()
        {
            try
            {
                dataGridViewEmployees.DataSource = nhanVienBLL.GetAllEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dataGridViewEmployees.Columns.Count == 0) return;

            dataGridViewEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEmployees.MultiSelect = false;
            dataGridViewEmployees.ReadOnly = true;

            if (dataGridViewEmployees.Columns.Contains("Ma_nhan_vien"))
                dataGridViewEmployees.Columns["Ma_nhan_vien"].HeaderText = "Mã NV";
            if (dataGridViewEmployees.Columns.Contains("Ten_nhan_vien"))
                dataGridViewEmployees.Columns["Ten_nhan_vien"].HeaderText = "Tên nhân viên";
            if (dataGridViewEmployees.Columns.Contains("Ngay_sinh"))
                dataGridViewEmployees.Columns["Ngay_sinh"].HeaderText = "Ngày sinh";
            if (dataGridViewEmployees.Columns.Contains("Gioi_tinh"))
                dataGridViewEmployees.Columns["Gioi_tinh"].HeaderText = "Giới tính";
            if (dataGridViewEmployees.Columns.Contains("CCCD"))
                dataGridViewEmployees.Columns["CCCD"].HeaderText = "CCCD";
            if (dataGridViewEmployees.Columns.Contains("Dia_chi"))
                dataGridViewEmployees.Columns["Dia_chi"].HeaderText = "Địa chỉ";
            if (dataGridViewEmployees.Columns.Contains("SDT"))
                dataGridViewEmployees.Columns["SDT"].HeaderText = "SĐT";
            if (dataGridViewEmployees.Columns.Contains("Email"))
                dataGridViewEmployees.Columns["Email"].HeaderText = "Email";
            if (dataGridViewEmployees.Columns.Contains("Ngay_vao_lam"))
                dataGridViewEmployees.Columns["Ngay_vao_lam"].HeaderText = "Ngày vào làm";
            if (dataGridViewEmployees.Columns.Contains("Ten_chuc_vu"))
                dataGridViewEmployees.Columns["Ten_chuc_vu"].HeaderText = "Chức vụ";
            if (dataGridViewEmployees.Columns.Contains("Ten_phong_ban"))
                dataGridViewEmployees.Columns["Ten_phong_ban"].HeaderText = "Phòng ban";
            if (dataGridViewEmployees.Columns.Contains("Luong_co_ban"))
                dataGridViewEmployees.Columns["Luong_co_ban"].HeaderText = "Lương cơ bản";
            if (dataGridViewEmployees.Columns.Contains("Tinh_trang"))
                dataGridViewEmployees.Columns["Tinh_trang"].HeaderText = "Tình trạng";

            if (dataGridViewEmployees.Columns.Contains("Ma_chuc_vu"))
                dataGridViewEmployees.Columns["Ma_chuc_vu"].Visible = false;
            if (dataGridViewEmployees.Columns.Contains("Ma_phong_ban"))
                dataGridViewEmployees.Columns["Ma_phong_ban"].Visible = false;
            if (dataGridViewEmployees.Columns.Contains("Anh_nv"))
                dataGridViewEmployees.Columns["Anh_nv"].Visible = false;
        }

        // ================= LOAD COMBOBOX =================
        private void LoadDepartments()
        {
            try
            {
                DataTable dt = danhMucBLL.GetDepartments();
                DataTable dt1 = dt.Copy();
                DataTable dt2 = dt.Copy();

                cmbDepartment.DataSource = dt1;
                cmbDepartment.DisplayMember = "Ten_phong_ban";
                cmbDepartment.ValueMember = "Ma_phong_ban";
                cmbDepartment.SelectedIndex = -1;

                DataRow rowAll = dt2.NewRow();
                rowAll["Ma_phong_ban"] = DBNull.Value;
                rowAll["Ten_phong_ban"] = "-- Tất cả --";
                dt2.Rows.InsertAt(rowAll, 0);

                cmbLocPhongBan.DataSource = dt2;
                cmbLocPhongBan.DisplayMember = "Ten_phong_ban";
                cmbLocPhongBan.ValueMember = "Ma_phong_ban";
                cmbLocPhongBan.SelectedIndex = 0;
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
                DataTable dt = danhMucBLL.GetPositions();
                DataTable dt1 = dt.Copy();
                DataTable dt2 = dt.Copy();

                cmbPosition.DataSource = dt1;
                cmbPosition.DisplayMember = "Ten_chuc_vu";
                cmbPosition.ValueMember = "Ma_chuc_vu";
                cmbPosition.SelectedIndex = -1;

                DataRow rowAll = dt2.NewRow();
                rowAll["Ma_chuc_vu"] = DBNull.Value;
                rowAll["Ten_chuc_vu"] = "-- Tất cả --";
                dt2.Rows.InsertAt(rowAll, 0);

                cmbLocChucVu.DataSource = dt2;
                cmbLocChucVu.DisplayMember = "Ten_chuc_vu";
                cmbLocChucVu.ValueMember = "Ma_chuc_vu";
                cmbLocChucVu.SelectedIndex = 0;
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
            cmbGender.SelectedIndex = -1;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Đang làm");
            cmbStatus.Items.Add("Tạm nghỉ");
            cmbStatus.Items.Add("Nghỉ việc");
            cmbStatus.SelectedIndex = -1;
        }

        private void LoadFilterCombobox()
        {
            cmbLocTinhTrang.Items.Clear();
            cmbLocTinhTrang.Items.Add("-- Tất cả --");
            cmbLocTinhTrang.Items.Add("Đang làm");
            cmbLocTinhTrang.Items.Add("Tạm nghỉ");
            cmbLocTinhTrang.Items.Add("Nghỉ việc");
            cmbLocTinhTrang.SelectedIndex = 0;
        }

        // ================= CLICK GRID =================
        private void dataGridViewEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewEmployees.Rows[e.RowIndex];

            txtMaNhanVien.Text = row.Cells["Ma_nhan_vien"].Value?.ToString() ?? "";
            txtFullName.Text = row.Cells["Ten_nhan_vien"].Value?.ToString() ?? "";
            txtCCCD.Text = row.Cells["CCCD"].Value?.ToString() ?? "";
            txtPhone.Text = row.Cells["SDT"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            txtAddress.Text = row.Cells["Dia_chi"].Value?.ToString() ?? "";
            txtLuongCoBan.Text = row.Cells["Luong_co_ban"].Value?.ToString() ?? "";
            cmbGender.Text = row.Cells["Gioi_tinh"].Value?.ToString() ?? "";
            cmbStatus.Text = row.Cells["Tinh_trang"].Value?.ToString() ?? "";

            if (DateTime.TryParse(row.Cells["Ngay_sinh"].Value?.ToString(), out DateTime birthDate))
                dtpBirthDate.Value = birthDate;

            if (DateTime.TryParse(row.Cells["Ngay_vao_lam"].Value?.ToString(), out DateTime ngayVaoLam))
                dtpNgayVaoLam.Value = ngayVaoLam;

            if (row.Cells["Ma_phong_ban"].Value != DBNull.Value && row.Cells["Ma_phong_ban"].Value != null)
                cmbDepartment.SelectedValue = Convert.ToInt32(row.Cells["Ma_phong_ban"].Value);

            if (row.Cells["Ma_chuc_vu"].Value != DBNull.Value && row.Cells["Ma_chuc_vu"].Value != null)
                cmbPosition.SelectedValue = Convert.ToInt32(row.Cells["Ma_chuc_vu"].Value);

            selectedImagePath = row.Cells["Anh_nv"].Value?.ToString() ?? "";
            LoadEmployeeImage(selectedImagePath);
        }

        // ================= ẢNH =================
        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Chọn ảnh nhân viên";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;
                    LoadEmployeeImage(selectedImagePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn ảnh: " + ex.Message);
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

        // ================= THÊM =================
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput(true)) return;

                using (SqlConnection conn = new SqlConnection(connectstring))
                {
                    conn.Open();

                    int maNhanVien;
                    if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
                    {
                        maNhanVien = GetNextEmployeeId(conn);
                        txtMaNhanVien.Text = maNhanVien.ToString();
                    }
                    else
                    {
                        maNhanVien = int.Parse(txtMaNhanVien.Text.Trim());
                        if (IsEmployeeIdExists(conn, maNhanVien))
                        {
                            MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác.");
                            txtMaNhanVien.Focus();
                            return;
                        }
                    }

                    string query = @"
                        INSERT INTO NHAN_VIEN
                        (
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
                        )
                        VALUES
                        (
                            @Ma_nhan_vien,
                            @Ten_nhan_vien,
                            @Ngay_sinh,
                            @Gioi_tinh,
                            @CCCD,
                            @Dia_chi,
                            @SDT,
                            @Email,
                            @Ngay_vao_lam,
                            @Ma_chuc_vu,
                            @Ten_chuc_vu,
                            @Ma_phong_ban,
                            @Ten_phong_ban,
                            @Luong_co_ban,
                            @Tinh_trang,
                            @Anh_nv
                        )";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    BindEmployeeParameters(cmd);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm nhân viên thành công.");
                    LoadEmployeeData();
                    ConfigureDataGridView();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message);
            }
        }

        // ================= SỬA =================
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần sửa.");
                    return;
                }

                if (!ValidateInput(false)) return;

                using (SqlConnection conn = new SqlConnection(connectstring))
                {
                    conn.Open();

                    string query = @"
                        UPDATE NHAN_VIEN
                        SET
                            Ten_nhan_vien = @Ten_nhan_vien,
                            Ngay_sinh = @Ngay_sinh,
                            Gioi_tinh = @Gioi_tinh,
                            CCCD = @CCCD,
                            Dia_chi = @Dia_chi,
                            SDT = @SDT,
                            Email = @Email,
                            Ngay_vao_lam = @Ngay_vao_lam,
                            Ma_chuc_vu = @Ma_chuc_vu,
                            Ten_chuc_vu = @Ten_chuc_vu,
                            Ma_phong_ban = @Ma_phong_ban,
                            Ten_phong_ban = @Ten_phong_ban,
                            Luong_co_ban = @Luong_co_ban,
                            Tinh_trang = @Tinh_trang,
                            Anh_nv = @Anh_nv
                        WHERE Ma_nhan_vien = @Ma_nhan_vien";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    BindEmployeeParameters(cmd);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sửa nhân viên thành công.");
                    LoadEmployeeData();
                    ConfigureDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa nhân viên: " + ex.Message);
            }
        }

        // ================= XÓA =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn xóa nhân viên này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No) return;

                using (SqlConnection conn = new SqlConnection(connectstring))
                {
                    conn.Open();

                    string query = "DELETE FROM NHAN_VIEN WHERE Ma_nhan_vien = @Ma_nhan_vien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ma_nhan_vien", int.Parse(txtMaNhanVien.Text));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa nhân viên thành công.");
                    LoadEmployeeData();
                    ConfigureDataGridView();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa nhân viên: " + ex.Message);
            }
        }

        // ================= TÌM KIẾM KIỂU LỌC =================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectstring))
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
                        WHERE 1 = 1";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    if (cmbLocPhongBan.SelectedValue != null && cmbLocPhongBan.SelectedIndex > 0)
                    {
                        query += " AND Ma_phong_ban = @Ma_phong_ban";
                        cmd.Parameters.AddWithValue("@Ma_phong_ban", Convert.ToInt32(cmbLocPhongBan.SelectedValue));
                    }

                    if (cmbLocChucVu.SelectedValue != null && cmbLocChucVu.SelectedIndex > 0)
                    {
                        query += " AND Ma_chuc_vu = @Ma_chuc_vu";
                        cmd.Parameters.AddWithValue("@Ma_chuc_vu", Convert.ToInt32(cmbLocChucVu.SelectedValue));
                    }

                    if (cmbLocTinhTrang.SelectedIndex > 0)
                    {
                        query += " AND Tinh_trang = @Tinh_trang";
                        cmd.Parameters.AddWithValue("@Tinh_trang", cmbLocTinhTrang.Text);
                    }

                    if (!string.IsNullOrWhiteSpace(txtTuKhoa.Text))
                    {
                        query += " AND (Ten_nhan_vien LIKE @TuKhoa OR CCCD LIKE @TuKhoa OR SDT LIKE @TuKhoa OR CAST(Ma_nhan_vien AS NVARCHAR(20)) LIKE @TuKhoa)";
                        cmd.Parameters.AddWithValue("@TuKhoa", "%" + txtTuKhoa.Text.Trim() + "%");
                    }

                    query += " ORDER BY Ma_nhan_vien";
                    cmd.CommandText = query;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewEmployees.DataSource = dt;
                    ConfigureDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            cmbLocPhongBan.SelectedIndex = 0;
            cmbLocChucVu.SelectedIndex = 0;
            cmbLocTinhTrang.SelectedIndex = 0;
            txtTuKhoa.Clear();

            LoadEmployeeData();
            ConfigureDataGridView();
        }

        // ================= HỖ TRỢ =================
        private void BindEmployeeParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Ma_nhan_vien", int.Parse(txtMaNhanVien.Text.Trim()));
            cmd.Parameters.AddWithValue("@Ten_nhan_vien", txtFullName.Text.Trim());
            cmd.Parameters.AddWithValue("@Ngay_sinh", dtpBirthDate.Value.Date);
            cmd.Parameters.AddWithValue("@Gioi_tinh", cmbGender.Text.Trim());
            cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text.Trim());
            cmd.Parameters.AddWithValue("@Dia_chi", txtAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@SDT", txtPhone.Text.Trim());
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@Ngay_vao_lam", dtpNgayVaoLam.Value.Date);
            cmd.Parameters.AddWithValue("@Ma_chuc_vu", Convert.ToInt32(cmbPosition.SelectedValue));
            cmd.Parameters.AddWithValue("@Ten_chuc_vu", cmbPosition.Text);
            cmd.Parameters.AddWithValue("@Ma_phong_ban", Convert.ToInt32(cmbDepartment.SelectedValue));
            cmd.Parameters.AddWithValue("@Ten_phong_ban", cmbDepartment.Text);
            cmd.Parameters.AddWithValue("@Luong_co_ban", decimal.Parse(txtLuongCoBan.Text.Trim()));
            cmd.Parameters.AddWithValue("@Tinh_trang", cmbStatus.Text);

            if (string.IsNullOrWhiteSpace(selectedImagePath))
                cmd.Parameters.AddWithValue("@Anh_nv", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@Anh_nv", selectedImagePath);
        }

        private int GetNextEmployeeId(SqlConnection conn)
        {
            string query = "SELECT ISNULL(MAX(Ma_nhan_vien), 0) + 1 FROM NHAN_VIEN";
            SqlCommand cmd = new SqlCommand(query, conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private bool IsEmployeeIdExists(SqlConnection conn, int maNhanVien)
        {
            string query = "SELECT COUNT(*) FROM NHAN_VIEN WHERE Ma_nhan_vien = @Ma_nhan_vien";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Ma_nhan_vien", maNhanVien);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        private bool ValidateInput(bool isAddNew)
        {
            if (!string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
            {
                if (!int.TryParse(txtMaNhanVien.Text.Trim(), out _))
                {
                    MessageBox.Show("Mã nhân viên phải là số nguyên.");
                    txtMaNhanVien.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên.");
                txtFullName.Focus();
                return false;
            }

            if (cmbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                cmbGender.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập CCCD.");
                txtCCCD.Focus();
                return false;
            }

            if (cmbDepartment.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng ban.");
                cmbDepartment.Focus();
                return false;
            }

            if (cmbPosition.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn chức vụ.");
                cmbPosition.Focus();
                return false;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tình trạng.");
                cmbStatus.Focus();
                return false;
            }

            if (!decimal.TryParse(txtLuongCoBan.Text.Trim(), out _))
            {
                MessageBox.Show("Lương cơ bản không hợp lệ.");
                txtLuongCoBan.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtMaNhanVien.Clear();
            txtFullName.Clear();
            txtCCCD.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtLuongCoBan.Clear();

            cmbGender.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;

            dtpBirthDate.Value = DateTime.Now;
            dtpNgayVaoLam.Value = DateTime.Now;

            selectedImagePath = "";
            pictureBoxAnh.Image = null;
        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
