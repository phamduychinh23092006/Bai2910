using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InventoryManagement.DTO;

namespace InventoryManagement.DAL
{
    public class NhaCungCapDAL
    {
        public List<NhaCungCapDTO> GetAll()
        {
            List<NhaCungCapDTO> list = new List<NhaCungCapDTO>();
            DataTable dt = DatabaseAccess.ExecuteQuery("SELECT * FROM NhaCungCap");
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new NhaCungCapDTO
                {
                    MaNCC = Convert.ToInt32(row["MaNCC"]),
                    TenNCC = row["TenNCC"].ToString(),
                    DienThoai = row["DienThoai"].ToString(),
                    DiaChi = row["DiaChi"].ToString()
                });
            }
            return list;
        }

        public bool Insert(NhaCungCapDTO ncc)
        {
            string query = "INSERT INTO NhaCungCap (TenNCC, DienThoai, DiaChi) VALUES (@TenNCC, @DienThoai, @DiaChi)";
            SqlParameter[] p = {
                new SqlParameter("@TenNCC", ncc.TenNCC),
                new SqlParameter("@DienThoai", (object)ncc.DienThoai ?? DBNull.Value),
                new SqlParameter("@DiaChi", (object)ncc.DiaChi ?? DBNull.Value)
            };
            return DatabaseAccess.ExecuteNonQuery(query, p) > 0;
        }
    }
}