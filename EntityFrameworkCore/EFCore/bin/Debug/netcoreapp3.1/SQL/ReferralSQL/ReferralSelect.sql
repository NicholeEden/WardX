CREATE OR ALTER PROCEDURE sp_SelectReferralByPatientID
    @PatientID int
AS
BEGIN
SET NOCOUNT ON
    SELECT *
    FROM Referral r
    WHERE @PatientID = PatientID
    AND r.isAdmitted = 'False'
END
GO