CREATE PROCEDURE [dbo].[User_Insert]
	
	@firstname NVARCHAR(50),
    @lastname NVARCHAR(50),
    @email NVARCHAR(323),
    @avatar NVARCHAR(50) = NULL,
    @login NVARCHAR(50),
    @password NVARCHAR(50),
    @isAdmin BIT,
    @birthdate DATETIME2,
    @salt CHAR(8) 
AS
	SET @salt = [dbo].SF_GenerateSalt()
    
    INSERT INTO [User] ([firstname], [lastname], [email], [avatar], [login], [password], [isAdmin], [birthdate], [salt])
    OUTPUT inserted.idUser
    VALUES (@firstname, @lastname, @email, @avatar, @login, @password, @isAdmin, @birthdate,[dbo].SF_PassWordEncryption(@password, @salt)) 

