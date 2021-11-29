USE HWMS06DB
GO
CREATE OR ALTER PROCEDURE sp_InsertClerkComputer
	@ClerkID int,
	@ComputerSkillID int,
	@ProficiencyLevel nvarchar(50)

AS
BEGIN
	INSERT INTO ClerkComputer (ClerkID, ComputerSkillID, ProficiencyLevel) 
	VALUES (@ClerkID, @ComputerSkillID, @ProficiencyLevel) 
END