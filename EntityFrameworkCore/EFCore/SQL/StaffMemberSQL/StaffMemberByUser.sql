
CREATE OR ALTER PROCEDURE sp_GetStaffMemberByUser
  @UserID int
AS
BEGIN 
SET NOCOUNT ON
    SELECT FirstName, LastName, EmailAddress, AddressLine1, AddressLine2, WorkNumber, MobileNumber, isActive, StaffType, SuburbID, UserID
    FROM StaffMember
    WHERE UserID = @UserID
END