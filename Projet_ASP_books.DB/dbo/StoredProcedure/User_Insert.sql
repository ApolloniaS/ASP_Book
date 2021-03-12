CREATE PROCEDURE [dbo].[User_Insert]
	
	@firstname NVARCHAR(50),
    @lastname NVARCHAR(50),
    @email NVARCHAR(323),
    @avatar NVARCHAR(50) = NULL,
    @login NVARCHAR(50),
    @isAdmin BIT,
    @birthdate DATETIME2 = NULL,
    @password NVARCHAR(MAX)
AS
	DECLARE @idUser INT, @salt CHAR(8)
    SET @salt = [dbo].SF_GenerateSalt()
    
    INSERT INTO [User] ([firstname], [lastname], [email], [avatar], [login], [isAdmin], [birthdate], [salt], [password])
    --OUTPUT inserted.idUser
    VALUES (@firstname, @lastname, @email, @avatar, @login, @isAdmin, @birthdate, @salt, [dbo].SF_PassWordEncryption(@password, @salt)) 
    SET @idUser = @@IDENTITY


