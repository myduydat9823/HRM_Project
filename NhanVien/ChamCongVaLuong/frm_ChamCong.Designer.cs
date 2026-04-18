namespace QuanLyNhanSu.NhanVien.ChamCongVaLuong
{
    partial class frm_ChamCong
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
            this.lblMaNhanVien = new System.Windows.Forms.Label();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.lblNgayHomNay = new System.Windows.Forms.Label();
            this.txtNgayHomNay = new System.Windows.Forms.TextBox();
            this.lblGioVao = new System.Windows.Forms.Label();
            this.txtGioVao = new System.Windows.Forms.TextBox();
            this.lblGioRa = new System.Windows.Forms.Label();
            this.txtGioRa = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.lblGhiChuMoc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(154, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(457, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CHẤM CÔNG NHÂN VIÊN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaNhanVien
            // 
            this.lblMaNhanVien.AutoSize = true;
            this.lblMaNhanVien.Location = new System.Drawing.Point(80, 110);
            this.lblMaNhanVien.Name = "lblMaNhanVien";
            this.lblMaNhanVien.Size = new System.Drawing.Size(72, 13);
            this.lblMaNhanVien.TabIndex = 1;
            this.lblMaNhanVien.Text = "Mã nhân viên";
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Location = new System.Drawing.Point(190, 107);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.ReadOnly = true;
            this.txtMaNhanVien.Size = new System.Drawing.Size(220, 20);
            this.txtMaNhanVien.TabIndex = 2;
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.AutoSize = true;
            this.lblTenNhanVien.Location = new System.Drawing.Point(80, 150);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(76, 13);
            this.lblTenNhanVien.TabIndex = 3;
            this.lblTenNhanVien.Text = "Tên nhân viên";
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Location = new System.Drawing.Point(190, 147);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.ReadOnly = true;
            this.txtTenNhanVien.Size = new System.Drawing.Size(480, 20);
            this.txtTenNhanVien.TabIndex = 4;
            // 
            // lblNgayHomNay
            // 
            this.lblNgayHomNay.AutoSize = true;
            this.lblNgayHomNay.Location = new System.Drawing.Point(80, 190);
            this.lblNgayHomNay.Name = "lblNgayHomNay";
            this.lblNgayHomNay.Size = new System.Drawing.Size(75, 13);
            this.lblNgayHomNay.TabIndex = 5;
            this.lblNgayHomNay.Text = "Ngày hôm nay";
            // 
            // txtNgayHomNay
            // 
            this.txtNgayHomNay.Location = new System.Drawing.Point(190, 187);
            this.txtNgayHomNay.Name = "txtNgayHomNay";
            this.txtNgayHomNay.ReadOnly = true;
            this.txtNgayHomNay.Size = new System.Drawing.Size(220, 20);
            this.txtNgayHomNay.TabIndex = 6;
            // 
            // lblGioVao
            // 
            this.lblGioVao.AutoSize = true;
            this.lblGioVao.Location = new System.Drawing.Point(80, 230);
            this.lblGioVao.Name = "lblGioVao";
            this.lblGioVao.Size = new System.Drawing.Size(44, 13);
            this.lblGioVao.TabIndex = 7;
            this.lblGioVao.Text = "Giờ vào";
            // 
            // txtGioVao
            // 
            this.txtGioVao.Location = new System.Drawing.Point(190, 227);
            this.txtGioVao.Name = "txtGioVao";
            this.txtGioVao.ReadOnly = true;
            this.txtGioVao.Size = new System.Drawing.Size(220, 20);
            this.txtGioVao.TabIndex = 8;
            // 
            // lblGioRa
            // 
            this.lblGioRa.AutoSize = true;
            this.lblGioRa.Location = new System.Drawing.Point(80, 270);
            this.lblGioRa.Name = "lblGioRa";
            this.lblGioRa.Size = new System.Drawing.Size(35, 13);
            this.lblGioRa.TabIndex = 9;
            this.lblGioRa.Text = "Giờ ra";
            // 
            // txtGioRa
            // 
            this.txtGioRa.Location = new System.Drawing.Point(190, 267);
            this.txtGioRa.Name = "txtGioRa";
            this.txtGioRa.ReadOnly = true;
            this.txtGioRa.Size = new System.Drawing.Size(220, 20);
            this.txtGioRa.TabIndex = 10;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(80, 310);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(55, 13);
            this.lblTrangThai.TabIndex = 11;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(190, 307);
            this.txtTrangThai.Multiline = true;
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.ReadOnly = true;
            this.txtTrangThai.Size = new System.Drawing.Size(480, 80);
            this.txtTrangThai.TabIndex = 12;
            this.txtTrangThai.TextChanged += new System.EventHandler(this.txtTrangThai_TextChanged);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheckIn.Location = new System.Drawing.Point(203, 425);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(160, 45);
            this.btnCheckIn.TabIndex = 13;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheckOut.Location = new System.Drawing.Point(411, 425);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(160, 45);
            this.btnCheckOut.TabIndex = 14;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            // 
            // lblGhiChuMoc
            // 
            this.lblGhiChuMoc.AutoSize = true;
            this.lblGhiChuMoc.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblGhiChuMoc.Location = new System.Drawing.Point(254, 489);
            this.lblGhiChuMoc.Name = "lblGhiChuMoc";
            this.lblGhiChuMoc.Size = new System.Drawing.Size(252, 13);
            this.lblGhiChuMoc.TabIndex = 15;
            this.lblGhiChuMoc.Text = "Mốc chuẩn: vào làm 08:00 - tan làm 17:00 mỗi ngày";
            this.lblGhiChuMoc.Click += new System.EventHandler(this.lblGhiChuMoc_Click);
            // 
            // frm_ChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.lblGhiChuMoc);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.txtTrangThai);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.txtGioRa);
            this.Controls.Add(this.lblGioRa);
            this.Controls.Add(this.txtGioVao);
            this.Controls.Add(this.lblGioVao);
            this.Controls.Add(this.txtNgayHomNay);
            this.Controls.Add(this.lblNgayHomNay);
            this.Controls.Add(this.txtTenNhanVien);
            this.Controls.Add(this.lblTenNhanVien);
            this.Controls.Add(this.txtMaNhanVien);
            this.Controls.Add(this.lblMaNhanVien);
            this.Controls.Add(this.lblTitle);
            this.Name = "frm_ChamCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chấm công nhân viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMaNhanVien;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.Label lblTenNhanVien;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.Label lblNgayHomNay;
        private System.Windows.Forms.TextBox txtNgayHomNay;
        private System.Windows.Forms.Label lblGioVao;
        private System.Windows.Forms.TextBox txtGioVao;
        private System.Windows.Forms.Label lblGioRa;
        private System.Windows.Forms.TextBox txtGioRa;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Label lblGhiChuMoc;
    }
}