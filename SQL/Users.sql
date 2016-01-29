CREATE TABLE [dbo].[Users] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Login]    VARCHAR (32) NULL,
    [Password] VARCHAR (32) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

