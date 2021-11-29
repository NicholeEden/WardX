CREATE OR ALTER PROCEDURE sp_SetBedStatus
	@BedID int,
	@isAvailable bit

AS
	BEGIN
	 UPDATE Bed

	 SET isAvailable = @isAvailable
	 WHERE BedID = @BedID
	
	END