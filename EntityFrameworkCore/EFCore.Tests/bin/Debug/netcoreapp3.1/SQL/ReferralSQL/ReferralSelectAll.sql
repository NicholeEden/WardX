CREATE OR ALTER PROCEDURE sp_SelectReferral
    @isAdmitted bit
AS
BEGIN
SET NOCOUNT ON
    SELECT *
    FROM Referral
    WHERE isAdmitted = @isAdmitted
END
GO