
/****** Object:  Table [dbo].[Hasta]    Script Date: 30/10/2019 19:21:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hasta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdiSoyadi] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Hasta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Randevu]    Script Date: 30/10/2019 19:21:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Randevu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HastaId] [int] NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Description] [nvarchar](max) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Location] [nvarchar](200) NULL,
	[AllDay] [bit] NULL,
	[Type] [int] NULL,
	[Subject] [nvarchar](200) NULL,
	[Status] [int] NULL,
	[Label] [int] NULL,
 CONSTRAINT [PK_Randevu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Randevu]  WITH CHECK ADD  CONSTRAINT [FK_Randevu_Hasta] FOREIGN KEY([HastaId])
REFERENCES [dbo].[Hasta] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Randevu] CHECK CONSTRAINT [FK_Randevu_Hasta]
GO
