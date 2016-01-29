CREATE TABLE [dbo].[Caracteristiques] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Nom]    VARCHAR (32) NULL,
    [Def]    VARCHAR (32) NULL,
    [Type]   VARCHAR (32) NULL,
    [Valeur] INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


