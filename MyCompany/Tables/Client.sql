CREATE TABLE [dbo].[Client]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(100) NOT NULL, 
    [LastName] VARCHAR(100) NOT NULL, 
    [MiddleName] VARCHAR(100) NULL, 
    [BirthDate] DATE NOT NULL, 
    [Gender] SMALLINT NOT NULL, 
    [Code] VARCHAR(50) NOT NULL, 
    [Since] DATE NOT NULL, 
    [Email] VARCHAR(1028) NOT NULL, 
    [AgentId] INT NOT NULL, 
    [CreatedBy] VARCHAR(50) NOT NULL DEFAULT 'SYSTEM', 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedBy] VARCHAR(50) NOT NULL DEFAULT 'SYSTEM', 
    [ModifiedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    [Deleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [AK_Client_Code] UNIQUE ([Code]),
    CONSTRAINT [AK_Client_Email] UNIQUE ([Email]), 
    CONSTRAINT [FK_Client_Agent] FOREIGN KEY ([AgentId]) REFERENCES [Agent]([Id])
)

GO
