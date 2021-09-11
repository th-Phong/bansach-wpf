/*
Created		16/03/2021
Modified		21/03/2021
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/

/**/
Create database QL_BANSACH
GO

USE QL_BANSACH
GO

SET DATEFORMAT dmy

Create table dbo.[CT_HOADON]
(
	[SoHD] VARCHAR(5) NOT NULL,
	[MaSach] VARCHAR(5) NOT NULL,
	[SoLuong] Int check ([SoLuong]>0) NOT NULL,
Primary Key ([MaSach],[SoHD])
) 
go

Create table dbo.[PHIEUNHAPSACH]
(
	[SoPNS] VARCHAR(5) NOT NULL,
	[MaNV] VARCHAR(5) NOT NULL,
	[NgayNhap] Date NULL,
Primary Key ([SoPNS])
) 
go

Create table dbo.[HOADON]
(
	[SoHD] VARCHAR(5) NOT NULL,
	[MaKhachHang] VARCHAR(5) NOT NULL,
	[MaNV] VARCHAR(5) NOT NULL,
	[NgayHoaDon] Date NULL,
	[TrangThai] nvarchar(40) check ([TrangThai] IN(N'Đã thanh toán',N'Chưa thanh toán')) NOT NULL,
Primary Key ([SoHD])
) 
go

Create table dbo.[NHAXUATBAN]
(
	[MaNhaXuatBan] VARCHAR(5) NOT NULL,
	[TenNhaXuatBan] nvarchar(70) NOT NULL,
	[DiaChiNXB] nvarchar(70) NULL,
	[DienThoai] nvarchar(70) NULL,
Primary Key ([MaNhaXuatBan])
) 
go

Create table dbo.[SACH]
(
	[MaSach] VARCHAR(5) NOT NULL,
	[MaTacGia] VARCHAR(5) NOT NULL,
	[MaTheLoai] VARCHAR(5) NOT NULL,
	[MaNhaXuatBan] VARCHAR(5) NOT NULL,
	[MaKM] VARCHAR(5) NOT NULL,
Primary Key ([MaSach])
) 
go

Create table dbo.[THELOAI]
(
	[MaTheLoai] VARCHAR(5) NOT NULL,
	[TenTheLoai] nVarchar(100) NOT NULL,
Primary Key ([MaTheLoai])
) 
go

Create table dbo.[NHANVIEN]
(
	[MaNV] VARCHAR(5) NOT NULL,
	[UserName] varchar(25) NOT NULL,
	[MaChucVu] VARCHAR(5) NOT NULL,
	[TenNV] nvarchar(100) NOT NULL,
	[DiaChi] nvarchar(100) NOT NULL,
	[SoDienThoai] int NOT NULL,
	[CMND] varChar(11) NOT NULL,
	[Phai] nvarchar(7) check ([Phai] IN(N'Nam',N'Nữ')) NOT NULL,
	[NgaySinh] date NULL,
	[TrangThai] nvarchar(100) check ([TrangThai] IN(N'Đang đi làm',N'Đã nghỉ việc',N'Đang xử lý')) NOT NULL,
Primary Key ([MaNV])
) 
go

Create table dbo.[TACGIA]
(
	[MaTacGia] VARCHAR(5) NOT NULL,
	[TenTacGia] nvarchar(70) NOT NULL,
	[NgaySinh] date NULL,
	[QueQuan] nvarchar(70) NULL,
	[Phai] nvarchar(7) check ([Phai] IN(N'Nam',N'Nữ')) NOT NULL,
Primary Key ([MaTacGia])
) 
go

Create table dbo.[ChucVu]
(
	[MaChucVu] VARCHAR(5) NOT NULL,
	[TenChucVu] nvarchar(50) NOT NULL,
Primary Key ([MaChucVu])
) 
go

Create table dbo.[TAIKHOAN]
(
	[UserName] varchar(25) NOT NULL,
	[MaQuyen] VARCHAR(5) NOT NULL,
	[Pass] varChar(max) NOT NULL,
Primary Key ([UserName])
) 
go

Create table dbo.[KHACHHANG]
(
	[MaKhachHang] VARCHAR(5) NOT NULL,
	[TenKhachHang] NVARCHAR(70) NOT NULL,
	[Phai] nvarchar(7) check ([Phai] IN(N'Nam',N'Nữ')) NOT NULL,
	[DiaChi] NVARCHAR(70) NOT NULL,
	[SDT] int NOT NULL,
	[Email] VARCHAR(50) NULL,
	[NgaySinh] date NULL,
Primary Key ([MaKhachHang])
) 
go

Create table dbo.[PHANQUYEN]
(
	[MaQuyen] VARCHAR(5) NOT NULL,
	[TenQuyen] VARCHAR(15) NOT NULL,
	[Mota] NVARCHAR(50) NULL,
Primary Key ([MaQuyen])
) 
go

