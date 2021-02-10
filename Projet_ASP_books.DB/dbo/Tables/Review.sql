CREATE TABLE [dbo].[Review] (
    [idReview]      INT            IDENTITY (1, 1) NOT NULL,
    [idUser]        INT            NOT NULL,
    [idBook]        INT            NOT NULL,
    [reviewDate]    DATETIME2 (7)  CONSTRAINT [DF_Review_reviewDate] DEFAULT (getdate()) NOT NULL,
    [reviewContent] NVARCHAR (MAX) NOT NULL,
    [reviewScore]   FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED ([idReview] ASC),
    CONSTRAINT [CK_reviewContent] CHECK (len(replace([reviewContent],' ',''))>(0)),
    CONSTRAINT [CK_reviewScore] CHECK ([reviewScore]>=(0)),
    CONSTRAINT [FK_Review_Book] FOREIGN KEY ([idBook]) REFERENCES [dbo].[Book] ([idBook]),
    CONSTRAINT [FK_Review_User] FOREIGN KEY ([idUser]) REFERENCES [dbo].[User] ([idUser])
);

