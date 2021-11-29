
CREATE OR ALTER PROCEDURE sp_SelectPatientMovementByReason
@Reason int
AS
BEGIN
SET NOCOUNT ON
SELECT  *
	FROM PatientMovement PM, Patient P,AdmissionFile A
	WHERE Reason = @Reason AND
	A.PatientID = P.PatientID AND PM.AdmissionFileID = A.AdmissionFileID
	
END