namespace QuanLyNhanSu.Admin.HeThong
{
    partial class frmCapTaiKhoan
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

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBoxDanhSachNhanVien = new System.Windows.Forms.GroupBox();
            this.dgvNhanVienChuaCoTaiKhoan = new System.Windows.Forms.DataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.groupBoxThongTinTaiKhoan = new System.Windows.Forms.GroupBox();
            this.lblGoiY = new System.Windows.Forms.Label();
            this.chkHienMatKhau = new System.Windows.Forms.CheckBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnCapTaiKhoan = new System.Windows.Forms.Button();
            this.cmbQuyen = new System.Windows.Forms.ComboBox();
            this.lblQuyen = new System.Windows.Forms.Label();
            this.txtNhapLaiMatKhau = new System.Windows.Forms.TextBox();
            this.lblNhapLaiMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.lblMaNhanVien = new System.Windows.Forms.Label();
            this.groupBoxDanhSachNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVienChuaCoTaiKhoan)).BeginInit();
            this.groupBoxThongTinTaiKhoan.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1050, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CẤP TÀI KHOẢN CHO NHÂN VIÊN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxDanhSachNhanVien
            // 
            this.groupBoxDanhSachNhanVien.Controls.Add(this.dgvNhanVienChuaCoTaiKhoan);
            this.groupBoxDanhSachNhanVien.Controls.Add(this.btnTimKiem);
            this.groupBoxDanhSachNhanVien.Controls.Add(this.txtTimKiem);
            this.groupBoxDanhSachNhanVien.Controls.Add(this.lblTimKiem);
            this.groupBoxDanhSachNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBoxDanhSachNhanVien.Location = new System.Drawing.Point(97, 75);
            this.groupBoxDanhSachNhanVien.Name = "groupBoxDanhSachNhanVien";
            this.groupBoxDanhSachNhanVien.Size = new System.Drawing.Size(1004, 560);
            this.groupBoxDanhSachNhanVien.TabIndex = 1;
            this.groupBoxDanhSachNhanVien.TabStop = false;
            this.groupBoxDanhSachNhanVien.Text = "Nhân viên chưa có tài khoản";
            // 
            // dgvNhanVienChuaCoTaiKhoan
            // 
            this.dgvNhanVienChuaCoTaiKhoan.AllowUserToAddRows = false;
            this.dgvNhanVienChuaCoTaiKhoan.AllowUserToDeleteRows = false;
            this.dgvNhanVienChuaCoTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVienChuaCoTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVienChuaCoTaiKhoan.Location = new System.Drawing.Point(20, 80);
            this.dgvNhanVienChuaCoTaiKhoan.MultiSelect = false;
            this.dgvNhanVienChuaCoTaiKhoan.Name = "dgvNhanVienChuaCoTaiKhoan";
            this.dgvNhanVienChuaCoTaiKhoan.ReadOnly = true;
            this.dgvNhanVienChuaCoTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVienChuaCoTaiKhoan.Size = new System.Drawing.Size(931, 460);
            this.dgvNhanVienChuaCoTaiKhoan.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.Location = new System.Drawing.Point(530, 32);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 28);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(100, 35);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(410, 23);
            this.txtTimKiem.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(20, 38);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(64, 17);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm kiếm";
            // 
            // groupBoxThongTinTaiKhoan
            // 
            this.groupBoxThongTinTaiKhoan.Controls.Add(this.lblGoiY);
            this.groupBoxThongTinTaiKhoan.Controls.Add(this.chkHienMatKhau);
            this.groupBoxThongTinTaiKhoan.Controls.Add(this.btnLamMoi);
            this.groupBoxThongTinTaiKhoan.Controls.Add(this.btnCapTaiKhoan);
            this.groupBoxThongTinTaiKhoan.Controls.Add(this.cmbQuyen);
            this.groupBoxThongTinTaiKhoan.Controls.Add(this.lblQuyen);
            this.groupBoxThongTinTaiKhoan.Controls.Add(this.txtNhapLaiMatKhau);
            this.groupBoxThongTinTaiKhoan.Controls.Add(this.lblNhapLaiMatKhau);
            this.groupBoxThongTinTaiKhoan.Controls.Add(this.txtMatKhau);
            this.groupBoxThongTinTaiKhoan.Controls.Add(this.lblMatKhau);
            this.groupBoxThongTinTaiKhoan.Controls.Add(this.txtTaiKhoan);
            this.groupBoxThongTinTaiKhoan.Controls.Add(this.lblTaiKhoan);
            this.groupBoxThongTinTaiKhoan.Controls.Add(this.txtTenNhanVien);
            this.groupBoxThongTinTaiKhoan.Controls.Add(this.lblTenNhanVien);
            this.groupBoxThongTinTaiKhoan.Controls.Add(this.txtMaNhanVien);
            this.groupBoxThongTinTaiKhoan.Controls.Add(this.lblMaNhanVien);
            this.groupBoxThongTinTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBoxThongTinTaiKhoan.Location = new System.Drawing.Point(1193, 75);
            this.groupBoxThongTinTaiKhoan.Name = "groupBoxThongTinTaiKhoan";
            this.groupBoxThongTinTaiKhoan.Size = new System.Drawing.Size(354, 560);
            this.groupBoxThongTinTaiKhoan.TabIndex = 2;
            this.groupBoxThongTinTaiKhoan.TabStop = false;
            this.groupBoxThongTinTaiKhoan.Text = "Thông tin tài khoản";
            // 
            // lblGoiY
            // 
            this.lblGoiY.ForeColor = System.Drawing.Color.DimGray;
            this.lblGoiY.Location = new System.Drawing.Point(30, 435);
            this.lblGoiY.Name = "lblGoiY";
            this.lblGoiY.Size = new System.Drawing.Size(285, 45);
            this.lblGoiY.TabIndex = 15;
            this.lblGoiY.Text = "Chọn nhân viên ở bảng bên trái, sau đó nhập tài khoản và mật khẩu.";
            // 
            // chkHienMatKhau
            // 
            this.chkHienMatKhau.AutoSize = true;
            this.chkHienMatKhau.Location = new System.Drawing.Point(130, 310);
            this.chkHienMatKhau.Name = "chkHienMatKhau";
            this.chkHienMatKhau.Size = new System.Drawing.Size(118, 21);
            this.chkHienMatKhau.TabIndex = 11;
            this.chkHienMatKhau.Text = "Hiện mật khẩu";
            this.chkHienMatKhau.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.Location = new System.Drawing.Point(190, 380);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(125, 35);
            this.btnLamMoi.TabIndex = 14;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnCapTaiKhoan
            // 
            this.btnCapTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCapTaiKhoan.Location = new System.Drawing.Point(30, 380);
            this.btnCapTaiKhoan.Name = "btnCapTaiKhoan";
            this.btnCapTaiKhoan.Size = new System.Drawing.Size(140, 35);
            this.btnCapTaiKhoan.TabIndex = 13;
            this.btnCapTaiKhoan.Text = "Cấp tài khoản";
            this.btnCapTaiKhoan.UseVisualStyleBackColor = true;
            // 
            // cmbQuyen
            // 
            this.cmbQuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuyen.FormattingEnabled = true;
            this.cmbQuyen.Location = new System.Drawing.Point(130, 340);
            this.cmbQuyen.Name = "cmbQuyen";
            this.cmbQuyen.Size = new System.Drawing.Size(185, 24);
            this.cmbQuyen.TabIndex = 12;
            // 
            // lblQuyen
            // 
            this.lblQuyen.AutoSize = true;
            this.lblQuyen.Location = new System.Drawing.Point(30, 343);
            this.lblQuyen.Name = "lblQuyen";
            this.lblQuyen.Size = new System.Drawing.Size(50, 17);
            this.lblQuyen.TabIndex = 11;
            this.lblQuyen.Text = "Quyền";
            // 
            // txtNhapLaiMatKhau
            // 
            this.txtNhapLaiMatKhau.Location = new System.Drawing.Point(130, 270);
            this.txtNhapLaiMatKhau.Name = "txtNhapLaiMatKhau";
            this.txtNhapLaiMatKhau.PasswordChar = '*';
            this.txtNhapLaiMatKhau.Size = new System.Drawing.Size(185, 23);
            this.txtNhapLaiMatKhau.TabIndex = 10;
            // 
            // lblNhapLaiMatKhau
            // 
            this.lblNhapLaiMatKhau.AutoSize = true;
            this.lblNhapLaiMatKhau.Location = new System.Drawing.Point(30, 273);
            this.lblNhapLaiMatKhau.Name = "lblNhapLaiMatKhau";
            this.lblNhapLaiMatKhau.Size = new System.Drawing.Size(84, 17);
            this.lblNhapLaiMatKhau.TabIndex = 9;
            this.lblNhapLaiMatKhau.Text = "Nhập lại MK";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(130, 225);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(185, 23);
            this.txtMatKhau.TabIndex = 8;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(30, 228);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(66, 17);
            this.lblMatKhau.TabIndex = 7;
            this.lblMatKhau.Text = "Mật khẩu";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(130, 180);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(185, 23);
            this.txtTaiKhoan.TabIndex = 6;
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.Location = new System.Drawing.Point(30, 183);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(71, 17);
            this.lblTaiKhoan.TabIndex = 5;
            this.lblTaiKhoan.Text = "Tài khoản";
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Location = new System.Drawing.Point(130, 110);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.ReadOnly = true;
            this.txtTenNhanVien.Size = new System.Drawing.Size(185, 23);
            this.txtTenNhanVien.TabIndex = 4;
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.AutoSize = true;
            this.lblTenNhanVien.Location = new System.Drawing.Point(30, 113);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(99, 17);
            this.lblTenNhanVien.TabIndex = 3;
            this.lblTenNhanVien.Text = "Tên nhân viên";
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Location = new System.Drawing.Point(130, 65);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.ReadOnly = true;
            this.txtMaNhanVien.Size = new System.Drawing.Size(185, 23);
            this.txtMaNhanVien.TabIndex = 2;
            // 
            // lblMaNhanVien
            // 
            this.lblMaNhanVien.AutoSize = true;
            this.lblMaNhanVien.Location = new System.Drawing.Point(30, 68);
            this.lblMaNhanVien.Name = "lblMaNhanVien";
            this.lblMaNhanVien.Size = new System.Drawing.Size(93, 17);
            this.lblMaNhanVien.TabIndex = 1;
            this.lblMaNhanVien.Text = "Mã nhân viên";
            // 
            // frmCapTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 1041);
            this.Controls.Add(this.groupBoxThongTinTaiKhoan);
            this.Controls.Add(this.groupBoxDanhSachNhanVien);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmCapTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấp tài khoản";
            this.groupBoxDanhSachNhanVien.ResumeLayout(false);
            this.groupBoxDanhSachNhanVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVienChuaCoTaiKhoan)).EndInit();
            this.groupBoxThongTinTaiKhoan.ResumeLayout(false);
            this.groupBoxThongTinTaiKhoan.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBoxDanhSachNhanVien;
        private System.Windows.Forms.DataGridView dgvNhanVienChuaCoTaiKhoan;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.GroupBox groupBoxThongTinTaiKhoan;
        private System.Windows.Forms.Label lblGoiY;
        private System.Windows.Forms.CheckBox chkHienMatKhau;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnCapTaiKhoan;
        private System.Windows.Forms.ComboBox cmbQuyen;
        private System.Windows.Forms.Label lblQuyen;
        private System.Windows.Forms.TextBox txtNhapLaiMatKhau;
        private System.Windows.Forms.Label lblNhapLaiMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.Label lblTenNhanVien;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.Label lblMaNhanVien;
    }
}
