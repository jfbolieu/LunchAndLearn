CREATE TABLE [dbo].[Province]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Code] VARCHAR(3) NOT NULL
)

GO

CREATE INDEX [IX_Province_Code] ON [dbo].[Province] ([Code])
