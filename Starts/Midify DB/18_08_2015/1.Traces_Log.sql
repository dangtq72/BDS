USE [Starts]
GO

/****** Object:  Table [dbo].[Traces_Log]    Script Date: 19/08/2015 5:25:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Traces_Log](
	[TRACE_ID] [int] IDENTITY(1,1) NOT NULL,
	[TRACE_OBJECT] [nvarchar](100) NULL,
	[TRACE_PROCEDURE] [nvarchar](100) NULL,
	[TRACE_VALUE] [nvarchar](max) NULL,
	[TRACE_USER] [nvarchar](50) NULL,
	[TRACE_DATETIME] [date] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


