USE HWMS06DB
GO
CREATE OR ALTER PROCEDURE sp_ComputerSkillByID
   @ComputerSkillID int
AS
BEGIN 
SET NOCOUNT ON
    SELECT ComputerSkillID, [Application]
    FROM ComputerSkill
    WHERE ComputerSkillID = @ComputerSkillID
END