Create table dbo.[CHITIETPHIEUNHAP]
(
	[SoPNS] VARCHAR(5) NOT NULL,
	[MaSach] VARCHAR(5) NOT NULL,
	[SoLuongNhap] int check ([SoLuongNhap]>0) NOT NULL,
	[DonGiaNhap] DECIMAL NOT NULL,
Primary Key ([SoPNS],[MaSach])
) 
go

Create table dbo.[KHUYENMAI]
(
	[MaKM] VARCHAR(5) NOT NULL,
	[TenChuongTrinh] NVARCHAR(70) NOT NULL,
	[GiamGia] int check ([GiamGia]>=0 and 100>=[GiamGia]) NOT NULL,
Primary Key ([MaKM])
) 
go

Create table dbo.[CHITIETSACH]
(
	[MaSach] VARCHAR(5) NOT NULL,
	[TenSach] NVARCHAR(70) NOT NULL,
	[DonGiaBan] DECIMAL NOT NULL,
	[SoLuongTon] int check ([SoLuongTon]>0) NOT NULL,
	[LanTaiBan] int check ([LanTaiBan]>=1) NOT NULL,
	[SoTrang] smallint check ([SoTrang]>=1 and 2000>=[SoTrang]) NOT NULL,
	[LoaiBia] nvarchar(15) check ([LoaiBia] IN(N'Bìa cứng',N'Bìa Mềm')) NOT NULL,
	[NgayXuatBan] date NULL,
	[Hinh] nvarchar(300) NULL,
Primary Key ([MaSach])
) 
go


Alter table dbo.[CHITIETPHIEUNHAP] add  foreign key([SoPNS]) references [PHIEUNHAPSACH] ([SoPNS]) ON UPDATE CASCADE ON DELETE CASCADE 
go
Alter table dbo.[CT_HOADON] add  foreign key([SoHD]) references [HOADON] ([SoHD]) ON UPDATE CASCADE ON DELETE CASCADE  
go
Alter table dbo.[SACH] add  foreign key([MaNhaXuatBan]) references [NHAXUATBAN] ([MaNhaXuatBan])  ON UPDATE CASCADE ON DELETE CASCADE 
go
Alter table dbo.[CT_HOADON] add  foreign key([MaSach]) references [SACH] ([MaSach])  ON UPDATE CASCADE ON DELETE CASCADE 
go
Alter table dbo.[CHITIETPHIEUNHAP] add  foreign key([MaSach]) references [SACH] ([MaSach])  ON UPDATE CASCADE ON DELETE CASCADE
go
Alter table dbo.[CHITIETSACH] add  foreign key([MaSach]) references [SACH] ([MaSach])  ON UPDATE CASCADE ON DELETE CASCADE 
go
Alter table dbo.[SACH] add  foreign key([MaTheLoai]) references [THELOAI] ([MaTheLoai])  ON UPDATE CASCADE ON DELETE CASCADE 
go
Alter table dbo.[PHIEUNHAPSACH] add  foreign key([MaNV]) references [NHANVIEN] ([MaNV])  ON UPDATE CASCADE ON DELETE CASCADE 
go
Alter table dbo.[HOADON] add  foreign key([MaNV]) references [NHANVIEN] ([MaNV]) ON UPDATE CASCADE ON DELETE CASCADE
go
Alter table dbo.[SACH] add  foreign key([MaTacGia]) references [TACGIA] ([MaTacGia])  ON UPDATE CASCADE ON DELETE CASCADE
go
Alter table dbo.[NHANVIEN] add  foreign key([MaChucVu]) references [ChucVu] ([MaChucVu])  ON UPDATE CASCADE ON DELETE CASCADE 
go
Alter table dbo.[NHANVIEN] add  foreign key([UserName]) references [TAIKHOAN] ([UserName])  ON UPDATE CASCADE ON DELETE CASCADE 
go
Alter table dbo.[HOADON] add  foreign key([MaKhachHang]) references [KHACHHANG] ([MaKhachHang])  ON UPDATE CASCADE ON DELETE CASCADE 
go
Alter table dbo.[TAIKHOAN] add  foreign key([MaQuyen]) references [PHANQUYEN] ([MaQuyen])  ON UPDATE CASCADE ON DELETE CASCADE
go
Alter table dbo.[SACH] add  foreign key([MaKM]) references [KHUYENMAI] ([MaKM])  ON UPDATE CASCADE ON DELETE CASCADE
GO


Set quoted_identifier on
go



Set quoted_identifier off
go

/*   -------------------------------    INSERT     ------------------------------------- */

INSERT dbo.THELOAI (MaTheLoai,TenTheLoai)VALUES('TL001',N'Kinh tế')
INSERT dbo.THELOAI (MaTheLoai,TenTheLoai)VALUES('TL002',N'Văn học')
INSERT dbo.THELOAI (MaTheLoai,TenTheLoai)VALUES('TL003',N'Thiếu nhi')
INSERT dbo.THELOAI (MaTheLoai,TenTheLoai)VALUES('TL004',N'Học ngoại ngữ')
INSERT dbo.THELOAI (MaTheLoai,TenTheLoai)VALUES('TL005',N'Kỹ năng sống')

