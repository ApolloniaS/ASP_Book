
CREATE PROCEDURE [dbo].[SP_Show_Current_Books_Status]
	
	@idBook INT,
	@idUser INT
	
AS

SELECT TOP(1)   dbo.UserBook.idBook, dbo.UserBook.idUser, dbo.Book.title, dbo.[User].login, dbo.UserBook.idUserBook,
                         CASE WHEN dbo.UserBook.readingStatus = 0 THEN 'À lire' WHEN dbo.UserBook.readingStatus = 1 THEN 'Lu' ELSE 'En cours de lecture' END AS readingStatus
FROM            dbo.UserBook INNER JOIN
                         dbo.Book ON dbo.UserBook.idBook = dbo.Book.idBook INNER JOIN
                         dbo.[User] ON dbo.UserBook.idUser = dbo.[User].idUser
WHERE dbo.UserBook.idBook = @idBook AND dbo.UserBook.idUser = @idUser
ORDER BY dbo.UserBook.idUserBook DESC