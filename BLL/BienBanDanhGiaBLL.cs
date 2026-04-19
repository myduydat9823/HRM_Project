using QuanLyNhanSu.DAL;
using QuanLyNhanSu.DTO;
using System;
using System.Data;

namespace QuanLyNhanSu.BLL
{
    public class BienBanDanhGiaBLL
    {
        private readonly BienBanDanhGiaDAL bienBanDanhGiaDAL = new BienBanDanhGiaDAL();

        public DataTable GetAll()
        {
            return bienBanDanhGiaDAL.GetAll();
        }

        public DataTable Search(string keyword)
        {
            keyword = keyword == null ? "" : keyword.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                return bienBanDanhGiaDAL.GetAll();
            }

            return bienBanDanhGiaDAL.Search(keyword);
        }

        public DataTable GetEmployees()
        {
            return bienBanDanhGiaDAL.GetEmployees();
        }

        public int GetNextBienBanId()
        {
            return bienBanDanhGiaDAL.GetNextBienBanId();
        }

        public OperationResultDto Create(BienBanDanhGiaDto bienBan)
        {
            OperationResultDto validation = ValidateForSave(bienBan, false);
            if (!validation.Success)
            {
                return validation;
            }

            int maBienBan = bienBanDanhGiaDAL.Insert(Normalize(bienBan));

            return new OperationResultDto
            {
                Success = true,
                Message = "Them bien ban thanh cong. Da gui thong bao cho nhan vien. Ma bien ban: " + maBienBan
            };
        }

        public OperationResultDto Update(BienBanDanhGiaDto bienBan)
        {
            OperationResultDto validation = ValidateForSave(bienBan, true);
            if (!validation.Success)
            {
                return validation;
            }

            bool updated = bienBanDanhGiaDAL.Update(Normalize(bienBan));
            if (!updated)
            {
                return Fail("Cap nhat bien ban that bai.");
            }

            return new OperationResultDto
            {
                Success = true,
                Message = "Cap nhat bien ban thanh cong."
            };
        }

        public OperationResultDto Delete(int? maBienBan)
        {
            if (!maBienBan.HasValue || maBienBan.Value <= 0)
            {
                return Fail("Vui long chon bien ban can xoa.");
            }

            bool deleted = bienBanDanhGiaDAL.Delete(maBienBan.Value);
            if (!deleted)
            {
                return Fail("Xoa bien ban that bai.");
            }

            return new OperationResultDto
            {
                Success = true,
                Message = "Xoa bien ban thanh cong."
            };
        }

        private OperationResultDto ValidateForSave(BienBanDanhGiaDto bienBan, bool requireId)
        {
            if (bienBan == null)
            {
                return Fail("Du lieu bien ban khong hop le.");
            }

            if (requireId && (!bienBan.MaBienBan.HasValue || bienBan.MaBienBan.Value <= 0))
            {
                return Fail("Vui long chon bien ban can cap nhat.");
            }

            if (bienBan.NgayLap == DateTime.MinValue)
            {
                return Fail("Ngay lap khong hop le.");
            }

            if (bienBan.NgayLap.Date > DateTime.Today)
            {
                return Fail("Ngay lap khong duoc lon hon ngay hien tai.");
            }

            if (bienBan.MaNhanVien <= 0)
            {
                return Fail("Vui long chon nhan vien.");
            }

            if (string.IsNullOrWhiteSpace(bienBan.TenNhanVien))
            {
                return Fail("Ten nhan vien khong duoc de trong.");
            }

            if (string.IsNullOrWhiteSpace(bienBan.TenChucVu))
            {
                return Fail("Chuc vu khong duoc de trong.");
            }

            if (string.IsNullOrWhiteSpace(bienBan.TenPhongBan))
            {
                return Fail("Phong ban khong duoc de trong.");
            }

            if (string.IsNullOrWhiteSpace(bienBan.NoiDungDanhGia))
            {
                return Fail("Vui long nhap noi dung danh gia.");
            }

            if (bienBan.NoiDungDanhGia.Trim().Length < 10)
            {
                return Fail("Noi dung danh gia phai co it nhat 10 ky tu.");
            }

            return new OperationResultDto
            {
                Success = true,
                Message = ""
            };
        }

        private BienBanDanhGiaDto Normalize(BienBanDanhGiaDto bienBan)
        {
            bienBan.TenNhanVien = bienBan.TenNhanVien == null ? "" : bienBan.TenNhanVien.Trim();
            bienBan.TenChucVu = bienBan.TenChucVu == null ? "" : bienBan.TenChucVu.Trim();
            bienBan.TenPhongBan = bienBan.TenPhongBan == null ? "" : bienBan.TenPhongBan.Trim();
            bienBan.NoiDungDanhGia = bienBan.NoiDungDanhGia == null ? "" : bienBan.NoiDungDanhGia.Trim();

            return bienBan;
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
