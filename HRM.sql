USE [master]
GO
/****** Object:  Database [HRMDB]    Script Date: 12/8/2021 1:57:33 AM ******/
CREATE DATABASE [HRMDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HRMB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HRMB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HRMB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HRMB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HRMDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HRMDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HRMDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HRMDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HRMDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HRMDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HRMDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HRMDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HRMDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HRMDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HRMDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HRMDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HRMDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HRMDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HRMDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HRMDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HRMDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HRMDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HRMDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HRMDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HRMDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HRMDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HRMDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HRMDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HRMDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HRMDB] SET  MULTI_USER 
GO
ALTER DATABASE [HRMDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HRMDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HRMDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HRMDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HRMDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HRMDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HRMDB] SET QUERY_STORE = OFF
GO
USE [HRMDB]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[Description] [varchar](150) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](50) NOT NULL,
	[Description] [varchar](150) NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DesignationTitle] [varchar](50) NOT NULL,
	[Description] [varchar](150) NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [varchar](100) NOT NULL,
	[FatherName] [varchar](100) NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[PhoneNo] [varchar](50) NOT NULL,
	[Mail] [varchar](150) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[DesignationId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL,
	[JoiningDate] [datetime] NOT NULL,
	[NID] [int] NOT NULL,
	[Status] [varchar](10) NOT NULL,
	[MaterialStatus] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([Id], [CompanyName], [Description]) VALUES (4009, N'ABC', N'gt4t')
INSERT [dbo].[Company] ([Id], [CompanyName], [Description]) VALUES (4010, N'XYZ', N'gerte')
INSERT [dbo].[Company] ([Id], [CompanyName], [Description]) VALUES (4011, N'MNO', N'w3r')
INSERT [dbo].[Company] ([Id], [CompanyName], [Description]) VALUES (4012, N'OPQ', N'tret')
INSERT [dbo].[Company] ([Id], [CompanyName], [Description]) VALUES (4013, N'syz', N'ffyj')
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [DepartmentName], [Description], [CompanyId]) VALUES (3018, N'Software Development', N'eghrt', 4009)
INSERT [dbo].[Department] ([Id], [DepartmentName], [Description], [CompanyId]) VALUES (3019, N'Accuntant', N'eqe3', 4009)
INSERT [dbo].[Department] ([Id], [DepartmentName], [Description], [CompanyId]) VALUES (3020, N'IT ', N'rfdewf', 4009)
INSERT [dbo].[Department] ([Id], [DepartmentName], [Description], [CompanyId]) VALUES (3022, N'Accuntant', N'efef', 4010)
INSERT [dbo].[Department] ([Id], [DepartmentName], [Description], [CompanyId]) VALUES (3024, N'Software Development', N'fde', 4010)
INSERT [dbo].[Department] ([Id], [DepartmentName], [Description], [CompanyId]) VALUES (3025, N'Software Development', N'ge', 4012)
INSERT [dbo].[Department] ([Id], [DepartmentName], [Description], [CompanyId]) VALUES (3026, N'Accuntant', N'ty', 4012)
INSERT [dbo].[Department] ([Id], [DepartmentName], [Description], [CompanyId]) VALUES (3027, N'Software Development', N'tdgff', 4013)
INSERT [dbo].[Department] ([Id], [DepartmentName], [Description], [CompanyId]) VALUES (3028, N'Accuntant', N'yfbyf', 4013)
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([Id], [DesignationTitle], [Description], [DepartmentId]) VALUES (2010, N'Jr. Software Engineer', N'eghrt', 3018)
INSERT [dbo].[Designation] ([Id], [DesignationTitle], [Description], [DepartmentId]) VALUES (2011, N'Software Engineer', N'34bh5w34', 3018)
INSERT [dbo].[Designation] ([Id], [DesignationTitle], [Description], [DepartmentId]) VALUES (2012, N'Sr. Software Engineer', N'vqeq', 3018)
INSERT [dbo].[Designation] ([Id], [DesignationTitle], [Description], [DepartmentId]) VALUES (2013, N'Jr. Software Engineer', N'gw4wvg', 3020)
INSERT [dbo].[Designation] ([Id], [DesignationTitle], [Description], [DepartmentId]) VALUES (2014, N'Software Engineer', N'trbtb', 3020)
SET IDENTITY_INSERT [dbo].[Designation] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [EmployeeName], [FatherName], [Gender], [DOB], [Address], [PhoneNo], [Mail], [Country], [DepartmentId], [DesignationId], [CompanyId], [Salary], [JoiningDate], [NID], [Status], [MaterialStatus]) VALUES (1004, N'Md Sharif', N'Md. Amir', N'Male', CAST(N'1996-11-09T00:00:00.000' AS DateTime), N'Jatrabari', N'01534718068', N'a@gmail.com', N'Bangladeshi', 3018, 2010, 4009, CAST(20000.00 AS Decimal(18, 2)), CAST(N'2021-01-09T00:00:00.000' AS DateTime), 4611, N'Active', N'Unmarried')
INSERT [dbo].[Employee] ([Id], [EmployeeName], [FatherName], [Gender], [DOB], [Address], [PhoneNo], [Mail], [Country], [DepartmentId], [DesignationId], [CompanyId], [Salary], [JoiningDate], [NID], [Status], [MaterialStatus]) VALUES (1005, N'Sabuj', N'Md. Amir', N'Male', CAST(N'1994-09-09T00:00:00.000' AS DateTime), N'Jatrabari', N'01534718068', N'a@gmail.com', N'Bangladeshi', 3018, 2010, 4009, CAST(20000.00 AS Decimal(18, 2)), CAST(N'2021-02-09T00:00:00.000' AS DateTime), 567, N'Active', N'Unmarried')
INSERT [dbo].[Employee] ([Id], [EmployeeName], [FatherName], [Gender], [DOB], [Address], [PhoneNo], [Mail], [Country], [DepartmentId], [DesignationId], [CompanyId], [Salary], [JoiningDate], [NID], [Status], [MaterialStatus]) VALUES (1006, N'Salim', N'Md. Amir', N'Male', CAST(N'1994-03-09T00:00:00.000' AS DateTime), N'Jatrabari', N'01534718068', N'a@gmail.com', N'Bangladeshi', 3018, 2011, 4009, CAST(20000.00 AS Decimal(18, 2)), CAST(N'2021-02-09T00:00:00.000' AS DateTime), 5776161, N'Active', N'Unmarried')
INSERT [dbo].[Employee] ([Id], [EmployeeName], [FatherName], [Gender], [DOB], [Address], [PhoneNo], [Mail], [Country], [DepartmentId], [DesignationId], [CompanyId], [Salary], [JoiningDate], [NID], [Status], [MaterialStatus]) VALUES (1007, N'Md Sharif', N'Md. Amir', N'Male', CAST(N'1998-02-09T00:00:00.000' AS DateTime), N'Jatrabari', N'01534718068', N'a@gmail.com', N'Bangladeshi', 3018, 2010, 4009, CAST(20000.00 AS Decimal(18, 2)), CAST(N'2021-03-09T00:00:00.000' AS DateTime), 6, N'Active', N'Unmarried')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
/****** Object:  StoredProcedure [dbo].[AddComapnay]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[AddComapnay]
@ComapnyName varchar(50),
@Description varchar(150)
AS
BEGIN
   Insert into Company(CompanyName,Description)Values(@ComapnyName,@Description)
END
GO
/****** Object:  StoredProcedure [dbo].[AddDepartment]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AddDepartment]
@DepartmentName varchar(50),
@Description varchar(150),
@CompanyId int
AS
BEGIN
   Insert into Department(DepartmentName,Description,CompanyId)Values(@DepartmentName,@Description,@CompanyId)
END
GO
/****** Object:  StoredProcedure [dbo].[AddDesignation]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AddDesignation]
@DesignationTitle varchar(50),
@DepartmentId int,
@Description varchar(150)
AS
BEGIN
   Insert into Designation(DesignationTitle,Description,DepartmentId)Values(@DesignationTitle,@Description,@DepartmentId)
END
GO
/****** Object:  StoredProcedure [dbo].[AddEmployee]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AddEmployee]
@EmployeName varchar(100),
@FatherName varchar(100),
@Gender varchar(10),
@DOB datetime,
@Address varchar(200),
@PhoneNo varchar(50),
@Mail varchar(150),
@Country varchar(50),
@DepartmentId int,
@DesignationId int,
@CompanyId int,
@Salary decimal(18,2) ,
@JoiningDate datetime,
@NID int,
@Status varchar(10),
@MaterialStatus varchar(10)
AS
BEGIN
   Insert into Employee(EmployeeName,FatherName,Gender,DOB,Address,PhoneNo,Mail,Country,DepartmentId,DesignationId,CompanyId,Salary,JoiningDate,NID,Status,MaterialStatus)Values(@EmployeName,@FatherName,@Gender,@DOB,@Address,@PhoneNo,@Mail,@Country,@DepartmentId,@DesignationId,@CompanyId,@Salary,@JoiningDate,@NID,@Status,@MaterialStatus)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteById]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[DeleteById]
@Id int,
@Action varchar(20)

AS
BEGIN
if @Action='Company'
  Delete From Company Where Id=@Id
  if @Action='Department'
  Delete From Department Where Id=@Id
  if @Action='Designation'
  Delete From Designation Where Id=@Id
  if @Action='Employee'
  Delete From Employee Where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[ExistData]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ExistData]
@Action varchar(50),
@CompanyName varchar(50),
@DepartmentName varchar(50)
AS
BEGIN
  IF @Action='Company'
  BEGIN
     Select * From Company Where CompanyName=@CompanyName
  END
   IF @Action='Department'
  BEGIN
     Select * From Department Where DepartmentName=@DepartmentName
  END
END
GO
/****** Object:  StoredProcedure [dbo].[ExistDataCompany]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ExistDataCompany]

@CompanyName varchar(50)

AS
BEGIN

  
     Select * From Company Where CompanyName=@CompanyName
  END
GO
/****** Object:  StoredProcedure [dbo].[ExistDataDepartmentByName]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ExistDataDepartmentByName]
@DepartmentName varchar(50),
@CompanyId int
AS
  BEGIN
     Select * From Department Where DepartmentName=@DepartmentName AND CompanyId=@CompanyId
  END
GO
/****** Object:  StoredProcedure [dbo].[ExistDataDesignation]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ExistDataDesignation]
@DesignationTitle varchar(50),
@DepartmentId int
AS
  BEGIN
     Select * From Designation Where DesignationTitle=@DesignationTitle AND DepartmentId=@DepartmentId
  END
GO
/****** Object:  StoredProcedure [dbo].[GetAllCompany]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetAllCompany]

AS
BEGIN
   Select * From Company
   END
GO
/****** Object:  StoredProcedure [dbo].[GetAllDepartment]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetAllDepartment]
As
BEGIN
Select dep.Id,dep.DepartmentName,c.CompanyName
From Department dep
 left join  Company c on  c.Id=dep.CompanyId

 END
GO
/****** Object:  StoredProcedure [dbo].[GetAllDesignation]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetAllDesignation]

AS
BEGIN
   Select d.Id,d.DesignationTitle,dep.DepartmentName From Designation d
   left join Department dep on dep.Id=d.DepartmentId
   END
GO
/****** Object:  StoredProcedure [dbo].[GetAllEmployee]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetAllEmployee]
As
BEGIN
Select emp.id, emp.EmployeeName,emp.Gender,emp.Address,emp.PhoneNo,emp.Salary,emp.Status,emp.MaterialStatus, d.DesignationTitle,dept.DepartmentName,c.CompanyName
From Employee emp
 left join  Department dept on  dept.Id=emp.DepartmentId
 left join Designation d on d.Id=emp.DesignationId
 left join Company c on c.Id=emp.CompanyId
 END
GO
/****** Object:  StoredProcedure [dbo].[GetDeparmentByCompanyId]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetDeparmentByCompanyId]
@CompanyId int
AS
BEGIN
  SELECT Id,DepartmentName FROM Department Where CompanyId=@CompanyId
END
GO
/****** Object:  StoredProcedure [dbo].[GetDesignationByDepartmentId]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetDesignationByDepartmentId]
@DepartmentId int
AS
BEGIN
  SELECT Id,DesignationTitle FROM Designation Where DepartmentId=@DepartmentId
END
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeByStatus]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetEmployeeByStatus]
@Status varchar(10)
As
BEGIN
Select emp.id, emp.EmployeeName,emp.Gender,emp.Address,emp.PhoneNo,emp.Salary,emp.Status, d.DesignationTitle,dept.DepartmentName,c.CompanyName
From Employee emp
 left join  Department dept on  dept.Id=emp.DepartmentId
 left join Designation d on d.Id=emp.DesignationId
 left join Company c on c.Id=emp.CompanyId
 Where Status=@Status
 END
GO
/****** Object:  StoredProcedure [dbo].[SearchEmployeeByJoiningDate]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SearchEmployeeByJoiningDate]
@FromDate datetime,
@ToDate datetime
As
BEGIN
  Select emp.id, emp.EmployeeName,emp.Gender,emp.Address,emp.PhoneNo,emp.JoiningDate,emp.Salary,d.DesignationTitle,dept.DepartmentName,c.CompanyName
From Employee emp
 left join  Department dept on  dept.Id=emp.DepartmentId
 left join Designation d on d.Id=emp.DesignationId
 left join Company c on c.Id=emp.CompanyId
  Where JoiningDate Between @FromDate And @ToDate
END
GO
/****** Object:  StoredProcedure [dbo].[Update]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Update]
@Id int,
@CompanyName varchar(50),
@DepartmentName varchar(50),
@DesignationTitle varchar(50),
@Description varchar(150),
@Action varchar(50)
AS
BEGIN
 if @Action='Company'
 Begin
  Update Company set CompanyName=@CompanyName,Description=@Description
  Where Id=@Id
  End
  if @Action='Department'
 Begin
  Update Department set DepartmentName=@DepartmentName,Description=@Description
  Where Id=@Id
  End
  if @Action='Designation'
 Begin
  Update Designation set DesignationTitle=@DesignationTitle,Description=@Description
  Where Id=@Id
  End
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCompany]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[UpdateCompany]
@Id int,
@CompanyName varchar(50),
@Description varchar(150)
AS
BEGIN
  Update Company set CompanyName=@CompanyName,Description=@Description
  Where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateDepartment]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[UpdateDepartment]
@Id int,
@DepartmentName varchar(50),
@Description varchar(150),
@CompanyId int

AS
BEGIN
  Update Department set DepartmentName=@DepartmentName,Description=@Description,CompanyId=@CompanyId
  Where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateDesignation]    Script Date: 12/8/2021 1:57:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[UpdateDesignation]
@Id int,
@DesignationTitle varchar(50),
@Description varchar(150),
@DepartmentId int
AS
BEGIN
  Update Designation set DesignationTitle=@DesignationTitle,Description=@Description ,DepartmentId=@DepartmentId
  Where Id=@Id
END
GO
USE [master]
GO
ALTER DATABASE [HRMDB] SET  READ_WRITE 
GO
