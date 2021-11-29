

CREATE OR ALTER PROCEDURE sp_GetPrescriptionByID
  @ScriptID int
AS
SET NOCOUNT ON
BEGIN
    SELECT *
    FROM Prescription p, Medication m
    WHERE PrescriptionID = @ScriptID AND p.MedicaltionID = m.MedicationID
END
GO