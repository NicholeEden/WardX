

CREATE OR ALTER PROCEDURE sp_GetStaffMember
AS
SET NOCOUNT ON
	BEGIN
	    SELECT StaffID, FirstName, LastName, EmployeeID, EmailAddress, AddressLine1, AddressLine2, WorkNumber, MobileNumber, isActive, StaffType, SuburbID, UserID 
		FROM StaffMember
END
GO
