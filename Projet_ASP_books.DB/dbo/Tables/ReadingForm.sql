CREATE TABLE [dbo].[ReadingForm] (
    [idReadingForm] INT            IDENTITY (1, 1) NOT NULL,
    [idUser]        INT            NOT NULL,
    [question]      NVARCHAR (MAX) NOT NULL,
    [answer]        NVARCHAR (300) NULL,
    CONSTRAINT [PK_ReadingForm] PRIMARY KEY CLUSTERED ([idReadingForm] ASC),
    CONSTRAINT [FK_ReadingForm_User] FOREIGN KEY ([idUser]) REFERENCES [dbo].[User] ([idUser])
);



