
CREATE OR ALTER PROCEDURE sp_UpdateMedicalHistory
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
	  UPDATE  MedicalHistory SET PatientID=@PatientID, 
	  Diagnosis= @Diagnosis, 
	  ExistingCondition=@ExistingCondition, 
	  BMI=@BMI,
	  [Weight]=@Weight,
	  Allergies= @Allergies,
	  BloodGroupID=@BloodGroup

	END
GO
