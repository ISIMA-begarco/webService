CREATE TABLE [dbo].[Matches] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [Jedi1]     INT NULL,
    [Jedi2]     INT NULL,
    [Stade]     INT NOT NULL,
    [Vainqueur] INT NULL,
    [Phase]     INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Jedi1]) REFERENCES [dbo].[Jedis] ([Id]),
    FOREIGN KEY ([Jedi2]) REFERENCES [dbo].[Jedis] ([Id]),
    FOREIGN KEY ([Stade]) REFERENCES [dbo].[Stades] ([Id])
);

