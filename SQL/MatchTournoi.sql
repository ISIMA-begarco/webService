CREATE TABLE MatchTournoi
(
	[IdMatch] INT NOT NULL,
	[IdTournoi] INT NOT NULL,
	CONSTRAINT PK_MatchTournoi PRIMARY KEY CLUSTERED (IdMatch,IdTournoi)
)
