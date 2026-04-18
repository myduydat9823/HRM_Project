using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace QuanLyNhanSu.NhanVien.DonNghiVaThongBao
{
    public partial class frmThongBaoNhanVien : Form
    {
        private readonly string connectString =
            @"Data Source=ADMIN\PHANTAN1;Initial Catalog=QUAN_LY_NHAN_VIEN_CMC;Integrated Security=True;TrustServerCertificate=True";

        public frmThongBaoNhanVien()
        {
            InitializeComponent();
            this.Load += frmThongBaoNhanVien_Load;
            btnDanhDauDaDoc.Click += btnDanhDauDaDoc_Click;
            btnTaiLai.Click += btnTaiLai_Click;
            dataGridViewThongBao.CellClick += dataGridViewThongBao_CellClick;
        }

        private void frmThongBaoNhanVien_Load(object sender, EventArgs e)
        {
            LoadNotifications();
            ConfigureDataGridView();
        }

        private void LoadNotifications()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            Ma_thong_bao,
                            Tieu_de,
                            Ngay_tao,
                            Da_doc,
                            Loai_thong_bao,
                            Ma_don_lien_quan,
                            Noi_dung
                        FROM THONG_BAO
                        WHERE Ma_nhan_vien = @Ma_nhan_vien
                        ORDER BY Ngay_tao DESC, Ma_thong_bao DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma_nhan_vien", session.MaNhanVien);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridViewThongBao.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông báo: " + ex.Message);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dataGridViewThongBao.Columns.Count == 0) return;

            dataGridViewThongBao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewThongBao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewThongBao.MultiSelect = false;
            dataGridViewThongBao.ReadOnly = true;
            dataGridViewThongBao.AllowUserToAddRows = false;
            dataGridViewThongBao.AllowUserToDeleteRows = false;

            if (dataGridViewThongBao.Columns.Contains("Ma_thong_bao"))
                dataGridViewThongBao.Columns["Ma_thong_bao"].HeaderText = "Mã TB";
            if (dataGridViewThongBao.Columns.Contains("Tieu_de"))
                dataGridViewThongBao.Columns["Tieu_de"].HeaderText = "Tiêu đề";
            if (dataGridViewThongBao.Columns.Contains("Ngay_tao"))
                dataGridViewThongBao.Columns["Ngay_tao"].HeaderText = "Ngày tạo";
            if (dataGridViewThongBao.Columns.Contains("Da_doc"))
                dataGridViewThongBao.Columns["Da_doc"].HeaderText = "Đã đọc";
            if (dataGridViewThongBao.Columns.Contains("Loai_thong_bao"))
                dataGridViewThongBao.Columns["Loai_thong_bao"].HeaderText = "Loại";
            if (dataGridViewThongBao.Columns.Contains("Ma_don_lien_quan"))
                dataGridViewThongBao.Columns["Ma_don_lien_quan"].HeaderText = "Mã đơn";
            if (dataGridViewThongBao.Columns.Contains("Noi_dung"))
                dataGridViewThongBao.Columns["Noi_dung"].Visible = false;
        }

        private void dataGridViewThongBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewThongBao.Rows[e.RowIndex];

            txtTieuDe.Text = row.Cells["Tieu_de"].Value?.ToString() ?? "";
            txtNgayTao.Text = row.Cells["Ngay_tao"].Value == null ? "" :
                Convert.ToDateTime(row.Cells["Ngay_tao"].Value).ToString("dd/MM/yyyy HH:mm:ss");
            txtNoiDung.Text = row.Cells["Noi_dung"].Value?.ToString() ?? "";
        }

        private void btnDanhDauDaDoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewThongBao.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn thông báo.");
                    return;
                }

                int maThongBao = Convert.ToInt32(dataGridViewThongBao.CurrentRow.Cells["Ma_thong_bao"].Value);

                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE THONG_BAO
                        SET Da_doc = 1
                        WHERE Ma_thong_bao = @Ma_thong_bao
                          AND Ma_nhan_vien = @Ma_nhan_vien";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma_thong_bao", maThongBao);
                        cmd.Parameters.AddWithValue("@Ma_nhan_vien", session.MaNhanVien);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadNotifications();
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật trạng thái thông báo: " + ex.Message);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadNotifications();
            ConfigureDataGridView();
            txtTieuDe.Clear();
            txtNgayTao.Clear();
            txtNoiDung.Clear();
        }
    }
}