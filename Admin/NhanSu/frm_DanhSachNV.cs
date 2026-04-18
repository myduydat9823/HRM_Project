using System;
using System.Data;
using QuanLyNhanSu.BLL;
using QuanLyNhanSu.DTO;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class frm_DanhSachNV : Form
    {
        private readonly NhanVienBLL nhanVienBLL = new NhanVienBLL();
        private readonly DanhMucBLL danhMucBLL = new DanhMucBLL();

        private string selectedImagePath = "";

        public frm_DanhSachNV()
        {
            InitializeComponent();
        }

        private void frm_DanhSachNV_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadPositions();
            LoadStaticCombobox();
            LoadFilterCombobox();
            LoadEmployeeData();
            ConfigureDataGridView();
        }

        // ================= LOAD DANH SACH =================
        private void LoadEmployeeData()
        {
            try
            {
                dataGridViewEmployees.DataSource = nhanVienBLL.GetAllEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dataGridViewEmployees.Columns.Count == 0) return;

            dataGridViewEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEmployees.MultiSelect = false;
            dataGridViewEmployees.ReadOnly = true;

            if (dataGridViewEmployees.Columns.Contains("Ma_nhan_vien"))
                dataGridViewEmployees.Columns["Ma_nhan_vien"].HeaderText = "Mã NV";
            if (dataGridViewEmployees.Columns.Contains("Ten_nhan_vien"))
                dataGridViewEmployees.Columns["Ten_nhan_vien"].HeaderText = "Tên nhân viên";
            if (dataGridViewEmployees.Columns.Contains("Ngay_sinh"))
                dataGridViewEmployees.Columns["Ngay_sinh"].HeaderText = "Ngày sinh";
            if (dataGridViewEmployees.Columns.Contains("Gioi_tinh"))
                dataGridViewEmployees.Columns["Gioi_tinh"].HeaderText = "Giới tính";
            if (dataGridViewEmployees.Columns.Contains("CCCD"))
                dataGridViewEmployees.Columns["CCCD"].HeaderText = "CCCD";
            if (dataGridViewEmployees.Columns.Contains("Dia_chi"))
                dataGridViewEmployees.Columns["Dia_chi"].HeaderText = "Địa chỉ";
            if (dataGridViewEmployees.Columns.Contains("SDT"))
                dataGridViewEmployees.Columns["SDT"].HeaderText = "SĐT";
            if (dataGridViewEmployees.Columns.Contains("Email"))
                dataGridViewEmployees.Columns["Email"].HeaderText = "Email";
            if (dataGridViewEmployees.Columns.Contains("Ngay_vao_lam"))
                dataGridViewEmployees.Columns["Ngay_vao_lam"].HeaderText = "Ngày vào làm";
            if (dataGridViewEmployees.Columns.Contains("Ten_chuc_vu"))
                dataGridViewEmployees.Columns["Ten_chuc_vu"].HeaderText = "Chức vụ";
            if (dataGridViewEmployees.Columns.Contains("Ten_phong_ban"))
                dataGridViewEmployees.Columns["Ten_phong_ban"].HeaderText = "Phòng ban";
            if (dataGridViewEmployees.Columns.Contains("Luong_co_ban"))
                dataGridViewEmployees.Columns["Luong_co_ban"].HeaderText = "Lương cơ bản";
            if (dataGridViewEmployees.Columns.Contains("Tinh_trang"))
                dataGridViewEmployees.Columns["Tinh_trang"].HeaderText = "Tình trạng";

            if (dataGridViewEmployees.Columns.Contains("Ma_chuc_vu"))
                dataGridViewEmployees.Columns["Ma_chuc_vu"].Visible = false;
            if (dataGridViewEmployees.Columns.Contains("Ma_phong_ban"))
                dataGridViewEmployees.Columns["Ma_phong_ban"].Visible = false;
            if (dataGridViewEmployees.Columns.Contains("Anh_nv"))
                dataGridViewEmployees.Columns["Anh_nv"].Visible = false;
        }

        // ================= LOAD COMBOBOX =================
        private void LoadDepartments()
        {
            try
            {
                DataTable dt = danhMucBLL.GetDepartments();
                DataTable dt1 = dt.Copy();
                DataTable dt2 = dt.Copy();

                cmbDepartment.DataSource = dt1;
                cmbDepartment.DisplayMember = "Ten_phong_ban";
                cmbDepartment.ValueMember = "Ma_phong_ban";
                cmbDepartment.SelectedIndex = -1;

                DataRow rowAll = dt2.NewRow();
                rowAll["Ma_phong_ban"] = DBNull.Value;
                rowAll["Ten_phong_ban"] = "-- Tất cả --";
                dt2.Rows.InsertAt(rowAll, 0);

                cmbLocPhongBan.DataSource = dt2;
                cmbLocPhongBan.DisplayMember = "Ten_phong_ban";
                cmbLocPhongBan.ValueMember = "Ma_phong_ban";
                cmbLocPhongBan.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải phòng ban: " + ex.Message);
            }
        }

        private void LoadPositions()
        {
            try
            {
                DataTable dt = danhMucBLL.GetPositions();
                DataTable dt1 = dt.Copy();
                DataTable dt2 = dt.Copy();

                cmbPosition.DataSource = dt1;
                cmbPosition.DisplayMember = "Ten_chuc_vu";
                cmbPosition.ValueMember = "Ma_chuc_vu";
                cmbPosition.SelectedIndex = -1;

                DataRow rowAll = dt2.NewRow();
                rowAll["Ma_chuc_vu"] = DBNull.Value;
                rowAll["Ten_chuc_vu"] = "-- Tất cả --";
                dt2.Rows.InsertAt(rowAll, 0);

                cmbLocChucVu.DataSource = dt2;
                cmbLocChucVu.DisplayMember = "Ten_chuc_vu";
                cmbLocChucVu.ValueMember = "Ma_chuc_vu";
                cmbLocChucVu.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chức vụ: " + ex.Message);
            }
        }

        private void LoadStaticCombobox()
        {
            cmbGender.Items.Clear();
            cmbGender.Items.Add("Nam");
            cmbGender.Items.Add("Nữ");
            cmbGender.Items.Add("Khác");
            cmbGender.SelectedIndex = -1;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Đang làm");
            cmbStatus.Items.Add("Tạm nghỉ");
            cmbStatus.Items.Add("Nghỉ việc");
            cmbStatus.SelectedIndex = -1;
        }

        private void LoadFilterCombobox()
        {
            cmbLocTinhTrang.Items.Clear();
            cmbLocTinhTrang.Items.Add("-- Tất cả --");
            cmbLocTinhTrang.Items.Add("Đang làm");
            cmbLocTinhTrang.Items.Add("Tạm nghỉ");
            cmbLocTinhTrang.Items.Add("Nghỉ việc");
            cmbLocTinhTrang.SelectedIndex = 0;
        }

        // ================= CLICK GRID =================
        private void dataGridViewEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewEmployees.Rows[e.RowIndex];

            txtMaNhanVien.Text = row.Cells["Ma_nhan_vien"].Value?.ToString() ?? "";
            txtFullName.Text = row.Cells["Ten_nhan_vien"].Value?.ToString() ?? "";
            txtCCCD.Text = row.Cells["CCCD"].Value?.ToString() ?? "";
            txtPhone.Text = row.Cells["SDT"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            txtAddress.Text = row.Cells["Dia_chi"].Value?.ToString() ?? "";
            txtLuongCoBan.Text = row.Cells["Luong_co_ban"].Value?.ToString() ?? "";
            cmbGender.Text = row.Cells["Gioi_tinh"].Value?.ToString() ?? "";
            cmbStatus.Text = row.Cells["Tinh_trang"].Value?.ToString() ?? "";

            if (DateTime.TryParse(row.Cells["Ngay_sinh"].Value?.ToString(), out DateTime birthDate))
                dtpBirthDate.Value = birthDate;

            if (DateTime.TryParse(row.Cells["Ngay_vao_lam"].Value?.ToString(), out DateTime ngayVaoLam))
                dtpNgayVaoLam.Value = ngayVaoLam;

            if (row.Cells["Ma_phong_ban"].Value != DBNull.Value && row.Cells["Ma_phong_ban"].Value != null)
                cmbDepartment.SelectedValue = Convert.ToInt32(row.Cells["Ma_phong_ban"].Value);

            if (row.Cells["Ma_chuc_vu"].Value != DBNull.Value && row.Cells["Ma_chuc_vu"].Value != null)
                cmbPosition.SelectedValue = Convert.ToInt32(row.Cells["Ma_chuc_vu"].Value);

            selectedImagePath = row.Cells["Anh_nv"].Value?.ToString() ?? "";
            LoadEmployeeImage(selectedImagePath);
        }

        // ================= ẢNH =================
        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Chọn ảnh nhân viên";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;
                    LoadEmployeeImage(selectedImagePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn ảnh: " + ex.Message);
            }
        }

        private void LoadEmployeeImage(string path)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        pictureBoxAnh.Image = Image.FromStream(fs);
                    }
                }
                else
                {
                    pictureBoxAnh.Image = null;
                }
            }
            catch
            {
                pictureBoxAnh.Image = null;
            }
        }

        // ================= THÊM =================
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput(true)) return;

                NhanVienDto employee = CreateEmployeeDto();

                try
                {
                    int maNhanVien = nhanVienBLL.AddEmployee(employee);
                    txtMaNhanVien.Text = maNhanVien.ToString();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                    txtMaNhanVien.Focus();
                    return;
                }

                MessageBox.Show("Thêm nhân viên thành công.");
                LoadEmployeeData();
                ConfigureDataGridView();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message);
            }
        }

        // ================= SỬA =================
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần sửa.");
                    return;
                }

                if (!ValidateInput(false)) return;

                nhanVienBLL.UpdateEmployee(CreateEmployeeDto());

                MessageBox.Show("Sửa nhân viên thành công.");
                LoadEmployeeData();
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa nhân viên: " + ex.Message);
            }
        }

        // ================= XÓA =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn xóa nhân viên này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No) return;

                nhanVienBLL.DeleteEmployee(int.Parse(txtMaNhanVien.Text));

                MessageBox.Show("Xóa nhân viên thành công.");
                LoadEmployeeData();
                ConfigureDataGridView();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa nhân viên: " + ex.Message);
            }
        }

        // ================= TÌM KIẾM KIỂU LỌC =================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                int? maPhongBan = cmbLocPhongBan.SelectedValue != null && cmbLocPhongBan.SelectedIndex > 0
                    ? Convert.ToInt32(cmbLocPhongBan.SelectedValue)
                    : (int?)null;

                int? maChucVu = cmbLocChucVu.SelectedValue != null && cmbLocChucVu.SelectedIndex > 0
                    ? Convert.ToInt32(cmbLocChucVu.SelectedValue)
                    : (int?)null;

                string tinhTrang = cmbLocTinhTrang.SelectedIndex > 0
                    ? cmbLocTinhTrang.Text
                    : null;

                dataGridViewEmployees.DataSource = nhanVienBLL.SearchEmployees(
                    maPhongBan,
                    maChucVu,
                    tinhTrang,
                    txtTuKhoa.Text);

                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            cmbLocPhongBan.SelectedIndex = 0;
            cmbLocChucVu.SelectedIndex = 0;
            cmbLocTinhTrang.SelectedIndex = 0;
            txtTuKhoa.Clear();

            LoadEmployeeData();
            ConfigureDataGridView();
        }

        // ================= HỖ TRỢ =================
        private NhanVienDto CreateEmployeeDto()
        {
            return new NhanVienDto
            {
                MaNhanVien = string.IsNullOrWhiteSpace(txtMaNhanVien.Text)
                    ? (int?)null
                    : int.Parse(txtMaNhanVien.Text.Trim()),
                TenNhanVien = txtFullName.Text.Trim(),
                NgaySinh = dtpBirthDate.Value.Date,
                GioiTinh = cmbGender.Text.Trim(),
                CCCD = txtCCCD.Text.Trim(),
                DiaChi = txtAddress.Text.Trim(),
                SDT = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                NgayVaoLam = dtpNgayVaoLam.Value.Date,
                MaChucVu = Convert.ToInt32(cmbPosition.SelectedValue),
                TenChucVu = cmbPosition.Text,
                MaPhongBan = Convert.ToInt32(cmbDepartment.SelectedValue),
                TenPhongBan = cmbDepartment.Text,
                LuongCoBan = decimal.Parse(txtLuongCoBan.Text.Trim()),
                TinhTrang = cmbStatus.Text,
                AnhNv = selectedImagePath
            };
        }

        private bool ValidateInput(bool isAddNew)
        {
            if (!string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
            {
                if (!int.TryParse(txtMaNhanVien.Text.Trim(), out _))
                {
                    MessageBox.Show("Mã nhân viên phải là số nguyên.");
                    txtMaNhanVien.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên.");
                txtFullName.Focus();
                return false;
            }

            if (cmbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                cmbGender.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập CCCD.");
                txtCCCD.Focus();
                return false;
            }

            if (cmbDepartment.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng ban.");
                cmbDepartment.Focus();
                return false;
            }

            if (cmbPosition.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn chức vụ.");
                cmbPosition.Focus();
                return false;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tình trạng.");
                cmbStatus.Focus();
                return false;
            }

            if (!decimal.TryParse(txtLuongCoBan.Text.Trim(), out _))
            {
                MessageBox.Show("Lương cơ bản không hợp lệ.");
                txtLuongCoBan.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtMaNhanVien.Clear();
            txtFullName.Clear();
            txtCCCD.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtLuongCoBan.Clear();

            cmbGender.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;

            dtpBirthDate.Value = DateTime.Now;
            dtpNgayVaoLam.Value = DateTime.Now;

            selectedImagePath = "";
            pictureBoxAnh.Image = null;
        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
