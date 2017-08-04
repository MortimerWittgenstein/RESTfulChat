CREATE TABLE [dbo].[ChatUser]
(
	[ChatId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
	PRIMARY KEY ([UserId], [ChatId]),
    CONSTRAINT [FK_Chat_Chat_User] 
		FOREIGN KEY ([ChatId]) 
		REFERENCES [Chat]([Id]), 
    CONSTRAINT [FK_User_Chat_User] 
		FOREIGN KEY ([UserId]) 
		REFERENCES [User]([Id])
)
