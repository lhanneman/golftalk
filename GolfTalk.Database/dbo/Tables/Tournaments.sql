﻿CREATE TABLE [dbo].[Tournaments]
(
	[Id]              BIGINT IDENTITY (1, 1) NOT NULL,
	[Name]            NVARCHAR(256) NOT NULL,
	[StartDateUtc]    DATETIME2 NOT NULL,
	[EndDateUtc]	  DATETIME2 NOT NULL,
	[CreatedAtUtc]    DATETIME2 NOT NULL DEFAULT GETUTCDATE(),

	CONSTRAINT [PK_Tournaments] PRIMARY KEY CLUSTERED ([Id] ASC)
)