INSERT dbo.NHAXUATBAN(MaNhaXuatBan,TenNhaXuatBan,DiaChiNXB,DienThoai)VALUES('NXB01',N'Văn Học',N'Hồ Chí Minh',N'0920329209')
INSERT dbo.NHAXUATBAN(MaNhaXuatBan,TenNhaXuatBan,DiaChiNXB,DienThoai)VALUES('NXB02',N'Hội nhà văn',N'Hà Nội',N'0920439209')
INSERT dbo.NHAXUATBAN(MaNhaXuatBan,TenNhaXuatBan,DiaChiNXB,DienThoai)VALUES('NXB03',N'Kim đồng',N'Hà Nội',N'0924329209')
INSERT dbo.NHAXUATBAN(MaNhaXuatBan,TenNhaXuatBan,DiaChiNXB,DienThoai)VALUES('NXB04',N'Thế giới',N'Hồ Chí Minh',N'0982748294')
INSERT dbo.NHAXUATBAN(MaNhaXuatBan,TenNhaXuatBan,DiaChiNXB,DienThoai)VALUES('NXB05',N'Lao động',N'Hà Nội',N'0394928593')
INSERT dbo.NHAXUATBAN(MaNhaXuatBan,TenNhaXuatBan,DiaChiNXB,DienThoai)VALUES('NXB06',N'Trẻ',N'Hà Nội',N'9384929594')
INSERT dbo.NHAXUATBAN(MaNhaXuatBan,TenNhaXuatBan,DiaChiNXB,DienThoai)VALUES('NXB07',N'Đà Nẵng',N'Đà Nẵng',N'0403042443')
INSERT dbo.NHAXUATBAN(MaNhaXuatBan,TenNhaXuatBan,DiaChiNXB,DienThoai)VALUES('NXB08',N'Tổng hợp thành phố Hồ Chí Minh',N'Hồ Chí Minh',N'0204857234')

INSERT dbo.TACGIA (MaTacGia,TenTacGia,NgaySinh,QueQuan,Phai)VALUES('TG001',N'Antoine de Saint-Exupéry',CAST(N'1900-06-29' AS Date),N'Pháp',N'Nam')
INSERT dbo.TACGIA (MaTacGia,TenTacGia,NgaySinh,QueQuan,Phai)VALUES('TG002',N'Luis Sepúlveda',CAST(N'1949-10-04' AS Date),N'Chi Lê',N'Nam')
INSERT dbo.TACGIA (MaTacGia,TenTacGia,NgaySinh,QueQuan,Phai)VALUES('TG003',N'Tô Hoài',CAST(N'1920-09-27' AS Date),N'Hà Nội',N'Nam')
INSERT dbo.TACGIA (MaTacGia,TenTacGia,NgaySinh,QueQuan,Phai)VALUES('TG004',N'Daniel Kahneman',CAST(N'1934-03-05' AS Date),N'Israel',N'Nam')
INSERT dbo.TACGIA (MaTacGia,TenTacGia,NgaySinh,QueQuan,Phai)VALUES('TG005',N'Oliver Napoleon Hill',CAST(N'1883-10-26' AS Date),N'Mỹ',N'Nam')
INSERT dbo.TACGIA (MaTacGia,TenTacGia,NgaySinh,QueQuan,Phai)VALUES('TG006',N'Nguyễn Nhật Ánh',CAST(N'1955-05-07' AS Date),N'Quảng Nam',N'Nam')
INSERT dbo.TACGIA (MaTacGia,TenTacGia,NgaySinh,QueQuan,Phai)VALUES('TG007',N'Paulo Coelho',CAST(N'1947-08-24' AS Date),N'Brasil',N'Nam')
INSERT dbo.TACGIA (MaTacGia,TenTacGia,NgaySinh,QueQuan,Phai)VALUES('TG008',N'Mai Lan Hương',CAST(N'1978-03-09' AS Date),N'Việt Nam',N'Nữ')
INSERT dbo.TACGIA (MaTacGia,TenTacGia,NgaySinh,QueQuan,Phai)VALUES('TG009',N'Nihongo So-matoe',CAST(N'1980-06-12' AS Date),N'Nhật Bản',N'Nữ')
INSERT dbo.TACGIA (MaTacGia,TenTacGia,NgaySinh,QueQuan,Phai)VALUES('TG010',N'Dale Carnegie',CAST(N'1988-11-24' AS Date),N'Mỹ',N'Nam')
INSERT dbo.TACGIA (MaTacGia,TenTacGia,NgaySinh,QueQuan,Phai)VALUES('TG011',N'Tony Buổi Sáng',CAST(N'1960-05-01' AS Date),N'Việt Nam',N'Nam')
INSERT dbo.TACGIA (MaTacGia,TenTacGia,NgaySinh,QueQuan,Phai)VALUES('TG012',N'Stephen Richards Covey',CAST(N'1932-10-24' AS Date),N'Mỹ',N'Nam')

