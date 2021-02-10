CREATE TABLE [dbo].[BookCategory] (
    [idBook]     INT NOT NULL,
    [idCategory] INT NOT NULL,
    CONSTRAINT [PK_BookCategory] PRIMARY KEY CLUSTERED ([idBook] ASC, [idCategory] ASC),
    CONSTRAINT [FK_BookCategory_Book] FOREIGN KEY ([idBook]) REFERENCES [dbo].[Book] ([idBook]),
    CONSTRAINT [FK_BookCategory_Category] FOREIGN KEY ([idCategory]) REFERENCES [dbo].[Category] ([idCategory])
);

