using System;

namespace QuanLyNhanSu.DTO
{
    public class NhanVienDto
    {
        public int? MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public int MaChucVu { get; set; }
        public string TenChucVu { get; set; }
        public int MaPhongBan { get; set; }
        public string TenPhongBan { get; set; }
        public decimal LuongCoBan { get; set; }
        public string TinhTrang { get; set; }
        public string AnhNv { get; set; }
    }
}
