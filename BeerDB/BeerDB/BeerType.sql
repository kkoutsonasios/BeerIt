CREATE TABLE [dbo].[BeerType]
(
	[Id] INT NOT NULL  IDENTITY, 
    [Name] NCHAR(10) NOT NULL, 
    CONSTRAINT [PK_BeerType] PRIMARY KEY ([Id]), 
    CONSTRAINT [CK_BeerType_Name] UNIQUE(Name) 
)
