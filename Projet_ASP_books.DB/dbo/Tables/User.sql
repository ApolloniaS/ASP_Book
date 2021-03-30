CREATE TABLE [dbo].[User] (
    [idUser]    INT            IDENTITY (1, 1) NOT NULL,
    [firstname] NVARCHAR (50)  NOT NULL,
    [lastname]  NVARCHAR (50)  NOT NULL,
    [email]     NVARCHAR (323) NOT NULL,
    [avatar]    NVARCHAR (50)  NULL,
    [login]     NVARCHAR (50)  NOT NULL,
    [password]  NVARCHAR (MAX) NOT NULL,
    [isAdmin]   BIT            CONSTRAINT [DF__User__isAdmin__19AACF41] DEFAULT ((0)) NOT NULL,
    [birthdate] DATETIME2 (7)  NULL,
    [salt]      CHAR (8)       NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([idUser] ASC),
    CONSTRAINT [CK_user_birthdate] CHECK (datediff(year,[birthdate],getdate())>(13) AND datediff(year,[birthDate],getdate())<(100)),
    CONSTRAINT [UK_User_Email] UNIQUE NONCLUSTERED ([email] ASC),
    CONSTRAINT [UK_User_Login] UNIQUE NONCLUSTERED ([login] ASC)
);









