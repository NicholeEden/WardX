
CREATE OR ALTER PROCEDURE sp_NurseInspectionByPatient
  @PatientID int
AS
SET NOCOUNT ON
BEGIN
    SELECT NurseInspectionID, NurseID, PatientID, [Date], [time], Comments
    FROM NurseInspection
    WHERE PatientID = @PatientID
END
GO