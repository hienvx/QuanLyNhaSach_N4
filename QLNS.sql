USE [master]
GO
/****** Object:  Database [BOOK]    Script Date: 7/2/2021 9:28:09 PM ******/
CREATE DATABASE [BOOK]
ALTER DATABASE [BOOK] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BOOK].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BOOK] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BOOK] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BOOK] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BOOK] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BOOK] SET ARITHABORT OFF 
GO
ALTER DATABASE [BOOK] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BOOK] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BOOK] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BOOK] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BOOK] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BOOK] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BOOK] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BOOK] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BOOK] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BOOK] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BOOK] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BOOK] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BOOK] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BOOK] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BOOK] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BOOK] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BOOK] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BOOK] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BOOK] SET  MULTI_USER 
GO
ALTER DATABASE [BOOK] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BOOK] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BOOK] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BOOK] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BOOK] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BOOK] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BOOK', N'ON'
GO
ALTER DATABASE [BOOK] SET QUERY_STORE = OFF
GO
USE [BOOK]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 7/2/2021 9:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaChiTietHoaDon] [nvarchar](10) NOT NULL,
	[MaHoaDon] [nvarchar](10) NULL,
	[MaSach] [nvarchar](10) NULL,
	[SoLuong] [int] NULL,
	[GiaBan] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaChiTietHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhapSach]    Script Date: 7/2/2021 9:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhapSach](
	[MaChiTietPhieuNhapSach] [nvarchar](10) NOT NULL,
	[MaPhieuNhapSach] [nvarchar](10) NULL,
	[MaSach] [nvarchar](10) NULL,
	[SoLuong] [int] NULL,
	[GiaNhap] [int] NULL,
 CONSTRAINT [PK_ChiTietPhieuNhapSach] PRIMARY KEY CLUSTERED 
(
	[MaChiTietPhieuNhapSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 7/2/2021 9:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [nvarchar](10) NOT NULL,
	[MaKhachHang] [nvarchar](10) NULL,
	[MaNhanVien] [nvarchar](10) NULL,
	[NgayLapHoaDon] [datetime] NULL,
	[TongTien] [int] NULL,
	[DiemThuong] [int] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 7/2/2021 9:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [nvarchar](10) NOT NULL,
	[TenKhachHang] [ntext] NULL,
	[CMND] [ntext] NULL,
	[SoDienThoai] [ntext] NULL,
	[DiemTichLuy] [int] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 7/2/2021 9:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [nvarchar](10) NOT NULL,
	[TenNhanVien] [ntext] NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi] [ntext] NULL,
	[SoDienThoai] [ntext] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhapSach]    Script Date: 7/2/2021 9:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhapSach](
	[MaPhieuNhapSach] [nvarchar](10) NOT NULL,
	[NgayNhapSach] [datetime] NULL,
	[MaNhanVien] [nvarchar](10) NULL,
	[TongTien] [int] NULL,
 CONSTRAINT [PK_PhieuNhapSach] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhapSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuiDinh]    Script Date: 7/2/2021 9:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuiDinh](
	[MaQD] [nvarchar](10) NOT NULL,
	[TenQD] [ntext] NULL,
	[GiaTri] [int] NULL,
	[SuDung] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaQD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 7/2/2021 9:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [nvarchar](10) NOT NULL,
	[TenSach] [ntext] NULL,
	[TacGia] [ntext] NULL,
	[TheLoai] [ntext] NULL,
	[NhaXuatBan] [ntext] NULL,
	[NamXuatBan] [int] NULL,
	[GiaBan] [int] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_SACH] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 7/2/2021 9:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTaiKhoan] [nvarchar](10) NOT NULL,
	[TenDangNhap] [ntext] NULL,
	[MatKhau] [ntext] NULL,
	[MaNhanVien] [nvarchar](10) NULL,
	[LoaiTK] [int] NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSach], [SoLuong], [GiaBan]) VALUES (N'CD001', N'HD001', N'SA001', 1, 65000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSach], [SoLuong], [GiaBan]) VALUES (N'CD002', N'HD001', N'SA002', 1, 75000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSach], [SoLuong], [GiaBan]) VALUES (N'CD003', N'HD001', N'SA005', 2, 35000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSach], [SoLuong], [GiaBan]) VALUES (N'CD004', N'HD002', N'SA001', 5, 65000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSach], [SoLuong], [GiaBan]) VALUES (N'CD005', N'HD003', N'SA001', 1, 65000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSach], [SoLuong], [GiaBan]) VALUES (N'CD006', N'HD003', N'SA002', 1, 75000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSach], [SoLuong], [GiaBan]) VALUES (N'CD007', N'HD003', N'SA003', 1, 50000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSach], [SoLuong], [GiaBan]) VALUES (N'CD008', N'HD003', N'SA004', 1, 60000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSach], [SoLuong], [GiaBan]) VALUES (N'CD009', N'HD003', N'SA005', 1, 35000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSach], [SoLuong], [GiaBan]) VALUES (N'CD010', N'HD004', N'SA001', 1, 50000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSach], [SoLuong], [GiaBan]) VALUES (N'CD011', N'HD004', N'SA003', 1, 60000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSach], [SoLuong], [GiaBan]) VALUES (N'CD012', N'HD005', N'SA001', 1, 60000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSach], [SoLuong], [GiaBan]) VALUES (N'CD013', N'HD005', N'SA004', 2, 50000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSach], [SoLuong], [GiaBan]) VALUES (N'CD014', N'HD007', N'SA004', 5, 75000)
