using System;
using System.Data.SqlClient;

namespace QuanLyNhanSu.Common
{
    public class KetoanRoleInfo
    {
        public const int AccountingDepartmentId = 2;
        public const int AccountingManagerPositionId = 3;
        public const int AccountantPositionId = 4;

        public int MaNhanVien { get; set; }
        public int MaQuyen { get; set; }
        public int MaChucVu { get; set; }
        public int MaPhongBan { get; set; }
        public string TenChucVu { get; set; }
        public string TenPhongBan { get; set; }
        public bool IsAdmin { get; set; }

        public bool IsAccountingDepartment
        {
            get { return MaPhongBan == AccountingDepartmentId; }
        }

        public bool IsAccountingManager
        {
            get
            {
                return IsAdmin
                    || (MaQuyen == 3
                        && MaPhongBan == AccountingDepartmentId
                        && MaChucVu == AccountingManagerPositionId);
            }
        }

        public bool IsAccountant
        {
            get
            {
                return MaQuyen == 3
                    && MaPhongBan == AccountingDepartmentId
                    && MaChucVu == AccountantPositionId;
            }
        }

        public bool CanCreateRewardPenalty
        {
            get { return IsAccountingManager || IsAccountant; }
        }

        public bool CanApproveRewardPenalty
        {
            get { return IsAccountingManager; }
        }
    }

    public static class KetoanPermissionHelper
    {
        public static KetoanRoleInfo GetCurrentRole()
        {
            KetoanRoleInfo role = new KetoanRoleInfo
            {
                MaNhanVien = session.MaNhanVien,
                MaQuyen = session.MaQuyen,
                IsAdmin = session.MaQuyen == 1,
                TenChucVu = string.Empty,
                TenPhongBan = string.Empty
            };

            if (role.IsAdmin)
                return role;

            if (session.MaNhanVien <= 0)
                return role;

            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = @"
                    SELECT
                        ISNULL(Ma_chuc_vu, 0) AS Ma_chuc_vu,
                        ISNULL(Ma_phong_ban, 0) AS Ma_phong_ban,
                        ISNULL(Ten_chuc_vu, N'') AS Ten_chuc_vu,
                        ISNULL(Ten_phong_ban, N'') AS Ten_phong_ban
                    FROM NHAN_VIEN
                    WHERE Ma_nhan_vien = @Ma_nhan_vien";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Ma_nhan_vien", session.MaNhanVien);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            role.MaChucVu = Convert.ToInt32(reader["Ma_chuc_vu"]);
                            role.MaPhongBan = Convert.ToInt32(reader["Ma_phong_ban"]);
                            role.TenChucVu = reader["Ten_chuc_vu"].ToString();
                            role.TenPhongBan = reader["Ten_phong_ban"].ToString();
                        }
                    }
                }
            }

            return role;
        }
    }
}
