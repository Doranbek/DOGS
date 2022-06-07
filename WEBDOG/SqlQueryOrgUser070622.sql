USE SVDDOG 
GO

/****** Object:  Table [dbo].[OrgUser]    Script Date: Вт 07.06.22 10:47:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrgUser](
	[OrgId] [int] NULL,
	[UserId] [nvarchar](450) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OrgUser]  WITH CHECK ADD  CONSTRAINT [FK_OrgUser_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[OrgUser] CHECK CONSTRAINT [FK_OrgUser_AspNetUsers]
GO

ALTER TABLE [dbo].[OrgUser]  WITH CHECK ADD  CONSTRAINT [FK_OrgUser_Organizations] FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organizations] ([id])
GO

ALTER TABLE [dbo].[OrgUser] CHECK CONSTRAINT [FK_OrgUser_Organizations]
GO
