namespace QuanLyNhanSu.KeToan.ThuongPhat
{
    partial class frmDuyetThuongPhatKeToan
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
            this.groupBoxDanhSach = new System.Windows.Forms.GroupBox();
            this.dataGridViewChoDuyet = new System.Windows.Forms.DataGridView();
            this.groupBoxChiTiet = new System.Windows.Forms.GroupBox();
            this.txtGhiChuDuyet = new System.Windows.Forms.TextBox();
            this.lblGhiChuDuyet = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtNguoiTao = new System.Windows.Forms.TextBox();
            this.lblNguoiTao = new System.Windows.Forms.Label();
            this.txtMucThuongPhat = new System.Windows.Forms.TextBox();
            this.lblMucThuongPhat = new System.Windows.Forms.Label();
            this.txtPhongBan = new System.Windows.Forms.TextBox();
            this.lblPhongBan = new System.Windows.Forms.Label();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.txtLoaiQuyetDinh = new System.Windows.Forms.TextBox();
            this.lblLoaiQuyetDinh = new System.Windows.Forms.Label();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.txtNgayLap = new System.Windows.Forms.TextBox();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.txtMaQuyetDinh = new System.Windows.Forms.TextBox();
            this.lblMaQuyetDinh = new System.Windows.Forms.Label();
            this.groupBoxChucNang = new System.Windows.Forms.GroupBox();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.btnTuChoi = new System.Windows.Forms.Button();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.groupBoxDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChoDuyet)).BeginInit();
            this.groupBoxChiTiet.SuspendLayout();
            this.groupBoxChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1160, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DUYỆT KHEN THƯỞNG / KỶ LUẬT";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxDanhSach
            // 
            this.groupBoxDanhSach.Controls.Add(this.dataGridViewChoDuyet);
            this.groupBoxDanhSach.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBoxDanhSach.Location = new System.Drawing.Point(20, 75);
            this.groupBoxDanhSach.Name = "groupBoxDanhSach";
            this.groupBoxDanhSach.Size = new System.Drawing.Size(1152, 285);
            this.groupBoxDanhSach.TabIndex = 1;
            this.groupBoxDanhSach.TabStop = false;
            this.groupBoxDanhSach.Text = "Danh sách yêu cầu chờ duyệt";
            // 
            // dataGridViewChoDuyet
            // 
            this.dataGridViewChoDuyet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewChoDuyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewChoDuyet.Location = new System.Drawing.Point(3, 21);
            this.dataGridViewChoDuyet.Name = "dataGridViewChoDuyet";
            this.dataGridViewChoDuyet.Size = new System.Drawing.Size(1146, 261);
            this.dataGridViewChoDuyet.TabIndex = 0;
            // 
            // groupBoxChiTiet
            // 
            this.groupBoxChiTiet.Controls.Add(this.txtGhiChuDuyet);
            this.groupBoxChiTiet.Controls.Add(this.lblGhiChuDuyet);
            this.groupBoxChiTiet.Controls.Add(this.txtLyDo);
            this.groupBoxChiTiet.Controls.Add(this.lblLyDo);
            this.groupBoxChiTiet.Controls.Add(this.txtNguoiTao);
            this.groupBoxChiTiet.Controls.Add(this.lblNguoiTao);
            this.groupBoxChiTiet.Controls.Add(this.txtMucThuongPhat);
            this.groupBoxChiTiet.Controls.Add(this.lblMucThuongPhat);
            this.groupBoxChiTiet.Controls.Add(this.txtPhongBan);
            this.groupBoxChiTiet.Controls.Add(this.lblPhongBan);
            this.groupBoxChiTiet.Controls.Add(this.txtChucVu);
            this.groupBoxChiTiet.Controls.Add(this.lblChucVu);
            this.groupBoxChiTiet.Controls.Add(this.txtLoaiQuyetDinh);
            this.groupBoxChiTiet.Controls.Add(this.lblLoaiQuyetDinh);
            this.groupBoxChiTiet.Controls.Add(this.txtNhanVien);
            this.groupBoxChiTiet.Controls.Add(this.lblNhanVien);
            this.groupBoxChiTiet.Controls.Add(this.txtNgayLap);
            this.groupBoxChiTiet.Controls.Add(this.lblNgayLap);
            this.groupBoxChiTiet.Controls.Add(this.txtMaQuyetDinh);
            this.groupBoxChiTiet.Controls.Add(this.lblMaQuyetDinh);
            this.groupBoxChiTiet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBoxChiTiet.Location = new System.Drawing.Point(20, 375);
            this.groupBoxChiTiet.Name = "groupBoxChiTiet";
            this.groupBoxChiTiet.Size = new System.Drawing.Size(800, 290);
            this.groupBoxChiTiet.TabIndex = 2;
            this.groupBoxChiTiet.TabStop = false;
            this.groupBoxChiTiet.Text = "Chi tiết yêu cầu";
            // 
            // txtGhiChuDuyet
            // 
            this.txtGhiChuDuyet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGhiChuDuyet.Location = new System.Drawing.Point(150, 235);
            this.txtGhiChuDuyet.Multiline = true;
            this.txtGhiChuDuyet.Name = "txtGhiChuDuyet";
            this.txtGhiChuDuyet.Size = new System.Drawing.Size(610, 40);
            this.txtGhiChuDuyet.TabIndex = 19;
            // 
            // lblGhiChuDuyet
            // 
            this.lblGhiChuDuyet.AutoSize = true;
            this.lblGhiChuDuyet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGhiChuDuyet.Location = new System.Drawing.Point(25, 238);
            this.lblGhiChuDuyet.Name = "lblGhiChuDuyet";
            this.lblGhiChuDuyet.Size = new System.Drawing.Size(98, 19);
            this.lblGhiChuDuyet.TabIndex = 18;
            this.lblGhiChuDuyet.Text = "Ghi chú duyệt";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLyDo.Location = new System.Drawing.Point(150, 180);
            this.txtLyDo.Multiline = true;
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.ReadOnly = true;
            this.txtLyDo.Size = new System.Drawing.Size(610, 45);
            this.txtLyDo.TabIndex = 17;
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLyDo.Location = new System.Drawing.Point(25, 183);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(42, 19);
            this.lblLyDo.TabIndex = 16;
            this.lblLyDo.Text = "Lý do";
            // 
            // txtNguoiTao
            // 
            this.txtNguoiTao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNguoiTao.Location = new System.Drawing.Point(550, 140);
            this.txtNguoiTao.Name = "txtNguoiTao";
            this.txtNguoiTao.ReadOnly = true;
            this.txtNguoiTao.Size = new System.Drawing.Size(210, 25);
            this.txtNguoiTao.TabIndex = 15;
            // 
            // lblNguoiTao
            // 
            this.lblNguoiTao.AutoSize = true;
            this.lblNguoiTao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNguoiTao.Location = new System.Drawing.Point(420, 143);
            this.lblNguoiTao.Name = "lblNguoiTao";
            this.lblNguoiTao.Size = new System.Drawing.Size(71, 19);
            this.lblNguoiTao.TabIndex = 14;
            this.lblNguoiTao.Text = "Người tạo";
            // 
            // txtMucThuongPhat
            // 
            this.txtMucThuongPhat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMucThuongPhat.Location = new System.Drawing.Point(150, 140);
            this.txtMucThuongPhat.Name = "txtMucThuongPhat";
            this.txtMucThuongPhat.ReadOnly = true;
            this.txtMucThuongPhat.Size = new System.Drawing.Size(230, 25);
            this.txtMucThuongPhat.TabIndex = 13;
            // 
            // lblMucThuongPhat
            // 
            this.lblMucThuongPhat.AutoSize = true;
            this.lblMucThuongPhat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMucThuongPhat.Location = new System.Drawing.Point(25, 143);
            this.lblMucThuongPhat.Name = "lblMucThuongPhat";
            this.lblMucThuongPhat.Size = new System.Drawing.Size(118, 19);
            this.lblMucThuongPhat.TabIndex = 12;
            this.lblMucThuongPhat.Text = "Mức thưởng/phạt";
            // 
            // txtPhongBan
            // 
            this.txtPhongBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhongBan.Location = new System.Drawing.Point(550, 105);
            this.txtPhongBan.Name = "txtPhongBan";
            this.txtPhongBan.ReadOnly = true;
            this.txtPhongBan.Size = new System.Drawing.Size(210, 25);
            this.txtPhongBan.TabIndex = 11;
            // 
            // lblPhongBan
            // 
            this.lblPhongBan.AutoSize = true;
            this.lblPhongBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhongBan.Location = new System.Drawing.Point(420, 108);
            this.lblPhongBan.Name = "lblPhongBan";
            this.lblPhongBan.Size = new System.Drawing.Size(76, 19);
            this.lblPhongBan.TabIndex = 10;
            this.lblPhongBan.Text = "Phòng ban";
            // 
            // txtChucVu
            // 
            this.txtChucVu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtChucVu.Location = new System.Drawing.Point(150, 105);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.ReadOnly = true;
            this.txtChucVu.Size = new System.Drawing.Size(230, 25);
            this.txtChucVu.TabIndex = 9;
            // 
            // lblChucVu
            // 
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblChucVu.Location = new System.Drawing.Point(25, 108);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(59, 19);
            this.lblChucVu.TabIndex = 8;
            this.lblChucVu.Text = "Chức vụ";
            // 
            // txtLoaiQuyetDinh
            // 
            this.txtLoaiQuyetDinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLoaiQuyetDinh.Location = new System.Drawing.Point(550, 70);
            this.txtLoaiQuyetDinh.Name = "txtLoaiQuyetDinh";
            this.txtLoaiQuyetDinh.ReadOnly = true;
            this.txtLoaiQuyetDinh.Size = new System.Drawing.Size(210, 25);
            this.txtLoaiQuyetDinh.TabIndex = 7;
            // 
            // lblLoaiQuyetDinh
            // 
            this.lblLoaiQuyetDinh.AutoSize = true;
            this.lblLoaiQuyetDinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLoaiQuyetDinh.Location = new System.Drawing.Point(420, 73);
            this.lblLoaiQuyetDinh.Name = "lblLoaiQuyetDinh";
            this.lblLoaiQuyetDinh.Size = new System.Drawing.Size(104, 19);
            this.lblLoaiQuyetDinh.TabIndex = 6;
            this.lblLoaiQuyetDinh.Text = "Loại quyết định";
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNhanVien.Location = new System.Drawing.Point(150, 70);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.ReadOnly = true;
            this.txtNhanVien.Size = new System.Drawing.Size(230, 25);
            this.txtNhanVien.TabIndex = 5;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNhanVien.Location = new System.Drawing.Point(25, 73);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(71, 19);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Nhân viên";
            // 
            // txtNgayLap
            // 
            this.txtNgayLap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNgayLap.Location = new System.Drawing.Point(550, 35);
            this.txtNgayLap.Name = "txtNgayLap";
            this.txtNgayLap.ReadOnly = true;
            this.txtNgayLap.Size = new System.Drawing.Size(210, 25);
            this.txtNgayLap.TabIndex = 3;
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgayLap.Location = new System.Drawing.Point(420, 38);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(63, 19);
            this.lblNgayLap.TabIndex = 2;
            this.lblNgayLap.Text = "Ngày lập";
            // 
            // txtMaQuyetDinh
            // 
            this.txtMaQuyetDinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaQuyetDinh.Location = new System.Drawing.Point(150, 35);
            this.txtMaQuyetDinh.Name = "txtMaQuyetDinh";
            this.txtMaQuyetDinh.ReadOnly = true;
            this.txtMaQuyetDinh.Size = new System.Drawing.Size(230, 25);
            this.txtMaQuyetDinh.TabIndex = 1;
            // 
            // lblMaQuyetDinh
            // 
            this.lblMaQuyetDinh.AutoSize = true;
            this.lblMaQuyetDinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaQuyetDinh.Location = new System.Drawing.Point(25, 38);
            this.lblMaQuyetDinh.Name = "lblMaQuyetDinh";
            this.lblMaQuyetDinh.Size = new System.Drawing.Size(99, 19);
            this.lblMaQuyetDinh.TabIndex = 0;
            this.lblMaQuyetDinh.Text = "Mã quyết định";
            // 
            // groupBoxChucNang
            // 
            this.groupBoxChucNang.Controls.Add(this.btnTaiLai);
            this.groupBoxChucNang.Controls.Add(this.btnTuChoi);
            this.groupBoxChucNang.Controls.Add(this.btnDuyet);
            this.groupBoxChucNang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBoxChucNang.Location = new System.Drawing.Point(845, 375);
            this.groupBoxChucNang.Name = "groupBoxChucNang";
            this.groupBoxChucNang.Size = new System.Drawing.Size(327, 160);
            this.groupBoxChucNang.TabIndex = 3;
            this.groupBoxChucNang.TabStop = false;
            this.groupBoxChucNang.Text = "Chức năng";
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTaiLai.Location = new System.Drawing.Point(35, 110);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(260, 32);
            this.btnTaiLai.TabIndex = 2;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTuChoi.Location = new System.Drawing.Point(35, 70);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(260, 32);
            this.btnTuChoi.TabIndex = 1;
            this.btnTuChoi.Text = "Từ chối";
            this.btnTuChoi.UseVisualStyleBackColor = true;
            // 
            // btnDuyet
            // 
            this.btnDuyet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDuyet.Location = new System.Drawing.Point(35, 30);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(260, 32);
            this.btnDuyet.TabIndex = 0;
            this.btnDuyet.Text = "Duyệt";
            this.btnDuyet.UseVisualStyleBackColor = true;
            // 
            // frmDuyetThuongPhatKeToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1190, 690);
            this.Controls.Add(this.groupBoxChucNang);
            this.Controls.Add(this.groupBoxChiTiet);
            this.Controls.Add(this.groupBoxDanhSach);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "frmDuyetThuongPhatKeToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duyệt khen thưởng / kỷ luật";
            this.groupBoxDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChoDuyet)).EndInit();
            this.groupBoxChiTiet.ResumeLayout(false);
            this.groupBoxChiTiet.PerformLayout();
            this.groupBoxChucNang.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBoxDanhSach;
        private System.Windows.Forms.DataGridView dataGridViewChoDuyet;
        private System.Windows.Forms.GroupBox groupBoxChiTiet;
        private System.Windows.Forms.TextBox txtGhiChuDuyet;
        private System.Windows.Forms.Label lblGhiChuDuyet;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.TextBox txtNguoiTao;
        private System.Windows.Forms.Label lblNguoiTao;
        private System.Windows.Forms.TextBox txtMucThuongPhat;
        private System.Windows.Forms.Label lblMucThuongPhat;
        private System.Windows.Forms.TextBox txtPhongBan;
        private System.Windows.Forms.Label lblPhongBan;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.TextBox txtLoaiQuyetDinh;
        private System.Windows.Forms.Label lblLoaiQuyetDinh;
        private System.Windows.Forms.TextBox txtNhanVien;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.TextBox txtNgayLap;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.TextBox txtMaQuyetDinh;
        private System.Windows.Forms.Label lblMaQuyetDinh;
        private System.Windows.Forms.GroupBox groupBoxChucNang;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Button btnTuChoi;
        private System.Windows.Forms.Button btnDuyet;
    }
}
