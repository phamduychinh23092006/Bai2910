using InventoryManagement.DAL;
using InventoryManagement.DTO;

namespace InventoryManagement.BUS
{
    public class PhieuKhoBUS
    {
        private PhieuKhoDAL phieuDAL = new PhieuKhoDAL();

        public bool SavePhieuKho(PhieuKhoDTO phieu, out string error)
        {
            error = string.Empty;

            if (phieu.ChiTiet == null || phieu.ChiTiet.Count == 0)
            {
                error = "Phiếu kho phải có ít nhất 1 vật tư!";
                return false;
            }

            if (phieu.LoaiPhieu == "NHAP" && (!phieu.MaNCC.HasValue || phieu.MaNCC.Value <= 0))
            {
                error = "Phiếu nhập kho bắt buộc phải chọn Nhà cung cấp!";
                return false;
            }

            try
            {
                return phieuDAL.SavePhieuKhoTransaction(phieu);
            }
            catch (System.Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}