CREATE OR ALTER PROCEDURE sp_InsertNextOfKin
           @PatientID int,
           @FirstName nvarchar (1024),
           @LastName nvarchar (1024),
           @Relationship nvarchar (128),
           @EmailAddress nvarchar (1024),
           @MobileNumber nvarchar (10),
           @AddressLine1 nvarchar(1024),
           @AddressLine2 nvarchar(1024) = '',
           @SuburbID int,
           @Gender int
AS
BEGIN
	INSERT INTO [dbo].[NextOfKin]
           ([PatientID]
           ,[FirstName]
           ,[LastName]
           ,[Relationship]
           ,[EmailAddress]
           ,[MobileNumber]
           ,[AddressLine1]
           ,[AddressLine2]
           ,[SuburbID]
           ,[Gender])
	VALUES (@PatientID
           ,@FirstName
           ,@LastName
           ,@Relationship
           ,@EmailAddress
           ,@MobileNumber
           ,@AddressLine1
           ,@AddressLine2
           ,@SuburbID
           ,@Gender)
END
GO