CREATE OR ALTER PROCEDURE sp_SelectPatientByID
	@PatientID int 
AS 
BEGIN 
SET NOCOUNT ON
	SELECT *
	FROM Patient
	WHERE PatientID = @PatientID 
END