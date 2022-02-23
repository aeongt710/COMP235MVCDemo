# COMP235MVCDemo
Query to create Movies Table:
CREATE TABLE [dbo].[Movies] (
    [Id]          INT        NOT NULL,
    [Title]       NCHAR (30) NULL,
    [Description] NCHAR (30) NULL,
    [Director]    NCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

