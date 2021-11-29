
CREATE OR ALTER PROCEDURE sp_SelectVitalSignByPatient
	@PatientID int
AS
BEGIN
SET NOCOUNT ON
	SELECT *
	FROM VitalSign,Patient
	WHERE VitalSign.VitalSignID = Patient.VitalSignID AND PatientID=@PatientID
END