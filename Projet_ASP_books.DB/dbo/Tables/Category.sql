CREATE TABLE [dbo].[Category] (
    [idCategory]   INT           IDENTITY (1, 1) NOT NULL,
    [categoryName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([idCategory] ASC)
);

