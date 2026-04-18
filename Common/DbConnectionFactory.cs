using System.Configuration;
using System.Data.SqlClient;

namespace QuanLyNhanSu.Common
{
    public static class DbConnectionFactory
    {
        public static SqlConnection CreateConnection()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["QuanLyNhanSuDb"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ConfigurationErrorsException(
                    "Không tìm thấy connection string 'QuanLyNhanSuDb' trong App.config.");
            }

            return new SqlConnection(connectionString);
        }
    }
}
