CREATE TABLE [dbo].[PublisherBook] (
    [idPublisherBook] INT            IDENTITY (1, 1) NOT NULL,
    [idPublisher]     INT            NOT NULL,
    [idBook]          INT            NOT NULL,
    [publicationDate] DATETIME2 (7)  NOT NULL,
    [isbn]            CHAR (13)      NOT NULL,
    [price]           MONEY          NOT NULL,
    [linkBuy]         NVARCHAR (255) NULL,
    CONSTRAINT [PK_PublisherBook] PRIMARY KEY CLUSTERED ([idPublisherBook] ASC),
    CONSTRAINT [CK_price] CHECK ([price]>=(0)),
    CONSTRAINT [FK_PublisherBook_Book] FOREIGN KEY ([idBook]) REFERENCES [dbo].[Book] ([idBook]),
    CONSTRAINT [FK_PublisherBook_Publisher] FOREIGN KEY ([idPublisher]) REFERENCES [dbo].[Publisher] ([idPublisher]),
    CONSTRAINT [UK_isbn] UNIQUE NONCLUSTERED ([isbn] ASC),
    CONSTRAINT [UK_Publisher_Book] UNIQUE NONCLUSTERED ([idPublisher] ASC, [idBook] ASC)
);



