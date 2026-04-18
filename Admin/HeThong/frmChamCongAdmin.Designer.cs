namespace QuanLyNhanSu.Admin.HeThong   
{
    partial class frmChamCongAdmin
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
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.lblThang = new System.Windows.Forms.Label();
            this.cmbThang = new System.Windows.Forms.ComboBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.dataGridViewChamCong = new System.Windows.Forms.DataGridView();
            this.lblTongNgayChamCong = new System.Windows.Forms.Label();
            this.txtTongNgayChamCong = new System.Windows.Forms.TextBox();
            this.lblSoNgayDiMuon = new System.Windows.Forms.Label();
            this.txtSoNgayDiMuon = new System.Windows.Forms.TextBox();
            this.lblSoNgayVeSom = new System.Windows.Forms.Label();
            this.txtSoNgayVeSom = new System.Windows.Forms.TextBox();
            this.lblSoNgayNghiPhep = new System.Windows.Forms.Label();
            this.txtSoNgayNghiPhep = new System.Windows.Forms.TextBox();
            this.lblTongGioLam = new System.Windows.Forms.Label();
            this.txtTongGioLam = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChamCong)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(370, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CHẤM CÔNG NHÂN VIÊN - ADMIN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(30, 78);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(56, 13);
            this.lblNhanVien.TabIndex = 1;
            this.lblNhanVien.Text = "Nhân viên";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(105, 75);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(260, 21);
            this.cmbNhanVien.TabIndex = 2;
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Location = new System.Drawing.Point(390, 78);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(38, 13);
            this.lblThang.TabIndex = 3;
            this.lblThang.Text = "Tháng";
            // 
            // cmbThang
            // 
            this.cmbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThang.FormattingEnabled = true;
            this.cmbThang.Location = new System.Drawing.Point(445, 75);
            this.cmbThang.Name = "cmbThang";
            this.cmbThang.Size = new System.Drawing.Size(90, 21);
            this.cmbThang.TabIndex = 4;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(560, 78);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(29, 13);
            this.lblNam.TabIndex = 5;
            this.lblNam.Text = "Năm";
            // 
            // cmbNam
            // 
            this.cmbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(605, 75);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(90, 21);
            this.cmbNam.TabIndex = 6;
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(720, 72);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(85, 28);
            this.btnLoc.TabIndex = 7;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Location = new System.Drawing.Point(820, 72);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(85, 28);
            this.btnTaiLai.TabIndex = 8;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            // 
            // dataGridViewChamCong
            // 
            this.dataGridViewChamCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewChamCong.Location = new System.Drawing.Point(33, 120);
            this.dataGridViewChamCong.Name = "dataGridViewChamCong";
            this.dataGridViewChamCong.Size = new System.Drawing.Size(1180, 420);
            this.dataGridViewChamCong.TabIndex = 9;
            // 
            // lblTongNgayChamCong
            // 
            this.lblTongNgayChamCong.AutoSize = true;
            this.lblTongNgayChamCong.Location = new System.Drawing.Point(33, 565);
            this.lblTongNgayChamCong.Name = "lblTongNgayChamCong";
            this.lblTongNgayChamCong.Size = new System.Drawing.Size(107, 13);
            this.lblTongNgayChamCong.TabIndex = 10;
            this.lblTongNgayChamCong.Text = "Tổng ngày chấm công";
            // 
            // txtTongNgayChamCong
            // 
            this.txtTongNgayChamCong.Location = new System.Drawing.Point(155, 562);
            this.txtTongNgayChamCong.Name = "txtTongNgayChamCong";
            this.txtTongNgayChamCong.ReadOnly = true;
            this.txtTongNgayChamCong.Size = new System.Drawing.Size(120, 20);
            this.txtTongNgayChamCong.TabIndex = 11;
            // 
            // lblSoNgayDiMuon
            // 
            this.lblSoNgayDiMuon.AutoSize = true;
            this.lblSoNgayDiMuon.Location = new System.Drawing.Point(305, 565);
            this.lblSoNgayDiMuon.Name = "lblSoNgayDiMuon";
            this.lblSoNgayDiMuon.Size = new System.Drawing.Size(83, 13);
            this.lblSoNgayDiMuon.TabIndex = 12;
            this.lblSoNgayDiMuon.Text = "Số ngày đi muộn";
            // 
            // txtSoNgayDiMuon
            // 
            this.txtSoNgayDiMuon.Location = new System.Drawing.Point(405, 562);
            this.txtSoNgayDiMuon.Name = "txtSoNgayDiMuon";
            this.txtSoNgayDiMuon.ReadOnly = true;
            this.txtSoNgayDiMuon.Size = new System.Drawing.Size(120, 20);
            this.txtSoNgayDiMuon.TabIndex = 13;
            // 
            // lblSoNgayVeSom
            // 
            this.lblSoNgayVeSom.AutoSize = true;
            this.lblSoNgayVeSom.Location = new System.Drawing.Point(555, 565);
            this.lblSoNgayVeSom.Name = "lblSoNgayVeSom";
            this.lblSoNgayVeSom.Size = new System.Drawing.Size(81, 13);
            this.lblSoNgayVeSom.TabIndex = 14;
            this.lblSoNgayVeSom.Text = "Số ngày về sớm";
            // 
            // txtSoNgayVeSom
            // 
            this.txtSoNgayVeSom.Location = new System.Drawing.Point(655, 562);
            this.txtSoNgayVeSom.Name = "txtSoNgayVeSom";
            this.txtSoNgayVeSom.ReadOnly = true;
            this.txtSoNgayVeSom.Size = new System.Drawing.Size(120, 20);
            this.txtSoNgayVeSom.TabIndex = 15;
            // 
            // lblSoNgayNghiPhep
            // 
            this.lblSoNgayNghiPhep.AutoSize = true;
            this.lblSoNgayNghiPhep.Location = new System.Drawing.Point(805, 565);
            this.lblSoNgayNghiPhep.Name = "lblSoNgayNghiPhep";
            this.lblSoNgayNghiPhep.Size = new System.Drawing.Size(92, 13);
            this.lblSoNgayNghiPhep.TabIndex = 16;
            this.lblSoNgayNghiPhep.Text = "Số ngày nghỉ phép";
            // 
            // txtSoNgayNghiPhep
            // 
            this.txtSoNgayNghiPhep.Location = new System.Drawing.Point(915, 562);
            this.txtSoNgayNghiPhep.Name = "txtSoNgayNghiPhep";
            this.txtSoNgayNghiPhep.ReadOnly = true;
            this.txtSoNgayNghiPhep.Size = new System.Drawing.Size(120, 20);
            this.txtSoNgayNghiPhep.TabIndex = 17;
            // 
            // lblTongGioLam
            // 
            this.lblTongGioLam.AutoSize = true;
            this.lblTongGioLam.Location = new System.Drawing.Point(33, 600);
            this.lblTongGioLam.Name = "lblTongGioLam";
            this.lblTongGioLam.Size = new System.Drawing.Size(73, 13);
            this.lblTongGioLam.TabIndex = 18;
            this.lblTongGioLam.Text = "Tổng giờ làm";
            // 
            // txtTongGioLam
            // 
            this.txtTongGioLam.Location = new System.Drawing.Point(155, 597);
            this.txtTongGioLam.Name = "txtTongGioLam";
            this.txtTongGioLam.ReadOnly = true;
            this.txtTongGioLam.Size = new System.Drawing.Size(120, 20);
            this.txtTongGioLam.TabIndex = 19;
            // 
            // frmChamCongAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 650);
            this.Controls.Add(this.txtTongGioLam);
            this.Controls.Add(this.lblTongGioLam);
            this.Controls.Add(this.txtSoNgayNghiPhep);
            this.Controls.Add(this.lblSoNgayNghiPhep);
            this.Controls.Add(this.txtSoNgayVeSom);
            this.Controls.Add(this.lblSoNgayVeSom);
            this.Controls.Add(this.txtSoNgayDiMuon);
            this.Controls.Add(this.lblSoNgayDiMuon);
            this.Controls.Add(this.txtTongNgayChamCong);
            this.Controls.Add(this.lblTongNgayChamCong);
            this.Controls.Add(this.dataGridViewChamCong);
            this.Controls.Add(this.btnTaiLai);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.lblNam);
            this.Controls.Add(this.cmbThang);
            this.Controls.Add(this.lblThang);
            this.Controls.Add(this.cmbNhanVien);
            this.Controls.Add(this.lblNhanVien);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmChamCongAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chấm công nhân viên - Admin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChamCong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.ComboBox cmbThang;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.DataGridView dataGridViewChamCong;
        private System.Windows.Forms.Label lblTongNgayChamCong;
        private System.Windows.Forms.TextBox txtTongNgayChamCong;
        private System.Windows.Forms.Label lblSoNgayDiMuon;
        private System.Windows.Forms.TextBox txtSoNgayDiMuon;
        private System.Windows.Forms.Label lblSoNgayVeSom;
        private System.Windows.Forms.TextBox txtSoNgayVeSom;
        private System.Windows.Forms.Label lblSoNgayNghiPhep;
        private System.Windows.Forms.TextBox txtSoNgayNghiPhep;
        private System.Windows.Forms.Label lblTongGioLam;
        private System.Windows.Forms.TextBox txtTongGioLam;
    }
}