
CREATE OR ALTER PROCEDURE sp_InsertMedicalHistory
     @PatientID int,
	 @Diagnosis nvarchar(50),
	 @ExistingCondition nvarchar(50),
	 @BMI float,
	 @Weight int,
	 @Allergies nvarchar(50),
	 @BloodGroup int

AS
SET NOCOUNT ON
	BEGIN
	    INSERT INTO MedicalHistory (PatientID, Diagnosis, ExistingCondition, BMI, [Weight], Allergies, BloodGroupID)
		VALUES (@PatientID, @Diagnosis, @ExistingCondition, @BMI, @Weight, @Allergies, @BloodGroup)
	END
GO
