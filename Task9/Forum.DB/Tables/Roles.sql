CREATE TABLE [dbo].[Roles]
(
	[RoleId] int NOT NULL PRIMARY KEY, 
	[Name] nvarchar(50) NULL,
	[Permissions] int
)
