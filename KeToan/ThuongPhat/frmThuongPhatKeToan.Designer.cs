namespace QuanLyNhanSu.KeToan.ThuongPhat
{
    partial class frmThuongPhatKeToan
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
            this.groupBoxThongTin = new System.Windows.Forms.GroupBox();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtMucThuongPhat = new System.Windows.Forms.TextBox();
            this.lblMucThuongPhat = new System.Windows.Forms.Label();
            this.cmbLoaiQuyetDinh = new System.Windows.Forms.ComboBox();
            this.lblLoaiQuyetDinh = new System.Windows.Forms.Label();
            this.txtPhongBan = new System.Windows.Forms.TextBox();
            this.lblPhongBan = new System.Windows.Forms.Label();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.txtMaQuyetDinh = new System.Windows.Forms.TextBox();
            this.lblMaQuyetDinh = new System.Windows.Forms.Label();
            this.groupBoxBoLoc = new System.Windows.Forms.GroupBox();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.cmbThang = new System.Windows.Forms.ComboBox();
            this.lblThang = new System.Windows.Forms.Label();
            this.groupBoxChucNang = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dataGridViewThuongPhat = new System.Windows.Forms.DataGridView();
            this.groupBoxThongTin.SuspendLayout();
            this.groupBoxBoLoc.SuspendLayout();
            this.groupBoxChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewThuongPhat)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1160, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ KHEN THƯỞNG / KỶ LUẬT";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxThongTin
            // 
            this.groupBoxThongTin.Controls.Add(this.txtLyDo);
            this.groupBoxThongTin.Controls.Add(this.lblLyDo);
            this.groupBoxThongTin.Controls.Add(this.txtMucThuongPhat);
            this.groupBoxThongTin.Controls.Add(this.lblMucThuongPhat);
            this.groupBoxThongTin.Controls.Add(this.cmbLoaiQuyetDinh);
            this.groupBoxThongTin.Controls.Add(this.lblLoaiQuyetDinh);
            this.groupBoxThongTin.Controls.Add(this.txtPhongBan);
            this.groupBoxThongTin.Controls.Add(this.lblPhongBan);
            this.groupBoxThongTin.Controls.Add(this.txtChucVu);
            this.groupBoxThongTin.Controls.Add(this.lblChucVu);
            this.groupBoxThongTin.Controls.Add(this.cmbNhanVien);
            this.groupBoxThongTin.Controls.Add(this.lblNhanVien);
            this.groupBoxThongTin.Controls.Add(this.dtpNgayLap);
            this.groupBoxThongTin.Controls.Add(this.lblNgayLap);
            this.groupBoxThongTin.Controls.Add(this.txtMaQuyetDinh);
            this.groupBoxThongTin.Controls.Add(this.lblMaQuyetDinh);
            this.groupBoxThongTin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBoxThongTin.Location = new System.Drawing.Point(20, 75);
            this.groupBoxThongTin.Name = "groupBoxThongTin";
            this.groupBoxThongTin.Size = new System.Drawing.Size(760, 245);
            this.groupBoxThongTin.TabIndex = 1;
            this.groupBoxThongTin.TabStop = false;
            this.groupBoxThongTin.Text = "Thông tin quyết định";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLyDo.Location = new System.Drawing.Point(150, 175);
            this.txtLyDo.Multiline = true;
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(580, 55);
            this.txtLyDo.TabIndex = 15;
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLyDo.Location = new System.Drawing.Point(25, 178);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(42, 19);
            this.lblLyDo.TabIndex = 14;
            this.lblLyDo.Text = "Lý do";
            // 
            // txtMucThuongPhat
            // 
            this.txtMucThuongPhat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMucThuongPhat.Location = new System.Drawing.Point(520, 130);
            this.txtMucThuongPhat.Name = "txtMucThuongPhat";
            this.txtMucThuongPhat.Size = new System.Drawing.Size(210, 25);
            this.txtMucThuongPhat.TabIndex = 13;
            // 
            // lblMucThuongPhat
            // 
            this.lblMucThuongPhat.AutoSize = true;
            this.lblMucThuongPhat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMucThuongPhat.Location = new System.Drawing.Point(385, 133);
            this.lblMucThuongPhat.Name = "lblMucThuongPhat";
            this.lblMucThuongPhat.Size = new System.Drawing.Size(118, 19);
            this.lblMucThuongPhat.TabIndex = 12;
            this.lblMucThuongPhat.Text = "Mức thưởng/phạt";
            // 
            // cmbLoaiQuyetDinh
            // 
            this.cmbLoaiQuyetDinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoaiQuyetDinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbLoaiQuyetDinh.FormattingEnabled = true;
            this.cmbLoaiQuyetDinh.Location = new System.Drawing.Point(150, 130);
            this.cmbLoaiQuyetDinh.Name = "cmbLoaiQuyetDinh";
            this.cmbLoaiQuyetDinh.Size = new System.Drawing.Size(210, 25);
            this.cmbLoaiQuyetDinh.TabIndex = 11;
            // 
            // lblLoaiQuyetDinh
            // 
            this.lblLoaiQuyetDinh.AutoSize = true;
            this.lblLoaiQuyetDinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLoaiQuyetDinh.Location = new System.Drawing.Point(25, 133);
            this.lblLoaiQuyetDinh.Name = "lblLoaiQuyetDinh";
            this.lblLoaiQuyetDinh.Size = new System.Drawing.Size(104, 19);
            this.lblLoaiQuyetDinh.TabIndex = 10;
            this.lblLoaiQuyetDinh.Text = "Loại quyết định";
            // 
            // txtPhongBan
            // 
            this.txtPhongBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhongBan.Location = new System.Drawing.Point(520, 95);
            this.txtPhongBan.Name = "txtPhongBan";
            this.txtPhongBan.ReadOnly = true;
            this.txtPhongBan.Size = new System.Drawing.Size(210, 25);
            this.txtPhongBan.TabIndex = 9;
            // 
            // lblPhongBan
            // 
            this.lblPhongBan.AutoSize = true;
            this.lblPhongBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhongBan.Location = new System.Drawing.Point(385, 98);
            this.lblPhongBan.Name = "lblPhongBan";
            this.lblPhongBan.Size = new System.Drawing.Size(76, 19);
            this.lblPhongBan.TabIndex = 8;
            this.lblPhongBan.Text = "Phòng ban";
            // 
            // txtChucVu
            // 
            this.txtChucVu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtChucVu.Location = new System.Drawing.Point(150, 95);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.ReadOnly = true;
            this.txtChucVu.Size = new System.Drawing.Size(210, 25);
            this.txtChucVu.TabIndex = 7;
            // 
            // lblChucVu
            // 
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblChucVu.Location = new System.Drawing.Point(25, 98);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(59, 19);
            this.lblChucVu.TabIndex = 6;
            this.lblChucVu.Text = "Chức vụ";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(150, 60);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(580, 25);
            this.cmbNhanVien.TabIndex = 5;
            this.cmbNhanVien.SelectedIndexChanged += new System.EventHandler(this.cmbNhanVien_SelectedIndexChanged_1);
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNhanVien.Location = new System.Drawing.Point(25, 63);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(71, 19);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Nhân viên";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLap.Location = new System.Drawing.Point(520, 25);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(210, 25);
            this.dtpNgayLap.TabIndex = 3;
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgayLap.Location = new System.Drawing.Point(385, 29);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(63, 19);
            this.lblNgayLap.TabIndex = 2;
            this.lblNgayLap.Text = "Ngày lập";
            // 
            // txtMaQuyetDinh
            // 
            this.txtMaQuyetDinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaQuyetDinh.Location = new System.Drawing.Point(150, 25);
            this.txtMaQuyetDinh.Name = "txtMaQuyetDinh";
            this.txtMaQuyetDinh.ReadOnly = true;
            this.txtMaQuyetDinh.Size = new System.Drawing.Size(210, 25);
            this.txtMaQuyetDinh.TabIndex = 1;
            // 
            // lblMaQuyetDinh
            // 
            this.lblMaQuyetDinh.AutoSize = true;
            this.lblMaQuyetDinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaQuyetDinh.Location = new System.Drawing.Point(25, 29);
            this.lblMaQuyetDinh.Name = "lblMaQuyetDinh";
            this.lblMaQuyetDinh.Size = new System.Drawing.Size(99, 19);
            this.lblMaQuyetDinh.TabIndex = 0;
            this.lblMaQuyetDinh.Text = "Mã quyết định";
            // 
            // groupBoxBoLoc
            // 
            this.groupBoxBoLoc.Controls.Add(this.btnTaiLai);
            this.groupBoxBoLoc.Controls.Add(this.btnLoc);
            this.groupBoxBoLoc.Controls.Add(this.cmbNam);
            this.groupBoxBoLoc.Controls.Add(this.lblNam);
            this.groupBoxBoLoc.Controls.Add(this.cmbThang);
            this.groupBoxBoLoc.Controls.Add(this.lblThang);
            this.groupBoxBoLoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBoxBoLoc.Location = new System.Drawing.Point(800, 75);
            this.groupBoxBoLoc.Name = "groupBoxBoLoc";
            this.groupBoxBoLoc.Size = new System.Drawing.Size(372, 110);
            this.groupBoxBoLoc.TabIndex = 2;
            this.groupBoxBoLoc.TabStop = false;
            this.groupBoxBoLoc.Text = "Bộ lọc";
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTaiLai.Location = new System.Drawing.Point(195, 65);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(130, 30);
            this.btnTaiLai.TabIndex = 5;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            // 
            // btnLoc
            // 
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLoc.Location = new System.Drawing.Point(35, 65);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(130, 30);
            this.btnLoc.TabIndex = 4;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            // 
            // cmbNam
            // 
            this.cmbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(235, 25);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(90, 25);
            this.cmbNam.TabIndex = 3;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNam.Location = new System.Drawing.Point(190, 28);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(38, 19);
            this.lblNam.TabIndex = 2;
            this.lblNam.Text = "Năm";
            // 
            // cmbThang
            // 
            this.cmbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbThang.FormattingEnabled = true;
            this.cmbThang.Location = new System.Drawing.Point(80, 25);
            this.cmbThang.Name = "cmbThang";
            this.cmbThang.Size = new System.Drawing.Size(85, 25);
            this.cmbThang.TabIndex = 1;
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThang.Location = new System.Drawing.Point(30, 28);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(47, 19);
            this.lblThang.TabIndex = 0;
            this.lblThang.Text = "Tháng";
            // 
            // groupBoxChucNang
            // 
            this.groupBoxChucNang.Controls.Add(this.btnLamMoi);
            this.groupBoxChucNang.Controls.Add(this.btnXoa);
            this.groupBoxChucNang.Controls.Add(this.btnSua);
            this.groupBoxChucNang.Controls.Add(this.btnThem);
            this.groupBoxChucNang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBoxChucNang.Location = new System.Drawing.Point(800, 200);
            this.groupBoxChucNang.Name = "groupBoxChucNang";
            this.groupBoxChucNang.Size = new System.Drawing.Size(372, 120);
            this.groupBoxChucNang.TabIndex = 3;
            this.groupBoxChucNang.TabStop = false;
            this.groupBoxChucNang.Text = "Chức năng";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.Location = new System.Drawing.Point(195, 70);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(130, 32);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.Location = new System.Drawing.Point(35, 70);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(130, 32);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.Location = new System.Drawing.Point(195, 28);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(130, 32);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(35, 28);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 32);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // dataGridViewThuongPhat
            // 
            this.dataGridViewThuongPhat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewThuongPhat.Location = new System.Drawing.Point(20, 340);
            this.dataGridViewThuongPhat.Name = "dataGridViewThuongPhat";
            this.dataGridViewThuongPhat.Size = new System.Drawing.Size(1152, 330);
            this.dataGridViewThuongPhat.TabIndex = 4;
            this.dataGridViewThuongPhat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewThuongPhat_CellContentClick);
            // 
            // frmThuongPhatKeToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 690);
            this.Controls.Add(this.dataGridViewThuongPhat);
            this.Controls.Add(this.groupBoxChucNang);
            this.Controls.Add(this.groupBoxBoLoc);
            this.Controls.Add(this.groupBoxThongTin);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "frmThuongPhatKeToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý khen thưởng / kỷ luật";
            this.groupBoxThongTin.ResumeLayout(false);
            this.groupBoxThongTin.PerformLayout();
            this.groupBoxBoLoc.ResumeLayout(false);
            this.groupBoxBoLoc.PerformLayout();
            this.groupBoxChucNang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewThuongPhat)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBoxThongTin;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.TextBox txtMucThuongPhat;
        private System.Windows.Forms.Label lblMucThuongPhat;
        private System.Windows.Forms.ComboBox cmbLoaiQuyetDinh;
        private System.Windows.Forms.Label lblLoaiQuyetDinh;
        private System.Windows.Forms.TextBox txtPhongBan;
        private System.Windows.Forms.Label lblPhongBan;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.TextBox txtMaQuyetDinh;
        private System.Windows.Forms.Label lblMaQuyetDinh;
        private System.Windows.Forms.GroupBox groupBoxBoLoc;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.ComboBox cmbThang;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.GroupBox groupBoxChucNang;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dataGridViewThuongPhat;
    }
}