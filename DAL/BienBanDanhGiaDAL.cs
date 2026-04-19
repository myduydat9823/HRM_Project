using QuanLyNhanSu.Common;
using QuanLyNhanSu.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhanSu.DAL
{
    public class BienBanDanhGiaDAL
    {
        public DataTable GetAll()
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = @"
                    SELECT
                        Ma_bien_ban,
                        Ngay_lap,
                        Ma_nhan_vien,
                        Ten_nhan_vien,
                        Ten_chuc_vu,
                        TP_phong_ban,
                        Noi_dung_danh_gia
                    FROM BIEN_BAN_DANH_GIA
                    ORDER BY Ngay_lap DESC, Ma_bien_ban DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        public DataTable Search(string keyword)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = @"
                    SELECT
                        Ma_bien_ban,
                        Ngay_lap,
                        Ma_nhan_vien,
                        Ten_nhan_vien,
                        Ten_chuc_vu,
                        TP_phong_ban,
                        Noi_dung_danh_gia
                    FROM BIEN_BAN_DANH_GIA
                    WHERE
                        CAST(Ma_bien_ban AS NVARCHAR(20)) LIKE @Keyword
                        OR CAST(Ma_nhan_vien AS NVARCHAR(20)) LIKE @Keyword
                        OR Ten_nhan_vien LIKE @Keyword
                        OR Ten_chuc_vu LIKE @Keyword
                        OR TP_phong_ban LIKE @Keyword
                        OR Noi_dung_danh_gia LIKE @Keyword
                    ORDER BY Ngay_lap DESC, Ma_bien_ban DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + (keyword == null ? "" : keyword.Trim()) + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
            }
        }

        public DataTable GetEmployees()
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = @"
                    SELECT
                        Ma_nhan_vien,
                        CAST(Ma_nhan_vien AS NVARCHAR(20)) + N' - ' + Ten_nhan_vien AS Hien_thi_nhan_vien,
                        Ten_nhan_vien,
                        Ten_chuc_vu,
                        Ten_phong_ban
                    FROM NHAN_VIEN
                    ORDER BY Ten_nhan_vien";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        public int GetNextBienBanId()
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = "SELECT ISNULL(MAX(Ma_bien_ban), 0) + 1 FROM BIEN_BAN_DANH_GIA";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public int Insert(BienBanDanhGiaDto bienBan)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        int maBienBan = GetNextBienBanId(conn, tran);

                        string query = @"
                            INSERT INTO BIEN_BAN_DANH_GIA
                            (
                                Ma_bien_ban,
                                Ngay_lap,
                                Ma_nhan_vien,
                                Ten_nhan_vien,
                                Ten_chuc_vu,
                                TP_phong_ban,
                                Noi_dung_danh_gia
                            )
                            VALUES
                            (
                                @Ma_bien_ban,
                                @Ngay_lap,
                                @Ma_nhan_vien,
                                @Ten_nhan_vien,
                                @Ten_chuc_vu,
                                @TP_phong_ban,
                                @Noi_dung_danh_gia
                            )";

                        using (SqlCommand cmd = new SqlCommand(query, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@Ma_bien_ban", maBienBan);
                            cmd.Parameters.AddWithValue("@Ngay_lap", bienBan.NgayLap);
                            cmd.Parameters.AddWithValue("@Ma_nhan_vien", bienBan.MaNhanVien);
                            cmd.Parameters.AddWithValue("@Ten_nhan_vien", bienBan.TenNhanVien);
                            cmd.Parameters.AddWithValue("@Ten_chuc_vu", bienBan.TenChucVu);
                            cmd.Parameters.AddWithValue("@TP_phong_ban", bienBan.TenPhongBan);
                            cmd.Parameters.AddWithValue("@Noi_dung_danh_gia", bienBan.NoiDungDanhGia);
                            cmd.ExecuteNonQuery();
                        }

                        InsertNotification(conn, tran, maBienBan, bienBan);

                        tran.Commit();
                        return maBienBan;
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool Update(BienBanDanhGiaDto bienBan)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = @"
                    UPDATE BIEN_BAN_DANH_GIA
                    SET
                        Ngay_lap = @Ngay_lap,
                        Ma_nhan_vien = @Ma_nhan_vien,
                        Ten_nhan_vien = @Ten_nhan_vien,
                        Ten_chuc_vu = @Ten_chuc_vu,
                        TP_phong_ban = @TP_phong_ban,
                        Noi_dung_danh_gia = @Noi_dung_danh_gia
                    WHERE Ma_bien_ban = @Ma_bien_ban";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Ma_bien_ban", bienBan.MaBienBan.Value);
                    cmd.Parameters.AddWithValue("@Ngay_lap", bienBan.NgayLap);
                    cmd.Parameters.AddWithValue("@Ma_nhan_vien", bienBan.MaNhanVien);
                    cmd.Parameters.AddWithValue("@Ten_nhan_vien", bienBan.TenNhanVien);
                    cmd.Parameters.AddWithValue("@Ten_chuc_vu", bienBan.TenChucVu);
                    cmd.Parameters.AddWithValue("@TP_phong_ban", bienBan.TenPhongBan);
                    cmd.Parameters.AddWithValue("@Noi_dung_danh_gia", bienBan.NoiDungDanhGia);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int maBienBan)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        string deleteNotification = @"
                            DELETE FROM THONG_BAO
                            WHERE Loai_thong_bao = @Loai_thong_bao
                              AND Ma_don_lien_quan = @Ma_don_lien_quan";

                        using (SqlCommand cmd = new SqlCommand(deleteNotification, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@Loai_thong_bao", "Bien ban danh gia");
                            cmd.Parameters.AddWithValue("@Ma_don_lien_quan", maBienBan);
                            cmd.ExecuteNonQuery();
                        }

                        string deleteBienBan = @"
                            DELETE FROM BIEN_BAN_DANH_GIA
                            WHERE Ma_bien_ban = @Ma_bien_ban";

                        using (SqlCommand cmd = new SqlCommand(deleteBienBan, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@Ma_bien_ban", maBienBan);
                            bool deleted = cmd.ExecuteNonQuery() > 0;

                            tran.Commit();
                            return deleted;
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

        private int GetNextBienBanId(SqlConnection conn, SqlTransaction tran)
        {
            string query = @"
                SELECT ISNULL(MAX(Ma_bien_ban), 0) + 1
                FROM BIEN_BAN_DANH_GIA WITH (UPDLOCK, HOLDLOCK)";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private int GetNextNotificationId(SqlConnection conn, SqlTransaction tran)
        {
            string query = @"
                SELECT ISNULL(MAX(Ma_thong_bao), 0) + 1
                FROM THONG_BAO WITH (UPDLOCK, HOLDLOCK)";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void InsertNotification(
            SqlConnection conn,
            SqlTransaction tran,
            int maBienBan,
            BienBanDanhGiaDto bienBan)
        {
            int maThongBao = GetNextNotificationId(conn, tran);

            string query = @"
                INSERT INTO THONG_BAO
                (
                    Ma_thong_bao,
                    Ma_nhan_vien,
                    Tieu_de,
                    Noi_dung,
                    Ngay_tao,
                    Da_doc,
                    Loai_thong_bao,
                    Ma_don_lien_quan
                )
                VALUES
                (
                    @Ma_thong_bao,
                    @Ma_nhan_vien,
                    @Tieu_de,
                    @Noi_dung,
                    GETDATE(),
                    0,
                    @Loai_thong_bao,
                    @Ma_don_lien_quan
                )";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                cmd.Parameters.AddWithValue("@Ma_thong_bao", maThongBao);
                cmd.Parameters.AddWithValue("@Ma_nhan_vien", bienBan.MaNhanVien);
                cmd.Parameters.AddWithValue("@Tieu_de", "Ban co bien ban danh gia moi");
                cmd.Parameters.AddWithValue("@Noi_dung", BuildNotificationContent(maBienBan, bienBan));
                cmd.Parameters.AddWithValue("@Loai_thong_bao", "Bien ban danh gia");
                cmd.Parameters.AddWithValue("@Ma_don_lien_quan", maBienBan);
                cmd.ExecuteNonQuery();
            }
        }

        private string BuildNotificationContent(int maBienBan, BienBanDanhGiaDto bienBan)
        {
            return
                "Ban vua duoc lap bien ban danh gia.\r\n" +
                "Ma bien ban: " + maBienBan + "\r\n" +
                "Ngay lap: " + bienBan.NgayLap.ToString("dd/MM/yyyy") + "\r\n" +
                "Chuc vu: " + bienBan.TenChucVu + "\r\n" +
                "Phong ban: " + bienBan.TenPhongBan + "\r\n\r\n" +
                "Noi dung danh gia:\r\n" +
                bienBan.NoiDungDanhGia;
        }
    }
}
