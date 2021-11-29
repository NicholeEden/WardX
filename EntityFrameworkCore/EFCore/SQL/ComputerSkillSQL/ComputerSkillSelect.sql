USE HWMS06DB
GO
CREATE OR ALTER PROCEDURE sp_SelectComputerSkill
AS
BEGIN 
SET NOCOUNT ON
    SELECT ComputerSkillID, [Application]
    FROM ComputerSkill
END