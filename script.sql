USE [Gateways]
GO
/****** Object:  Table [dbo].[Devices]    Script Date: 5/22/2022 5:43:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Devices](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Vendor] [nvarchar](50) NOT NULL,
	[StatusId] [int] NOT NULL,
	[GatewayId] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[LastUpdatedOn] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_PeripheralDevices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gateways]    Script Date: 5/22/2022 5:43:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gateways](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IPV4] [varchar](15) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[LastUpdatedOn] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Gateways] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeripheralDevicesStatuses]    Script Date: 5/22/2022 5:43:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeripheralDevicesStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_PeripheralDevicesStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Devices] ON 

INSERT [dbo].[Devices] ([Id], [Vendor], [StatusId], [GatewayId], [CreatedOn], [LastUpdatedOn], [IsDeleted]) VALUES (1, N'vendor1', 1, N'e1a2841d-5c7c-4c95-8686-655f7590f4b6', CAST(N'2022-05-20T14:01:10.6000000' AS DateTime2), NULL, 1)
INSERT [dbo].[Devices] ([Id], [Vendor], [StatusId], [GatewayId], [CreatedOn], [LastUpdatedOn], [IsDeleted]) VALUES (2, N'vendor2', 1, N'e1a2841d-5c7c-4c95-8686-655f7590f4b6', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1)
INSERT [dbo].[Devices] ([Id], [Vendor], [StatusId], [GatewayId], [CreatedOn], [LastUpdatedOn], [IsDeleted]) VALUES (3, N'vendor2', 1, N'e1a2841d-5c7c-4c95-8686-655f7590f4b6', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Devices] ([Id], [Vendor], [StatusId], [GatewayId], [CreatedOn], [LastUpdatedOn], [IsDeleted]) VALUES (4, N'vendor2', 1, N'e1a2841d-5c7c-4c95-8686-655f7590f4b6', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Devices] ([Id], [Vendor], [StatusId], [GatewayId], [CreatedOn], [LastUpdatedOn], [IsDeleted]) VALUES (5, N'Apple', 1, N'e1a2841d-5c7c-4c95-8686-655f7590f4b6', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Devices] ([Id], [Vendor], [StatusId], [GatewayId], [CreatedOn], [LastUpdatedOn], [IsDeleted]) VALUES (6, N'xaomi', 1, N'e1a2841d-5c7c-4c95-8686-655f7590f4b6', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Devices] ([Id], [Vendor], [StatusId], [GatewayId], [CreatedOn], [LastUpdatedOn], [IsDeleted]) VALUES (10, N'string', 1, N'e1a2841d-5c7c-4c95-8686-655f7590f4b6', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Devices] ([Id], [Vendor], [StatusId], [GatewayId], [CreatedOn], [LastUpdatedOn], [IsDeleted]) VALUES (11, N'Samsung', 1, N'3fa85f64-5717-4562-b3fc-2c963f66afa6', CAST(N'2022-05-20T20:26:33.3137744' AS DateTime2), NULL, 0)
SET IDENTITY_INSERT [dbo].[Devices] OFF
INSERT [dbo].[Gateways] ([Id], [Name], [IPV4], [Description], [CreatedOn], [LastUpdatedOn], [IsDeleted]) VALUES (N'922558f6-4e9d-424b-a630-08da3a945b71', N'Gateway2', N'0.0.0.0', NULL, CAST(N'2022-05-20T21:09:56.6729069' AS DateTime2), NULL, 0)
INSERT [dbo].[Gateways] ([Id], [Name], [IPV4], [Description], [CreatedOn], [LastUpdatedOn], [IsDeleted]) VALUES (N'445b2111-103e-46ed-5603-08da3a94a34d', N'Gateway3', N'0.0.0.1', NULL, CAST(N'2022-05-20T21:12:07.4393143' AS DateTime2), NULL, 0)
INSERT [dbo].[Gateways] ([Id], [Name], [IPV4], [Description], [CreatedOn], [LastUpdatedOn], [IsDeleted]) VALUES (N'111cb8eb-2927-4ab0-e1df-08da3b95c05a', N'string', N'0.0.0.0', NULL, CAST(N'2022-05-22T03:52:37.3518516' AS DateTime2), NULL, 0)
INSERT [dbo].[Gateways] ([Id], [Name], [IPV4], [Description], [CreatedOn], [LastUpdatedOn], [IsDeleted]) VALUES (N'165b83b8-4d95-428b-e1e0-08da3b95c05a', N'string', N'0.0.0.0', NULL, CAST(N'2022-05-22T03:53:28.1617502' AS DateTime2), NULL, 0)
INSERT [dbo].[Gateways] ([Id], [Name], [IPV4], [Description], [CreatedOn], [LastUpdatedOn], [IsDeleted]) VALUES (N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'string', N'0.0.0.0', NULL, CAST(N'2022-05-22T03:51:00.4861832' AS DateTime2), NULL, 0)
INSERT [dbo].[Gateways] ([Id], [Name], [IPV4], [Description], [CreatedOn], [LastUpdatedOn], [IsDeleted]) VALUES (N'e1a2841d-5c7c-4c95-8686-655f7590f4b6', N'Gate1', N'111.111.111.111', N'hi', CAST(N'2022-05-20T13:47:08.6966667' AS DateTime2), NULL, 0)
SET IDENTITY_INSERT [dbo].[PeripheralDevicesStatuses] ON 

INSERT [dbo].[PeripheralDevicesStatuses] ([Id], [Status]) VALUES (1, N'Online')
INSERT [dbo].[PeripheralDevicesStatuses] ([Id], [Status]) VALUES (2, N'Offline')
SET IDENTITY_INSERT [dbo].[PeripheralDevicesStatuses] OFF
ALTER TABLE [dbo].[Devices] ADD  CONSTRAINT [DF_PeripheralDevices_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Devices] ADD  CONSTRAINT [DF_PeripheralDevices_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Gateways] ADD  CONSTRAINT [DF_Gateways_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Gateways] ADD  CONSTRAINT [DF_Gateways_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Gateways] ADD  CONSTRAINT [DF_Gateways_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
