
CREATE OR ALTER PROCEDURE sp_InsertNurseBar
    @NurseID int, 
    @BarID int
AS
BEGIN
    INSERT INTO NurseBar (NurseID, BarID)
    VALUES (@NurseID, @BarID)
END
GO