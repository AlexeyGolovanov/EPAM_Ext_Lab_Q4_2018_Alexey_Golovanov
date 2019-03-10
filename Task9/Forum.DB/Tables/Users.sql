CREATE TABLE [dbo].[Users]
(
	[UserId] int NOT NULL PRIMARY KEY,
	[Username] nvarchar(50) NOT NULL UNIQUE,
	[Role] int NOT NULL,
	[Password] nvarchar(50) NOT NULL,
	[Email] nvarchar(50) NOT NULL UNIQUE,
	[RegDate] datetime NULL,
	[Country] int NOT NULL,
	[Gender] VARCHAR(6) NOT NULL CHECK (Gender IN ('Male', 'Female')),
	[FirstName] nvarchar(50) NULL,
	[LastName] nvarchar(50) NULL,
	[BirthDate] datetime NULL,

	CONSTRAINT [FK_USER_ROLE] FOREIGN KEY ([Role]) REFERENCES [Roles]([RoleId]),
	CONSTRAINT [FK_USER_COUNTRY] FOREIGN KEY ([Country]) REFERENCES [Countries]([CountryId])
)
