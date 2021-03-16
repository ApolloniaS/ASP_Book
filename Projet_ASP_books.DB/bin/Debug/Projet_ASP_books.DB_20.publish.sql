﻿/*
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
PRINT N'Création de [dbo].[SP_CHECKPASSWORD]...';


GO
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
GO
PRINT N'Mise à jour terminée.';


GO
