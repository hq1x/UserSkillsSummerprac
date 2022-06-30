CREATE DATABASE SkillsAccountingDB
COLLATE Cyrillic_General_100_CI_AI
GO
use SkillsAccountingDB

CREATE TABLE [Users] (
  [ID] int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Users] PRIMARY KEY,
  [Name] nvarchar(50) NOT NULL,
  [Birthday] date,
  [Description] nvarchar(255)
);

CREATE TABLE [Accounts] (
  [UserID] int NOT NULL,
  [UserLogin] nvarchar(30) NOT NULL,
  [UserPassword] nvarchar(15) NOT NULL,
  [UserRole] nvarchar(20) NOT NULL,
  CONSTRAINT [FK_Accounts.UserID]
    FOREIGN KEY ([UserID])
      REFERENCES [Users]([ID])
);

CREATE TABLE [Skills] (
  [ID] int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Skills] PRIMARY KEY,
  [Name] nvarchar(50) NOT NULL,
  [Description] nvarchar(255) NOT NULL
);

CREATE TABLE [SkillUserConnection] (
  [UserID] int NOT NULL,
  [SkillID] int NOT NULL,
  CONSTRAINT [FK_SkillUserConnection.UserID]
    FOREIGN KEY ([UserID])
      REFERENCES [Users]([ID]),
  CONSTRAINT [FK_SkillUserConnection.SkillID]
    FOREIGN KEY ([SkillID])
      REFERENCES [Skills]([ID])
);

ALTER TABLE [Accounts]
ADD UNIQUE(UserLogin);

ALTER TABLE Users
ALTER COLUMN Birthday date NOT NULL;
