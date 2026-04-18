using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace QuanLyNhanSu.NhanVien.ChamCongVaLuong 
{
    public partial class frm_ChiTietLuong : Form
    {
        private readonly string connectString =
            @"Data Source=ADMIN\PHANTAN1;Initial Catalog=QUAN_LY_NHAN_VIEN_CMC;Integrated Security=True;TrustServerCertificate=True";

        public frm_ChiTietLuong()
        {
            InitializeComponent();
            this.Load += frm_ChiTietLuong_Load;
            btnLoc.Click += btnLoc_Click;
            btnTaiLai.Click += btnTaiLai_Click;
        }

        private void frm_ChiTietLuong_Load(object sender, EventArgs e)
        {
            LoadEmployeeInfo();
            LoadMonthCombobox();
            LoadYearCombobox();
            SetCurrentMonthYear();
            LoadAttendanceData();
            ConfigureDataGridView();
        }

        private void LoadEmployeeInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();

                    string query = @"
                        SELECT Ma_nhan_vien, Ten_nhan_vien
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
                                txtTenNhanVien.Text = reader["Ten_nhan_vien"].ToString();
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

        private void LoadMonthCombobox()
        {
            cmbThang.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                cmbThang.Items.Add(i);
            }
        }

        private void LoadYearCombobox()
        {
            cmbNam.Items.Clear();

            int currentYear = DateTime.Now.Year;
            for (int i = currentYear - 5; i <= currentYear + 1; i++)
            {
                cmbNam.Items.Add(i);
            }
        }

        private void SetCurrentMonthYear()
        {
            cmbThang.SelectedItem = DateTime.Now.Month;
            cmbNam.SelectedItem = DateTime.Now.Year;
        }

        private void LoadAttendanceData()
        {
            try
            {
                if (cmbThang.SelectedItem == null || cmbNam.SelectedItem == null)
                    return;

                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            Ma_cham_cong,
                            Ngay_cham_cong,
                            Gio_vao,
                            Gio_ra,
                            So_gio_lam_viec,
                            ISNULL(Di_muon, 0) AS Di_muon,
                            ISNULL(Ve_som, 0) AS Ve_som,
                            ISNULL(Nghi_phep, 0) AS Nghi_phep,
                            Ghi_chu
                        FROM CHAM_CONG
                        WHERE Ma_nhan_vien = @Ma_nhan_vien
                          AND MONTH(Ngay_cham_cong) = @Thang
                          AND YEAR(Ngay_cham_cong) = @Nam
                        ORDER BY Ngay_cham_cong ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma_nhan_vien", session.MaNhanVien);
                        cmd.Parameters.AddWithValue("@Thang", Convert.ToInt32(cmbThang.SelectedItem));
                        cmd.Parameters.AddWithValue("@Nam", Convert.ToInt32(cmbNam.SelectedItem));

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridViewChamCong.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết chấm công: " + ex.Message);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dataGridViewChamCong.Columns.Count == 0) return;

            dataGridViewChamCong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewChamCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewChamCong.MultiSelect = false;
            dataGridViewChamCong.ReadOnly = true;
            dataGridViewChamCong.AllowUserToAddRows = false;
            dataGridViewChamCong.AllowUserToDeleteRows = false;

            if (dataGridViewChamCong.Columns.Contains("Ma_cham_cong"))
                dataGridViewChamCong.Columns["Ma_cham_cong"].HeaderText = "Mã chấm công";

            if (dataGridViewChamCong.Columns.Contains("Ngay_cham_cong"))
                dataGridViewChamCong.Columns["Ngay_cham_cong"].HeaderText = "Ngày chấm công";

            if (dataGridViewChamCong.Columns.Contains("Gio_vao"))
                dataGridViewChamCong.Columns["Gio_vao"].HeaderText = "Giờ vào";

            if (dataGridViewChamCong.Columns.Contains("Gio_ra"))
                dataGridViewChamCong.Columns["Gio_ra"].HeaderText = "Giờ ra";

            if (dataGridViewChamCong.Columns.Contains("So_gio_lam_viec"))
                dataGridViewChamCong.Columns["So_gio_lam_viec"].HeaderText = "Số giờ làm việc";

            if (dataGridViewChamCong.Columns.Contains("Di_muon"))
                dataGridViewChamCong.Columns["Di_muon"].HeaderText = "Đi muộn";

            if (dataGridViewChamCong.Columns.Contains("Ve_som"))
                dataGridViewChamCong.Columns["Ve_som"].HeaderText = "Về sớm";

            if (dataGridViewChamCong.Columns.Contains("Nghi_phep"))
                dataGridViewChamCong.Columns["Nghi_phep"].HeaderText = "Nghỉ phép";

            if (dataGridViewChamCong.Columns.Contains("Ghi_chu"))
                dataGridViewChamCong.Columns["Ghi_chu"].HeaderText = "Ghi chú";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadAttendanceData();
            ConfigureDataGridView();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            SetCurrentMonthYear();
            LoadAttendanceData();
            ConfigureDataGridView();
        }
    }
}