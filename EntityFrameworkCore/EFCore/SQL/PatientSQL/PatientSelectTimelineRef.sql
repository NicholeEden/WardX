CREATE OR ALTER PROCEDURE sp_SelectReferralTimeline
    @PatientID int
AS
BEGIN
SET NOCOUNT ON
    SELECT *
    FROM Referral r, Diagnosis d
    WHERE @PatientID = r.PatientID
    AND r.DiagnosisID = d.DiagnosisID
END
GO