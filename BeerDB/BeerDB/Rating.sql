CREATE TABLE [dbo].[Rating]
(
	[BeerId] INT NOT NULL, 
    [Rating] INT NOT NULL, 
    CONSTRAINT [FK_Rating_Beer] FOREIGN KEY ([BeerId]) REFERENCES [Beer]([Id])
)
