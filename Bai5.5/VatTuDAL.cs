using System;
using System.Data;
using System.Data.SqlClient;
using InventoryManagement.DTO;

namespace InventoryManagement.DAL
{
    public class VatTuDAL
    {
        public DataTable GetAll()
        {
            return DatabaseAccess.ExecuteQuery("SELECT * FROM VatTu");
        }

        // Chống SQL Injection 100% bằng SqlParameter khi tìm kiếm theo mã hoặc tên
        public DataTable Search(string keyword)
        {
            string query = "SELECT * FROM VatTu WHERE MaVatTu LIKE @Keyword OR TenVatTu LIKE @Keyword";
            SqlParameter[] p = { new SqlParameter("@Keyword", "%" + keyword + "%") };
            return DatabaseAccess.ExecuteQuery(query, p);
        }

        public bool Insert(VatTuDTO vt)
        {
            string query = "INSERT INTO VatTu (MaVatTu, TenVatTu, DVT, SoLuongTon) VALUES (@MaVatTu, @TenVatTu, @DVT, @SoLuongTon)";
            SqlParameter[] p = {
                new SqlParameter("@MaVatTu", vt.MaVatTu),
                new SqlParameter("@TenVatTu", vt.TenVatTu),
                new SqlParameter("@DVT", (object)vt.DVT ?? DBNull.Value),
                new SqlParameter("@SoLuongTon", vt.SoLuongTon)
            };
            return DatabaseAccess.ExecuteNonQuery(query, p) > 0;
        }

        // Lấy các vật tư có SoLuongTon dưới ngưỡng định mức
        public DataTable GetLowStock(decimal threshold)
        {
            string query = "SELECT * FROM VatTu WHERE SoLuongTon < @Threshold";
            SqlParameter[] p = { new SqlParameter("@Threshold", threshold) };
            return DatabaseAccess.ExecuteQuery(query, p);
        }

        // Dùng ExecuteScalar để tính tổng giá trị hàng hóa tồn kho
        public decimal GetTotalInventoryValue()
        {
            string query = @"
                SELECT ISNULL(SUM(vt.SoLuongTon * ISNULL(
                    (SELECT TOP 1 DonGia FROM ChiTietPhieuKho ct JOIN PhieuKho p ON ct.MaPhieu = p.MaPhieu WHERE ct.MaVatTu = vt.MaVatTu ORDER BY p.NgayLap DESC), 0
                )), 0) 
                FROM VatTu vt";
            object res = DatabaseAccess.ExecuteScalar(query);
            return Convert.ToDecimal(res);
        }
    }
}