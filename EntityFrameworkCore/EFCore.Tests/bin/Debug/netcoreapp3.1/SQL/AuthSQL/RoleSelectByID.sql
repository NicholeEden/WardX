CREATE OR ALTER PROCEDURE sp_SelectRoleByID
    @RoleID int
AS
BEGIN
    SELECT RoleID, RoleName
    FROM [Role]
    WHERE @RoleID = RoleID
END