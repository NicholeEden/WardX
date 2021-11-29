
CREATE OR ALTER PROCEDURE sp_InsertAdmissionFile
     @AdmissionDate datetime2(7),
	 @Notes nvarchar(1024),
	 @AssignedSpecialistID int,
	 @PatientID int,
	 @BedID int
AS

	BEGIN
	  INSERT INTO AdmissionFile (AdmissionDate, Notes, AssignedSpecialistID, PatientID, BedID)
	  VALUES (@AdmissionDate,  @Notes, @AssignedSpecialistID, @PatientID, @BedID)
	  
	END
GO
