CREATE TABLE [dbo].[Author] (
    [idAuthor]  INT           IDENTITY (1, 1) NOT NULL,
    [firstname] NVARCHAR (50) NOT NULL,
    [lastname]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED ([idAuthor] ASC),
    CONSTRAINT [UK_firstname_lastname] UNIQUE NONCLUSTERED ([firstname] ASC, [lastname] ASC)
);

