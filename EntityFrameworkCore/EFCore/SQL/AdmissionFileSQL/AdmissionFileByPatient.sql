
CREATE OR ALTER PROCEDURE sp_SelectAdmissionFileByPatientID
	@PatientID int 
AS 
BEGIN 
SET NOCOUNT ON
	SELECT *
	FROM AdmissionFile 
	WHERE @PatientID = PatientID
END