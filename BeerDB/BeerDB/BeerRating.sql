CREATE TABLE [dbo].[BeerRating]
(
	[Id] INT NOT NULL IDENTITY, 
	[BeerId] INT NOT NULL, 
    [Rating] INT NOT NULL, 
    CONSTRAINT [FK_BeerRating_Beer] FOREIGN KEY ([BeerId]) REFERENCES [Beer]([Id]), 
    CONSTRAINT [PK_BeerRating] PRIMARY KEY ([Id])
)
