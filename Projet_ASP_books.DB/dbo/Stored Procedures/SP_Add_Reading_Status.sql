CREATE PROCEDURE [dbo].[SP_Add_Reading_Status]
	
	@idBook INT,
	@idUser INT
	
AS
SELECT [idUserBook]
      ,[idUser]
      ,[idBook]
      ,CASE WHEN dbo.UserBook.readingStatus = 0 THEN 'À lire' WHEN dbo.UserBook.readingStatus = 1 THEN 'Lu' ELSE 'En cours de lecture' END AS readingStatus
    FROM [dbo].[UserBook]
	WHERE dbo.UserBook.idBook = @idBook AND dbo.UserBook.idUser = @idUser