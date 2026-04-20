using QuanLyNhanSu.DAL;
using QuanLyNhanSu.DTO;
using System.Data;

namespace QuanLyNhanSu.BLL
{
    public class TaiKhoanBLL
    {
        private readonly TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();

        public DataTable GetEmployeesWithoutAccount(string keyword = "")
        {
            return taiKhoanDAL.GetEmployeesWithoutAccount(keyword == null ? "" : keyword.Trim());
        }

        public DataTable GetPermissions()
        {
            return taiKhoanDAL.GetPermissions();
        }

        public OperationResultDto CreateAccount(
            int? maNhanVien,
            string taiKhoan,
            string matKhau,
            string nhapLaiMatKhau,
            int? maQuyen)
        {
            taiKhoan = taiKhoan == null ? "" : taiKhoan.Trim();
            matKhau = matKhau == null ? "" : matKhau.Trim();
            nhapLaiMatKhau = nhapLaiMatKhau == null ? "" : nhapLaiMatKhau.Trim();

            if (!maNhanVien.HasValue || maNhanVien.Value <= 0)
            {
                return Fail("Vui long chon nhan vien can cap tai khoan.");
            }

            if (string.IsNullOrWhiteSpace(taiKhoan))
            {
                return Fail("Vui long nhap tai khoan.");
            }

            if (taiKhoan.Contains(" "))
            {
                return Fail("Tai khoan khong duoc chua khoang trang.");
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                return Fail("Vui long nhap mat khau.");
            }

            if (matKhau.Length < 6)
            {
                return Fail("Mat khau phai co it nhat 6 ky tu.");
            }

            if (matKhau != nhapLaiMatKhau)
            {
                return Fail("Mat khau nhap lai khong khop.");
            }

            if (!maQuyen.HasValue || maQuyen.Value <= 0)
            {
                return Fail("Vui long chon quyen cho tai khoan.");
            }

            if (taiKhoanDAL.IsEmployeeHasAccount(maNhanVien.Value))
            {
                return Fail("Nhan vien nay da co tai khoan.");
            }

            if (taiKhoanDAL.IsUsernameExists(taiKhoan))
            {
                return Fail("Tai khoan nay da ton tai.");
            }

            string matKhauHash = PasswordHelper.HashPassword(matKhau);
            bool created = taiKhoanDAL.CreateAccount(maNhanVien.Value, taiKhoan, matKhauHash, maQuyen.Value);

            if (!created)
            {
                return Fail("Cap tai khoan that bai.");
            }

            return new OperationResultDto
            {
                Success = true,
                Message = "Cap tai khoan thanh cong."
            };
        }

        public OperationResultDto ChangePassword(string taiKhoan, string matKhauCu, string matKhauMoi)
        {
            taiKhoan = taiKhoan == null ? "" : taiKhoan.Trim();
            matKhauCu = matKhauCu == null ? "" : matKhauCu.Trim();
            matKhauMoi = matKhauMoi == null ? "" : matKhauMoi.Trim();

            if (string.IsNullOrWhiteSpace(taiKhoan))
            {
                return Fail("Vui lòng nhập tài khoản.");
            }

            if (taiKhoan.Contains(" "))
            {
                return Fail("Tài khoản không được chứa khoảng trắng.");
            }

            if (string.IsNullOrWhiteSpace(matKhauCu))
            {
                return Fail("Vui lòng nhập mật khẩu hiện tại.");
            }

            if (string.IsNullOrWhiteSpace(matKhauMoi))
            {
                return Fail("Vui lòng nhập mật khẩu mới.");
            }

            if (matKhauMoi.Length < 6)
            {
                return Fail("Mật khẩu mới phải có ít nhất 6 ký tự.");
            }

            if (matKhauCu == matKhauMoi)
            {
                return Fail("Mật khẩu mới không được trùng mật khẩu hiện tại.");
            }

            string matKhauCuHash = PasswordHelper.HashPassword(matKhauCu);
            string matKhauMoiHash = PasswordHelper.HashPassword(matKhauMoi);

            bool changed = taiKhoanDAL.ChangePassword(taiKhoan, matKhauCuHash, matKhauMoiHash);

            if (!changed)
            {
                return Fail("Tài khoản hoặc mật khẩu hiện tại không đúng.");
            }

            return new OperationResultDto
            {
                Success = true,
                Message = "Đổi mật khẩu thành công."
            };
        }

        private OperationResultDto Fail(string message)
        {
            return new OperationResultDto
            {
                Success = false,
                Message = message
            };
        }
    }
}
