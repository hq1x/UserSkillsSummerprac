
CREATE PROCEDURE InsertUser
@ID INT OUTPUT,
@Name nvarchar(50),
@Birthday date,
@Description nvarchar(255)
AS 
INSERT INTO Users
VALUES(@Name, @Birthday, @Description)
SELECT CAST(SCOPE_IDENTITY() AS INT) AS NewID
GO

CREATE PROCEDURE DeleteUser
@ID INT
AS 
IF (EXISTS (SELECT * FROM Accounts WHERE UserID = @ID))
  DELETE FROM Accounts
  WHERE UserID = @ID
IF (EXISTS (SELECT * FROM SkillUserConnection WHERE UserID = @ID))
  DELETE FROM SkillUserConnection
  WHERE UserID = @ID
DELETE FROM Users 
WHERE ID = @ID
GO

CREATE PROCEDURE UpdateUser
@ID INT,
@Name nvarchar(50),
@Birthday date,
@Description nvarchar(255)
AS
UPDATE Users
SET Name = @Name, Birthday = @Birthday, [Description] = @Description
WHERE ID = @ID
GO

CREATE PROCEDURE GetAllUsers
AS 
SELECT ID, Name, Birthday FROM Users
GO

CREATE PROCEDURE GetUserDescription
@ID INT
AS 
SELECT [Description] FROM Users
WHERE ID = @ID
GO

CREATE PROCEDURE InsertSkill
@ID INT OUTPUT,
@Name nvarchar(50),
@Description nvarchar(255)
AS 
INSERT INTO Skills
VALUES(@Name, @Description)
GO

CREATE PROCEDURE DeleteSkill
@ID INT
AS 
IF (EXISTS (SELECT * FROM SkillUserConnection WHERE SkillID = @ID))
  DELETE FROM SkillUserConnection
  WHERE SkillID = @ID
DELETE FROM SKills 
WHERE ID = @ID
GO

CREATE PROCEDURE UpdateSkill
@ID INT,
@Name nvarchar(50),
@Description nvarchar(255)
AS
UPDATE Skills
SET Name = @Name, [Description] = @Description
WHERE ID = @ID
GO

CREATE PROCEDURE GetAllSkills
AS 
SELECT * FROM Skills
GO

CREATE PROCEDURE InsertSkillUserConnection
@UserID INT,
@SkillID INT
AS 
INSERT INTO SkillUserConnection
VALUES(@UserID, @SkillID)
GO

CREATE PROCEDURE DeleteSkillUserConnection
@UserID INT,
@SkillID INT
AS 
DELETE FROM SkillUserConnection 
WHERE UserID = @UserID AND SkillID = @SkillID
GO

--CREATE PROCEDURE UpdateAchievementUserConnection
--@UserID INT,
--@OldAchievementID INT,
--@NewAchievementID INT
--AS
--UPDATE AchievementUserConnection
--SET UserID = @UserID, AchievementID = @AchievementID
--WHERE UserID = @UserID AND AchievementID = @OldAchievementID
--GO

CREATE PROCEDURE GetAllSkillsByUser
@UserID INT
AS 
SELECT ski.ID, ski.Name, ski.[Description]
FROM SkillUserConnection AS skiUser
INNER JOIN Skills AS ski ON ski.ID = skiUser.SkillID
WHERE skiUser.UserID = @UserID
GO

CREATE PROCEDURE InsertAccount
@UserID INT,
@UserLogin nvarchar(30),
@UserPassword nvarchar(15),
@UserRole nvarchar(20)
AS 
INSERT INTO Accounts
VALUES(@UserID, @UserLogin, @UserPassword, @UserRole)
GO

CREATE PROCEDURE DeleteAccount
@UserID INT
AS 
IF (EXISTS (SELECT * FROM SkillUserConnection WHERE UserID = @UserID))
  DELETE FROM SkillUserConnection
  WHERE UserID = @UserID
DELETE FROM Accounts 
WHERE UserID = @UserID
GO

CREATE PROCEDURE UpdateAccount
@UserID INT,
@UserLogin nvarchar(30),
@UserPassword nvarchar(15),
@UserRole nvarchar(20)
AS
UPDATE Accounts
SET UserLogin = @UserLogin, UserPassword = @UserPassword, UserRole = @UserRole
WHERE UserID = @UserID
GO

CREATE PROCEDURE GetAllAccounts
AS 
SELECT * FROM Accounts
GO

CREATE PROCEDURE GetUserByID
@UserID INT
AS 
SELECT * FROM Users
WHERE ID = @UserID
GO

CREATE PROCEDURE SearchAccountForAuth
@UserLogin nvarchar(30),
@UserPassword nvarchar(15)
AS
SELECT * FROM Accounts
WHERE UserLogin = @UserLogin AND UserPassword = @UserPassword
GO
