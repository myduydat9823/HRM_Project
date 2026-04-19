using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhanSu.Common;

namespace QuanLyNhanSu.KeToan.ThuongPhat
{
    public partial class frmThuongPhatKeToan : Form
    {
        private const string TrangThaiChoDuyet = "Chờ duyệt";
        private const string TrangThaiDaDuyet = "Đã duyệt";

        private readonly string connectString =
            @"Data Source=ADMIN\PHANTAN1;Initial Catalog=QUAN_LY_NHAN_VIEN_CMC;Integrated Security=True;TrustServerCertificate=True";

        private bool isProcessing = false;
        private KetoanRoleInfo currentRole;

        public frmThuongPhatKeToan()
        {
            InitializeComponent();

            this.Load += frmThuongPhatKeToan_Load;
            cmbNhanVien.SelectedIndexChanged += cmbNhanVien_SelectedIndexChanged;
            dataGridViewThuongPhat.CellClick += dataGridViewThuongPhat_CellClick;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnLoc.Click += btnLoc_Click;
            btnTaiLai.Click += btnTaiLai_Click;
        }

        private void frmThuongPhatKeToan_Load(object sender, EventArgs e)
        {
            if (session.MaQuyen != 1 && session.MaQuyen != 3)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng thưởng/phạt.");
                this.Close();
                return;
            }

            try
            {
                currentRole = KetoanPermissionHelper.GetCurrentRole();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra quyền kế toán: " + ex.Message);
                this.Close();
                return;
            }

            if (!currentRole.CanCreateRewardPenalty)
            {
                MessageBox.Show("Chỉ trưởng phòng kế toán hoặc kế toán viên mới được dùng chức năng thưởng/phạt.");
                this.Close();
                return;
            }

            if (currentRole.CanApproveRewardPenalty)
            {
                lblTitle.Text = "QUẢN LÝ KHEN THƯỞNG / KỶ LUẬT";
                btnThem.Text = "Thêm";
            }
            else
            {
                lblTitle.Text = "GỬI YÊU CẦU KHEN THƯỞNG / KỶ LUẬT";
                btnThem.Text = "Gửi duyệt";
            }

            LoadEmployeeCombobox();
            LoadLoaiQuyetDinh();
            LoadMonthCombobox();
            LoadYearCombobox();
            SetCurrentMonthYear();

            LoadRewardPenaltyData();
            ConfigureDataGridView();
            ClearForm();
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
                    rowAll["Hien_thi"] = "-- Chọn / Tất cả nhân viên --";
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

        private void LoadLoaiQuyetDinh()
        {
            cmbLoaiQuyetDinh.Items.Clear();
            cmbLoaiQuyetDinh.Items.Add("Khen thưởng");
            cmbLoaiQuyetDinh.Items.Add("Kỷ luật");
            cmbLoaiQuyetDinh.SelectedIndex = -1;
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

        private void cmbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNhanVien.SelectedIndex <= 0 || cmbNhanVien.SelectedValue == null)
            {
                txtChucVu.Clear();
                txtPhongBan.Clear();
                return;
            }

            LoadEmployeeExtraInfo(Convert.ToInt32(cmbNhanVien.SelectedValue));
        }

