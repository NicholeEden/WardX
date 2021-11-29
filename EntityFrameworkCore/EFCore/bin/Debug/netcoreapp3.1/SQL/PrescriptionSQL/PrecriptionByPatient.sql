
CREATE OR ALTER PROCEDURE sp_SelectPrescriptionByPatientID
  @PatientID int
AS
SET NOCOUNT ON
BEGIN
    SELECT *
    FROM Prescription p, AdmissionFile a, Medication m
    WHERE PatientID = @PatientID AND p.PrescriptionID = a.PrescriptionID AND p.MedicaltionID = m.MedicationID
END
GO