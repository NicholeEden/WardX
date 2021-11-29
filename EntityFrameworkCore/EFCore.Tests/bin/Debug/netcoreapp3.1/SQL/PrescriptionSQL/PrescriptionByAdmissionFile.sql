CREATE OR ALTER PROCEDURE sp_SelectPrescriptionByAdmissionFileID
  @AdmissionFileID int
AS
SET NOCOUNT ON
BEGIN
    SELECT *
    FROM Prescription p, AdmissionFile a, Medication m
    WHERE AdmissionFileID = @AdmissionFileID AND p.PrescriptionID = a.PrescriptionID AND p.MedicationID = m.MedicationID
END
GO