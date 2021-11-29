CREATE OR ALTER PROCEDURE sp_SelectMedicalAid
    @PatientID int
AS
BEGIN
SET NOCOUNT ON
    SELECT *
    FROM MedicalAid
    WHERE @PatientID = PatientID
END
GO