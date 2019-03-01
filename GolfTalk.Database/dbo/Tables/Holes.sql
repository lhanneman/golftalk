CREATE TABLE [dbo].[Holes]
(
	[Id]           BIGINT IDENTITY (1, 1) NOT NULL,
	[HoleNumber]   INT NOT NULL,
	[Par]          INT NOT NULL,
	[Yards]        INT NOT NULL,

	CONSTRAINT [PK_Holes] PRIMARY KEY CLUSTERED ([Id] ASC),
)
