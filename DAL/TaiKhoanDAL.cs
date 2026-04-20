using QuanLyNhanSu.Common;
using QuanLyNhanSu.DTO;
using System;
using System.Data;
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

        public DataTable GetEmployeesWithoutAccount(string keyword = "")
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = @"
                    SELECT
                        nv.Ma_nhan_vien,
                        nv.Ten_nhan_vien,
                        nv.SDT,
                        nv.Email,
                        nv.Ten_phong_ban,
                        nv.Ten_chuc_vu
                    FROM NHAN_VIEN nv
                    WHERE NOT EXISTS
                    (
                        SELECT 1
                        FROM TAI_KHOAN tk
                        WHERE tk.Ma_nhan_vien = nv.Ma_nhan_vien
                    )";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query += @"
                            AND
                            (
                                CAST(nv.Ma_nhan_vien AS NVARCHAR(20)) LIKE @Keyword
                                OR nv.Ten_nhan_vien LIKE @Keyword
                                OR nv.SDT LIKE @Keyword
                                OR nv.Email LIKE @Keyword
                            )";

                        cmd.Parameters.AddWithValue("@Keyword", "%" + keyword.Trim() + "%");
                    }

                    query += " ORDER BY nv.Ma_nhan_vien";
                    cmd.CommandText = query;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
            }
        }

        public DataTable GetPermissions()
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = @"
                    SELECT
                        Ma_quyen,
                        Ten_quyen
                    FROM QUYEN
                    ORDER BY Ma_quyen";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        public bool IsUsernameExists(string taiKhoan)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = @"
                    SELECT COUNT(*)
                    FROM TAI_KHOAN
                    WHERE Tai_khoan = @Tai_khoan";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Tai_khoan", taiKhoan);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool IsEmployeeHasAccount(int maNhanVien)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = @"
                    SELECT COUNT(*)
                    FROM TAI_KHOAN
                    WHERE Ma_nhan_vien = @Ma_nhan_vien";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Ma_nhan_vien", maNhanVien);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool CreateAccount(int maNhanVien, string taiKhoan, string matKhauHash, int maQuyen)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        int maTaiKhoan = GetNextAccountId(conn, tran);

                        string query = @"
                            INSERT INTO TAI_KHOAN
                            (
                                Ma_tai_khoan,
                                Ma_nhan_vien,
                                Tai_khoan,
                                Mat_khau,
                                Ma_quyen
                            )
                            VALUES
                            (
                                @Ma_tai_khoan,
                                @Ma_nhan_vien,
                                @Tai_khoan,
                                @Mat_khau,
                                @Ma_quyen
                            )";

                        using (SqlCommand cmd = new SqlCommand(query, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@Ma_tai_khoan", maTaiKhoan);
                            cmd.Parameters.AddWithValue("@Ma_nhan_vien", maNhanVien);
                            cmd.Parameters.AddWithValue("@Tai_khoan", taiKhoan);
                            cmd.Parameters.AddWithValue("@Mat_khau", matKhauHash);
                            cmd.Parameters.AddWithValue("@Ma_quyen", maQuyen);

                            bool created = cmd.ExecuteNonQuery() > 0;
                            tran.Commit();

                            return created;
                        }
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool ChangePassword(string taiKhoan, string matKhauCuHash, string matKhauMoiHash)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = @"
                    UPDATE TAI_KHOAN
                    SET Mat_khau = @Mat_khau_moi
                    WHERE Tai_khoan = @Tai_khoan
                      AND Mat_khau = @Mat_khau_cu";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Tai_khoan", taiKhoan);
                    cmd.Parameters.AddWithValue("@Mat_khau_cu", matKhauCuHash);
                    cmd.Parameters.AddWithValue("@Mat_khau_moi", matKhauMoiHash);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        private int GetNextAccountId(SqlConnection conn, SqlTransaction tran)
        {
            string query = @"
                SELECT ISNULL(MAX(Ma_tai_khoan), 0) + 1
                FROM TAI_KHOAN WITH (UPDLOCK, HOLDLOCK)";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
