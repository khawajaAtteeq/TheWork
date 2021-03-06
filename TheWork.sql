USE [master]
GO
/****** Object:  Database [TheWork]    Script Date: 9/18/2018 9:12:37 PM ******/
CREATE DATABASE [TheWork]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\MMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\MMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TheWork] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TheWork].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TheWork] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TheWork] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TheWork] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TheWork] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TheWork] SET ARITHABORT OFF 
GO
ALTER DATABASE [TheWork] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TheWork] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TheWork] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TheWork] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TheWork] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TheWork] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TheWork] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TheWork] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TheWork] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TheWork] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TheWork] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TheWork] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TheWork] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TheWork] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TheWork] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TheWork] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TheWork] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TheWork] SET RECOVERY FULL 
GO
ALTER DATABASE [TheWork] SET  MULTI_USER 
GO
ALTER DATABASE [TheWork] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TheWork] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TheWork] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TheWork] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TheWork] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TheWork', N'ON'
GO
ALTER DATABASE [TheWork] SET QUERY_STORE = OFF
GO
USE [TheWork]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [TheWork]
GO
/****** Object:  Table [dbo].[AccountsBalanceSheetNote]    Script Date: 9/18/2018 9:12:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountsBalanceSheetNote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BalanceSheetNoteNumber] [int] NOT NULL,
	[BalanceSheetNoteName] [nvarchar](150) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Accounts_BalanceSheetNote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountsDetailAccount]    Script Date: 9/18/2018 9:12:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountsDetailAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DetailAccountCode] [nvarchar](max) NOT NULL,
	[DetailAccountName] [nvarchar](max) NOT NULL,
	[HeadAccountId] [int] NOT NULL,
	[SortOrder] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Accounts_DetailAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountsGroupAccount]    Script Date: 9/18/2018 9:12:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountsGroupAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupAccountCode] [nvarchar](max) NOT NULL,
	[GroupAccountName] [nvarchar](max) NOT NULL,
	[MainAccountId] [int] NOT NULL,
	[SortOrder] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Accounts_GroupAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountsHeadAccount]    Script Date: 9/18/2018 9:12:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountsHeadAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HeadAccountCode] [nvarchar](max) NOT NULL,
	[HeadAccountName] [nvarchar](max) NOT NULL,
	[GroupAccountId] [int] NOT NULL,
	[BalanceSheetNoteId] [int] NULL,
	[ProfitLoseNoteId] [int] NULL,
	[SortOrder] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Accounts_HeadAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountsMainAccount]    Script Date: 9/18/2018 9:12:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountsMainAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MainAccountCode] [nvarchar](max) NOT NULL,
	[MainAccountName] [nvarchar](max) NOT NULL,
	[AccountClass] [nvarchar](max) NOT NULL,
	[SortOrder] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Accounts_MainAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountsProfitLoseNote]    Script Date: 9/18/2018 9:12:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountsProfitLoseNote](
	[Id] [int] NOT NULL,
	[ProfitLoseNoteNumber] [int] NOT NULL,
	[ProfitLoseNoteName] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Accounts_ProfitLoseNote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountsTransactionVoucherDetail]    Script Date: 9/18/2018 9:12:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountsTransactionVoucherDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VoucherId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[DebitAmount] [money] NULL,
	[CreditAmount] [money] NULL,
	[BankName] [nvarchar](max) NULL,
	[BankBranchName] [nvarchar](max) NULL,
	[CheckTitle] [nvarchar](max) NULL,
	[ChequeNumber] [nvarchar](max) NULL,
	[ChcequeDate] [datetime] NULL,
	[IsDebit] [bit] NULL,
	[IsCredit] [bit] NULL,
 CONSTRAINT [PK_Accounts_VoucherDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountsTransactionVoucherHead]    Script Date: 9/18/2018 9:12:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountsTransactionVoucherHead](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VoucherTypeId] [int] NOT NULL,
	[VoucherDate] [datetime] NOT NULL,
	[VoucherNumber] [nvarchar](max) NOT NULL,
	[VoucherMethod] [nvarchar](max) NOT NULL,
	[ReferenceAccountId] [int] NULL,
	[VoucherRemarks] [nvarchar](max) NULL,
	[VoucherStatus] [nvarchar](max) NULL,
	[EntryUserId] [int] NULL,
	[EntryDate] [datetime] NOT NULL,
	[CheckedUserId] [int] NULL,
	[CheckedDate] [datetime] NULL,
	[PostedUserId] [int] NULL,
	[PostedDate] [datetime] NULL,
 CONSTRAINT [PK_Accounts_VoucherHead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountsVoucherType]    Script Date: 9/18/2018 9:12:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountsVoucherType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VoucherTypeCode] [nvarchar](max) NOT NULL,
	[VoucherTypeName] [nvarchar](max) NOT NULL,
	[SortOrder] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Accounts_Define_VoucherType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 9/18/2018 9:12:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyShortName] [nvarchar](max) NULL,
	[CompanyFullName] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Region] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[PostalCode] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[LandLine] [nvarchar](max) NULL,
	[Fax] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryItemCategory]    Script Date: 9/18/2018 9:12:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryItemCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemCategoryCode] [nvarchar](max) NOT NULL,
	[ItemCategoryName] [nvarchar](max) NOT NULL,
	[ItemGroupID] [int] NOT NULL,
	[PurchaseAccountID] [int] NULL,
	[SaleAccountID] [int] NULL,
	[SortOrder] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Inventory_Define_StockKeepUnitCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryItemGroup]    Script Date: 9/18/2018 9:12:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryItemGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemGroupCode] [nvarchar](max) NULL,
	[ItemGroupName] [nvarchar](max) NULL,
	[SortOrder] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Inventory_Define_StockKeepUnitGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryItems]    Script Date: 9/18/2018 9:12:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemCode] [nvarchar](max) NOT NULL,
	[ItemName] [nvarchar](max) NOT NULL,
	[ItemDescription] [nvarchar](max) NULL,
	[PackQuantity] [float] NULL,
	[UnitPurchasePrice] [money] NULL,
	[UnitSalePrice] [money] NULL,
	[IsVat] [bit] NULL,
	[StockMaxLevel] [float] NULL,
	[StoctNormalLevel] [float] NULL,
	[StockMinLevel] [float] NULL,
	[ItemImagePath] [nvarchar](max) NULL,
	[ItemUnitId] [int] NOT NULL,
	[ItemGroupId] [int] NOT NULL,
	[ItemCategoryId] [int] NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Inventory_Define_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryItemUnits]    Script Date: 9/18/2018 9:12:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryItemUnits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemUnitCode] [nvarchar](max) NOT NULL,
	[ItemUnitName] [nvarchar](max) NOT NULL,
	[SortOrder] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Inventory_Define_Units] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryTransactionPurchaseDetail]    Script Date: 9/18/2018 9:12:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryTransactionPurchaseDetail](
	[Id] [int] NOT NULL,
	[PurchaseId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[ItemUnitId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[VatPercentage] [float] NULL,
	[Vat] [money] NULL,
	[DiscountPercentage] [float] NULL,
	[DiscountAmount] [money] NULL,
	[PurchaseAmount] [money] NOT NULL,
	[Comments] [nvarchar](max) NULL,
 CONSTRAINT [PK_Inventory_Transaction_PurchaseDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryTransactionPurchaseHead]    Script Date: 9/18/2018 9:12:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryTransactionPurchaseHead](
	[Id] [int] NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[PurchaseNo] [nvarchar](max) NOT NULL,
	[VendorId] [int] NOT NULL,
	[Remarks] [nvarchar](max) NOT NULL,
	[PurchaseTotalAmount] [money] NULL,
	[PurchaseOrderId] [int] NULL,
	[PurchaseStatus] [nvarchar](max) NULL,
	[EntryUserId] [int] NULL,
	[EntryDate] [datetime] NULL,
	[CheckedUserId] [int] NULL,
	[CheckedDate] [datetime] NULL,
	[PostedUserId] [int] NULL,
	[PostedDate] [datetime] NULL,
 CONSTRAINT [PK_Inventory_Transaction_PurchaseHead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryTransactionSaleDetail]    Script Date: 9/18/2018 9:12:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryTransactionSaleDetail](
	[Id] [int] NOT NULL,
	[SaleId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[ItemUnitId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[VatPercentage] [float] NULL,
	[Vat] [money] NULL,
	[DiscountPercentage] [float] NULL,
	[DiscountAmount] [money] NULL,
	[SaleAmount] [money] NOT NULL,
	[Comments] [nvarchar](max) NULL,
 CONSTRAINT [PK_Inventory_Transaction_SaleDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryTransactionSaleHead]    Script Date: 9/18/2018 9:12:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryTransactionSaleHead](
	[Id] [int] NOT NULL,
	[SaleDate] [datetime] NOT NULL,
	[SaleNo] [nvarchar](max) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Remarks] [nvarchar](max) NOT NULL,
	[SaleTotalAmount] [money] NULL,
	[SaleOrderId] [int] NULL,
	[SaleStatus] [nvarchar](max) NULL,
	[EntryUserId] [int] NULL,
	[EntryDate] [datetime] NULL,
	[CheckedUserId] [int] NULL,
	[CheckedDate] [datetime] NULL,
	[PostedUserId] [int] NULL,
	[PostedDate] [datetime] NULL,
 CONSTRAINT [PK_Inventory_Transaction_SaleHead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 9/18/2018 9:12:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tokens]    Script Date: 9/18/2018 9:12:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tokens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[AuthToken] [nvarchar](250) NULL,
	[IssuedOn] [datetime] NULL,
	[ExpiresOn] [datetime] NULL,
 CONSTRAINT [PK_Tokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInformation]    Script Date: 9/18/2018 9:12:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInformation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Married] [bit] NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Sex] [bit] NULL,
	[DateOfBirth] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [ProductName]) VALUES (1, N'Apple')
INSERT [dbo].[Products] ([Id], [ProductName]) VALUES (2, N'Gava')
INSERT [dbo].[Products] ([Id], [ProductName]) VALUES (3, N'Orange')
INSERT [dbo].[Products] ([Id], [ProductName]) VALUES (4, N'Tommato')
SET IDENTITY_INSERT [dbo].[Products] OFF
ALTER TABLE [dbo].[Tokens]  WITH CHECK ADD  CONSTRAINT [FK_Tokens_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserInformation] ([Id])
GO
ALTER TABLE [dbo].[Tokens] CHECK CONSTRAINT [FK_Tokens_User]
GO
USE [master]
GO
ALTER DATABASE [TheWork] SET  READ_WRITE 
GO
