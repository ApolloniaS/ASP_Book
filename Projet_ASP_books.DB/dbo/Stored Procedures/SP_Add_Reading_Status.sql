CREATE PROCEDURE [dbo].[SP_Add_Reading_Status]
	
	@idBook INT,
	@idUser INT,
	@readingstatus BIT
	
AS
DECLARE @doExist BIT
IF EXISTS( 
	SELECT [idUserBook]
      ,[idUser]
      ,[idBook]
      ,[readingStatus]
    FROM [dbo].[UserBook]
	WHERE dbo.UserBook.idBook = @idBook AND dbo.UserBook.idUser = @idUser
)

	SET @doExist = 1

ELSE

	SET @doExist = 0

RETURN @doExist