CREATE TABLE [dbo].[Holes]
(
	[Id]           BIGINT IDENTITY (1, 1) NOT NULL,
	[CourseId]     BIGINT NOT NULL,
	[HoleNumber]   INT NOT NULL,
	[Par]          INT NOT NULL,
	[Yards]        INT NOT NULL,
	[Handicap]     INT NULL,

	CONSTRAINT [PK_Holes] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Holes_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Courses] ([Id]),
)
