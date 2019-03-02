CREATE TABLE [dbo].[TeamUsers]
(
	[Id]        BIGINT IDENTITY (1, 1) NOT NULL,
	[TeamId]    BIGINT NOT NULL,
	[UserId]	NVARCHAR(128) NOT NULL,

	CONSTRAINT [PK_TeamUsers] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_TeamUsers_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([Id]),
	CONSTRAINT [FK_TeamUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
)
