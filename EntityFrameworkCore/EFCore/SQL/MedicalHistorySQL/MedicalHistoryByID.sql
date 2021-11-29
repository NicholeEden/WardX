
CREATE OR ALTER PROCEDURE sp_GetMedicalHistoryByID
  @PatientID int
AS
BEGIN 
SET NOCOUNT ON
    SELECT Diagnosis, ExistingCondition, BMI, [Weight], Allergies, BloodGroupID
    FROM MedicalHistory
    WHERE PatientID = @PatientID
END