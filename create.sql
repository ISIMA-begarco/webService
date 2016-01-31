CREATE TABLE [dbo].[Caracteristiques] (
    [Id]     INT          NOT NULL,
    [Nom]    VARCHAR (32) NULL,
    [Def]    VARCHAR (32) NULL,
    [Type]   VARCHAR (32) NULL,
    [Valeur] INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)

CREATE TABLE [dbo].[Jedis] (
    [Id]     INT           NOT NULL,
    [Nom]    VARCHAR (32)  NOT NULL,
    [IsSith] BIT           NOT NULL,
    [Image]  VARCHAR (128) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)

CREATE TABLE [dbo].[Stades] (
    [Id]       INT           NOT NULL,
    [Nom]      VARCHAR (32)  NOT NULL,
    [NbPlaces] INT           NOT NULL,
    [Image]    VARCHAR (128) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Matches] (
    [Id]        INT NOT NULL,
    [Jedi1]     INT NULL,
    [Jedi2]     INT NULL,
    [Stade]     INT NOT NULL,
    [Vainqueur] INT NULL,
    [Phase]     INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Tournois] (
    [Id]  INT          NOT NULL,
    [Nom] VARCHAR (32) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Users] (
    [Id]       INT          NOT NULL,
    [Login]    VARCHAR (32) NULL,
    [Password] VARCHAR (555) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[JediCarac]
(
	[IdJedi] INT NOT NULL,
	[IdCarac] INT NOT NULL,
	CONSTRAINT PK_JediCarac PRIMARY KEY CLUSTERED (IdJedi,IdCarac)
)

CREATE TABLE [dbo].[StadeCarac]
(
	[IdStade] INT NOT NULL,
	[IdCarac] INT NOT NULL,
	CONSTRAINT PK_StadeCarac PRIMARY KEY CLUSTERED (IdStade,IdCarac)
)

CREATE TABLE [dbo].[MatchTournoi]
(
	[IdMatch] INT NOT NULL,
	[IdTournoi] INT NOT NULL,
	CONSTRAINT PK_MatchTournoi PRIMARY KEY CLUSTERED (IdMatch,IdTournoi)
)
