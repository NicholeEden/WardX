CREATE OR ALTER PROCEDURE sp_SelectNextOfKin
    @PatientID int
AS
BEGIN
SET NOCOUNT ON
    SELECT *
    FROM NextOfKin
    WHERE @PatientID = PatientID
END
GO