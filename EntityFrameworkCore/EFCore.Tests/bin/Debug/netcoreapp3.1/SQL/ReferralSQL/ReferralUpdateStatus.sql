CREATE OR ALTER PROCEDURE sp_UpdateReferralStatus
	@ReferralID int,
	@isAdmitted bit
AS
BEGIN
	UPDATE Referral
	SET isAdmitted = @isAdmitted
	WHERE ReferralID = @ReferralID
END