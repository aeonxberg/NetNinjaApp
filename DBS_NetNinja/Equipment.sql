CREATE TABLE [dbo].[Equipment]
(
	[Name] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Agility] INT NOT NULL, 
    [Price] INT NOT NULL, 
    [Intelligence] INT NOT NULL, 
    [Strength] INT NOT NULL, 
    [ImageURL] NVARCHAR(50) NULL, 
    [Category] NVARCHAR(50) NOT NULL, 
    [NinjaName] NVARCHAR(50) NULL
)
