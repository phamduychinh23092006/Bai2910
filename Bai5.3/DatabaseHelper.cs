namespace CafePOSProject
{
    public static class DatabaseHelper
    {
        // ⚠️ Lưu ý: Thay đổi ".\SQLEXPRESS" thành tên SQL Server của máy bạn nếu cần
        public static string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=CafePOSDB;Integrated Security=True";
    }
}