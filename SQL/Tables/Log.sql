USE [GeekDB]
GO

/****** Object: Table [dbo].[Log] Script Date: 25-May-18 14:22:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Log] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Application] NVARCHAR (50)  NOT NULL,
    [Logged]      DATETIME       NOT NULL,
    [Level]       NVARCHAR (50)  NOT NULL,
    [Message]     NVARCHAR (MAX) NOT NULL,
    [Logger]      NVARCHAR (250) NULL,
    [Callsite]    NVARCHAR (MAX) NULL,
    [Exception]   NVARCHAR (MAX) NULL
);


