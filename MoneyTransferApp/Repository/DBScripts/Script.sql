CREATE TABLE [dbo].[Users]
(
	[Id] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [CurrentBalance] FLOAT NULL
)

CREATE TABLE [dbo].[Transfers]
(
	[Id] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [SourceUserId] NVARCHAR(50) NOT NULL, 
    [TargetUserId] NVARCHAR(50) NOT NULL, 
    [Amount] FLOAT NOT NULL,
    [Timestamp] DATETIME NOT NULL
)

--Seed Data
INSERT INTO Users(Id,[Name],CurrentBalance) VALUES('U1','User A', 1000.00)
INSERT INTO Users(Id,[Name],CurrentBalance) VALUES('U2','User B', 1500.00)