USE master
GO
CREATE DATABASE MedicineManager
GO

USE MedicineManager
GO

SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO
PRINT N'Creating [dbo].[NhaPhanPhoi]'
GO
CREATE TABLE [dbo].[NhaPhanPhoi]
(
[MaNPP] [int] NOT NULL IDENTITY(1, 1),
[TenNPP] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DiaChi] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DienThoai] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Fax] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Email] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[MaSoThue] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[GhiChu] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_NhaPhanPhoi] on [dbo].[NhaPhanPhoi]'
GO
ALTER TABLE [dbo].[NhaPhanPhoi] ADD CONSTRAINT [PK_NhaPhanPhoi] PRIMARY KEY CLUSTERED ([MaNPP])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[DelNhaPhanPhoiByMaNPP]'
GO

CREATE PROC DelNhaPhanPhoiByMaNPP
@MaNPP int
AS
Begin
	DELETE NhaPhanPhoi WHERE MaNPP = @MaNPP
End



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[Thuoc]'
GO
CREATE TABLE [dbo].[Thuoc]
(
[IDThuoc] [int] NOT NULL IDENTITY(1, 1),
[MaThuoc] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[TenThuoc] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[MaNhom] [int] NOT NULL CONSTRAINT [DF_Thuoc_MaNhom] DEFAULT ((1)),
[NguonGoc] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Thuoc_NguonGoc] DEFAULT (N''),
[MaNSX] [int] NOT NULL CONSTRAINT [DF_Thuoc_MaNSX] DEFAULT ((1)),
[SoLuong] [int] NOT NULL CONSTRAINT [DF_Thuoc_SoLuong] DEFAULT ((0)),
[Thue] [float] NOT NULL CONSTRAINT [DF_Thuoc_Thue] DEFAULT ((0)),
[GiaBan] [money] NOT NULL CONSTRAINT [DF_Thuoc_GiaBan] DEFAULT ((0)),
[MaDVT] [int] NOT NULL CONSTRAINT [DF_Thuoc_MaDVT] DEFAULT ((1)),
[DangDongGoi] [int] NOT NULL CONSTRAINT [DF_Thuoc_DangDongGoi] DEFAULT ((1)),
[SoLuongDongGoi] [int] NOT NULL CONSTRAINT [DF_Thuoc_SoLuongDongGoi] DEFAULT ((0)),
[SoDangKy] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF_Thuoc_SoDangKy] DEFAULT (N''),
[DangBaoChe] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF_Thuoc_DangBaoChe] DEFAULT (N''),
[ThanhPhan] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF_Thuoc_ThanhPhan] DEFAULT (N''),
[HamLuong] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF_Thuoc_HamLuong] DEFAULT (N''),
[CongDung] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF_Thuoc_CongDung] DEFAULT (N''),
[PhanTacDung] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF_Thuoc_PhanTacDung] DEFAULT (N''),
[CachDung] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF_Thuoc_CachDung] DEFAULT (N''),
[ChuY] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF_Thuoc_ChuY] DEFAULT (N''),
[HanSuDung] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF_Thuoc_HanSuDung] DEFAULT (N''),
[BaoQuan] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF_Thuoc_BaoQuan] DEFAULT (N'')
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_Thuoc] on [dbo].[Thuoc]'
GO
ALTER TABLE [dbo].[Thuoc] ADD CONSTRAINT [PK_Thuoc] PRIMARY KEY CLUSTERED ([IDThuoc])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[KiemTraNSX]'
GO
CREATE Proc KiemTraNSX
@MaNSX int
As
Select * From Thuoc Where MaNSX=@MaNSX



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[NhaSanXuat]'
GO
CREATE TABLE [dbo].[NhaSanXuat]
(
[MaNSX] [int] NOT NULL IDENTITY(1, 1),
[TenNSX] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DiaChi] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DienThoai] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Fax] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Email] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[GhiChu] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_NhaCungCap] on [dbo].[NhaSanXuat]'
GO
ALTER TABLE [dbo].[NhaSanXuat] ADD CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED ([MaNSX])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[DelNhaSanXuatByMaNSX]'
GO

CREATE PROC DelNhaSanXuatByMaNSX
@MaNSX int
AS
Begin
	DELETE NhaSanXuat WHERE MaNSX = @MaNSX
End



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[KiemTraDVT]'
GO
CREATE Proc KiemTraDVT
@MaDVT int
As
Select * From Thuoc Where MaDVT=@MaDVT or DangDongGoi=@MaDVT



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[DonViTinh]'
GO
CREATE TABLE [dbo].[DonViTinh]
(
[MaDVT] [int] NOT NULL IDENTITY(1, 1),
[TenDVT] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_DonViTinh] on [dbo].[DonViTinh]'
GO
ALTER TABLE [dbo].[DonViTinh] ADD CONSTRAINT [PK_DonViTinh] PRIMARY KEY CLUSTERED ([MaDVT])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[DelDonViTinhByMaDVT]'
GO

CREATE PROC DelDonViTinhByMaDVT
@MaDVT int
AS
Begin
	DELETE DonViTinh WHERE MaDVT = @MaDVT
End



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[KiemTraNhomThuoc]'
GO
CREATE Proc KiemTraNhomThuoc
@MaNhom int
As
Select * From Thuoc Where MaNhom=@MaNhom



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[InsertThuoc]'
GO
CREATE Proc InsertThuoc
@MaThuoc Nvarchar(50),
@TenThuoc Nvarchar(100),
@MaNhom int,
@NguonGoc Nvarchar(100),
@MaNSX int,
@SoLuong int,
@Thue Float,
@GiaBan Money,
@MaDVT int,
@DangDongGoi int,
@SoLuongDongGoi int,
@SoDangKy Nvarchar(500),
@DangBaoChe Nvarchar(500),
@ThanhPhan Nvarchar(500),
@HamLuong Nvarchar(500),
@CongDung Nvarchar(500),
@PhanTacDung Nvarchar(500),
@CachDung Nvarchar(500),
@ChuY Nvarchar(500),
@HanSuDung Nvarchar(500),
@BaoQuan Nvarchar(500)
As
Insert Into Thuoc Values(@MaThuoc,@TenThuoc,@MaNhom,@NguonGoc,@MaNSX,@SoLuong,@Thue,@GiaBan,@MaDVT,@DangDongGoi, 
				 @SoLuongDongGoi,@SoDangKy,@DangBaoChe,@ThanhPhan,@HamLuong,@CongDung,@PhanTacDung, 
				 @CachDung,@ChuY,@HanSuDung,@BaoQuan)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[ChiTietHoaDonNhap]'
GO
CREATE TABLE [dbo].[ChiTietHoaDonNhap]
(
[MaCTHDN] [int] NOT NULL IDENTITY(1, 1),
[MaHDN] [int] NOT NULL,
[IDThuoc] [int] NOT NULL,
[SoLuong] [int] NOT NULL,
[GiaNhap] [money] NOT NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_ChiTietHoaDonNhap] on [dbo].[ChiTietHoaDonNhap]'
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap] ADD CONSTRAINT [PK_ChiTietHoaDonNhap] PRIMARY KEY CLUSTERED ([MaCTHDN])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[KiemTraThuocHDN]'
GO
CREATE Proc KiemTraThuocHDN
@IDThuoc Nvarchar(100)
As
Select * From ChiTietHoaDonNhap Where IDThuoc = @IDThuoc


GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[ChiTietHoaDonXuat]'
GO
CREATE TABLE [dbo].[ChiTietHoaDonXuat]
(
[MaCTHDX] [int] NOT NULL IDENTITY(1, 1),
[MaHDX] [int] NOT NULL,
[IDThuoc] [int] NOT NULL,
[SoLuong] [int] NOT NULL,
[GiaBan] [money] NOT NULL,
[Thue] [float] NOT NULL,
[DonVi] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_ChiTietHoaDonXuat] on [dbo].[ChiTietHoaDonXuat]'
GO
ALTER TABLE [dbo].[ChiTietHoaDonXuat] ADD CONSTRAINT [PK_ChiTietHoaDonXuat] PRIMARY KEY CLUSTERED ([MaCTHDX])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[KiemTraThuocHDX]'
GO

CREATE Proc KiemTraThuocHDX
@IDThuoc Nvarchar(50)
As
Select * From ChiTietHoaDonXuat Where IDThuoc=@IDThuoc



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[UpdateDVT]'
GO

CREATE Proc UpdateDVT
@MaDVT int,
@TenDVT Nvarchar(50)
As
	Update DonViTinh set TenDVT=@TenDVT Where MaDVT = @MaDVT

Select * From DonViTInh



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BenhNhan]'
GO
CREATE TABLE [dbo].[BenhNhan]
(
[IDBN] [int] NOT NULL IDENTITY(1, 1),
[MaBN] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[HoTen] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Tuoi] [int] NOT NULL,
[DiaChi] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DienThoai] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_KhachHang] on [dbo].[BenhNhan]'
GO
ALTER TABLE [dbo].[BenhNhan] ADD CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED ([IDBN])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[InsertBenhNhan_Haitx]'
GO


CREATE PROC InsertBenhNhan_Haitx
@MaBN nvarchar(50),
@HoTen nvarchar(100),
@Tuoi int,
@DiaChi nvarchar(500),
@DienThoai varchar(50)
as
insert into BenhNhan
(MaBN,HoTen,Tuoi,DiaChi,DienThoai)
Values
(@MaBN,@HoTen,@Tuoi,@DiaChi,@DienThoai)


GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[DVT_Insert]'
GO

CREATE PROC DVT_Insert
as
insert into DonViTinh Values ('')



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[UpdateBenhNhan_Haitx]'
GO
CREATE PROC UpdateBenhNhan_Haitx
@IDBN int,
@MaBN nvarchar(50),
@HoTen nvarchar(100),
@Tuoi int,
@DiaChi nvarchar(500),
@DienThoai varchar(50)
as
Update BenhNhan Set
 MaBN= @MaBN,HoTen= @HoTen,Tuoi= @Tuoi,DiaChi= @DiaChi,DienThoai= @DienThoai 
 Where IDBN= @IDBN


GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[DelThuoc]'
GO

CREATE PROC DelThuoc
@MaThuoc Nvarchar(50)
AS
Begin
	DELETE Thuoc WHERE MaThuoc = @MaThuoc
End



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[NSX_Insert]'
GO
CREATE PROC NSX_Insert
as
insert into NhaSanXuat Values ('','','','','','')



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[SelectLastBenhNhan_Haitx]'
GO
CREATE PROC SelectLastBenhNhan_Haitx
AS
SELECT * FROM BenhNhan ORDER BY IDBN DESC


GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[Users]'
GO
CREATE TABLE [dbo].[Users]
(
[IDUser] [int] NOT NULL IDENTITY(1, 1),
[Username] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Password] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[HoTen] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DiaChi] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_Users] on [dbo].[Users]'
GO
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([IDUser])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetUser]'
GO

CREATE PROC GetUser
@Username nvarchar(50),
@Password nvarchar(50)
AS
SELECT * FROM Users WHERE Username = @Username AND Password = @Password



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[SystemLog]'
GO
CREATE TABLE [dbo].[SystemLog]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[IDUser] [int] NOT NULL,
[DateLogin] [datetime] NOT NULL,
[Description] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_SystemLog] on [dbo].[SystemLog]'
GO
ALTER TABLE [dbo].[SystemLog] ADD CONSTRAINT [PK_SystemLog] PRIMARY KEY CLUSTERED ([ID])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[SetDateLoginUser]'
GO
CREATE PROC SetDateLoginUser
@IDUser int,
@DateLogin datetime,
@Description nvarchar(200)
AS
INSERT INTO SystemLog(IDUser,DateLogin,Description) VALUES(@IDUser,@DateLogin,@Description)



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetLastLoginUser]'
GO
CREATE PROC GetLastLoginUser
@IDUser int
AS
SELECT Top 1* FROM SystemLog WHERE IDUser = @IDUser AND Description like N'%Đăng Nhập%' ORDER BY ID DESC
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[NSX_Update]'
GO

