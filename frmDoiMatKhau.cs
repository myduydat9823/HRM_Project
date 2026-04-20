using QuanLyNhanSu.BLL;
using QuanLyNhanSu.DTO;
using System;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class frmDoiMatKhau : Form
    {
        private readonly TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();

        public frmDoiMatKhau()
        {
            InitializeComponent();

            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            btnHuy.Click += btnHuy_Click;
            txtMatKhauMoi.KeyDown += txtMatKhauMoi_KeyDown;
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(session.TaiKhoan))
            {
                txtTaiKhoan.Text = session.TaiKhoan;
                txtMatKhauCu.Focus();
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                OperationResultDto result = taiKhoanBLL.ChangePassword(
                    txtTaiKhoan.Text,
                    txtMatKhauCu.Text,
                    txtMatKhauMoi.Text);

                MessageBox.Show(result.Message);

                if (!result.Success)
                {
                    FocusInvalidInput();
                    return;
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đổi mật khẩu: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtMatKhauMoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDoiMatKhau.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void FocusInvalidInput()
        {
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                txtTaiKhoan.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text))
            {
                txtMatKhauCu.Focus();
                return;
            }

            txtMatKhauMoi.Focus();
        }
    }
}
