CREATE TABLE [dbo].[BookAuthor] (
    [idAuthor] INT NOT NULL,
    [idBook]   INT NOT NULL,
    CONSTRAINT [PK_BookAuthor] PRIMARY KEY NONCLUSTERED ([idAuthor] ASC, [idBook] ASC),
    CONSTRAINT [FK_BookAuthor_Author] FOREIGN KEY ([idAuthor]) REFERENCES [dbo].[Author] ([idAuthor]),
    CONSTRAINT [FK_BookAuthor_Book] FOREIGN KEY ([idBook]) REFERENCES [dbo].[Book] ([idBook]),
    CONSTRAINT [UK_Author_Book] UNIQUE NONCLUSTERED ([idAuthor] ASC, [idBook] ASC)
);