INSERT dbo.KHUYENMAI (MaKM,TenChuongTrinh,GiamGia)VALUES('KM000',N'No',0)
INSERT dbo.KHUYENMAI (MaKM,TenChuongTrinh,GiamGia)VALUES('KM001',N'Quốc tế Phụ nữ',20)
INSERT dbo.KHUYENMAI (MaKM,TenChuongTrinh,GiamGia)VALUES('KM002',N'1 năm khai trương',10)
INSERT dbo.KHUYENMAI (MaKM,TenChuongTrinh,GiamGia)VALUES('KM003',N'Xả kho',30)

INSERT dbo.SACH (MaSach,MaTacGia,MaTheLoai,MaNhaXuatBan,MaKM)VALUES('S0001','TG001','TL003','NXB01','KM001')
INSERT dbo.SACH (MaSach,MaTacGia,MaTheLoai,MaNhaXuatBan,MaKM)VALUES('S0002','TG002','TL003','NXB02','KM002')
INSERT dbo.SACH (MaSach,MaTacGia,MaTheLoai,MaNhaXuatBan,MaKM)VALUES('S0003','TG003','TL003','NXB03','KM003')
INSERT dbo.SACH (MaSach,MaTacGia,MaTheLoai,MaNhaXuatBan,MaKM)VALUES('S0004','TG004','TL001','NXB04','KM001')
INSERT dbo.SACH (MaSach,MaTacGia,MaTheLoai,MaNhaXuatBan,MaKM)VALUES('S0005','TG005','TL001','NXB05','KM001')
INSERT dbo.SACH (MaSach,MaTacGia,MaTheLoai,MaNhaXuatBan,MaKM)VALUES('S0006','TG006','TL002','NXB06','KM000')
INSERT dbo.SACH (MaSach,MaTacGia,MaTheLoai,MaNhaXuatBan,MaKM)VALUES('S0007','TG007','TL002','NXB02','KM000')
INSERT dbo.SACH (MaSach,MaTacGia,MaTheLoai,MaNhaXuatBan,MaKM)VALUES('S0008','TG008','TL004','NXB07','KM001')
INSERT dbo.SACH (MaSach,MaTacGia,MaTheLoai,MaNhaXuatBan,MaKM)VALUES('S0009','TG009','TL004','NXB06','KM001')
INSERT dbo.SACH (MaSach,MaTacGia,MaTheLoai,MaNhaXuatBan,MaKM)VALUES('S0010','TG010','TL005','NXB08','KM002')
INSERT dbo.SACH (MaSach,MaTacGia,MaTheLoai,MaNhaXuatBan,MaKM)VALUES('S0011','TG011','TL005','NXB06','KM003')
INSERT dbo.SACH (MaSach,MaTacGia,MaTheLoai,MaNhaXuatBan,MaKM)VALUES('S0012','TG012','TL005','NXB08','KM002')

