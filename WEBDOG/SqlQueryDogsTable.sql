/*

ВАЖНО!!! 
ПЕРЕИМЕНОВАТЬ тестовубю базу TEST2 на нужную базу
Строго соблюдать создания очередности таблиц база DOGS
1-Coats;
2-Drugs;
3-Organizations;
4-Dogs;
5-DogKaroos;
6-DogDaarys;
7-Persons.
*/

USE [TEST2]
GO

/****** Object:  1-Table [dbo].[Coats]    Script Date: Вт 31.05.22 14:36:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Coats](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Parent] [int] NOT NULL,
	[CoatoNum] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Coats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


USE [TEST2]
GO

/****** Object:  2-Table [dbo].[Drugs]    Script Date: Вт 31.05.22 14:40:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Drugs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[SerialNumber] [nvarchar](max) NULL,
	[ExpirationDate] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Drugs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [TEST2]
GO

/****** Object:  3-Table [dbo].[Organizations]    Script Date: Вт 31.05.22 14:42:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Organizations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


USE [TEST2]
GO

/****** Object:  4-Table [dbo].[Dogs]    Script Date: Вт 31.05.22 14:44:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dogs](
	[id] [uniqueidentifier] NOT NULL,
	[CoatoId] [int] NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[TagNumber] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[Owner] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[DogName] [nvarchar](max) NULL,
	[Colour] [nvarchar](max) NULL,
	[Gender] [int] NOT NULL,
	[BirthYear] [int] NOT NULL,
	[Breed] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsAlive] [int] NOT NULL,
 CONSTRAINT [PK_Dogs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Dogs]  WITH CHECK ADD  CONSTRAINT [FK_Dogs_Coats_CoatoId] FOREIGN KEY([CoatoId])
REFERENCES [dbo].[Coats] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Dogs] CHECK CONSTRAINT [FK_Dogs_Coats_CoatoId]
GO

ALTER TABLE [dbo].[Dogs]  WITH CHECK ADD  CONSTRAINT [FK_Dogs_Organizations_OrganizationId] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organizations] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Dogs] CHECK CONSTRAINT [FK_Dogs_Organizations_OrganizationId]
GO


USE [TEST2]
GO

/****** Object:  5-Table [dbo].[DogKaroos]    Script Date: Вт 31.05.22 14:47:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DogKaroos](
	[Id] [uniqueidentifier] NOT NULL,
	[DogId] [uniqueidentifier] NOT NULL,
	[PersonId] [uniqueidentifier] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Disease] [int] NOT NULL,
	[Weight] [int] NOT NULL,
	[DrugId] [int] NOT NULL,
	[QuantityDrug] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_DogKaroos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[DogKaroos]  WITH CHECK ADD  CONSTRAINT [FK_DogKaroos_Dogs_DogId] FOREIGN KEY([DogId])
REFERENCES [dbo].[Dogs] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DogKaroos] CHECK CONSTRAINT [FK_DogKaroos_Dogs_DogId]
GO

ALTER TABLE [dbo].[DogKaroos]  WITH CHECK ADD  CONSTRAINT [FK_DogKaroos_Drugs_DrugId] FOREIGN KEY([DrugId])
REFERENCES [dbo].[Drugs] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DogKaroos] CHECK CONSTRAINT [FK_DogKaroos_Drugs_DrugId]
GO


USE [TEST2]
GO

/****** Object:  6-Table [dbo].[DogDaarys]    Script Date: Вт 31.05.22 14:48:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DogDaarys](
	[Id] [uniqueidentifier] NOT NULL,
	[DogId] [uniqueidentifier] NOT NULL,
	[PersonId] [uniqueidentifier] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Disease] [int] NOT NULL,
	[Dose] [int] NOT NULL,
	[DrugId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_DogDaarys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[DogDaarys]  WITH CHECK ADD  CONSTRAINT [FK_DogDaarys_Dogs_DogId] FOREIGN KEY([DogId])
REFERENCES [dbo].[Dogs] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DogDaarys] CHECK CONSTRAINT [FK_DogDaarys_Dogs_DogId]
GO

ALTER TABLE [dbo].[DogDaarys]  WITH CHECK ADD  CONSTRAINT [FK_DogDaarys_Drugs_DrugId] FOREIGN KEY([DrugId])
REFERENCES [dbo].[Drugs] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DogDaarys] CHECK CONSTRAINT [FK_DogDaarys_Drugs_DrugId]
GO


USE [TEST2]
GO

/****** Object:  7-Table [dbo].[Persons]    Script Date: Вт 31.05.22 14:52:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Persons](
	[Id] [uniqueidentifier] NOT NULL,
	[CoatoId] [int] NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[BrithDay] [datetime2](7) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[PassportNumber] [nvarchar](max) NULL,
	[DateOfIssue] [datetime2](7) NOT NULL,
	[IssuingOrg] [nvarchar](max) NULL,
	[TagNumber] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[University] [nvarchar](max) NULL,
	[Specialization] [nvarchar](max) NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Coats_CoatoId] FOREIGN KEY([CoatoId])
REFERENCES [dbo].[Coats] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Coats_CoatoId]
GO


