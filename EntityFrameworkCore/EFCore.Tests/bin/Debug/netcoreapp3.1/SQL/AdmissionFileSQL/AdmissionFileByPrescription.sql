
CREATE OR ALTER PROCEDURE sp_SelectAdmissionFileByPrescription
  @PrescriptionID int
AS
SET NOCOUNT ON
BEGIN
    SELECT *
    FROM  AdmissionFile a, Prescription p,  Medication m
    WHERE a.PrescriptionID = @PrescriptionID 
    AND p.PrescriptionID = a.PrescriptionID 
    AND p.MedicationID = m.MedicationID
END
GO