CREATE OR ALTER PROCEDURE sp_UpdatePatientMovement
@PatientMovementID int,
@AdmissionFileID int,
@isCheckedOut bit

AS
BEGIN
SET NOCOUNT ON
	UPDATE PatientMovement 
	SET CheckInTime = GETDATE(),
	isCheckedOut = 'False'
	WHERE PatientMovementID = @PatientMovementID 
END

