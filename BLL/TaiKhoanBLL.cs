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
