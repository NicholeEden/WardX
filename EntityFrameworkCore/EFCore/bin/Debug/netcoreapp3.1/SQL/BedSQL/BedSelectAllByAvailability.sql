USE HWMS06DB
GO
CREATE OR ALTER PROCEDURE sp_SelectAvailableBed
	@isAvailable bit
AS
BEGIN
SET NOCOUNT ON
SELECT *
FROM Bed
WHERE isAvailable = @isAvailable
END