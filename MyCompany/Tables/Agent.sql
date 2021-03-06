CREATE TABLE [dbo].[Agent]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(100) NOT NULL, 
    [LastName] VARCHAR(100) NOT NULL, 
    [Initiale] CHAR(1) NULL, 
    [BirthDate] DATE NOT NULL, 
    [Gender] SMALLINT NOT NULL, 
    [CreatedBy] VARCHAR(50) NOT NULL DEFAULT 'SYSTEM', 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedBy] VARCHAR(50) NOT NULL DEFAULT 'SYSTEM', 
    [ModifiedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    [Deleted] BIT NOT NULL DEFAULT 0

)
