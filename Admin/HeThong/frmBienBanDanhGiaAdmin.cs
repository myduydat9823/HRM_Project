using QuanLyNhanSu.BLL;
using QuanLyNhanSu.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhanSu.Admin.HeThong
{
    public partial class frmBienBanDanhGiaAdmin : Form
    {
        private readonly BienBanDanhGiaBLL bienBanDanhGiaBLL = new BienBanDanhGiaBLL();
        private bool isLoadingEmployees;

        public frmBienBanDanhGiaAdmin()
        {
            InitializeComponent();

            this.Load += frmBienBanDanhGiaAdmin_Load;
            cmbNhanVien.SelectedIndexChanged += cmbNhanVien_SelectedIndexChanged;
            dgvBienBanDanhGia.CellClick += dgvBienBanDanhGia_CellClick;
            btnTimKiem.Click += btnTimKiem_Click;
            btnTaiLai.Click += btnTaiLai_Click;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
        }

        private void frmBienBanDanhGiaAdmin_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadBienBanDanhGia();
            ClearForm();
        }

        private void LoadEmployees()
        {
            try
            {
                isLoadingEmployees = true;

                DataTable dt = bienBanDanhGiaBLL.GetEmployees();
                cmbNhanVien.DataSource = dt;
                cmbNhanVien.DisplayMember = "Hien_thi_nhan_vien";
                cmbNhanVien.ValueMember = "Ma_nhan_vien";
                cmbNhanVien.DropDownWidth = 320;
                cmbNhanVien.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tai danh sach nhan vien: " + ex.Message);
            }
            finally
            {
                isLoadingEmployees = false;
            }
        }

        private void LoadBienBanDanhGia()
        {
            try
            {
                DataTable dt = bienBanDanhGiaBLL.GetAll();
                dgvBienBanDanhGia.DataSource = dt;
                ConfigureDataGridView();
                dgvBienBanDanhGia.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tai danh sach bien ban: " + ex.Message);
            }
        }

        private void SearchBienBanDanhGia()
        {
            try
            {
                DataTable dt = bienBanDanhGiaBLL.Search(txtTimKiem.Text);
                dgvBienBanDanhGia.DataSource = dt;
                ConfigureDataGridView();
                dgvBienBanDanhGia.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tim kiem bien ban: " + ex.Message);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dgvBienBanDanhGia.Columns.Count == 0)
                return;

            dgvBienBanDanhGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBienBanDanhGia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBienBanDanhGia.MultiSelect = false;
            dgvBienBanDanhGia.ReadOnly = true;
            dgvBienBanDanhGia.AllowUserToAddRows = false;
            dgvBienBanDanhGia.AllowUserToDeleteRows = false;

            if (dgvBienBanDanhGia.Columns.Contains("Ma_bien_ban"))
                dgvBienBanDanhGia.Columns["Ma_bien_ban"].HeaderText = "Ma bien ban";

            if (dgvBienBanDanhGia.Columns.Contains("Ngay_lap"))
            {
                dgvBienBanDanhGia.Columns["Ngay_lap"].HeaderText = "Ngay lap";
                dgvBienBanDanhGia.Columns["Ngay_lap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvBienBanDanhGia.Columns.Contains("Ma_nhan_vien"))
                dgvBienBanDanhGia.Columns["Ma_nhan_vien"].HeaderText = "Ma NV";

            if (dgvBienBanDanhGia.Columns.Contains("Ten_nhan_vien"))
                dgvBienBanDanhGia.Columns["Ten_nhan_vien"].HeaderText = "Ten NV";

            if (dgvBienBanDanhGia.Columns.Contains("Ten_chuc_vu"))
                dgvBienBanDanhGia.Columns["Ten_chuc_vu"].HeaderText = "Chuc vu";

            if (dgvBienBanDanhGia.Columns.Contains("TP_phong_ban"))
                dgvBienBanDanhGia.Columns["TP_phong_ban"].HeaderText = "Phong ban";

            if (dgvBienBanDanhGia.Columns.Contains("Noi_dung_danh_gia"))
            {
                dgvBienBanDanhGia.Columns["Noi_dung_danh_gia"].HeaderText = "Noi dung";
                dgvBienBanDanhGia.Columns["Noi_dung_danh_gia"].FillWeight = 180;
            }
        }

        private void cmbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoadingEmployees || cmbNhanVien.SelectedItem == null)
                return;

            DataRowView row = cmbNhanVien.SelectedItem as DataRowView;
            if (row == null)
                return;

            txtMaNhanVien.Text = GetValue(row, "Ma_nhan_vien");
            txtTenNhanVien.Text = GetValue(row, "Ten_nhan_vien");
            txtTenChucVu.Text = GetValue(row, "Ten_chuc_vu");
            txtTenPhongBan.Text = GetValue(row, "Ten_phong_ban");
        }

        private void dgvBienBanDanhGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvBienBanDanhGia.Rows[e.RowIndex];
            if (row.IsNewRow)
                return;

            if (int.TryParse(GetCellValue(row, "Ma_nhan_vien"), out int maNhanVien))
            {
                try
                {
                    isLoadingEmployees = true;
                    cmbNhanVien.SelectedValue = maNhanVien;
                }
                finally
                {
                    isLoadingEmployees = false;
                }
            }

            txtMaBienBan.Text = GetCellValue(row, "Ma_bien_ban");

            object ngayLapValue = row.Cells["Ngay_lap"].Value;
            if (ngayLapValue != null && ngayLapValue != DBNull.Value)
                dtpNgayLap.Value = Convert.ToDateTime(ngayLapValue);

            txtMaNhanVien.Text = GetCellValue(row, "Ma_nhan_vien");
            txtTenNhanVien.Text = GetCellValue(row, "Ten_nhan_vien");
            txtTenChucVu.Text = GetCellValue(row, "Ten_chuc_vu");
            txtTenPhongBan.Text = GetCellValue(row, "TP_phong_ban");
            txtNoiDungDanhGia.Text = GetCellValue(row, "Noi_dung_danh_gia");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SearchBienBanDanhGia();
            ClearForm();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;
            SearchBienBanDanhGia();
            ClearForm();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadBienBanDanhGia();
            ClearForm();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            OperationResultDto result = bienBanDanhGiaBLL.Create(CreateDto());
            MessageBox.Show(result.Message);

            if (!result.Success)
                return;

            LoadBienBanDanhGia();
            ClearForm();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            OperationResultDto result = bienBanDanhGiaBLL.Update(CreateDto());
            MessageBox.Show(result.Message);

            if (!result.Success)
                return;

            SearchBienBanDanhGia();
            ClearForm();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int? maBienBan = GetSelectedBienBanId();
            if (!maBienBan.HasValue)
            {
                MessageBox.Show("Vui long chon bien ban can xoa.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Ban co chac muon xoa bien ban nay khong?",
                "Xac nhan",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            OperationResultDto result = bienBanDanhGiaBLL.Delete(maBienBan);
            MessageBox.Show(result.Message);

            if (!result.Success)
                return;

            SearchBienBanDanhGia();
            ClearForm();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private BienBanDanhGiaDto CreateDto()
        {
            int.TryParse(txtMaBienBan.Text.Trim(), out int maBienBan);
            int.TryParse(txtMaNhanVien.Text.Trim(), out int maNhanVien);

            return new BienBanDanhGiaDto
            {
                MaBienBan = maBienBan > 0 ? (int?)maBienBan : null,
                NgayLap = dtpNgayLap.Value.Date,
                MaNhanVien = maNhanVien,
                TenNhanVien = txtTenNhanVien.Text.Trim(),
                TenChucVu = txtTenChucVu.Text.Trim(),
                TenPhongBan = txtTenPhongBan.Text.Trim(),
                NoiDungDanhGia = txtNoiDungDanhGia.Text.Trim()
            };
        }

        private int? GetSelectedBienBanId()
        {
            if (!int.TryParse(txtMaBienBan.Text.Trim(), out int maBienBan))
                return null;

            if (maBienBan <= 0)
                return null;

            return maBienBan;
        }

        private void ClearForm()
        {
            try
            {
                txtMaBienBan.Text = bienBanDanhGiaBLL.GetNextBienBanId().ToString();
            }
            catch
            {
                txtMaBienBan.Clear();
            }

            dtpNgayLap.Value = DateTime.Today;
            cmbNhanVien.SelectedIndex = -1;
            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            txtTenChucVu.Clear();
            txtTenPhongBan.Clear();
            txtNoiDungDanhGia.Clear();

            if (dgvBienBanDanhGia.DataSource != null)
                dgvBienBanDanhGia.ClearSelection();
        }

        private string GetValue(DataRowView row, string columnName)
        {
            if (row.Row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                return row[columnName].ToString();

            return "";
        }

        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            if (row.DataGridView.Columns.Contains(columnName) &&
                row.Cells[columnName].Value != null &&
                row.Cells[columnName].Value != DBNull.Value)
            {
                return row.Cells[columnName].Value.ToString();
            }

            return "";
        }
    }
}
