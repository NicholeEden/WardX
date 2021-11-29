
CREATE OR ALTER PROCEDURE sp_SelectPatientMovementByStatus
@isCheckedOut bit
AS
BEGIN
SET NOCOUNT ON
SELECT P.FirstName,P.LastName,PM.AdmissionFileID CheckInTime, Reason,isCheckedOut
	FROM PatientMovement PM, Patient P,AdmissionFile A
	WHERE isCheckedOut = @isCheckedOut AND
	A.PatientID = P.PatientID AND PM.AdmissionFileID = A.AdmissionFileID
END