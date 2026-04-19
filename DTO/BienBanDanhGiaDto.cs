using System;

namespace QuanLyNhanSu.DTO
{
    public class BienBanDanhGiaDto
    {
        public int? MaBienBan { get; set; }
        public DateTime NgayLap { get; set; }
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string TenChucVu { get; set; }
        public string TenPhongBan { get; set; }
        public string NoiDungDanhGia { get; set; }
    }
}