        private void LoadEmployeeExtraInfo(int maNhanVien)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            ISNULL(Ten_chuc_vu, N'') AS Ten_chuc_vu,
                            ISNULL(Ten_phong_ban, N'') AS Ten_phong_ban
                        FROM NHAN_VIEN
                        WHERE Ma_nhan_vien = @Ma_nhan_vien";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma_nhan_vien", maNhanVien);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtChucVu.Text = reader["Ten_chuc_vu"].ToString();
                                txtPhongBan.Text = reader["Ten_phong_ban"].ToString();
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

        private void LoadRewardPenaltyData()
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
                            Ma_quyet_dinh,
                            Ngay_lap,
                            Loai_quyet_dinh,
                            Ma_nhan_vien,
                            Ten_nhan_vien,
                            Ten_chuc_vu,
                            Ten_phong_ban,
                            Muc_thuong_phat,
                            Ly_do,
                            ISNULL(Trang_thai, N'Đã duyệt') AS Trang_thai,
                            Nguoi_tao,
                            Nguoi_duyet,
                            Ngay_duyet,
                            Ly_do_duyet
                        FROM KHEN_THUONG_KY_LUAT
                        WHERE MONTH(Ngay_lap) = @Thang
                          AND YEAR(Ngay_lap) = @Nam";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@Thang", Convert.ToInt32(cmbThang.SelectedItem));
                    cmd.Parameters.AddWithValue("@Nam", Convert.ToInt32(cmbNam.SelectedItem));

                    if (cmbNhanVien.SelectedIndex > 0 && cmbNhanVien.SelectedValue != null)
                    {
                        query += " AND Ma_nhan_vien = @Ma_nhan_vien";
                        cmd.Parameters.AddWithValue("@Ma_nhan_vien", Convert.ToInt32(cmbNhanVien.SelectedValue));
                    }

                    query += " ORDER BY Ngay_lap DESC, Ma_quyet_dinh DESC";
                    cmd.CommandText = query;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewThuongPhat.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu thưởng/phạt: " + ex.Message);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dataGridViewThuongPhat.Columns.Count == 0) return;

            dataGridViewThuongPhat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewThuongPhat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewThuongPhat.MultiSelect = false;
            dataGridViewThuongPhat.ReadOnly = true;
            dataGridViewThuongPhat.AllowUserToAddRows = false;
            dataGridViewThuongPhat.AllowUserToDeleteRows = false;

            if (dataGridViewThuongPhat.Columns.Contains("Ma_quyet_dinh"))
                dataGridViewThuongPhat.Columns["Ma_quyet_dinh"].HeaderText = "Mã QĐ";

            if (dataGridViewThuongPhat.Columns.Contains("Ngay_lap"))
                dataGridViewThuongPhat.Columns["Ngay_lap"].HeaderText = "Ngày lập";

            if (dataGridViewThuongPhat.Columns.Contains("Loai_quyet_dinh"))
                dataGridViewThuongPhat.Columns["Loai_quyet_dinh"].HeaderText = "Loại";

            if (dataGridViewThuongPhat.Columns.Contains("Ma_nhan_vien"))
                dataGridViewThuongPhat.Columns["Ma_nhan_vien"].HeaderText = "Mã NV";

            if (dataGridViewThuongPhat.Columns.Contains("Ten_nhan_vien"))
                dataGridViewThuongPhat.Columns["Ten_nhan_vien"].HeaderText = "Tên nhân viên";

            if (dataGridViewThuongPhat.Columns.Contains("Ten_chuc_vu"))
                dataGridViewThuongPhat.Columns["Ten_chuc_vu"].HeaderText = "Chức vụ";

            if (dataGridViewThuongPhat.Columns.Contains("Ten_phong_ban"))
                dataGridViewThuongPhat.Columns["Ten_phong_ban"].HeaderText = "Phòng ban";

            if (dataGridViewThuongPhat.Columns.Contains("Muc_thuong_phat"))
            {
                dataGridViewThuongPhat.Columns["Muc_thuong_phat"].HeaderText = "Mức thưởng/phạt";
                dataGridViewThuongPhat.Columns["Muc_thuong_phat"].DefaultCellStyle.Format = "N0";
            }

            if (dataGridViewThuongPhat.Columns.Contains("Ly_do"))
                dataGridViewThuongPhat.Columns["Ly_do"].HeaderText = "Lý do";

            if (dataGridViewThuongPhat.Columns.Contains("Trang_thai"))
                dataGridViewThuongPhat.Columns["Trang_thai"].HeaderText = "Trạng thái";

            if (dataGridViewThuongPhat.Columns.Contains("Ngay_duyet"))
                dataGridViewThuongPhat.Columns["Ngay_duyet"].HeaderText = "Ngày duyệt";

            if (dataGridViewThuongPhat.Columns.Contains("Nguoi_tao"))
                dataGridViewThuongPhat.Columns["Nguoi_tao"].Visible = false;

            if (dataGridViewThuongPhat.Columns.Contains("Nguoi_duyet"))
                dataGridViewThuongPhat.Columns["Nguoi_duyet"].Visible = false;

            if (dataGridViewThuongPhat.Columns.Contains("Ly_do_duyet"))
                dataGridViewThuongPhat.Columns["Ly_do_duyet"].Visible = false;
        }

        private void dataGridViewThuongPhat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewThuongPhat.Rows[e.RowIndex];

            txtMaQuyetDinh.Text = row.Cells["Ma_quyet_dinh"].Value?.ToString() ?? "";

            if (DateTime.TryParse(row.Cells["Ngay_lap"].Value?.ToString(), out DateTime ngayLap))
                dtpNgayLap.Value = ngayLap;

            cmbLoaiQuyetDinh.Text = row.Cells["Loai_quyet_dinh"].Value?.ToString() ?? "";

            if (row.Cells["Ma_nhan_vien"].Value != DBNull.Value)
                cmbNhanVien.SelectedValue = Convert.ToInt32(row.Cells["Ma_nhan_vien"].Value);

            txtChucVu.Text = row.Cells["Ten_chuc_vu"].Value?.ToString() ?? "";
            txtPhongBan.Text = row.Cells["Ten_phong_ban"].Value?.ToString() ?? "";

            decimal mucTien = 0;
            decimal.TryParse(row.Cells["Muc_thuong_phat"].Value?.ToString(), out mucTien);
            txtMucThuongPhat.Text = Math.Abs(mucTien).ToString("0");

            txtLyDo.Text = row.Cells["Ly_do"].Value?.ToString() ?? "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;

            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                if (!ValidateInput()) return;

                conn = new SqlConnection(connectString);
                conn.Open();
                tran = conn.BeginTransaction(IsolationLevel.Serializable);

                int maQuyetDinh = GetNextDecisionId(conn, tran);
                decimal mucThuongPhat = GetNormalizedAmount();
                bool duyetNgay = currentRole != null && currentRole.CanApproveRewardPenalty;
                string trangThai = duyetNgay ? TrangThaiDaDuyet : TrangThaiChoDuyet;

                string query = @"
                    INSERT INTO KHEN_THUONG_KY_LUAT
                    (
                        Ma_quyet_dinh,
                        Ngay_lap,
                        Loai_quyet_dinh,
                        Ma_nhan_vien,
                        Ten_nhan_vien,
                        Ten_chuc_vu,
                        Ten_phong_ban,
                        Muc_thuong_phat,
                        Ly_do,
                        Trang_thai,
                        Nguoi_tao,
                        Nguoi_duyet,
                        Ngay_duyet,
                        Ly_do_duyet
                    )
                    VALUES
                    (
                        @Ma_quyet_dinh,
                        @Ngay_lap,
                        @Loai_quyet_dinh,
                        @Ma_nhan_vien,
                        @Ten_nhan_vien,
                        @Ten_chuc_vu,
                        @Ten_phong_ban,
                        @Muc_thuong_phat,
                        @Ly_do,
                        @Trang_thai,
                        @Nguoi_tao,
                        @Nguoi_duyet,
                        @Ngay_duyet,
                        @Ly_do_duyet
                    )";

                using (SqlCommand cmd = new SqlCommand(query, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@Ma_quyet_dinh", maQuyetDinh);
                    cmd.Parameters.AddWithValue("@Ngay_lap", dtpNgayLap.Value.Date);
                    cmd.Parameters.AddWithValue("@Loai_quyet_dinh", cmbLoaiQuyetDinh.Text);
                    cmd.Parameters.AddWithValue("@Ma_nhan_vien", Convert.ToInt32(cmbNhanVien.SelectedValue));
                    cmd.Parameters.AddWithValue("@Ten_nhan_vien", cmbNhanVien.Text.Split('-').Length > 1 ? cmbNhanVien.Text.Split('-')[1].Trim() : cmbNhanVien.Text);
                    cmd.Parameters.AddWithValue("@Ten_chuc_vu", txtChucVu.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ten_phong_ban", txtPhongBan.Text.Trim());
                    cmd.Parameters.AddWithValue("@Muc_thuong_phat", mucThuongPhat);
                    cmd.Parameters.AddWithValue("@Ly_do", txtLyDo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Trang_thai", trangThai);
                    cmd.Parameters.AddWithValue("@Nguoi_tao", GetSessionEmployeeValue());
                    cmd.Parameters.AddWithValue("@Nguoi_duyet", duyetNgay ? GetSessionEmployeeValue() : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ngay_duyet", duyetNgay ? (object)DateTime.Now : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ly_do_duyet", DBNull.Value);

                    cmd.ExecuteNonQuery();
                }

                tran.Commit();

                if (duyetNgay)
                    MessageBox.Show("Thêm thưởng/phạt thành công. Quyết định đã được duyệt.");
                else
                    MessageBox.Show("Đã gửi yêu cầu thưởng/phạt. Trưởng phòng kế toán cần duyệt trước khi khoản này được tính vào lương.");

                LoadRewardPenaltyData();
                ConfigureDataGridView();
                ClearForm();
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    try { tran.Rollback(); } catch { }
                }

                MessageBox.Show("Lỗi thêm thưởng/phạt: " + ex.Message);
            }
            finally
            {
                if (tran != null) tran.Dispose();
                if (conn != null) conn.Dispose();

                isProcessing = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;

            try
            {
                if (string.IsNullOrWhiteSpace(txtMaQuyetDinh.Text))
                {
                    MessageBox.Show("Vui lòng chọn quyết định cần sửa.");
                    return;
                }

                if (!ValidateInput()) return;
                if (!CanModifySelectedDecision()) return;

                decimal mucThuongPhat = GetNormalizedAmount();
                bool duyetNgay = currentRole != null && currentRole.CanApproveRewardPenalty;
                string trangThai = duyetNgay ? TrangThaiDaDuyet : TrangThaiChoDuyet;

                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE KHEN_THUONG_KY_LUAT
                        SET
                            Ngay_lap = @Ngay_lap,
                            Loai_quyet_dinh = @Loai_quyet_dinh,
                            Ma_nhan_vien = @Ma_nhan_vien,
                            Ten_nhan_vien = @Ten_nhan_vien,
                            Ten_chuc_vu = @Ten_chuc_vu,
                            Ten_phong_ban = @Ten_phong_ban,
                            Muc_thuong_phat = @Muc_thuong_phat,
                            Ly_do = @Ly_do,
                            Trang_thai = @Trang_thai,
                            Nguoi_tao = ISNULL(Nguoi_tao, @Nguoi_tao),
                            Nguoi_duyet = @Nguoi_duyet,
                            Ngay_duyet = @Ngay_duyet,
                            Ly_do_duyet = @Ly_do_duyet
                        WHERE Ma_quyet_dinh = @Ma_quyet_dinh";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma_quyet_dinh", int.Parse(txtMaQuyetDinh.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Ngay_lap", dtpNgayLap.Value.Date);
                        cmd.Parameters.AddWithValue("@Loai_quyet_dinh", cmbLoaiQuyetDinh.Text);
                        cmd.Parameters.AddWithValue("@Ma_nhan_vien", Convert.ToInt32(cmbNhanVien.SelectedValue));
                        cmd.Parameters.AddWithValue("@Ten_nhan_vien", cmbNhanVien.Text.Split('-').Length > 1 ? cmbNhanVien.Text.Split('-')[1].Trim() : cmbNhanVien.Text);
                        cmd.Parameters.AddWithValue("@Ten_chuc_vu", txtChucVu.Text.Trim());
                        cmd.Parameters.AddWithValue("@Ten_phong_ban", txtPhongBan.Text.Trim());
                        cmd.Parameters.AddWithValue("@Muc_thuong_phat", mucThuongPhat);
                        cmd.Parameters.AddWithValue("@Ly_do", txtLyDo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Trang_thai", trangThai);
                        cmd.Parameters.AddWithValue("@Nguoi_tao", GetSessionEmployeeValue());
                        cmd.Parameters.AddWithValue("@Nguoi_duyet", duyetNgay ? GetSessionEmployeeValue() : DBNull.Value);
                        cmd.Parameters.AddWithValue("@Ngay_duyet", duyetNgay ? (object)DateTime.Now : DBNull.Value);
                        cmd.Parameters.AddWithValue("@Ly_do_duyet", DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                if (duyetNgay)
                    MessageBox.Show("Sửa thưởng/phạt thành công. Quyết định đang ở trạng thái đã duyệt.");
                else
                    MessageBox.Show("Sửa yêu cầu thưởng/phạt thành công. Yêu cầu vẫn đang chờ duyệt.");

                LoadRewardPenaltyData();
                ConfigureDataGridView();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa thưởng/phạt: " + ex.Message);
            }
            finally
            {
                isProcessing = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;

            try
            {
                if (string.IsNullOrWhiteSpace(txtMaQuyetDinh.Text))
                {
                    MessageBox.Show("Vui lòng chọn quyết định cần xóa.");
                    return;
                }

                if (!CanModifySelectedDecision()) return;

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn xóa quyết định này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No) return;

                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();

                    string query = "DELETE FROM KHEN_THUONG_KY_LUAT WHERE Ma_quyet_dinh = @Ma_quyet_dinh";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma_quyet_dinh", int.Parse(txtMaQuyetDinh.Text.Trim()));
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Xóa quyết định thành công.");
                LoadRewardPenaltyData();
                ConfigureDataGridView();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa thưởng/phạt: " + ex.Message);
            }
            finally
            {
                isProcessing = false;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadRewardPenaltyData();
            ConfigureDataGridView();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            SetCurrentMonthYear();
            cmbNhanVien.SelectedIndex = 0;
            LoadRewardPenaltyData();
            ConfigureDataGridView();
            ClearForm();
        }

        private object GetSessionEmployeeValue()
        {
            if (session.MaNhanVien <= 0)
                return DBNull.Value;

            return session.MaNhanVien;
        }

        private bool CanModifySelectedDecision()
        {
            if (currentRole != null && currentRole.CanApproveRewardPenalty)
                return true;

            string trangThai = GetSelectedDecisionStatus();

            if (trangThai == TrangThaiChoDuyet)
                return true;

            MessageBox.Show("Kế toán viên chỉ được sửa hoặc xóa yêu cầu đang chờ duyệt.");
            return false;
        }

        private string GetSelectedDecisionStatus()
        {
            if (dataGridViewThuongPhat.CurrentRow == null
                || !dataGridViewThuongPhat.Columns.Contains("Trang_thai"))
            {
                return TrangThaiDaDuyet;
            }

            object value = dataGridViewThuongPhat.CurrentRow.Cells["Trang_thai"].Value;

            if (value == null || value == DBNull.Value)
                return TrangThaiDaDuyet;

            return value.ToString();
        }

        private bool ValidateInput()
        {
            if (cmbNhanVien.SelectedIndex <= 0 || cmbNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên.");
                cmbNhanVien.Focus();
                return false;
            }

            if (cmbLoaiQuyetDinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại quyết định.");
                cmbLoaiQuyetDinh.Focus();
                return false;
            }

            if (!decimal.TryParse(txtMucThuongPhat.Text.Trim(), out decimal mucTien))
            {
                MessageBox.Show("Mức thưởng/phạt không hợp lệ.");
                txtMucThuongPhat.Focus();
                return false;
            }

            if (mucTien <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền lớn hơn 0. Hệ thống sẽ tự đổi thành âm nếu là kỷ luật.");
                txtMucThuongPhat.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLyDo.Text))
            {
                MessageBox.Show("Vui lòng nhập lý do.");
                txtLyDo.Focus();
                return false;
            }

            if (txtLyDo.Text.Trim().Length > 255)
            {
                MessageBox.Show("Lý do không được vượt quá 255 ký tự.");
                txtLyDo.Focus();
                return false;
            }

            return true;
        }

        private decimal GetNormalizedAmount()
        {
            decimal mucTien = Math.Abs(decimal.Parse(txtMucThuongPhat.Text.Trim()));

            if (cmbLoaiQuyetDinh.Text == "Kỷ luật")
                mucTien = -mucTien;

            return mucTien;
        }

        private int GetNextDecisionId(SqlConnection conn, SqlTransaction tran)
        {
            string query = @"
                SELECT ISNULL(MAX(Ma_quyet_dinh), 0) + 1
                FROM KHEN_THUONG_KY_LUAT WITH (UPDLOCK, HOLDLOCK)";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void ClearForm()
        {
            txtMaQuyetDinh.Clear();
            dtpNgayLap.Value = DateTime.Today;
            cmbLoaiQuyetDinh.SelectedIndex = -1;
            txtMucThuongPhat.Clear();
            txtLyDo.Clear();
            txtChucVu.Clear();
            txtPhongBan.Clear();

            if (cmbNhanVien.Items.Count > 0)
                cmbNhanVien.SelectedIndex = 0;
        }

        private void dataGridViewThuongPhat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbNhanVien_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
