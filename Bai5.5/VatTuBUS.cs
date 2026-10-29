using System.Data;
using InventoryManagement.DAL;
using InventoryManagement.DTO;

namespace InventoryManagement.BUS
{
    public class VatTuBUS
    {
        private VatTuDAL vatTuDAL = new VatTuDAL();

        public DataTable GetAll() => vatTuDAL.GetAll();

        public DataTable Search(string keyword) => vatTuDAL.Search(keyword);

        public bool Add(VatTuDTO vt, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(vt.MaVatTu))
            {
                error = "Mã vật tư không được để trống!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(vt.TenVatTu))
            {
                error = "Tên vật tư không được để trống!";
                return false;
            }
            if (vt.SoLuongTon < 0)
            {
                error = "Số lượng tồn ban đầu không được âm!";
                return false;
            }
            return vatTuDAL.Insert(vt);
        }

        public DataTable GetLowStock(decimal threshold) => vatTuDAL.GetLowStock(threshold);

        public decimal GetTotalInventoryValue() => vatTuDAL.GetTotalInventoryValue();
    }
}