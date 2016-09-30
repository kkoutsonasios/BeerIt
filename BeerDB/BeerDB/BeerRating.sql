CREATE TABLE [dbo].[BeerRating]
(
	[BeerId] INT NOT NULL, 
    [Rating] INT NOT NULL, 
    CONSTRAINT [FK_BeerRating_Beer] FOREIGN KEY ([BeerId]) REFERENCES [Beer]([Id])
)
