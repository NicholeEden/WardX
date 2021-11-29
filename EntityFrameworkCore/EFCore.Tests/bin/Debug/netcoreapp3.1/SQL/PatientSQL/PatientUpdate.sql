CREATE OR ALTER PROCEDURE sp_UpdatePatient
	@PatientID int,
    @FirstName nvarchar(128),
	@LastName nvarchar(128),
	@EmailAddress nvarchar(1024),
	@MobileNumber nvarchar(10),
	@AddressLine1 nvarchar(1024),
	@AddressLine2 nvarchar(1024),
	@SuburbID int
AS
BEGIN
	UPDATE Patient
	SET FirstName = @FirstName,
		LastName = @LastName,
		EmailAddress = @EmailAddress,
		MobileNumber = @MobileNumber,
		AddressLine1 = @AddressLine1,
		AddressLine2 = @AddressLine2,
		SuburbID = @SuburbID
	WHERE PatientID = @PatientID
END
GO