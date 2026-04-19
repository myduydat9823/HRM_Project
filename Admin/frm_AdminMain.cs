using QuanLyNhanSu.Admin.HeThong;
using QuanLyNhanSu.Admin.NghiPhep;
using System;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class frmMain : Form
    {
        private Form currentFormChild;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblHeader.Text = "Trang chủ";
            // Nếu muốn mở sẵn form nhân viên khi vào main thì bỏ comment dòng dưới
            // OpenChildForm(new frm_DanhSachNV(), "Quản lý nhân viên");
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

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_DanhSachNV(), "Quản lý nhân viên");
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
   
            OpenChildForm(new frmDuyetDonNghiPhep(), "Kế toán");
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            // Đổi frm_HeThong thành tên form hệ thống thật của bạn
            OpenChildForm(new frmCapTaiKhoan (), "Cấp tài khoản");
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
            OpenChildForm(new frmChamCongAdmin(), "Hệ thống");
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
    }
}