using QuanLyNhanSu.DAL;
using System.Data;

namespace QuanLyNhanSu.BLL
{
    public class DanhMucBLL
    {
        private readonly DanhMucDAL danhMucDAL = new DanhMucDAL();

        public DataTable GetDepartments()
        {
            return danhMucDAL.GetDepartments();
        }

        public DataTable GetPositions()
        {
            return danhMucDAL.GetPositions();
        }
    }
}
