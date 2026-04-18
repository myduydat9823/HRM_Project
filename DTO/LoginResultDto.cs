namespace QuanLyNhanSu.DTO
{
    public class LoginResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public TaiKhoanDto User { get; set; }
    }
}
