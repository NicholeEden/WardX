CREATE OR ALTER PROCEDURE sp_SelectRoleByRoleName
    @RoleName nvarchar(1024)
AS
BEGIN
    SELECT RoleID, RoleName
    FROM [Role]
    WHERE @RoleName = RoleName
END