using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhanSu.Common;

namespace QuanLyNhanSu.KeToan.ThuongPhat
{
    public partial class frmDuyetThuongPhatKeToan : Form
    {
        private const string TrangThaiChoDuyet = "Chờ duyệt";
        private const string TrangThaiDaDuyet = "Đã duyệt";
        private const string TrangThaiTuChoi = "Từ chối";

        private bool isProcessing;

        public frmDuyetThuongPhatKeToan()
        {
            InitializeComponent();

            this.Load += frmDuyetThuongPhatKeToan_Load;
            dataGridViewChoDuyet.CellClick += dataGridViewChoDuyet_CellClick;
            btnDuyet.Click += btnDuyet_Click;
            btnTuChoi.Click += btnTuChoi_Click;
            btnTaiLai.Click += btnTaiLai_Click;
        }

        private void frmDuyetThuongPhatKeToan_Load(object sender, EventArgs e)
        {
            try
            {
                KetoanRoleInfo role = KetoanPermissionHelper.GetCurrentRole();

                if (!role.CanApproveRewardPenalty)
                {
                    MessageBox.Show("Chỉ trưởng phòng kế toán hoặc Admin mới được duyệt thưởng/phạt.");
                    Close();
                    return;
                }

                LoadPendingData();
                ConfigureDataGridView();
                ClearDetail();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở màn hình duyệt thưởng/phạt: " + ex.Message);
                Close();
            }
        }

