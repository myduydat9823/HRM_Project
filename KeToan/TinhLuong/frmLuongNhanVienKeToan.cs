using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

using QuanLyNhanSu.Common;

namespace QuanLyNhanSu.KeToan.TinhLuong
{
    public partial class frmLuongNhanVienKeToan : Form
    {
        private bool isProcessing = false;

        public frmLuongNhanVienKeToan()
        {
            InitializeComponent();

            this.Load += frmLuongNhanVienKeToan_Load;
            btnTinhLuong.Click += btnTinhLuong_Click;
            btnLoc.Click += btnLoc_Click;
            btnTaiLai.Click += btnTaiLai_Click;
            btnXuatExcel.Click += btnXuatExcel_Click;
        }

        private void frmLuongNhanVienKeToan_Load(object sender, EventArgs e)
        {
            if (!HasSalaryPermission())
            {
                this.Close();
                return;
            }

            LoadEmployeeCombobox();
            LoadMonthCombobox();
            LoadYearCombobox();
            SetCurrentMonthYear();

            LoadSalaryData();
            ConfigureDataGridView();
        }

        private bool HasSalaryPermission()
        {
            if (session.MaQuyen != 1 && session.MaQuyen != 3)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng lương.");
                return false;
            }

            return true;
        }

        private void SetActionButtonsEnabled(bool enabled)
        {
            btnTinhLuong.Enabled = enabled;
            btnLoc.Enabled = enabled;
            btnTaiLai.Enabled = enabled;
            btnXuatExcel.Enabled = enabled;
        }

