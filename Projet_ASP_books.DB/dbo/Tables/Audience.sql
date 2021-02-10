CREATE TABLE [dbo].[Audience] (
    [idAudience]    INT           IDENTITY (1, 1) NOT NULL,
    [audienceGroup] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Audience] PRIMARY KEY CLUSTERED ([idAudience] ASC)
);

