CREATE OR ALTER PROCEDURE sp_SelectRolesByUserID
    @UserID int
AS
BEGIN
    SELECT r.RoleID, r.RoleName
    FROM [Role] r, UserRole ur
    WHERE @UserID = ur.UserID AND ur.RoleID = r.RoleID
END