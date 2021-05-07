CREATE TABLE [dbo].[Location]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(200) NULL, 
    [Address] VARCHAR(500) NULL, 
    [Room] VARCHAR(100) NULL, 
    [City] VARCHAR(100) NULL, 
    [ProvinceId] INT NOT NULL,
    [PostalCode] CHAR(6) NULL, 
    [Corrdinated] VARCHAR(500) NULL, 
    [CreatedBy] VARCHAR(50) NOT NULL DEFAULT 'SYSTEM', 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedBy] VARCHAR(50) NOT NULL DEFAULT 'SYSTEM', 
    [ModifiedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    [Deleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [AK_Locations_Name] UNIQUE ([Name]), 
    CONSTRAINT [FK_Location_Province] FOREIGN KEY ([ProvinceId]) REFERENCES [Province]([Id]), 

)
