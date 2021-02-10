﻿CREATE TABLE [dbo].[User] (
    [idUser]    INT             IDENTITY (1, 1) NOT NULL,
    [firstname] NVARCHAR (50)   NOT NULL,
    [lastname]  NVARCHAR (50)   NOT NULL,
    [email]     NVARCHAR (323)  NOT NULL,
    [avatar]    VARBINARY (MAX) NULL,
    [login]     NVARCHAR (50)   NOT NULL,
    [password]  NVARCHAR (50)   NOT NULL,
    [isAdmin]   BIT             NOT NULL,
    [birthdate] DATETIME2 (7)   NOT NULL,
    [salt] CHAR(8) NOT NULL, 
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([idUser] ASC),
    CONSTRAINT [CK_user_birthdate] CHECK (datediff(year,[birthdate],getdate())>(13) AND datediff(year,[birthdate],getdate())<(100)),
    CONSTRAINT [CK_User_Email] CHECK ([Email] like '___%@___%.__%'),
    CONSTRAINT [UK_User_Email] UNIQUE NONCLUSTERED ([email] ASC),
    CONSTRAINT [UK_User_Login] UNIQUE NONCLUSTERED ([login] ASC)
);

