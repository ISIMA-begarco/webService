CREATE TABLE [dbo].[Stades] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nom]      VARCHAR (32)  NOT NULL,
    [NbPlaces] INT           NOT NULL,
    [Image]    VARCHAR (128) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);