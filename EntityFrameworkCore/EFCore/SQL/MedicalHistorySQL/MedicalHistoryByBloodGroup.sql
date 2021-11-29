
CREATE OR ALTER PROCEDURE sp_GetMedicalHistoryByBloodGroup
  @BloodGroupID int
AS
BEGIN 
SET NOCOUNT ON
    SELECT Diagnosis, ExistingCondition, BMI, [Weight], Allergies, BloodGroupID
    FROM MedicalHistory
    WHERE BloodGroupID = @BloodGroupID
END