        private void LoadEmployeeCombobox()
        {
            try
            {
                using (SqlConnection conn = DbConnectionFactory.CreateConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            Ma_nhan_vien,
                            Ten_nhan_vien,
                            CAST(Ma_nhan_vien AS NVARCHAR(20)) + N' - ' + Ten_nhan_vien AS Hien_thi
                        FROM NHAN_VIEN
                        WHERE Tinh_trang = N'Đang làm'
                        ORDER BY Ten_nhan_vien";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataRow rowAll = dt.NewRow();
                    rowAll["Ma_nhan_vien"] = DBNull.Value;
                    rowAll["Ten_nhan_vien"] = "";
                    rowAll["Hien_thi"] = "-- Tất cả nhân viên --";
                    dt.Rows.InsertAt(rowAll, 0);

                    cmbNhanVien.DataSource = dt;
                    cmbNhanVien.DisplayMember = "Hien_thi";
                    cmbNhanVien.ValueMember = "Ma_nhan_vien";
                    cmbNhanVien.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message);
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

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            if (!HasSalaryPermission()) return;
            if (isProcessing) return;

            isProcessing = true;
            SetActionButtonsEnabled(false);

            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                if (cmbThang.SelectedItem == null || cmbNam.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn tháng và năm.");
                    return;
                }

                int thang = Convert.ToInt32(cmbThang.SelectedItem);
                int nam = Convert.ToInt32(cmbNam.SelectedItem);
                int? maNhanVien = null;

                if (cmbNhanVien.SelectedIndex > 0 && cmbNhanVien.SelectedValue != null)
                {
                    maNhanVien = Convert.ToInt32(cmbNhanVien.SelectedValue);
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn tính lương tháng " + thang + "/" + nam + " không?",
                    "Xác nhận tính lương",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;

                conn = DbConnectionFactory.CreateConnection();
                conn.Open();

                tran = conn.BeginTransaction(IsolationLevel.Serializable);

                DataTable salarySource = GetSalarySourceData(conn, tran, thang, nam, maNhanVien);

                if (salarySource.Rows.Count == 0)
                {
                    tran.Rollback();
                    MessageBox.Show("Không có nhân viên nào để tính lương.");
                    return;
                }

                foreach (DataRow row in salarySource.Rows)
                {
                    SaveSalaryRow(conn, tran, row, thang, nam);
                }

                tran.Commit();

                MessageBox.Show("Tính lương thành công.");

                LoadSalaryData();
                ConfigureDataGridView();
            }
            catch (SqlException ex)
            {
                if (tran != null)
                {
                    try { tran.Rollback(); } catch { }
                }

                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    MessageBox.Show("Dữ liệu lương bị trùng. Mỗi nhân viên chỉ có một bảng lương trong một tháng.");
                }
                else
                {
                    MessageBox.Show("Lỗi SQL khi tính lương: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    try { tran.Rollback(); } catch { }
                }

                MessageBox.Show("Lỗi tính lương: " + ex.Message);
            }
            finally
            {
                if (tran != null) tran.Dispose();
                if (conn != null) conn.Dispose();

                isProcessing = false;
                SetActionButtonsEnabled(true);
            }
        }

        private DataTable GetSalarySourceData(SqlConnection conn, SqlTransaction tran, int thang, int nam, int? maNhanVien)
        {
            DateTime tuNgay = new DateTime(nam, thang, 1);
            DateTime denNgay = tuNgay.AddMonths(1).AddDays(-1);

            string query = @"
                ;WITH ChamCongTongHop AS
                (
                    SELECT
                        Ma_nhan_vien,
                        COUNT(*) AS Tong_so_cong,
                        SUM(ISNULL(So_gio_lam_viec, 0)) AS Tong_gio_lam,
                        SUM(CASE
                                WHEN ISNULL(Di_muon, 0) = 1
                                     OR (Gio_vao IS NOT NULL AND Gio_vao > CAST('08:00:00' AS TIME))
                                THEN 1 ELSE 0
                            END) AS So_ngay_di_muon,
                        SUM(CASE
                                WHEN Gio_ra IS NOT NULL AND Gio_ra < CAST('17:00:00' AS TIME)
                                THEN 1 ELSE 0
                            END) AS So_ngay_ve_som,
                        SUM(CASE
                                WHEN ISNULL(Nghi_phep, 0) = 1
                                THEN 1 ELSE 0
                            END) AS So_ngay_nghi_phep_cham_cong
                    FROM CHAM_CONG
                    WHERE MONTH(Ngay_cham_cong) = @Thang
                      AND YEAR(Ngay_cham_cong) = @Nam
                    GROUP BY Ma_nhan_vien
                ),
                NghiPhepTongHop AS
                (
                    SELECT
                        Ma_nhan_vien,
                        SUM(
                            DATEDIFF(
                                DAY,
                                CASE WHEN Ngay_bat_dau < @TuNgay THEN @TuNgay ELSE Ngay_bat_dau END,
                                CASE WHEN Ngay_ket_thuc > @DenNgay THEN @DenNgay ELSE Ngay_ket_thuc END
                            ) + 1
                        ) AS So_ngay_nghi_duyet
                    FROM NGHI_PHEP_THOI_VIEC
                    WHERE Loai_don = N'Nghỉ phép'
                      AND Tinh_trang = N'Đã duyệt'
                      AND Ngay_bat_dau <= @DenNgay
                      AND Ngay_ket_thuc >= @TuNgay
                    GROUP BY Ma_nhan_vien
                )
                SELECT
                    nv.Ma_nhan_vien,
                    nv.Ten_nhan_vien,
                    nv.Luong_co_ban,
                    ISNULL(cv.He_so_luong, 1) AS He_so_luong,

                    nv.Luong_co_ban * ISNULL(cv.He_so_luong, 1) AS Luong_chuc_vu,

                    ISNULL(kt.Tong_thuong_phat, 0) AS Tong_thuong_phat,

                    (nv.Luong_co_ban * ISNULL(cv.He_so_luong, 1))
                        + ISNULL(kt.Tong_thuong_phat, 0) AS Thuc_nhan,

                    ISNULL(ccth.Tong_so_cong, 0) AS Tong_so_cong,
                    ISNULL(ccth.Tong_gio_lam, 0) AS Tong_gio_lam,
                    CASE
                        WHEN ISNULL(npth.So_ngay_nghi_duyet, 0) > ISNULL(ccth.So_ngay_nghi_phep_cham_cong, 0)
                        THEN ISNULL(npth.So_ngay_nghi_duyet, 0)
                        ELSE ISNULL(ccth.So_ngay_nghi_phep_cham_cong, 0)
                    END AS So_ngay_nghi_phep,
                    ISNULL(ccth.So_ngay_di_muon, 0) AS So_ngay_di_muon,
                    ISNULL(ccth.So_ngay_ve_som, 0) AS So_ngay_ve_som
                FROM NHAN_VIEN nv
                LEFT JOIN CHUC_VU cv ON nv.Ma_chuc_vu = cv.Ma_chuc_vu
                LEFT JOIN ChamCongTongHop ccth ON nv.Ma_nhan_vien = ccth.Ma_nhan_vien
                LEFT JOIN NghiPhepTongHop npth ON nv.Ma_nhan_vien = npth.Ma_nhan_vien
                LEFT JOIN
                (
                    SELECT
                        Ma_nhan_vien,
                        SUM(Muc_thuong_phat) AS Tong_thuong_phat
                    FROM KHEN_THUONG_KY_LUAT
                    WHERE MONTH(Ngay_lap) = @Thang
                      AND YEAR(Ngay_lap) = @Nam
                      AND ISNULL(Trang_thai, N'Đã duyệt') = N'Đã duyệt'
                    GROUP BY Ma_nhan_vien
                ) kt ON nv.Ma_nhan_vien = kt.Ma_nhan_vien
                WHERE nv.Tinh_trang = N'Đang làm'";

            if (maNhanVien.HasValue)
            {
                query += " AND nv.Ma_nhan_vien = @Ma_nhan_vien";
            }

            query += " ORDER BY nv.Ten_nhan_vien";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                cmd.Parameters.AddWithValue("@Thang", thang);
                cmd.Parameters.AddWithValue("@Nam", nam);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                if (maNhanVien.HasValue)
                {
                    cmd.Parameters.AddWithValue("@Ma_nhan_vien", maNhanVien.Value);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        private void SaveSalaryRow(SqlConnection conn, SqlTransaction tran, DataRow row, int thang, int nam)
        {
            int maNhanVien = Convert.ToInt32(row["Ma_nhan_vien"]);
            string tenNhanVien = row["Ten_nhan_vien"].ToString();

            decimal luongCoBan = Convert.ToDecimal(row["Luong_co_ban"]);
            decimal heSoLuong = Convert.ToDecimal(row["He_so_luong"]);
            decimal luongChucVu = Convert.ToDecimal(row["Luong_chuc_vu"]);
            decimal tongThuongPhat = Convert.ToDecimal(row["Tong_thuong_phat"]);
            decimal thucNhan = Convert.ToDecimal(row["Thuc_nhan"]);
            int tongSoCong = Convert.ToInt32(row["Tong_so_cong"]);
            decimal tongGioLam = Convert.ToDecimal(row["Tong_gio_lam"]);
            int soNgayNghiPhep = Convert.ToInt32(row["So_ngay_nghi_phep"]);
            int soNgayDiMuon = Convert.ToInt32(row["So_ngay_di_muon"]);
            int soNgayVeSom = Convert.ToInt32(row["So_ngay_ve_som"]);

            string query = @"
                IF EXISTS (
                    SELECT 1
                    FROM LUONG WITH (UPDLOCK, HOLDLOCK)
                    WHERE Ma_nhan_vien = @Ma_nhan_vien
                      AND Thang = @Thang
                      AND Nam = @Nam
                )
                BEGIN
                    UPDATE LUONG
                    SET
                        Ten_nhan_vien = @Ten_nhan_vien,
                        Luong_co_ban = @Luong_co_ban,
                        He_so_luong = @He_so_luong,
                        Luong_chuc_vu = @Luong_chuc_vu,
                        Muc_thuong_phat = @Muc_thuong_phat,
                        Thuc_nhan = @Thuc_nhan,
                        Ghi_chu = @Ghi_chu
                    WHERE Ma_nhan_vien = @Ma_nhan_vien
                      AND Thang = @Thang
                      AND Nam = @Nam
                END
                ELSE
                BEGIN
                    INSERT INTO LUONG
                    (
                        Ma_luong,
                        Ma_nhan_vien,
                        Ten_nhan_vien,
                        Ma_cham_cong,
                        Thang,
                        Nam,
                        Luong_co_ban,
                        He_so_luong,
                        Luong_chuc_vu,
                        Muc_thuong_phat,
                        Thuc_nhan,
                        Ghi_chu
                    )
                    VALUES
                    (
                        @Ma_luong,
                        @Ma_nhan_vien,
                        @Ten_nhan_vien,
                        NULL,
                        @Thang,
                        @Nam,
                        @Luong_co_ban,
                        @He_so_luong,
                        @Luong_chuc_vu,
                        @Muc_thuong_phat,
                        @Thuc_nhan,
                        @Ghi_chu
                    )
                END";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                cmd.Parameters.AddWithValue("@Ma_luong", GetNextSalaryId(conn, tran));
                cmd.Parameters.AddWithValue("@Ma_nhan_vien", maNhanVien);
                cmd.Parameters.AddWithValue("@Ten_nhan_vien", tenNhanVien);
                cmd.Parameters.AddWithValue("@Thang", thang);
                cmd.Parameters.AddWithValue("@Nam", nam);
                cmd.Parameters.AddWithValue("@Luong_co_ban", luongCoBan);
                cmd.Parameters.AddWithValue("@He_so_luong", heSoLuong);
                cmd.Parameters.AddWithValue("@Luong_chuc_vu", luongChucVu);
                cmd.Parameters.AddWithValue("@Muc_thuong_phat", tongThuongPhat);
                cmd.Parameters.AddWithValue("@Thuc_nhan", thucNhan);
                cmd.Parameters.AddWithValue("@Ghi_chu",
                    "Luong = Luong co ban x He so + Thuong/phat; " +
                    "Cong: " + tongSoCong +
                    "; Gio lam: " + tongGioLam.ToString("0.##") +
                    "; Nghi phep: " + soNgayNghiPhep +
                    "; Di muon: " + soNgayDiMuon +
                    "; Ve som: " + soNgayVeSom);

                cmd.ExecuteNonQuery();
            }
        }

        private int GetNextSalaryId(SqlConnection conn, SqlTransaction tran)
        {
            string query = @"
                SELECT ISNULL(MAX(Ma_luong), 0) + 1
                FROM LUONG WITH (UPDLOCK, HOLDLOCK)";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void LoadSalaryData()
        {
            try
            {
                if (cmbThang.SelectedItem == null || cmbNam.SelectedItem == null)
                    return;

                int thang = Convert.ToInt32(cmbThang.SelectedItem);
                int nam = Convert.ToInt32(cmbNam.SelectedItem);
                DateTime tuNgay = new DateTime(nam, thang, 1);
                DateTime denNgay = tuNgay.AddMonths(1).AddDays(-1);

                using (SqlConnection conn = DbConnectionFactory.CreateConnection())
                {
                    conn.Open();

                    string query = @"
                        ;WITH ChamCongTongHop AS
                        (
                            SELECT
                                Ma_nhan_vien,
                                COUNT(*) AS Tong_so_cong,
                                SUM(ISNULL(So_gio_lam_viec, 0)) AS Tong_gio_lam,
                                SUM(CASE
                                        WHEN ISNULL(Di_muon, 0) = 1
                                             OR (Gio_vao IS NOT NULL AND Gio_vao > CAST('08:00:00' AS TIME))
                                        THEN 1 ELSE 0
                                    END) AS So_ngay_di_muon,
                                SUM(CASE
                                        WHEN Gio_ra IS NOT NULL AND Gio_ra < CAST('17:00:00' AS TIME)
                                        THEN 1 ELSE 0
                                    END) AS So_ngay_ve_som,
                                SUM(CASE
                                        WHEN ISNULL(Nghi_phep, 0) = 1
                                        THEN 1 ELSE 0
                                    END) AS So_ngay_nghi_phep_cham_cong
                            FROM CHAM_CONG
                            WHERE MONTH(Ngay_cham_cong) = @Thang
                              AND YEAR(Ngay_cham_cong) = @Nam
                            GROUP BY Ma_nhan_vien
                        ),
                        NghiPhepTongHop AS
                        (
                            SELECT
                                Ma_nhan_vien,
                                SUM(
                                    DATEDIFF(
                                        DAY,
                                        CASE WHEN Ngay_bat_dau < @TuNgay THEN @TuNgay ELSE Ngay_bat_dau END,
                                        CASE WHEN Ngay_ket_thuc > @DenNgay THEN @DenNgay ELSE Ngay_ket_thuc END
                                    ) + 1
                                ) AS So_ngay_nghi_duyet
                            FROM NGHI_PHEP_THOI_VIEC
                            WHERE Loai_don = N'Nghỉ phép'
                              AND Tinh_trang = N'Đã duyệt'
                              AND Ngay_bat_dau <= @DenNgay
                              AND Ngay_ket_thuc >= @TuNgay
                            GROUP BY Ma_nhan_vien
                        )
                        SELECT
                            l.Ma_luong,
                            l.Ma_nhan_vien,
                            l.Ten_nhan_vien,
                            ISNULL(nv.Ten_phong_ban, N'') AS Ten_phong_ban,
                            ISNULL(nv.Ten_chuc_vu, N'') AS Ten_chuc_vu,
                            ISNULL(nv.So_tai_khoan, N'') AS So_tai_khoan,
                            ISNULL(nv.Ten_ngan_hang, N'') AS Ten_ngan_hang,
                            l.Thang,
                            l.Nam,
                            ISNULL(ccth.Tong_so_cong, 0) AS Tong_so_cong,
                            ISNULL(ccth.Tong_gio_lam, 0) AS Tong_gio_lam,
                            CASE
                                WHEN ISNULL(npth.So_ngay_nghi_duyet, 0) > ISNULL(ccth.So_ngay_nghi_phep_cham_cong, 0)
                                THEN ISNULL(npth.So_ngay_nghi_duyet, 0)
                                ELSE ISNULL(ccth.So_ngay_nghi_phep_cham_cong, 0)
                            END AS So_ngay_nghi_phep,
                            ISNULL(ccth.So_ngay_di_muon, 0) AS So_ngay_di_muon,
                            ISNULL(ccth.So_ngay_ve_som, 0) AS So_ngay_ve_som,
                            l.Luong_co_ban,
                            l.He_so_luong,
                            l.Luong_chuc_vu,
                            l.Muc_thuong_phat,
                            l.Thuc_nhan,
                            l.Ghi_chu
                        FROM LUONG l
                        LEFT JOIN NHAN_VIEN nv ON l.Ma_nhan_vien = nv.Ma_nhan_vien
                        LEFT JOIN ChamCongTongHop ccth ON l.Ma_nhan_vien = ccth.Ma_nhan_vien
                        LEFT JOIN NghiPhepTongHop npth ON l.Ma_nhan_vien = npth.Ma_nhan_vien
                        WHERE l.Thang = @Thang
                          AND l.Nam = @Nam";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                    if (cmbNhanVien.SelectedIndex > 0 && cmbNhanVien.SelectedValue != null)
                    {
                        query += " AND l.Ma_nhan_vien = @Ma_nhan_vien";
                        cmd.Parameters.AddWithValue("@Ma_nhan_vien", Convert.ToInt32(cmbNhanVien.SelectedValue));
                    }

                    query += " ORDER BY l.Ten_nhan_vien";
                    cmd.CommandText = query;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewLuong.DataSource = dt;
                    CalculateSalarySummary(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bảng lương: " + ex.Message);
            }
        }

        private void CalculateSalarySummary(DataTable dt)
        {
            int soNhanVien = dt.Rows.Count;
            decimal tongThuongPhat = 0;
            decimal tongThucNhan = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Muc_thuong_phat"] != DBNull.Value)
                    tongThuongPhat += Convert.ToDecimal(row["Muc_thuong_phat"]);

                if (row["Thuc_nhan"] != DBNull.Value)
                    tongThucNhan += Convert.ToDecimal(row["Thuc_nhan"]);
            }

            txtSoNhanVien.Text = soNhanVien.ToString();
            txtTongThuongPhat.Text = tongThuongPhat.ToString("N0");
            txtTongThucNhan.Text = tongThucNhan.ToString("N0");
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

            if (dataGridViewLuong.Columns.Contains("Ma_nhan_vien"))
                dataGridViewLuong.Columns["Ma_nhan_vien"].HeaderText = "Mã NV";

            if (dataGridViewLuong.Columns.Contains("Ten_nhan_vien"))
                dataGridViewLuong.Columns["Ten_nhan_vien"].HeaderText = "Tên nhân viên";

            if (dataGridViewLuong.Columns.Contains("Ten_phong_ban"))
                dataGridViewLuong.Columns["Ten_phong_ban"].HeaderText = "Phòng ban";

            if (dataGridViewLuong.Columns.Contains("Ten_chuc_vu"))
                dataGridViewLuong.Columns["Ten_chuc_vu"].HeaderText = "Chức vụ";

            if (dataGridViewLuong.Columns.Contains("So_tai_khoan"))
                dataGridViewLuong.Columns["So_tai_khoan"].HeaderText = "Số tài khoản";

            if (dataGridViewLuong.Columns.Contains("Ten_ngan_hang"))
                dataGridViewLuong.Columns["Ten_ngan_hang"].HeaderText = "Tên ngân hàng";

            if (dataGridViewLuong.Columns.Contains("Thang"))
                dataGridViewLuong.Columns["Thang"].HeaderText = "Tháng";

            if (dataGridViewLuong.Columns.Contains("Nam"))
                dataGridViewLuong.Columns["Nam"].HeaderText = "Năm";

            if (dataGridViewLuong.Columns.Contains("Tong_so_cong"))
                dataGridViewLuong.Columns["Tong_so_cong"].HeaderText = "Tổng công";

            if (dataGridViewLuong.Columns.Contains("Tong_gio_lam"))
            {
                dataGridViewLuong.Columns["Tong_gio_lam"].HeaderText = "Tổng giờ";
                dataGridViewLuong.Columns["Tong_gio_lam"].DefaultCellStyle.Format = "N2";
            }

            if (dataGridViewLuong.Columns.Contains("So_ngay_nghi_phep"))
                dataGridViewLuong.Columns["So_ngay_nghi_phep"].HeaderText = "Ngày nghỉ";

            if (dataGridViewLuong.Columns.Contains("So_ngay_di_muon"))
                dataGridViewLuong.Columns["So_ngay_di_muon"].HeaderText = "Đi muộn";

            if (dataGridViewLuong.Columns.Contains("So_ngay_ve_som"))
                dataGridViewLuong.Columns["So_ngay_ve_som"].HeaderText = "Về sớm";

            if (dataGridViewLuong.Columns.Contains("Luong_co_ban"))
            {
                dataGridViewLuong.Columns["Luong_co_ban"].HeaderText = "Lương cơ bản";
                dataGridViewLuong.Columns["Luong_co_ban"].DefaultCellStyle.Format = "N0";
            }

            if (dataGridViewLuong.Columns.Contains("He_so_luong"))
                dataGridViewLuong.Columns["He_so_luong"].HeaderText = "Hệ số";

            if (dataGridViewLuong.Columns.Contains("Luong_chuc_vu"))
            {
                dataGridViewLuong.Columns["Luong_chuc_vu"].HeaderText = "Lương chức vụ";
                dataGridViewLuong.Columns["Luong_chuc_vu"].DefaultCellStyle.Format = "N0";
            }

            if (dataGridViewLuong.Columns.Contains("Muc_thuong_phat"))
            {
                dataGridViewLuong.Columns["Muc_thuong_phat"].HeaderText = "Thưởng/phạt";
                dataGridViewLuong.Columns["Muc_thuong_phat"].DefaultCellStyle.Format = "N0";
            }

            if (dataGridViewLuong.Columns.Contains("Thuc_nhan"))
            {
                dataGridViewLuong.Columns["Thuc_nhan"].HeaderText = "Thực nhận";
                dataGridViewLuong.Columns["Thuc_nhan"].DefaultCellStyle.Format = "N0";
            }

            if (dataGridViewLuong.Columns.Contains("Ghi_chu"))
                dataGridViewLuong.Columns["Ghi_chu"].HeaderText = "Ghi chú";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (!HasSalaryPermission()) return;

            LoadSalaryData();
            ConfigureDataGridView();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            if (!HasSalaryPermission()) return;

            cmbNhanVien.SelectedIndex = 0;
            SetCurrentMonthYear();

            LoadSalaryData();
            ConfigureDataGridView();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (!HasSalaryPermission()) return;

            int rowCount = 0;

            foreach (DataGridViewRow row in dataGridViewLuong.Rows)
            {
                if (!row.IsNewRow)
                    rowCount++;
            }

            if (rowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu lương để xuất Excel.");
                return;
            }

            string thang = cmbThang.SelectedItem == null ? DateTime.Now.Month.ToString() : cmbThang.SelectedItem.ToString();
            string nam = cmbNam.SelectedItem == null ? DateTime.Now.Year.ToString() : cmbNam.SelectedItem.ToString();

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Xuất bảng lương ra Excel";
                saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = "BangLuong_Thang" + thang + "_Nam" + nam + ".xlsx";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    ExcelExportHelper.ExportDataGridViewToXlsx(
                        dataGridViewLuong,
                        saveFileDialog.FileName,
                        "Bang luong");

                    MessageBox.Show("Xuất Excel thành công:\n" + saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
                }
            }
        }
    }
}
