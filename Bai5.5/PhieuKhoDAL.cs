using System;
using System.Data.SqlClient;
using InventoryManagement.DTO;

namespace InventoryManagement.DAL
{
    public class PhieuKhoDAL
    {
        public bool SavePhieuKhoTransaction(PhieuKhoDTO phieu)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // Bước 1: Chèn bản ghi vào bảng PhieuKho
                        string insertPhieu = @"INSERT INTO PhieuKho (LoaiPhieu, NgayLap, MaNCC, TongTien) 
                                               OUTPUT INSERTED.MaPhieu 
                                               VALUES (@LoaiPhieu, GETDATE(), @MaNCC, @TongTien)";
                        SqlCommand cmdPhieu = new SqlCommand(insertPhieu, conn, trans);
                        cmdPhieu.Parameters.AddWithValue("@LoaiPhieu", phieu.LoaiPhieu);
                        cmdPhieu.Parameters.AddWithValue("@MaNCC", (object)phieu.MaNCC ?? DBNull.Value);
                        cmdPhieu.Parameters.AddWithValue("@TongTien", phieu.TongTien);

                        int maPhieuGenerated = (int)cmdPhieu.ExecuteScalar();

                        // Bước 2 & 3: Lặp chèn ChiTietPhieuKho và Cập nhật Kho
                        foreach (var item in phieu.ChiTiet)
                        {
                            // Chèn ChiTietPhieuKho
                            string insertCT = "INSERT INTO ChiTietPhieuKho (MaPhieu, MaVatTu, SoLuong, DonGia) VALUES (@MaPhieu, @MaVatTu, @SoLuong, @DonGia)";
                            SqlCommand cmdCT = new SqlCommand(insertCT, conn, trans);
                            cmdCT.Parameters.AddWithValue("@MaPhieu", maPhieuGenerated);
                            cmdCT.Parameters.AddWithValue("@MaVatTu", item.MaVatTu);
                            cmdCT.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                            cmdCT.Parameters.AddWithValue("@DonGia", item.DonGia);
                            cmdCT.ExecuteNonQuery();

                            // Xử lý biến động tồn kho theo LoaiPhieu
                            if (phieu.LoaiPhieu == "NHAP")
                            {
                                string updateStock = "UPDATE VatTu SET SoLuongTon = SoLuongTon + @SoLuong WHERE MaVatTu = @MaVatTu";
                                SqlCommand cmdStock = new SqlCommand(updateStock, conn, trans);
                                cmdStock.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                                cmdStock.Parameters.AddWithValue("@MaVatTu", item.MaVatTu);
                                cmdStock.ExecuteNonQuery();
                            }
                            else if (phieu.LoaiPhieu == "XUAT")
                            {
                                // Lấy tồn kho hiện tại và khóa dòng dữ liệu để kiểm tra
                                string checkStockQuery = "SELECT SoLuongTon FROM VatTu WITH (UPDLOCK) WHERE MaVatTu = @MaVatTu";
                                SqlCommand cmdCheck = new SqlCommand(checkStockQuery, conn, trans);
                                cmdCheck.Parameters.AddWithValue("@MaVatTu", item.MaVatTu);
                                object currentStockObj = cmdCheck.ExecuteScalar();

                                if (currentStockObj == null)
                                {
                                    throw new Exception($"Vật tư {item.MaVatTu} không tồn tại trong hệ thống.");
                                }

                                decimal currentStock = Convert.ToDecimal(currentStockObj);

                                // Điều kiện kiểm tra tồn kho: Nếu không đủ hàng -> Rollback
                                if (currentStock < item.SoLuong)
                                {
                                    throw new Exception($"Không đủ hàng trong kho cho vật tư: {item.TenVatTu ?? item.MaVatTu} (Tồn: {currentStock}, Xuất: {item.SoLuong})");
                                }

                                string updateStock = "UPDATE VatTu SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaVatTu = @MaVatTu";
                                SqlCommand cmdStock = new SqlCommand(updateStock, conn, trans);
                                cmdStock.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                                cmdStock.Parameters.AddWithValue("@MaVatTu", item.MaVatTu);
                                cmdStock.ExecuteNonQuery();
                            }
                        }

                        // Bước 4: Gọi Commit() khi tất cả các bước thành công
                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}