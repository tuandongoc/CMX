USE [CWorks_SHB]
GO

/****** Object:  Table [dbo].[DebtorInformation]    Script Date: 4/30/2019 9:41:26 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DebtorInformation](
	[DebtorID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[DoingBusinessAs] [nvarchar](50) NULL,
	[GroupName] [nvarchar](50) NULL,
	[HotNote] [nvarchar](255) NULL,
	[ZipDelPoint] [char](3) NULL,
	[ZipCart] [char](4) NULL,
	[ReturnedMail] [bit] NOT NULL,
	[HoldLetters] [bit] NOT NULL,
	[HoldHomeCalls] [bit] NOT NULL,
	[HoldWorkCalls] [bit] NOT NULL,
	[PullCreditReport] [bit] NOT NULL,
	[SendReminderLetters] [bit] NOT NULL,
	[DateOfLastCreditReportPull] [nvarchar](16) NULL,
	[CreditReportFileName] [nvarchar](16) NULL,
	[LastEditDate] [smalldatetime] NULL,
	[LastEditBy] [int] NULL,
	[LockedByID] [int] NULL,
	[LockedBy] [nvarchar](50) NULL,
	[LockedDate] [datetime] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


