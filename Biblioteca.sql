USE [Biblioteca]
GO
/****** Object:  Table [dbo].[Autori]    Script Date: 20/12/2024 12:16:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autori](
	[IdAutor] [int] IDENTITY(1,1) NOT NULL,
	[NumeAutor] [nvarchar](100) NOT NULL,
	[PrenumeAutor] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carti]    Script Date: 20/12/2024 12:16:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carti](
	[IdCarte] [int] IDENTITY(1,1) NOT NULL,
	[Titlu] [nvarchar](200) NOT NULL,
	[IdCategorie] [int] NOT NULL,
	[IdAutor] [int] NOT NULL,
	[AnPublicare] [int] NULL,
	[NumarPagini] [int] NULL,
	[StocDisponibil] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCarte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorii]    Script Date: 20/12/2024 12:16:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorii](
	[IdCategorie] [int] IDENTITY(1,1) NOT NULL,
	[NumeCategorie] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategorie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactMessages]    Script Date: 20/12/2024 12:16:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactMessages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Subject] [nvarchar](50) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Imprumuturi]    Script Date: 20/12/2024 12:16:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Imprumuturi](
	[IdImprumut] [int] IDENTITY(1,1) NOT NULL,
	[IdCarte] [int] NULL,
	[IdUtilizator] [int] NOT NULL,
	[DataImprumut] [date] NOT NULL,
	[DataReturnare] [date] NULL,
	[Status] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdImprumut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilizatori]    Script Date: 20/12/2024 12:16:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilizatori](
	[IdUtilizator] [int] IDENTITY(1,1) NOT NULL,
	[NumeUtilizator] [nvarchar](100) NOT NULL,
	[PrenumeUtilizator] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Telefon] [nvarchar](15) NULL,
	[DataInregistrare] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUtilizator] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carti] ADD  DEFAULT ((0)) FOR [StocDisponibil]
GO
ALTER TABLE [dbo].[ContactMessages] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Imprumuturi] ADD  DEFAULT ('Imprumutat') FOR [Status]
GO
ALTER TABLE [dbo].[Utilizatori] ADD  DEFAULT (getdate()) FOR [DataInregistrare]
GO
ALTER TABLE [dbo].[Carti]  WITH CHECK ADD  CONSTRAINT [FK_Carti_Autori] FOREIGN KEY([IdAutor])
REFERENCES [dbo].[Autori] ([IdAutor])
GO
ALTER TABLE [dbo].[Carti] CHECK CONSTRAINT [FK_Carti_Autori]
GO
ALTER TABLE [dbo].[Carti]  WITH CHECK ADD  CONSTRAINT [FK_Carti_Categorii] FOREIGN KEY([IdCategorie])
REFERENCES [dbo].[Categorii] ([IdCategorie])
GO
ALTER TABLE [dbo].[Carti] CHECK CONSTRAINT [FK_Carti_Categorii]
GO
ALTER TABLE [dbo].[Imprumuturi]  WITH CHECK ADD  CONSTRAINT [FK_Imprumuturi_Carti] FOREIGN KEY([IdCarte])
REFERENCES [dbo].[Carti] ([IdCarte])
GO
ALTER TABLE [dbo].[Imprumuturi] CHECK CONSTRAINT [FK_Imprumuturi_Carti]
GO
ALTER TABLE [dbo].[Imprumuturi]  WITH CHECK ADD  CONSTRAINT [FK_Imprumuturi_Utilizatori] FOREIGN KEY([IdUtilizator])
REFERENCES [dbo].[Utilizatori] ([IdUtilizator])
GO
ALTER TABLE [dbo].[Imprumuturi] CHECK CONSTRAINT [FK_Imprumuturi_Utilizatori]
GO
