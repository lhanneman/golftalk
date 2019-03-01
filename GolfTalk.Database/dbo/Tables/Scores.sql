CREATE TABLE [dbo].[Scores]
(
	[Id]        BIGINT IDENTITY (1, 1) NOT NULL,
	[TeamId]    BIGINT NOT NULL,
	[HoleId]    BIGINT NOT NULL,
	[Strokes]   INT NOT NULL,

	CONSTRAINT [PK_Scores] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Scores_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([Id]),
	CONSTRAINT [FK_Scores_HoleId] FOREIGN KEY ([HoleId]) REFERENCES [dbo].[Holes] ([Id]),
)
