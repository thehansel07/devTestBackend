USE [TestDevBackEnd]
GO
/****** Object:  Table [dbo].[Announcement]    Script Date: 1/5/2024 6:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Announcement](
	[id] [int] NOT NULL,
	[link] [varchar](max) NULL,
	[title] [varchar](max) NULL,
	[content] [varchar](max) NULL,
	[date] [datetime] NULL,
	[AuditCreateUser] [datetime] NULL,
	[AuditCreateDate] [datetime] NULL,
	[AuditUpdateUser] [datetime] NULL,
	[AuditUpdateDate] [datetime] NULL,
	[AuditDeleteUser] [datetime] NULL,
	[AuditDeleteDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
