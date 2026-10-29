using System;
using System.Data;
using System.Data.SqlClient;

namespace HotelDAL
{
    public class PhieuDatPhongDAL
    {
        // Kiểm tra hoặc thêm khách hàng, tạo phiếu đặt phòng (Check-in)
        public bool CheckIn(string soPhong, string hoTen, string cccd, string sdt)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // 1. Kiểm tra khách hàng có tồn tại theo CCCD chưa
                    int maKH = -1;
                    SqlCommand cmdCheckKH = new SqlCommand("SELECT MaKH FROM KhachHang WHERE CCCD = @CCCD", conn, transaction);
                    cmdCheckKH.Parameters.AddWithValue("@CCCD", cccd);
                    object result = cmdCheckKH.ExecuteScalar();

                    if (result != null)
                    {
                        maKH = Convert.ToInt32(result);
                    }
                    else
                    {
                        // Thêm khách mới nếu chưa có
                        SqlCommand cmdInsertKH = new SqlCommand("INSERT INTO KhachHang (HoTen, CCCD, SoDienThoai) OUTPUT INSERTED.MaKH VALUES (@HoTen, @CCCD, @SoDienThoai)", conn, transaction);
                        cmdInsertKH.Parameters.AddWithValue("@HoTen", hoTen);
                        cmdInsertKH.Parameters.AddWithValue("@CCCD", cccd);
                        cmdInsertKH.Parameters.AddWithValue("@SoDienThoai", sdt);
                        maKH = (int)cmdInsertKH.ExecuteScalar();
                    }

                    // 2. Tạo phiếu đặt phòng mới
                    SqlCommand cmdInsertPhieu = new SqlCommand("INSERT INTO PhieuDatPhong (SoPhong, MaKH, NgayNhanPhong) VALUES (@SoPhong, @MaKH, GETDATE())", conn, transaction);
                    cmdInsertPhieu.Parameters.AddWithValue("@SoPhong", soPhong);
                    cmdInsertPhieu.Parameters.AddWithValue("@MaKH", maKH);
                    cmdInsertPhieu.ExecuteNonQuery();

                    // 3. Cập nhật trạng thái phòng thành "Đang ở"
                    SqlCommand cmdUpdatePhong = new SqlCommand("UPDATE Phong SET TrangThai = N'Đang ở' WHERE SoPhong = @SoPhong", conn, transaction);
                    cmdUpdatePhong.Parameters.AddWithValue("@SoPhong", soPhong);
                    cmdUpdatePhong.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        // Chức năng Check-out & Thanh toán sử dụng SqlTransaction
        public bool CheckOut(int maPhieu, string soPhong, decimal tongTien)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // 1. Cập nhật Phiếu đặt phòng (NgayTraPhong, TongTienThanhToan)
                    SqlCommand cmdPhieu = new SqlCommand("UPDATE PhieuDatPhong SET NgayTraPhong = GETDATE(), TongTienThanhToan = @TongTien WHERE MaPhieu = @MaPhieu", conn, transaction);
                    cmdPhieu.Parameters.AddWithValue("@TongTien", tongTien);
                    cmdPhieu.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmdPhieu.ExecuteNonQuery();

                    // 2. Chuyển trạng thái phòng sang "Đang dọn dẹp"
                    SqlCommand cmdPhong = new SqlCommand("UPDATE Phong SET TrangThai = N'Đang dọn dẹp' WHERE SoPhong = @SoPhong", conn, transaction);
                    cmdPhong.Parameters.AddWithValue("@SoPhong", soPhong);
                    cmdPhong.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}