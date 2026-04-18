namespace QuanLyNhanSu.KeToan.ChiTietChamCong

{
    partial class frmXemChamCongKeToan
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
            this.lblTongNgay = new System.Windows.Forms.Label();
            this.txtTongNgay = new System.Windows.Forms.TextBox();
            this.lblTongGio = new System.Windows.Forms.Label();
            this.txtTongGio = new System.Windows.Forms.TextBox();
            this.lblDiMuon = new System.Windows.Forms.Label();
            this.txtDiMuon = new System.Windows.Forms.TextBox();
            this.lblVeSom = new System.Windows.Forms.Label();
            this.txtVeSom = new System.Windows.Forms.TextBox();
            this.lblNghiPhep = new System.Windows.Forms.Label();
            this.txtNghiPhep = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChamCong)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(360, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(460, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "XEM CHẤM CÔNG NHÂN VIÊN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(35, 85);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(56, 13);
            this.lblNhanVien.TabIndex = 1;
            this.lblNhanVien.Text = "Nhân viên";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(115, 82);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(280, 21);
            this.cmbNhanVien.TabIndex = 2;
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Location = new System.Drawing.Point(430, 85);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(38, 13);
            this.lblThang.TabIndex = 3;
            this.lblThang.Text = "Tháng";
            // 
            // cmbThang
            // 
            this.cmbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThang.FormattingEnabled = true;
            this.cmbThang.Location = new System.Drawing.Point(485, 82);
            this.cmbThang.Name = "cmbThang";
            this.cmbThang.Size = new System.Drawing.Size(90, 21);
            this.cmbThang.TabIndex = 4;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(610, 85);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(29, 13);
            this.lblNam.TabIndex = 5;
            this.lblNam.Text = "Năm";
            // 
            // cmbNam
            // 
            this.cmbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(655, 82);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(100, 21);
            this.cmbNam.TabIndex = 6;
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(785, 78);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(90, 30);
            this.btnLoc.TabIndex = 7;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Location = new System.Drawing.Point(895, 78);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(90, 30);
            this.btnTaiLai.TabIndex = 8;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            // 
            // dataGridViewChamCong
            // 
            this.dataGridViewChamCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewChamCong.Location = new System.Drawing.Point(38, 130);
            this.dataGridViewChamCong.Name = "dataGridViewChamCong";
            this.dataGridViewChamCong.Size = new System.Drawing.Size(1185, 430);
            this.dataGridViewChamCong.TabIndex = 9;
            // 
            // lblTongNgay
            // 
            this.lblTongNgay.AutoSize = true;
            this.lblTongNgay.Location = new System.Drawing.Point(38, 590);
            this.lblTongNgay.Name = "lblTongNgay";
            this.lblTongNgay.Size = new System.Drawing.Size(104, 13);
            this.lblTongNgay.TabIndex = 10;
            this.lblTongNgay.Text = "Tổng ngày có công";
            // 
            // txtTongNgay
            // 
            this.txtTongNgay.Location = new System.Drawing.Point(160, 587);
            this.txtTongNgay.Name = "txtTongNgay";
            this.txtTongNgay.ReadOnly = true;
            this.txtTongNgay.Size = new System.Drawing.Size(100, 20);
            this.txtTongNgay.TabIndex = 11;
            // 
            // lblTongGio
            // 
            this.lblTongGio.AutoSize = true;
            this.lblTongGio.Location = new System.Drawing.Point(295, 590);
            this.lblTongGio.Name = "lblTongGio";
            this.lblTongGio.Size = new System.Drawing.Size(73, 13);
            this.lblTongGio.TabIndex = 12;
            this.lblTongGio.Text = "Tổng giờ làm";
            // 
            // txtTongGio
            // 
            this.txtTongGio.Location = new System.Drawing.Point(385, 587);
            this.txtTongGio.Name = "txtTongGio";
            this.txtTongGio.ReadOnly = true;
            this.txtTongGio.Size = new System.Drawing.Size(100, 20);
            this.txtTongGio.TabIndex = 13;
            // 
            // lblDiMuon
            // 
            this.lblDiMuon.AutoSize = true;
            this.lblDiMuon.Location = new System.Drawing.Point(520, 590);
            this.lblDiMuon.Name = "lblDiMuon";
            this.lblDiMuon.Size = new System.Drawing.Size(83, 13);
            this.lblDiMuon.TabIndex = 14;
            this.lblDiMuon.Text = "Số ngày đi muộn";
            // 
            // txtDiMuon
            // 
            this.txtDiMuon.Location = new System.Drawing.Point(620, 587);
            this.txtDiMuon.Name = "txtDiMuon";
            this.txtDiMuon.ReadOnly = true;
            this.txtDiMuon.Size = new System.Drawing.Size(100, 20);
            this.txtDiMuon.TabIndex = 15;
            // 
            // lblVeSom
            // 
            this.lblVeSom.AutoSize = true;
            this.lblVeSom.Location = new System.Drawing.Point(755, 590);
            this.lblVeSom.Name = "lblVeSom";
            this.lblVeSom.Size = new System.Drawing.Size(81, 13);
            this.lblVeSom.TabIndex = 16;
            this.lblVeSom.Text = "Số ngày về sớm";
            // 
            // txtVeSom
            // 
            this.txtVeSom.Location = new System.Drawing.Point(855, 587);
            this.txtVeSom.Name = "txtVeSom";
            this.txtVeSom.ReadOnly = true;
            this.txtVeSom.Size = new System.Drawing.Size(100, 20);
            this.txtVeSom.TabIndex = 17;
            // 
            // lblNghiPhep
            // 
            this.lblNghiPhep.AutoSize = true;
            this.lblNghiPhep.Location = new System.Drawing.Point(990, 590);
            this.lblNghiPhep.Name = "lblNghiPhep";
            this.lblNghiPhep.Size = new System.Drawing.Size(92, 13);
            this.lblNghiPhep.TabIndex = 18;
            this.lblNghiPhep.Text = "Số ngày nghỉ phép";
            // 
            // txtNghiPhep
            // 
            this.txtNghiPhep.Location = new System.Drawing.Point(1100, 587);
            this.txtNghiPhep.Name = "txtNghiPhep";
            this.txtNghiPhep.ReadOnly = true;
            this.txtNghiPhep.Size = new System.Drawing.Size(100, 20);
            this.txtNghiPhep.TabIndex = 19;
            // 
            // frmXemChamCongKeToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 651);
            this.Controls.Add(this.txtNghiPhep);
            this.Controls.Add(this.lblNghiPhep);
            this.Controls.Add(this.txtVeSom);
            this.Controls.Add(this.lblVeSom);
            this.Controls.Add(this.txtDiMuon);
            this.Controls.Add(this.lblDiMuon);
            this.Controls.Add(this.txtTongGio);
            this.Controls.Add(this.lblTongGio);
            this.Controls.Add(this.txtTongNgay);
            this.Controls.Add(this.lblTongNgay);
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
            this.Name = "frmXemChamCongKeToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem chấm công - Kế toán";
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
        private System.Windows.Forms.Label lblTongNgay;
        private System.Windows.Forms.TextBox txtTongNgay;
        private System.Windows.Forms.Label lblTongGio;
        private System.Windows.Forms.TextBox txtTongGio;
        private System.Windows.Forms.Label lblDiMuon;
        private System.Windows.Forms.TextBox txtDiMuon;
        private System.Windows.Forms.Label lblVeSom;
        private System.Windows.Forms.TextBox txtVeSom;
        private System.Windows.Forms.Label lblNghiPhep;
        private System.Windows.Forms.TextBox txtNghiPhep;
    }
}