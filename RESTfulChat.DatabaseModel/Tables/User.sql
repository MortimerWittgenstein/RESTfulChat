CREATE TABLE [dbo].[User]
(
	[Id] INT IDENTITY NOT NULL, 
	[UserName] NVARCHAR(50) NOT NULL UNIQUE,
    [FirstName] NVARCHAR(MAX) NULL, 
    [LastName] NVARCHAR(MAX) NULL, 
    [Birthdate] DATE NULL, 
	[Email] NVARCHAR(MAX) NULL,
    [Company] NVARCHAR(MAX) NULL,
	PRIMARY KEY ([Id])
)
