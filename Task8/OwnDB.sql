/*14 На основе диаграммы классов проработайте архитектуру базы данных вашего финального проекта.
--Напишите скрипт создания сущностей пользователя, ролей и зависимых сущностей (достаточных для выполнения CRUD операций над пользователями и выдачи им определенных ролей)
--*Напишите скрипт создания оставшихся сущностей вашей диаграммы. 
*/
GO  
IF NOT EXISTS(SELECT * FROM sys.databases 
          WHERE name='Forum')
CREATE DATABASE Forum
GO  

USE [Forum]
GO

IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
	DROP TABLE [dbo].[Users]
GO
IF OBJECT_ID('dbo.Countries', 'U') IS NOT NULL
	DROP TABLE [dbo].[Countries]
GO
IF OBJECT_ID('dbo.Roles', 'U') IS NOT NULL
	DROP TABLE [dbo].[Roles]
GO
IF OBJECT_ID('dbo.Permissions', 'U') IS NOT NULL
	DROP TABLE [dbo].[Permissions]
GO


BEGIN 
	CREATE TABLE [Permissions](
		[PermId] int IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
		[Name] nvarchar(50) NULL, 
		[Description] nvarchar(200) NULL)
END;

BEGIN 
	CREATE TABLE Roles(
		[RoleId] int IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
		[Name] nvarchar(50) NULL,
		[Permissions] int FOREIGN KEY REFERENCES [Permissions](PermId))
END;

BEGIN 
	CREATE TABLE Countries(
		CountryId int IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
		[CountryName] nvarchar(100) NOT NULL)
END;

CREATE TABLE [dbo].[Users](
	[UserId] int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[Username] nvarchar(50) NOT NULL,
	[Role] int FOREIGN KEY REFERENCES Roles(RoleId),
	[Password] nvarchar(50) NOT NULL,
	[Email] nvarchar(50) NOT NULL,
	[RegDate] datetime NULL,
	[Country] int FOREIGN KEY REFERENCES Countries(CountryId),
	[Gender] VARCHAR(6) NOT NULL CHECK (Gender IN ('Male', 'Female')),
	[FirstName] nvarchar(50) NULL,
	[LastName] nvarchar(50) NULL,
	[BirthDate] datetime NULL)
GO