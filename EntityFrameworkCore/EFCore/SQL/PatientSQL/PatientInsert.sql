CREATE OR ALTER PROCEDURE sp_InsertPatient
    @FirstName nvarchar(128),
	@LastName nvarchar(128),
	@Gender int,
	@IDNumber nvarchar(13),
	@DOB datetime2(7),
	@EmailAddress nvarchar(1024),
	@MobileNumber nvarchar(10),
	@AddressLine1 nvarchar(1024),
	@AddressLine2 nvarchar(1024) = '',
	@SuburbID int,
	@PatientID int OUTPUT
AS
BEGIN
	INSERT INTO Patient ( FirstName, LastName, Gender, IDNumber, DOB, EmailAddress, MobileNumber, AddressLine1, AddressLine2, SuburbID )
	VALUES ( @FirstName, @LastName, @Gender, @IDNumber, @DOB, @EmailAddress, @MobileNumber, @AddressLine1, @AddressLine2, @SuburbID )
	SET @PatientID = SCOPE_IDENTITY()
END
GO