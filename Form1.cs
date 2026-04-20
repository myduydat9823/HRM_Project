using QuanLyNhanSu.KeToan;
using QuanLyNhanSu.NhanVien;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhanSu.Common;
using QuanLyNhanSu.BLL;
using QuanLyNhanSu.DTO;

using static System.Collections.Specialized.BitVector32;


namespace QuanLyNhanSu
{
    public partial class Form1 : Form

    {
        private readonly AuthBLL authBLL = new AuthBLL();


        public Form1()
        {
            InitializeComponent();
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                LoginResultDto result = authBLL.Login(txtTenDangNhap.Text, txtMatKhau.Text);

                if (!result.Success)
                {
                    MessageBox.Show(result.Message);

                    if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
                        txtTenDangNhap.Focus();
                    else
                        txtMatKhau.Focus();

                    return;
                }

                session.MaNhanVien = result.User.MaNhanVien;
                session.TaiKhoan = result.User.TaiKhoan;
                session.MaQuyen = result.User.MaQuyen;
                session.TenQuyen = result.User.TenQuyen;

                OpenFormByPermission(session.MaQuyen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
        }


        private void OpenFormByPermission(int maQuyen)
        {
            Form frm = null;

            switch (maQuyen)
            {
                case 1:
                    frm = new frmMain();
                    break;
                case 2:
                    frm = new frm_MainNhanVien();
                    break;
                case 3:
                    frm = new frm_MainKetoan();
                    break;
                case 4:
                    frm = new frm_MainNhanVien();
                    break;
                default:
                    MessageBox.Show("Quyền không hợp lệ.");
                    return;
            }

            frm.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            using (frmDoiMatKhau frm = new frmDoiMatKhau())
            {
                frm.ShowDialog(this);
            }
        }
    }
}
