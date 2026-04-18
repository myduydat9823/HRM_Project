using QuanLyNhanSu.Common;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhanSu.DAL
{
    public class DanhMucDAL
    {
        public DataTable GetDepartments()
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = "SELECT Ma_phong_ban, Ten_phong_ban FROM PHONG_BAN ORDER BY Ten_phong_ban";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        public DataTable GetPositions()
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = "SELECT Ma_chuc_vu, Ten_chuc_vu FROM CHUC_VU ORDER BY Ten_chuc_vu";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
    }
}
