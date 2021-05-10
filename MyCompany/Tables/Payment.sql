CREATE TABLE [dbo].[Payment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CardNumber] VARCHAR(16) MASKED WITH (FUNCTION = 'partial(0, "xxxxxxxxxxxx", 4)') NOT NULL , 
    [CardType] INT NOT NULL, 
    [Amount] DECIMAL(9, 2) NOT NULL DEFAULT 0, 
    [Date] DATE NOT NULL DEFAULT SYSDATETIME(), 
    [Time] TIME(0) NOT NULL DEFAULT FORMAT(SYSDATETIME(), 'hh:mm:ss') 
)
