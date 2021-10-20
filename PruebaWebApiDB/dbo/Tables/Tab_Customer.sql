CREATE TABLE [dbo].[Tab_Customer] (
    [Id]    INT          IDENTITY (1, 1) NOT NULL,
    [Name]  VARCHAR (50) NULL,
    [Phone] VARCHAR (50) NULL,
    [Email] VARCHAR (50) NULL,
    [Notes] VARCHAR (50) NULL,
    CONSTRAINT [PK_Tab_Customer] PRIMARY KEY CLUSTERED ([Id] ASC)
);



