CREATE TABLE [dbo].[Teams]
(
	[Id]               BIGINT IDENTITY (1, 1) NOT NULL,
	[TournamentId]     BIGINT NOT NULL,
	[Name]             NVARCHAR(256) NOT NULL,
	[CreatedAtUtc]     DATETIME2 NOT NULL DEFAULT GETUTCDATE(),

	CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Teams_TournamentId] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournaments] ([Id]),
)
