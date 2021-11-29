
CREATE OR ALTER PROCEDURE sp_NurseByEpaulette
  @Epaulette int
AS
SET NOCOUNT ON
BEGIN
    SELECT NurseID, EpauletteID, isWardManager, isHeadNurse, SpecializationID, Nurse_TypeID
    FROM Nurse
    WHERE EpauletteID = @EpauletteID
END
GO