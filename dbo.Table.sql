CREATE TABLE [dbo].[MyTable]
(
	[Name] VARCHAR(50) NOT NULL , 
    [LastName] VARCHAR(50) NULL, 
    [Address] VARCHAR(50) NULL, 
    CONSTRAINT [PK_MyTable] PRIMARY KEY ([Name])
)
