CREATE TABLE [dbo].[Meeting]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LocationId] INT NOT NULL, 
    [ClientId] INT NOT NULL, 
    [AgentId] INT NOT NULL, 
    [DateTime] DATETIME2 NOT NULL, 
    [ExpectedEndTime] DATETIME2 NOT NULL, 
    [ActualEndTime] DATETIME2 NULL,
    [CreatedBy] VARCHAR(50) NOT NULL DEFAULT 'SYSTEM', 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedBy] VARCHAR(50) NOT NULL DEFAULT 'SYSTEM', 
    [ModifiedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    CONSTRAINT [FK_Meetings_Location] FOREIGN KEY ([LocationId]) REFERENCES [Location]([Id]),
    CONSTRAINT [FK_Meetings_Client] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id]),
    CONSTRAINT [FK_Meetings_Agent] FOREIGN KEY ([AgentId]) REFERENCES [Agent]([Id])
)