INSERT dbo.CHITIETSACH(MaSach,TenSach,DonGiaBan,SoLuongTon,LanTaiBan,SoTrang,LoaiBia,NgayXuatBan,Hinh)VALUES('S0001',N'Hoàng Tử Bé',75000,50,10,102,N'Bìa mềm',CAST(N'2019-05-01' AS Date),N'D:\QL_SACH\Image\hoangtube.jpg')
INSERT dbo.CHITIETSACH(MaSach,TenSach,DonGiaBan,SoLuongTon,LanTaiBan,SoTrang,LoaiBia,NgayXuatBan,Hinh)VALUES('S0002',N'Chuyện con mèo dạy hải âu biết bay',49000,40,4,144,N'Bìa mềm',CAST(N'2019-06-01' AS Date),N'D:\QL_SACH\Image\hoangtube.jpg')
INSERT dbo.CHITIETSACH(MaSach,TenSach,DonGiaBan,SoLuongTon,LanTaiBan,SoTrang,LoaiBia,NgayXuatBan,Hinh)VALUES('S0003',N'Dế mèn phiêu lưu kí',225000,65,2,176,N'Bìa cứng',CAST(N'2020-09-01' AS Date),N'D:\QL_SACH\Image\hoangtube.jpg')
INSERT dbo.CHITIETSACH(MaSach,TenSach,DonGiaBan,SoLuongTon,LanTaiBan,SoTrang,LoaiBia,NgayXuatBan,Hinh)VALUES('S0004',N'Tư duy nhanh và chậm',239000,40,7,612,N'Bìa mềm',CAST(N'2019-06-01' AS Date),N'D:\QL_SACH\Image\hoangtube.jpg')
INSERT dbo.CHITIETSACH(MaSach,TenSach,DonGiaBan,SoLuongTon,LanTaiBan,SoTrang,LoaiBia,NgayXuatBan,Hinh)VALUES('S0005',N'13 nguyên tắc nghĩ giàu, làm giàu',110000,34,34,339,N'Bìa mềm',CAST(N'2020-12-01' AS Date),N'D:\QL_SACH\Image\hoangtube.jpg')
INSERT dbo.CHITIETSACH(MaSach,TenSach,DonGiaBan,SoLuongTon,LanTaiBan,SoTrang,LoaiBia,NgayXuatBan,Hinh)VALUES('S0006',N'Mắt biếc',110000,80,44,300,N'Bìa mềm',CAST(N'2017-07-01' AS Date),N'D:\QL_SACH\Image\hoangtube.jpg')
INSERT dbo.CHITIETSACH(MaSach,TenSach,DonGiaBan,SoLuongTon,LanTaiBan,SoTrang,LoaiBia,NgayXuatBan,Hinh)VALUES('S0007',N'Nhà giả kim',69000,100,41,228,N'Bìa mềm',CAST(N'2013-10-01' AS Date),N'D:\QL_SACH\Image\hoangtube.jpg')
INSERT dbo.CHITIETSACH(MaSach,TenSach,DonGiaBan,SoLuongTon,LanTaiBan,SoTrang,LoaiBia,NgayXuatBan,Hinh)VALUES('S0008',N'Giải thích ngữ pháp tiếng Anh',180000,54,23,560,N'Bìa mềm',CAST(N'2020-04-01' AS Date),N'D:\QL_SACH\Image\hoangtube.jpg')
INSERT dbo.CHITIETSACH(MaSach,TenSach,DonGiaBan,SoLuongTon,LanTaiBan,SoTrang,LoaiBia,NgayXuatBan,Hinh)VALUES('S0009',N'Luyện thi năng lực Nhật ngữ N5',65000,30,7,132,N'Bìa mềm',CAST(N'2019-09-01' AS Date),N'D:\QL_SACH\Image\hoangtube.jpg')
INSERT dbo.CHITIETSACH(MaSach,TenSach,DonGiaBan,SoLuongTon,LanTaiBan,SoTrang,LoaiBia,NgayXuatBan,Hinh)VALUES('S0010',N'Đắc nhân tâm',76000,97,34,329,N'Bìa mềm',CAST(N'2016-03-01' AS Date),N'D:\QL_SACH\Image\hoangtube.jpg')
INSERT dbo.CHITIETSACH(MaSach,TenSach,DonGiaBan,SoLuongTon,LanTaiBan,SoTrang,LoaiBia,NgayXuatBan,Hinh)VALUES('S0011',N'Trên đường băng',80000,84,21,380,N'Bìa mềm',CAST(N'2017-10-01' AS Date),N'D:\QL_SACH\Image\hoangtube.jpg')
INSERT dbo.CHITIETSACH(MaSach,TenSach,DonGiaBan,SoLuongTon,LanTaiBan,SoTrang,LoaiBia,NgayXuatBan,Hinh)VALUES('S0012',N'7 thói quen hiệu quả',165000,48,10,480,N'Bìa cứng',CAST(N'2020-12-01' AS Date),N'D:\QL_SACH\Image\hoangtube.jpg')

INSERT dbo.KHACHHANG (MaKhachHang,TenKhachHang,Phai,DiaChi,SDT,Email,NgaySinh)VALUES('KH001',N'Trần Văn Tuấn',N'Nam',N'Hồ Chí Minh',0394020391,'tuantran@gmail.com',CAST(N'1990-12-09' AS Date))
INSERT dbo.KHACHHANG (MaKhachHang,TenKhachHang,Phai,DiaChi,SDT,Email,NgaySinh)VALUES('KH002',N'Trần Minh Hưng',N'Nam',N'Hồ Chí Minh',0909293993,'',CAST(N'2000-11-11' AS Date))
INSERT dbo.KHACHHANG (MaKhachHang,TenKhachHang,Phai,DiaChi,SDT,Email,NgaySinh)VALUES('KH003',N'Lệ Thị Phượng',N'Nữ',N'Bình Dương',0983727273,'lephuong@gmail.com',CAST(N'1987-10-04' AS Date))
INSERT dbo.KHACHHANG (MaKhachHang,TenKhachHang,Phai,DiaChi,SDT,Email,NgaySinh)VALUES('KH004',N'Bùi Thị Thu Cúc',N'Nữ',N'Hồ Chí Minh',0394853332,'',CAST(N'1995-7-03' AS Date))
INSERT dbo.KHACHHANG (MaKhachHang,TenKhachHang,Phai,DiaChi,SDT,Email,NgaySinh)VALUES('KH005',N'Vũ Thị Hồng Mộng',N'Nữ',N'Đồng Nai',0909192939,'hongmong@gmail.com',CAST(N'1980-2-12' AS Date))

