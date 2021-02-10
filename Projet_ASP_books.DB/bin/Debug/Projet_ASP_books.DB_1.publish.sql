/*
Script de déploiement pour Projet_ASP_books

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Projet_ASP_books"
:setvar DefaultFilePrefix "Projet_ASP_books"
:setvar DefaultDataPath "C:\Users\sorel\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\sorel\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
La colonne [dbo].[User].[otherInfo] est en cours de suppression, des données risquent d'être perdues.

La colonne [dbo].[User].[userName] est en cours de suppression, des données risquent d'être perdues.

La colonne [dbo].[User].[salt] de la table [dbo].[User] doit être ajoutée mais la colonne ne comporte pas de valeur par défaut et n'autorise pas les valeurs NULL. Si la table contient des données, le script ALTER ne fonctionnera pas. Pour éviter ce problème, vous devez ajouter une valeur par défaut à la colonne, la marquer comme autorisant les valeurs Null ou activer la génération de smart-defaults en tant qu'option de déploiement.
*/

IF EXISTS (select top 1 1 from [dbo].[User])
    RAISERROR (N'Lignes détectées. Arrêt de la mise à jour du schéma en raison d''''un risque de perte de données.', 16, 127) WITH NOWAIT

GO
PRINT N'Modification de [dbo].[User]...';


GO
ALTER TABLE [dbo].[User] DROP COLUMN [otherInfo], COLUMN [userName];


GO
ALTER TABLE [dbo].[User]
    ADD [salt] CHAR (8) NOT NULL;


GO
PRINT N'Création de [dbo].[SF_GenerateSalt]...';


GO
CREATE FUNCTION [dbo].[SF_GenerateSalt]
()
RETURNS CHAR(8)
AS
BEGIN
	DECLARE @generatedSalt NVARCHAR(8)
	DECLARE @rand SMALLINT
	DECLARE @i SMALLINT
	SET @i = 0;
	WHILE @i < 8
	BEGIN
		SET @rand = FLOOR(RAND()*10)
		SET @generatedSalt = CONCAT(@generatedSalt, @rand)
		SET @i = @i + 1;
	END

	RETURN @generatedSalt
END
GO
PRINT N'Création de [dbo].[SF_PassWordEncryption]...';


GO
CREATE FUNCTION [dbo].[SF_PassWordEncryption]
(
	@password NVARCHAR(32),
	@salt CHAR(8)
)
RETURNS VARBINARY(32)
AS
BEGIN
	RETURN HASHBYTES('SHA2_256', CONCAT(SUBSTRING(@salt,0,4), @password, SUBSTRING(@salt, 4,4)))
END
GO
PRINT N'Création de [dbo].[User_Insert]...';


GO
CREATE PROCEDURE [dbo].[User_Insert]
	@idUser INT,
	@firstname NVARCHAR(50),
    @lastname NVARCHAR(50),
    @email NVARCHAR(323),
    @avatar VARBINARY (MAX) = NULL,
    @login NVARCHAR(50),
    @password NVARCHAR(50),
    @isAdmin BIT,
    @birthdate DATETIME2,
    @salt CHAR(8) 
AS
	SET @salt = [dbo].SF_GenerateSalt()
    SET @idUser = @@IDENTITY
    INSERT INTO [User] ([idUser], [firstname], [lastname], [email], [avatar], [login], [password], [isAdmin], [birthdate], [salt])
    OUTPUT inserted.idUser
    VALUES (@idUser, @firstname, @lastname, @email, @avatar, @login, @password, @isAdmin, @birthdate,[dbo].SF_PassWordEncryption(@password, @salt))
GO
PRINT N'Mise à jour terminée.';


GO
