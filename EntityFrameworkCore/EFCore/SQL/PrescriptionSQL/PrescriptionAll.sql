
CREATE OR ALTER PROCEDURE sp_SelectPrescription
AS
SET NOCOUNT ON
BEGIN
    SELECT *
    FROM Prescription p, Medication m
    WHERE p.MedicationID = m.MedicationID
END
GO