INSERT dbo.PHANQUYEN (MaQuyen,TenQuyen,Mota)VALUES('admin','admin',N'Có đầy đủ tất cả các quyền')
INSERT dbo.PHANQUYEN (MaQuyen,TenQuyen,Mota)VALUES('staff','nhanvien',N'Chỉ có các quyền cơ bản của nhân viên')


INSERT dbo.TAIKHOAN (UserName,MaQuyen,Pass)VALUES('admin1','admin','87d9bb400c0634691f0e3baaf1e2fd0d')
INSERT dbo.TAIKHOAN (UserName,MaQuyen,Pass)VALUES('staff1','staff','87d9bb400c0634691f0e3baaf1e2fd0d')
INSERT dbo.TAIKHOAN (UserName,MaQuyen,Pass)VALUES('staff2','staff','87d9bb400c0634691f0e3baaf1e2fd0d')
INSERT dbo.TAIKHOAN (UserName,MaQuyen,Pass)VALUES('staff3','staff','87d9bb400c0634691f0e3baaf1e2fd0d')
INSERT dbo.TAIKHOAN (UserName,MaQuyen,Pass)VALUES('staff4','staff','87d9bb400c0634691f0e3baaf1e2fd0d')
INSERT dbo.TAIKHOAN (UserName,MaQuyen,Pass)VALUES('staff5','staff','87d9bb400c0634691f0e3baaf1e2fd0d')
INSERT dbo.TAIKHOAN (UserName,MaQuyen,Pass)VALUES('staff6','staff','87d9bb400c0634691f0e3baaf1e2fd0d')
INSERT dbo.TAIKHOAN (UserName,MaQuyen,Pass)VALUES('staff7','staff','87d9bb400c0634691f0e3baaf1e2fd0d')

INSERT dbo.ChucVu (MaChucVu,TenChucVu)VALUES('CV001',N'Chủ')
INSERT dbo.ChucVu (MaChucVu,TenChucVu)VALUES('CV002',N'Quản lý')
INSERT dbo.ChucVu (MaChucVu,TenChucVu)VALUES('CV003',N'Nhân viên')

INSERT dbo.NHANVIEN (MaNV,UserName,MaChucVu,TenNV,DiaChi,SoDienThoai,CMND,Phai,NgaySinh,TrangThai)VALUES('NV001','admin1','CV001',N'Võ Gia Huy',N'Hồ Chí Minh',0909292929,'11111111',N'Nam',CAST(N'1970-11-11' AS Date),N'Đang đi làm')
INSERT dbo.NHANVIEN (MaNV,UserName,MaChucVu,TenNV,DiaChi,SoDienThoai,CMND,Phai,NgaySinh,TrangThai)VALUES('NV002','staff1','CV002',N'Nguyễn Hoàng Thy',N'Đồng Nai',0909292444,'11111201',N'Nữ',CAST(N'1980-10-07' AS Date),N'Đang đi làm')
INSERT dbo.NHANVIEN (MaNV,UserName,MaChucVu,TenNV,DiaChi,SoDienThoai,CMND,Phai,NgaySinh,TrangThai)VALUES('NV003','staff2','CV003',N'Lê Hồng Ngọc',N'Hồ Chí Minh',0911002200,'111382949',N'Nữ',CAST(N'1992-03-12' AS Date),N'Đang đi làm')
INSERT dbo.NHANVIEN (MaNV,UserName,MaChucVu,TenNV,DiaChi,SoDienThoai,CMND,Phai,NgaySinh,TrangThai)VALUES('NV004','staff3','CV003',N'La Thanh Hải',N'Hồ Chí Minh',0928382848,'132382949',N'Nam',CAST(N'1995-05-08' AS Date),N'Đang đi làm')
INSERT dbo.NHANVIEN (MaNV,UserName,MaChucVu,TenNV,DiaChi,SoDienThoai,CMND,Phai,NgaySinh,TrangThai)VALUES('NV005','staff4','CV003',N'Lê Trung Dũng',N'Bình Dương',0928380394,'0304382949',N'Nam',CAST(N'1993-12-20' AS Date),N'Đang đi làm')
INSERT dbo.NHANVIEN (MaNV,UserName,MaChucVu,TenNV,DiaChi,SoDienThoai,CMND,Phai,NgaySinh,TrangThai)VALUES('NV006','staff5','CV003',N'Hà Huy Tuấn',N'Hồ Chí Minh',093380394,'011112949',N'Nam',CAST(N'1997-02-11' AS Date),N'Đang đi làm')
INSERT dbo.NHANVIEN (MaNV,UserName,MaChucVu,TenNV,DiaChi,SoDienThoai,CMND,Phai,NgaySinh,TrangThai)VALUES('NV007','staff6','CV003',N'Nguyễn An',N'Hồ Chí Minh',093110884,'011112949',N'Nam',CAST(N'1988-03-11' AS Date),N'Đã nghỉ việc')
INSERT dbo.NHANVIEN (MaNV,UserName,MaChucVu,TenNV,DiaChi,SoDienThoai,CMND,Phai,NgaySinh,TrangThai)VALUES('NV008','staff7','CV003',N'Lê Thủy',N'Đồng Nai',093110224,'011112949',N'Nữ',CAST(N'1989-02-12' AS Date),N'Đang xử lý')

