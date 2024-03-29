USE [CHTC]
GO
/****** Object:  Table [dbo].[tbChiTietDh]    Script Date: 5/26/2023 9:15:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbChiTietDh](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDDonHang] [int] NULL,
	[IDSanPham] [int] NULL,
	[IDThuCung] [int] NULL,
	[SoLuong] [int] NULL,
	[Gia] [float] NULL,
	[IDTiemChung] [int] NULL,
 CONSTRAINT [PK_tbChiTietDh] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbChiTietDN]    Script Date: 5/26/2023 9:15:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbChiTietDN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDDonNhap] [int] NULL,
	[SoLuong] [int] NULL,
	[Gia] [float] NULL,
	[IDLoaiHang] [int] NULL,
 CONSTRAINT [PK_tbChiTietDN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbDonDatHang]    Script Date: 5/26/2023 9:15:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbDonDatHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDNV] [int] NULL,
	[MaDonHang] [nvarchar](20) NULL,
	[NgayDatHang] [date] NULL,
	[IDKhachHang] [int] NULL,
 CONSTRAINT [PK_tbDonDatHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbDonNhapHang]    Script Date: 5/26/2023 9:15:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbDonNhapHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDNV] [int] NULL,
	[NgayNhap] [date] NULL,
	[IDNCC] [int] NULL,
 CONSTRAINT [PK_tbDonNhapHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbKhacHang]    Script Date: 5/26/2023 9:15:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbKhacHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDTaiKhoan] [int] NULL,
	[HoVaTen] [nvarchar](50) NULL,
	[SDT] [nvarchar](10) NULL,
	[Email] [nvarchar](150) NULL,
	[DiaChi] [nvarchar](300) NULL,
 CONSTRAINT [PK_tbKhacHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbLoaiHang]    Script Date: 5/26/2023 9:15:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbLoaiHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaLH] [nvarchar](10) NULL,
	[TenLH] [nvarchar](20) NULL,
 CONSTRAINT [PK_tbLoaiHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbNhaCC]    Script Date: 5/26/2023 9:15:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbNhaCC](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaNhaCc] [nvarchar](10) NULL,
	[TenNhaCc] [nvarchar](20) NULL,
	[SDT] [nvarchar](10) NULL,
	[DiaChi] [nvarchar](150) NULL,
 CONSTRAINT [PK_tbNhaCC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbNhanVien]    Script Date: 5/26/2023 9:15:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbNhanVien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDTaiKhoan] [int] NULL,
	[MaNhanVien] [nvarchar](10) NULL,
	[TenNhanVien] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](150) NULL,
	[NgaySinh] [date] NULL,
	[SDT] [nvarchar](10) NULL,
	[Email] [nvarchar](30) NULL,
 CONSTRAINT [PK_tbNhanVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbSanPham]    Script Date: 5/26/2023 9:15:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbSanPham](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaSanPham] [nvarchar](10) NULL,
	[TenSanPham] [nvarchar](50) NULL,
	[MoTa] [nvarchar](200) NULL,
	[AnhSp] [nvarchar](max) NULL,
	[IDLoaiHang] [int] NULL,
	[TinhTrang] [bit] NULL,
	[Gia] [float] NULL,
 CONSTRAINT [PK_tbSanPham] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbTaiKhoan]    Script Date: 5/26/2023 9:15:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbTaiKhoan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [nvarchar](30) NULL,
	[MatKhau] [nvarchar](max) NULL,
	[Quyen] [bit] NULL,
 CONSTRAINT [PK_tbTaiKhoan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbThuCung]    Script Date: 5/26/2023 9:15:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbThuCung](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaThuCung] [nvarchar](10) NULL,
	[Ten] [nvarchar](20) NULL,
	[Tuoi] [int] NULL,
	[GioiTinh] [bit] NULL,
	[Giong] [nvarchar](150) NULL,
	[MoTa] [nvarchar](150) NULL,
	[AnhTC] [nvarchar](max) NULL,
	[IDLoaiHang] [int] NULL,
	[TInhTrang] [bit] NULL,
	[Gia] [float] NULL,
	[TrangThai] [bit] NULL,
	[IDHDN] [int] NULL,
 CONSTRAINT [PK_tbThuCung] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbTiemChung]    Script Date: 5/26/2023 9:15:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbTiemChung](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaTiemChung] [nvarchar](10) NULL,
	[Ten] [nvarchar](30) NULL,
	[MoTa] [nvarchar](150) NULL,
	[IDLoaiHang] [int] NULL,
	[Gia] [float] NULL,
 CONSTRAINT [PK_tbTiemChung] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbChiTietDh] ON 

INSERT [dbo].[tbChiTietDh] ([ID], [IDDonHang], [IDSanPham], [IDThuCung], [SoLuong], [Gia], [IDTiemChung]) VALUES (6, 2, 1, 1, 3, 8570000, 2)
INSERT [dbo].[tbChiTietDh] ([ID], [IDDonHang], [IDSanPham], [IDThuCung], [SoLuong], [Gia], [IDTiemChung]) VALUES (10, 3, 5, 2, 5, 3965000, 5)
INSERT [dbo].[tbChiTietDh] ([ID], [IDDonHang], [IDSanPham], [IDThuCung], [SoLuong], [Gia], [IDTiemChung]) VALUES (11, 4, 4, 4, 3, 3410000, 1)
INSERT [dbo].[tbChiTietDh] ([ID], [IDDonHang], [IDSanPham], [IDThuCung], [SoLuong], [Gia], [IDTiemChung]) VALUES (13, 3, 3, 9, 2, 3170000, 2)
INSERT [dbo].[tbChiTietDh] ([ID], [IDDonHang], [IDSanPham], [IDThuCung], [SoLuong], [Gia], [IDTiemChung]) VALUES (14, 4, 7, 10, 3, 5370000, 2)
INSERT [dbo].[tbChiTietDh] ([ID], [IDDonHang], [IDSanPham], [IDThuCung], [SoLuong], [Gia], [IDTiemChung]) VALUES (15, 2, 1, 1, 2, 7050000, 1)
INSERT [dbo].[tbChiTietDh] ([ID], [IDDonHang], [IDSanPham], [IDThuCung], [SoLuong], [Gia], [IDTiemChung]) VALUES (16, 2, 6, 10, 4, 6490000, 3)
INSERT [dbo].[tbChiTietDh] ([ID], [IDDonHang], [IDSanPham], [IDThuCung], [SoLuong], [Gia], [IDTiemChung]) VALUES (17, 6, 1, 2, 3, 8090000, 3)
SET IDENTITY_INSERT [dbo].[tbChiTietDh] OFF
GO
SET IDENTITY_INSERT [dbo].[tbDonDatHang] ON 

INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (2, 11, N'DH001', CAST(N'2023-05-19' AS Date), 11)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (3, 11, N'DH002', CAST(N'2023-05-18' AS Date), 1)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (4, 16, N'DH003', CAST(N'2023-05-17' AS Date), 1)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (5, 15, N'DH004', CAST(N'2023-05-16' AS Date), 2)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (6, 14, N'DH005', CAST(N'2023-05-15' AS Date), 2)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (7, 14, N'DH006', CAST(N'2023-05-14' AS Date), 3)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (8, 15, N'DH007', CAST(N'2023-05-13' AS Date), 3)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (9, 12, N'DH008', CAST(N'2023-05-12' AS Date), 3)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (10, 12, N'DH009', CAST(N'2023-05-11' AS Date), 5)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (11, 13, N'DH010', CAST(N'2023-05-10' AS Date), 6)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (12, 16, N'DH011', CAST(N'2023-05-09' AS Date), 5)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (13, 17, N'DH012', CAST(N'2023-05-08' AS Date), 20)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (14, 18, N'DH013', CAST(N'2023-05-07' AS Date), 20)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (15, 19, N'DH014', CAST(N'2023-05-06' AS Date), 18)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (16, 20, N'DH015', CAST(N'2023-05-05' AS Date), 8)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (17, 20, N'DH016', CAST(N'2023-05-04' AS Date), 7)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (18, 20, N'DH017', CAST(N'2023-05-03' AS Date), 6)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (19, 18, N'DH018', CAST(N'2023-05-02' AS Date), 4)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (20, 19, N'DH019', CAST(N'2023-05-01' AS Date), 10)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (21, 17, N'DH020', CAST(N'2023-04-30' AS Date), 15)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (22, 15, N'DH021', CAST(N'2023-04-15' AS Date), 19)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (23, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbDonDatHang] ([ID], [IDNV], [MaDonHang], [NgayDatHang], [IDKhachHang]) VALUES (24, 11, N'DH05', CAST(N'2023-05-18' AS Date), 2)
SET IDENTITY_INSERT [dbo].[tbDonDatHang] OFF
GO
SET IDENTITY_INSERT [dbo].[tbKhacHang] ON 

INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (1, NULL, N'Nguyễn Van A', N'0123456789', N'nguyenvana@gmail.com', N'234 Hoàng Quốc Việt , Hà Nội')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (2, NULL, N'Trần Thị B', N'0987654321', N'tranthib@gmail.com', N'45 Đường Phạm Văn Đồng')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (3, NULL, N'Lê Minh C', N'0369123456', N'leminhc@yahoo.com', N'789 Ðu?ng Z')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (4, NULL, N'Phạm Thanh D', N'0912345678', N'phamthanhd@hotmail.com', N'1011 Ðu?ng T')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (5, NULL, N'Truong Ðức E', N'0978563412', N'truongduce@gmail.com', N'1213 Ðu?ng S')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (6, NULL, N'Luong Mỹ F', N'0888888888', N'luongmyf@yahoo.com', N'1415 Ðu?ng R')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (7, NULL, N'Ðỗ Diệu G', N'0909090909', N'dodieug@yahoo.com', N'1617 Ðu?ng Q')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (8, NULL, N'Võ Van H', N'0999999999', N'vovanh@hotmail.com', N'1819 Ðu?ng P')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (9, NULL, N'Hông Nhung I', N'0833333333', N'hongnhungi@gmail.com', N'2021 Ðu?ng O')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (10, NULL, N'Phan Thị K', N'0966666666', N'phanthik@yahoo.com', N'2223 Ðu?ng N')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (11, NULL, N'Duong Ngọc L', N'0355555555', N'duongngocl@gmail.com', N'2425 Ðu?ng M')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (12, NULL, N'Lại Thị M', N'0922222222', N'laithim@hotmail.com', N'2627 Ðu?ng L')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (13, NULL, N'Ngô Van N', N'0944444444', N'ngovann@yahoo.com', N'2829 Ðu?ng K')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (14, NULL, N'Trịnh Thị O', N'0977777777', N'trinhthio@gmail.com', N'3031 Ðu?ng J')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (15, NULL, N'Bùi Ðình P', N'0899999999', N'buidinhp@yahoo.com', N'3233 Ðu?ng I')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (16, NULL, N'Lý Thái Q', N'0911111111', N'lythaiq@hotmail.com', N'3435 Ðu?ng H')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (17, NULL, N'Ðào Thị R', N'0969696969', N'daothir@yahoo.com', N'3637 Ðu?ng G')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (18, NULL, N'Hà Minh S', N'0934343434', N'haminhs@gmail.com', N'3839 Ðu?ng F')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (19, NULL, N'Phùng Van T', N'0925252525', N'phungvant@yahoo.com', N'4041 Ðu?ng E')
INSERT [dbo].[tbKhacHang] ([ID], [IDTaiKhoan], [HoVaTen], [SDT], [Email], [DiaChi]) VALUES (20, NULL, N'Nguy?n Th? U', N'0987878787', N'nguyenthii@gmail.com', N'4243 Ðu?ng D')
SET IDENTITY_INSERT [dbo].[tbKhacHang] OFF
GO
SET IDENTITY_INSERT [dbo].[tbLoaiHang] ON 

INSERT [dbo].[tbLoaiHang] ([ID], [MaLH], [TenLH]) VALUES (1, N'H01', N'Loại mèo')
INSERT [dbo].[tbLoaiHang] ([ID], [MaLH], [TenLH]) VALUES (2, N'H02', N'Các phụ kiện')
INSERT [dbo].[tbLoaiHang] ([ID], [MaLH], [TenLH]) VALUES (3, N'H03', N'Thuốc tiêm')
SET IDENTITY_INSERT [dbo].[tbLoaiHang] OFF
GO
SET IDENTITY_INSERT [dbo].[tbNhaCC] ON 

INSERT [dbo].[tbNhaCC] ([ID], [MaNhaCc], [TenNhaCc], [SDT], [DiaChi]) VALUES (1, N'NCC001', N'Công ty TNHH ABC', N'123456789', N'123 Ðu?ng ABC, Qu?n 1, TP.HCM')
INSERT [dbo].[tbNhaCC] ([ID], [MaNhaCc], [TenNhaCc], [SDT], [DiaChi]) VALUES (2, N'NCC002', N'Công ty TNHH XYZ', N'0987654321', N'321 Ðu?ng XYZ, Qu?n 2, TP.HCM')
INSERT [dbo].[tbNhaCC] ([ID], [MaNhaCc], [TenNhaCc], [SDT], [DiaChi]) VALUES (3, N'NCC003', N'Công ty TNHH DEF', N'0123456789', N'456 Ðu?ng DEF, Qu?n 3, TP.HCM')
INSERT [dbo].[tbNhaCC] ([ID], [MaNhaCc], [TenNhaCc], [SDT], [DiaChi]) VALUES (4, N'NCC004', N'Công ty TNHH GHI', N'0987654321', N'789 Ðu?ng GHI, Qu?n 4, TP.HCM')
INSERT [dbo].[tbNhaCC] ([ID], [MaNhaCc], [TenNhaCc], [SDT], [DiaChi]) VALUES (5, N'NCC005', N'Công ty TNHH KLM', N'0123456789', N'101 Ðu?ng KLM, Qu?n 5, TP.HCM')
INSERT [dbo].[tbNhaCC] ([ID], [MaNhaCc], [TenNhaCc], [SDT], [DiaChi]) VALUES (6, N'NCC006', N'Công ty TNHH NOP', N'0987654321', N'202 Ðu?ng NOP, Qu?n 6, TP.HCM')
INSERT [dbo].[tbNhaCC] ([ID], [MaNhaCc], [TenNhaCc], [SDT], [DiaChi]) VALUES (7, N'NCC007', N'Công ty TNHH QRS', N'0123456789', N'303 Ðu?ng QRS, Qu?n 7, TP.HCM')
INSERT [dbo].[tbNhaCC] ([ID], [MaNhaCc], [TenNhaCc], [SDT], [DiaChi]) VALUES (8, N'NCC008', N'Công ty TNHH TUV', N'0987654321', N'404 Ðu?ng TUV, Qu?n 8, TP.HCM')
INSERT [dbo].[tbNhaCC] ([ID], [MaNhaCc], [TenNhaCc], [SDT], [DiaChi]) VALUES (9, N'NCC009', N'Công ty TNHH XYZ', N'0123456789', N'567 Ðu?ng XYZ, Qu?n 1, TP.HCM')
INSERT [dbo].[tbNhaCC] ([ID], [MaNhaCc], [TenNhaCc], [SDT], [DiaChi]) VALUES (10, N'NCC010', N'Công ty TNHH ABC', N'0987654321', N'789 Ðu?ng ABC, Qu?n 2, TP.HCM')
INSERT [dbo].[tbNhaCC] ([ID], [MaNhaCc], [TenNhaCc], [SDT], [DiaChi]) VALUES (11, N'NCC011', N'Công ty TNHH GHI', N'0123456789', N'234 Ðu?ng GHI, Qu?n 3, TP.HCM')
INSERT [dbo].[tbNhaCC] ([ID], [MaNhaCc], [TenNhaCc], [SDT], [DiaChi]) VALUES (12, N'NCC012', N'Công ty TNHH KLM', N'0987654321', N'345 Ðu?ng KLM, Qu?n 4, TP.HCM')
SET IDENTITY_INSERT [dbo].[tbNhaCC] OFF
GO
SET IDENTITY_INSERT [dbo].[tbNhanVien] ON 

INSERT [dbo].[tbNhanVien] ([ID], [IDTaiKhoan], [MaNhanVien], [TenNhanVien], [DiaChi], [NgaySinh], [SDT], [Email]) VALUES (11, NULL, N'NV001', N'Nguyen Van A', N'123 Duong 30/4, TP Ho Chi Minh', CAST(N'1990-01-01' AS Date), N'0901234567', N'nguyenvana@gmail.com')
INSERT [dbo].[tbNhanVien] ([ID], [IDTaiKhoan], [MaNhanVien], [TenNhanVien], [DiaChi], [NgaySinh], [SDT], [Email]) VALUES (12, NULL, N'NV002', N'Tran Thi B', N'456 Nguyen Van Linh, Da Nang', CAST(N'1995-05-05' AS Date), N'0912345678', N'tranthib@gmail.com')
INSERT [dbo].[tbNhanVien] ([ID], [IDTaiKhoan], [MaNhanVien], [TenNhanVien], [DiaChi], [NgaySinh], [SDT], [Email]) VALUES (13, NULL, N'NV003', N'Le Van C', N'789 Tran Hung Dao, Ha Noi', CAST(N'1998-12-31' AS Date), N'0987654321', N'levanc@gmail.com')
INSERT [dbo].[tbNhanVien] ([ID], [IDTaiKhoan], [MaNhanVien], [TenNhanVien], [DiaChi], [NgaySinh], [SDT], [Email]) VALUES (14, NULL, N'NV004', N'Pham Thi D', N'111 Nguyen Van Cu, Can Tho', CAST(N'1992-09-20' AS Date), N'0978123456', N'phamthid@gmail.com')
INSERT [dbo].[tbNhanVien] ([ID], [IDTaiKhoan], [MaNhanVien], [TenNhanVien], [DiaChi], [NgaySinh], [SDT], [Email]) VALUES (15, NULL, N'NV005', N'Vu Van E', N'222 Tran Phu, Nha Trang', CAST(N'1997-03-15' AS Date), N'0967123456', N'vuvane@gmail.com')
INSERT [dbo].[tbNhanVien] ([ID], [IDTaiKhoan], [MaNhanVien], [TenNhanVien], [DiaChi], [NgaySinh], [SDT], [Email]) VALUES (16, NULL, N'NV006', N'Nguyen Thi F', N'333 Vo Van Tan, Da Lat', CAST(N'1993-07-25' AS Date), N'0934123456', N'nguyenthif@gmail.com')
INSERT [dbo].[tbNhanVien] ([ID], [IDTaiKhoan], [MaNhanVien], [TenNhanVien], [DiaChi], [NgaySinh], [SDT], [Email]) VALUES (17, NULL, N'NV007', N'Tran Van G', N'444 Le Duan, Ha Noi', CAST(N'1991-11-11' AS Date), N'0945123456', N'tranvang@gmail.com')
INSERT [dbo].[tbNhanVien] ([ID], [IDTaiKhoan], [MaNhanVien], [TenNhanVien], [DiaChi], [NgaySinh], [SDT], [Email]) VALUES (18, NULL, N'NV008', N'Hoang Thi H', N'555 Tran Hung Dao, Da Nang', CAST(N'1994-04-04' AS Date), N'0956123456', N'hoangthih@gmail.com')
INSERT [dbo].[tbNhanVien] ([ID], [IDTaiKhoan], [MaNhanVien], [TenNhanVien], [DiaChi], [NgaySinh], [SDT], [Email]) VALUES (19, NULL, N'NV009', N'Nguyen Van I', N'666 Nguyen Trai, Ho Chi Minh', CAST(N'1996-06-06' AS Date), N'0987123456', N'nguyenvani@gmail.com')
INSERT [dbo].[tbNhanVien] ([ID], [IDTaiKhoan], [MaNhanVien], [TenNhanVien], [DiaChi], [NgaySinh], [SDT], [Email]) VALUES (20, NULL, N'NV010', N'Le Thi K', N'777 Ton Duc Thang', CAST(N'1999-09-09' AS Date), N'0917123456', N'lethik@gmail.com')
SET IDENTITY_INSERT [dbo].[tbNhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[tbSanPham] ON 

INSERT [dbo].[tbSanPham] ([ID], [MaSanPham], [TenSanPham], [MoTa], [AnhSp], [IDLoaiHang], [TinhTrang], [Gia]) VALUES (1, N'PSM01', N'Chuồng cho mèo', N'Chuồng nhựa cao cấp cho mèo', N'chuongnhua.jpg', 2, 1, 1500000)
INSERT [dbo].[tbSanPham] ([ID], [MaSanPham], [TenSanPham], [MoTa], [AnhSp], [IDLoaiHang], [TinhTrang], [Gia]) VALUES (2, N'PSM02', N'Thức ăn cho mèo', N'Thức ăn hạt dinh dưỡng cho mèo', N'hat.jpg', 2, 1, 200000)
INSERT [dbo].[tbSanPham] ([ID], [MaSanPham], [TenSanPham], [MoTa], [AnhSp], [IDLoaiHang], [TinhTrang], [Gia]) VALUES (3, N'PSM03', N'Tay xách cho mèo', N'Tay xách nhỏ gọn cho mèo', N'tui.jpg', 2, 0, 50000)
INSERT [dbo].[tbSanPham] ([ID], [MaSanPham], [TenSanPham], [MoTa], [AnhSp], [IDLoaiHang], [TinhTrang], [Gia]) VALUES (4, N'PSM04', N'Vòng cổ cho mèo', N'Vòng cổ da cho mèo', N'vongco.jpg', 2, 1, 120000)
INSERT [dbo].[tbSanPham] ([ID], [MaSanPham], [TenSanPham], [MoTa], [AnhSp], [IDLoaiHang], [TinhTrang], [Gia]) VALUES (5, N'PSM05', N'Nước rửa chén cho mèo', N'Sản phẩm vệ sinh sạch sẽ cho mèo', N'nuocrua.jpg', 2, 0, 80000)
INSERT [dbo].[tbSanPham] ([ID], [MaSanPham], [TenSanPham], [MoTa], [AnhSp], [IDLoaiHang], [TinhTrang], [Gia]) VALUES (6, N'PSM06', N'Lồng vận chuyển cho mèo', N'Lồng du lịch cho mèo', N'long.jpeg', 2, 1, 350000)
INSERT [dbo].[tbSanPham] ([ID], [MaSanPham], [TenSanPham], [MoTa], [AnhSp], [IDLoaiHang], [TinhTrang], [Gia]) VALUES (7, N'PSM07', N'Đồ chơi cát cho mèo', N'Đồ chơi giải trí cho mèo', N'dochoi.jpg', 2, 1, 100000)
INSERT [dbo].[tbSanPham] ([ID], [MaSanPham], [TenSanPham], [MoTa], [AnhSp], [IDLoaiHang], [TinhTrang], [Gia]) VALUES (8, N'PSM08', N'Bàn chải cho mèo', N'Bàn chải nhỏ gọn cho mèo', N'banchai.jpg', 2, 1, 50000)
INSERT [dbo].[tbSanPham] ([ID], [MaSanPham], [TenSanPham], [MoTa], [AnhSp], [IDLoaiHang], [TinhTrang], [Gia]) VALUES (9, N'PSM09', N'Tấm lót cho mèo', N'Tấm lót vệ sinh cho mèo', N'tamlot.jpg', 2, 0, 70000)
INSERT [dbo].[tbSanPham] ([ID], [MaSanPham], [TenSanPham], [MoTa], [AnhSp], [IDLoaiHang], [TinhTrang], [Gia]) VALUES (10, N'PSM11', N'Cốc uống nước cho mèo', N'Cốc uống nước tự động cho mèo', N'cocnuoc.jpg', 2, 1, 80000)
INSERT [dbo].[tbSanPham] ([ID], [MaSanPham], [TenSanPham], [MoTa], [AnhSp], [IDLoaiHang], [TinhTrang], [Gia]) VALUES (11, N'PSM12', N'Giường cho mèo', N'Giường ngủ êm ái cho mèo', N'giuong.jpg', 2, 0, 250000)
INSERT [dbo].[tbSanPham] ([ID], [MaSanPham], [TenSanPham], [MoTa], [AnhSp], [IDLoaiHang], [TinhTrang], [Gia]) VALUES (12, N'PSM13', N'Đồ chơi móc câu cho mèo', N'Đồ chơi giải trí cho mèo', N'cancau.jpg', 2, 0, 60000)
SET IDENTITY_INSERT [dbo].[tbSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[tbTaiKhoan] ON 

INSERT [dbo].[tbTaiKhoan] ([ID], [TaiKhoan], [MatKhau], [Quyen]) VALUES (1, N'duong', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1)
INSERT [dbo].[tbTaiKhoan] ([ID], [TaiKhoan], [MatKhau], [Quyen]) VALUES (2, N'Nv01', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 0)
INSERT [dbo].[tbTaiKhoan] ([ID], [TaiKhoan], [MatKhau], [Quyen]) VALUES (3, N'Nv02', N'b3a8e0e1f9ab1bfe3a36f231f676f78bb30a519d2b21e6c530c0eee8ebb4a5d0', 0)
SET IDENTITY_INSERT [dbo].[tbTaiKhoan] OFF
GO
SET IDENTITY_INSERT [dbo].[tbThuCung] ON 

INSERT [dbo].[tbThuCung] ([ID], [MaThuCung], [Ten], [Tuoi], [GioiTinh], [Giong], [MoTa], [AnhTC], [IDLoaiHang], [TInhTrang], [Gia], [TrangThai], [IDHDN]) VALUES (1, N'TC01', N'Mun', 2, 0, N'mèo Sphynx không lông', N' không lông (mèo Ai Cập, nhân sư).', N'sphynx230526391.png', 1, 0, 4000000, 1, NULL)
INSERT [dbo].[tbThuCung] ([ID], [MaThuCung], [Ten], [Tuoi], [GioiTinh], [Giong], [MoTa], [AnhTC], [IDLoaiHang], [TInhTrang], [Gia], [TrangThai], [IDHDN]) VALUES (2, N'TC02', N'Sâu', 2, 0, N'mèo báo Bengal', N' Màu sắc: nâu', N'bengal-nau.png', 1, 0, 3500000, 0, NULL)
INSERT [dbo].[tbThuCung] ([ID], [MaThuCung], [Ten], [Tuoi], [GioiTinh], [Giong], [MoTa], [AnhTC], [IDLoaiHang], [TInhTrang], [Gia], [TrangThai], [IDHDN]) VALUES (3, N'TC03', N'Sấu', 2, 1, N'mèo báo Bengal', N' Màu sắc: nâu', N'bengal-nau.png', 1, 1, 4000000, 1, NULL)
INSERT [dbo].[tbThuCung] ([ID], [MaThuCung], [Ten], [Tuoi], [GioiTinh], [Giong], [MoTa], [AnhTC], [IDLoaiHang], [TInhTrang], [Gia], [TrangThai], [IDHDN]) VALUES (4, N'TC04', N'Pu', 2, 1, N'mèo Anh lông ngắn (British Shorthair).', N' Màu sắc: Silver.', N'meo-aln-silver.png', 1, 0, 3000000, 0, NULL)
INSERT [dbo].[tbThuCung] ([ID], [MaThuCung], [Ten], [Tuoi], [GioiTinh], [Giong], [MoTa], [AnhTC], [IDLoaiHang], [TInhTrang], [Gia], [TrangThai], [IDHDN]) VALUES (5, N'TC05', N'Bon', 2, 0, N'mèo ALN, mèo Munchkin (chân ngắn), Scottish Fold (tai cụp).', N'Màu sắc: bicolor', N'taicup.png', 1, 1, 3200000, 1, NULL)
INSERT [dbo].[tbThuCung] ([ID], [MaThuCung], [Ten], [Tuoi], [GioiTinh], [Giong], [MoTa], [AnhTC], [IDLoaiHang], [TInhTrang], [Gia], [TrangThai], [IDHDN]) VALUES (6, N'TC06', N'Bo', 3, 1, N' mèo Maine Coon (mèo Mỹ lông dài).', N' Màu sắc: bi-red', N'maine-coon.png', 1, 1, 4500000, 1, NULL)
INSERT [dbo].[tbThuCung] ([ID], [MaThuCung], [Ten], [Tuoi], [GioiTinh], [Giong], [MoTa], [AnhTC], [IDLoaiHang], [TInhTrang], [Gia], [TrangThai], [IDHDN]) VALUES (7, N'TC07', N'Đen', 2, 1, N'mèo British Shorthair (ALN), Scottish (tai cụp).', N' Màu sắc: chocolate.', N'tai-cup.png', 1, 0, 3600000, 1, NULL)
INSERT [dbo].[tbThuCung] ([ID], [MaThuCung], [Ten], [Tuoi], [GioiTinh], [Giong], [MoTa], [AnhTC], [IDLoaiHang], [TInhTrang], [Gia], [TrangThai], [IDHDN]) VALUES (8, N'TC08', N'Snow', 2, 1, N'mèo British Longhair (mèo Anh lông dài, Ald)', N'Màu sắc: trắng, hai màu mắt.', N'meo-anh.jpg', 1, 1, 4200000, 0, NULL)
INSERT [dbo].[tbThuCung] ([ID], [MaThuCung], [Ten], [Tuoi], [GioiTinh], [Giong], [MoTa], [AnhTC], [IDLoaiHang], [TInhTrang], [Gia], [TrangThai], [IDHDN]) VALUES (9, N'TC09', N'Vàng', 2, 0, N'mèo Anh lông dài (British Longhair), Ald.', N'Màu sắc: red.', N'meo-ald.png', 1, 0, 3000000, 1, NULL)
INSERT [dbo].[tbThuCung] ([ID], [MaThuCung], [Ten], [Tuoi], [GioiTinh], [Giong], [MoTa], [AnhTC], [IDLoaiHang], [TInhTrang], [Gia], [TrangThai], [IDHDN]) VALUES (10, N'TC10', N'Black', 5, 1, N'mèo Maine Coon (mèo Mỹ lông dài)', N'Màu sắc: tuxedo.', N'meo-maine.png', 1, 1, 5000000, 0, NULL)
INSERT [dbo].[tbThuCung] ([ID], [MaThuCung], [Ten], [Tuoi], [GioiTinh], [Giong], [MoTa], [AnhTC], [IDLoaiHang], [TInhTrang], [Gia], [TrangThai], [IDHDN]) VALUES (1006, N'TC11', N'Su', 10, 0, N'mèo Munchkin.', N'Màu sắc: Tortoisesshell (torties) hay đồi mồi.  Đặc điểm: chân ngắn, mặt bánh bao, mắt vàng đồng.', N'munchkin.jpg', 1, 1, 6000000, 1, NULL)
INSERT [dbo].[tbThuCung] ([ID], [MaThuCung], [Ten], [Tuoi], [GioiTinh], [Giong], [MoTa], [AnhTC], [IDLoaiHang], [TInhTrang], [Gia], [TrangThai], [IDHDN]) VALUES (1007, N'TC12', N'Xám', 2, 1, N'mèo Scottish Fold.', N'Màu sắc: Hyma (Himalaya, Colorpoint).Đặc điểm: tai cụp sát, mặt cu mũi hồng.', N'meo-scottish.jpeg', 1, 0, 6500000, 1, NULL)
SET IDENTITY_INSERT [dbo].[tbThuCung] OFF
GO
SET IDENTITY_INSERT [dbo].[tbTiemChung] ON 

INSERT [dbo].[tbTiemChung] ([ID], [MaTiemChung], [Ten], [MoTa], [IDLoaiHang], [Gia]) VALUES (1, N'MTC001', N'LIỀU THUỐC TIÊM CHO MÈO 1', N'Mô tả về liều thuốc tiêm cho mèo 1', 3, 50000)
INSERT [dbo].[tbTiemChung] ([ID], [MaTiemChung], [Ten], [MoTa], [IDLoaiHang], [Gia]) VALUES (2, N'MTC002', N'LIỀU THUỐC TIÊM CHO MÈO 2', N'Mô tả về liều thuốc tiêm cho mèo 2', 3, 70000)
INSERT [dbo].[tbTiemChung] ([ID], [MaTiemChung], [Ten], [MoTa], [IDLoaiHang], [Gia]) VALUES (3, N'MTC003', N'LIỀU THUỐC TIÊM CHO MÈO 3', N'Mô tả về liều thuốc tiêm cho mèo 3', 3, 90000)
INSERT [dbo].[tbTiemChung] ([ID], [MaTiemChung], [Ten], [MoTa], [IDLoaiHang], [Gia]) VALUES (4, N'MTC004', N'LIỀU THUỐC TIÊM CHO MÈO 4', N'Mô tả về liều thuốc tiêm cho mèo 4', 3, 80000)
INSERT [dbo].[tbTiemChung] ([ID], [MaTiemChung], [Ten], [MoTa], [IDLoaiHang], [Gia]) VALUES (5, N'MTC005', N'LIỀU THUỐC TIÊM CHO MÈO 5', N'Mô t? v? li?u thu?c tiêm cho mèo 5', 3, 65000)
SET IDENTITY_INSERT [dbo].[tbTiemChung] OFF
GO
ALTER TABLE [dbo].[tbChiTietDh]  WITH CHECK ADD  CONSTRAINT [FK_tbChiTietDh_tbDonDatHang] FOREIGN KEY([IDDonHang])
REFERENCES [dbo].[tbDonDatHang] ([ID])
GO
ALTER TABLE [dbo].[tbChiTietDh] CHECK CONSTRAINT [FK_tbChiTietDh_tbDonDatHang]
GO
ALTER TABLE [dbo].[tbChiTietDh]  WITH CHECK ADD  CONSTRAINT [FK_tbChiTietDh_tbSanPham] FOREIGN KEY([IDSanPham])
REFERENCES [dbo].[tbSanPham] ([ID])
GO
ALTER TABLE [dbo].[tbChiTietDh] CHECK CONSTRAINT [FK_tbChiTietDh_tbSanPham]
GO
ALTER TABLE [dbo].[tbChiTietDh]  WITH CHECK ADD  CONSTRAINT [FK_tbChiTietDh_tbThuCung] FOREIGN KEY([IDThuCung])
REFERENCES [dbo].[tbThuCung] ([ID])
GO
ALTER TABLE [dbo].[tbChiTietDh] CHECK CONSTRAINT [FK_tbChiTietDh_tbThuCung]
GO
ALTER TABLE [dbo].[tbChiTietDh]  WITH CHECK ADD  CONSTRAINT [FK_tbChiTietDh_tbTiemChung1] FOREIGN KEY([IDTiemChung])
REFERENCES [dbo].[tbTiemChung] ([ID])
GO
ALTER TABLE [dbo].[tbChiTietDh] CHECK CONSTRAINT [FK_tbChiTietDh_tbTiemChung1]
GO
ALTER TABLE [dbo].[tbChiTietDN]  WITH CHECK ADD  CONSTRAINT [FK_tbChiTietDN_tbDonNhapHang] FOREIGN KEY([IDDonNhap])
REFERENCES [dbo].[tbDonNhapHang] ([ID])
GO
ALTER TABLE [dbo].[tbChiTietDN] CHECK CONSTRAINT [FK_tbChiTietDN_tbDonNhapHang]
GO
ALTER TABLE [dbo].[tbChiTietDN]  WITH CHECK ADD  CONSTRAINT [FK_tbChiTietDN_tbLoaiHang] FOREIGN KEY([IDLoaiHang])
REFERENCES [dbo].[tbLoaiHang] ([ID])
GO
ALTER TABLE [dbo].[tbChiTietDN] CHECK CONSTRAINT [FK_tbChiTietDN_tbLoaiHang]
GO
ALTER TABLE [dbo].[tbDonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_tbDonDatHang_tbNhanVien] FOREIGN KEY([IDNV])
REFERENCES [dbo].[tbNhanVien] ([ID])
GO
ALTER TABLE [dbo].[tbDonDatHang] CHECK CONSTRAINT [FK_tbDonDatHang_tbNhanVien]
GO
ALTER TABLE [dbo].[tbDonNhapHang]  WITH CHECK ADD  CONSTRAINT [FK_tbDonNhapHang_tbNhaCC] FOREIGN KEY([IDNCC])
REFERENCES [dbo].[tbNhaCC] ([ID])
GO
ALTER TABLE [dbo].[tbDonNhapHang] CHECK CONSTRAINT [FK_tbDonNhapHang_tbNhaCC]
GO
ALTER TABLE [dbo].[tbDonNhapHang]  WITH CHECK ADD  CONSTRAINT [FK_tbDonNhapHang_tbNhanVien] FOREIGN KEY([IDNV])
REFERENCES [dbo].[tbNhanVien] ([ID])
GO
ALTER TABLE [dbo].[tbDonNhapHang] CHECK CONSTRAINT [FK_tbDonNhapHang_tbNhanVien]
GO
ALTER TABLE [dbo].[tbKhacHang]  WITH CHECK ADD  CONSTRAINT [FK_tbKhacHang_tbTaiKhoan] FOREIGN KEY([IDTaiKhoan])
REFERENCES [dbo].[tbTaiKhoan] ([ID])
GO
ALTER TABLE [dbo].[tbKhacHang] CHECK CONSTRAINT [FK_tbKhacHang_tbTaiKhoan]
GO
ALTER TABLE [dbo].[tbNhanVien]  WITH CHECK ADD  CONSTRAINT [FK_tbNhanVien_tbTaiKhoan] FOREIGN KEY([IDTaiKhoan])
REFERENCES [dbo].[tbTaiKhoan] ([ID])
GO
ALTER TABLE [dbo].[tbNhanVien] CHECK CONSTRAINT [FK_tbNhanVien_tbTaiKhoan]
GO
