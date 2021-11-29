
CREATE OR ALTER PROCEDURE sp_GetNurseSchedule

@ShiftSlotID int

AS
SET NOCOUNT ON
BEGIN
    SELECT ShiftSlotID
    FROM NurseSchedule
    WHERE ShiftSlotID=@ShiftSlotID
END
GO