CREATE TABLE [dbo].[Book] (
    [idBook]       INT            IDENTITY (1, 1) NOT NULL,
    [idAudience]   INT            NOT NULL,
    [picture]      VARCHAR (50)   NULL,
    [title]        NVARCHAR (100) NOT NULL,
    [summary]      NVARCHAR (MAX) NOT NULL,
    [firstRelease] DATE           NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([idBook] ASC),
    CONSTRAINT [FK_Book_Audience] FOREIGN KEY ([idAudience]) REFERENCES [dbo].[Audience] ([idAudience])
);