CREATE Proc NSX_Update
@MaNSX int,
@TenNSX Nvarchar(100),
@DiaChi Nvarchar(200),
@DienThoai Nvarchar(100),
@Fax Nvarchar(100),
@Email Nvarchar(100),
@GhiChu Nvarchar(200)
As
	Update NhaSanXuat set TenNSX=@TenNSX, DiaChi=@DiaChi, DienThoai=@DienThoai, Fax=@Fax, 
					  Email=@Email, GhiChu=@GhiChu 
					  Where MaNSX = @MaNSX 



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetCurrentUserSystemLog]'
GO
CREATE PROC GetCurrentUserSystemLog
@IDUser int
AS
SELECT * FROM SystemLog WHERE IDUser = @IDUser ORDER BY ID DESC




GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[NPP_Insert]'
GO
CREATE PROC NPP_Insert
as
insert into NhaPhanPhoi Values ('','','','','','','')



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[NPP_Update]'
GO

CREATE Proc NPP_Update
@MaNPP int,
@TenNPP Nvarchar(100),
@DiaChi Nvarchar(200),
@DienThoai Nvarchar(100),
@Fax Nvarchar(100),
@Email Nvarchar(100),
@MaSoThue Nvarchar(100),
@GhiChu Nvarchar(200)
As
	Update NhaPhanPhoi set TenNPP=@TenNPP, DiaChi=@DiaChi, DienThoai=@DienThoai, Fax=@Fax, 
					  Email=@Email,MaSoThue=@MaSoThue, GhiChu=@GhiChu 
					  Where MaNPP = @MaNPP



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetNPPBYTenNSX]'
GO
Create PROC GetNPPBYTenNSX
@TenNPP nvarchar(100)
AS 
SELECT * From NhaPhanPhoi
WHERE TenNPP LIKE @TenNPP ORDER BY MaNPP


GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetNPPBYTenNPP]'
GO
CREATE PROC GetNPPBYTenNPP
@TenNPP nvarchar(100)
AS 
SELECT * From NhaPhanPhoi
WHERE TenNPP LIKE @TenNPP ORDER BY MaNPP



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[HoaDonNhap]'
GO
CREATE TABLE [dbo].[HoaDonNhap]
(
[MaHDN] [int] NOT NULL IDENTITY(1, 1),
[MaNPP] [int] NOT NULL,
[NguoiGiao] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[NguoiNhan] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[TongTienThuoc] [money] NOT NULL,
[TongThue] [float] NOT NULL,
[TongTienHD] [money] NOT NULL,
[NgayViet] [datetime] NOT NULL,
[NgayNhap] [datetime] NOT NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_HoaDonNhap] on [dbo].[HoaDonNhap]'
GO
ALTER TABLE [dbo].[HoaDonNhap] ADD CONSTRAINT [PK_HoaDonNhap] PRIMARY KEY CLUSTERED ([MaHDN])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[HoaDonNhap_Insert]'
GO
CREATE PROC HoaDonNhap_Insert
@MaNPP Nvarchar(50),
@NguoiGiao Nvarchar(50),
@NguoiNhan Nvarchar(50),
@TongTienThuoc money,
@TongThue float,
@TongTienHD money,
@NgayViet Datetime,
@NgayNhap Datetime
As
Insert Into HoaDOnNhap Values (@MaNPP,@NguoiGiao,@NguoiNhan,@TongTienThuoc,@TongThue,@TongTienHD,@NgayViet,@NgayNhap)



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetLastMaHoaDonNhap]'
GO
CREATE PROC GetLastMaHoaDonNhap
AS
SELECT Top 1 MaHDN FROM HoaDonNhap ORDER BY MaHDN DESC



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[ChiTietHoaDonNhap_Insert]'
GO
CREATE PROC ChiTietHoaDonNhap_Insert
@MaHDN int,
@IDThuoc int,
@SoLuong int,
@GiaNhap money
As
Insert Into ChiTietHoaDonNhap Values (@MaHDN,@IDThuoc,@SoLuong,@GiaNhap)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[UpdateSoLuongThuocNhap]'
GO
CREATE PROC UpdateSoLuongThuocNhap
@IDThuoc int,
@SoLuong int
AS
UPDATE Thuoc SET SoLuong = SoLuong + @SoLuong
WHERE IDTHuoc = @IDThuoc
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[DelChiTietHDNByMaHDN]'
GO
CREATE PROC DelChiTietHDNByMaHDN
@MaHDN int
AS
DELETE ChiTietHoaDonNhap
WHERE MaHDN = @MaHDN


GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[DelHoaDOnNhapByMaHDN]'
GO
CREATE PROC DelHoaDOnNhapByMaHDN
@MaHDN int
AS
Begin
	DELETE ChiTietHoaDonNhap WHERE MaHDN = @MaHDN
	DELETE HoaDonNhap WHERE MaHDN = @MaHDN
End



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[getAllHDN]'
GO
CREATE PROC getAllHDN
@TenNPP Nvarchar(100),
@MaThuoc Nvarchar(50),
@FromDate datetime,
@ToDate datetime
AS
SELECT MaHDN,HDN.MaNPP,TenNPP,NguoiGiao,NguoiNhan,TongTienThuoc,TongThue,TongTienHD,NgayViet,NgayNhap 
From HoaDOnNhap as HDN, NhaPhanPhoi as NPP
Where HDN.MaNPP=NPP.MaNPP and (NgayNhap between @FromDate and @ToDate) and TenNPP like @TenNPP and
			MaHDN in (Select MaHDN From ChiTietHoaDOnNhap as CT,Thuoc as T 
					  Where Ct.IDThuoc=T.IDThuoc and MaThuoc like @MaThuoc) Order by (MaHDN) DESC
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetChiTietHDN_MaHDN]'
GO
CREATE PROC GetChiTietHDN_MaHDN
@MaHDN int
AS
SELECT MaCTHDN,MaHDN,CT.IDThuoc,TenThuoc,CT.SoLuong,GiaNhap From ChiTietHoaDonNhap as CT, Thuoc as T Where MaHDN = @MaHDN and T.IDThuoc=CT.IDThuoc
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[HoaDonXuat]'
GO
CREATE TABLE [dbo].[HoaDonXuat]
(
[MaHDX] [int] NOT NULL IDENTITY(1, 1),
[IDBN] [int] NOT NULL,
[NgayLap] [datetime] NOT NULL,
[TongTienThuoc] [money] NOT NULL,
[TongThue] [float] NOT NULL,
[TongTienHD] [money] NOT NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_HoaDonXuat] on [dbo].[HoaDonXuat]'
GO
ALTER TABLE [dbo].[HoaDonXuat] ADD CONSTRAINT [PK_HoaDonXuat] PRIMARY KEY CLUSTERED ([MaHDX])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetHoaDonXuat_MaHDX]'
GO
CREATE PROC GetHoaDonXuat_MaHDX
@MaHDX int
AS
SELECT * FROM HoaDonXuat
WHERE MaHDX = @MaHDX





GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetBenhNhan_MaBN]'
GO
CREATE PROC GetBenhNhan_MaBN
@MaBN nvarchar(100)
AS
SELECT * FROM BenhNhan
WHERE MaBN = @MaBN

GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetDonThuocByMaHDX]'
GO
CREATE PROC GetDonThuocByMaHDX
@MaHDX int
AS 
SELECT HDX.MaHDX,BN.MaBN,HDX.NgayLap,HDX.TongTienThuoc,HDX.TongThue,HDX.TongTienHD,
BN.HoTen,BN.Tuoi,BN.DiaChi,BN.DienThoai,
T.MaThuoc,CT.SoLuong,CT.GiaBan,CT.Thue,CT.DonVi,ThanhTien = (CT.SoLuong*CT.GiaBan)
FROM ((HoaDonXuat AS HDX INNER JOIN BenhNhan AS BN ON HDX.IDBN = BN.IDBN)
INNER JOIN ChiTietHoaDonXuat AS CT ON HDX.MaHDX = CT.MaHDX)
INNER JOIN Thuoc AS T ON CT.IDThuoc = T.IDThuoc
WHERE HDX.MaHDX = @MaHDX

GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[NhomThuoc]'
GO
CREATE TABLE [dbo].[NhomThuoc]
(
[MaNhom] [int] NOT NULL IDENTITY(1, 1),
[TenNhom] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[GhiChu] [nchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_NhomThuoc] on [dbo].[NhomThuoc]'
GO
ALTER TABLE [dbo].[NhomThuoc] ADD CONSTRAINT [PK_NhomThuoc] PRIMARY KEY CLUSTERED ([MaNhom])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetBenhNhanDetails]'
GO
CREATE PROC GetBenhNhanDetails
@MaBN nvarchar(100)
AS
SELECT * FROM BenhNhan
WHERE MaBN LIKE @MaBN



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[HoaDonXuat_Insert]'
GO
CREATE PROCEDURE HoaDonXuat_Insert
@IDBN int,
@NgayLap datetime,
@TongTienThuoc money,
@TongThue float,
@TongTienHD money
as
insert into HoaDonXuat
(IDBN,NgayLap,TongTienThuoc,TongThue,TongTienHD)
Values
(@IDBN,@NgayLap,@TongTienThuoc,@TongThue,@TongTienHD)


GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[UpdateSoLuongThuoc]'
GO

CREATE PROC UpdateSoLuongThuoc
@IDThuoc int,
@SoLuong int
AS
UPDATE Thuoc SET SoLuong = SoLuong - @SoLuong
WHERE IDThuoc = @IDThuoc

GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[ChiTietHoaDonXuat_Insert]'
GO
CREATE PROC ChiTietHoaDonXuat_Insert
@MaHDX int,
@IDThuoc int,
@SoLuong int,
@GiaBan money,
@Thue float,
@DonVi nvarchar(50)
as
insert into ChiTietHoaDonXuat
(MaHDX,IDThuoc,SoLuong,GiaBan,Thue,DonVi)
Values
(@MaHDX,@IDThuoc,@SoLuong,@GiaBan,@Thue,@DonVi)

GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetLastHoaDonXuat]'
GO
CREATE PROC GetLastHoaDonXuat
AS
SELECT * FROM HoaDonXuat ORDER BY MaHDX DESC

GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[DelChiTietHDXByMaHDX]'
GO
CREATE PROC DelChiTietHDXByMaHDX
@MaHDX int
AS
DELETE ChiTietHoaDonXuat
WHERE MaHDX = @MaHDX




GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[TimKiemThuoc]'
GO
Create PROC TimKiemThuoc
@MaThuoc nvarchar(100),
@MaNhom int,
@MaNSX int
AS
Begin 
	if ((@MaNhom=0) and (@MaNSX=0))
		SELECT T.IDThuoc,T.MaThuoc,T.TenThuoc,NT.TenNhom,T.NguonGoc,NSX.TenNSX,T.SoLuong,T.Thue,T.GiaBan,
		DVT.TenDVT,DDG.TenDVT,T.SoLuongDongGoi,T.SoDangKy,T.DangBaoChe,T.ThanhPhan,
		T.HamLuong,T.CongDung,T.PhanTacDung,T.CachDung,T.ChuY,T.HanSuDung,T.BaoQuan,T.MaNhom,
		T.MaNSX,T.MaDVT,T.DangDongGoi
		FROM (((Thuoc AS T INNER JOIN NhomThuoc AS NT ON T.MaNhom = NT.MaNhom)
		INNER JOIN NhaSanXuat AS NSX ON T.MaNSX = NSX.MaNSX) 
		INNER JOIN DonViTinh AS DVT ON T.MaDVT = DVT.MaDVT)
		INNER JOIN DonViTinh AS DDG ON T.DangDongGoi = DDG.MaDVT
		WHERE T.MaThuoc LIKE @MaThuoc 
	else if (@MaNhom>0) and (@MaNSX=0)
		SELECT T.IDThuoc,T.MaThuoc,T.TenThuoc,NT.TenNhom,T.NguonGoc,NSX.TenNSX,T.SoLuong,T.Thue,T.GiaBan,
		DVT.TenDVT,DDG.TenDVT,T.SoLuongDongGoi,T.SoDangKy,T.DangBaoChe,T.ThanhPhan,
		T.HamLuong,T.CongDung,T.PhanTacDung,T.CachDung,T.ChuY,T.HanSuDung,T.BaoQuan,T.MaNhom,
		T.MaNSX,T.MaDVT,T.DangDongGoi
		FROM (((Thuoc AS T INNER JOIN NhomThuoc AS NT ON T.MaNhom = NT.MaNhom)
		INNER JOIN NhaSanXuat AS NSX ON T.MaNSX = NSX.MaNSX) 
		INNER JOIN DonViTinh AS DVT ON T.MaDVT = DVT.MaDVT)
		INNER JOIN DonViTinh AS DDG ON T.DangDongGoi = DDG.MaDVT
		WHERE T.MaThuoc LIKE @MaThuoc and T.MaNhom=@MaNhom
	else if (@MaNhom=0) and (@MaNSX>0)
		SELECT T.IDThuoc,T.MaThuoc,T.TenThuoc,NT.TenNhom,T.NguonGoc,NSX.TenNSX,T.SoLuong,T.Thue,T.GiaBan,
		DVT.TenDVT,DDG.TenDVT,T.SoLuongDongGoi,T.SoDangKy,T.DangBaoChe,T.ThanhPhan,
		T.HamLuong,T.CongDung,T.PhanTacDung,T.CachDung,T.ChuY,T.HanSuDung,T.BaoQuan,T.MaNhom,
		T.MaNSX,T.MaDVT,T.DangDongGoi
		FROM (((Thuoc AS T INNER JOIN NhomThuoc AS NT ON T.MaNhom = NT.MaNhom)
		INNER JOIN NhaSanXuat AS NSX ON T.MaNSX = NSX.MaNSX) 
		INNER JOIN DonViTinh AS DVT ON T.MaDVT = DVT.MaDVT)
		INNER JOIN DonViTinh AS DDG ON T.DangDongGoi = DDG.MaDVT
		WHERE T.MaThuoc LIKE @MaThuoc and T.MaNSX=@MaNSX
	else
		SELECT T.IDThuoc,T.MaThuoc,T.TenThuoc,NT.TenNhom,T.NguonGoc,NSX.TenNSX,T.SoLuong,T.Thue,T.GiaBan,
		DVT.TenDVT,DDG.TenDVT,T.SoLuongDongGoi,T.SoDangKy,T.DangBaoChe,T.ThanhPhan,
		T.HamLuong,T.CongDung,T.PhanTacDung,T.CachDung,T.ChuY,T.HanSuDung,T.BaoQuan,T.MaNhom,
		T.MaNSX,T.MaDVT,T.DangDongGoi
		FROM (((Thuoc AS T INNER JOIN NhomThuoc AS NT ON T.MaNhom = NT.MaNhom)
		INNER JOIN NhaSanXuat AS NSX ON T.MaNSX = NSX.MaNSX) 
		INNER JOIN DonViTinh AS DVT ON T.MaDVT = DVT.MaDVT)
		INNER JOIN DonViTinh AS DDG ON T.DangDongGoi = DDG.MaDVT
		WHERE T.MaThuoc LIKE @MaThuoc and T.MaNSX=@MaNSX and T.MaNhom=@MaNhom
End
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[DelHoaDonXuatByMaHDX]'
GO
CREATE PROC DelHoaDonXuatByMaHDX
@MaHDX int
AS
DELETE HoaDonXuat
WHERE MaHDX = @MaHDX


GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[DSHDX_NgayThangMaBN]'
GO
CREATE PROC DSHDX_NgayThangMaBN
@MaBN nvarchar(100),
@NgayLapTo datetime,
@NgayLapFrom datetime
AS
SELECT HDX.MaHDX,BN.IDBN,BN.MaBN,HDX.NgayLap,HDX.TongTienThuoc,HDX.TongThue,HDX.TongTienHD,BN.HoTen
FROM HoaDonXuat AS HDX INNER JOIN BenhNhan AS BN
ON HDX.IDBN = BN.IDBN
WHERE (HDX.NgayLap BETWEEN @NgayLapTo AND @NgayLapFrom) 
AND BN.MaBN LIKE @MaBN 
ORDER BY HDX.MaHDX DESC

GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetThuocBYTenThuoc]'
GO
CREATE PROC GetThuocBYTenThuoc
@MaThuoc nvarchar(100)
AS 
SELECT T.IDThuoc,T.MaThuoc,T.TenThuoc,NT.TenNhom,T.NguonGoc,NSX.TenNSX,T.SoLuong,T.Thue,T.GiaBan,
DVT.TenDVT,DDG.TenDVT,T.SoLuongDongGoi,T.SoDangKy,T.DangBaoChe,T.ThanhPhan,
T.HamLuong,T.CongDung,T.PhanTacDung,T.CachDung,T.ChuY,T.HanSuDung,T.BaoQuan
FROM (((Thuoc AS T INNER JOIN NhomThuoc AS NT ON T.MaNhom = NT.MaNhom)
INNER JOIN NhaSanXuat AS NSX ON T.MaNSX = NSX.MaNSX) 
INNER JOIN DonViTinh AS DVT ON T.MaDVT = DVT.MaDVT)
INNER JOIN DonViTinh AS DDG ON T.DangDongGoi = DDG.MaDVT
WHERE T.MaThuoc LIKE @MaThuoc ORDER BY T.TenThuoc

GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetChiTietHD_MaHDX]'
GO
CREATE PROC GetChiTietHD_MaHDX
@MaHDX int
AS
SELECT CTHDX.MaCTHDX,CTHDX.MaHDX,CTHDX.IDThuoc,T.MaThuoc,CTHDX.SoLuong,CTHDX.GiaBan,CTHDX.Thue,CTHDX.DonVi,T.TenThuoc
FROM ChiTietHoaDonXuat AS CTHDX INNER JOIN Thuoc AS T
ON CTHDX.IDThuoc = T.IDThuoc
WHERE CTHDX.MaHDX = @MaHDX
ORDER BY CTHDX.MaCTHDX DESC


GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetAllUser]'
GO
Create PROC GetAllUser
AS 
SELECT * From Users


GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetAllUsers]'
GO


------------------------------------- Hungnc --------------------------------
CREATE PROC GetAllUsers
AS 
SELECT * From Users



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetAllSystem]'
GO
CREATE PROC GetAllSystem
@FromDate varchar(40),
@ToDate varchar(40)
AS 
SELECT ID,SystemLog.IDUser,UserName,DateLogin,Description From SystemLog,Users 
Where SystemLog.IDUser=Users.IDUser and (DateLogin BETWEEN @FromDate AND @ToDate) Order by (ID) DESC
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[DelSystemLogByMaSys]'
GO
CREATE PROC DelSystemLogByMaSys
@MaSys int
AS
DELETE SystemLog
WHERE ID = @MaSys


GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[DelSystemLogByID]'
GO

CREATE PROC DelSystemLogByID
@ID int
AS
DELETE SystemLog
WHERE ID = @ID



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[getAllNhomThuoc]'
GO

CREATE PROC getAllNhomThuoc
AS
Select * From NhomThuoc



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[NhomThuoc_Insert]'
GO

CREATE PROC NhomThuoc_Insert
@TenNhom nvarchar(100),
@GhiChu nvarchar(100)
as
insert into NhomThuoc Values (@TenNhom,@GhiChu)



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[DelNhomThuocByMaNhom]'
GO

CREATE PROC DelNhomThuocByMaNhom
@MaNhom int
AS
Begin
	DELETE NhomThuoc WHERE MaNhom = @MaNhom
End



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetNSXBYTenNSX]'
GO
CREATE PROC GetNSXBYTenNSX
@TenNSX nvarchar(100)
AS 
SELECT * From NhaSanXuat
WHERE TenNSX LIKE @TenNSX ORDER BY MaNSX




GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetAllDVT]'
GO
CREATE PROC GetAllDVT
AS 
SELECT * From DonViTinh



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[UpdateThuoc]'
GO
CREATE Proc UpdateThuoc
@IDThuoc int,
@MaThuoc Nvarchar(50),
@TenThuoc Nvarchar(100),
@MaNhom int,
@NguonGoc Nvarchar(100),
@MaNSX int,
@SoLuong int,
@Thue Float,
@GiaBan Money,
@MaDVT int,
@DangDongGoi int,
@SoLuongDongGoi int,
@SoDangKy Nvarchar(500),
@DangBaoChe Nvarchar(500),
@ThanhPhan Nvarchar(500),
@HamLuong Nvarchar(500),
@CongDung Nvarchar(500),
@PhanTacDung Nvarchar(500),
@CachDung Nvarchar(500),
@ChuY Nvarchar(500),
@HanSuDung Nvarchar(500),
@BaoQuan Nvarchar(500)
As
UPDATE Thuoc SET MaThuoc=@MaThuoc,TenThuoc=@TenThuoc, MaNhom=@MaNhom , NguonGoc=@NguonGoc, MaNSX=@MaNSX, SoLuong=@SoLuong, 
				 Thue=@Thue, GiaBan=@GiaBan, MaDVT=@MaDVT, DangDongGoi=@DangDongGoi, 
				 SoLuongDongGoi=@SoLuongDongGoi, SoDangKy=@SoDangKy, DangBaoChe=@DangBaoChe, 
				 ThanhPhan=@ThanhPhan, HamLuong=@HamLuong, CongDung=@CongDung, PhanTacDung=@PhanTacDung, 
				 CachDung=@CachDung, ChuY=@ChuY, HanSuDung=@HanSuDung, BaoQuan=@BaoQuan
WHERE IDThuoc = @IDThuoc
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[UpdateNhomThuoc]'
GO

CREATE Proc UpdateNhomThuoc
@MaNhom int,
@TenNhom Nvarchar(100),
@GhiChu Nvarchar(100)
As
UPDATE NhomThuoc SET TenNhom=@TenNhom, GhiChu=@GhiChu
WHERE MaNhom = @MaNhom



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetThuocLast]'
GO

