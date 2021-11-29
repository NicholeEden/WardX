
CREATE OR ALTER PROCEDURE sp_UpdateAdmissionFileByPatient
     @AdmissionFileID int,
	 @Notes nvarchar(1024),
	 @BedID int
AS

	BEGIN
	UPDATE AdmissionFile 
	SET Notes = @Notes, BedID = @BedID
    WHERE AdmissionFileID = @AdmissionFileID
	END
GO