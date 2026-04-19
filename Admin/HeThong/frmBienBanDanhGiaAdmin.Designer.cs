namespace QuanLyNhanSu.Admin.HeThong
{
    partial class frmBienBanDanhGiaAdmin
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
            this.groupBoxBoLoc = new System.Windows.Forms.GroupBox();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.groupBoxThongTin = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtNoiDungDanhGia = new System.Windows.Forms.TextBox();
            this.lblNoiDungDanhGia = new System.Windows.Forms.Label();
            this.txtTenPhongBan = new System.Windows.Forms.TextBox();
            this.lblTenPhongBan = new System.Windows.Forms.Label();
            this.txtTenChucVu = new System.Windows.Forms.TextBox();
            this.lblTenChucVu = new System.Windows.Forms.Label();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.lblMaNhanVien = new System.Windows.Forms.Label();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.txtMaBienBan = new System.Windows.Forms.TextBox();
            this.lblMaBienBan = new System.Windows.Forms.Label();
            this.groupBoxDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvBienBanDanhGia = new System.Windows.Forms.DataGridView();
            this.groupBoxBoLoc.SuspendLayout();
            this.groupBoxThongTin.SuspendLayout();
            this.groupBoxDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBienBanDanhGia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1050, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BIEN BAN DANH GIA NHAN VIEN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxBoLoc
            // 
            this.groupBoxBoLoc.Controls.Add(this.btnTaiLai);
            this.groupBoxBoLoc.Controls.Add(this.btnTimKiem);
            this.groupBoxBoLoc.Controls.Add(this.txtTimKiem);
            this.groupBoxBoLoc.Controls.Add(this.lblTimKiem);
            this.groupBoxBoLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBoxBoLoc.Location = new System.Drawing.Point(25, 65);
            this.groupBoxBoLoc.Name = "groupBoxBoLoc";
            this.groupBoxBoLoc.Size = new System.Drawing.Size(1028, 70);
            this.groupBoxBoLoc.TabIndex = 1;
            this.groupBoxBoLoc.TabStop = false;
            this.groupBoxBoLoc.Text = "Bo loc";
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnTaiLai.Location = new System.Drawing.Point(890, 26);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(110, 28);
            this.btnTaiLai.TabIndex = 3;
            this.btnTaiLai.Text = "Tai lai";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.Location = new System.Drawing.Point(760, 26);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(110, 28);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tim kiem";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(110, 29);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(620, 23);
            this.txtTimKiem.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(25, 32);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(64, 17);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tim kiem";
            // 
            // groupBoxThongTin
            // 
            this.groupBoxThongTin.Controls.Add(this.btnLamMoi);
            this.groupBoxThongTin.Controls.Add(this.btnXoa);
            this.groupBoxThongTin.Controls.Add(this.btnSua);
            this.groupBoxThongTin.Controls.Add(this.btnThem);
            this.groupBoxThongTin.Controls.Add(this.txtNoiDungDanhGia);
            this.groupBoxThongTin.Controls.Add(this.lblNoiDungDanhGia);
            this.groupBoxThongTin.Controls.Add(this.txtTenPhongBan);
            this.groupBoxThongTin.Controls.Add(this.lblTenPhongBan);
            this.groupBoxThongTin.Controls.Add(this.txtTenChucVu);
            this.groupBoxThongTin.Controls.Add(this.lblTenChucVu);
            this.groupBoxThongTin.Controls.Add(this.txtTenNhanVien);
            this.groupBoxThongTin.Controls.Add(this.lblTenNhanVien);
            this.groupBoxThongTin.Controls.Add(this.txtMaNhanVien);
            this.groupBoxThongTin.Controls.Add(this.lblMaNhanVien);
            this.groupBoxThongTin.Controls.Add(this.cmbNhanVien);
            this.groupBoxThongTin.Controls.Add(this.lblNhanVien);
            this.groupBoxThongTin.Controls.Add(this.dtpNgayLap);
            this.groupBoxThongTin.Controls.Add(this.lblNgayLap);
            this.groupBoxThongTin.Controls.Add(this.txtMaBienBan);
            this.groupBoxThongTin.Controls.Add(this.lblMaBienBan);
            this.groupBoxThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBoxThongTin.Location = new System.Drawing.Point(25, 150);
            this.groupBoxThongTin.Name = "groupBoxThongTin";
            this.groupBoxThongTin.Size = new System.Drawing.Size(400, 485);
            this.groupBoxThongTin.TabIndex = 2;
            this.groupBoxThongTin.TabStop = false;
            this.groupBoxThongTin.Text = "Thong tin bien ban";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.Location = new System.Drawing.Point(295, 430);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(80, 32);
            this.btnLamMoi.TabIndex = 19;
            this.btnLamMoi.Text = "Lam moi";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoa.Location = new System.Drawing.Point(205, 430);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 32);
            this.btnXoa.TabIndex = 18;
            this.btnXoa.Text = "Xoa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSua.Location = new System.Drawing.Point(115, 430);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 32);
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "Sua";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(25, 430);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 32);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Them";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // txtNoiDungDanhGia
            // 
            this.txtNoiDungDanhGia.Location = new System.Drawing.Point(130, 285);
            this.txtNoiDungDanhGia.Multiline = true;
            this.txtNoiDungDanhGia.Name = "txtNoiDungDanhGia";
            this.txtNoiDungDanhGia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNoiDungDanhGia.Size = new System.Drawing.Size(245, 125);
            this.txtNoiDungDanhGia.TabIndex = 15;
            // 
            // lblNoiDungDanhGia
            // 
            this.lblNoiDungDanhGia.AutoSize = true;
            this.lblNoiDungDanhGia.Location = new System.Drawing.Point(25, 288);
            this.lblNoiDungDanhGia.Name = "lblNoiDungDanhGia";
            this.lblNoiDungDanhGia.Size = new System.Drawing.Size(90, 17);
            this.lblNoiDungDanhGia.TabIndex = 14;
            this.lblNoiDungDanhGia.Text = "Noi dung DG";
            // 
            // txtTenPhongBan
            // 
            this.txtTenPhongBan.Location = new System.Drawing.Point(130, 240);
            this.txtTenPhongBan.Name = "txtTenPhongBan";
            this.txtTenPhongBan.ReadOnly = true;
            this.txtTenPhongBan.Size = new System.Drawing.Size(245, 23);
            this.txtTenPhongBan.TabIndex = 13;
            // 
            // lblTenPhongBan
            // 
            this.lblTenPhongBan.AutoSize = true;
            this.lblTenPhongBan.Location = new System.Drawing.Point(25, 243);
            this.lblTenPhongBan.Name = "lblTenPhongBan";
            this.lblTenPhongBan.Size = new System.Drawing.Size(77, 17);
            this.lblTenPhongBan.TabIndex = 12;
            this.lblTenPhongBan.Text = "Phong ban";
            // 
            // txtTenChucVu
            // 
            this.txtTenChucVu.Location = new System.Drawing.Point(130, 205);
            this.txtTenChucVu.Name = "txtTenChucVu";
            this.txtTenChucVu.ReadOnly = true;
            this.txtTenChucVu.Size = new System.Drawing.Size(245, 23);
            this.txtTenChucVu.TabIndex = 11;
            // 
            // lblTenChucVu
            // 
            this.lblTenChucVu.AutoSize = true;
            this.lblTenChucVu.Location = new System.Drawing.Point(25, 208);
            this.lblTenChucVu.Name = "lblTenChucVu";
            this.lblTenChucVu.Size = new System.Drawing.Size(59, 17);
            this.lblTenChucVu.TabIndex = 10;
            this.lblTenChucVu.Text = "Chuc vu";
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Location = new System.Drawing.Point(130, 170);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.ReadOnly = true;
            this.txtTenNhanVien.Size = new System.Drawing.Size(245, 23);
            this.txtTenNhanVien.TabIndex = 9;
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.AutoSize = true;
            this.lblTenNhanVien.Location = new System.Drawing.Point(25, 173);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(56, 17);
            this.lblTenNhanVien.TabIndex = 8;
            this.lblTenNhanVien.Text = "Ten NV";
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Location = new System.Drawing.Point(130, 135);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.ReadOnly = true;
            this.txtMaNhanVien.Size = new System.Drawing.Size(245, 23);
            this.txtMaNhanVien.TabIndex = 7;
            // 
            // lblMaNhanVien
            // 
            this.lblMaNhanVien.AutoSize = true;
            this.lblMaNhanVien.Location = new System.Drawing.Point(25, 138);
            this.lblMaNhanVien.Name = "lblMaNhanVien";
            this.lblMaNhanVien.Size = new System.Drawing.Size(50, 17);
            this.lblMaNhanVien.TabIndex = 6;
            this.lblMaNhanVien.Text = "Ma NV";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(130, 100);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(245, 24);
            this.cmbNhanVien.TabIndex = 5;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(25, 103);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(72, 17);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Nhan vien";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLap.Location = new System.Drawing.Point(130, 65);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(245, 23);
            this.dtpNgayLap.TabIndex = 3;
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Location = new System.Drawing.Point(25, 68);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(64, 17);
            this.lblNgayLap.TabIndex = 2;
            this.lblNgayLap.Text = "Ngay lap";
            // 
            // txtMaBienBan
            // 
            this.txtMaBienBan.Location = new System.Drawing.Point(130, 30);
            this.txtMaBienBan.Name = "txtMaBienBan";
            this.txtMaBienBan.ReadOnly = true;
            this.txtMaBienBan.Size = new System.Drawing.Size(245, 23);
            this.txtMaBienBan.TabIndex = 1;
            // 
            // lblMaBienBan
            // 
            this.lblMaBienBan.AutoSize = true;
            this.lblMaBienBan.Location = new System.Drawing.Point(25, 33);
            this.lblMaBienBan.Name = "lblMaBienBan";
            this.lblMaBienBan.Size = new System.Drawing.Size(86, 17);
            this.lblMaBienBan.TabIndex = 0;
            this.lblMaBienBan.Text = "Ma bien ban";
            // 
            // groupBoxDanhSach
            // 
            this.groupBoxDanhSach.Controls.Add(this.dgvBienBanDanhGia);
            this.groupBoxDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBoxDanhSach.Location = new System.Drawing.Point(445, 150);
            this.groupBoxDanhSach.Name = "groupBoxDanhSach";
            this.groupBoxDanhSach.Size = new System.Drawing.Size(608, 485);
            this.groupBoxDanhSach.TabIndex = 3;
            this.groupBoxDanhSach.TabStop = false;
            this.groupBoxDanhSach.Text = "Danh sach bien ban";
            // 
            // dgvBienBanDanhGia
            // 
            this.dgvBienBanDanhGia.AllowUserToAddRows = false;
            this.dgvBienBanDanhGia.AllowUserToDeleteRows = false;
            this.dgvBienBanDanhGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBienBanDanhGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBienBanDanhGia.Location = new System.Drawing.Point(20, 30);
            this.dgvBienBanDanhGia.MultiSelect = false;
            this.dgvBienBanDanhGia.Name = "dgvBienBanDanhGia";
            this.dgvBienBanDanhGia.ReadOnly = true;
            this.dgvBienBanDanhGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBienBanDanhGia.Size = new System.Drawing.Size(565, 432);
            this.dgvBienBanDanhGia.TabIndex = 0;
            // 
            // frmBienBanDanhGiaAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 660);
            this.Controls.Add(this.groupBoxDanhSach);
            this.Controls.Add(this.groupBoxThongTin);
            this.Controls.Add(this.groupBoxBoLoc);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmBienBanDanhGiaAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bien ban danh gia";
            this.groupBoxBoLoc.ResumeLayout(false);
            this.groupBoxBoLoc.PerformLayout();
            this.groupBoxThongTin.ResumeLayout(false);
            this.groupBoxThongTin.PerformLayout();
            this.groupBoxDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBienBanDanhGia)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBoxBoLoc;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.GroupBox groupBoxThongTin;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtNoiDungDanhGia;
        private System.Windows.Forms.Label lblNoiDungDanhGia;
        private System.Windows.Forms.TextBox txtTenPhongBan;
        private System.Windows.Forms.Label lblTenPhongBan;
        private System.Windows.Forms.TextBox txtTenChucVu;
        private System.Windows.Forms.Label lblTenChucVu;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.Label lblTenNhanVien;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.Label lblMaNhanVien;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.TextBox txtMaBienBan;
        private System.Windows.Forms.Label lblMaBienBan;
        private System.Windows.Forms.GroupBox groupBoxDanhSach;
        private System.Windows.Forms.DataGridView dgvBienBanDanhGia;
    }
}
