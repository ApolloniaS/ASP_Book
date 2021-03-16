CREATE PROCEDURE [dbo].[SP_CHECKPASSWORD]
	@login NVARCHAR(50),
	@password NVARCHAR(MAX)
AS
	DECLARE @hMotDePasse NVARCHAR(MAX)
    DECLARE @salt CHAR(8)
    DECLARE @newMotDePasse NVARCHAR(MAX)
	SELECT @salt = salt, @hMotDePasse = [password] FROM [dbo].[User] WHERE [login] = @login
	SELECT @newMotDePasse = [dbo].SF_PassWordEncryption(@password, @salt)
	IF(@newMotDePasse = @hMotDePasse)
	BEGIN
	SELECT *
	FROM [User]
	WHERE [login] = @login and [password] = @newMotDePasse
END
