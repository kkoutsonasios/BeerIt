CREATE TABLE [dbo].[Type]
(
	[Id] INT NOT NULL  IDENTITY, 
    [Name] NCHAR(10) NOT NULL, 
    CONSTRAINT [PK_Type] PRIMARY KEY ([Id]), 
    CONSTRAINT [CK_Type_Name] UNIQUE(Name) 
)
