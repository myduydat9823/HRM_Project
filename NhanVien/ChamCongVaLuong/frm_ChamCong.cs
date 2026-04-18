using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace QuanLyNhanSu.NhanVien.ChamCongVaLuong
{
    public partial class frm_ChamCong : Form
    {
        private readonly string connectString =
            @"Data Source=ADMIN\PHANTAN1;Initial Catalog=QUAN_LY_NHAN_VIEN_CMC;Integrated Security=True;TrustServerCertificate=True";

        private readonly TimeSpan gioBatDauLam = new TimeSpan(8, 0, 0);
        private readonly TimeSpan gioTanLam = new TimeSpan(17, 0, 0);

        private bool isProcessing = false;

        public frm_ChamCong()
        {
            InitializeComponent();
            this.Load += frmChamCongNhanVien_Load;
            btnCheckIn.Click += btnCheckIn_Click;
            btnCheckOut.Click += btnCheckOut_Click;
        }

        private void frmChamCongNhanVien_Load(object sender, EventArgs e)
        {
            LoadThongTinNhanVien();
            LoadChamCongHomNay();
        }

        private void LoadThongTinNhanVien()
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
                                txtNgayHomNay.Text = DateTime.Today.ToString("dd/MM/yyyy");
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

        private void LoadChamCongHomNay()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();

                    if (IsOnApprovedLeave(conn, session.MaNhanVien, DateTime.Today))
                    {
                        EnsureLeaveAttendanceRow(conn);

                        txtTrangThai.Text = "Hôm nay có nghỉ phép đã duyệt.";
                        btnCheckIn.Enabled = false;
                        btnCheckOut.Enabled = false;

                        LoadAttendanceDisplay(conn);
                        return;
                    }

                    LoadAttendanceDisplay(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải trạng thái chấm công: " + ex.Message);
            }
        }

        private void LoadAttendanceDisplay(SqlConnection conn)
        {
            string query = @"
                SELECT Gio_vao, Gio_ra, Ghi_chu, Nghi_phep
                FROM CHAM_CONG
                WHERE Ma_nhan_vien = @Ma_nhan_vien
                  AND Ngay_cham_cong = @Ngay_cham_cong";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Ma_nhan_vien", session.MaNhanVien);
                cmd.Parameters.AddWithValue("@Ngay_cham_cong", DateTime.Today);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtGioVao.Text = reader["Gio_vao"] == DBNull.Value
                            ? ""
                            : TimeSpan.Parse(reader["Gio_vao"].ToString()).ToString();

                        txtGioRa.Text = reader["Gio_ra"] == DBNull.Value
                            ? ""
                            : TimeSpan.Parse(reader["Gio_ra"].ToString()).ToString();

                        bool coCheckIn = reader["Gio_vao"] != DBNull.Value;
                        bool coCheckOut = reader["Gio_ra"] != DBNull.Value;
                        bool nghiPhep = reader["Nghi_phep"] != DBNull.Value && Convert.ToBoolean(reader["Nghi_phep"]);

                        if (nghiPhep)
                        {
                            txtTrangThai.Text = reader["Ghi_chu"] == DBNull.Value ? "Nghỉ phép" : reader["Ghi_chu"].ToString();
                            btnCheckIn.Enabled = false;
                            btnCheckOut.Enabled = false;
                        }
                        else if (coCheckIn && !coCheckOut)
                        {
                            txtTrangThai.Text = "Đã check-in, chưa check-out.";
                            btnCheckIn.Enabled = false;
                            btnCheckOut.Enabled = true;
                        }
                        else if (coCheckIn && coCheckOut)
                        {
                            txtTrangThai.Text = reader["Ghi_chu"] == DBNull.Value ? "Đã chấm công xong." : reader["Ghi_chu"].ToString();
                            btnCheckIn.Enabled = false;
                            btnCheckOut.Enabled = false;
                        }
                        else
                        {
                            txtTrangThai.Text = "Chưa chấm công hôm nay.";
                            btnCheckIn.Enabled = true;
                            btnCheckOut.Enabled = false;
                        }
                    }
                    else
                    {
                        txtGioVao.Text = "";
                        txtGioRa.Text = "";
                        txtTrangThai.Text = "Chưa chấm công hôm nay.";
                        btnCheckIn.Enabled = true;
                        btnCheckOut.Enabled = false;
                    }
                }
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;
            btnCheckIn.Enabled = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();

                    if (IsOnApprovedLeave(conn, session.MaNhanVien, DateTime.Today))
                    {
                        EnsureLeaveAttendanceRow(conn);
                        MessageBox.Show("Hôm nay bạn đang nghỉ phép đã duyệt, không thể check-in.");
                        LoadChamCongHomNay();
                        return;
                    }

                    int maChamCong = GetNextAttendanceId(conn);
                    string tenNhanVien = GetEmployeeName(conn, session.MaNhanVien);
                    DateTime now = DateTime.Now;
                    bool diMuon = now.TimeOfDay > gioBatDauLam;

                    string ghiChu = diMuon
                        ? $"Đi muộn {Math.Round((now.TimeOfDay - gioBatDauLam).TotalMinutes)} phút"
                        : "Vào đúng giờ";

                    string query = @"
