CREATE TABLE [dbo].[Chats]
(
	[Id]        BIGINT IDENTITY (1, 1) NOT NULL,
	[TeamId]    BIGINT NOT NULL,
	[Message]   NVARCHAR(MAX) NULL,

	CONSTRAINT [PK_Chats] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Chats_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([Id]),
)
