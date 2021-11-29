
CREATE OR ALTER PROCEDURE sp_InsertNurse
    @NurseID int,
    @SpecializationID int,
    @isWardManager bit,
    @isHeadNurse bit,
    @NurseTypeID int
AS
BEGIN
    INSERT INTO Nurse (NurseID, SpecializationID, isWardManager, isHeadNurse, NurseTypeID)
    VALUES (@NurseID, @SpecializationID, @isWardManager, @isHeadNurse, @NurseTypeID)
    RETURN SCOPE_IDENTITY()
END
