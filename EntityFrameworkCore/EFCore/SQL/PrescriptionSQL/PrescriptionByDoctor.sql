
CREATE OR ALTER PROCEDURE sp_GetPrescriptionByDoctor
  @DoctorID int
AS
SET NOCOUNT ON
BEGIN
    SELECT ScriptID, DoctorID, PatientID, Date, Notes
    FROM Prescription
    WHERE DoctorID = @DoctorID
END
GO