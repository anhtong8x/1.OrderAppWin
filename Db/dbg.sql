USE [OrderFood]
GO
/****** Object:  Table [adm].[Role]    Script Date: 12/9/2018 10:18:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [adm].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [adm].[RoleAction]    Script Date: 12/9/2018 10:18:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [adm].[RoleAction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ControllerId] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[ActionName] [nvarchar](500) NULL,
	[Order] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_RoleAction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [adm].[RoleArea]    Script Date: 12/9/2018 10:18:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [adm].[RoleArea](
	[Id] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Order] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_RoleArea] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [adm].[RoleClaim]    Script Date: 12/9/2018 10:18:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [adm].[RoleClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [adm].[RoleController]    Script Date: 12/9/2018 10:18:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [adm].[RoleController](
	[Id] [nvarchar](100) NOT NULL,
	[AreaId] [nvarchar](100) NULL,
	[GroupId] [int] NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Order] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_RoleController] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [adm].[RoleDetail]    Script Date: 12/9/2018 10:18:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [adm].[RoleDetail](
	[RoleId] [int] NOT NULL,
	[ActionId] [int] NOT NULL,
 CONSTRAINT [PK_RoleDetail] PRIMARY KEY CLUSTERED 
(
	[ActionId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [adm].[RoleGroup]    Script Date: 12/9/2018 10:18:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [adm].[RoleGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Order] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_RoleGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [adm].[User]    Script Date: 12/9/2018 10:18:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [adm].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Avatar] [nvarchar](max) NULL,
	[DisplayName] [nvarchar](100) NULL,
	[IsLock] [bit] NOT NULL,
	[NoteLock] [nvarchar](1000) NULL,
	[IsReLogin] [bit] NOT NULL,
	[IsSuperAdmin] [bit] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[RoleTransportCompany] [nvarchar](max) NULL,
	[RoleSchool] [nvarchar](max) NULL,
	[RoleParents] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [adm].[UserClaim]    Script Date: 12/9/2018 10:18:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [adm].[UserClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [adm].[UserLogin]    Script Date: 12/9/2018 10:18:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [adm].[UserLogin](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [adm].[UserRole]    Script Date: 12/9/2018 10:18:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [adm].[UserRole](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [adm].[UserToken]    Script Date: 12/9/2018 10:18:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [adm].[UserToken](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserToken] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/9/2018 10:18:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [adm].[Role] ON 

INSERT [adm].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Description], [Type]) VALUES (1, N'Quyền 3', N'QUYỀN 3', N'fb420678-c78f-42bd-bebf-191a80785920', NULL, 2)
INSERT [adm].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Description], [Type]) VALUES (6, N'Quyền admin', N'QUYỀN ADMIN', N'957217dd-4467-4943-b978-85a0a69d6595', NULL, 0)
INSERT [adm].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Description], [Type]) VALUES (10, N'Quyền 2', N'QUYỀN 2', N'c667ddcb-1cbc-424d-a00e-a87e5a7e8ac0', NULL, 4)
INSERT [adm].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Description], [Type]) VALUES (11, N'Quyền 1', N'QUYỀN 1', N'ee1ca281-6432-4dd8-9f73-b3e6ab66ae4e', NULL, 0)
SET IDENTITY_INSERT [adm].[Role] OFF
SET IDENTITY_INSERT [adm].[RoleAction] ON 

INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (1, N'RoleManager', N'Index', N'Danh sách nhóm quyền', 1, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (2, N'RoleManager', N'Create', N'Thêm mới nhóm quyền', 2, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (3, N'RoleManager', N'Edit', N'Cập nhật nhóm quyền', 3, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (4, N'RoleManager', N'Delete', N'Xóa nhóm quyền', 4, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (5, N'UserManager', N'Index', N'Danh sách tài khoản', 1, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (6, N'UserManager', N'Create', N'Thêm mới tài khoản', 2, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (7, N'UserManager', N'Edit', N'Cập nhật tài khoản', 3, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (8, N'UserManager', N'Delete', N'Xóa tài khoản', 4, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (9, N'UserManager', N'UploadAvatar', N'Cập nhật ảnh đại diện', 5, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (10, N'Home', N'Index', N'Trang điều khiển 1', 4, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (27, N'LogManager', N'Index', N'Danh sách log', 1, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (28, N'LogManager', N'Details', N'Chi tiết log', 2, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (33, N'Settings', N'Index', N'Cập nhật cấu hình hệ thống', 5, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (100, N'SchoolManager', N'Index', N'Danh sách trường', 1, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (101, N'SchoolManager', N'Create', N'Thêm mới trường', 2, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (102, N'SchoolManager', N'Edit', N'Chỉnh sửa trường', 3, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (103, N'SchoolManager', N'Delete', N'Xóa trường', 4, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (104, N'SchoolManager', N'CreateClass', N'Thêm lớp', 5, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (105, N'SchoolManager', N'EditClass', N'Sửa lớp', 6, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (106, N'SchoolManager', N'DeleteClass', N'Xóa lớp', 7, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (110, N'StudentManager', N'Index', N'Danh sách học sinh', 1, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (111, N'StudentManager', N'Create', N'Thêm mới học sinh', 2, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (112, N'StudentManager', N'Edit', N'Cập nhật học sinh', 3, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (113, N'StudentManager', N'Delete', N'Xóa học sinh', 4, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (120, N'TransportCompanyManager', N'Index', N'Danh sách đơn vị vận tải', 1, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (121, N'TransportCompanyManager', N'Create', N'Thêm mới đơn vị vận tải', 2, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (122, N'TransportCompanyManager', N'Edit', N'Cập nhật đơn vị vận tải', 3, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (123, N'TransportCompanyManager', N'Delete', N'Xóa đơn vị vận tải', 4, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (130, N'VehicleManager', N'Index', N'Danh sách phương tiện', 1, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (131, N'VehicleManager', N'Create', N'Thêm mới phương tiện', 2, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (132, N'VehicleManager', N'Edit', N'Cập nhật phương tiện', 3, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (133, N'VehicleManager', N'Delete', N'Xóa phương tiện', 4, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (140, N'TransportCompanyMistakeManager', N'Index', N'Danh sách danh mục lỗi', 1, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (141, N'TransportCompanyMistakeManager', N'Create', N'Thêm mới danh mục lỗi', 2, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (142, N'TransportCompanyMistakeManager', N'Edit', N'Chỉnh sửa danh mục lỗi', 3, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (143, N'TransportCompanyMistakeManager', N'Delete', N'Xóa danh mục lỗi', 4, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (147, N'TransportCompanyEmployeeManager', N'Index', N'Danh sách nhân viên', 1, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (148, N'TransportCompanyEmployeeManager', N'Create', N'Thêm mới nhân viên', 2, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (149, N'TransportCompanyEmployeeManager', N'Edit', N'Chỉnh sửa nhân viên', 3, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (150, N'TransportCompanyEmployeeManager', N'Delete', N'Xóa nhân viên đơn vị', 4, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (151, N'StudentGroupManager', N'Index', N'Danh sách nhóm học sinh', 1, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (152, N'StudentGroupManager', N'Create', N'Thêm mới nhóm học sinh', 2, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (153, N'StudentGroupManager', N'Edit', N'Chỉnh sửa nhóm học sinh', 3, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (154, N'StudentGroupManager', N'Delete', N'Xóa nhóm học sinh', 4, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (155, N'StationManager', N'Index', N'Danh sách trạm', 1, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (156, N'StationManager', N'Create', N'Thêm mới trạm', 2, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (157, N'StationManager', N'Edit', N'Cập nhật trạm', 3, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (158, N'StationManager', N'Delete', N'Xóa trạm', 4, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (159, N'RouteManager', N'Index', N'Danh sách tuyến', 1, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (160, N'RouteManager', N'Create', N'Thêm mới tuyến', 2, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (161, N'RouteManager', N'Edit', N'Chỉnh sửa tuyến', 3, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (162, N'RouteManager', N'Delete', N'Xóa tuyến', 4, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (167, N'ConfirmationTripsManager', N'Index', N'Danh sách', 1, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (168, N'ConfirmationTripsManager', N'Create', N'Thêm mới', 2, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (169, N'ConfirmationTripsManager', N'Edit', N'Chỉnh sửa', 3, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (170, N'ConfirmationTripsManager', N'Delete', N'Xóa', 4, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (181, N'DeviceManager', N'Index', N'Danh sách', 1, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (182, N'DeviceManager', N'Create', N'Thêm mới', 2, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (183, N'DeviceManager', N'Edit', N'Chỉnh sửa', 3, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (184, N'DeviceManager', N'Delte', N'Xóa', 4, 1)
INSERT [adm].[RoleAction] ([Id], [ControllerId], [Name], [ActionName], [Order], [Status]) VALUES (185, N'TripsReport', N'Index', N'Xem báo cáo', 1, 1)
SET IDENTITY_INSERT [adm].[RoleAction] OFF
INSERT [adm].[RoleArea] ([Id], [Name], [Order], [Status]) VALUES (N'Base', N'Base', 1, 1)
INSERT [adm].[RoleArea] ([Id], [Name], [Order], [Status]) VALUES (N'Company', N'Company', 1, 1)
INSERT [adm].[RoleArea] ([Id], [Name], [Order], [Status]) VALUES (N'Log', N'Log', 7, 1)
INSERT [adm].[RoleArea] ([Id], [Name], [Order], [Status]) VALUES (N'Manager', N'Quản lý khác', 8, 1)
INSERT [adm].[RoleArea] ([Id], [Name], [Order], [Status]) VALUES (N'Null', N'Null', 4, 1)
INSERT [adm].[RoleArea] ([Id], [Name], [Order], [Status]) VALUES (N'Report', N'Report', 1, 1)
INSERT [adm].[RoleArea] ([Id], [Name], [Order], [Status]) VALUES (N'Route', N'Route', 5, 1)
INSERT [adm].[RoleArea] ([Id], [Name], [Order], [Status]) VALUES (N'School', N'School', 6, 1)
INSERT [adm].[RoleArea] ([Id], [Name], [Order], [Status]) VALUES (N'Setting', N'Setting', 3, 1)
INSERT [adm].[RoleArea] ([Id], [Name], [Order], [Status]) VALUES (N'User', N'User', 2, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'ConfirmationTripsManager', N'Route', 5, N'Xác nhận chuyến đi', 3, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'DeviceManager', N'Manager', 2, N'Quản lý thiết bị vân tay', 1, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'Home', N'Null', 1, N'Trang điều khiển', 1, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'LogManager', N'Log', 2, N'Log người dùng', 3, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'RoleManager', N'User', 2, N'Quản lý quyền', 2, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'RouteManager', N'Route', 5, N'Lên lộ trình tuyền', 3, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'SchoolManager', N'School', 4, N'Quản lý trường, lớp 1', 1, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'Settings', N'Base', 2, N'Cấu hình hệ thống', 6, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'StationManager', N'Route', 5, N'Quản lý danh mục trạm', 1, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'StudentGroupManager', N'Route', 4, N'Quản lý nhóm học sinh', 3, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'StudentManager', N'School', 4, N'Quản lý học sinh', 2, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'TransportCompanyEmployeeManager', N'Company', 3, N'Quản lý nhân viên đơn vị vận tải', 5, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'TransportCompanyManager', N'Company', 3, N'Quản lý đơn vị vận tải', 1, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'TransportCompanyMistakeManager', N'Company', 3, N'Quản lý danh mục lỗi', 4, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'TripsReport', N'Report', 1, N'Báo cáo thống kê', 1, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'UserManager', N'User', 2, N'Quản lý tài khoản', 1, 1)
INSERT [adm].[RoleController] ([Id], [AreaId], [GroupId], [Name], [Order], [Status]) VALUES (N'VehicleManager', N'Company', 3, N'Quản lý phương tiện', 2, 1)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 10)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 100)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 101)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 102)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 103)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 104)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 105)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 106)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 110)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 111)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 112)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 113)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 120)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 121)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 122)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 123)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 130)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 131)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 132)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 133)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 140)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 141)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 142)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 143)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 147)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 148)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 149)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 150)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 151)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 152)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 153)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 154)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 155)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 156)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 157)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 158)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 159)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 160)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 161)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 162)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 167)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 168)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 169)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (1, 170)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 5)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 6)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 7)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 8)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 9)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 10)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 27)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 28)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 33)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 100)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 101)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 102)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 103)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 104)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 105)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 106)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 110)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 111)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 112)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 113)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 120)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 121)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 122)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 123)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 130)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 131)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 132)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 133)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 140)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 141)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 142)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 143)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 147)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 148)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 149)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 150)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 151)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 152)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 153)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 154)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 155)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 156)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 157)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 158)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 159)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 160)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 161)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 162)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 167)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 168)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 169)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 170)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 181)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 182)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 183)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 184)
GO
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (6, 185)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (10, 10)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (10, 100)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (10, 101)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (10, 102)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (10, 103)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (10, 104)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (10, 105)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (10, 106)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (10, 110)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (10, 111)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (10, 112)
INSERT [adm].[RoleDetail] ([RoleId], [ActionId]) VALUES (10, 113)
SET IDENTITY_INSERT [adm].[RoleGroup] ON 

INSERT [adm].[RoleGroup] ([Id], [Name], [Order], [Status]) VALUES (1, N'Điều khiển', 1, 1)
INSERT [adm].[RoleGroup] ([Id], [Name], [Order], [Status]) VALUES (2, N'Hệ thống', 6, 1)
INSERT [adm].[RoleGroup] ([Id], [Name], [Order], [Status]) VALUES (3, N'Quản lý đơn vị vận tải', 2, 1)
INSERT [adm].[RoleGroup] ([Id], [Name], [Order], [Status]) VALUES (4, N'Quản lý trường, học sinh', 3, 1)
INSERT [adm].[RoleGroup] ([Id], [Name], [Order], [Status]) VALUES (5, N'Quản lý công tác đưa đón học sinh', 4, 1)
SET IDENTITY_INSERT [adm].[RoleGroup] OFF
SET IDENTITY_INSERT [adm].[User] ON 

INSERT [adm].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Avatar], [DisplayName], [IsLock], [NoteLock], [IsReLogin], [IsSuperAdmin], [Note], [CreatedUserId], [CreatedDate], [UpdatedUserId], [UpdatedDate], [RoleTransportCompany], [RoleSchool], [RoleParents]) VALUES (18, N'administrator', N'ADMINISTRATOR', N'phamtrong1989@gmail.com', N'PHAMTRONG1989@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEA1KxIcujRZmJGlV6oPVoTFkkGmCAKCYxpctjZw/cvbp9DcZsSJwC41RHzJfYKzQ7A==', N'QJXCJYM7STL6Y5CAAIQDYOLHHLCE2M2W', N'5ba7ce4d-a520-429b-8555-7c35279a16a5', N'09872655821', 0, 0, NULL, 1, 0, N'/Data/Avatar/ecaba803-2c0c-4ec3-bcc1-93ede84c93cc.jpeg', N'Phạm Văn Trọng', 0, N'', 0, 1, N'1234', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [adm].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Avatar], [DisplayName], [IsLock], [NoteLock], [IsReLogin], [IsSuperAdmin], [Note], [CreatedUserId], [CreatedDate], [UpdatedUserId], [UpdatedDate], [RoleTransportCompany], [RoleSchool], [RoleParents]) VALUES (33, N'trungtambus', N'TRUNGTAMBUS', N'phamtrongit1989@gmail.com', N'PHAMTRONGIT1989@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEOcTBJG6zKOAIES72MqBWaq7ocuPG5L8iZAdQ44lZKN/DVrdVBoZ37QND3wRzn8PsA==', N'BM6TGOLJCOI5TSYMI6OHXYNOVSX5SYHR', N'cd1ac5af-db35-4859-abf9-db765d0f0146', NULL, 0, 0, NULL, 1, 0, NULL, N'Trung tâm BUS', 0, NULL, 1, 0, NULL, 18, CAST(N'2018-07-09 09:01:59.1567189' AS DateTime2), NULL, NULL, N'', N'', NULL)
INSERT [adm].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Avatar], [DisplayName], [IsLock], [NoteLock], [IsReLogin], [IsSuperAdmin], [Note], [CreatedUserId], [CreatedDate], [UpdatedUserId], [UpdatedDate], [RoleTransportCompany], [RoleSchool], [RoleParents]) VALUES (34, N'donvibus', N'DONVIBUS', N'phamtrongit01051989@gmail.com', N'PHAMTRONG01051989@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEApXjl2djBjbAXK7F+RHL4wDA5whkV/GnwQqXJXNlMe08HYEAPXyEqmxb3q/HagS7g==', N'2375V6TXLPJICDMKEXYD5WJGZ4APLO6Q', N'd6e1af27-3860-4d66-9114-3eb456f85a00', NULL, 0, 0, NULL, 1, 0, NULL, N'Đơn vị bus', 0, N'', 1, 0, NULL, 18, CAST(N'2018-07-09 09:04:37.3218135' AS DateTime2), NULL, NULL, N'2,31', N'', NULL)
INSERT [adm].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Avatar], [DisplayName], [IsLock], [NoteLock], [IsReLogin], [IsSuperAdmin], [Note], [CreatedUserId], [CreatedDate], [UpdatedUserId], [UpdatedDate], [RoleTransportCompany], [RoleSchool], [RoleParents]) VALUES (35, N'taikhoantruong', N'TAIKHOANTRUONG', N'phamtrong01051989@gmail.com', N'PHAMTRONGIT01051989@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEJFu2ExgDU4kreTh0s7pHKTjFEH7dtulDUOn7HxXM+tuGJHXC7ympTyfxQBUCdGHNA==', N'B5G7XCCAQHXVOHJXZFXFOHI3UFBRGX4S', N'fa35eecc-0b9b-4ba1-b07d-47672f3f1086', NULL, 0, 0, NULL, 1, 0, NULL, N'Tài khoản trường', 0, N'', 1, 0, NULL, 18, CAST(N'2018-07-17 15:51:35.9065142' AS DateTime2), NULL, NULL, N'', N'254,272', NULL)
INSERT [adm].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Avatar], [DisplayName], [IsLock], [NoteLock], [IsReLogin], [IsSuperAdmin], [Note], [CreatedUserId], [CreatedDate], [UpdatedUserId], [UpdatedDate], [RoleTransportCompany], [RoleSchool], [RoleParents]) VALUES (36, N'taikhoantruong2', N'TAIKHOANTRUONG2', N'phamtrong123it1989@gmail.com', N'PHAMTRONG123IT1989@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEPcb9Buzbxp8mXOkRCb6A13bLwPr7T/c3RbH26MgkJp22P60DIDm+u4d3gaZgKV9Iw==', N'N6OVCSMBNYHCHLDCMOJDZ2JVA4SEMCOO', N'1bec2241-27a6-4378-982e-291042231434', NULL, 0, 0, NULL, 1, 0, NULL, N'Tài khoản trường', 0, N'', 1, 0, NULL, 18, CAST(N'2018-07-19 17:18:52.5165797' AS DateTime2), NULL, NULL, N'', N'201,254', NULL)
SET IDENTITY_INSERT [adm].[User] OFF
INSERT [adm].[UserRole] ([UserId], [RoleId]) VALUES (34, 1)
INSERT [adm].[UserRole] ([UserId], [RoleId]) VALUES (33, 6)
INSERT [adm].[UserRole] ([UserId], [RoleId]) VALUES (35, 10)
INSERT [adm].[UserRole] ([UserId], [RoleId]) VALUES (36, 10)
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181207010728_v1.0', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181207013534_v1.1', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181207030953_v1.3', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181207084513_v1.4', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181208032244_v1.5', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181208045147_v1.6', N'2.1.4-rtm-31024')
ALTER TABLE [adm].[RoleAction]  WITH CHECK ADD  CONSTRAINT [FK_RoleAction_RoleController_ControllerId] FOREIGN KEY([ControllerId])
REFERENCES [adm].[RoleController] ([Id])
GO
ALTER TABLE [adm].[RoleAction] CHECK CONSTRAINT [FK_RoleAction_RoleController_ControllerId]
GO
ALTER TABLE [adm].[RoleClaim]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaim_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [adm].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [adm].[RoleClaim] CHECK CONSTRAINT [FK_RoleClaim_Role_RoleId]
GO
ALTER TABLE [adm].[RoleController]  WITH CHECK ADD  CONSTRAINT [FK_RoleController_RoleArea_AreaId] FOREIGN KEY([AreaId])
REFERENCES [adm].[RoleArea] ([Id])
GO
ALTER TABLE [adm].[RoleController] CHECK CONSTRAINT [FK_RoleController_RoleArea_AreaId]
GO
ALTER TABLE [adm].[RoleController]  WITH CHECK ADD  CONSTRAINT [FK_RoleController_RoleGroup_GroupId] FOREIGN KEY([GroupId])
REFERENCES [adm].[RoleGroup] ([Id])
GO
ALTER TABLE [adm].[RoleController] CHECK CONSTRAINT [FK_RoleController_RoleGroup_GroupId]
GO
ALTER TABLE [adm].[RoleDetail]  WITH CHECK ADD  CONSTRAINT [FK_RoleDetail_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [adm].[Role] ([Id])
GO
ALTER TABLE [adm].[RoleDetail] CHECK CONSTRAINT [FK_RoleDetail_Role_RoleId]
GO
ALTER TABLE [adm].[RoleDetail]  WITH CHECK ADD  CONSTRAINT [FK_RoleDetail_RoleAction_ActionId] FOREIGN KEY([ActionId])
REFERENCES [adm].[RoleAction] ([Id])
GO
ALTER TABLE [adm].[RoleDetail] CHECK CONSTRAINT [FK_RoleDetail_RoleAction_ActionId]
GO
ALTER TABLE [adm].[UserClaim]  WITH CHECK ADD  CONSTRAINT [FK_UserClaim_User_UserId] FOREIGN KEY([UserId])
REFERENCES [adm].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [adm].[UserClaim] CHECK CONSTRAINT [FK_UserClaim_User_UserId]
GO
ALTER TABLE [adm].[UserLogin]  WITH CHECK ADD  CONSTRAINT [FK_UserLogin_User_UserId] FOREIGN KEY([UserId])
REFERENCES [adm].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [adm].[UserLogin] CHECK CONSTRAINT [FK_UserLogin_User_UserId]
GO
ALTER TABLE [adm].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [adm].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [adm].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role_RoleId]
GO
ALTER TABLE [adm].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User_UserId] FOREIGN KEY([UserId])
REFERENCES [adm].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [adm].[UserRole] CHECK CONSTRAINT [FK_UserRole_User_UserId]
GO
ALTER TABLE [adm].[UserToken]  WITH CHECK ADD  CONSTRAINT [FK_UserToken_User_UserId] FOREIGN KEY([UserId])
REFERENCES [adm].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [adm].[UserToken] CHECK CONSTRAINT [FK_UserToken_User_UserId]
GO
