
CREATE OR ALTER PROCEDURE sp_InsertStaffMember
    @FirstName nvarchar(50),
    @LastName nvarchar(50), 
    @EmployeeID nvarchar(13), 
    @EmailAddress nvarchar(50), 
    @AddressLine1 nvarchar(50), 
    @AddressLine2 nvarchar(50), 
    @WorkNumber nvarchar(10), 
    @MobileNumber nvarchar(10),
    @StaffType nvarchar(2), 
    @UserID int,
    @SuburbID int,
    @isActive bit

AS
BEGIN
    INSERT INTO StaffMember (FirstName, LastName, EmployeeID, EmailAddress, AddressLine1, AddressLine2, WorkNumber, MobileNumber, StaffType, UserID, SuburbID, isActive)
    VALUES (@FirstName, @LastName, @EmployeeID, @EmailAddress, @AddressLine1, @AddressLine2, @WorkNumber, @MobileNumber, @StaffType, @UserID, @SuburbID, @isActive)
    RETURN SCOPE_IDENTITY()
END