GO
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP001', N'PN001', N'SA001', 20, 30000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP002', N'PN001', N'SA002', 25, 50000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP003', N'PN001', N'SA003', 50, 25000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP004', N'PN001', N'SA004', 10, 30000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP005', N'PN002', N'SA005', 100, 20000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP006', N'PN002', N'SA006', 15, 50000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP007', N'PN003', N'SA001', 5, 30000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP008', N'PN003', N'SA005', 1, 30000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP009', N'PN004', N'SA003', 1, 50000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP010', N'PN005', N'SA005', 1, 60000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP011', N'PN005', N'SA002', 2, 75000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP012', N'PN006', N'SA001', 1, 25000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP013', N'PN007', N'SA001', 1, 20000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP014', N'PN007', N'SA002', 2, 40000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP015', N'PN008', N'SA001', 1, 300000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP016', N'PN008', N'SA002', 3, 40000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP017', N'PN009', N'SA004', 1, 30000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP018', N'PN009', N'SA005', 1, 20000)
INSERT [dbo].[ChiTietPhieuNhapSach] ([MaChiTietPhieuNhapSach], [MaPhieuNhapSach], [MaSach], [SoLuong], [GiaNhap]) VALUES (N'CP019', N'PN012', N'SA004', 10, 50000)
GO
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayLapHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD001', N'KH001', N'NV003', CAST(N'2018-12-20T00:00:00.000' AS DateTime), 210000, 2)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayLapHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD002', N'KH002', N'NV003', CAST(N'2019-01-01T00:00:00.000' AS DateTime), 325000, 3)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayLapHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD003', N'KH004', N'NV002', CAST(N'2018-12-12T00:00:00.000' AS DateTime), 285000, 2)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayLapHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD004', N'KH003', N'NV001', CAST(N'2019-01-02T11:04:54.630' AS DateTime), 110000, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayLapHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD005', N'KH003', N'NV001', CAST(N'2019-01-04T07:09:02.443' AS DateTime), 160000, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayLapHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD006', N'KH005', N'NV001', CAST(N'2019-01-04T10:05:36.417' AS DateTime), 0, 0)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayLapHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD007', N'KH002', N'NV001', CAST(N'2021-07-02T19:41:12.470' AS DateTime), 375000, 3)
GO
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [CMND], [SoDienThoai], [DiemTichLuy]) VALUES (N'KH001', N'Nguyễn Long Hồ', N'241003212', N'035371888', 2)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [CMND], [SoDienThoai], [DiemTichLuy]) VALUES (N'KH002', N'Đỗ Minh Hiếu', N'210234050', N'031294485', 6)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [CMND], [SoDienThoai], [DiemTichLuy]) VALUES (N'KH003', N'Hồ Thiên Hổ', N'230459662', N'023485555', 2)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [CMND], [SoDienThoai], [DiemTichLuy]) VALUES (N'KH004', N'Cao Thiên Hoàng', N'231456042', N'049311239', 2)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [CMND], [SoDienThoai], [DiemTichLuy]) VALUES (N'KH005', N'Nguyễn Văn Bình', N'231205371', N'0351827707', 0)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [CMND], [SoDienThoai], [DiemTichLuy]) VALUES (N'KH006', N'Nguyễn Hồng Đào', N'210422432', N'0361739444', 0)
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [DiaChi], [SoDienThoai]) VALUES (N'NV001', N'Lê Tống Minh Hiếu', CAST(N'1998-11-20T00:00:00.000' AS DateTime), N'191 Đồng Đen, Tân Bình', N'0932345134')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [DiaChi], [SoDienThoai]) VALUES (N'NV002', N'Vũ Quốc Hội', CAST(N'1998-01-01T00:00:00.000' AS DateTime), N'17A đường 1, Q7', N'0365141006')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [DiaChi], [SoDienThoai]) VALUES (N'NV003', N'Trần Văn Huân', CAST(N'1997-02-01T00:00:00.000' AS DateTime), N'191 Thống Nhất, Gò Vấp', N'035112036')
GO
INSERT [dbo].[PhieuNhapSach] ([MaPhieuNhapSach], [NgayNhapSach], [MaNhanVien], [TongTien]) VALUES (N'PN001', CAST(N'2018-12-20T00:00:00.000' AS DateTime), N'NV001', 3400000)
INSERT [dbo].[PhieuNhapSach] ([MaPhieuNhapSach], [NgayNhapSach], [MaNhanVien], [TongTien]) VALUES (N'PN002', CAST(N'2018-12-19T00:00:00.000' AS DateTime), N'NV002', 2750000)
INSERT [dbo].[PhieuNhapSach] ([MaPhieuNhapSach], [NgayNhapSach], [MaNhanVien], [TongTien]) VALUES (N'PN003', CAST(N'2019-01-02T10:03:59.527' AS DateTime), N'NV001', 180000)
INSERT [dbo].[PhieuNhapSach] ([MaPhieuNhapSach], [NgayNhapSach], [MaNhanVien], [TongTien]) VALUES (N'PN004', CAST(N'2019-01-02T22:59:33.637' AS DateTime), N'NV003', 50000)
INSERT [dbo].[PhieuNhapSach] ([MaPhieuNhapSach], [NgayNhapSach], [MaNhanVien], [TongTien]) VALUES (N'PN005', CAST(N'2019-01-03T23:22:58.167' AS DateTime), N'NV001', 210000)
INSERT [dbo].[PhieuNhapSach] ([MaPhieuNhapSach], [NgayNhapSach], [MaNhanVien], [TongTien]) VALUES (N'PN006', CAST(N'2019-01-04T02:48:37.840' AS DateTime), N'NV001', 25000)
INSERT [dbo].[PhieuNhapSach] ([MaPhieuNhapSach], [NgayNhapSach], [MaNhanVien], [TongTien]) VALUES (N'PN007', CAST(N'2019-01-04T07:07:05.297' AS DateTime), N'NV001', 100000)
INSERT [dbo].[PhieuNhapSach] ([MaPhieuNhapSach], [NgayNhapSach], [MaNhanVien], [TongTien]) VALUES (N'PN008', CAST(N'2019-01-04T10:01:56.740' AS DateTime), N'NV001', 420000)
INSERT [dbo].[PhieuNhapSach] ([MaPhieuNhapSach], [NgayNhapSach], [MaNhanVien], [TongTien]) VALUES (N'PN009', CAST(N'2019-01-04T10:04:14.690' AS DateTime), N'NV001', 50000)
INSERT [dbo].[PhieuNhapSach] ([MaPhieuNhapSach], [NgayNhapSach], [MaNhanVien], [TongTien]) VALUES (N'PN010', CAST(N'2021-07-02T19:20:29.667' AS DateTime), N'NV001', 0)
INSERT [dbo].[PhieuNhapSach] ([MaPhieuNhapSach], [NgayNhapSach], [MaNhanVien], [TongTien]) VALUES (N'PN011', CAST(N'2021-07-02T19:25:28.833' AS DateTime), N'NV001', 0)
INSERT [dbo].[PhieuNhapSach] ([MaPhieuNhapSach], [NgayNhapSach], [MaNhanVien], [TongTien]) VALUES (N'PN012', CAST(N'2021-07-02T19:31:03.037' AS DateTime), N'NV001', 500000)
GO
INSERT [dbo].[QuiDinh] ([MaQD], [TenQD], [GiaTri], [SuDung]) VALUES (N'DEPT_MAX', N'Tiền nợ tối đa', 20000, 1)
INSERT [dbo].[QuiDinh] ([MaQD], [TenQD], [GiaTri], [SuDung]) VALUES (N'IN_MIN', N'Số lượng nhập tối thiểu', 150, 1)
INSERT [dbo].[QuiDinh] ([MaQD], [TenQD], [GiaTri], [SuDung]) VALUES (N'IN_REM', N'Lượng tồn tối thiểu trước khi nhập', 300, 1)
INSERT [dbo].[QuiDinh] ([MaQD], [TenQD], [GiaTri], [SuDung]) VALUES (N'SELL_REM', N'Lượng tồn tối thiểu sau khi bán', 20, 1)
GO
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan], [NamXuatBan], [GiaBan], [SoLuong]) VALUES (N'SA001', N'Nhập môn lập trình', N'KHTN', N'Khoa học', N'Kĩ thuật', 2007, 65000, 21)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan], [NamXuatBan], [GiaBan], [SoLuong]) VALUES (N'SA002', N'Kĩ thuật lập trình', N'KHTN', N'Khoa học', N'Kĩ thuật', 2007, 75000, 32)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan], [NamXuatBan], [GiaBan], [SoLuong]) VALUES (N'SA003', N'Tư tưởng HCM', N'Bộ GDĐT', N'Chính trị', N'Chính trị Quốc gia sự thật', 2002, 50000, 50)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan], [NamXuatBan], [GiaBan], [SoLuong]) VALUES (N'SA004', N'Đường lối CMĐCS', N'Bộ GDĐT', N'Chính trị', N'Chính trị Quốc gia sự thật', 2000, 60000, 14)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan], [NamXuatBan], [GiaBan], [SoLuong]) VALUES (N'SA005', N'Toán cao cấp C1', N'Nguyễn Quốc Hưng', N'Khoa học', N'Đại học sư phạm', 2003, 35000, 102)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan], [NamXuatBan], [GiaBan], [SoLuong]) VALUES (N'SA006', N'Vật lí đại cương 2', N'Nguyễn Thành Vấn', N'Khoa học', N'Kĩ thuật', 2002, 70000, 35)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan], [NamXuatBan], [GiaBan], [SoLuong]) VALUES (N'SA007', N'Tự học C#', N'NON', N'Kĩ thuật', N'KHTN', 2019, 60000, 20)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [TheLoai], [NhaXuatBan], [NamXuatBan], [GiaBan], [SoLuong]) VALUES (N'SA008', N'Sách mới', N'Chưa xác định', N'Chưa xác định', N'ABC', 2019, 15000, 10)
GO
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaNhanVien], [LoaiTK]) VALUES (N'TK001', N'admin', N'123', NULL, 0)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaNhanVien], [LoaiTK]) VALUES (N'TK002', N'hieu', N'hieu123', N'NV001', 1)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaNhanVien], [LoaiTK]) VALUES (N'TK003', N'hoi', N'hoi123', N'NV002', 1)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaNhanVien], [LoaiTK]) VALUES (N'TK004', N'huan', N'huan123', N'NV003', 1)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaNhanVien], [LoaiTK]) VALUES (N'TK005', N'hieu2', N'123', N'NV001', 1)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaNhanVien], [LoaiTK]) VALUES (N'TK006', N'hieu@gmail.com', N'123456', N'NV001', 1)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaNhanVien], [LoaiTK]) VALUES (N'TK007', N'hieu3', N'123', N'NV001', 1)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaNhanVien], [LoaiTK]) VALUES (N'TK008', N'huan123', N'123', N'NV003', 1)
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_Sach]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhapSach]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhapSach_PhieuNhapSach] FOREIGN KEY([MaPhieuNhapSach])
REFERENCES [dbo].[PhieuNhapSach] ([MaPhieuNhapSach])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhapSach] CHECK CONSTRAINT [FK_ChiTietPhieuNhapSach_PhieuNhapSach]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhapSach]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhapSach_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhapSach] CHECK CONSTRAINT [FK_ChiTietPhieuNhapSach_Sach]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[PhieuNhapSach]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhapSach_NhanVien1] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PhieuNhapSach] CHECK CONSTRAINT [FK_PhieuNhapSach_NhanVien1]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NhanVien]
GO
USE [master]
GO
ALTER DATABASE [BOOK] SET  READ_WRITE 
GO
