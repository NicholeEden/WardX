CREATE OR ALTER PROCEDURE sp_AdmissionFileDischarge
	@DischargeDate datetime2(7),
	@AdmissionFileID int
AS

	BEGIN
	  UPDATE AdmissionFile
	  SET DischargeDate = @DischargeDate
      WHERE AdmissionFileID = @AdmissionFileID
	END
GO