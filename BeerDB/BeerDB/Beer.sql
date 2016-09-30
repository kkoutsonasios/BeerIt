CREATE TABLE [dbo].[Beer]
(
	[Id] INT NOT NULL IDENTITY , 
    [Name] NVARCHAR(150) NOT NULL, 
    [TypeId] INT NOT NULL, 
    CONSTRAINT [FK_Beer_Type] FOREIGN KEY ([TypeId]) REFERENCES [BeerType]([id]), 
    CONSTRAINT [PK_Beer] PRIMARY KEY ([Id]), 
    CONSTRAINT [CK_Beer_Name] UNIQUE (Name)
)
