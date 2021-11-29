
CREATE OR ALTER PROCEDURE sp_UpdateNurseSchedule

@ScheduleID int,
@isAvailable bit,
@ShiftSlotID int,
@NurseID int,
@MonthID int

AS
BEGIN
SET NOCOUNT ON
UPDATE  NurseSchedule SET isAvailable= @isAvailable, ShiftSlotID=@ShiftSlotID, NurseID=@NurseID, MonthID=@MonthID
WHERE ScheduleID=@ScheduleID
END