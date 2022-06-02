/*
ВАЖНО!!! 
Строго соблюдать создания очередности таблиц база SVDDOG
1-Coats;
2-Drugs;
3-Organizations;
4-Dogs;
5-DogKaroos;
6-DogDaarys;
7-Persons.
*/
USE [SVDDOG] 
GO
--1
/****** Object:  Table [dbo].[Coats]    Script Date: Вт 31.05.22 14:36:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Coats](
	[Id] [int] NOT NULL,
	[Parent] [int] NOT NULL,
	[CoatoNum] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_COATO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
--2
/****** Object:  Table [dbo].[Drugs]    Script Date: Вт 31.05.22 14:40:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Drugs](
	[Id] [int] NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[SerialNumber] [varchar](30) NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Drugs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
--3
/****** Object:  Table [dbo].[Organizations]    Script Date: Вт 31.05.22 14:42:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Organizations](
	[id] [int] NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_ORG] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
--4
/****** Object:  Table [dbo].[Dogs]    Script Date: Вт 31.05.22 14:44:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dogs](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[CoatoId] [int] NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[TagNumber] [nvarchar](20) NOT NULL,
	[CreatedDate] [smalldatetime] NOT NULL,
	[Owner] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NOT NULL,
	[DogName] [nvarchar](20) NOT NULL,
	[Colour] [nvarchar](20) NULL,
	[Gender] [int] NULL,
	[BirthYear] [int] NULL,
	[Breed] [nvarchar](20) NULL,
	[Description] [nvarchar](300) NULL,
	[IsAlive] [int] NULL,
 CONSTRAINT [PK_DOG] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Dogs]  WITH CHECK ADD  CONSTRAINT [FK_Dogs_Coats_CoatoId] FOREIGN KEY([CoatoId])
REFERENCES [dbo].[Coats] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Dogs] CHECK CONSTRAINT [FK_Dogs_Coats_CoatoId]
GO

ALTER TABLE [dbo].[Dogs]  WITH CHECK ADD  CONSTRAINT [FK_DOG_ORG] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organizations] ([id])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[Dogs] CHECK CONSTRAINT [FK_DOG_ORG]
GO
--5
/****** Object:  Table [dbo].[Person]    Script Date: Чт 02.06.22 8:59:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Person](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[CoatoId] [int] NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Gender] [int] NOT NULL,
	[BirthDay] [smalldatetime] NULL,
	[Phone] [nvarchar](100) NULL,
	[PassportNumber] [nvarchar](50) NULL,
	[DateOfIssue] [smalldatetime] NULL,
	[IssuingOrg] [nvarchar](50) NULL,
	[TagNumber] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[University] [nvarchar](200) NULL,
	[Specialization] [nvarchar](150) NULL,
 CONSTRAINT [PK_PERSON] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
--6
/****** Object:  Table [dbo].[DogKaroos]    Script Date: Чт 02.06.22 9:13:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DogKaroos](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[DogId] [uniqueidentifier] NOT NULL,
	[PersonId] [uniqueidentifier] NOT NULL,
	[Date] [smalldatetime] NOT NULL,
	[Disease] [int] NOT NULL,
	[Weight] [int] NOT NULL,
	[QuantityDrug] [int] NOT NULL,
	[Description] [nvarchar](300) NULL,
	[DrugId] [int] NULL,
 CONSTRAINT [PK_DOGKAROO] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DogKaroos]  WITH CHECK ADD  CONSTRAINT [FK_DOGKAROO_DOG] FOREIGN KEY([DogId])
REFERENCES [dbo].[Dogs] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DogKaroos] CHECK CONSTRAINT [FK_DOGKAROO_DOG]
GO

ALTER TABLE [dbo].[DogKaroos]  WITH CHECK ADD  CONSTRAINT [FK_DogKaroo_Drugs] FOREIGN KEY([DrugId])
REFERENCES [dbo].[Drugs] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DogKaroos] CHECK CONSTRAINT [FK_DogKaroo_Drugs]
GO

ALTER TABLE [dbo].[DogKaroos]  WITH CHECK ADD  CONSTRAINT [FK_DOGKAROO_PERSON] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([id])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[DogKaroos] CHECK CONSTRAINT [FK_DOGKAROO_PERSON]
GO

--7
/****** Object:  Table [dbo].[DogDaarys]    Script Date: Чт 02.06.22 9:15:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DogDaarys](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[DogId] [uniqueidentifier] NOT NULL,
	[PersonId] [uniqueidentifier] NOT NULL,
	[Date] [smalldatetime] NOT NULL,
	[Disease] [int] NOT NULL,
	[Dose] [float] NOT NULL,
	[Description] [nvarchar](300) NULL,
	[DrugId] [int] NULL,
 CONSTRAINT [PK_DOGDAARY] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DogDaarys]  WITH CHECK ADD  CONSTRAINT [FK_DOGDAARY_DOG_dor] FOREIGN KEY([DrugId])
REFERENCES [dbo].[Drugs] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DogDaarys] CHECK CONSTRAINT [FK_DOGDAARY_DOG_dor]
GO

ALTER TABLE [dbo].[DogDaarys]  WITH CHECK ADD  CONSTRAINT [FK_DOGDAARY_PERSON] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([id])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[DogDaarys] CHECK CONSTRAINT [FK_DOGDAARY_PERSON]
GO