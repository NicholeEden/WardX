
CREATE OR ALTER PROCEDURE sp_InsertNurseSchedule

@isAvailable bit,
@ShiftSlotID int,
@NurseID int,
@MonthID int

AS
BEGIN
SET NOCOUNT ON
INSERT INTO NurseSchedule (isAvailable, ShiftSlotID, NurseID, MonthID)
VALUES (@isAvailable, @ShiftSlotID, @NurseID, @MonthID)

END