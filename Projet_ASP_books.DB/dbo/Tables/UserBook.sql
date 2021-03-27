CREATE TABLE [dbo].[UserBook] (
    [idUserBook]    INT IDENTITY (1, 1) NOT NULL,
    [idUser]        INT NOT NULL,
    [idBook]        INT NOT NULL,
    [readingStatus] BIT NULL,
    CONSTRAINT [PK_UserBook] PRIMARY KEY CLUSTERED ([idUserBook] ASC),
    CONSTRAINT [FK_UserBook_Book] FOREIGN KEY ([idBook]) REFERENCES [dbo].[Book] ([idBook]),
    CONSTRAINT [FK_UserBook_User] FOREIGN KEY ([idUser]) REFERENCES [dbo].[User] ([idUser]),
    CONSTRAINT [UC_ReadingStatus] UNIQUE NONCLUSTERED ([idUser] ASC, [idBook] ASC, [readingStatus] ASC)
);



