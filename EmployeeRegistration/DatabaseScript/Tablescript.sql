
USE [DbEmployee]
GO
/****** Object:  Table [dbo].[tblCountry]    Script Date: 28-10-2020 11.10.46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCountry](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](50) NULL,
 CONSTRAINT [PK_tblCountry] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[tblState]    Script Date: 28-10-2020 11.10.46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblState](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NOT NULL,
	[StateName] [varchar](max) NULL,
 CONSTRAINT [PK_tblState] PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


/****** Object:  Table [dbo].[tblEmployee]    Script Date: 28-10-2020 11.10.46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEmployee](
	[EmpolyeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[DOB] [smalldatetime] NULL,
	[Gender] [bit] NULL,
	[MarritalStatus] [bit] NULL,
	[CountryID] [int] NULL,
	[StateID] [int] NULL,
	[Address] [varchar](max) NULL,
	[Hobbies] [varchar](max) NULL,
 CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED 
(
	[EmpolyeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO


SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF_tblEmployee_Gender]  DEFAULT ((0)) FOR [Gender]
GO
ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF_tblEmployee_MarritalStatus]  DEFAULT ((0)) FOR [MarritalStatus]
GO
ALTER TABLE [dbo].[tblEmployee]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployee_tblCountry] FOREIGN KEY([CountryID])
REFERENCES [dbo].[tblCountry] ([CountryID])
GO
ALTER TABLE [dbo].[tblEmployee] CHECK CONSTRAINT [FK_tblEmployee_tblCountry]
GO
ALTER TABLE [dbo].[tblEmployee]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployee_tblState] FOREIGN KEY([StateID])
REFERENCES [dbo].[tblState] ([StateID])
GO
ALTER TABLE [dbo].[tblEmployee] CHECK CONSTRAINT [FK_tblEmployee_tblState]
GO
ALTER TABLE [dbo].[tblState]  WITH CHECK ADD  CONSTRAINT [FK_tblState_tblState] FOREIGN KEY([CountryID])
REFERENCES [dbo].[tblCountry] ([CountryID])
GO
ALTER TABLE [dbo].[tblState] CHECK CONSTRAINT [FK_tblState_tblState]
GO
