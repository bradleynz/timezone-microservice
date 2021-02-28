USE [master]
GO
DROP DATABASE IF EXISTS [TimezoneDb]
GO
CREATE DATABASE [TimezoneDb]
GO
USE [TimezoneDb]
GO
IF OBJECT_ID('dbo.TimeZoneData', 'U') IS NOT NULL 
  DROP TABLE dbo.TimeZoneData;

CREATE TABLE [dbo].[TimeZoneData](
	[RequestId] [uniqueidentifier] NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[Request] [nvarchar](max) NOT NULL,
	[Response] [nvarchar](max) NOT NULL,
	[Timestamp] [bigint] NOT NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
 CONSTRAINT [PK_TimeZoneData] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
