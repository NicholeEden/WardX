
CREATE OR ALTER PROCEDURE sp_NurseByType
  @NurseTypeID int
AS
SET NOCOUNT ON
BEGIN
    SELECT NurseID, isWardManager, isHeadNurse, SpecializationID, NurseTypeID
    FROM Nurse
    WHERE NurseTypeID = @NurseTypeID
END
GO