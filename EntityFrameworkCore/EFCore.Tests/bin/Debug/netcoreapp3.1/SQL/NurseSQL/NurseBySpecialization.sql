
CREATE OR ALTER PROCEDURE sp_NurseBySpecialization
  @SpecializationID int
AS
SET NOCOUNT ON
BEGIN
    SELECT NurseID, isWardManager, isHeadNurse, SpecializationID, NurseTypeID
    FROM Nurse
    WHERE SpecializationID = @SpecializationID
END
GO