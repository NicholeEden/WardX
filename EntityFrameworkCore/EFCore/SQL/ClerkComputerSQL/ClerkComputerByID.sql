USE HWMS06DB
GO
CREATE OR ALTER PROCEDURE sp_GetClerkComputerByID
	@ClerkID int
AS
BEGIN
SET NOCOUNT ON
	SELECT ComputerSkillID, ProficiencyLevel
	FROM ClerkComputer
	WHERE ClerkID = @ClerkID
END