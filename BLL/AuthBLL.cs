using QuanLyNhanSu.DAL;
using QuanLyNhanSu.DTO;
using System;

namespace QuanLyNhanSu.BLL
{
    public class AuthBLL
    {
        private readonly TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();

        public LoginResultDto Login(string tenDangNhap, string matKhau)
        {
            tenDangNhap = tenDangNhap == null ? "" : tenDangNhap.Trim();
            matKhau = matKhau == null ? "" : matKhau.Trim();

            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                return new LoginResultDto
                {
                    Success = false,
                    Message = "Vui lòng nhập tên đăng nhập."
                };
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                return new LoginResultDto
                {
                    Success = false,
                    Message = "Vui lòng nhập mật khẩu."
                };
            }

            string matKhauHash = PasswordHelper.HashPassword(matKhau);
            TaiKhoanDto user = taiKhoanDAL.GetByUsernameAndPassword(tenDangNhap, matKhauHash);

            if (user == null)
            {
                return new LoginResultDto
                {
                    Success = false,
                    Message = "Sai tên đăng nhập hoặc mật khẩu."
                };
            }

            return new LoginResultDto
            {
                Success = true,
                Message = "Đăng nhập thành công.",
                User = user
            };
        }
    }
}
