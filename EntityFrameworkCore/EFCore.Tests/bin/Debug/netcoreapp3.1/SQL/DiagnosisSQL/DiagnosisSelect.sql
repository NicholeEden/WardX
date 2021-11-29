CREATE OR ALTER PROCEDURE sp_SelectDiagnosis
    @DiagnosisID int
AS
BEGIN
SET NOCOUNT ON
    SELECT *
    FROM Diagnosis
    WHERE @DiagnosisID = DiagnosisID
END
GO