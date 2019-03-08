CREATE TABLE [dbo].[Courses]
(
	[Id]               BIGINT IDENTITY (1, 1) NOT NULL,
	[Name]             NVARCHAR(256) NOT NULL,
	[Description]      NVARCHAR(MAX) NULL,
	[CreatedAtUtc]     DATETIME2 NOT NULL DEFAULT GETUTCDATE(),

	CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED ([Id] ASC)

)
