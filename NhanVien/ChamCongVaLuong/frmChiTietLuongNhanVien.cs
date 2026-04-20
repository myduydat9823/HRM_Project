using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

using QuanLyNhanSu.Common;

namespace QuanLyNhanSu.NhanVien.ChamCongVaLuong
{
    public partial class frmChiTietLuongNhanVien : Form
    {
        public frmChiTietLuongNhanVien()
        {
            InitializeComponent();
            this.Load += frmChiTietLuongNhanVien_Load;
            btnLoc.Click += btnLoc_Click;
            btnTaiLai.Click += btnTaiLai_Click;
        }

        private void frmChiTietLuongNhanVien_Load(object sender, EventArgs e)
        {
            LoadEmployeeInfo();
            LoadMonthCombobox();
            LoadYearCombobox();
            SetCurrentMonthYear();
            LoadSalaryData();
            ConfigureDataGridView();
        }

        private void LoadEmployeeInfo()
        {
            try
            {
                using (SqlConnection conn = DbConnectionFactory.CreateConnection())
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

        private void LoadSalaryData()
        {
            try
            {
                if (cmbThang.SelectedItem == null || cmbNam.SelectedItem == null)
                    return;

                using (SqlConnection conn = DbConnectionFactory.CreateConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            Ma_luong,
                            Thang,
                            Nam,
                            Luong_co_ban,
                            Muc_thuong_phat,
                            Thuc_nhan
                        FROM LUONG
                        WHERE Ma_nhan_vien = @Ma_nhan_vien
                          AND Thang = @Thang
                          AND Nam = @Nam
                        ORDER BY Nam DESC, Thang DESC, Ma_luong DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma_nhan_vien", session.MaNhanVien);
                        cmd.Parameters.AddWithValue("@Thang", Convert.ToInt32(cmbThang.SelectedItem));
                        cmd.Parameters.AddWithValue("@Nam", Convert.ToInt32(cmbNam.SelectedItem));

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridViewLuong.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết lương: " + ex.Message);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dataGridViewLuong.Columns.Count == 0) return;

            dataGridViewLuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLuong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLuong.MultiSelect = false;
            dataGridViewLuong.ReadOnly = true;
            dataGridViewLuong.AllowUserToAddRows = false;
            dataGridViewLuong.AllowUserToDeleteRows = false;

            if (dataGridViewLuong.Columns.Contains("Ma_luong"))
                dataGridViewLuong.Columns["Ma_luong"].HeaderText = "Mã lương";

            if (dataGridViewLuong.Columns.Contains("Thang"))
                dataGridViewLuong.Columns["Thang"].HeaderText = "Tháng";

            if (dataGridViewLuong.Columns.Contains("Nam"))
                dataGridViewLuong.Columns["Nam"].HeaderText = "Năm";

            if (dataGridViewLuong.Columns.Contains("Luong_co_ban"))
                dataGridViewLuong.Columns["Luong_co_ban"].HeaderText = "Lương cơ bản";

            if (dataGridViewLuong.Columns.Contains("Muc_thuong_phat"))
                dataGridViewLuong.Columns["Muc_thuong_phat"].HeaderText = "Mức thưởng/phạt";

            if (dataGridViewLuong.Columns.Contains("Thuc_nhan"))
                dataGridViewLuong.Columns["Thuc_nhan"].HeaderText = "Thực nhận";

            if (dataGridViewLuong.Columns.Contains("Luong_co_ban"))
                dataGridViewLuong.Columns["Luong_co_ban"].DefaultCellStyle.Format = "N0";

            if (dataGridViewLuong.Columns.Contains("Muc_thuong_phat"))
                dataGridViewLuong.Columns["Muc_thuong_phat"].DefaultCellStyle.Format = "N0";

            if (dataGridViewLuong.Columns.Contains("Thuc_nhan"))
                dataGridViewLuong.Columns["Thuc_nhan"].DefaultCellStyle.Format = "N0";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadSalaryData();
            ConfigureDataGridView();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            SetCurrentMonthYear();
            LoadSalaryData();
            ConfigureDataGridView();
        }
    }
}
