
CREATE OR ALTER PROCEDURE sp_SelectPatientMovementByNotification
@lateTime datetime2(7),
@isCheckedOut bit
AS
BEGIN
SET NOCOUNT ON
SELECT *
	FROM PatientMovement PM, Patient P,AdmissionFile A
	WHERE isCheckedOut = 'True' AND CheckOutTime < @lateTime AND 
	A.PatientID = P.PatientID AND PM.AdmissionFileID = A.AdmissionFileID
END