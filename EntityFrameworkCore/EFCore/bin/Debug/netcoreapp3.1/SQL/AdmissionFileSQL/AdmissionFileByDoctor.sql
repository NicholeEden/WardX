USE HWMS06DB
GO
CREATE OR ALTER PROCEDURE sp_SelectAdmissionFileByDoctor
	@AssignedSpecialistID int 
AS 
BEGIN 
SET NOCOUNT ON
	SELECT AdmissionFileID, PatientID, AdmissionDate, AssignedSpecialistID, DischargeDate, BedID, PrescriptionID 
	FROM AdmissionFile 
	WHERE AssignedSpecialistID = @AssignedSpecialistID 
END