INSERT dbo.HOADON (SoHD,MaKhachHang,MaNV,NgayHoaDon,TrangThai)VALUES('HD001','KH001','NV003',CAST(N'2021-02-11' AS Date),N'Đã thanh toán')
INSERT dbo.HOADON (SoHD,MaKhachHang,MaNV,NgayHoaDon,TrangThai)VALUES('HD002','KH003','NV004',CAST(N'2021-02-12' AS Date),N'Đã thanh toán')
INSERT dbo.HOADON (SoHD,MaKhachHang,MaNV,NgayHoaDon,TrangThai)VALUES('HD003','KH002','NV005',CAST(N'2021-02-13' AS Date),N'Đã thanh toán')
INSERT dbo.HOADON (SoHD,MaKhachHang,MaNV,NgayHoaDon,TrangThai)VALUES('HD004','KH004','NV006',CAST(N'2021-02-14' AS Date),N'Đã thanh toán')
INSERT dbo.HOADON (SoHD,MaKhachHang,MaNV,NgayHoaDon,TrangThai)VALUES('HD005','KH005','NV003',CAST(N'2021-02-15' AS Date),N'Đã thanh toán')
INSERT dbo.HOADON (SoHD,MaKhachHang,MaNV,NgayHoaDon,TrangThai)VALUES('HD006','KH001','NV004',CAST(N'2021-02-15' AS Date),N'Đã thanh toán')
INSERT dbo.HOADON (SoHD,MaKhachHang,MaNV,NgayHoaDon,TrangThai)VALUES('HD007','KH002','NV003',CAST(N'2021-02-16' AS Date),N'Đã thanh toán')

INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD001','S0001',1)
INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD001','S0002',1)
INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD002','S0004',1)
INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD002','S0008',1)
INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD002','S0012',1)
INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD003','S0004',2)
INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD004','S0001',1)
INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD004','S0002',1)
INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD004','S0007',1)
INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD004','S0009',1)
INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD005','S0008',3)
INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD006','S0011',1)
INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD006','S0012',1)
INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD007','S0003',1)
INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD007','S0010',1)
INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD007','S0005',1)
--INSERT dbo.CT_HOADON (SoHD,MaSach,SoLuong)VALUES('HD002','S0002',600)

INSERT dbo.PHIEUNHAPSACH (SoPNS,MaNV,NgayNhap)VALUES('PN001','NV004',CAST(N'2021-01-10' AS Date))
INSERT dbo.PHIEUNHAPSACH (SoPNS,MaNV,NgayNhap)VALUES('PN002','NV005',CAST(N'2021-01-10' AS Date))
INSERT dbo.PHIEUNHAPSACH (SoPNS,MaNV,NgayNhap)VALUES('PN003','NV006',CAST(N'2021-01-15' AS Date))
INSERT dbo.PHIEUNHAPSACH (SoPNS,MaNV,NgayNhap)VALUES('PN004','NV004',CAST(N'2021-01-22' AS Date))
INSERT dbo.PHIEUNHAPSACH (SoPNS,MaNV,NgayNhap)VALUES('PN005','NV005',CAST(N'2021-02-01' AS Date))

