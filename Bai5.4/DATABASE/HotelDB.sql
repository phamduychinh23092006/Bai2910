CREATE DATABASE HotelDB;
GO

USE HotelDB;
GO

-- 1. Bảng Phòng
CREATE TABLE Phong (
    SoPhong VARCHAR(10) PRIMARY KEY,
    LoaiPhong NVARCHAR(50),
    GiaTheoGio DECIMAL(18,2),
    TrangThai NVARCHAR(30) DEFAULT N'Trống' -- 'Trống', 'Đang ở', 'Đang dọn dẹp'
);

-- 2. Bảng Khách hàng
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    CCCD VARCHAR(20) UNIQUE NOT NULL,
    SoDienThoai VARCHAR(15)
);

-- 3. Bảng Dịch vụ
CREATE TABLE DichVu (
    MaDV INT IDENTITY(1,1) PRIMARY KEY,
    TenDV NVARCHAR(100),
    DonGia DECIMAL(18,2)
);

-- 4. Bảng Phiếu đặt phòng
CREATE TABLE PhieuDatPhong (
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    SoPhong VARCHAR(10) FOREIGN KEY REFERENCES Phong(SoPhong),
    MaKH INT FOREIGN KEY REFERENCES KhachHang(MaKH),
    NgayNhanPhong DATETIME DEFAULT GETDATE(),
    NgayTraPhong DATETIME NULL,
    TongTienThanhToan DECIMAL(18,2) DEFAULT 0
);

-- 5. Bảng Sử dụng dịch vụ
CREATE TABLE SuDungDichVu (
    MaPhieu INT FOREIGN KEY REFERENCES PhieuDatPhong(MaPhieu),
    MaDV INT FOREIGN KEY REFERENCES DichVu(MaDV),
    SoLuong INT NOT NULL,
    ThoiGian DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (MaPhieu, MaDV)
);
GO

-- Thêm dữ liệu mẫu
INSERT INTO Phong (SoPhong, LoaiPhong, GiaTheoGio) VALUES 
('P101', N'Đơn', 50000), 
('P102', N'Đơn', 50000), 
('P201', N'Đôi', 80000), 
('P301', N'VIP', 150000);

INSERT INTO DichVu (TenDV, DonGia) VALUES 
(N'Nước suối', 10000), 
(N'Mì tôm', 20000), 
(N'Giặt là', 50000);
GO