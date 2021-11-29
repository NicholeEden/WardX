
CREATE OR ALTER PROCEDURE sp_NurseInspectionByNurse
  @NurseID int
AS
SET NOCOUNT ON
BEGIN
    SELECT NurseInspectionID, NurseID, PatientID, [Date], [time], Comments
    FROM NurseInspection
    WHERE NurseID = @NurseID
END
GO