
CREATE OR ALTER PROCEDURE sp_SelectPatientMovementByID
@PatientMovementID int
AS
BEGIN
SET NOCOUNT ON
SELECT *
FROM PatientMovement
WHERE PatientMovementID = @PatientMovementID
END