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
La colonne birthdate de la table [dbo].[User] doit être modifiée de NULL à NOT NULL. Si la table contient des données, le script ALTER peut ne pas fonctionner. Pour éviter ce problème, vous devez ajouter des valeurs à cette colonne pour toutes les lignes, marquer la colonne comme autorisant les valeurs NULL ou activer la génération de smart-defaults en tant qu'option de déploiement.
*/

IF EXISTS (select top 1 1 from [dbo].[User])
    RAISERROR (N'Lignes détectées. Arrêt de la mise à jour du schéma en raison d''''un risque de perte de données.', 16, 127) WITH NOWAIT

GO
PRINT N'Modification de [dbo].[User]...';


GO
ALTER TABLE [dbo].[User] ALTER COLUMN [birthdate] DATETIME2 (7) NOT NULL;


GO
PRINT N'Actualisation de [dbo].[V_MostRecentReviews]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[V_MostRecentReviews]';


GO
PRINT N'Actualisation de [dbo].[V_ReadingStatus]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[V_ReadingStatus]';


GO
PRINT N'Actualisation de [dbo].[V_UserReview]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[V_UserReview]';


GO
PRINT N'Actualisation de [dbo].[User_Insert]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[User_Insert]';


GO
PRINT N'Mise à jour terminée.';


GO
