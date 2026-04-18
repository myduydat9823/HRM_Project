using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace QuanLyNhanSu.KeToan.ChiTietChamCong
{
    public partial class frmXemChamCongKeToan : Form
    {
        private readonly string connectString =
            @"Data Source=ADMIN\PHANTAN1;Initial Catalog=QUAN_LY_NHAN_VIEN_CMC;Integrated Security=True;TrustServerCertificate=True";

        public frmXemChamCongKeToan()
        {
            InitializeComponent();

            this.Load += frmXemChamCongKeToan_Load;
            btnLoc.Click += btnLoc_Click;
            btnTaiLai.Click += btnTaiLai_Click;
        }

        private void frmXemChamCongKeToan_Load(object sender, EventArgs e)
        {
            if (session.MaQuyen != 1 && session.MaQuyen != 3)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng xem chấm công.");
                this.Close();
                return;
            }

            LoadEmployeeCombobox();
            LoadMonthCombobox();
            LoadYearCombobox();
            SetCurrentMonthYear();

            LoadAttendanceData();
            ConfigureDataGridView();
        }

        private void LoadEmployeeCombobox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            Ma_nhan_vien, 
                            CAST(Ma_nhan_vien AS NVARCHAR(20)) + N' - ' + Ten_nhan_vien AS Hien_thi
                        FROM NHAN_VIEN
                        WHERE Tinh_trang = N'Đang làm'
                        ORDER BY Ten_nhan_vien";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataRow rowAll = dt.NewRow();
                    rowAll["Ma_nhan_vien"] = DBNull.Value;
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
                            cc.Ma_cham_cong,
                            cc.Ma_nhan_vien,
                            ISNULL(nv.Ten_nhan_vien, cc.Ten_nhan_vien) AS Ten_nhan_vien,
                            ISNULL(nv.Ten_phong_ban, N'') AS Ten_phong_ban,
                            ISNULL(nv.Ten_chuc_vu, N'') AS Ten_chuc_vu,
                            cc.Ngay_cham_cong,

                            CONVERT(VARCHAR(8), cc.Gio_vao, 108) AS Gio_vao,
                            CONVERT(VARCHAR(8), cc.Gio_ra, 108) AS Gio_ra,

                            ISNULL(cc.So_gio_lam_viec, 0) AS So_gio_lam_viec,

                            CASE
                                WHEN cc.Gio_vao IS NOT NULL 
                                     AND cc.Gio_vao > CAST('08:00:00' AS TIME)
                                THEN N'Có'
                                ELSE N'Không'
                            END AS Di_muon,

                            CASE
                                WHEN cc.Gio_ra IS NOT NULL 
                                     AND cc.Gio_ra < CAST('17:00:00' AS TIME)
                                THEN N'Có'
                                ELSE N'Không'
                            END AS Ve_som,

                            CASE
                                WHEN EXISTS
                                (
                                    SELECT 1
                                    FROM NGHI_PHEP_THOI_VIEC np
                                    WHERE np.Ma_nhan_vien = cc.Ma_nhan_vien
                                      AND np.Loai_don = N'Nghỉ phép'
                                      AND np.Tinh_trang = N'Đã duyệt'
                                      AND cc.Ngay_cham_cong BETWEEN np.Ngay_bat_dau AND np.Ngay_ket_thuc
                                )
                                THEN N'Có'
                                ELSE N'Không'
                            END AS Nghi_phep,

                            CASE
                                WHEN EXISTS
                                (
                                    SELECT 1
                                    FROM NGHI_PHEP_THOI_VIEC np
                                    WHERE np.Ma_nhan_vien = cc.Ma_nhan_vien
                                      AND np.Loai_don = N'Nghỉ phép'
                                      AND np.Tinh_trang = N'Đã duyệt'
                                      AND cc.Ngay_cham_cong BETWEEN np.Ngay_bat_dau AND np.Ngay_ket_thuc
                                )
                                THEN N'Nghỉ phép'

                                WHEN cc.Gio_vao IS NULL
                                THEN N'Chưa check-in'

                                WHEN cc.Gio_ra IS NULL
                                THEN N'Chưa check-out'

                                ELSE N'Đã chấm công'
                            END AS Trang_thai
                        FROM CHAM_CONG cc
                        LEFT JOIN NHAN_VIEN nv ON cc.Ma_nhan_vien = nv.Ma_nhan_vien
                        WHERE MONTH(cc.Ngay_cham_cong) = @Thang
                          AND YEAR(cc.Ngay_cham_cong) = @Nam";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@Thang", Convert.ToInt32(cmbThang.SelectedItem));
                    cmd.Parameters.AddWithValue("@Nam", Convert.ToInt32(cmbNam.SelectedItem));

                    if (cmbNhanVien.SelectedIndex > 0 && cmbNhanVien.SelectedValue != null)
                    {
                        query += " AND cc.Ma_nhan_vien = @Ma_nhan_vien";
                        cmd.Parameters.AddWithValue("@Ma_nhan_vien", Convert.ToInt32(cmbNhanVien.SelectedValue));
                    }

                    query += @"
                        ORDER BY 
                            ISNULL(nv.Ten_nhan_vien, cc.Ten_nhan_vien),
                            cc.Ngay_cham_cong";

                    cmd.CommandText = query;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewChamCong.DataSource = dt;

                    CalculateSummary(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu chấm công: " + ex.Message);
            }
        }

        private void CalculateSummary(DataTable dt)
        {
            int tongNgay = 0;
            int soNgayDiMuon = 0;
            int soNgayVeSom = 0;
            int soNgayNghiPhep = 0;
            decimal tongGio = 0;

            foreach (DataRow row in dt.Rows)
            {
                tongNgay++;

                if (row["So_gio_lam_viec"] != DBNull.Value)
                    tongGio += Convert.ToDecimal(row["So_gio_lam_viec"]);

                if (row["Di_muon"].ToString() == "Có")
                    soNgayDiMuon++;

                if (row["Ve_som"].ToString() == "Có")
                    soNgayVeSom++;

                if (row["Nghi_phep"].ToString() == "Có")
                    soNgayNghiPhep++;
            }

            txtTongNgay.Text = tongNgay.ToString();
            txtTongGio.Text = tongGio.ToString("0.##");
            txtDiMuon.Text = soNgayDiMuon.ToString();
            txtVeSom.Text = soNgayVeSom.ToString();
            txtNghiPhep.Text = soNgayNghiPhep.ToString();
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
                dataGridViewChamCong.Columns["Ma_cham_cong"].HeaderText = "Mã CC";

            if (dataGridViewChamCong.Columns.Contains("Ma_nhan_vien"))
                dataGridViewChamCong.Columns["Ma_nhan_vien"].HeaderText = "Mã NV";

            if (dataGridViewChamCong.Columns.Contains("Ten_nhan_vien"))
                dataGridViewChamCong.Columns["Ten_nhan_vien"].HeaderText = "Tên nhân viên";

            if (dataGridViewChamCong.Columns.Contains("Ten_phong_ban"))
                dataGridViewChamCong.Columns["Ten_phong_ban"].HeaderText = "Phòng ban";

            if (dataGridViewChamCong.Columns.Contains("Ten_chuc_vu"))
                dataGridViewChamCong.Columns["Ten_chuc_vu"].HeaderText = "Chức vụ";

            if (dataGridViewChamCong.Columns.Contains("Ngay_cham_cong"))
                dataGridViewChamCong.Columns["Ngay_cham_cong"].HeaderText = "Ngày chấm công";

            if (dataGridViewChamCong.Columns.Contains("Gio_vao"))
                dataGridViewChamCong.Columns["Gio_vao"].HeaderText = "Giờ vào";

            if (dataGridViewChamCong.Columns.Contains("Gio_ra"))
                dataGridViewChamCong.Columns["Gio_ra"].HeaderText = "Giờ ra";

            if (dataGridViewChamCong.Columns.Contains("So_gio_lam_viec"))
                dataGridViewChamCong.Columns["So_gio_lam_viec"].HeaderText = "Số giờ làm";

            if (dataGridViewChamCong.Columns.Contains("Di_muon"))
                dataGridViewChamCong.Columns["Di_muon"].HeaderText = "Đi muộn";

            if (dataGridViewChamCong.Columns.Contains("Ve_som"))
                dataGridViewChamCong.Columns["Ve_som"].HeaderText = "Về sớm";

            if (dataGridViewChamCong.Columns.Contains("Nghi_phep"))
                dataGridViewChamCong.Columns["Nghi_phep"].HeaderText = "Nghỉ phép";

            if (dataGridViewChamCong.Columns.Contains("Trang_thai"))
                dataGridViewChamCong.Columns["Trang_thai"].HeaderText = "Trạng thái";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadAttendanceData();
            ConfigureDataGridView();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            cmbNhanVien.SelectedIndex = 0;
            SetCurrentMonthYear();

            LoadAttendanceData();
            ConfigureDataGridView();
        }
    }
}