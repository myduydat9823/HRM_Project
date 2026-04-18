namespace QuanLyNhanSu.KeToan.TinhLuong
{
    partial class frmLuongNhanVienKeToan
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
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnTinhLuong = new System.Windows.Forms.Button();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.cmbThang = new System.Windows.Forms.ComboBox();
            this.lblThang = new System.Windows.Forms.Label();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.groupBoxThongKe = new System.Windows.Forms.GroupBox();
            this.txtTongThucNhan = new System.Windows.Forms.TextBox();
            this.lblTongThucNhan = new System.Windows.Forms.Label();
            this.txtTongThuongPhat = new System.Windows.Forms.TextBox();
            this.lblTongThuongPhat = new System.Windows.Forms.Label();
            this.txtSoNhanVien = new System.Windows.Forms.TextBox();
            this.lblSoNhanVien = new System.Windows.Forms.Label();
            this.dataGridViewLuong = new System.Windows.Forms.DataGridView();
            this.groupBoxBoLoc.SuspendLayout();
            this.groupBoxThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1220, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "LƯƠNG NHÂN VIÊN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxBoLoc
            // 
            this.groupBoxBoLoc.Controls.Add(this.btnTaiLai);
            this.groupBoxBoLoc.Controls.Add(this.btnLoc);
            this.groupBoxBoLoc.Controls.Add(this.btnTinhLuong);
            this.groupBoxBoLoc.Controls.Add(this.cmbNam);
            this.groupBoxBoLoc.Controls.Add(this.lblNam);
            this.groupBoxBoLoc.Controls.Add(this.cmbThang);
            this.groupBoxBoLoc.Controls.Add(this.lblThang);
            this.groupBoxBoLoc.Controls.Add(this.cmbNhanVien);
            this.groupBoxBoLoc.Controls.Add(this.lblNhanVien);
            this.groupBoxBoLoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBoxBoLoc.Location = new System.Drawing.Point(25, 75);
            this.groupBoxBoLoc.Name = "groupBoxBoLoc";
            this.groupBoxBoLoc.Size = new System.Drawing.Size(1207, 95);
            this.groupBoxBoLoc.TabIndex = 1;
            this.groupBoxBoLoc.TabStop = false;
            this.groupBoxBoLoc.Text = "Bộ lọc và tính lương";
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTaiLai.Location = new System.Drawing.Point(1055, 35);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(120, 32);
            this.btnTaiLai.TabIndex = 8;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            // 
            // btnLoc
            // 
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLoc.Location = new System.Drawing.Point(915, 35);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(120, 32);
            this.btnLoc.TabIndex = 7;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            // 
            // btnTinhLuong
            // 
            this.btnTinhLuong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTinhLuong.Location = new System.Drawing.Point(755, 35);
            this.btnTinhLuong.Name = "btnTinhLuong";
            this.btnTinhLuong.Size = new System.Drawing.Size(140, 32);
            this.btnTinhLuong.TabIndex = 6;
            this.btnTinhLuong.Text = "Tính lương";
            this.btnTinhLuong.UseVisualStyleBackColor = true;
            // 
            // cmbNam
            // 
            this.cmbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(625, 38);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(100, 25);
            this.cmbNam.TabIndex = 5;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(580, 41);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(39, 19);
            this.lblNam.TabIndex = 4;
            this.lblNam.Text = "Năm";
            // 
            // cmbThang
            // 
            this.cmbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThang.FormattingEnabled = true;
            this.cmbThang.Location = new System.Drawing.Point(475, 38);
            this.cmbThang.Name = "cmbThang";
            this.cmbThang.Size = new System.Drawing.Size(85, 25);
            this.cmbThang.TabIndex = 3;
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Location = new System.Drawing.Point(420, 41);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(48, 19);
            this.lblThang.TabIndex = 2;
            this.lblThang.Text = "Tháng";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(115, 38);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(280, 25);
            this.cmbNhanVien.TabIndex = 1;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(25, 41);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(70, 19);
            this.lblNhanVien.TabIndex = 0;
            this.lblNhanVien.Text = "Nhân viên";
            // 
            // groupBoxThongKe
            // 
            this.groupBoxThongKe.Controls.Add(this.txtTongThucNhan);
            this.groupBoxThongKe.Controls.Add(this.lblTongThucNhan);
            this.groupBoxThongKe.Controls.Add(this.txtTongThuongPhat);
            this.groupBoxThongKe.Controls.Add(this.lblTongThuongPhat);
            this.groupBoxThongKe.Controls.Add(this.txtSoNhanVien);
            this.groupBoxThongKe.Controls.Add(this.lblSoNhanVien);
            this.groupBoxThongKe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBoxThongKe.Location = new System.Drawing.Point(25, 185);
            this.groupBoxThongKe.Name = "groupBoxThongKe";
            this.groupBoxThongKe.Size = new System.Drawing.Size(1207, 80);
            this.groupBoxThongKe.TabIndex = 2;
            this.groupBoxThongKe.TabStop = false;
            this.groupBoxThongKe.Text = "Thống kê";
            // 
            // txtTongThucNhan
            // 
            this.txtTongThucNhan.Location = new System.Drawing.Point(735, 32);
            this.txtTongThucNhan.Name = "txtTongThucNhan";
            this.txtTongThucNhan.ReadOnly = true;
            this.txtTongThucNhan.Size = new System.Drawing.Size(180, 25);
            this.txtTongThucNhan.TabIndex = 5;
            // 
            // lblTongThucNhan
            // 
            this.lblTongThucNhan.AutoSize = true;
            this.lblTongThucNhan.Location = new System.Drawing.Point(610, 35);
            this.lblTongThucNhan.Name = "lblTongThucNhan";
            this.lblTongThucNhan.Size = new System.Drawing.Size(104, 19);
            this.lblTongThucNhan.TabIndex = 4;
            this.lblTongThucNhan.Text = "Tổng thực nhận";
            // 
            // txtTongThuongPhat
            // 
            this.txtTongThuongPhat.Location = new System.Drawing.Point(405, 32);
            this.txtTongThuongPhat.Name = "txtTongThuongPhat";
            this.txtTongThuongPhat.ReadOnly = true;
            this.txtTongThuongPhat.Size = new System.Drawing.Size(160, 25);
            this.txtTongThuongPhat.TabIndex = 3;
            // 
            // lblTongThuongPhat
            // 
            this.lblTongThuongPhat.AutoSize = true;
            this.lblTongThuongPhat.Location = new System.Drawing.Point(260, 35);
            this.lblTongThuongPhat.Name = "lblTongThuongPhat";
            this.lblTongThuongPhat.Size = new System.Drawing.Size(121, 19);
            this.lblTongThuongPhat.TabIndex = 2;
            this.lblTongThuongPhat.Text = "Tổng thưởng/phạt";
            // 
            // txtSoNhanVien
            // 
            this.txtSoNhanVien.Location = new System.Drawing.Point(115, 32);
            this.txtSoNhanVien.Name = "txtSoNhanVien";
            this.txtSoNhanVien.ReadOnly = true;
            this.txtSoNhanVien.Size = new System.Drawing.Size(100, 25);
            this.txtSoNhanVien.TabIndex = 1;
            // 
            // lblSoNhanVien
            // 
            this.lblSoNhanVien.AutoSize = true;
            this.lblSoNhanVien.Location = new System.Drawing.Point(25, 35);
            this.lblSoNhanVien.Name = "lblSoNhanVien";
            this.lblSoNhanVien.Size = new System.Drawing.Size(86, 19);
            this.lblSoNhanVien.TabIndex = 0;
            this.lblSoNhanVien.Text = "Số nhân viên";
            // 
            // dataGridViewLuong
            // 
            this.dataGridViewLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLuong.Location = new System.Drawing.Point(25, 280);
            this.dataGridViewLuong.Name = "dataGridViewLuong";
            this.dataGridViewLuong.Size = new System.Drawing.Size(1207, 390);
            this.dataGridViewLuong.TabIndex = 3;
            // 
            // frmLuongNhanVienKeToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 701);
            this.Controls.Add(this.dataGridViewLuong);
            this.Controls.Add(this.groupBoxThongKe);
            this.Controls.Add(this.groupBoxBoLoc);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "frmLuongNhanVienKeToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lương nhân viên - Kế toán";
            this.groupBoxBoLoc.ResumeLayout(false);
            this.groupBoxBoLoc.PerformLayout();
            this.groupBoxThongKe.ResumeLayout(false);
            this.groupBoxThongKe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLuong)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBoxBoLoc;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnTinhLuong;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.ComboBox cmbThang;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.GroupBox groupBoxThongKe;
        private System.Windows.Forms.TextBox txtTongThucNhan;
        private System.Windows.Forms.Label lblTongThucNhan;
        private System.Windows.Forms.TextBox txtTongThuongPhat;
        private System.Windows.Forms.Label lblTongThuongPhat;
        private System.Windows.Forms.TextBox txtSoNhanVien;
        private System.Windows.Forms.Label lblSoNhanVien;
        private System.Windows.Forms.DataGridView dataGridViewLuong;
    }
}