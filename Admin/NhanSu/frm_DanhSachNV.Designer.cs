namespace QuanLyNhanSu
{
    partial class frm_DanhSachNV
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.gbLoc = new System.Windows.Forms.GroupBox();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.cmbLocTinhTrang = new System.Windows.Forms.ComboBox();
            this.lblLocTinhTrang = new System.Windows.Forms.Label();
            this.cmbLocChucVu = new System.Windows.Forms.ComboBox();
            this.lblLocChucVu = new System.Windows.Forms.Label();
            this.cmbLocPhongBan = new System.Windows.Forms.ComboBox();
            this.lblLocPhongBan = new System.Windows.Forms.Label();
            this.gbEmployeeInfo = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.gbAnh = new System.Windows.Forms.GroupBox();
            this.btnThemAnh = new System.Windows.Forms.Button();
            this.pictureBoxAnh = new System.Windows.Forms.PictureBox();
            this.txtTenNganHang = new System.Windows.Forms.TextBox();
            this.lblTenNganHang = new System.Windows.Forms.Label();
            this.txtSoTaiKhoan = new System.Windows.Forms.TextBox();
            this.lblSoTaiKhoan = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtLuongCoBan = new System.Windows.Forms.TextBox();
            this.lblLuongCoBan = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.dtpNgayVaoLam = new System.Windows.Forms.DateTimePicker();
            this.lblNgayVaoLam = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.lblMaNhanVien = new System.Windows.Forms.Label();
            this.gbEmployeeList = new System.Windows.Forms.GroupBox();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.gbLoc.SuspendLayout();
            this.gbEmployeeInfo.SuspendLayout();
            this.gbAnh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnh)).BeginInit();
            this.gbEmployeeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // gbLoc
            // 
            this.gbLoc.Controls.Add(this.btnTaiLai);
            this.gbLoc.Controls.Add(this.btnTimKiem);
            this.gbLoc.Controls.Add(this.txtTuKhoa);
            this.gbLoc.Controls.Add(this.lblTuKhoa);
            this.gbLoc.Controls.Add(this.cmbLocTinhTrang);
            this.gbLoc.Controls.Add(this.lblLocTinhTrang);
            this.gbLoc.Controls.Add(this.cmbLocChucVu);
            this.gbLoc.Controls.Add(this.lblLocChucVu);
            this.gbLoc.Controls.Add(this.cmbLocPhongBan);
            this.gbLoc.Controls.Add(this.lblLocPhongBan);
            this.gbLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbLoc.Location = new System.Drawing.Point(0, 0);
            this.gbLoc.Name = "gbLoc";
            this.gbLoc.Size = new System.Drawing.Size(1200, 80);
            this.gbLoc.TabIndex = 0;
            this.gbLoc.TabStop = false;
            this.gbLoc.Text = "Lọc nhân viên";
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Location = new System.Drawing.Point(1062, 31);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(90, 28);
            this.btnTaiLai.TabIndex = 9;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(966, 31);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 28);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(760, 35);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(190, 20);
            this.txtTuKhoa.TabIndex = 7;
            this.txtTuKhoa.TextChanged += new System.EventHandler(this.txtTuKhoa_TextChanged);
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Location = new System.Drawing.Point(705, 38);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(47, 13);
            this.lblTuKhoa.TabIndex = 6;
            this.lblTuKhoa.Text = "Từ khóa";
            // 
            // cmbLocTinhTrang
            // 
            this.cmbLocTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocTinhTrang.FormattingEnabled = true;
            this.cmbLocTinhTrang.Location = new System.Drawing.Point(504, 34);
            this.cmbLocTinhTrang.Name = "cmbLocTinhTrang";
            this.cmbLocTinhTrang.Size = new System.Drawing.Size(180, 21);
            this.cmbLocTinhTrang.TabIndex = 5;
            // 
            // lblLocTinhTrang
            // 
            this.lblLocTinhTrang.AutoSize = true;
            this.lblLocTinhTrang.Location = new System.Drawing.Point(438, 38);
            this.lblLocTinhTrang.Name = "lblLocTinhTrang";
            this.lblLocTinhTrang.Size = new System.Drawing.Size(55, 13);
            this.lblLocTinhTrang.TabIndex = 4;
            this.lblLocTinhTrang.Text = "Tình trạng";
            // 
            // cmbLocChucVu
            // 
            this.cmbLocChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocChucVu.FormattingEnabled = true;
            this.cmbLocChucVu.Location = new System.Drawing.Point(252, 34);
            this.cmbLocChucVu.Name = "cmbLocChucVu";
            this.cmbLocChucVu.Size = new System.Drawing.Size(170, 21);
            this.cmbLocChucVu.TabIndex = 3;
            // 
            // lblLocChucVu
            // 
            this.lblLocChucVu.AutoSize = true;
            this.lblLocChucVu.Location = new System.Drawing.Point(199, 38);
            this.lblLocChucVu.Name = "lblLocChucVu";
            this.lblLocChucVu.Size = new System.Drawing.Size(47, 13);
            this.lblLocChucVu.TabIndex = 2;
            this.lblLocChucVu.Text = "Chức vụ";
            // 
            // cmbLocPhongBan
            // 
            this.cmbLocPhongBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocPhongBan.FormattingEnabled = true;
            this.cmbLocPhongBan.Location = new System.Drawing.Point(72, 34);
            this.cmbLocPhongBan.Name = "cmbLocPhongBan";
            this.cmbLocPhongBan.Size = new System.Drawing.Size(121, 21);
            this.cmbLocPhongBan.TabIndex = 1;
            // 
            // lblLocPhongBan
            // 
            this.lblLocPhongBan.AutoSize = true;
            this.lblLocPhongBan.Location = new System.Drawing.Point(12, 38);
            this.lblLocPhongBan.Name = "lblLocPhongBan";
            this.lblLocPhongBan.Size = new System.Drawing.Size(59, 13);
            this.lblLocPhongBan.TabIndex = 0;
            this.lblLocPhongBan.Text = "Phòng ban";
            // 
            // gbEmployeeInfo
            // 
            this.gbEmployeeInfo.Controls.Add(this.btnXoa);
            this.gbEmployeeInfo.Controls.Add(this.btnSua);
            this.gbEmployeeInfo.Controls.Add(this.btnThem);
            this.gbEmployeeInfo.Controls.Add(this.gbAnh);
            this.gbEmployeeInfo.Controls.Add(this.txtTenNganHang);
            this.gbEmployeeInfo.Controls.Add(this.lblTenNganHang);
            this.gbEmployeeInfo.Controls.Add(this.txtSoTaiKhoan);
            this.gbEmployeeInfo.Controls.Add(this.lblSoTaiKhoan);
            this.gbEmployeeInfo.Controls.Add(this.cmbStatus);
            this.gbEmployeeInfo.Controls.Add(this.lblStatus);
            this.gbEmployeeInfo.Controls.Add(this.txtLuongCoBan);
            this.gbEmployeeInfo.Controls.Add(this.lblLuongCoBan);
            this.gbEmployeeInfo.Controls.Add(this.cmbPosition);
            this.gbEmployeeInfo.Controls.Add(this.lblPosition);
            this.gbEmployeeInfo.Controls.Add(this.cmbDepartment);
            this.gbEmployeeInfo.Controls.Add(this.lblDepartment);
            this.gbEmployeeInfo.Controls.Add(this.dtpNgayVaoLam);
            this.gbEmployeeInfo.Controls.Add(this.lblNgayVaoLam);
            this.gbEmployeeInfo.Controls.Add(this.txtAddress);
            this.gbEmployeeInfo.Controls.Add(this.lblAddress);
            this.gbEmployeeInfo.Controls.Add(this.txtEmail);
            this.gbEmployeeInfo.Controls.Add(this.lblEmail);
            this.gbEmployeeInfo.Controls.Add(this.txtPhone);
            this.gbEmployeeInfo.Controls.Add(this.lblPhone);
            this.gbEmployeeInfo.Controls.Add(this.txtCCCD);
            this.gbEmployeeInfo.Controls.Add(this.lblCCCD);
            this.gbEmployeeInfo.Controls.Add(this.cmbGender);
            this.gbEmployeeInfo.Controls.Add(this.lblGender);
            this.gbEmployeeInfo.Controls.Add(this.dtpBirthDate);
            this.gbEmployeeInfo.Controls.Add(this.lblBirthDate);
            this.gbEmployeeInfo.Controls.Add(this.txtFullName);
            this.gbEmployeeInfo.Controls.Add(this.lblFullName);
            this.gbEmployeeInfo.Controls.Add(this.txtMaNhanVien);
            this.gbEmployeeInfo.Controls.Add(this.lblMaNhanVien);
            this.gbEmployeeInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbEmployeeInfo.Location = new System.Drawing.Point(0, 80);
            this.gbEmployeeInfo.Name = "gbEmployeeInfo";
            this.gbEmployeeInfo.Size = new System.Drawing.Size(1200, 310);
            this.gbEmployeeInfo.TabIndex = 1;
            this.gbEmployeeInfo.TabStop = false;
            this.gbEmployeeInfo.Text = "Thông tin nhân viên";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(623, 250);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 32);
            this.btnXoa.TabIndex = 29;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(527, 250);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 32);
            this.btnSua.TabIndex = 28;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(431, 250);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 32);
            this.btnThem.TabIndex = 27;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // gbAnh
            // 
            this.gbAnh.Controls.Add(this.btnThemAnh);
            this.gbAnh.Controls.Add(this.pictureBoxAnh);
            this.gbAnh.Location = new System.Drawing.Point(920, 22);
            this.gbAnh.Name = "gbAnh";
            this.gbAnh.Size = new System.Drawing.Size(220, 230);
            this.gbAnh.TabIndex = 26;
            this.gbAnh.TabStop = false;
            this.gbAnh.Text = "Ảnh nhân viên";
            // 
            // btnThemAnh
            // 
            this.btnThemAnh.Location = new System.Drawing.Point(61, 186);
            this.btnThemAnh.Name = "btnThemAnh";
            this.btnThemAnh.Size = new System.Drawing.Size(100, 30);
            this.btnThemAnh.TabIndex = 1;
            this.btnThemAnh.Text = "Thêm ảnh";
            this.btnThemAnh.UseVisualStyleBackColor = true;
            this.btnThemAnh.Click += new System.EventHandler(this.btnThemAnh_Click);
            // 
            // pictureBoxAnh
            // 
            this.pictureBoxAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAnh.Location = new System.Drawing.Point(31, 25);
            this.pictureBoxAnh.Name = "pictureBoxAnh";
            this.pictureBoxAnh.Size = new System.Drawing.Size(160, 150);
            this.pictureBoxAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAnh.TabIndex = 0;
            this.pictureBoxAnh.TabStop = false;
            // 
            // txtTenNganHang
            // 
            this.txtTenNganHang.Location = new System.Drawing.Point(707, 227);
            this.txtTenNganHang.Name = "txtTenNganHang";
            this.txtTenNganHang.Size = new System.Drawing.Size(180, 20);
            this.txtTenNganHang.TabIndex = 33;
            // 
            // lblTenNganHang
            // 
            this.lblTenNganHang.AutoSize = true;
            this.lblTenNganHang.Location = new System.Drawing.Point(612, 230);
            this.lblTenNganHang.Name = "lblTenNganHang";
            this.lblTenNganHang.Size = new System.Drawing.Size(80, 13);
            this.lblTenNganHang.TabIndex = 32;
            this.lblTenNganHang.Text = "Tên ngân hàng";
            // 
            // txtSoTaiKhoan
            // 
            this.txtSoTaiKhoan.Location = new System.Drawing.Point(707, 192);
            this.txtSoTaiKhoan.Name = "txtSoTaiKhoan";
            this.txtSoTaiKhoan.Size = new System.Drawing.Size(180, 20);
            this.txtSoTaiKhoan.TabIndex = 31;
            // 
            // lblSoTaiKhoan
            // 
            this.lblSoTaiKhoan.AutoSize = true;
            this.lblSoTaiKhoan.Location = new System.Drawing.Point(628, 195);
            this.lblSoTaiKhoan.Name = "lblSoTaiKhoan";
            this.lblSoTaiKhoan.Size = new System.Drawing.Size(67, 13);
            this.lblSoTaiKhoan.TabIndex = 30;
            this.lblSoTaiKhoan.Text = "Số tài khoản";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(707, 157);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(180, 21);
            this.cmbStatus.TabIndex = 25;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(628, 161);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(55, 13);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "Tình trạng";
            // 
            // txtLuongCoBan
            // 
            this.txtLuongCoBan.Location = new System.Drawing.Point(707, 122);
            this.txtLuongCoBan.Name = "txtLuongCoBan";
            this.txtLuongCoBan.Size = new System.Drawing.Size(180, 20);
            this.txtLuongCoBan.TabIndex = 23;
            // 
            // lblLuongCoBan
            // 
            this.lblLuongCoBan.AutoSize = true;
            this.lblLuongCoBan.Location = new System.Drawing.Point(628, 125);
            this.lblLuongCoBan.Name = "lblLuongCoBan";
            this.lblLuongCoBan.Size = new System.Drawing.Size(73, 13);
            this.lblLuongCoBan.TabIndex = 22;
            this.lblLuongCoBan.Text = "Lương cơ bản";
            // 
            // cmbPosition
            // 
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(707, 87);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(180, 21);
            this.cmbPosition.TabIndex = 21;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(628, 91);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(47, 13);
            this.lblPosition.TabIndex = 20;
            this.lblPosition.Text = "Chức vụ";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(707, 52);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(180, 21);
            this.cmbDepartment.TabIndex = 19;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(628, 56);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(59, 13);
            this.lblDepartment.TabIndex = 18;
            this.lblDepartment.Text = "Phòng ban";
            // 
            // dtpNgayVaoLam
            // 
            this.dtpNgayVaoLam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayVaoLam.Location = new System.Drawing.Point(707, 17);
            this.dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            this.dtpNgayVaoLam.Size = new System.Drawing.Size(180, 20);
            this.dtpNgayVaoLam.TabIndex = 17;
            // 
            // lblNgayVaoLam
            // 
            this.lblNgayVaoLam.AutoSize = true;
            this.lblNgayVaoLam.Location = new System.Drawing.Point(628, 21);
            this.lblNgayVaoLam.Name = "lblNgayVaoLam";
            this.lblNgayVaoLam.Size = new System.Drawing.Size(72, 13);
            this.lblNgayVaoLam.TabIndex = 16;
            this.lblNgayVaoLam.Text = "Ngày vào làm";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(102, 227);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(490, 20);
            this.txtAddress.TabIndex = 15;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(15, 230);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(40, 13);
            this.lblAddress.TabIndex = 14;
            this.lblAddress.Text = "Địa chỉ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(102, 192);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(490, 20);
            this.txtEmail.TabIndex = 13;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(15, 195);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "Email";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(102, 157);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(180, 20);
            this.txtPhone.TabIndex = 11;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(15, 160);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(70, 13);
            this.lblPhone.TabIndex = 10;
            this.lblPhone.Text = "Số điện thoại";
            // 
            // txtCCCD
            // 
            this.txtCCCD.Location = new System.Drawing.Point(102, 122);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(180, 20);
            this.txtCCCD.TabIndex = 9;
            // 
            // lblCCCD
            // 
            this.lblCCCD.AutoSize = true;
            this.lblCCCD.Location = new System.Drawing.Point(15, 125);
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.Size = new System.Drawing.Size(36, 13);
            this.lblCCCD.TabIndex = 8;
            this.lblCCCD.Text = "CCCD";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(412, 87);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(180, 21);
            this.cmbGender.TabIndex = 7;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(333, 91);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(47, 13);
            this.lblGender.TabIndex = 6;
            this.lblGender.Text = "Giới tính";
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(412, 52);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(180, 20);
            this.dtpBirthDate.TabIndex = 5;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(333, 56);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(54, 13);
            this.lblBirthDate.TabIndex = 4;
            this.lblBirthDate.Text = "Ngày sinh";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(102, 87);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(180, 20);
            this.txtFullName.TabIndex = 3;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(15, 90);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(54, 13);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Họ và tên";
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Location = new System.Drawing.Point(102, 52);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.ReadOnly = true;
            this.txtMaNhanVien.Size = new System.Drawing.Size(180, 20);
            this.txtMaNhanVien.TabIndex = 1;
            // 
            // lblMaNhanVien
            // 
            this.lblMaNhanVien.AutoSize = true;
            this.lblMaNhanVien.Location = new System.Drawing.Point(15, 55);
            this.lblMaNhanVien.Name = "lblMaNhanVien";
            this.lblMaNhanVien.Size = new System.Drawing.Size(72, 13);
            this.lblMaNhanVien.TabIndex = 0;
            this.lblMaNhanVien.Text = "Mã nhân viên";
            // 
            // gbEmployeeList
            // 
            this.gbEmployeeList.Controls.Add(this.dataGridViewEmployees);
            this.gbEmployeeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEmployeeList.Location = new System.Drawing.Point(0, 390);
            this.gbEmployeeList.Name = "gbEmployeeList";
            this.gbEmployeeList.Size = new System.Drawing.Size(1200, 310);
            this.gbEmployeeList.TabIndex = 2;
            this.gbEmployeeList.TabStop = false;
            this.gbEmployeeList.Text = "Danh sách nhân viên";
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.Size = new System.Drawing.Size(1194, 291);
            this.dataGridViewEmployees.TabIndex = 0;
            this.dataGridViewEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmployees_CellClick);
            // 
            // frm_DanhSachNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.gbEmployeeList);
            this.Controls.Add(this.gbEmployeeInfo);
            this.Controls.Add(this.gbLoc);
            this.Name = "frm_DanhSachNV";
            this.Text = "Danh sách nhân viên";
            this.Load += new System.EventHandler(this.frm_DanhSachNV_Load);
            this.gbLoc.ResumeLayout(false);
            this.gbLoc.PerformLayout();
            this.gbEmployeeInfo.ResumeLayout(false);
            this.gbEmployeeInfo.PerformLayout();
            this.gbAnh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnh)).EndInit();
            this.gbEmployeeList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLoc;
        private System.Windows.Forms.ComboBox cmbLocPhongBan;
        private System.Windows.Forms.Label lblLocPhongBan;
        private System.Windows.Forms.ComboBox cmbLocChucVu;
        private System.Windows.Forms.Label lblLocChucVu;
        private System.Windows.Forms.ComboBox cmbLocTinhTrang;
        private System.Windows.Forms.Label lblLocTinhTrang;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.GroupBox gbEmployeeInfo;
        private System.Windows.Forms.Label lblMaNhanVien;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblNgayVaoLam;
        private System.Windows.Forms.DateTimePicker dtpNgayVaoLam;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label lblLuongCoBan;
        private System.Windows.Forms.TextBox txtLuongCoBan;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.GroupBox gbAnh;
        private System.Windows.Forms.PictureBox pictureBoxAnh;
        private System.Windows.Forms.Button btnThemAnh;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.GroupBox gbEmployeeList;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.TextBox txtSoTaiKhoan;
        private System.Windows.Forms.Label lblSoTaiKhoan;
        private System.Windows.Forms.TextBox txtTenNganHang;
        private System.Windows.Forms.Label lblTenNganHang;
    }
}
