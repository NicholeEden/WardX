
CREATE OR ALTER PROCEDURE sp_SelectAdmissionFileByID
	@AdmissionFileID int 
AS 
BEGIN 
SET NOCOUNT ON
	SELECT *
	FROM AdmissionFile 
	WHERE AdmissionFileID = @AdmissionFileID 
END