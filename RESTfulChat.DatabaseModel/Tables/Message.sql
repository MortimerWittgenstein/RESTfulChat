CREATE TABLE [dbo].[Message]
(
	[ChatId] INT NOT NULL,
    [CreatedAt] DATETIME NOT NULL,
    [FromUserId] INT NOT NULL,
    [Text] NVARCHAR(MAX) NOT NULL,
	PRIMARY KEY ([ChatId],[CreatedAt]),
	INDEX [FK_Chat_ChatMessage] ([ChatId] ASC),
	INDEX [FK_User_ChatMessage] ([FromUserId] ASC),
    CONSTRAINT [FK_Chat_ChatMessage]
		FOREIGN KEY ([ChatId])
		REFERENCES [Chat]([Id]),
	CONSTRAINT [FK_User_ChatMessage]
		FOREIGN KEY ([FromUserId])
		REFERENCES [User]([Id])
)
