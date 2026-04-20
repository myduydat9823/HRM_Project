namespace QuanLyNhanSu.KeToan
{
    partial class frm_MainKetoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnLuong = new System.Windows.Forms.Button();
            this.btnDuyetThuongPhat = new System.Windows.Forms.Button();
            this.btnThuongPhat = new System.Windows.Forms.Button();
            this.btnChiTietChamCong = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(220, 60);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1267, 544);
            this.pnlContent.TabIndex = 8;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTop.Controls.Add(this.lblHeader);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(220, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1267, 60);
            this.pnlTop.TabIndex = 7;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblHeader.Size = new System.Drawing.Size(1267, 60);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Trang chủ";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.pnlMenu.Controls.Add(this.btnDangXuat);
            this.pnlMenu.Controls.Add(this.btnLuong);
            this.pnlMenu.Controls.Add(this.btnDuyetThuongPhat);
            this.pnlMenu.Controls.Add(this.btnThuongPhat);
            this.pnlMenu.Controls.Add(this.btnChiTietChamCong);
            this.pnlMenu.Controls.Add(this.pnlLogo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(220, 604);
            this.pnlMenu.TabIndex = 6;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 544);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDangXuat.Size = new System.Drawing.Size(220, 60);
            this.btnDangXuat.TabIndex = 4;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.UseVisualStyleBackColor = true;
            // 
            // btnLuong
            // 
            this.btnLuong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLuong.FlatAppearance.BorderSize = 0;
            this.btnLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuong.ForeColor = System.Drawing.Color.White;
            this.btnLuong.Location = new System.Drawing.Point(0, 280);
            this.btnLuong.Name = "btnLuong";
            this.btnLuong.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLuong.Size = new System.Drawing.Size(220, 60);
            this.btnLuong.TabIndex = 3;
            this.btnLuong.Text = "Lương";
            this.btnLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuong.UseVisualStyleBackColor = true;
            this.btnLuong.Click += new System.EventHandler(this.btnLuong_Click);
            // 
            // btnDuyetThuongPhat
            // 
            this.btnDuyetThuongPhat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDuyetThuongPhat.FlatAppearance.BorderSize = 0;
            this.btnDuyetThuongPhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuyetThuongPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnDuyetThuongPhat.ForeColor = System.Drawing.Color.White;
            this.btnDuyetThuongPhat.Location = new System.Drawing.Point(0, 220);
            this.btnDuyetThuongPhat.Name = "btnDuyetThuongPhat";
            this.btnDuyetThuongPhat.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDuyetThuongPhat.Size = new System.Drawing.Size(220, 60);
            this.btnDuyetThuongPhat.TabIndex = 8;
            this.btnDuyetThuongPhat.Text = "Duyệt Thưởng Phạt";
            this.btnDuyetThuongPhat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDuyetThuongPhat.UseVisualStyleBackColor = true;
            this.btnDuyetThuongPhat.Click += new System.EventHandler(this.btnDuyetThuongPhat_Click);
            // 
            // btnThuongPhat
            // 
            this.btnThuongPhat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThuongPhat.FlatAppearance.BorderSize = 0;
            this.btnThuongPhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThuongPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnThuongPhat.ForeColor = System.Drawing.Color.White;
            this.btnThuongPhat.Location = new System.Drawing.Point(0, 160);
            this.btnThuongPhat.Name = "btnThuongPhat";
            this.btnThuongPhat.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThuongPhat.Size = new System.Drawing.Size(220, 60);
            this.btnThuongPhat.TabIndex = 2;
            this.btnThuongPhat.Text = "Thưởng Phạt";
            this.btnThuongPhat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThuongPhat.UseVisualStyleBackColor = true;
            this.btnThuongPhat.Click += new System.EventHandler(this.btnThuongPhat_Click);
            // 
            // btnChiTietChamCong
            // 
            this.btnChiTietChamCong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChiTietChamCong.FlatAppearance.BorderSize = 0;
            this.btnChiTietChamCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiTietChamCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnChiTietChamCong.ForeColor = System.Drawing.Color.White;
            this.btnChiTietChamCong.Location = new System.Drawing.Point(0, 100);
            this.btnChiTietChamCong.Name = "btnChiTietChamCong";
            this.btnChiTietChamCong.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnChiTietChamCong.Size = new System.Drawing.Size(220, 60);
            this.btnChiTietChamCong.TabIndex = 1;
            this.btnChiTietChamCong.Text = "Chấm Công Của Nhân Viên";
            this.btnChiTietChamCong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChiTietChamCong.UseVisualStyleBackColor = true;
            this.btnChiTietChamCong.Click += new System.EventHandler(this.btnChiTietChamCong_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.pnlLogo.Controls.Add(this.lblTitle);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(220, 100);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 100);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Kế Toán";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_MainKetoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1487, 604);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlMenu);
            this.Name = "frm_MainKetoan";
            this.Text = "frm_MainKetoan";
            this.pnlTop.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnLuong;
        private System.Windows.Forms.Button btnDuyetThuongPhat;
        private System.Windows.Forms.Button btnThuongPhat;
        private System.Windows.Forms.Button btnChiTietChamCong;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblTitle;
    }
}
