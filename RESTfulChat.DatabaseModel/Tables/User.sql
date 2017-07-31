CREATE TABLE [dbo].[User]
(
	[Id] INT IDENTITY NOT NULL, 
    [FirstName] NVARCHAR(MAX) NULL, 
    [LastName] NVARCHAR(MAX) NULL, 
    [Birthdate] DATE NULL, 
	[Email] NVARCHAR(MAX) NULL,
    [Company] NVARCHAR(MAX) NULL,
	PRIMARY KEY ([Id])
)
