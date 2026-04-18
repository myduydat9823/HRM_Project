using QuanLyNhanSu.KeToan;
using QuanLyNhanSu.NhanVien;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhanSu.Common;

using static System.Collections.Specialized.BitVector32;


namespace QuanLyNhanSu
{
    public partial class Form1 : Form

    {

        public Form1()
        {
            InitializeComponent();

        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string matKhauHash = PasswordHelper.HashPassword(matKhau);

            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.");
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.");
                txtMatKhau.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = DbConnectionFactory.CreateConnection())

                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            tk.Ma_nhan_vien,
                            tk.Ma_quyen,
                            q.Ten_quyen
                        FROM TAI_KHOAN tk
                        INNER JOIN QUYEN q ON tk.Ma_quyen = q.Ma_quyen
                        WHERE tk.Tai_khoan = @Tai_khoan
                          AND tk.Mat_khau = @Mat_khau";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Tai_khoan", tenDangNhap);
                        cmd.Parameters.AddWithValue("@Mat_khau", matKhauHash);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                session.MaNhanVien = Convert.ToInt32(reader["Ma_nhan_vien"]);
                                session.TaiKhoan = tenDangNhap;
                                session.MaQuyen = Convert.ToInt32(reader["Ma_quyen"]);
                                session.TenQuyen = reader["Ten_quyen"].ToString();

                                OpenFormByPermission(session.MaQuyen);
                            }
                            else
                            {
                                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.");
                            }
                        }
                    }
                }
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
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())

            {
                conn.Open();

                string matKhauHash = PasswordHelper.HashPassword("123456");

                string query = "UPDATE TAI_KHOAN SET Mat_khau = @Mat_khau";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Mat_khau", matKhauHash);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}