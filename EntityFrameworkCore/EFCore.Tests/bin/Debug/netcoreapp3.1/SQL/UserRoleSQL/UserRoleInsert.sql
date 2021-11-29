
CREATE OR ALTER PROCEDURE sp_InsertUserRole
    @UserID int, 
    @RoleID int

AS
BEGIN
    INSERT INTO UserRole (UserID, RoleID)
    VALUES (@UserID, @RoleID)
END