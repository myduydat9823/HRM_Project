using QuanLyNhanSu.Common;
using QuanLyNhanSu.DTO;
using System;
using System.Data.SqlClient;

namespace QuanLyNhanSu.DAL
{
    public class TaiKhoanDAL
    {
        public TaiKhoanDto GetByUsernameAndPassword(string tenDangNhap, string matKhauHash)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        tk.Ma_nhan_vien,
                        tk.Ma_quyen,
                        q.Ten_quyen
                    FROM TAI_KHOAN tk
                    INNER JOIN QUYEN q ON tk.Ma_quyen = q.Ma_quyen
                    WHERE tk.Tai_khoan = @Tai_khoan
                      AND tk.Mat_khau = @Mat_khau";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Tai_khoan", tenDangNhap);
                    cmd.Parameters.AddWithValue("@Mat_khau", matKhauHash);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        return new TaiKhoanDto
                        {
                            MaNhanVien = Convert.ToInt32(reader["Ma_nhan_vien"]),
                            TaiKhoan = tenDangNhap,
                            MaQuyen = Convert.ToInt32(reader["Ma_quyen"]),
                            TenQuyen = reader["Ten_quyen"].ToString()
                        };
                    }
                }
            }
        }
    }
}
