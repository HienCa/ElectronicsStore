USE [master]
GO
/****** Object:  Database [ElectronicsStore]    Script Date: 4/25/2023 12:32:44 PM ******/
CREATE DATABASE [ElectronicsStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ElectronicsStore', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ElectronicsStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ElectronicsStore_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ElectronicsStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ElectronicsStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ElectronicsStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ElectronicsStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ElectronicsStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ElectronicsStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ElectronicsStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ElectronicsStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [ElectronicsStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ElectronicsStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ElectronicsStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ElectronicsStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ElectronicsStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ElectronicsStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ElectronicsStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ElectronicsStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ElectronicsStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ElectronicsStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ElectronicsStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ElectronicsStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ElectronicsStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ElectronicsStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ElectronicsStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ElectronicsStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ElectronicsStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ElectronicsStore] SET RECOVERY FULL 
GO
ALTER DATABASE [ElectronicsStore] SET  MULTI_USER 
GO
ALTER DATABASE [ElectronicsStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ElectronicsStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ElectronicsStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ElectronicsStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ElectronicsStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ElectronicsStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ElectronicsStore', N'ON'
GO
ALTER DATABASE [ElectronicsStore] SET QUERY_STORE = OFF
GO
USE [ElectronicsStore]
GO
/****** Object:  Table [dbo].[CTNGANHANGKH]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTNGANHANGKH](
	[IDCTNHKH] [int] IDENTITY(1,1) NOT NULL,
	[STK] [int] NOT NULL,
	[IDKH] [int] NOT NULL,
	[IDNH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCTNHKH] ASC,
	[IDKH] ASC,
	[IDNH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTNGANHANGNCC]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTNGANHANGNCC](
	[IDCTNHNCC] [int] IDENTITY(1,1) NOT NULL,
	[STK] [int] NOT NULL,
	[IDNH] [int] NOT NULL,
	[IDNCC] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCTNHNCC] ASC,
	[IDNH] ASC,
	[IDNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DONDATHANG]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONDATHANG](
	[IDDH] [int] IDENTITY(1,1) NOT NULL,
	[MADH] [nvarchar](255) NULL,
	[NGAYDAT] [datetime] NOT NULL,
	[NGAYGIAO] [datetime] NULL,
	[TRANGTHAI] [int] NOT NULL,
	[GHICHU] [nvarchar](4000) NULL,
	[ACTIVE] [int] NOT NULL,
	[IDKH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HANGHOA]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HANGHOA](
	[IDHH] [int] IDENTITY(1,1) NOT NULL,
	[MAVL] [nvarchar](255) NULL,
	[TENVL] [nvarchar](255) NOT NULL,
	[HINHANH] [nvarchar](255) NULL,
	[GIAKM] [real] NULL,
	[GIABAN] [real] NOT NULL,
	[TINHTRANG] [int] NOT NULL,
	[MAUSAC] [nvarchar](255) NULL,
	[DONVITINH] [nvarchar](255) NOT NULL,
	[THOIGIANBH] [int] NOT NULL,
	[MOTA] [nvarchar](max) NULL,
	[ACTIVE] [int] NOT NULL,
	[IDNSX] [int] NOT NULL,
	[IDTH] [int] NOT NULL,
	[IDNHH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HINHTHUCTHANHTOAN]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HINHTHUCTHANHTOAN](
	[IDHTTT] [int] IDENTITY(1,1) NOT NULL,
	[MAHTTT] [nvarchar](255) NULL,
	[TENHTTT] [nvarchar](255) NOT NULL,
	[ACTIVE] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDHTTT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[IDKH] [int] IDENTITY(1,1) NOT NULL,
	[MAKH] [nvarchar](255) NULL,
	[TENKH] [nvarchar](255) NOT NULL,
	[CCCD] [nvarchar](255) NULL,
	[DIACHI] [nvarchar](4000) NOT NULL,
	[SDT] [nvarchar](255) NOT NULL,
	[EMAIL] [nvarchar](255) NULL,
	[MATKHAU] [nvarchar](255) NULL,
	[GIOITINH] [nvarchar](255) NOT NULL,
	[MASOTHUE] [nvarchar](255) NULL,
	[GHICHU] [nvarchar](4000) NULL,
	[NVIDSALE] [int] NULL,
	[HINHANH] [nvarchar](255) NULL,
	[NGAYSINH] [date] NULL,
	[FACEBOOK] [nvarchar](255) NULL,
	[ZALO] [nvarchar](255) NULL,
	[ACTIVE] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NGANHANG]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGANHANG](
	[IDNH] [int] IDENTITY(1,1) NOT NULL,
	[TENNH] [nvarchar](255) NOT NULL,
	[DIACHI] [nvarchar](255) NOT NULL,
	[EMAIL] [nvarchar](255) NOT NULL,
	[MASOTHUE] [nvarchar](255) NOT NULL,
	[GHICHU] [nvarchar](4000) NULL,
	[ACTIVE] [int] NOT NULL,
	[IDHTTT] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[IDNCC] [int] IDENTITY(1,1) NOT NULL,
	[MANCC] [nvarchar](255) NULL,
	[TENNCC] [nvarchar](255) NOT NULL,
	[DIACHI] [nvarchar](255) NOT NULL,
	[EMAIL] [nvarchar](255) NOT NULL,
	[SDT] [nvarchar](255) NOT NULL,
	[MASOTHUE] [nvarchar](255) NOT NULL,
	[GHICHU] [nvarchar](4000) NULL,
	[FACEBOOK] [nvarchar](255) NULL,
	[ZALO] [nvarchar](255) NULL,
	[ACTIVE] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[IDNV] [int] IDENTITY(1,1) NOT NULL,
	[MANV] [nvarchar](255) NULL,
	[TENNV] [nvarchar](255) NOT NULL,
	[CCCD] [nvarchar](255) NULL,
	[NGAYSINH] [datetime] NOT NULL,
	[GIOITINH] [nvarchar](255) NOT NULL,
	[DIACHI] [nvarchar](4000) NOT NULL,
	[SDT] [nvarchar](255) NOT NULL,
	[EMAIL] [nvarchar](255) NOT NULL,
	[MASOTHUE] [nvarchar](255) NULL,
	[MATKHAU] [nvarchar](255) NULL,
	[HINHANH] [nvarchar](255) NULL,
	[GHICHU] [nvarchar](4000) NULL,
	[FACEBOOK] [nvarchar](255) NULL,
	[ZALO] [nvarchar](255) NULL,
	[ACTIVE] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHOMHH]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHOMHH](
	[IDNHH] [int] IDENTITY(1,1) NOT NULL,
	[MANHH] [nvarchar](255) NULL,
	[TENNHH] [nvarchar](255) NOT NULL,
	[ACTIVE] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NOIDUNGDDH]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NOIDUNGDDH](
	[IDNDDDH] [int] IDENTITY(1,1) NOT NULL,
	[SOLUONG] [real] NOT NULL,
	[DONGIA] [real] NOT NULL,
	[HETHANBH] [datetime] NULL,
	[IDHH] [int] NOT NULL,
	[IDDH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNDDDH] ASC,
	[IDHH] ASC,
	[IDDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NOIDUNGPNK]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NOIDUNGPNK](
	[IDNDPNK] [int] IDENTITY(1,1) NOT NULL,
	[SOLUONG] [real] NOT NULL,
	[DONGIA] [real] NOT NULL,
	[SOLO] [nvarchar](255) NULL,
	[NGAYSX] [date] NULL,
	[HANSD] [date] NULL,
	[VAT] [real] NULL,
	[CKTM] [real] NULL,
	[IDHH] [int] NOT NULL,
	[IDPNK] [int] NOT NULL,
	[DONVITINH] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNDPNK] ASC,
	[IDHH] ASC,
	[IDPNK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NOIDUNGPXK]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NOIDUNGPXK](
	[IDNDPXK] [int] IDENTITY(1,1) NOT NULL,
	[SOLUONG] [real] NOT NULL,
	[DONGIA] [real] NOT NULL,
	[VAT] [real] NULL,
	[CKTM] [real] NULL,
	[IDPXK] [int] NOT NULL,
	[IDHH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNDPXK] ASC,
	[IDPXK] ASC,
	[IDHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NOIDUNGTHUNODDH]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NOIDUNGTHUNODDH](
	[IDNDTNDDH] [int] IDENTITY(1,1) NOT NULL,
	[IDPTNKH] [int] NOT NULL,
	[IDDH] [int] NOT NULL,
	[NGAYTHUNO] [datetime] NOT NULL,
	[SOTIEN] [real] NULL,
	[GHICHU] [nvarchar](4000) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNDTNDDH] ASC,
	[IDPTNKH] ASC,
	[IDDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NOIDUNGTHUNOKH]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NOIDUNGTHUNOKH](
	[IDNDTNKH] [int] IDENTITY(1,1) NOT NULL,
	[IDPTNKH] [int] NOT NULL,
	[IDPXK] [int] NOT NULL,
	[NGAYTHUNO] [datetime] NOT NULL,
	[SOTIEN] [real] NOT NULL,
	[GHICHU] [nvarchar](4000) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNDTNKH] ASC,
	[IDPTNKH] ASC,
	[IDPXK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NOIDUNGTRANONCC]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NOIDUNGTRANONCC](
	[IDNDTNNCC] [int] IDENTITY(1,1) NOT NULL,
	[IDPTNNCC] [int] NOT NULL,
	[IDPNK] [int] NOT NULL,
	[SOTIEN] [real] NULL,
	[NGAYTRANO] [datetime] NULL,
	[GHICHU] [nvarchar](4000) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNDTNNCC] ASC,
	[IDPTNNCC] ASC,
	[IDPNK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NUOSX]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NUOSX](
	[IDNSX] [int] IDENTITY(1,1) NOT NULL,
	[MANSX] [nvarchar](255) NULL,
	[TENNSX] [nvarchar](255) NOT NULL,
	[ACTIVE] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNSX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUNHAPKHO]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUNHAPKHO](
	[IDPNK] [int] IDENTITY(1,1) NOT NULL,
	[SOPHIEU] [nvarchar](255) NOT NULL,
	[NGAYLAP] [datetime] NOT NULL,
	[SOHD] [nvarchar](255) NULL,
	[NGAYHD] [datetime] NULL,
	[GHICHU] [nvarchar](4000) NULL,
	[ACTIVE] [int] NOT NULL,
	[IDNCC] [int] NOT NULL,
	[IDNV] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDPNK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUTHUNOKH]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUTHUNOKH](
	[IDPTNKH] [int] IDENTITY(1,1) NOT NULL,
	[SOPHIEU] [nvarchar](255) NULL,
	[NGAYLAP] [datetime] NOT NULL,
	[GHICHU] [nvarchar](4000) NULL,
	[ACTIVE] [int] NOT NULL,
	[IDHTTT] [int] NOT NULL,
	[IDNV] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDPTNKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUTRANONCC]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUTRANONCC](
	[IDPTNNCC] [int] IDENTITY(1,1) NOT NULL,
	[SOPHIEU] [nvarchar](255) NOT NULL,
	[NGAYLAP] [datetime] NOT NULL,
	[GHICHU] [nvarchar](4000) NULL,
	[ACTIVE] [int] NOT NULL,
	[IDHTTT] [int] NOT NULL,
	[IDNV] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDPTNNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUXUATKHO]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUXUATKHO](
	[IDPXK] [int] IDENTITY(1,1) NOT NULL,
	[SOPHIEU] [nvarchar](255) NULL,
	[NGAYLAP] [datetime] NOT NULL,
	[SOHD] [nvarchar](255) NULL,
	[NGAYHD] [datetime] NULL,
	[GHICHU] [nvarchar](4000) NULL,
	[ACTIVE] [int] NOT NULL,
	[IDNV] [int] NOT NULL,
	[IDKH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDPXK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THUONGHIEU]    Script Date: 4/25/2023 12:32:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THUONGHIEU](
	[IDTH] [int] IDENTITY(1,1) NOT NULL,
	[MATH] [nvarchar](255) NULL,
	[TENTH] [nvarchar](255) NOT NULL,
	[ACTIVE] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDTH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DONDATHANG] ON 

INSERT [dbo].[DONDATHANG] ([IDDH], [MADH], [NGAYDAT], [NGAYGIAO], [TRANGTHAI], [GHICHU], [ACTIVE], [IDKH]) VALUES (41, N'230425103912587T4Ho30', CAST(N'2023-04-25T10:39:12.590' AS DateTime), CAST(N'2023-04-25T10:44:11.687' AS DateTime), 3, NULL, 1, 30)
SET IDENTITY_INSERT [dbo].[DONDATHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[HANGHOA] ON 

INSERT [dbo].[HANGHOA] ([IDHH], [MAVL], [TENVL], [HINHANH], [GIAKM], [GIABAN], [TINHTRANG], [MAUSAC], [DONVITINH], [THOIGIANBH], [MOTA], [ACTIVE], [IDNSX], [IDTH], [IDNHH]) VALUES (5, N'MSIVGA', N'Card màn hình VGA ASRock Radeon RX 6600 8GB GDDR6 Challenger D RX 6600 CLD 8GB', N'84e27dea-9480-4574-a2e9-6fb56adbef10_VGA_MSI.jpg', 90000, 100000, 1, N'Đen', N'Cái', 180, N'Graphics Engine	AMD Radeon™ RX 6600
Bus Standard	PCI® Express 4.0
DirectX	12 Ultimate
OpenGL	 4.6
Memory	8GB GDDR6
Engine Clock	- Boost Clock: Up to 2491 MHz
- Game Clock: Up to 2044 MHz
- Base Clock: 1626 MHz
Stream Processors	1792
Memory Clock	14 Gbps
Memory Interface	128-bit
Resolution	Digital Max Resolution: 7680 x 4320
Interface	- 1 x HDMI™ 2.1 VRR
- 3 x DisplayPort™ 1.4 with DSC
HDCP	Yes
Multi-view	4
Recommended PSU	500W
Power Connector	1 x 8-pin
Accessories	1 x Quick Installation Guide
Dimensions	269 x 132 x 41 mm
Net Weight	 627 g', 1, 1, 2, 2)
INSERT [dbo].[HANGHOA] ([IDHH], [MAVL], [TENVL], [HINHANH], [GIAKM], [GIABAN], [TINHTRANG], [MAUSAC], [DONVITINH], [THOIGIANBH], [MOTA], [ACTIVE], [IDNSX], [IDTH], [IDNHH]) VALUES (7, N'NX-7010', N'Chuột không dây Genius NX-7010', N'ac602224-6a58-4c35-be65-1b82d74802df_ChuotGenius.jpg', NULL, 200000, 0, N'Đỏ đen', N'Cái', 360, N'Kiểu chuột: Không dây
Kết nối: Cổng cắm USB
Xuất xứ: Chính hãng', 1, 1, 4, 4)
INSERT [dbo].[HANGHOA] ([IDHH], [MAVL], [TENVL], [HINHANH], [GIAKM], [GIABAN], [TINHTRANG], [MAUSAC], [DONVITINH], [THOIGIANBH], [MOTA], [ACTIVE], [IDNSX], [IDTH], [IDNHH]) VALUES (8, N'M325', N'Chuột máy tính Logitech M325', N'ef89b01b-0100-4211-94b1-5fefb01b9703_LogitechM325.jpg', NULL, 390000, 0, N'Đen', N'Cái', 360, N'Kiểu kết nối: Chuột không dây
Kết nối: Lightspeed Wireless
Kiểu cầm: Ergonomic / Công thái học
Độ phân giải (CPI/DPI): 1000DPI
Dạng cảm biến:Optical
Số nút bấm: 3
Kiểu pin: 1 x Pin AA
Kích thước: 95 x 57 x 40 mm
Khối lượng: 93 g', 1, 1, 5, 4)
INSERT [dbo].[HANGHOA] ([IDHH], [MAVL], [TENVL], [HINHANH], [GIAKM], [GIABAN], [TINHTRANG], [MAUSAC], [DONVITINH], [THOIGIANBH], [MOTA], [ACTIVE], [IDNSX], [IDTH], [IDNHH]) VALUES (9, N'MBB65013', N'GIGABYTE B650I AORUS ULTRA (rev. 1.0) (DDR5)', N'b5145429-1196-4450-877b-2fbbc9f421e4_MBB65013.jpg', NULL, 8990000, 0, N'Đen', N'Cái', 1080, N'CPU:AMD Socket AM5, hỗ trợ cho: Bộ xử lý AMD Ryzen ™ 7000 Series
Chipset: AMD B650
Bộ xử lý đồ họa tích hợp:
1 x DisplayPort, hỗ trợ độ phân giải tối đa 3840x2160@144 Hz
* Hỗ trợ phiên bản DisplayPort 1.4 và HDR.
1 x cổng USB Type-C®, hỗ trợ đầu ra video USB 3.2 Thế hệ 2 và DisplayPort và độ phân giải tối đa 3840x2160@144 Hz
* Hỗ trợ phiên bản DisplayPort 1.4 và HDR.
1 x cổng HDMI, hỗ trợ độ phân giải tối đa 7680x4320@60 Hz
* Hỗ trợ phiên bản HDMI 2.1 và HDCP 2.3.
** Hỗ trợ cổng tương thích HDMI 2.1 TMDS gốc.
(Thông số kỹ thuật đồ họa có thể khác nhau tùy thuộc vào sự hỗ trợ của CPU.)
LAN: Chip mạng LAN Intel® 2,5GbE (2,5 Gbps /1 Gbps /100 Mbps)', 1, 1, 2, 2)
INSERT [dbo].[HANGHOA] ([IDHH], [MAVL], [TENVL], [HINHANH], [GIAKM], [GIABAN], [TINHTRANG], [MAUSAC], [DONVITINH], [THOIGIANBH], [MOTA], [ACTIVE], [IDNSX], [IDTH], [IDNHH]) VALUES (10, N'RDDR4011', N'Ram T-Group T-Force Delta 1x8GB 3200 RGB White (TF4D48G3200HC16C01)', N'7a502843-c7d1-4f80-9224-df604036bd10_RDDR4011.jpg', NULL, 1199000, 0, N'Đen', N'Cái', 0, N'Chuẩn RAM:	DDR4-3200 (PC4-25600)
Cas Latency: CL16-18-18-38
Điện áp:	1.35V
Dung lượng:	8GB
Kích thước: 49(H) x 147(L) x 7(W) mm', 1, 1, 7, 5)
INSERT [dbo].[HANGHOA] ([IDHH], [MAVL], [TENVL], [HINHANH], [GIAKM], [GIABAN], [TINHTRANG], [MAUSAC], [DONVITINH], [THOIGIANBH], [MOTA], [ACTIVE], [IDNSX], [IDTH], [IDNHH]) VALUES (11, N'KF552C40BBAK2-32', N'RAM Kingston Fury Beast RGB 32GB (2x16GB) bus 5200 DDR5 (KF552C40BBAK2-32)', N'c549ffd7-6659-43aa-9f45-22dbcb5b1afd_KF552C40BBAK2-32.jpg', NULL, 3590000, 0, N'Đen', N'Cái', 1080, N'Tổng dung lượng: 32GB (2x16GB)
Tần số: 5200MT/s
Độ trễ: CL40
Điện áp: 1.25V
Nhiệt độ vận hành: 0°C đến 85°C
Kích thước: 133,35 mm x 42,23 mm x 7,11 mm ', 1, 1, 6, 2)
SET IDENTITY_INSERT [dbo].[HANGHOA] OFF
GO
SET IDENTITY_INSERT [dbo].[HINHTHUCTHANHTOAN] ON 

INSERT [dbo].[HINHTHUCTHANHTOAN] ([IDHTTT], [MAHTTT], [TENHTTT], [ACTIVE]) VALUES (1, N'TM', N'Tiền mặt', 1)
INSERT [dbo].[HINHTHUCTHANHTOAN] ([IDHTTT], [MAHTTT], [TENHTTT], [ACTIVE]) VALUES (2, N'CK', N'Chuyển khoản', 1)
INSERT [dbo].[HINHTHUCTHANHTOAN] ([IDHTTT], [MAHTTT], [TENHTTT], [ACTIVE]) VALUES (3, N'N', N'Nợ', 1)
SET IDENTITY_INSERT [dbo].[HINHTHUCTHANHTOAN] OFF
GO
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([IDKH], [MAKH], [TENKH], [CCCD], [DIACHI], [SDT], [EMAIL], [MATKHAU], [GIOITINH], [MASOTHUE], [GHICHU], [NVIDSALE], [HINHANH], [NGAYSINH], [FACEBOOK], [ZALO], [ACTIVE]) VALUES (2, N'hienca', N'Nguyễn Hiền', N'1234567', N'Hóc Môn, HCM', N'0384319201', N'nguyenlongthan0@gmail.com', N'KH', N'0', N'43453213', N'ABC', NULL, N'f7752048-4db8-4b12-9440-23a04ed0391f_anhthe8.jpg', NULL, NULL, NULL, 1)
INSERT [dbo].[KHACHHANG] ([IDKH], [MAKH], [TENKH], [CCCD], [DIACHI], [SDT], [EMAIL], [MATKHAU], [GIOITINH], [MASOTHUE], [GHICHU], [NVIDSALE], [HINHANH], [NGAYSINH], [FACEBOOK], [ZALO], [ACTIVE]) VALUES (30, N'192X168X1X60384319203', N'Phan Thanh Hải', NULL, N'Hóc Môn, Hồ Chí Minh', N'0384319203', NULL, NULL, N'2', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[NGANHANG] ON 

INSERT [dbo].[NGANHANG] ([IDNH], [TENNH], [DIACHI], [EMAIL], [MASOTHUE], [GHICHU], [ACTIVE], [IDHTTT]) VALUES (1, N'Vietcombank', N'Hóc môn, HCM', N'nguyenvanhien050601@gmail.com', N'43453213', NULL, 1, 2)
SET IDENTITY_INSERT [dbo].[NGANHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[NHACUNGCAP] ON 

INSERT [dbo].[NHACUNGCAP] ([IDNCC], [MANCC], [TENNCC], [DIACHI], [EMAIL], [SDT], [MASOTHUE], [GHICHU], [FACEBOOK], [ZALO], [ACTIVE]) VALUES (2, N'NCC1', N'Công ty linh kiện điện tử ABC', N'Đồng Tháp', N'nguyenvanhien050601@gmail.com', N'0384319201', N'43453213', NULL, NULL, NULL, 1)
INSERT [dbo].[NHACUNGCAP] ([IDNCC], [MANCC], [TENNCC], [DIACHI], [EMAIL], [SDT], [MASOTHUE], [GHICHU], [FACEBOOK], [ZALO], [ACTIVE]) VALUES (3, N'NCC2', N'Cty linh kiện HStore', N'Bình Mỹ, Củ Chi, Tp.HCM', N'vannhiena4@gmail.com', N'0384319201', N'43453213', N'uy tín', N'a', N'a', 1)
SET IDENTITY_INSERT [dbo].[NHACUNGCAP] OFF
GO
SET IDENTITY_INSERT [dbo].[NHANVIEN] ON 

INSERT [dbo].[NHANVIEN] ([IDNV], [MANV], [TENNV], [CCCD], [NGAYSINH], [GIOITINH], [DIACHI], [SDT], [EMAIL], [MASOTHUE], [MATKHAU], [HINHANH], [GHICHU], [FACEBOOK], [ZALO], [ACTIVE]) VALUES (1, N'NV001', N'Văn Hiền', N'12345678912', CAST(N'2001-06-05T00:00:00.000' AS DateTime), N'0', N'Hốc Môn, Hồ Chí Minh', N'0384319201', N'nguyenvanhien050601@gmail.com', N'43453213', N'nv', N'3605832b-39d4-4a94-8642-34f1b17ed56e_ahauphuongnhi.png', N'nhân viên đầu tiên', N'vanhien', N'NVH', 1)
INSERT [dbo].[NHANVIEN] ([IDNV], [MANV], [TENNV], [CCCD], [NGAYSINH], [GIOITINH], [DIACHI], [SDT], [EMAIL], [MASOTHUE], [MATKHAU], [HINHANH], [GHICHU], [FACEBOOK], [ZALO], [ACTIVE]) VALUES (2, N'NV002', N'Nguyễn Hiền', N'1234567', CAST(N'2001-06-05T00:00:00.000' AS DateTime), N'0', N'Đồng Tháp', N'0384319201', N'nguyenlongthan0@gmail.com', NULL, NULL, N'7997b738-fb29-4e39-9dc4-f104dcd02bfc_anhthe9.jpg', NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[NHANVIEN] OFF
GO
SET IDENTITY_INSERT [dbo].[NHOMHH] ON 

INSERT [dbo].[NHOMHH] ([IDNHH], [MANHH], [TENNHH], [ACTIVE]) VALUES (2, N'MB', N'Main board', 1)
INSERT [dbo].[NHOMHH] ([IDNHH], [MANHH], [TENNHH], [ACTIVE]) VALUES (3, N'MH', N'Màn hình', 1)
INSERT [dbo].[NHOMHH] ([IDNHH], [MANHH], [TENNHH], [ACTIVE]) VALUES (4, N'BPC', N'Bàn phím - Chuột', 1)
INSERT [dbo].[NHOMHH] ([IDNHH], [MANHH], [TENNHH], [ACTIVE]) VALUES (5, N'RAM', N'RAM', 1)
SET IDENTITY_INSERT [dbo].[NHOMHH] OFF
GO
SET IDENTITY_INSERT [dbo].[NOIDUNGDDH] ON 

INSERT [dbo].[NOIDUNGDDH] ([IDNDDDH], [SOLUONG], [DONGIA], [HETHANBH], [IDHH], [IDDH]) VALUES (43, 1, 8990000, CAST(N'2026-04-09T00:00:00.000' AS DateTime), 9, 41)
SET IDENTITY_INSERT [dbo].[NOIDUNGDDH] OFF
GO
SET IDENTITY_INSERT [dbo].[NOIDUNGPNK] ON 

INSERT [dbo].[NOIDUNGPNK] ([IDNDPNK], [SOLUONG], [DONGIA], [SOLO], [NGAYSX], [HANSD], [VAT], [CKTM], [IDHH], [IDPNK], [DONVITINH]) VALUES (7, 1, 10000, N'lq345', NULL, NULL, 0, 0, 7, 5, N'Cái')
INSERT [dbo].[NOIDUNGPNK] ([IDNDPNK], [SOLUONG], [DONGIA], [SOLO], [NGAYSX], [HANSD], [VAT], [CKTM], [IDHH], [IDPNK], [DONVITINH]) VALUES (9, 100, 300000, N'l3450', NULL, NULL, 10, 10, 8, 5, N'Cái')
INSERT [dbo].[NOIDUNGPNK] ([IDNDPNK], [SOLUONG], [DONGIA], [SOLO], [NGAYSX], [HANSD], [VAT], [CKTM], [IDHH], [IDPNK], [DONVITINH]) VALUES (10, 10, 100000, N'vga3fb', NULL, NULL, 10, 10, 5, 6, N'Cái')
INSERT [dbo].[NOIDUNGPNK] ([IDNDPNK], [SOLUONG], [DONGIA], [SOLO], [NGAYSX], [HANSD], [VAT], [CKTM], [IDHH], [IDPNK], [DONVITINH]) VALUES (11, 100, 150000, N'l345p', NULL, NULL, 0, 0, 7, 6, N'Cái')
INSERT [dbo].[NOIDUNGPNK] ([IDNDPNK], [SOLUONG], [DONGIA], [SOLO], [NGAYSX], [HANSD], [VAT], [CKTM], [IDHH], [IDPNK], [DONVITINH]) VALUES (12, 20, 5000000, N'l345', NULL, NULL, 0, 0, 9, 7, N'Cái')
SET IDENTITY_INSERT [dbo].[NOIDUNGPNK] OFF
GO
SET IDENTITY_INSERT [dbo].[NOIDUNGPXK] ON 

INSERT [dbo].[NOIDUNGPXK] ([IDNDPXK], [SOLUONG], [DONGIA], [VAT], [CKTM], [IDPXK], [IDHH]) VALUES (22, 1, 8990000, 0, 0, 18, 9)
SET IDENTITY_INSERT [dbo].[NOIDUNGPXK] OFF
GO
SET IDENTITY_INSERT [dbo].[NOIDUNGTHUNODDH] ON 

INSERT [dbo].[NOIDUNGTHUNODDH] ([IDNDTNDDH], [IDPTNKH], [IDDH], [NGAYTHUNO], [SOTIEN], [GHICHU]) VALUES (4, 12, 41, CAST(N'2023-04-25T10:44:11.663' AS DateTime), 8990000, NULL)
SET IDENTITY_INSERT [dbo].[NOIDUNGTHUNODDH] OFF
GO
SET IDENTITY_INSERT [dbo].[NOIDUNGTRANONCC] ON 

INSERT [dbo].[NOIDUNGTRANONCC] ([IDNDTNNCC], [IDPTNNCC], [IDPNK], [SOTIEN], [NGAYTRANO], [GHICHU]) VALUES (3, 15, 6, 990000, CAST(N'2023-04-17T19:35:40.407' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[NOIDUNGTRANONCC] OFF
GO
SET IDENTITY_INSERT [dbo].[NUOSX] ON 

INSERT [dbo].[NUOSX] ([IDNSX], [MANSX], [TENNSX], [ACTIVE]) VALUES (1, N'NSX001', N'Việt Nam', 1)
INSERT [dbo].[NUOSX] ([IDNSX], [MANSX], [TENNSX], [ACTIVE]) VALUES (2, N'NSX002', N'Đài Loan', 1)
SET IDENTITY_INSERT [dbo].[NUOSX] OFF
GO
SET IDENTITY_INSERT [dbo].[PHIEUNHAPKHO] ON 

INSERT [dbo].[PHIEUNHAPKHO] ([IDPNK], [SOPHIEU], [NGAYLAP], [SOHD], [NGAYHD], [GHICHU], [ACTIVE], [IDNCC], [IDNV]) VALUES (5, N'PNKNV001-41620237:21:27PM', CAST(N'2023-04-16T19:57:21.373' AS DateTime), NULL, NULL, NULL, 1, 2, 1)
INSERT [dbo].[PHIEUNHAPKHO] ([IDPNK], [SOPHIEU], [NGAYLAP], [SOHD], [NGAYHD], [GHICHU], [ACTIVE], [IDNCC], [IDNV]) VALUES (6, N'PNKNV001-41720236:27:11AM', CAST(N'2023-04-17T06:27:11.077' AS DateTime), NULL, NULL, NULL, 1, 2, 1)
INSERT [dbo].[PHIEUNHAPKHO] ([IDPNK], [SOPHIEU], [NGAYLAP], [SOHD], [NGAYHD], [GHICHU], [ACTIVE], [IDNCC], [IDNV]) VALUES (7, N'PNKNV001-425202310:41:49AM', CAST(N'2023-04-25T10:41:49.927' AS DateTime), NULL, NULL, NULL, 1, 3, 1)
SET IDENTITY_INSERT [dbo].[PHIEUNHAPKHO] OFF
GO
SET IDENTITY_INSERT [dbo].[PHIEUTHUNOKH] ON 

INSERT [dbo].[PHIEUTHUNOKH] ([IDPTNKH], [SOPHIEU], [NGAYLAP], [GHICHU], [ACTIVE], [IDHTTT], [IDNV]) VALUES (12, N'PTN230425104411599TnSP13041', CAST(N'2023-04-25T10:44:11.600' AS DateTime), NULL, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[PHIEUTHUNOKH] OFF
GO
SET IDENTITY_INSERT [dbo].[PHIEUTRANONCC] ON 

INSERT [dbo].[PHIEUTRANONCC] ([IDPTNNCC], [SOPHIEU], [NGAYLAP], [GHICHU], [ACTIVE], [IDHTTT], [IDNV]) VALUES (11, N'PNKNV001-413202312:26:59PM', CAST(N'2023-04-15T13:26:12.580' AS DateTime), N'a', 1, 2, 1)
INSERT [dbo].[PHIEUTRANONCC] ([IDPTNNCC], [SOPHIEU], [NGAYLAP], [GHICHU], [ACTIVE], [IDHTTT], [IDNV]) VALUES (12, N'PXKNV001-41420233:27:11PM', CAST(N'2023-04-16T09:44:37.587' AS DateTime), N'lần 1', 1, 1, 1)
INSERT [dbo].[PHIEUTRANONCC] ([IDPTNNCC], [SOPHIEU], [NGAYLAP], [GHICHU], [ACTIVE], [IDHTTT], [IDNV]) VALUES (13, N'PXKNV001-41420233:27:11PM', CAST(N'2023-04-16T10:02:53.853' AS DateTime), N'lần 1', 1, 1, 1)
INSERT [dbo].[PHIEUTRANONCC] ([IDPTNNCC], [SOPHIEU], [NGAYLAP], [GHICHU], [ACTIVE], [IDHTTT], [IDNV]) VALUES (14, N'PXKNV001-41420233:27:11PM', CAST(N'2023-04-16T10:07:01.967' AS DateTime), N'lần 1', 1, 1, 1)
INSERT [dbo].[PHIEUTRANONCC] ([IDPTNNCC], [SOPHIEU], [NGAYLAP], [GHICHU], [ACTIVE], [IDHTTT], [IDNV]) VALUES (15, N'PNKNV001-41720236:27:11AM', CAST(N'2023-04-17T19:35:24.713' AS DateTime), N'lần 1', 1, 1, 1)
SET IDENTITY_INSERT [dbo].[PHIEUTRANONCC] OFF
GO
SET IDENTITY_INSERT [dbo].[PHIEUXUATKHO] ON 

INSERT [dbo].[PHIEUXUATKHO] ([IDPXK], [SOPHIEU], [NGAYLAP], [SOHD], [NGAYHD], [GHICHU], [ACTIVE], [IDNV], [IDKH]) VALUES (18, N'23042510424555440pk13041', CAST(N'2023-04-25T10:42:45.553' AS DateTime), NULL, NULL, NULL, 1, 1, 30)
SET IDENTITY_INSERT [dbo].[PHIEUXUATKHO] OFF
GO
SET IDENTITY_INSERT [dbo].[THUONGHIEU] ON 

INSERT [dbo].[THUONGHIEU] ([IDTH], [MATH], [TENTH], [ACTIVE]) VALUES (2, N'GB', N'GIGABYTE', 1)
INSERT [dbo].[THUONGHIEU] ([IDTH], [MATH], [TENTH], [ACTIVE]) VALUES (3, N'MSI', N'MSI', 1)
INSERT [dbo].[THUONGHIEU] ([IDTH], [MATH], [TENTH], [ACTIVE]) VALUES (4, N'GN', N'Genius', 1)
INSERT [dbo].[THUONGHIEU] ([IDTH], [MATH], [TENTH], [ACTIVE]) VALUES (5, N'LGT', N'LOGITECH', 1)
INSERT [dbo].[THUONGHIEU] ([IDTH], [MATH], [TENTH], [ACTIVE]) VALUES (6, N'Kingston', N'Kingston', 1)
INSERT [dbo].[THUONGHIEU] ([IDTH], [MATH], [TENTH], [ACTIVE]) VALUES (7, N'TEAMGROUP', N'TEAMGROUP', 1)
SET IDENTITY_INSERT [dbo].[THUONGHIEU] OFF
GO
ALTER TABLE [dbo].[DONDATHANG] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[HANGHOA] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[HINHTHUCTHANHTOAN] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[KHACHHANG] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[NGANHANG] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[NHACUNGCAP] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[NHANVIEN] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[NHOMHH] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[NUOSX] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[PHIEUNHAPKHO] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[PHIEUTHUNOKH] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[PHIEUTRANONCC] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[PHIEUXUATKHO] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[THUONGHIEU] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[CTNGANHANGKH]  WITH CHECK ADD  CONSTRAINT [FKCTNGANHANG333690] FOREIGN KEY([IDNH])
REFERENCES [dbo].[NGANHANG] ([IDNH])
GO
ALTER TABLE [dbo].[CTNGANHANGKH] CHECK CONSTRAINT [FKCTNGANHANG333690]
GO
ALTER TABLE [dbo].[CTNGANHANGKH]  WITH CHECK ADD  CONSTRAINT [FKCTNGANHANG63746] FOREIGN KEY([IDKH])
REFERENCES [dbo].[KHACHHANG] ([IDKH])
GO
ALTER TABLE [dbo].[CTNGANHANGKH] CHECK CONSTRAINT [FKCTNGANHANG63746]
GO
ALTER TABLE [dbo].[CTNGANHANGNCC]  WITH CHECK ADD  CONSTRAINT [FKCTNGANHANG648720] FOREIGN KEY([IDNCC])
REFERENCES [dbo].[NHACUNGCAP] ([IDNCC])
GO
ALTER TABLE [dbo].[CTNGANHANGNCC] CHECK CONSTRAINT [FKCTNGANHANG648720]
GO
ALTER TABLE [dbo].[CTNGANHANGNCC]  WITH CHECK ADD  CONSTRAINT [FKCTNGANHANG844559] FOREIGN KEY([IDNH])
REFERENCES [dbo].[NGANHANG] ([IDNH])
GO
ALTER TABLE [dbo].[CTNGANHANGNCC] CHECK CONSTRAINT [FKCTNGANHANG844559]
GO
ALTER TABLE [dbo].[DONDATHANG]  WITH CHECK ADD  CONSTRAINT [FKDONDATHANG344447] FOREIGN KEY([IDKH])
REFERENCES [dbo].[KHACHHANG] ([IDKH])
GO
ALTER TABLE [dbo].[DONDATHANG] CHECK CONSTRAINT [FKDONDATHANG344447]
GO
ALTER TABLE [dbo].[HANGHOA]  WITH CHECK ADD  CONSTRAINT [FKHANGHOA381251] FOREIGN KEY([IDTH])
REFERENCES [dbo].[THUONGHIEU] ([IDTH])
GO
ALTER TABLE [dbo].[HANGHOA] CHECK CONSTRAINT [FKHANGHOA381251]
GO
ALTER TABLE [dbo].[HANGHOA]  WITH CHECK ADD  CONSTRAINT [FKHANGHOA559869] FOREIGN KEY([IDNSX])
REFERENCES [dbo].[NUOSX] ([IDNSX])
GO
ALTER TABLE [dbo].[HANGHOA] CHECK CONSTRAINT [FKHANGHOA559869]
GO
ALTER TABLE [dbo].[HANGHOA]  WITH CHECK ADD  CONSTRAINT [FKHANGHOA58581] FOREIGN KEY([IDNHH])
REFERENCES [dbo].[NHOMHH] ([IDNHH])
GO
ALTER TABLE [dbo].[HANGHOA] CHECK CONSTRAINT [FKHANGHOA58581]
GO
ALTER TABLE [dbo].[NGANHANG]  WITH CHECK ADD  CONSTRAINT [FKNGANHANG536661] FOREIGN KEY([IDHTTT])
REFERENCES [dbo].[HINHTHUCTHANHTOAN] ([IDHTTT])
GO
ALTER TABLE [dbo].[NGANHANG] CHECK CONSTRAINT [FKNGANHANG536661]
GO
ALTER TABLE [dbo].[NOIDUNGDDH]  WITH CHECK ADD  CONSTRAINT [FKNOIDUNGDDH238686] FOREIGN KEY([IDHH])
REFERENCES [dbo].[HANGHOA] ([IDHH])
GO
ALTER TABLE [dbo].[NOIDUNGDDH] CHECK CONSTRAINT [FKNOIDUNGDDH238686]
GO
ALTER TABLE [dbo].[NOIDUNGDDH]  WITH CHECK ADD  CONSTRAINT [FKNOIDUNGDDH501508] FOREIGN KEY([IDDH])
REFERENCES [dbo].[DONDATHANG] ([IDDH])
GO
ALTER TABLE [dbo].[NOIDUNGDDH] CHECK CONSTRAINT [FKNOIDUNGDDH501508]
GO
ALTER TABLE [dbo].[NOIDUNGPNK]  WITH CHECK ADD  CONSTRAINT [FKNOIDUNGPNK226841] FOREIGN KEY([IDHH])
REFERENCES [dbo].[HANGHOA] ([IDHH])
GO
ALTER TABLE [dbo].[NOIDUNGPNK] CHECK CONSTRAINT [FKNOIDUNGPNK226841]
GO
ALTER TABLE [dbo].[NOIDUNGPNK]  WITH CHECK ADD  CONSTRAINT [FKNOIDUNGPNK363708] FOREIGN KEY([IDPNK])
REFERENCES [dbo].[PHIEUNHAPKHO] ([IDPNK])
GO
ALTER TABLE [dbo].[NOIDUNGPNK] CHECK CONSTRAINT [FKNOIDUNGPNK363708]
GO
ALTER TABLE [dbo].[NOIDUNGPXK]  WITH CHECK ADD  CONSTRAINT [FKNOIDUNGPXK205950] FOREIGN KEY([IDPXK])
REFERENCES [dbo].[PHIEUXUATKHO] ([IDPXK])
GO
ALTER TABLE [dbo].[NOIDUNGPXK] CHECK CONSTRAINT [FKNOIDUNGPXK205950]
GO
ALTER TABLE [dbo].[NOIDUNGPXK]  WITH CHECK ADD  CONSTRAINT [FKNOIDUNGPXK226531] FOREIGN KEY([IDHH])
REFERENCES [dbo].[HANGHOA] ([IDHH])
GO
ALTER TABLE [dbo].[NOIDUNGPXK] CHECK CONSTRAINT [FKNOIDUNGPXK226531]
GO
ALTER TABLE [dbo].[NOIDUNGTHUNODDH]  WITH CHECK ADD  CONSTRAINT [FKNOIDUNGTHU162083] FOREIGN KEY([IDDH])
REFERENCES [dbo].[DONDATHANG] ([IDDH])
GO
ALTER TABLE [dbo].[NOIDUNGTHUNODDH] CHECK CONSTRAINT [FKNOIDUNGTHU162083]
GO
ALTER TABLE [dbo].[NOIDUNGTHUNODDH]  WITH CHECK ADD  CONSTRAINT [FKNOIDUNGTHU506148] FOREIGN KEY([IDPTNKH])
REFERENCES [dbo].[PHIEUTHUNOKH] ([IDPTNKH])
GO
ALTER TABLE [dbo].[NOIDUNGTHUNODDH] CHECK CONSTRAINT [FKNOIDUNGTHU506148]
GO
ALTER TABLE [dbo].[NOIDUNGTHUNOKH]  WITH CHECK ADD  CONSTRAINT [FKNOIDUNGTHU248276] FOREIGN KEY([IDPXK])
REFERENCES [dbo].[PHIEUXUATKHO] ([IDPXK])
GO
ALTER TABLE [dbo].[NOIDUNGTHUNOKH] CHECK CONSTRAINT [FKNOIDUNGTHU248276]
GO
ALTER TABLE [dbo].[NOIDUNGTHUNOKH]  WITH CHECK ADD  CONSTRAINT [FKNOIDUNGTHU311955] FOREIGN KEY([IDPTNKH])
REFERENCES [dbo].[PHIEUTHUNOKH] ([IDPTNKH])
GO
ALTER TABLE [dbo].[NOIDUNGTHUNOKH] CHECK CONSTRAINT [FKNOIDUNGTHU311955]
GO
ALTER TABLE [dbo].[NOIDUNGTRANONCC]  WITH CHECK ADD  CONSTRAINT [FKNOIDUNGTRA430668] FOREIGN KEY([IDPNK])
REFERENCES [dbo].[PHIEUNHAPKHO] ([IDPNK])
GO
ALTER TABLE [dbo].[NOIDUNGTRANONCC] CHECK CONSTRAINT [FKNOIDUNGTRA430668]
GO
ALTER TABLE [dbo].[NOIDUNGTRANONCC]  WITH CHECK ADD  CONSTRAINT [FKNOIDUNGTRA854248] FOREIGN KEY([IDPTNNCC])
REFERENCES [dbo].[PHIEUTRANONCC] ([IDPTNNCC])
GO
ALTER TABLE [dbo].[NOIDUNGTRANONCC] CHECK CONSTRAINT [FKNOIDUNGTRA854248]
GO
ALTER TABLE [dbo].[PHIEUNHAPKHO]  WITH CHECK ADD  CONSTRAINT [FKPHIEUNHAPK10246] FOREIGN KEY([IDNV])
REFERENCES [dbo].[NHANVIEN] ([IDNV])
GO
ALTER TABLE [dbo].[PHIEUNHAPKHO] CHECK CONSTRAINT [FKPHIEUNHAPK10246]
GO
ALTER TABLE [dbo].[PHIEUNHAPKHO]  WITH CHECK ADD  CONSTRAINT [FKPHIEUNHAPK461022] FOREIGN KEY([IDNCC])
REFERENCES [dbo].[NHACUNGCAP] ([IDNCC])
GO
ALTER TABLE [dbo].[PHIEUNHAPKHO] CHECK CONSTRAINT [FKPHIEUNHAPK461022]
GO
ALTER TABLE [dbo].[PHIEUTHUNOKH]  WITH CHECK ADD  CONSTRAINT [FKPHIEUTHUNO460360] FOREIGN KEY([IDNV])
REFERENCES [dbo].[NHANVIEN] ([IDNV])
GO
ALTER TABLE [dbo].[PHIEUTHUNOKH] CHECK CONSTRAINT [FKPHIEUTHUNO460360]
GO
ALTER TABLE [dbo].[PHIEUTHUNOKH]  WITH CHECK ADD  CONSTRAINT [FKPHIEUTHUNO674725] FOREIGN KEY([IDHTTT])
REFERENCES [dbo].[HINHTHUCTHANHTOAN] ([IDHTTT])
GO
ALTER TABLE [dbo].[PHIEUTHUNOKH] CHECK CONSTRAINT [FKPHIEUTHUNO674725]
GO
ALTER TABLE [dbo].[PHIEUTRANONCC]  WITH CHECK ADD  CONSTRAINT [FKPHIEUTRANO140505] FOREIGN KEY([IDHTTT])
REFERENCES [dbo].[HINHTHUCTHANHTOAN] ([IDHTTT])
GO
ALTER TABLE [dbo].[PHIEUTRANONCC] CHECK CONSTRAINT [FKPHIEUTRANO140505]
GO
ALTER TABLE [dbo].[PHIEUTRANONCC]  WITH CHECK ADD  CONSTRAINT [FKPHIEUTRANO695999] FOREIGN KEY([IDNV])
REFERENCES [dbo].[NHANVIEN] ([IDNV])
GO
ALTER TABLE [dbo].[PHIEUTRANONCC] CHECK CONSTRAINT [FKPHIEUTRANO695999]
GO
ALTER TABLE [dbo].[PHIEUXUATKHO]  WITH CHECK ADD  CONSTRAINT [FKPHIEUXUATK390756] FOREIGN KEY([IDNV])
REFERENCES [dbo].[NHANVIEN] ([IDNV])
GO
ALTER TABLE [dbo].[PHIEUXUATKHO] CHECK CONSTRAINT [FKPHIEUXUATK390756]
GO
ALTER TABLE [dbo].[PHIEUXUATKHO]  WITH CHECK ADD  CONSTRAINT [FKPHIEUXUATK935766] FOREIGN KEY([IDKH])
REFERENCES [dbo].[KHACHHANG] ([IDKH])
GO
ALTER TABLE [dbo].[PHIEUXUATKHO] CHECK CONSTRAINT [FKPHIEUXUATK935766]
GO
USE [master]
GO
ALTER DATABASE [ElectronicsStore] SET  READ_WRITE 
GO
