using QuanLyNhanSu.Common;
using QuanLyNhanSu.DTO;
using System;
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

        public int GetNextEmployeeId()
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = "SELECT ISNULL(MAX(Ma_nhan_vien), 0) + 1 FROM NHAN_VIEN";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool IsEmployeeIdExists(int maNhanVien)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM NHAN_VIEN WHERE Ma_nhan_vien = @Ma_nhan_vien";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Ma_nhan_vien", maNhanVien);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public void InsertEmployee(NhanVienDto employee)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = @"
                    INSERT INTO NHAN_VIEN
                    (
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
                    )
                    VALUES
                    (
                        @Ma_nhan_vien,
                        @Ten_nhan_vien,
                        @Ngay_sinh,
                        @Gioi_tinh,
                        @CCCD,
                        @Dia_chi,
                        @SDT,
                        @Email,
                        @Ngay_vao_lam,
                        @Ma_chuc_vu,
                        @Ten_chuc_vu,
                        @Ma_phong_ban,
                        @Ten_phong_ban,
                        @Luong_co_ban,
                        @Tinh_trang,
                        @Anh_nv
                    )";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Ma_nhan_vien", employee.MaNhanVien.Value);
                    cmd.Parameters.AddWithValue("@Ten_nhan_vien", employee.TenNhanVien);
                    cmd.Parameters.AddWithValue("@Ngay_sinh", employee.NgaySinh);
                    cmd.Parameters.AddWithValue("@Gioi_tinh", employee.GioiTinh);
                    cmd.Parameters.AddWithValue("@CCCD", employee.CCCD);
                    cmd.Parameters.AddWithValue("@Dia_chi", employee.DiaChi);
                    cmd.Parameters.AddWithValue("@SDT", employee.SDT);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@Ngay_vao_lam", employee.NgayVaoLam);
                    cmd.Parameters.AddWithValue("@Ma_chuc_vu", employee.MaChucVu);
                    cmd.Parameters.AddWithValue("@Ten_chuc_vu", employee.TenChucVu);
                    cmd.Parameters.AddWithValue("@Ma_phong_ban", employee.MaPhongBan);
                    cmd.Parameters.AddWithValue("@Ten_phong_ban", employee.TenPhongBan);
                    cmd.Parameters.AddWithValue("@Luong_co_ban", employee.LuongCoBan);
                    cmd.Parameters.AddWithValue("@Tinh_trang", employee.TinhTrang);

                    if (string.IsNullOrWhiteSpace(employee.AnhNv))
                        cmd.Parameters.AddWithValue("@Anh_nv", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Anh_nv", employee.AnhNv);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
