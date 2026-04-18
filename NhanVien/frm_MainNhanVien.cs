using QuanLyNhanSu.NhanVien.ChamCongVaLuong;
using QuanLyNhanSu.NhanVien.DonNghiVaThongBao;
using QuanLyNhanSu.NhanVien.ThongTinNhanVien;
using System;
using System.Windows.Forms;

namespace QuanLyNhanSu.NhanVien
{
    public partial class frm_MainNhanVien : Form
    {
        private Form currentFormChild;

        public frm_MainNhanVien()
        {
            InitializeComponent();
        }

        private void frm_MainNhanVien_Load(object sender, EventArgs e)
        {
            lblHeader.Text = "Trang chủ";
         
        }

        private void OpenChildForm(Form childForm, string title)
        {
            try
            {
                if (currentFormChild != null)
                {
                    currentFormChild.Close();
                }

                currentFormChild = childForm;

                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;

                pnlContent.Controls.Clear();
                pnlContent.Controls.Add(childForm);
                pnlContent.Tag = childForm;

                lblHeader.Text = title;

                childForm.BringToFront();
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở màn hình: " + ex.Message);
            }
        }

        private void btnSoYeuLyLich_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_SoYeuLyLich(), "Quản lý nhân viên");
        }

        private void btnKeToan_Click(object sender, EventArgs e)
        {
            // Đổi frm_KeToan thành tên form kế toán thật của bạn
            OpenChildForm(new frm_SoYeuLyLich(), "Kế toán");
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            // Đổi frm_HeThong thành tên form hệ thống thật của bạn
            OpenChildForm(new frm_DanhSachNV(), "Hệ thống");
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pnlLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_ChamCong(), "Chi tiết lương");
        }

        private void btn_ChiTietChamCong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_ChiTietLuong(), "Chi tiết lương");
        }

        private void btn_NghiPhep_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDonNghiPhepNhanVien(), "Đơn nghỉ phép");
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongBaoNhanVien(), "Thông báo");
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmChiTietLuongNhanVien(), "Chi tiết lương");
        
        }
    }
}