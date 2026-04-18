using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace QuanLyNhanSu.Admin.NghiPhep
{
    public partial class frmDuyetDonNghiPhep : Form
    {
        private readonly string connectString =
            @"Data Source=ADMIN\PHANTAN1;Initial Catalog=QUAN_LY_NHAN_VIEN_CMC;Integrated Security=True;TrustServerCertificate=True";

        private bool isProcessing = false;

        public frmDuyetDonNghiPhep()
        {
            InitializeComponent();
            this.Load += frmDuyetDonNghiPhep_Load;
            btnLoc.Click += btnLoc_Click;
            btnTaiLai.Click += btnTaiLai_Click;
            btnDuyet.Click += btnDuyet_Click;
            btnTuChoi.Click += btnTuChoi_Click;
            dataGridViewDon.CellClick += dataGridViewDon_CellClick;
        }

        private void frmDuyetDonNghiPhep_Load(object sender, EventArgs e)
        {
            if (session.MaQuyen != 1)
            {
                MessageBox.Show("Bạn không có quyền truy cập form duyệt đơn.");
                this.Close();
                return;
            }

            LoadTrangThai();
            LoadDonNghiPhep();
            ConfigureDataGridView();
        }

        private void LoadTrangThai()
        {
            cmbTrangThai.Items.Clear();
            cmbTrangThai.Items.Add("-- Tất cả --");
            cmbTrangThai.Items.Add("Chờ duyệt");
            cmbTrangThai.Items.Add("Đã duyệt");
            cmbTrangThai.Items.Add("Từ chối");
            cmbTrangThai.SelectedIndex = 0;
        }

        private void LoadDonNghiPhep()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            Ma_don,
                            Ngay_lap,
                            Ma_nhan_vien,
                            Ten_nhan_vien,
                            Ngay_bat_dau,
                            Ngay_ket_thuc,
                            Ly_do,
                            Tinh_trang
                        FROM NGHI_PHEP_THOI_VIEC
                        WHERE Loai_don = N'Nghỉ phép'";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    if (cmbTrangThai.SelectedIndex > 0)
                    {
                        query += " AND Tinh_trang = @Tinh_trang";
                        cmd.Parameters.AddWithValue("@Tinh_trang", cmbTrangThai.Text);
                    }

                    query += " ORDER BY Ngay_lap DESC, Ma_don DESC";
                    cmd.CommandText = query;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewDon.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách đơn nghỉ phép: " + ex.Message);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dataGridViewDon.Columns.Count == 0) return;

            dataGridViewDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDon.MultiSelect = false;
            dataGridViewDon.ReadOnly = true;
            dataGridViewDon.AllowUserToAddRows = false;
            dataGridViewDon.AllowUserToDeleteRows = false;

            if (dataGridViewDon.Columns.Contains("Ma_don"))
                dataGridViewDon.Columns["Ma_don"].HeaderText = "Mã đơn";
            if (dataGridViewDon.Columns.Contains("Ngay_lap"))
                dataGridViewDon.Columns["Ngay_lap"].HeaderText = "Ngày lập";
            if (dataGridViewDon.Columns.Contains("Ma_nhan_vien"))
                dataGridViewDon.Columns["Ma_nhan_vien"].HeaderText = "Mã NV";
            if (dataGridViewDon.Columns.Contains("Ten_nhan_vien"))
                dataGridViewDon.Columns["Ten_nhan_vien"].HeaderText = "Tên nhân viên";
            if (dataGridViewDon.Columns.Contains("Ngay_bat_dau"))
                dataGridViewDon.Columns["Ngay_bat_dau"].HeaderText = "Ngày bắt đầu";
            if (dataGridViewDon.Columns.Contains("Ngay_ket_thuc"))
                dataGridViewDon.Columns["Ngay_ket_thuc"].HeaderText = "Ngày kết thúc";
            if (dataGridViewDon.Columns.Contains("Ly_do"))
                dataGridViewDon.Columns["Ly_do"].HeaderText = "Lý do";
            if (dataGridViewDon.Columns.Contains("Tinh_trang"))
                dataGridViewDon.Columns["Tinh_trang"].HeaderText = "Tình trạng";
        }

        private void dataGridViewDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewDon.Rows[e.RowIndex];

            txtMaDon.Text = row.Cells["Ma_don"].Value?.ToString() ?? "";
            txtMaNhanVien.Text = row.Cells["Ma_nhan_vien"].Value?.ToString() ?? "";
            txtTenNhanVien.Text = row.Cells["Ten_nhan_vien"].Value?.ToString() ?? "";
            txtNgayBatDau.Text = row.Cells["Ngay_bat_dau"].Value == null ? "" :
                Convert.ToDateTime(row.Cells["Ngay_bat_dau"].Value).ToString("dd/MM/yyyy");
            txtNgayKetThuc.Text = row.Cells["Ngay_ket_thuc"].Value == null ? "" :
                Convert.ToDateTime(row.Cells["Ngay_ket_thuc"].Value).ToString("dd/MM/yyyy");
            txtTinhTrang.Text = row.Cells["Tinh_trang"].Value?.ToString() ?? "";
            txtLyDo.Text = row.Cells["Ly_do"].Value?.ToString() ?? "";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadDonNghiPhep();
            ConfigureDataGridView();
            ClearDetail();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            cmbTrangThai.SelectedIndex = 0;
            LoadDonNghiPhep();
            ConfigureDataGridView();
            ClearDetail();
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            ProcessLeaveRequest("Đã duyệt");
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            ProcessLeaveRequest("Từ chối");
        }

        private void ProcessLeaveRequest(string newStatus)
        {
            if (isProcessing) return;
            isProcessing = true;
            btnDuyet.Enabled = false;
            btnTuChoi.Enabled = false;

            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                if (session.MaQuyen != 1)
                {
                    MessageBox.Show("Bạn không có quyền thực hiện thao tác này.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMaDon.Text) || string.IsNullOrWhiteSpace(txtMaDon.Text) || string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
                {
                    MessageBox.Show("Vui lòng chọn đơn cần xử lý.");
                    return;
                }

                if (!string.Equals(txtTinhTrang.Text.Trim(), "Chờ duyệt", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Chỉ được xử lý các đơn đang ở trạng thái Chờ duyệt.");
                    return;
                }

                conn = new SqlConnection(connectString);
                conn.Open();
                tran = conn.BeginTransaction();

                string updateQuery = @"
                    UPDATE NGHI_PHEP_THOI_VIEC
                    SET Tinh_trang = @Tinh_trang
                    WHERE Ma_don = @Ma_don
                      AND Loai_don = N'Nghỉ phép'
                      AND Tinh_trang = N'Chờ duyệt'";

                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn, tran))
                {
                    updateCmd.Parameters.AddWithValue("@Tinh_trang", newStatus);
                    updateCmd.Parameters.AddWithValue("@Ma_don", int.Parse(txtMaDon.Text.Trim()));

                    int rows = updateCmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        tran.Rollback();
                        MessageBox.Show("Đơn đã được xử lý trước đó hoặc không hợp lệ.");
                        return;
                    }
                }

                int maThongBao = GetNextNotificationId(conn, tran);
                string tieuDe = newStatus == "Đã duyệt"
                    ? "Đơn nghỉ phép đã được duyệt"
                    : "Đơn nghỉ phép đã bị từ chối";

                string noiDung = BuildNotificationContent(newStatus);

                string insertNotification = @"
                    INSERT INTO THONG_BAO
                    (
                        Ma_thong_bao,
                        Ma_nhan_vien,
                        Tieu_de,
                        Noi_dung,
                        Ngay_tao,
                        Da_doc,
                        Loai_thong_bao,
                        Ma_don_lien_quan
                    )
                    VALUES
                    (
                        @Ma_thong_bao,
                        @Ma_nhan_vien,
                        @Tieu_de,
                        @Noi_dung,
                        GETDATE(),
                        0,
                        @Loai_thong_bao,
                        @Ma_don_lien_quan
                    )";

                using (SqlCommand insertCmd = new SqlCommand(insertNotification, conn, tran))
                {
                    insertCmd.Parameters.AddWithValue("@Ma_thong_bao", maThongBao);
                    insertCmd.Parameters.AddWithValue("@Ma_nhan_vien", int.Parse(txtMaNhanVien.Text.Trim()));
                    insertCmd.Parameters.AddWithValue("@Tieu_de", tieuDe);
                    insertCmd.Parameters.AddWithValue("@Noi_dung", noiDung);
                    insertCmd.Parameters.AddWithValue("@Loai_thong_bao", "Duyệt nghỉ phép");
                    insertCmd.Parameters.AddWithValue("@Ma_don_lien_quan", int.Parse(txtMaDon.Text.Trim()));
                    insertCmd.ExecuteNonQuery();
                }

                tran.Commit();

                MessageBox.Show(newStatus == "Đã duyệt"
                    ? "Duyệt đơn thành công."
                    : "Từ chối đơn thành công.");

                LoadDonNghiPhep();
                ConfigureDataGridView();
                ClearDetail();
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    try { tran.Rollback(); } catch { }
                }

                MessageBox.Show("Lỗi xử lý đơn nghỉ phép: " + ex.Message);
            }
            finally
            {
                if (tran != null) tran.Dispose();
                if (conn != null) conn.Dispose();

                isProcessing = false;
                btnDuyet.Enabled = true;
                btnTuChoi.Enabled = true;
            }
        }

        private int GetNextNotificationId(SqlConnection conn, SqlTransaction tran)
        {
            string query = @"
                SELECT ISNULL(MAX(Ma_thong_bao), 0) + 1
                FROM THONG_BAO WITH (UPDLOCK, HOLDLOCK)";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private string BuildNotificationContent(string status)
        {
            return
                $"Đơn nghỉ phép của bạn đã được xử lý.\r\n" +
                $"Mã đơn: {txtMaDon.Text.Trim()}\r\n" +
                $"Ngày bắt đầu: {txtNgayBatDau.Text.Trim()}\r\n" +
                $"Ngày kết thúc: {txtNgayKetThuc.Text.Trim()}\r\n" +
                $"Lý do: {txtLyDo.Text.Trim()}\r\n" +
                $"Kết quả: {status}";
        }

        private void ClearDetail()
        {
            txtMaDon.Clear();
            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            txtNgayBatDau.Clear();
            txtNgayKetThuc.Clear();
            txtTinhTrang.Clear();
            txtLyDo.Clear();
        }
    }
}