
CREATE OR ALTER PROCEDURE sp_NurseInspectionByID
  @NurseInspectionID int
AS
SET NOCOUNT ON
BEGIN
    SELECT NurseInspectionID, NurseID, PatientID, [Date], [time], Comments
    FROM NurseInspection
    WHERE NurseInspectionID = @NurseInspectionID
END
GO