        private void LoadPendingData()
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = @"
                    SELECT
                        kt.Ma_quyet_dinh,
                        kt.Ngay_lap,
                        kt.Loai_quyet_dinh,
                        kt.Ma_nhan_vien,
                        CAST(kt.Ma_nhan_vien AS NVARCHAR(20)) + N' - ' + kt.Ten_nhan_vien AS Nhan_vien,
                        kt.Ten_chuc_vu,
                        kt.Ten_phong_ban,
                        kt.Muc_thuong_phat,
                        kt.Ly_do,
                        ISNULL(kt.Trang_thai, N'Đã duyệt') AS Trang_thai,
                        kt.Nguoi_tao,
                        ISNULL(nv_tao.Ten_nhan_vien, N'') AS Ten_nguoi_tao
                    FROM KHEN_THUONG_KY_LUAT kt
                    LEFT JOIN NHAN_VIEN nv_tao ON kt.Nguoi_tao = nv_tao.Ma_nhan_vien
                    WHERE ISNULL(kt.Trang_thai, N'Đã duyệt') = N'Chờ duyệt'
                    ORDER BY kt.Ngay_lap DESC, kt.Ma_quyet_dinh DESC";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewChoDuyet.DataSource = dt;
                }
            }
        }

        private void ConfigureDataGridView()
        {
            if (dataGridViewChoDuyet.Columns.Count == 0) return;

            dataGridViewChoDuyet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewChoDuyet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewChoDuyet.MultiSelect = false;
            dataGridViewChoDuyet.ReadOnly = true;
            dataGridViewChoDuyet.AllowUserToAddRows = false;
            dataGridViewChoDuyet.AllowUserToDeleteRows = false;

            SetHeader("Ma_quyet_dinh", "Mã QĐ");
            SetHeader("Ngay_lap", "Ngày lập");
            SetHeader("Loai_quyet_dinh", "Loại");
            SetHeader("Ma_nhan_vien", "Mã NV");
            SetHeader("Nhan_vien", "Nhân viên");
            SetHeader("Ten_chuc_vu", "Chức vụ");
            SetHeader("Ten_phong_ban", "Phòng ban");
            SetHeader("Muc_thuong_phat", "Mức thưởng/phạt");
            SetHeader("Ly_do", "Lý do");
            SetHeader("Trang_thai", "Trạng thái");
            SetHeader("Ten_nguoi_tao", "Người tạo");

            if (dataGridViewChoDuyet.Columns.Contains("Muc_thuong_phat"))
                dataGridViewChoDuyet.Columns["Muc_thuong_phat"].DefaultCellStyle.Format = "N0";

            if (dataGridViewChoDuyet.Columns.Contains("Nguoi_tao"))
                dataGridViewChoDuyet.Columns["Nguoi_tao"].Visible = false;
        }

        private void SetHeader(string columnName, string headerText)
        {
            if (dataGridViewChoDuyet.Columns.Contains(columnName))
                dataGridViewChoDuyet.Columns[columnName].HeaderText = headerText;
        }

        private void dataGridViewChoDuyet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            FillDetail(dataGridViewChoDuyet.Rows[e.RowIndex]);
        }

        private void FillDetail(DataGridViewRow row)
        {
            txtMaQuyetDinh.Text = row.Cells["Ma_quyet_dinh"].Value?.ToString() ?? "";

            if (DateTime.TryParse(row.Cells["Ngay_lap"].Value?.ToString(), out DateTime ngayLap))
                txtNgayLap.Text = ngayLap.ToString("dd/MM/yyyy");
            else
                txtNgayLap.Clear();

            txtNhanVien.Text = row.Cells["Nhan_vien"].Value?.ToString() ?? "";
            txtLoaiQuyetDinh.Text = row.Cells["Loai_quyet_dinh"].Value?.ToString() ?? "";
            txtChucVu.Text = row.Cells["Ten_chuc_vu"].Value?.ToString() ?? "";
            txtPhongBan.Text = row.Cells["Ten_phong_ban"].Value?.ToString() ?? "";

            decimal mucTien = 0;
            decimal.TryParse(row.Cells["Muc_thuong_phat"].Value?.ToString(), out mucTien);
            txtMucThuongPhat.Text = mucTien.ToString("N0");

            string nguoiTao = row.Cells["Ten_nguoi_tao"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(nguoiTao))
                nguoiTao = row.Cells["Nguoi_tao"].Value?.ToString();

            txtNguoiTao.Text = nguoiTao ?? "";
            txtLyDo.Text = row.Cells["Ly_do"].Value?.ToString() ?? "";
            txtGhiChuDuyet.Clear();
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;

            ProcessDecision(TrangThaiDaDuyet);
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;

            if (string.IsNullOrWhiteSpace(txtGhiChuDuyet.Text))
            {
                MessageBox.Show("Vui lòng nhập lý do từ chối.");
                txtGhiChuDuyet.Focus();
                return;
            }

            ProcessDecision(TrangThaiTuChoi);
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadPendingData();
            ConfigureDataGridView();
            ClearDetail();
        }

        private void ProcessDecision(string trangThaiMoi)
        {
            if (string.IsNullOrWhiteSpace(txtMaQuyetDinh.Text))
            {
                MessageBox.Show("Vui lòng chọn yêu cầu cần xử lý.");
                return;
            }

            if (dataGridViewChoDuyet.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn yêu cầu cần xử lý.");
                return;
            }

            isProcessing = true;
            SqlTransaction tran = null;

            try
            {
                int maQuyetDinh = int.Parse(txtMaQuyetDinh.Text.Trim());
                int maNhanVien = Convert.ToInt32(dataGridViewChoDuyet.CurrentRow.Cells["Ma_nhan_vien"].Value);
                DateTime ngayLap = Convert.ToDateTime(dataGridViewChoDuyet.CurrentRow.Cells["Ngay_lap"].Value);

                using (SqlConnection conn = DbConnectionFactory.CreateConnection())
                {
                    conn.Open();
                    tran = conn.BeginTransaction(IsolationLevel.Serializable);

                    string query = @"
                        UPDATE KHEN_THUONG_KY_LUAT
                        SET
                            Trang_thai = @Trang_thai,
                            Nguoi_duyet = @Nguoi_duyet,
                            Ngay_duyet = GETDATE(),
                            Ly_do_duyet = @Ly_do_duyet
                        WHERE Ma_quyet_dinh = @Ma_quyet_dinh
                          AND Trang_thai = N'Chờ duyệt'";

                    int affectedRows;

                    using (SqlCommand cmd = new SqlCommand(query, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@Ma_quyet_dinh", maQuyetDinh);
                        cmd.Parameters.AddWithValue("@Trang_thai", trangThaiMoi);
                        cmd.Parameters.AddWithValue("@Nguoi_duyet", GetSessionEmployeeValue());
                        cmd.Parameters.AddWithValue("@Ly_do_duyet", string.IsNullOrWhiteSpace(txtGhiChuDuyet.Text)
                            ? (object)DBNull.Value
                            : txtGhiChuDuyet.Text.Trim());

                        affectedRows = cmd.ExecuteNonQuery();
                    }

                    if (affectedRows == 0)
                    {
                        tran.Rollback();
                        MessageBox.Show("Yêu cầu này không còn ở trạng thái chờ duyệt.");
                        return;
                    }

                    if (trangThaiMoi == TrangThaiDaDuyet)
                        UpdateSalaryAfterApproval(conn, tran, maNhanVien, ngayLap.Month, ngayLap.Year);

                    tran.Commit();
                }

                MessageBox.Show(trangThaiMoi == TrangThaiDaDuyet
                    ? "Đã duyệt yêu cầu thưởng/phạt."
                    : "Đã từ chối yêu cầu thưởng/phạt.");

                LoadPendingData();
                ConfigureDataGridView();
                ClearDetail();
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    try { tran.Rollback(); } catch { }
                }

                MessageBox.Show("Lỗi xử lý duyệt thưởng/phạt: " + ex.Message);
            }
            finally
            {
                if (tran != null) tran.Dispose();
                isProcessing = false;
            }
        }

        private void UpdateSalaryAfterApproval(SqlConnection conn, SqlTransaction tran, int maNhanVien, int thang, int nam)
        {
            string query = @"
                UPDATE l
                SET
                    l.Muc_thuong_phat = ISNULL(kt.Tong_thuong_phat, 0),
                    l.Thuc_nhan = (ISNULL(l.Luong_co_ban, 0) * ISNULL(l.He_so_luong, 1))
                        + ISNULL(kt.Tong_thuong_phat, 0)
                FROM LUONG l
                OUTER APPLY
                (
                    SELECT SUM(Muc_thuong_phat) AS Tong_thuong_phat
                    FROM KHEN_THUONG_KY_LUAT
                    WHERE Ma_nhan_vien = @Ma_nhan_vien
                      AND MONTH(Ngay_lap) = @Thang
                      AND YEAR(Ngay_lap) = @Nam
                      AND ISNULL(Trang_thai, N'Đã duyệt') = N'Đã duyệt'
                ) kt
                WHERE l.Ma_nhan_vien = @Ma_nhan_vien
                  AND l.Thang = @Thang
                  AND l.Nam = @Nam";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                cmd.Parameters.AddWithValue("@Ma_nhan_vien", maNhanVien);
                cmd.Parameters.AddWithValue("@Thang", thang);
                cmd.Parameters.AddWithValue("@Nam", nam);
                cmd.ExecuteNonQuery();
            }
        }

        private object GetSessionEmployeeValue()
        {
            if (session.MaNhanVien <= 0)
                return DBNull.Value;

            return session.MaNhanVien;
        }

        private void ClearDetail()
        {
            txtMaQuyetDinh.Clear();
            txtNgayLap.Clear();
            txtNhanVien.Clear();
            txtLoaiQuyetDinh.Clear();
            txtChucVu.Clear();
            txtPhongBan.Clear();
            txtMucThuongPhat.Clear();
            txtNguoiTao.Clear();
            txtLyDo.Clear();
            txtGhiChuDuyet.Clear();
        }
    }
}
