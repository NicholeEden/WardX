
CREATE OR ALTER PROCEDURE sp_SelectPatientMovementByStatus
@isCheckedOut bit
AS
BEGIN
SET NOCOUNT ON
SELECT *
	FROM PatientMovement PM, Patient P,AdmissionFile A
	WHERE isCheckedOut = @isCheckedOut AND
	A.PatientID = P.PatientID AND PM.AdmissionFileID = A.AdmissionFileID
END