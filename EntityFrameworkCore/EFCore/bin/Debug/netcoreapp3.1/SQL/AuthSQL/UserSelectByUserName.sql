CREATE OR ALTER PROCEDURE sp_SelectUserByUserName
    @UserName nvarchar(128)
AS
BEGIN
    SELECT s.StaffID, s.EmployeeID, s.FirstName, s.LastName, s.Gender, s.isActive, s.MobileNumber, s.WorkNumber, s.EmailAddress,
           s.AddressLine1, s.AddressLine2, s.StaffType, s.SuburbID, u.UserID, u.UserName, u.PasswordHash, u.Avatar, ur.RoleID
    FROM [User] u, StaffMember s, UserRole ur
    WHERE @UserName = u.UserName AND u.UserID = s.UserID AND u.UserID = ur.UserID
END