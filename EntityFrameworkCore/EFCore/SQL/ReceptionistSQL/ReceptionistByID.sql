
CREATE OR ALTER PROCEDURE sp_GetReceptionistByID
  @ClerkID int
AS
SET NOCOUNT ON
BEGIN
    SELECT ClerkID, QualificationID
    FROM Receptionist
    WHERE ClerkID = @ClerkID
END
GO