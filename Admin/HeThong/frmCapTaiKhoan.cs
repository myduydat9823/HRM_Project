using QuanLyNhanSu.BLL;
using QuanLyNhanSu.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhanSu.Admin.HeThong
{
    public partial class frmCapTaiKhoan : Form
    {
        private readonly TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();

        public frmCapTaiKhoan()
        {
            InitializeComponent();

            this.Load += frmCapTaiKhoan_Load;
            btnTimKiem.Click += btnTimKiem_Click;
            btnCapTaiKhoan.Click += btnCapTaiKhoan_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            dgvNhanVienChuaCoTaiKhoan.CellClick += dgvNhanVienChuaCoTaiKhoan_CellClick;
        }

        private void frmCapTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadPermissions();
            LoadEmployeesWithoutAccount();
            ClearAccountForm();
        }

        private void LoadEmployeesWithoutAccount(string keyword = "")
        {
            try
            {
                DataTable dt = taiKhoanBLL.GetEmployeesWithoutAccount(keyword);
                dgvNhanVienChuaCoTaiKhoan.DataSource = dt;
                ConfigureEmployeeGrid();
                dgvNhanVienChuaCoTaiKhoan.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tai danh sach nhan vien: " + ex.Message);
            }
        }

        private void LoadPermissions()
        {
            try
            {
                DataTable dt = taiKhoanBLL.GetPermissions();

                cmbQuyen.DataSource = dt;
                cmbQuyen.DisplayMember = "Ten_quyen";
                cmbQuyen.ValueMember = "Ma_quyen";
                cmbQuyen.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tai danh sach quyen: " + ex.Message);
            }
        }

        private void ConfigureEmployeeGrid()
        {
            if (dgvNhanVienChuaCoTaiKhoan.Columns.Count == 0)
                return;

            dgvNhanVienChuaCoTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVienChuaCoTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVienChuaCoTaiKhoan.MultiSelect = false;
            dgvNhanVienChuaCoTaiKhoan.ReadOnly = true;
            dgvNhanVienChuaCoTaiKhoan.AllowUserToAddRows = false;
            dgvNhanVienChuaCoTaiKhoan.AllowUserToDeleteRows = false;

            if (dgvNhanVienChuaCoTaiKhoan.Columns.Contains("Ma_nhan_vien"))
                dgvNhanVienChuaCoTaiKhoan.Columns["Ma_nhan_vien"].HeaderText = "Ma NV";

            if (dgvNhanVienChuaCoTaiKhoan.Columns.Contains("Ten_nhan_vien"))
                dgvNhanVienChuaCoTaiKhoan.Columns["Ten_nhan_vien"].HeaderText = "Ten nhan vien";

            if (dgvNhanVienChuaCoTaiKhoan.Columns.Contains("SDT"))
                dgvNhanVienChuaCoTaiKhoan.Columns["SDT"].HeaderText = "SDT";

            if (dgvNhanVienChuaCoTaiKhoan.Columns.Contains("Email"))
                dgvNhanVienChuaCoTaiKhoan.Columns["Email"].HeaderText = "Email";

            if (dgvNhanVienChuaCoTaiKhoan.Columns.Contains("Ten_phong_ban"))
                dgvNhanVienChuaCoTaiKhoan.Columns["Ten_phong_ban"].HeaderText = "Phong ban";

            if (dgvNhanVienChuaCoTaiKhoan.Columns.Contains("Ten_chuc_vu"))
                dgvNhanVienChuaCoTaiKhoan.Columns["Ten_chuc_vu"].HeaderText = "Chuc vu";
        }

        private void dgvNhanVienChuaCoTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvNhanVienChuaCoTaiKhoan.Rows[e.RowIndex];
            if (row.IsNewRow)
                return;

            txtMaNhanVien.Text = row.Cells["Ma_nhan_vien"].Value == null
                ? ""
                : row.Cells["Ma_nhan_vien"].Value.ToString();

            txtTenNhanVien.Text = row.Cells["Ten_nhan_vien"].Value == null
                ? ""
                : row.Cells["Ten_nhan_vien"].Value.ToString();

            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text) && !string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
            {
                txtTaiKhoan.Text = "nv" + txtMaNhanVien.Text.Trim();
            }

            txtTaiKhoan.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadEmployeesWithoutAccount(txtTimKiem.Text);
            ClearAccountForm();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;
            LoadEmployeesWithoutAccount(txtTimKiem.Text);
            ClearAccountForm();
        }

        private void btnCapTaiKhoan_Click(object sender, EventArgs e)
        {
            int? maNhanVien = GetSelectedEmployeeId();
            int? maQuyen = GetSelectedPermissionId();

            OperationResultDto result = taiKhoanBLL.CreateAccount(
                maNhanVien,
                txtTaiKhoan.Text,
                txtMatKhau.Text,
                txtNhapLaiMatKhau.Text,
                maQuyen);

            MessageBox.Show(result.Message);

            if (!result.Success)
                return;

            LoadEmployeesWithoutAccount(txtTimKiem.Text);
            ClearAccountForm();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadEmployeesWithoutAccount();
            ClearAccountForm();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            char passwordChar = chkHienMatKhau.Checked ? '\0' : '*';
            txtMatKhau.PasswordChar = passwordChar;
            txtNhapLaiMatKhau.PasswordChar = passwordChar;
        }

        private int? GetSelectedEmployeeId()
        {
            if (!int.TryParse(txtMaNhanVien.Text.Trim(), out int maNhanVien))
                return null;

            return maNhanVien;
        }

        private int? GetSelectedPermissionId()
        {
            if (cmbQuyen.SelectedValue == null)
                return null;

            if (!int.TryParse(cmbQuyen.SelectedValue.ToString(), out int maQuyen))
                return null;

            return maQuyen;
        }

        private void ClearAccountForm()
        {
            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtNhapLaiMatKhau.Clear();
            chkHienMatKhau.Checked = false;
            cmbQuyen.SelectedIndex = -1;

            if (dgvNhanVienChuaCoTaiKhoan.DataSource != null)
                dgvNhanVienChuaCoTaiKhoan.ClearSelection();
        }
    }
}
