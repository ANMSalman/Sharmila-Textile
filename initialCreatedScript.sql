USE [master]
GO
/****** Object:  Database [SharmilaTex]    Script Date: 2/5/2020 4:40:41 PM ******/
CREATE DATABASE [SharmilaTex]
GO
USE [SharmilaTex]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2/5/2020 4:40:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] NOT NULL,
	[CustomerName] [varchar](50) NULL,
	[NIC] [nchar](10) NULL,
	[HomeAddress] [varchar](max) NULL,
	[HomeLandline] [nchar](10) NULL,
	[OfficeAddress] [varchar](max) NULL,
	[OfficeLandline] [nchar](10) NULL,
	[Mobile] [nchar](10) NULL,
	[OpeningBalance] [decimal](18, 2) NULL,
	[CurrentBalance] [decimal](18, 2) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[CurrentStatus] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerAttachment]    Script Date: 2/5/2020 4:40:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerAttachment](
	[AttachmentId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[AttachmentName] [varchar](max) NULL,
	[AttachmentPath] [varchar](max) NULL,
 CONSTRAINT [PK_CustomerAttachment] PRIMARY KEY CLUSTERED 
(
	[AttachmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 2/5/2020 4:40:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffId] [int] IDENTITY(1,1) NOT NULL,
	[StaffName] [varchar](50) NULL,
	[NIC] [varchar](12) NULL,
	[Address] [varchar](max) NULL,
	[ContactNo] [varchar](10) NULL,
	[CurrentStatus] [int] NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[StaffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffAttachment]    Script Date: 2/5/2020 4:40:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffAttachment](
	[AttachmentId] [int] IDENTITY(1,1) NOT NULL,
	[StaffId] [int] NULL,
	[AttachmentName] [varchar](max) NULL,
	[AttachmentPath] [varchar](max) NULL,
 CONSTRAINT [PK_StaffAttachment] PRIMARY KEY CLUSTERED 
(
	[AttachmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 2/5/2020 4:40:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierId] [int] NOT NULL,
	[SupplierName] [varchar](50) NULL,
	[Address] [varchar](max) NULL,
	[Landline] [nchar](10) NULL,
	[Mobile] [nchar](10) NULL,
	[OpeningBalance] [decimal](18, 2) NULL,
	[CurrentBalance] [decimal](18, 2) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[CurrentStatus] [int] NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierAttachment]    Script Date: 2/5/2020 4:40:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierAttachment](
	[AttachmentId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NULL,
	[AttachmentName] [varchar](max) NULL,
	[AttachmentPath] [varchar](max) NULL,
 CONSTRAINT [PK_SupplierAttachment] PRIMARY KEY CLUSTERED 
(
	[AttachmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/5/2020 4:40:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[StaffId] [int] NULL,
	[UserName] [varchar](10) NULL,
	[Password] [varchar](50) NULL,
	[CurrentStatus] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_User]
GO
ALTER TABLE [dbo].[CustomerAttachment]  WITH CHECK ADD  CONSTRAINT [FK_CustomerAttachment_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomerAttachment] CHECK CONSTRAINT [FK_CustomerAttachment_Customer]
GO
ALTER TABLE [dbo].[StaffAttachment]  WITH CHECK ADD  CONSTRAINT [FK_StaffAttachment_Staff] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staff] ([StaffId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StaffAttachment] CHECK CONSTRAINT [FK_StaffAttachment_Staff]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_Supplier_User]
GO
ALTER TABLE [dbo].[SupplierAttachment]  WITH CHECK ADD  CONSTRAINT [FK_SupplierAttachment_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([SupplierId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SupplierAttachment] CHECK CONSTRAINT [FK_SupplierAttachment_Supplier]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Staff] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staff] ([StaffId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Staff]
GO
USE [master]
GO
ALTER DATABASE [SharmilaTex] SET  READ_WRITE 
GO