INSERT dbo.CHITIETPHIEUNHAP(SoPNS,MaSach,SoLuongNhap,DonGiaNhap)VALUES('PN001','S0001',50,40000)
INSERT dbo.CHITIETPHIEUNHAP(SoPNS,MaSach,SoLuongNhap,DonGiaNhap)VALUES('PN001','S0002',50,20000)
INSERT dbo.CHITIETPHIEUNHAP(SoPNS,MaSach,SoLuongNhap,DonGiaNhap)VALUES('PN001','S0003',50,150000)
INSERT dbo.CHITIETPHIEUNHAP(SoPNS,MaSach,SoLuongNhap,DonGiaNhap)VALUES('PN002','S0004',60,150000)
INSERT dbo.CHITIETPHIEUNHAP(SoPNS,MaSach,SoLuongNhap,DonGiaNhap)VALUES('PN002','S0005',60,60000)
INSERT dbo.CHITIETPHIEUNHAP(SoPNS,MaSach,SoLuongNhap,DonGiaNhap)VALUES('PN002','S0006',60,60000)
INSERT dbo.CHITIETPHIEUNHAP(SoPNS,MaSach,SoLuongNhap,DonGiaNhap)VALUES('PN003','S0007',50,40000)
INSERT dbo.CHITIETPHIEUNHAP(SoPNS,MaSach,SoLuongNhap,DonGiaNhap)VALUES('PN003','S0008',40,110000)
INSERT dbo.CHITIETPHIEUNHAP(SoPNS,MaSach,SoLuongNhap,DonGiaNhap)VALUES('PN003','S0009',55,35000)
INSERT dbo.CHITIETPHIEUNHAP(SoPNS,MaSach,SoLuongNhap,DonGiaNhap)VALUES('PN003','S0010',55,40000)
INSERT dbo.CHITIETPHIEUNHAP(SoPNS,MaSach,SoLuongNhap,DonGiaNhap)VALUES('PN004','S0011',70,45000)
INSERT dbo.CHITIETPHIEUNHAP(SoPNS,MaSach,SoLuongNhap,DonGiaNhap)VALUES('PN005','S0012',60,130000)
INSERT dbo.CHITIETPHIEUNHAP(SoPNS,MaSach,SoLuongNhap,DonGiaNhap)VALUES('PN005','S0002',30,20000)
INSERT dbo.CHITIETPHIEUNHAP(SoPNS,MaSach,SoLuongNhap,DonGiaNhap)VALUES('PN005','S0007',30,40000)

go

/*   ---------------------------------     TRIGGER    ------------------------------------- */
--Create Trigger tr_SuaCTHD On CT_HOADON
--For Update As
--Declare @D int
--Select @D = Count(*)
--From CHITIETSACH a, DELETED b, INSERTED c
--Where a.MaSach = b.MaSach
--      And a.MaSach = c.MaSach
--      And SoLuongTon + b.SoLuong - c.SoLuong < 0
--If (@D > 0 )
-- Begin
--   Print 'Không đủ hàng để bán'
--   RollBack Tran
--   Return
-- End
 go



Create Trigger tr_XoaCTHD On CT_HOADON
For Delete
As
  Update CHITIETSACH Set SoLuongTon = SoLuongTon + SoLuong From DELETED 
  Where CHITIETSACH.MaSach= DELETED.MaSach

--Cập nhật số lượng tồn trong bảng SACH
Update CHITIETSACH Set SoLuongTon =SoLuongTon + b.SoLuong - c.SoLuong
From SACH a, DELETED b, INSERTED c
Where a.MaSach = b.MaSach And a.MaSach = c.MaSach
go
/* Roles permissions */

/* Users permissions */

/* cập nhật hàng trong kho sau khi đặt hàng hoặc cập nhật */
CREATE TRIGGER trg_DatHang ON CT_HOADON AFTER INSERT AS 
BEGIN
	UPDATE CHITIETSACH
	SET SoLuongTon = SoLuongTon - (
		SELECT SoLuong
		FROM inserted
		WHERE MaSach = CHITIETSACH.MaSach
	)
	FROM CHITIETSACH
	JOIN inserted ON CHITIETSACH.MaSach = inserted.MaSach
END
GO
/* cập nhật hàng trong kho sau khi cập nhật đặt hàng */
CREATE TRIGGER trg_CapNhatDatHang on CT_HOADON after update AS
BEGIN
   UPDATE CHITIETSACH SET SoLuongTon = SoLuongTon -
	   (SELECT SoLuong FROM inserted WHERE MaSach = CHITIETSACH.MaSach) +
	   (SELECT SoLuong FROM deleted WHERE MaSach = CHITIETSACH.MaSach)
   FROM CHITIETSACH
   JOIN deleted ON CHITIETSACH.MaSach = deleted.MaSach
end
GO
/* cập nhật hàng trong kho sau khi hủy đặt hàng */
create TRIGGER trg_HuyDatHang ON CT_HoaDon FOR DELETE AS 
BEGIN
	UPDATE CHITIETSACH
	SET SoLuongTon = SoLuongTon + (SELECT SoLuong FROM deleted WHERE MaSach= CHITIETSACH.MaSach)
	FROM CHITIETSACH
	JOIN deleted ON CHITIETSACH.MaSach = deleted.MaSach
END


--CREATE TRIGGER trg_DatHang ON CT_HOADON AFTER INSERT AS 
--BEGIN
--	UPDATE CHITIETSACH
--	SET SoLuongTon = SoLuongTon - (
--		SELECT SoLuong
--		FROM inserted
--		WHERE MaSach = CHITIETSACH.MaSach
--	)
--	FROM CHITIETSACH
--	JOIN inserted ON CHITIETSACH.MaSach = inserted.MaSach
--	If (CHITIETSACH.SoLuongTon<0)
-- Begin
--   Print 'Không đủ hàng để bán'
--   RollBack Tran
--   Return
-- End
--END
--GO