CREATE Proc GetThuocLast
As
Select Top 1 MaThuoc From Thuoc Order by (MaThuoc) DESC



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetThuocDetails_Hungnc]'
GO
CREATE PROC GetThuocDetails_Hungnc
@MaThuoc nvarchar(100)
AS 
SELECT T.IDThuoc,T.MaThuoc,T.TenThuoc,NT.TenNhom,T.NguonGoc,NSX.TenNSX,T.SoLuong,T.Thue,T.GiaBan,
DVT.TenDVT,DDG.TenDVT,T.SoLuongDongGoi,T.SoDangKy,T.DangBaoChe,T.ThanhPhan,
T.HamLuong,T.CongDung,T.PhanTacDung,T.CachDung,T.ChuY,T.HanSuDung,T.BaoQuan,T.MaNhom,
T.MaNSX,T.MaDVT,T.DangDongGoi       
FROM (((Thuoc AS T INNER JOIN NhomThuoc AS NT ON T.MaNhom = NT.MaNhom)
INNER JOIN NhaSanXuat AS NSX ON T.MaNSX = NSX.MaNSX) 
INNER JOIN DonViTinh AS DVT ON T.MaDVT = DVT.MaDVT)
INNER JOIN DonViTinh AS DDG ON T.DangDongGoi = DDG.MaDVT
WHERE T.MaThuoc = @MaThuoc
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetBenhNhan_IDBN]'
GO
CREATE PROC GetBenhNhan_IDBN
@IDBN int
AS
SELECT * FROM BenhNhan
WHERE IDBN = @IDBN

GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[DeleteBenhNhan]'
GO
CREATE PROCEDURE DeleteBenhNhan
@IDBN int
AS
Begin
DELETE ChiTietHoaDonXuat WHERE MaHDX IN (SELECT MaHDX FROM HoaDonXuat WHERE IDBN = @IDBN)
Delete HoaDonXuat WHERE IDBN = @IDBN
Delete BenhNhan WHERE IDBN = @IDBN
END


GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetThuocBYTenThuoc_Hungnc]'
GO
CREATE PROC GetThuocBYTenThuoc_Hungnc
@MaThuoc nvarchar(100)
AS 
SELECT T.IDThuoc,T.MaThuoc,T.TenThuoc,NT.TenNhom,T.NguonGoc,NSX.TenNSX,T.SoLuong,T.Thue,T.GiaBan,
DVT.TenDVT,DDG.TenDVT,T.SoLuongDongGoi,T.SoDangKy,T.DangBaoChe,T.ThanhPhan,
T.HamLuong,T.CongDung,T.PhanTacDung,T.CachDung,T.ChuY,T.HanSuDung,T.BaoQuan,T.MaNhom,
T.MaNSX,T.MaDVT,T.DangDongGoi
FROM (((Thuoc AS T INNER JOIN NhomThuoc AS NT ON T.MaNhom = NT.MaNhom)
INNER JOIN NhaSanXuat AS NSX ON T.MaNSX = NSX.MaNSX) 
INNER JOIN DonViTinh AS DVT ON T.MaDVT = DVT.MaDVT)
INNER JOIN DonViTinh AS DDG ON T.DangDongGoi = DDG.MaDVT
WHERE T.MaThuoc LIKE @MaThuoc ORDER BY T.MaThuoc
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[KiemTraNPP]'
GO
CREATE Proc KiemTraNPP
@MaNPP int
As
Select * From HoaDonNhap Where MaNPP=@MaNPP



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[GetThuocDetails]'
GO
CREATE PROC GetThuocDetails
@IDThuoc int
AS 
SELECT T.IDThuoc,T.MaThuoc,T.TenThuoc,NT.TenNhom,T.NguonGoc,NSX.TenNSX,T.SoLuong,T.Thue,T.GiaBan,
DVT.TenDVT,DDG.TenDVT,T.SoLuongDongGoi,T.SoDangKy,T.DangBaoChe,T.ThanhPhan,
T.HamLuong,T.CongDung,T.PhanTacDung,T.CachDung,T.ChuY,T.HanSuDung,T.BaoQuan
FROM (((Thuoc AS T INNER JOIN NhomThuoc AS NT ON T.MaNhom = NT.MaNhom)
INNER JOIN NhaSanXuat AS NSX ON T.MaNSX = NSX.MaNSX) 
INNER JOIN DonViTinh AS DVT ON T.MaDVT = DVT.MaDVT)
INNER JOIN DonViTinh AS DDG ON T.DangDongGoi = DDG.MaDVT
WHERE T.IDThuoc = @IDThuoc

GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[HoaDonNhap]'
GO
ALTER TABLE [dbo].[HoaDonNhap] WITH NOCHECK ADD
CONSTRAINT [FK_MaNPP] FOREIGN KEY ([MaNPP]) REFERENCES [dbo].[NhaPhanPhoi] ([MaNPP])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[HoaDonXuat]'
GO
ALTER TABLE [dbo].[HoaDonXuat] ADD
CONSTRAINT [FK_HoaDonXuat_BenhNhan] FOREIGN KEY ([IDBN]) REFERENCES [dbo].[BenhNhan] ([IDBN])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[ChiTietHoaDonNhap]'
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap] ADD
CONSTRAINT [FK_MaHDN] FOREIGN KEY ([MaHDN]) REFERENCES [dbo].[HoaDonNhap] ([MaHDN]),
CONSTRAINT [FK_ChiTietHoaDonNhap_Thuoc] FOREIGN KEY ([IDThuoc]) REFERENCES [dbo].[Thuoc] ([IDThuoc])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[ChiTietHoaDonXuat]'
GO
ALTER TABLE [dbo].[ChiTietHoaDonXuat] ADD
CONSTRAINT [FK_MaHDX] FOREIGN KEY ([MaHDX]) REFERENCES [dbo].[HoaDonXuat] ([MaHDX]),
CONSTRAINT [FK_ChiTietHoaDonXuat_Thuoc] FOREIGN KEY ([IDThuoc]) REFERENCES [dbo].[Thuoc] ([IDThuoc])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[Thuoc]'
GO
ALTER TABLE [dbo].[Thuoc] ADD
CONSTRAINT [FK_Thuoc_DonViTinh1] FOREIGN KEY ([DangDongGoi]) REFERENCES [dbo].[DonViTinh] ([MaDVT]),
CONSTRAINT [FK_MaNSX] FOREIGN KEY ([MaNSX]) REFERENCES [dbo].[NhaSanXuat] ([MaNSX]),
CONSTRAINT [FK_MaNhom] FOREIGN KEY ([MaNhom]) REFERENCES [dbo].[NhomThuoc] ([MaNhom])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[SystemLog]'
GO
ALTER TABLE [dbo].[SystemLog] ADD
CONSTRAINT [FK_SystemLog_Users] FOREIGN KEY ([IDUser]) REFERENCES [dbo].[Users] ([IDUser])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT 'The database update succeeded'
COMMIT TRANSACTION
END
ELSE PRINT 'The database update failed'
GO
DROP TABLE #tmpErrors
GO
























USE MedicineManager
GO

SET NUMERIC_ROUNDABORT OFF
GO
SET XACT_ABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS, NOCOUNT ON
GO
SET DATEFORMAT YMD
GO
-- Pointer used for text / image updates. This might not be needed, but is declared here just in case
DECLARE @pv binary(16)

BEGIN TRANSACTION

-- Drop constraints from [dbo].[Thuoc]
ALTER TABLE [dbo].[Thuoc] DROP CONSTRAINT [FK_MaNhom]
ALTER TABLE [dbo].[Thuoc] DROP CONSTRAINT [FK_MaNSX]
ALTER TABLE [dbo].[Thuoc] DROP CONSTRAINT [FK_Thuoc_DonViTinh1]

-- Drop constraints from [dbo].[ChiTietHoaDonXuat]
ALTER TABLE [dbo].[ChiTietHoaDonXuat] DROP CONSTRAINT [FK_ChiTietHoaDonXuat_Thuoc]
ALTER TABLE [dbo].[ChiTietHoaDonXuat] DROP CONSTRAINT [FK_MaHDX]

-- Drop constraints from [dbo].[ChiTietHoaDonNhap]
ALTER TABLE [dbo].[ChiTietHoaDonNhap] DROP CONSTRAINT [FK_ChiTietHoaDonNhap_Thuoc]
ALTER TABLE [dbo].[ChiTietHoaDonNhap] DROP CONSTRAINT [FK_MaHDN]

-- Drop constraints from [dbo].[SystemLog]
ALTER TABLE [dbo].[SystemLog] DROP CONSTRAINT [FK_SystemLog_Users]

-- Drop constraints from [dbo].[HoaDonXuat]
ALTER TABLE [dbo].[HoaDonXuat] DROP CONSTRAINT [FK_HoaDonXuat_BenhNhan]

-- Drop constraints from [dbo].[HoaDonNhap]
ALTER TABLE [dbo].[HoaDonNhap] DROP CONSTRAINT [FK_MaNPP]

-- Add 3 rows to [dbo].[BenhNhan]
SET IDENTITY_INSERT [dbo].[BenhNhan] ON
INSERT INTO [dbo].[BenhNhan] ([IDBN], [MaBN], [HoTen], [Tuoi], [DiaChi], [DienThoai]) VALUES (12, N'BN_1_Trần Hai 2', N'Trần Hai 2', 241, N'234', '243')
INSERT INTO [dbo].[BenhNhan] ([IDBN], [MaBN], [HoTen], [Tuoi], [DiaChi], [DienThoai]) VALUES (33, N'BN_19_Phạm Văn Mách', N'Phạm Văn Mách', 35, N'Hải Phòng', '123456')
INSERT INTO [dbo].[BenhNhan] ([IDBN], [MaBN], [HoTen], [Tuoi], [DiaChi], [DienThoai]) VALUES (43, N'BN_20_Trần Văn A', N'Trần Văn A', 23, N'Thanh Xuân Hà Nội', '1234567')
SET IDENTITY_INSERT [dbo].[BenhNhan] OFF

-- Add 6 rows to [dbo].[DonViTinh]
SET IDENTITY_INSERT [dbo].[DonViTinh] ON
INSERT INTO [dbo].[DonViTinh] ([MaDVT], [TenDVT]) VALUES (1, N'Viên')
INSERT INTO [dbo].[DonViTinh] ([MaDVT], [TenDVT]) VALUES (2, N'Cái')
INSERT INTO [dbo].[DonViTinh] ([MaDVT], [TenDVT]) VALUES (3, N'Hộp')
INSERT INTO [dbo].[DonViTinh] ([MaDVT], [TenDVT]) VALUES (4, N'Chai')
INSERT INTO [dbo].[DonViTinh] ([MaDVT], [TenDVT]) VALUES (5, N'Lọ')
INSERT INTO [dbo].[DonViTinh] ([MaDVT], [TenDVT]) VALUES (6, N'Túi')
SET IDENTITY_INSERT [dbo].[DonViTinh] OFF

-- Add 4 rows to [dbo].[NhaPhanPhoi]
SET IDENTITY_INSERT [dbo].[NhaPhanPhoi] ON
INSERT INTO [dbo].[NhaPhanPhoi] ([MaNPP], [TenNPP], [DiaChi], [DienThoai], [Fax], [Email], [MaSoThue], [GhiChu]) VALUES (1, N'Công ty cổ phần dược phẩm trung ương 2', N'Cầu Giấy', '04040404040', '04040404040', 'ctcpdptu@gmail.com', '4563456', N'aaa')
INSERT INTO [dbo].[NhaPhanPhoi] ([MaNPP], [TenNPP], [DiaChi], [DienThoai], [Fax], [Email], [MaSoThue], [GhiChu]) VALUES (3, N'Công ty ABC', N'Nguyễn Trãi', '36735683878', '3783783783578', 'sfgadfgs@gmail.com', '56345635', N'bbb')
INSERT INTO [dbo].[NhaPhanPhoi] ([MaNPP], [TenNPP], [DiaChi], [DienThoai], [Fax], [Email], [MaSoThue], [GhiChu]) VALUES (4, N'Công Ty dược phẩm Mỹ - Nhật - Trung', N'Gò Đống Đa', '', '', '', '', N'')
INSERT INTO [dbo].[NhaPhanPhoi] ([MaNPP], [TenNPP], [DiaChi], [DienThoai], [Fax], [Email], [MaSoThue], [GhiChu]) VALUES (5, N'Bệnh Viện Thuốc Trần Duy Hưng', N'', '', '', '', '', N'')
SET IDENTITY_INSERT [dbo].[NhaPhanPhoi] OFF

