
CREATE OR ALTER PROCEDURE sp_InsertClerk
    @ClerkID int,
    @QualificationID int
AS
BEGIN
    INSERT INTO Receptionist (ClerkID, QualificationID)
    VALUES (@ClerkID, @QualificationID)
    RETURN SCOPE_IDENTITY()
END
