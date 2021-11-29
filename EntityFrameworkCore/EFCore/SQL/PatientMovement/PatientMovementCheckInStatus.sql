
CREATE OR ALTER PROCEDURE sp_SelectPatientMovementByCheckInStatus
@isCheckedOut bit
AS
BEGIN
SET NOCOUNT ON
SELECT P.FirstName,P.LastName, CheckInTime, CheckOutTime ,Reason,isCheckedOut
	FROM PatientMovement PM, Patient P,AdmissionFile A
	WHERE isCheckedOut = @isCheckedOut AND
	A.PatientID = P.PatientID AND PM.AdmissionFileID = A.AdmissionFileID
END