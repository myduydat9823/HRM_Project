using QuanLyNhanSu.Common;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhanSu.DAL
{
    public class NhanVienDAL
    {
        public DataTable GetAllEmployees()
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        Ma_nhan_vien,
                        Ten_nhan_vien,
                        Ngay_sinh,
                        Gioi_tinh,
                        CCCD,
                        Dia_chi,
                        SDT,
                        Email,
                        Ngay_vao_lam,
                        Ma_chuc_vu,
                        Ten_chuc_vu,
                        Ma_phong_ban,
                        Ten_phong_ban,
                        Luong_co_ban,
                        Tinh_trang,
                        Anh_nv
                    FROM NHAN_VIEN
                    ORDER BY Ma_nhan_vien";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
    }
}
