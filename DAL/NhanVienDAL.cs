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

        public DataTable SearchEmployees(int? maPhongBan, int? maChucVu, string tinhTrang, string tuKhoa)
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
                    WHERE 1 = 1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (maPhongBan.HasValue)
                {
                    query += " AND Ma_phong_ban = @Ma_phong_ban";
                    cmd.Parameters.AddWithValue("@Ma_phong_ban", maPhongBan.Value);
                }

                if (maChucVu.HasValue)
                {
                    query += " AND Ma_chuc_vu = @Ma_chuc_vu";
                    cmd.Parameters.AddWithValue("@Ma_chuc_vu", maChucVu.Value);
                }

                if (!string.IsNullOrWhiteSpace(tinhTrang))
                {
                    query += " AND Tinh_trang = @Tinh_trang";
                    cmd.Parameters.AddWithValue("@Tinh_trang", tinhTrang.Trim());
                }

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    query += " AND (Ten_nhan_vien LIKE @TuKhoa OR CCCD LIKE @TuKhoa OR SDT LIKE @TuKhoa OR CAST(Ma_nhan_vien AS NVARCHAR(20)) LIKE @TuKhoa)";
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa.Trim() + "%");
                }

                query += " ORDER BY Ma_nhan_vien";
                cmd.CommandText = query;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
    }
}
