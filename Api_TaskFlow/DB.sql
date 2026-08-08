USE [master]
GO
/****** Object:  Database [FinancialProductsDb]    Script Date: 08/08/2026 11:55:43  a. m. ******/
CREATE DATABASE [FinancialProductsDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FinancialProductsDb', FILENAME = N'/var/opt/mssql/data/FinancialProductsDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FinancialProductsDb_log', FILENAME = N'/var/opt/mssql/data/FinancialProductsDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [FinancialProductsDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FinancialProductsDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FinancialProductsDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FinancialProductsDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FinancialProductsDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FinancialProductsDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FinancialProductsDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET RECOVERY FULL 
GO
ALTER DATABASE [FinancialProductsDb] SET  MULTI_USER 
GO
ALTER DATABASE [FinancialProductsDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FinancialProductsDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FinancialProductsDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FinancialProductsDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FinancialProductsDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FinancialProductsDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FinancialProductsDb', N'ON'
GO
ALTER DATABASE [FinancialProductsDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [FinancialProductsDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [FinancialProductsDb]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 08/08/2026 11:55:43  a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentType] [nvarchar](50) NOT NULL,
	[IdentificationNumber] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 08/08/2026 11:55:43  a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTypes]    Script Date: 08/08/2026 11:55:43  a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 
GO
INSERT [dbo].[Clients] ([Id], [DocumentType], [IdentificationNumber], [FirstName], [LastName], [Address], [PhoneNumber], [Email]) VALUES (1, N'CC', N'10203040', N'José', N'Peña', N'Calle 123 #45-67', N'3001234567', N'jose.pena@example.com')
GO
INSERT [dbo].[Clients] ([Id], [DocumentType], [IdentificationNumber], [FirstName], [LastName], [Address], [PhoneNumber], [Email]) VALUES (2, N'CC', N'20304050', N'Ana', N'Gómez', N'Carrera 10 #20-30', N'3109876543', N'ana.gomez@example.com')
GO
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductTypes] ON 
GO
INSERT [dbo].[ProductTypes] ([Id], [Name], [Description]) VALUES (1, N'Cuentas de Ahorro', N'Cuenta básica para depósitos y retiros')
GO
INSERT [dbo].[ProductTypes] ([Id], [Name], [Description]) VALUES (2, N'Tarjetas de Crédito', N'Línea de crédito para compras')
GO
INSERT [dbo].[ProductTypes] ([Id], [Name], [Description]) VALUES (3, N'Préstamos', N'Créditos personales o hipotecarios')
GO
SET IDENTITY_INSERT [dbo].[ProductTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [Name], [ProductTypeId], [ClientId], [IsActive]) VALUES (1, N'Cuenta Ahorros José', 1, 1, 1)
GO
INSERT [dbo].[Products] ([Id], [Name], [ProductTypeId], [ClientId], [IsActive]) VALUES (2, N'Tarjeta Crédito José', 2, 1, 1)
GO
INSERT [dbo].[Products] ([Id], [Name], [ProductTypeId], [ClientId], [IsActive]) VALUES (3, N'Préstamo Ana', 3, 2, 1)
GO
INSERT [dbo].[Products] ([Id], [Name], [ProductTypeId], [ClientId], [IsActive]) VALUES (4, N'Cuenta Ahorros Ana', 1, 2, 1)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Clients]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductTypes] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductTypes] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductTypes]
GO
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT UQ_Clients_IdentificationNumber
UNIQUE ([IdentificationNumber]);
GO
USE [master]
GO
ALTER DATABASE [FinancialProductsDb] SET  READ_WRITE 
GO
