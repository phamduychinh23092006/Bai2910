using System.Collections.Generic;
using InventoryManagement.DAL;
using InventoryManagement.DTO;

namespace InventoryManagement.BUS
{
    public class NhaCungCapBUS
    {
        private NhaCungCapDAL nccDAL = new NhaCungCapDAL();

        public List<NhaCungCapDTO> GetAll() => nccDAL.GetAll();

        public bool Add(NhaCungCapDTO ncc, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(ncc.TenNCC))
            {
                error = "Tên nhà cung cấp không được để trống!";
                return false;
            }
            return nccDAL.Insert(ncc);
        }
    }
}