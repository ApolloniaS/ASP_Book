CREATE TABLE [dbo].[Publisher] (
    [idPublisher] INT           IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED ([idPublisher] ASC),
    CONSTRAINT [UK_name] UNIQUE NONCLUSTERED ([name] ASC)
);

