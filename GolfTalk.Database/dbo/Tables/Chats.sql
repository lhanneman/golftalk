CREATE TABLE [dbo].[Chats]
(
	[Id]              BIGINT IDENTITY (1, 1) NOT NULL,
	[SentByUserId]    NVARCHAR(128) NOT NULL,
	[TournamentId]    BIGINT NOT NULL,
	[Message]         NVARCHAR(MAX) NULL,
	[CreatedAtUtc]    DATETIME2 NOT NULL DEFAULT GETUTCDATE(),

	CONSTRAINT [PK_Chats] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Chats_TournamentId] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournaments] ([Id]),
	CONSTRAINT [FK_Chats_SentByUserId] FOREIGN KEY ([SentByUserId]) REFERENCES [dbo].[Users] ([Id]),
)
