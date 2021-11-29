CREATE OR ALTER PROCEDURE sp_SelectPendingReferral
AS
BEGIN
SET NOCOUNT ON
    SELECT *
    FROM Referral r
    WHERE r.AdmissionDate > GETDATE() 
    AND r.PatientID NOT IN (SELECT DISTINCT PatientID FROM AdmissionFile)
END
GO