-- Add 3 rows to [dbo].[NhaSanXuat]
SET IDENTITY_INSERT [dbo].[NhaSanXuat] ON
INSERT INTO [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [DiaChi], [DienThoai], [Fax], [Email], [GhiChu]) VALUES (1, N'Công Ty cổ phần Á Châu', N'Hai Duong', '264265', '3463456', 'DPMienNam@gmail.com', N'ff')
INSERT INTO [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [DiaChi], [DienThoai], [Fax], [Email], [GhiChu]) VALUES (2, N'Công ty TNHH dược phẩm Việt Anh', N'Bắc Ninh', '45673473', '07007070', 'VietAnh@gmail.com', N'ytyrt')
INSERT INTO [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [DiaChi], [DienThoai], [Fax], [Email], [GhiChu]) VALUES (3, N'Công Ty cổ phần Á Châu', N'Thanh Hóa', '', '0987654321', 'Achau@yahoo.com', N'')
SET IDENTITY_INSERT [dbo].[NhaSanXuat] OFF

-- Add 10 rows to [dbo].[NhomThuoc]
SET IDENTITY_INSERT [dbo].[NhomThuoc] ON
INSERT INTO [dbo].[NhomThuoc] ([MaNhom], [TenNhom], [GhiChu]) VALUES (1, N'Thuốc gây mê, tê', N'                                                                                                    ')
INSERT INTO [dbo].[NhomThuoc] ([MaNhom], [TenNhom], [GhiChu]) VALUES (2, N'Giảm đau, hạ sốt chống viêm', N'                                                                                                    ')
INSERT INTO [dbo].[NhomThuoc] ([MaNhom], [TenNhom], [GhiChu]) VALUES (3, N'Thuốc chống dị ứng', N'                                                                                                    ')
INSERT INTO [dbo].[NhomThuoc] ([MaNhom], [TenNhom], [GhiChu]) VALUES (6, N'Thuốc cấp cứu và giải độc', N'                                                                                                    ')
INSERT INTO [dbo].[NhomThuoc] ([MaNhom], [TenNhom], [GhiChu]) VALUES (18, N'Hướng tâm thần', N'hướng tâm thần                                                                                      ')
INSERT INTO [dbo].[NhomThuoc] ([MaNhom], [TenNhom], [GhiChu]) VALUES (19, N'Chống nhiễm khuẩn, Khử trùng', N'                                                                                                    ')
INSERT INTO [dbo].[NhomThuoc] ([MaNhom], [TenNhom], [GhiChu]) VALUES (20, N'Điều trị đau nửa đầu', N'Điều trị                                                                                            ')
INSERT INTO [dbo].[NhomThuoc] ([MaNhom], [TenNhom], [GhiChu]) VALUES (21, N'Thuốc chống ung thư', N'                                                                                                    ')
INSERT INTO [dbo].[NhomThuoc] ([MaNhom], [TenNhom], [GhiChu]) VALUES (22, N'Tác dụng đối với máu', N'                                                                                                    ')
INSERT INTO [dbo].[NhomThuoc] ([MaNhom], [TenNhom], [GhiChu]) VALUES (28, N'Tránh thai', N'tránh thai                                                                                          ')
SET IDENTITY_INSERT [dbo].[NhomThuoc] OFF

-- Add 4 rows to [dbo].[Users]
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([IDUser], [Username], [Password], [HoTen], [DiaChi]) VALUES (1, 'haitx', '123', N'Trần Xuân Hải', N'Hải Dương')
INSERT INTO [dbo].[Users] ([IDUser], [Username], [Password], [HoTen], [DiaChi]) VALUES (2, 'thanhtd', '123', N'Trịnh Đình Thành', N'Ninh Bình')
INSERT INTO [dbo].[Users] ([IDUser], [Username], [Password], [HoTen], [DiaChi]) VALUES (4, 'hungnc', '123', N'Nguyễn Công Hưng', N'Thanh Hóa')
INSERT INTO [dbo].[Users] ([IDUser], [Username], [Password], [HoTen], [DiaChi]) VALUES (5, 'thienld', '123', N'Lã Đức Thiện', N'Hà Nội')
SET IDENTITY_INSERT [dbo].[Users] OFF

-- Add 1 row to [dbo].[HoaDonNhap]
SET IDENTITY_INSERT [dbo].[HoaDonNhap] ON
INSERT INTO [dbo].[HoaDonNhap] ([MaHDN], [MaNPP], [NguoiGiao], [NguoiNhan], [TongTienThuoc], [TongThue], [TongTienHD], [NgayViet], [NgayNhap]) VALUES (8, 3, N'Hùng', N'', 345.0000, 0.8, 347.7600, '2009-12-04 00:00:00.000', '2009-12-04 00:00:00.000')
SET IDENTITY_INSERT [dbo].[HoaDonNhap] OFF

-- Add 8 rows to [dbo].[HoaDonXuat]
SET IDENTITY_INSERT [dbo].[HoaDonXuat] ON
INSERT INTO [dbo].[HoaDonXuat] ([MaHDX], [IDBN], [NgayLap], [TongTienThuoc], [TongThue], [TongTienHD]) VALUES (21, 43, '2009-12-02 16:57:51.000', 12000.0000, 60, 12060.0000)
INSERT INTO [dbo].[HoaDonXuat] ([MaHDX], [IDBN], [NgayLap], [TongTienThuoc], [TongThue], [TongTienHD]) VALUES (24, 43, '2009-12-02 17:04:54.000', 18000.0000, 90, 18090.0000)
INSERT INTO [dbo].[HoaDonXuat] ([MaHDX], [IDBN], [NgayLap], [TongTienThuoc], [TongThue], [TongTienHD]) VALUES (33, 33, '2009-12-02 18:34:49.000', 3000.0000, 15, 3015.0000)
INSERT INTO [dbo].[HoaDonXuat] ([MaHDX], [IDBN], [NgayLap], [TongTienThuoc], [TongThue], [TongTienHD]) VALUES (35, 43, '2009-12-02 18:36:49.000', 6000.0000, 30, 6030.0000)
INSERT INTO [dbo].[HoaDonXuat] ([MaHDX], [IDBN], [NgayLap], [TongTienThuoc], [TongThue], [TongTienHD]) VALUES (36, 43, '2009-12-02 18:44:58.000', 18000.0000, 90, 18090.0000)
INSERT INTO [dbo].[HoaDonXuat] ([MaHDX], [IDBN], [NgayLap], [TongTienThuoc], [TongThue], [TongTienHD]) VALUES (37, 12, '2009-12-02 18:49:00.000', 6000.0000, 30, 6030.0000)
INSERT INTO [dbo].[HoaDonXuat] ([MaHDX], [IDBN], [NgayLap], [TongTienThuoc], [TongThue], [TongTienHD]) VALUES (42, 43, '2009-12-02 21:17:07.000', 12000.0000, 60, 12060.0000)
INSERT INTO [dbo].[HoaDonXuat] ([MaHDX], [IDBN], [NgayLap], [TongTienThuoc], [TongThue], [TongTienHD]) VALUES (44, 12, '2009-12-04 22:23:38.000', 9000.0000, 45, 9045.0000)
SET IDENTITY_INSERT [dbo].[HoaDonXuat] OFF

