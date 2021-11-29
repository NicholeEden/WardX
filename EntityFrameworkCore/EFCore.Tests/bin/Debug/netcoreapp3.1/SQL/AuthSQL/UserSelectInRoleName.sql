CREATE OR ALTER PROCEDURE sp_SelectUsersInRoleName
    @RoleName nvarchar(1024)
AS
BEGIN
    SELECT s.StaffID, s.EmployeeID, s.FirstName, s.LastName, s.Gender, s.isActive, s.MobileNumber, s.WorkNumber, s.EmailAddress,
           s.AddressLine1, s.AddressLine2, s.StaffType, s.SuburbID, u.UserID, u.UserName, u.PasswordHash, u.Avatar
    FROM [User] u, StaffMember s
    WHERE s.UserID = u.UserID AND s.UserID IN 
        (SELECT ur.UserID FROM [UserRole] ur WHERE ur.RoleID IN 
            (SELECT RoleID FROM [Role] WHERE @RoleName = RoleName))
END