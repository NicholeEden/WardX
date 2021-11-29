
CREATE OR ALTER PROCEDURE sp_SelectPatientMoveByDateRange

@StartDate datetime2(7),
@EndDate datetime2(7),
@PatientID int

AS
BEGIN
SET NOCOUNT ON
SELECT *
	FROM PatientMovement PM, Patient P,AdmissionFile A
	WHERE  P.PatientID =@PatientID AND (MoveDate BETWEEN @StartDate AND @EndDate) AND 
	A.PatientID = P.PatientID AND PM.AdmissionFileID = A.AdmissionFileID

END