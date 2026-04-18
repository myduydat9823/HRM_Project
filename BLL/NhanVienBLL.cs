using QuanLyNhanSu.DAL;
using QuanLyNhanSu.DTO;
using System;
using System.Data;

namespace QuanLyNhanSu.BLL
{
    public class NhanVienBLL
    {
        private readonly NhanVienDAL nhanVienDAL = new NhanVienDAL();

        public DataTable GetAllEmployees()
        {
            return nhanVienDAL.GetAllEmployees();
        }

        public DataTable SearchEmployees(int? maPhongBan, int? maChucVu, string tinhTrang, string tuKhoa)
        {
            return nhanVienDAL.SearchEmployees(maPhongBan, maChucVu, tinhTrang, tuKhoa);
        }

        public int AddEmployee(NhanVienDto employee)
        {
            if (!employee.MaNhanVien.HasValue)
            {
                employee.MaNhanVien = nhanVienDAL.GetNextEmployeeId();
            }
            else if (nhanVienDAL.IsEmployeeIdExists(employee.MaNhanVien.Value))
            {
                throw new InvalidOperationException("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác.");
            }

            nhanVienDAL.InsertEmployee(employee);
            return employee.MaNhanVien.Value;
        }

        public void UpdateEmployee(NhanVienDto employee)
        {
            if (!employee.MaNhanVien.HasValue)
            {
                throw new InvalidOperationException("Vui lòng chọn nhân viên cần sửa.");
            }

            nhanVienDAL.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int maNhanVien)
        {
            nhanVienDAL.DeleteEmployee(maNhanVien);
        }
    }
}
