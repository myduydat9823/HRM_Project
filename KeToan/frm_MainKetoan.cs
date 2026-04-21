using QuanLyNhanSu.KeToan.ChiTietChamCong;
using QuanLyNhanSu.KeToan.ThuongPhat;
using QuanLyNhanSu.KeToan.TinhLuong;
using QuanLyNhanSu.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu.KeToan
{
    public partial class frm_MainKetoan : Form
    {
        private Form currentFormChild;

        public frm_MainKetoan()
        {
            InitializeComponent();
            this.Load += frm_MainKetoan_Load;
        }
        private void frm_MainKetoan_Load(object sender, EventArgs e)
        {
            lblHeader.Text = "Trang chủ";

            try
            {
                btnDuyetThuongPhat.Visible = KetoanPermissionHelper.GetCurrentRole().CanApproveRewardPenalty;
            }
            catch
            {
                btnDuyetThuongPhat.Visible = false;
            }
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

        private void btnChiTietChamCong_Click(object sender, EventArgs e)
        {
                    OpenChildForm(new frmXemChamCongKeToan(), "Chi Tiết Chấm Công");
        }

        private void btnThuongPhat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThuongPhatKeToan(), "Thưởng Phạt");

        }

        private void btnDuyetThuongPhat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDuyetThuongPhatKeToan(), "Duyệt Thưởng Phạt");
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLuongNhanVienKeToan(), "Lương");
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {

        }

        private void frm_MainKetoan_Load_1(object sender, EventArgs e)
        {

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
    }
}