IF EXISTS (
    SELECT 1
    FROM CHAM_CONG
    WHERE Ma_nhan_vien = @Ma_nhan_vien
      AND Ngay_cham_cong = @Ngay_cham_cong
)
BEGIN
    RAISERROR(N'Bạn đã check-in hôm nay rồi hoặc hôm nay đã có bản ghi chấm công.', 16, 1)
END
ELSE
BEGIN
    INSERT INTO CHAM_CONG
    (
        Ma_cham_cong,
        Ma_nhan_vien,
        Ten_nhan_vien,
        Ngay_cham_cong,
        Gio_vao,
        Gio_ra,
        So_gio_lam_viec,
        Di_muon,
        Ve_som,
        Nghi_phep,
        Ghi_chu
    )
    VALUES
    (
        @Ma_cham_cong,
        @Ma_nhan_vien,
        @Ten_nhan_vien,
        @Ngay_cham_cong,
        @Gio_vao,
        NULL,
        NULL,
        @Di_muon,
        0,
        0,
        @Ghi_chu
    )
END";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma_cham_cong", maChamCong);
                        cmd.Parameters.AddWithValue("@Ma_nhan_vien", session.MaNhanVien);
                        cmd.Parameters.AddWithValue("@Ten_nhan_vien", tenNhanVien);
                        cmd.Parameters.AddWithValue("@Ngay_cham_cong", DateTime.Today);
                        cmd.Parameters.AddWithValue("@Gio_vao", now.TimeOfDay);
                        cmd.Parameters.AddWithValue("@Di_muon", diMuon);
                        cmd.Parameters.AddWithValue("@Ghi_chu", ghiChu);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Check-in thành công.");
                    LoadChamCongHomNay();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi check-in: " + ex.Message);
            }
            finally
            {
                isProcessing = false;
                LoadChamCongHomNay();
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;
            btnCheckOut.Enabled = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();

                    string queryGet = @"
                        SELECT Ma_cham_cong, Gio_vao, Gio_ra, Nghi_phep
                        FROM CHAM_CONG
                        WHERE Ma_nhan_vien = @Ma_nhan_vien
                          AND Ngay_cham_cong = @Ngay_cham_cong";

                    int maChamCong = 0;
                    TimeSpan gioVao = TimeSpan.Zero;
                    bool daCheckOut = false;
                    bool nghiPhep = false;

                    using (SqlCommand cmd = new SqlCommand(queryGet, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma_nhan_vien", session.MaNhanVien);
                        cmd.Parameters.AddWithValue("@Ngay_cham_cong", DateTime.Today);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("Bạn chưa check-in hôm nay.");
                                return;
                            }

                            maChamCong = Convert.ToInt32(reader["Ma_cham_cong"]);

                            if (reader["Nghi_phep"] != DBNull.Value)
                                nghiPhep = Convert.ToBoolean(reader["Nghi_phep"]);

                            if (nghiPhep)
                            {
                                MessageBox.Show("Hôm nay là ngày nghỉ phép, không thể check-out.");
                                return;
                            }

                            if (reader["Gio_vao"] == DBNull.Value)
                            {
                                MessageBox.Show("Bạn chưa check-in hôm nay.");
                                return;
                            }

                            gioVao = TimeSpan.Parse(reader["Gio_vao"].ToString());

                            if (reader["Gio_ra"] != DBNull.Value)
                                daCheckOut = true;
                        }
                    }

                    if (daCheckOut)
                    {
                        MessageBox.Show("Bạn đã check-out hôm nay rồi.");
                        return;
                    }

                    DateTime now = DateTime.Now;
                    bool diMuon = gioVao > gioBatDauLam;
                    bool veSom = now.TimeOfDay < gioTanLam;
                    decimal soGioLam = Math.Round((decimal)(now.TimeOfDay - gioVao).TotalHours, 2);

                    if (soGioLam < 0)
                        soGioLam = 0;

                    string ghiChu = BuildAttendanceNote(gioVao, now.TimeOfDay, diMuon, veSom);

                    string queryUpdate = @"
                        UPDATE CHAM_CONG
                        SET
                            Gio_ra = @Gio_ra,
                            So_gio_lam_viec = @So_gio_lam_viec,
                            Di_muon = @Di_muon,
                            Ve_som = @Ve_som,
                            Ghi_chu = @Ghi_chu
                        WHERE Ma_cham_cong = @Ma_cham_cong
                          AND Gio_vao IS NOT NULL
                          AND Gio_ra IS NULL
                          AND ISNULL(Nghi_phep, 0) = 0";

                    using (SqlCommand cmd = new SqlCommand(queryUpdate, conn))
                    {
                        cmd.Parameters.AddWithValue("@Gio_ra", now.TimeOfDay);
                        cmd.Parameters.AddWithValue("@So_gio_lam_viec", soGioLam);
                        cmd.Parameters.AddWithValue("@Di_muon", diMuon);
                        cmd.Parameters.AddWithValue("@Ve_som", veSom);
                        cmd.Parameters.AddWithValue("@Ghi_chu", ghiChu);
                        cmd.Parameters.AddWithValue("@Ma_cham_cong", maChamCong);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageBox.Show("Bạn đã check-out rồi hoặc dữ liệu không hợp lệ.");
                            return;
                        }
                    }

                    MessageBox.Show("Check-out thành công.");
                    LoadChamCongHomNay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi check-out: " + ex.Message);
            }
            finally
            {
                isProcessing = false;
                LoadChamCongHomNay();
            }
        }

        private bool IsOnApprovedLeave(SqlConnection conn, int maNhanVien, DateTime ngay)
        {
            string query = @"
                SELECT COUNT(*)
                FROM NGHI_PHEP_THOI_VIEC
                WHERE Ma_nhan_vien = @Ma_nhan_vien
                  AND Loai_don = N'Nghỉ phép'
                  AND Tinh_trang = N'Đã duyệt'
                  AND @Ngay BETWEEN Ngay_bat_dau AND Ngay_ket_thuc";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Ma_nhan_vien", maNhanVien);
                cmd.Parameters.AddWithValue("@Ngay", ngay.Date);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private void EnsureLeaveAttendanceRow(SqlConnection conn)
        {
            string checkQuery = @"
                SELECT COUNT(*)
                FROM CHAM_CONG
                WHERE Ma_nhan_vien = @Ma_nhan_vien
                  AND Ngay_cham_cong = @Ngay_cham_cong";

            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@Ma_nhan_vien", session.MaNhanVien);
                checkCmd.Parameters.AddWithValue("@Ngay_cham_cong", DateTime.Today);

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0) return;
            }

            int maChamCong = GetNextAttendanceId(conn);
            string tenNhanVien = GetEmployeeName(conn, session.MaNhanVien);

            string insertQuery = @"
                INSERT INTO CHAM_CONG
                (
                    Ma_cham_cong,
                    Ma_nhan_vien,
                    Ten_nhan_vien,
                    Ngay_cham_cong,
                    Gio_vao,
                    Gio_ra,
                    So_gio_lam_viec,
                    Di_muon,
                    Ve_som,
                    Nghi_phep,
                    Ghi_chu
                )
                VALUES
                (
                    @Ma_cham_cong,
                    @Ma_nhan_vien,
                    @Ten_nhan_vien,
                    @Ngay_cham_cong,
                    NULL,
                    NULL,
                    0,
                    0,
                    0,
                    1,
                    N'Nghỉ phép'
                )";

            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
            {
                insertCmd.Parameters.AddWithValue("@Ma_cham_cong", maChamCong);
                insertCmd.Parameters.AddWithValue("@Ma_nhan_vien", session.MaNhanVien);
                insertCmd.Parameters.AddWithValue("@Ten_nhan_vien", tenNhanVien);
                insertCmd.Parameters.AddWithValue("@Ngay_cham_cong", DateTime.Today);
                insertCmd.ExecuteNonQuery();
            }
        }

        private int GetNextAttendanceId(SqlConnection conn)
        {
            string query = "SELECT ISNULL(MAX(Ma_cham_cong), 0) + 1 FROM CHAM_CONG";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private string GetEmployeeName(SqlConnection conn, int maNhanVien)
        {
            string query = "SELECT Ten_nhan_vien FROM NHAN_VIEN WHERE Ma_nhan_vien = @Ma_nhan_vien";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Ma_nhan_vien", maNhanVien);
                object result = cmd.ExecuteScalar();
                return result == null ? "" : result.ToString();
            }
        }

        private string BuildAttendanceNote(TimeSpan gioVao, TimeSpan gioRa, bool diMuon, bool veSom)
        {
            string note;

            if (diMuon)
            {
                double soPhutMuon = (gioVao - gioBatDauLam).TotalMinutes;
                note = $"Đi muộn {Math.Round(soPhutMuon)} phút";
            }
            else
            {
                note = "Vào đúng giờ";
            }

            note += " | ";

            if (veSom)
            {
                double soPhutSom = (gioTanLam - gioRa).TotalMinutes;
                note += $"Về sớm {Math.Round(soPhutSom)} phút";
            }
            else
            {
                note += "Ra đúng giờ hoặc muộn hơn";
            }

            return note;
        }

        private void lblGhiChuMoc_Click(object sender, EventArgs e)
        {

        }

        private void txtTrangThai_TextChanged(object sender, EventArgs e)
        {

        }
    }
}