-- Add 454 rows to [dbo].[SystemLog]
SET IDENTITY_INSERT [dbo].[SystemLog] ON
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (6, 1, '2009-12-02 10:02:24.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (7, 1, '2009-12-02 10:04:06.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (8, 1, '2009-12-02 10:05:57.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (9, 1, '2009-12-02 10:07:44.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (10, 1, '2009-12-02 10:07:51.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (11, 1, '2009-12-02 10:08:02.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (12, 1, '2009-12-02 10:09:43.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (13, 1, '2009-12-02 10:11:25.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (14, 1, '2009-12-02 10:19:21.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (15, 1, '2009-12-02 10:20:14.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (16, 1, '2009-12-02 10:21:27.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (17, 1, '2009-12-02 10:21:58.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (18, 1, '2009-12-02 10:22:50.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (19, 1, '2009-12-02 10:24:04.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (20, 1, '2009-12-02 10:25:07.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (21, 1, '2009-12-02 10:26:13.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (22, 1, '2009-12-02 10:32:27.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (23, 1, '2009-12-02 10:33:09.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (24, 1, '2009-12-02 10:35:54.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (25, 1, '2009-12-02 11:48:16.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (26, 1, '2009-12-02 12:31:29.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (27, 1, '2009-12-02 12:31:35.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (28, 1, '2009-12-02 12:32:08.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (29, 1, '2009-12-02 12:32:22.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (30, 1, '2009-12-02 12:35:17.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (31, 1, '2009-12-02 12:35:41.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (32, 1, '2009-12-02 13:21:37.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (33, 1, '2009-12-02 13:22:19.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (34, 1, '2009-12-02 13:32:07.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (35, 1, '2009-12-02 13:32:22.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (36, 1, '2009-12-02 13:32:30.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (37, 1, '2009-12-02 13:33:28.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (38, 1, '2009-12-02 13:34:42.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (39, 1, '2009-12-02 13:38:30.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (40, 1, '2009-12-02 13:39:11.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (41, 1, '2009-12-02 13:39:44.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (42, 1, '2009-12-02 13:40:19.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (43, 1, '2009-12-02 13:43:35.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (44, 1, '2009-12-02 13:48:23.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (45, 1, '2009-12-02 13:48:27.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (46, 1, '2009-12-02 13:48:32.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (47, 1, '2009-12-02 13:52:50.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (48, 1, '2009-12-02 13:53:50.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (49, 1, '2009-12-02 13:58:37.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (50, 1, '2009-12-02 14:00:46.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (51, 1, '2009-12-02 14:01:33.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (52, 1, '2009-12-02 14:03:02.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (53, 1, '2009-12-02 14:05:22.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (54, 1, '2009-12-02 14:10:53.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (55, 1, '2009-12-02 14:11:34.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (56, 1, '2009-12-02 14:11:40.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (57, 1, '2009-12-02 14:14:26.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (58, 1, '2009-12-02 14:23:49.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (59, 1, '2009-12-02 14:23:59.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (60, 1, '2009-12-02 14:24:08.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (61, 1, '2009-12-02 14:31:05.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (62, 1, '2009-12-02 14:31:13.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (63, 1, '2009-12-02 14:31:18.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (64, 1, '2009-12-02 14:38:34.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (65, 1, '2009-12-02 14:44:14.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (66, 1, '2009-12-02 14:45:11.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (67, 1, '2009-12-02 14:46:02.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (68, 1, '2009-12-02 14:46:52.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (69, 1, '2009-12-02 14:46:57.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (70, 1, '2009-12-02 14:54:01.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (71, 1, '2009-12-02 14:55:38.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (72, 1, '2009-12-02 15:00:02.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (73, 1, '2009-12-02 15:00:28.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (74, 1, '2009-12-02 15:00:33.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (75, 1, '2009-12-02 15:01:20.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (76, 1, '2009-12-02 15:02:07.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (77, 1, '2009-12-02 15:02:38.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (78, 1, '2009-12-02 15:02:53.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (79, 1, '2009-12-02 15:05:07.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (80, 1, '2009-12-02 15:06:39.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (81, 1, '2009-12-02 15:30:47.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (82, 1, '2009-12-02 15:32:47.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (83, 1, '2009-12-02 15:33:49.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (84, 1, '2009-12-02 15:34:13.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (85, 1, '2009-12-02 15:35:30.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (86, 1, '2009-12-02 15:36:07.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (87, 1, '2009-12-02 15:36:08.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (88, 1, '2009-12-02 15:36:19.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (89, 1, '2009-12-02 15:36:28.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (90, 1, '2009-12-02 15:38:55.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (91, 1, '2009-12-02 15:39:32.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (92, 1, '2009-12-02 15:40:07.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (93, 1, '2009-12-02 15:41:29.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (94, 1, '2009-12-02 15:44:41.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (95, 1, '2009-12-02 15:44:45.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (96, 1, '2009-12-02 15:44:52.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (97, 1, '2009-12-02 15:45:03.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (98, 1, '2009-12-02 15:45:28.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (99, 1, '2009-12-02 15:45:33.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (100, 1, '2009-12-02 15:45:55.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (101, 1, '2009-12-02 15:46:37.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (102, 1, '2009-12-02 15:46:44.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (103, 1, '2009-12-02 15:51:02.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (104, 1, '2009-12-02 15:52:25.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (105, 1, '2009-12-02 15:54:32.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (106, 1, '2009-12-02 15:56:29.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (107, 1, '2009-12-02 15:56:56.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (108, 1, '2009-12-02 15:58:34.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (109, 1, '2009-12-02 16:00:50.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (110, 1, '2009-12-02 16:03:11.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (111, 1, '2009-12-02 16:04:12.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (112, 1, '2009-12-02 16:04:49.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (113, 1, '2009-12-02 16:05:47.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (114, 1, '2009-12-02 16:10:25.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (115, 1, '2009-12-02 16:11:30.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (116, 1, '2009-12-02 16:12:22.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (117, 1, '2009-12-02 16:13:37.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (118, 1, '2009-12-02 16:17:03.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (119, 1, '2009-12-02 16:17:07.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (120, 1, '2009-12-02 16:18:25.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (121, 1, '2009-12-02 16:19:51.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (122, 1, '2009-12-02 16:24:01.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (123, 1, '2009-12-02 16:25:42.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (124, 1, '2009-12-02 16:27:02.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (125, 1, '2009-12-02 16:30:26.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (126, 1, '2009-12-02 16:31:18.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (127, 1, '2009-12-02 16:31:58.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (128, 1, '2009-12-02 16:32:07.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (129, 1, '2009-12-02 16:36:03.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (130, 1, '2009-12-02 16:42:18.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (131, 1, '2009-12-02 16:43:05.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (132, 1, '2009-12-02 16:46:26.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (133, 1, '2009-12-02 16:46:39.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (134, 1, '2009-12-02 16:47:10.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (135, 1, '2009-12-02 16:47:47.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (136, 1, '2009-12-02 16:48:51.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (137, 1, '2009-12-02 16:49:12.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (138, 1, '2009-12-02 16:54:35.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (139, 1, '2009-12-02 16:55:15.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (140, 1, '2009-12-02 16:55:29.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (141, 1, '2009-12-02 16:56:49.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (142, 1, '2009-12-02 16:57:06.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (143, 1, '2009-12-02 16:58:19.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (144, 1, '2009-12-02 17:01:27.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (145, 1, '2009-12-02 17:01:48.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (146, 1, '2009-12-02 17:01:53.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (147, 1, '2009-12-02 17:04:36.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (148, 1, '2009-12-02 17:07:24.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (149, 1, '2009-12-02 17:08:27.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (150, 1, '2009-12-02 17:10:29.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (151, 1, '2009-12-02 17:11:27.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (152, 1, '2009-12-02 17:13:32.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (153, 1, '2009-12-02 17:30:12.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (154, 1, '2009-12-02 17:30:25.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (155, 1, '2009-12-02 17:30:34.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (156, 1, '2009-12-02 17:33:23.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (157, 1, '2009-12-02 17:33:25.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (158, 1, '2009-12-02 17:33:33.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (159, 1, '2009-12-02 17:34:52.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (160, 1, '2009-12-02 17:35:02.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (161, 1, '2009-12-02 17:35:52.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (162, 1, '2009-12-02 17:37:13.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (163, 1, '2009-12-02 17:37:32.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (164, 1, '2009-12-02 17:38:22.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (165, 1, '2009-12-02 17:38:34.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (166, 1, '2009-12-02 17:40:16.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (167, 1, '2009-12-02 18:19:07.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (168, 1, '2009-12-02 18:19:26.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (169, 1, '2009-12-02 18:20:51.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (170, 1, '2009-12-02 18:21:01.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (171, 1, '2009-12-02 18:22:51.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (172, 1, '2009-12-02 18:23:08.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (173, 1, '2009-12-02 18:24:55.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (174, 1, '2009-12-02 18:31:53.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (175, 1, '2009-12-02 18:34:37.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (176, 1, '2009-12-02 18:37:14.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (177, 1, '2009-12-02 18:39:40.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (178, 1, '2009-12-02 18:40:01.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (179, 1, '2009-12-02 18:42:28.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (180, 1, '2009-12-02 18:42:49.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (181, 1, '2009-12-02 18:43:32.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (182, 1, '2009-12-02 18:43:53.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (183, 1, '2009-12-02 18:44:36.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (184, 1, '2009-12-02 18:45:51.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (185, 1, '2009-12-02 18:48:33.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (186, 1, '2009-12-02 18:49:50.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (187, 1, '2009-12-02 18:51:04.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (188, 1, '2009-12-02 18:57:23.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (189, 1, '2009-12-02 18:58:00.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (190, 1, '2009-12-02 19:23:12.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (191, 1, '2009-12-02 19:45:54.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (192, 1, '2009-12-02 19:46:00.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (193, 1, '2009-12-02 19:46:45.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (194, 1, '2009-12-02 20:16:12.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (195, 1, '2009-12-02 20:16:38.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (196, 1, '2009-12-02 20:17:03.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (197, 1, '2009-12-02 20:17:22.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (198, 1, '2009-12-02 20:25:02.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (199, 1, '2009-12-02 20:25:28.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (200, 1, '2009-12-02 20:29:07.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (201, 1, '2009-12-02 20:29:36.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (202, 1, '2009-12-02 20:33:02.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (203, 1, '2009-12-02 20:33:16.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (204, 1, '2009-12-02 21:16:46.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (205, 1, '2009-12-02 21:17:37.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (206, 1, '2009-12-02 21:25:24.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (207, 1, '2009-12-02 21:26:10.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (208, 1, '2009-12-03 08:39:09.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (209, 1, '2009-12-03 08:40:44.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (210, 1, '2009-12-03 08:41:16.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (211, 1, '2009-12-03 08:44:40.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (212, 1, '2009-12-03 08:46:00.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (213, 1, '2009-12-03 08:46:06.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (214, 1, '2009-12-03 08:46:19.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (215, 1, '2009-12-03 08:51:34.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (216, 1, '2009-12-03 08:53:08.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (217, 1, '2009-12-03 08:55:19.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (218, 1, '2009-12-03 08:58:12.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (219, 1, '2009-12-03 08:59:35.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (220, 1, '2009-12-03 08:59:43.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (221, 1, '2009-12-03 08:59:44.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (222, 1, '2009-12-03 09:00:14.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (223, 1, '2009-12-03 09:00:38.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (224, 1, '2009-12-03 09:00:45.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (225, 1, '2009-12-03 09:29:19.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (226, 1, '2009-12-03 09:34:15.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (227, 1, '2009-12-03 10:22:46.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (228, 1, '2009-12-03 10:26:55.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (229, 1, '2009-12-03 10:28:30.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (230, 1, '2009-12-03 15:19:59.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (231, 1, '2009-12-03 15:20:51.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (232, 1, '2009-12-03 15:22:50.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (233, 1, '2009-12-03 15:23:48.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (234, 1, '2009-12-03 15:29:12.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (235, 1, '2009-12-03 15:32:24.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (236, 1, '2009-12-03 15:33:46.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (237, 1, '2009-12-03 15:34:17.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (238, 1, '2009-12-03 15:35:04.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (239, 1, '2009-12-03 15:36:25.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (240, 1, '2009-12-03 15:36:54.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (241, 1, '2009-12-03 15:38:01.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (242, 1, '2009-12-03 15:40:25.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (243, 1, '2009-12-03 15:41:40.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (244, 1, '2009-12-03 16:12:45.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (245, 1, '2009-12-03 16:15:44.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (246, 1, '2009-12-03 16:19:48.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (247, 1, '2009-12-03 16:21:54.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (248, 1, '2009-12-03 16:23:02.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (249, 1, '2009-12-03 16:24:19.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (250, 1, '2009-12-03 16:25:46.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (251, 1, '2009-12-03 16:26:59.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (252, 1, '2009-12-03 16:28:57.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (253, 1, '2009-12-03 16:30:03.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (254, 1, '2009-12-03 23:32:07.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (255, 1, '2009-12-03 23:32:15.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (256, 1, '2009-12-03 23:32:40.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (257, 1, '2009-12-03 23:33:50.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (258, 1, '2009-12-03 23:35:51.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (259, 1, '2009-12-03 23:48:48.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (260, 1, '2009-12-03 23:52:08.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (261, 1, '2009-12-03 23:53:24.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (262, 1, '2009-12-03 23:57:33.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (263, 1, '2009-12-04 00:02:47.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (264, 1, '2009-12-04 00:08:22.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (265, 1, '2009-12-04 00:18:01.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (266, 1, '2009-12-04 00:29:46.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (267, 1, '2009-12-04 00:39:48.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (268, 1, '2009-12-04 00:47:23.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (269, 1, '2009-12-04 00:51:10.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (270, 1, '2009-12-04 00:51:55.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (271, 1, '2009-12-04 00:57:15.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (272, 1, '2009-12-04 01:03:28.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (273, 1, '2009-12-04 01:04:29.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (274, 1, '2009-12-04 01:20:47.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (275, 1, '2009-12-04 01:25:50.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (276, 1, '2009-12-04 01:28:38.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (277, 1, '2009-12-04 01:45:09.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (278, 1, '2009-12-04 01:45:50.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (279, 1, '2009-12-04 01:46:34.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (280, 1, '2009-12-04 01:47:45.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (281, 1, '2009-12-04 01:48:54.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (282, 1, '2009-12-04 01:49:24.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (283, 1, '2009-12-04 01:53:44.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (284, 1, '2009-12-04 01:58:33.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (285, 1, '2009-12-04 02:04:54.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (286, 1, '2009-12-04 02:07:02.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (287, 1, '2009-12-04 02:09:15.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (288, 1, '2009-12-04 02:28:04.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (289, 1, '2009-12-04 13:04:23.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (290, 1, '2009-12-04 13:04:53.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (291, 1, '2009-12-04 13:27:00.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (292, 1, '2009-12-04 13:28:19.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (293, 1, '2009-12-04 13:28:21.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (294, 1, '2009-12-04 13:28:23.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (295, 1, '2009-12-04 13:30:17.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (296, 1, '2009-12-04 13:31:46.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (297, 1, '2009-12-04 13:32:50.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (298, 1, '2009-12-04 13:34:47.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (299, 1, '2009-12-04 13:36:36.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (300, 1, '2009-12-04 13:39:57.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (301, 1, '2009-12-04 13:45:28.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (302, 1, '2009-12-04 13:46:18.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (303, 1, '2009-12-04 13:58:30.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (304, 1, '2009-12-04 14:22:06.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (305, 1, '2009-12-04 14:22:55.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (306, 1, '2009-12-04 14:24:20.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (307, 1, '2009-12-04 14:28:41.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (308, 1, '2009-12-04 14:29:42.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (309, 1, '2009-12-04 14:31:54.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (310, 1, '2009-12-04 14:33:48.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (311, 1, '2009-12-04 14:37:32.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (312, 1, '2009-12-04 14:43:28.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (313, 1, '2009-12-04 14:53:34.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (314, 1, '2009-12-04 14:55:22.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (315, 1, '2009-12-04 14:57:05.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (316, 1, '2009-12-04 14:58:28.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (317, 1, '2009-12-04 15:04:03.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (318, 1, '2009-12-04 15:05:23.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (319, 1, '2009-12-04 15:06:21.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (320, 1, '2009-12-04 15:08:50.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (321, 1, '2009-12-04 15:33:37.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (322, 1, '2009-12-04 15:34:30.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (323, 1, '2009-12-04 15:36:57.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (324, 1, '2009-12-04 15:38:24.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (325, 1, '2009-12-04 15:41:51.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (326, 1, '2009-12-04 15:42:44.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (327, 1, '2009-12-04 15:47:01.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (328, 1, '2009-12-04 15:49:10.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (329, 1, '2009-12-04 15:50:13.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (330, 1, '2009-12-04 15:52:36.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (331, 1, '2009-12-04 15:56:23.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (332, 1, '2009-12-04 15:56:38.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (333, 1, '2009-12-04 15:57:49.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (334, 1, '2009-12-04 15:58:17.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (335, 1, '2009-12-04 15:58:18.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (336, 1, '2009-12-04 15:58:57.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (337, 1, '2009-12-04 16:07:43.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (338, 1, '2009-12-04 16:09:33.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (339, 1, '2009-12-04 16:14:03.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (340, 1, '2009-12-04 16:15:37.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (341, 1, '2009-12-04 16:15:52.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (342, 1, '2009-12-04 16:18:37.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (343, 1, '2009-12-04 16:22:10.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (344, 1, '2009-12-04 16:24:11.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (345, 1, '2009-12-04 16:26:32.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (346, 1, '2009-12-04 16:36:10.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (347, 1, '2009-12-04 16:37:38.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (348, 1, '2009-12-04 16:41:43.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (349, 1, '2009-12-04 16:44:06.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (350, 1, '2009-12-04 16:48:03.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (351, 1, '2009-12-04 16:51:43.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (352, 1, '2009-12-04 16:52:59.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (353, 1, '2009-12-04 16:58:32.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (354, 1, '2009-12-04 16:58:51.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (355, 1, '2009-12-04 16:59:57.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (356, 1, '2009-12-04 17:00:03.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (357, 1, '2009-12-04 17:00:05.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (358, 1, '2009-12-04 17:02:35.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (359, 1, '2009-12-04 17:10:18.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (360, 1, '2009-12-04 17:12:04.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (361, 1, '2009-12-04 17:17:12.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (362, 1, '2009-12-04 17:18:30.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (363, 1, '2009-12-04 17:27:26.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (364, 1, '2009-12-04 17:33:58.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (365, 1, '2009-12-04 17:36:13.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (366, 1, '2009-12-04 17:36:29.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (367, 1, '2009-12-04 17:43:48.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (368, 1, '2009-12-04 17:46:11.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (369, 1, '2009-12-04 17:48:15.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (370, 1, '2009-12-04 17:50:07.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (371, 1, '2009-12-04 18:00:09.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (372, 1, '2009-12-04 18:07:10.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (373, 1, '2009-12-04 18:11:05.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (374, 1, '2009-12-04 18:11:06.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (375, 1, '2009-12-04 18:11:07.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (376, 1, '2009-12-04 18:55:04.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (377, 1, '2009-12-04 18:57:14.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (378, 1, '2009-12-04 18:57:26.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (379, 1, '2009-12-04 18:57:54.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (380, 1, '2009-12-04 18:57:56.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (381, 1, '2009-12-04 19:09:31.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (382, 4, '2009-12-04 19:16:04.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (383, 4, '2009-12-04 19:16:06.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (384, 4, '2009-12-04 19:16:10.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (385, 4, '2009-12-04 19:19:54.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (386, 4, '2009-12-04 19:20:00.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (387, 4, '2009-12-04 19:20:04.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (388, 4, '2009-12-04 19:22:47.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (389, 4, '2009-12-04 19:24:49.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (390, 4, '2009-12-04 19:28:50.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (391, 1, '2009-12-04 20:46:21.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (392, 1, '2009-12-04 20:46:43.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (393, 1, '2009-12-04 20:47:30.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (394, 1, '2009-12-04 20:52:04.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (395, 1, '2009-12-04 20:52:09.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (396, 1, '2009-12-04 20:52:14.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (397, 1, '2009-12-04 20:52:56.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (398, 1, '2009-12-04 20:54:37.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (399, 1, '2009-12-04 20:55:10.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (400, 1, '2009-12-04 20:55:42.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (401, 1, '2009-12-04 20:56:13.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (402, 1, '2009-12-04 21:02:47.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (403, 1, '2009-12-04 21:02:58.000', N'Xóa hóa đơn xuất')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (404, 1, '2009-12-04 21:03:06.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (405, 1, '2009-12-04 21:03:12.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (406, 1, '2009-12-04 21:41:19.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (407, 1, '2009-12-04 21:50:05.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (408, 1, '2009-12-04 21:50:11.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (409, 1, '2009-12-04 21:50:22.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (410, 1, '2009-12-04 21:50:42.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (411, 1, '2009-12-04 22:03:11.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (412, 1, '2009-12-04 22:03:23.000', N'Xóa đơn thuốc')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (413, 1, '2009-12-04 22:03:26.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (414, 1, '2009-12-04 22:03:31.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (415, 1, '2009-12-04 22:03:49.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (416, 1, '2009-12-04 22:23:27.000', N'Đăng nhập vào kê đơn')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (417, 1, '2009-12-04 22:23:39.000', N'Tạo đơn thuốc')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (418, 1, '2009-12-04 22:23:50.000', N'Xóa đơn thuốc')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (419, 1, '2009-12-04 22:24:07.000', N'Thêm bệnh nhân')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (420, 1, '2009-12-04 22:24:16.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (421, 4, '2009-12-04 22:24:26.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (422, 4, '2009-12-04 22:24:50.000', N'Sửa nhóm thuốc ')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (423, 4, '2009-12-04 22:24:56.000', N'Sửa nhóm thuốc ')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (424, 4, '2009-12-04 22:24:59.000', N'Xóa nhóm thuốc ')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (425, 4, '2009-12-04 22:25:05.000', N'Sửa đơn vị tính')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (426, 4, '2009-12-04 22:25:13.000', N'Sửa đơn vị tính')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (427, 4, '2009-12-04 22:25:16.000', N'Thêm đơn vị tính')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (428, 4, '2009-12-04 22:25:21.000', N'Sửa đơn vị tính')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (429, 4, '2009-12-04 22:25:23.000', N'Xóa đơn vị tính')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (430, 4, '2009-12-04 22:25:28.000', N'Xóa đơn vị tính')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (431, 4, '2009-12-04 22:26:04.000', N'Thêm thuốc')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (432, 4, '2009-12-04 22:26:15.000', N'Xóa thuốc ')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (433, 4, '2009-12-04 22:26:29.000', N'Xóa thuốc ')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (434, 4, '2009-12-04 22:26:48.000', N'Thêm nhà sản xuất')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (435, 4, '2009-12-04 22:26:51.000', N'Sửa nhà sản xuất')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (436, 4, '2009-12-04 22:26:54.000', N'Sửa nhà sản xuất')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (437, 4, '2009-12-04 22:26:57.000', N'Xóa nhà sản xuất')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (438, 4, '2009-12-04 22:27:02.000', N'Thêm nhà phân phối')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (439, 4, '2009-12-04 22:27:04.000', N'Sửa nhà phân phối')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (440, 4, '2009-12-04 22:27:07.000', N'Sửa nhà phân phối')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (441, 4, '2009-12-04 22:27:09.000', N'Thêm nhà phân phối')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (442, 4, '2009-12-04 22:27:12.000', N'Xóa nhà phân phôi')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (443, 4, '2009-12-04 22:27:15.000', N'Xóa nhà phân phôi')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (444, 4, '2009-12-04 22:27:19.000', N'Thêm nhà sản xuất')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (445, 4, '2009-12-04 22:27:22.000', N'Sửa nhà sản xuất')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (446, 4, '2009-12-04 22:27:24.000', N'Sửa nhà sản xuất')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (447, 4, '2009-12-04 22:27:27.000', N'Sửa nhà sản xuất')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (448, 4, '2009-12-04 22:27:29.000', N'Sửa nhà sản xuất')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (449, 4, '2009-12-04 22:27:32.000', N'Xóa nhà sản xuất')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (450, 4, '2009-12-04 22:27:36.000', N'Xóa nhà sản xuất')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (451, 4, '2009-12-04 22:27:46.000', N'Xóa đơn thuốc')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (452, 4, '2009-12-04 22:28:50.000', N'Thêm hóa đơn nhập')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (453, 4, '2009-12-04 22:28:55.000', N'Xóa hóa đơn nhập')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (454, 4, '2009-12-04 22:28:59.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (455, 4, '2009-12-04 22:29:12.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (456, 4, '2009-12-04 22:29:38.000', N'Logout')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (457, 1, '2009-12-04 22:36:19.000', N'Đăng nhập vào quản lý')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (458, 1, '2009-12-04 22:36:57.000', N'Thêm hóa đơn nhập')
INSERT INTO [dbo].[SystemLog] ([ID], [IDUser], [DateLogin], [Description]) VALUES (459, 1, '2009-12-04 22:37:57.000', N'Logout')
SET IDENTITY_INSERT [dbo].[SystemLog] OFF

-- Add 1 row to [dbo].[ChiTietHoaDonNhap]
SET IDENTITY_INSERT [dbo].[ChiTietHoaDonNhap] ON
INSERT INTO [dbo].[ChiTietHoaDonNhap] ([MaCTHDN], [MaHDN], [IDThuoc], [SoLuong], [GiaNhap]) VALUES (12, 8, 38, 1, 345.0000)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDonNhap] OFF

-- Add 10 rows to [dbo].[ChiTietHoaDonXuat]
SET IDENTITY_INSERT [dbo].[ChiTietHoaDonXuat] ON
INSERT INTO [dbo].[ChiTietHoaDonXuat] ([MaCTHDX], [MaHDX], [IDThuoc], [SoLuong], [GiaBan], [Thue], [DonVi]) VALUES (22, 21, 40, 4, 3000.0000, 0.5, N'Viên')
INSERT INTO [dbo].[ChiTietHoaDonXuat] ([MaCTHDX], [MaHDX], [IDThuoc], [SoLuong], [GiaBan], [Thue], [DonVi]) VALUES (25, 24, 38, 6, 3000.0000, 0.5, N'Viên')
INSERT INTO [dbo].[ChiTietHoaDonXuat] ([MaCTHDX], [MaHDX], [IDThuoc], [SoLuong], [GiaBan], [Thue], [DonVi]) VALUES (35, 33, 38, 1, 3000.0000, 0.5, N'Viên')
INSERT INTO [dbo].[ChiTietHoaDonXuat] ([MaCTHDX], [MaHDX], [IDThuoc], [SoLuong], [GiaBan], [Thue], [DonVi]) VALUES (37, 35, 36, 2, 3000.0000, 0.5, N'Viên')
INSERT INTO [dbo].[ChiTietHoaDonXuat] ([MaCTHDX], [MaHDX], [IDThuoc], [SoLuong], [GiaBan], [Thue], [DonVi]) VALUES (38, 36, 36, 2, 3000.0000, 0.5, N'Viên')
INSERT INTO [dbo].[ChiTietHoaDonXuat] ([MaCTHDX], [MaHDX], [IDThuoc], [SoLuong], [GiaBan], [Thue], [DonVi]) VALUES (39, 36, 38, 4, 3000.0000, 0.5, N'Viên')
INSERT INTO [dbo].[ChiTietHoaDonXuat] ([MaCTHDX], [MaHDX], [IDThuoc], [SoLuong], [GiaBan], [Thue], [DonVi]) VALUES (40, 37, 38, 2, 3000.0000, 0.5, N'Viên')
INSERT INTO [dbo].[ChiTietHoaDonXuat] ([MaCTHDX], [MaHDX], [IDThuoc], [SoLuong], [GiaBan], [Thue], [DonVi]) VALUES (45, 42, 38, 2, 3000.0000, 0.5, N'Viên')
INSERT INTO [dbo].[ChiTietHoaDonXuat] ([MaCTHDX], [MaHDX], [IDThuoc], [SoLuong], [GiaBan], [Thue], [DonVi]) VALUES (46, 42, 36, 2, 3000.0000, 0.5, N'Viên')
INSERT INTO [dbo].[ChiTietHoaDonXuat] ([MaCTHDX], [MaHDX], [IDThuoc], [SoLuong], [GiaBan], [Thue], [DonVi]) VALUES (48, 44, 39, 3, 3000.0000, 0.5, N'Viên')
SET IDENTITY_INSERT [dbo].[ChiTietHoaDonXuat] OFF

-- Add 10 rows to [dbo].[Thuoc]
SET IDENTITY_INSERT [dbo].[Thuoc] ON
INSERT INTO [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [MaNhom], [NguonGoc], [MaNSX], [SoLuong], [Thue], [GiaBan], [MaDVT], [DangDongGoi], [SoLuongDongGoi], [SoDangKy], [DangBaoChe], [ThanhPhan], [HamLuong], [CongDung], [PhanTacDung], [CachDung], [ChuY], [HanSuDung], [BaoQuan]) VALUES (36, N'MT_0001_Lidocain', N'Lidocain', 1, N'Việt Nam', 1, 95, 0.5, 3000.0000, 1, 2, 100, N'1234', N'Xăng pha nhớt', N'Thanh Phan', N'Ham Luong', N'Cong Dung', N'Phan Tac Dung', N'Cach Dung', N'Chu Y', N'11/09/2012', N'Kho')
INSERT INTO [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [MaNhom], [NguonGoc], [MaNSX], [SoLuong], [Thue], [GiaBan], [MaDVT], [DangDongGoi], [SoLuongDongGoi], [SoDangKy], [DangBaoChe], [ThanhPhan], [HamLuong], [CongDung], [PhanTacDung], [CachDung], [ChuY], [HanSuDung], [BaoQuan]) VALUES (37, N'MT_0002_Aerrane', N'Aerrane', 1, N'Viet Nam', 2, 93, 0.5, 3000.0000, 1, 1, 100, N'1234', N'Dang Bao Che', N'Thanh Phan', N'Ham Luong', N'Cong Dung', N'Phan Tac Dung', N'Cach Dung', N'Chu Y', N'11/09/2012', N'Kho')
INSERT INTO [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [MaNhom], [NguonGoc], [MaNSX], [SoLuong], [Thue], [GiaBan], [MaDVT], [DangDongGoi], [SoLuongDongGoi], [SoDangKy], [DangBaoChe], [ThanhPhan], [HamLuong], [CongDung], [PhanTacDung], [CachDung], [ChuY], [HanSuDung], [BaoQuan]) VALUES (38, N'MT_0003_Betaphenin', N'Betaphenin', 3, N'Viet Nam', 1, 153, 0.5, 3000.0000, 2, 3, 100, N'1234', N'Dang Bao Che', N'Thanh Phan', N'Ham Luong', N'Cong Dung', N'Phan Tac Dung', N'Cach Dung', N'Chu Y', N'11/09/2012', N'Kho')
INSERT INTO [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [MaNhom], [NguonGoc], [MaNSX], [SoLuong], [Thue], [GiaBan], [MaDVT], [DangDongGoi], [SoLuongDongGoi], [SoDangKy], [DangBaoChe], [ThanhPhan], [HamLuong], [CongDung], [PhanTacDung], [CachDung], [ChuY], [HanSuDung], [BaoQuan]) VALUES (39, N'MT_0004_Atropin Sulfat', N'Atropin Sulfat', 6, N'Việt Nam', 1, 97, 0.5, 3000.0000, 1, 3, 100, N'1234', N'Dang Bao Che', N'Thanh Phan', N'Ham Luong', N'Cong Dung', N'Phan Tac Dung', N'Cach Dung', N'Chú ý
', N'1 năm kể từ khi sản xuất

', N'Kho')
INSERT INTO [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [MaNhom], [NguonGoc], [MaNSX], [SoLuong], [Thue], [GiaBan], [MaDVT], [DangDongGoi], [SoLuongDongGoi], [SoDangKy], [DangBaoChe], [ThanhPhan], [HamLuong], [CongDung], [PhanTacDung], [CachDung], [ChuY], [HanSuDung], [BaoQuan]) VALUES (40, N'MT_0005_Cetirizin', N'Cetirizin', 3, N'Thái Lan', 1, 104, 0.5, 3000.0000, 1, 1, 100, N'1234', N'Dang Bao Che', N'Thanh Phan', N'Ham Luong', N'Cong Dung', N'Phan Tac Dung', N'Cach Dung', N'Chu Y', N'11/09/2012', N'Kho')
INSERT INTO [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [MaNhom], [NguonGoc], [MaNSX], [SoLuong], [Thue], [GiaBan], [MaDVT], [DangDongGoi], [SoLuongDongGoi], [SoDangKy], [DangBaoChe], [ThanhPhan], [HamLuong], [CongDung], [PhanTacDung], [CachDung], [ChuY], [HanSuDung], [BaoQuan]) VALUES (41, N'MT_0006_Calciumfolinat', N'Calciumfolinat', 6, N'Đài Loan', 1, 50, 0.5, 5000.0000, 1, 3, 900, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT INTO [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [MaNhom], [NguonGoc], [MaNSX], [SoLuong], [Thue], [GiaBan], [MaDVT], [DangDongGoi], [SoLuongDongGoi], [SoDangKy], [DangBaoChe], [ThanhPhan], [HamLuong], [CongDung], [PhanTacDung], [CachDung], [ChuY], [HanSuDung], [BaoQuan]) VALUES (43, N'MT_0008_Acyclovir', N'Acyclovir', 19, N'Trung Quốc', 2, 18, 0.5, 0.0000, 1, 3, 0, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT INTO [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [MaNhom], [NguonGoc], [MaNSX], [SoLuong], [Thue], [GiaBan], [MaDVT], [DangDongGoi], [SoLuongDongGoi], [SoDangKy], [DangBaoChe], [ThanhPhan], [HamLuong], [CongDung], [PhanTacDung], [CachDung], [ChuY], [HanSuDung], [BaoQuan]) VALUES (44, N'MT_0009_Albendazol', N'Albendazol', 19, N'', 1, 50, 0.5, 0.0000, 1, 1, 0, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT INTO [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [MaNhom], [NguonGoc], [MaNSX], [SoLuong], [Thue], [GiaBan], [MaDVT], [DangDongGoi], [SoLuongDongGoi], [SoDangKy], [DangBaoChe], [ThanhPhan], [HamLuong], [CongDung], [PhanTacDung], [CachDung], [ChuY], [HanSuDung], [BaoQuan]) VALUES (72, N'MT_0010_Paclitaxel', N'Paclitaxel', 21, N'', 2, 80, 0.5, 100000.0000, 2, 3, 0, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT INTO [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [MaNhom], [NguonGoc], [MaNSX], [SoLuong], [Thue], [GiaBan], [MaDVT], [DangDongGoi], [SoLuongDongGoi], [SoDangKy], [DangBaoChe], [ThanhPhan], [HamLuong], [CongDung], [PhanTacDung], [CachDung], [ChuY], [HanSuDung], [BaoQuan]) VALUES (73, N'MT_0011_qưerqewr', N'qưerqewr', 3, N'ưerwer', 2, 0, 0, 134514.0000, 1, 3, 1, N'235145', N'vien', N'', N'', N'', N'', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[Thuoc] OFF

-- Add constraints to [dbo].[Thuoc]
ALTER TABLE [dbo].[Thuoc] ADD CONSTRAINT [FK_MaNhom] FOREIGN KEY ([MaNhom]) REFERENCES [dbo].[NhomThuoc] ([MaNhom])
ALTER TABLE [dbo].[Thuoc] ADD CONSTRAINT [FK_MaNSX] FOREIGN KEY ([MaNSX]) REFERENCES [dbo].[NhaSanXuat] ([MaNSX])
ALTER TABLE [dbo].[Thuoc] ADD CONSTRAINT [FK_Thuoc_DonViTinh1] FOREIGN KEY ([DangDongGoi]) REFERENCES [dbo].[DonViTinh] ([MaDVT])

-- Add constraints to [dbo].[ChiTietHoaDonXuat]
ALTER TABLE [dbo].[ChiTietHoaDonXuat] ADD CONSTRAINT [FK_ChiTietHoaDonXuat_Thuoc] FOREIGN KEY ([IDThuoc]) REFERENCES [dbo].[Thuoc] ([IDThuoc])
ALTER TABLE [dbo].[ChiTietHoaDonXuat] ADD CONSTRAINT [FK_MaHDX] FOREIGN KEY ([MaHDX]) REFERENCES [dbo].[HoaDonXuat] ([MaHDX])

-- Add constraints to [dbo].[ChiTietHoaDonNhap]
ALTER TABLE [dbo].[ChiTietHoaDonNhap] ADD CONSTRAINT [FK_ChiTietHoaDonNhap_Thuoc] FOREIGN KEY ([IDThuoc]) REFERENCES [dbo].[Thuoc] ([IDThuoc])
ALTER TABLE [dbo].[ChiTietHoaDonNhap] ADD CONSTRAINT [FK_MaHDN] FOREIGN KEY ([MaHDN]) REFERENCES [dbo].[HoaDonNhap] ([MaHDN])

-- Add constraints to [dbo].[SystemLog]
ALTER TABLE [dbo].[SystemLog] ADD CONSTRAINT [FK_SystemLog_Users] FOREIGN KEY ([IDUser]) REFERENCES [dbo].[Users] ([IDUser])

-- Add constraints to [dbo].[HoaDonXuat]
ALTER TABLE [dbo].[HoaDonXuat] ADD CONSTRAINT [FK_HoaDonXuat_BenhNhan] FOREIGN KEY ([IDBN]) REFERENCES [dbo].[BenhNhan] ([IDBN])

-- Add constraints to [dbo].[HoaDonNhap]
ALTER TABLE [dbo].[HoaDonNhap] WITH NOCHECK ADD CONSTRAINT [FK_MaNPP] FOREIGN KEY ([MaNPP]) REFERENCES [dbo].[NhaPhanPhoi] ([MaNPP])

COMMIT TRANSACTION
GO