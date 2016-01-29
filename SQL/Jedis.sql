CREATE TABLE [dbo].[Jedis] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Nom]    VARCHAR (32)  NOT NULL,
    [IsSith] BIT           NOT NULL,
    [Image]  VARCHAR (128) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

