using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace QuanLyNhanSu.NhanVien.DonNghiVaThongBao
{
    public partial class frmDonNghiPhepNhanVien : Form
    {
        private readonly string connectString =
            @"Data Source=ADMIN\PHANTAN1;Initial Catalog=QUAN_LY_NHAN_VIEN_CMC;Integrated Security=True;TrustServerCertificate=True";

        private bool isProcessing = false;

        public frmDonNghiPhepNhanVien()
        {
            InitializeComponent();
            this.Load += frmDonNghiPhepNhanVien_Load;
            btnXacNhan.Click += btnXacNhan_Click;
            btnLamMoi.Click += btnLamMoi_Click;
        }

        private void frmDonNghiPhepNhanVien_Load(object sender, EventArgs e)
        {
            LoadEmployeeInfo();

            txtLyDo.MaxLength = 255;
            dtpNgayBatDau.MinDate = DateTime.Today;
            dtpNgayKetThuc.MinDate = DateTime.Today;

            ResetFormValues();
        }

        private void LoadEmployeeInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            Ma_nhan_vien,
                            Ten_nhan_vien,
                            ISNULL(Ten_chuc_vu, N'') AS Ten_chuc_vu,
                            ISNULL(Ten_phong_ban, N'') AS Ten_phong_ban,
                            ISNULL(Tinh_trang, N'') AS Tinh_trang
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
                                txtChucVu.Text = reader["Ten_chuc_vu"].ToString();
                                txtPhongBan.Text = reader["Ten_phong_ban"].ToString();

                                string tinhTrang = reader["Tinh_trang"].ToString().Trim();
                                if (string.Equals(tinhTrang, "Nghỉ việc", StringComparison.OrdinalIgnoreCase))
                                {
                                    MessageBox.Show("Nhân viên đã nghỉ việc, không thể tạo đơn nghỉ phép.");
                                    btnXacNhan.Enabled = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin nhân viên đang đăng nhập.");
                                btnXacNhan.Enabled = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin nhân viên: " + ex.Message);
                btnXacNhan.Enabled = false;
            }
        }

        private void ResetFormValues()
        {
            dtpNgayLap.Value = DateTime.Today;
            dtpNgayBatDau.Value = DateTime.Today;
            dtpNgayKetThuc.Value = DateTime.Today;
            txtLyDo.Clear();
            txtTinhTrang.Text = "Chờ duyệt";
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;
            btnXacNhan.Enabled = false;

            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                if (!ValidateInput())
                    return;

                conn = new SqlConnection(connectString);
                conn.Open();

                tran = conn.BeginTransaction(IsolationLevel.Serializable);

                if (!IsEmployeeEligibleForLeave(conn, tran))
                {
                    tran.Rollback();
                    return;
                }

                if (HasOverlappingLeave(conn, tran))
                {
                    tran.Rollback();
                    MessageBox.Show("Đã tồn tại đơn nghỉ phép trùng khoảng thời gian này.");
                    return;
                }

                int maDon = GetNextLeaveRequestId(conn, tran);

                string query = @"
                    INSERT INTO NGHI_PHEP_THOI_VIEC
                    (
                        Ma_don,
                        Ngay_lap,
                        Loai_don,
                        Ngay_bat_dau,
                        Ngay_ket_thuc,
                        Ma_nhan_vien,
                        Ten_nhan_vien,
                        Ten_chuc_vu,
                        Ten_phong_ban,
                        Ly_do,
                        Tinh_trang
                    )
                    VALUES
                    (
                        @Ma_don,
                        @Ngay_lap,
                        @Loai_don,
                        @Ngay_bat_dau,
                        @Ngay_ket_thuc,
                        @Ma_nhan_vien,
                        @Ten_nhan_vien,
                        @Ten_chuc_vu,
                        @Ten_phong_ban,
                        @Ly_do,
                        @Tinh_trang
                    )";

                using (SqlCommand cmd = new SqlCommand(query, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@Ma_don", maDon);
                    cmd.Parameters.AddWithValue("@Ngay_lap", DateTime.Today);
                    cmd.Parameters.AddWithValue("@Loai_don", "Nghỉ phép");
                    cmd.Parameters.AddWithValue("@Ngay_bat_dau", dtpNgayBatDau.Value.Date);
                    cmd.Parameters.AddWithValue("@Ngay_ket_thuc", dtpNgayKetThuc.Value.Date);
                    cmd.Parameters.AddWithValue("@Ma_nhan_vien", int.Parse(txtMaNhanVien.Text.Trim()));
                    cmd.Parameters.AddWithValue("@Ten_nhan_vien", txtTenNhanVien.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ten_chuc_vu", txtChucVu.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ten_phong_ban", txtPhongBan.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ly_do", txtLyDo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Tinh_trang", "Chờ duyệt");

                    cmd.ExecuteNonQuery();
                }

                tran.Commit();

                MessageBox.Show("Gửi đơn nghỉ phép thành công. Trạng thái: Chờ duyệt.");
                ResetFormValues();
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    try { tran.Rollback(); } catch { }
                }

                MessageBox.Show("Lỗi gửi đơn nghỉ phép: " + ex.Message);
            }
            finally
            {
                if (tran != null) tran.Dispose();
                if (conn != null) conn.Dispose();

                isProcessing = false;
                btnXacNhan.Enabled = true;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;
            ResetFormValues();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
            {
                MessageBox.Show("Không xác định được nhân viên đang đăng nhập.");
                return false;
            }

            if (dtpNgayBatDau.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Ngày bắt đầu nghỉ không được nhỏ hơn ngày hôm nay.");
                dtpNgayBatDau.Focus();
                return false;
            }

            if (dtpNgayKetThuc.Value.Date < dtpNgayBatDau.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.");
                dtpNgayKetThuc.Focus();
                return false;
            }

            string lyDo = txtLyDo.Text.Trim();

            if (string.IsNullOrWhiteSpace(lyDo))
            {
                MessageBox.Show("Vui lòng nhập lý do nghỉ phép.");
                txtLyDo.Focus();
                return false;
            }

            if (lyDo.Length > 255)
            {
                MessageBox.Show("Lý do không được vượt quá 255 ký tự.");
                txtLyDo.Focus();
                return false;
            }

            return true;
        }

        private bool IsEmployeeEligibleForLeave(SqlConnection conn, SqlTransaction tran)
        {
            string query = @"
                SELECT ISNULL(Tinh_trang, N'')
                FROM NHAN_VIEN
                WHERE Ma_nhan_vien = @Ma_nhan_vien";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                cmd.Parameters.AddWithValue("@Ma_nhan_vien", int.Parse(txtMaNhanVien.Text.Trim()));

                object result = cmd.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên.");
                    return false;
                }

                string tinhTrang = result.ToString().Trim();

                if (string.Equals(tinhTrang, "Nghỉ việc", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Nhân viên đã nghỉ việc, không thể gửi đơn nghỉ phép.");
                    return false;
                }

                return true;
            }
        }

        private bool HasOverlappingLeave(SqlConnection conn, SqlTransaction tran)
        {
            string query = @"
                SELECT COUNT(*)
                FROM NGHI_PHEP_THOI_VIEC
                WHERE Ma_nhan_vien = @Ma_nhan_vien
                  AND Loai_don = N'Nghỉ phép'
                  AND Tinh_trang IN (N'Chờ duyệt', N'Đã duyệt')
                  AND (
                        @Ngay_bat_dau BETWEEN Ngay_bat_dau AND Ngay_ket_thuc
                        OR @Ngay_ket_thuc BETWEEN Ngay_bat_dau AND Ngay_ket_thuc
                        OR Ngay_bat_dau BETWEEN @Ngay_bat_dau AND @Ngay_ket_thuc
                        OR Ngay_ket_thuc BETWEEN @Ngay_bat_dau AND @Ngay_ket_thuc
                      )";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                cmd.Parameters.AddWithValue("@Ma_nhan_vien", int.Parse(txtMaNhanVien.Text.Trim()));
                cmd.Parameters.AddWithValue("@Ngay_bat_dau", dtpNgayBatDau.Value.Date);
                cmd.Parameters.AddWithValue("@Ngay_ket_thuc", dtpNgayKetThuc.Value.Date);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private int GetNextLeaveRequestId(SqlConnection conn, SqlTransaction tran)
        {
            string query = @"
                SELECT ISNULL(MAX(Ma_don), 0) + 1
                FROM NGHI_PHEP_THOI_VIEC WITH (UPDLOCK, HOLDLOCK)";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}