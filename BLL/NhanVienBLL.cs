using QuanLyNhanSu.DAL;
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
    }
}
