CREATE PROCEDURE [dbo].[SP_Check_Password]
    @Login VARCHAR (16),
    @MotDePasse NVARCHAR(MAX)
    
AS
    DECLARE @hMotDePasse NVARCHAR(MAX)
    DECLARE @salt CHAR(8)
    DECLARE @newMotDePasse NVARCHAR(MAX)
    SELECT @salt = salt, @hMotDePasse = [password] FROM [User] WHERE [login] = @login
    SELECT @newMotDePasse = dbo.SF_PassWordEncryption (@MotDePasse, @salt)
    IF (@newMotDePasse = @hMotDePasse)
    BEGIN 
    SELECT [Login], firstname, lastname, email, avatar, [password], isAdmin, birthdate
    FROM [User]
    END