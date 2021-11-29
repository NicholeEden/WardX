CREATE OR ALTER PROCEDURE sp_InsertPatientMovement

@AdmissionFileID int,
@isCheckedOut bit,
@Reason int

AS
BEGIN

INSERT INTO PatientMovement (AdmissionFileID,MoveDate,CheckOutTime,isCheckedOut,Reason)
VALUES (@AdmissionFileID,GETDATE(),GETDATE(),'True',@Reason)

END