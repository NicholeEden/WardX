

CREATE OR ALTER PROCEDURE sp_GetNurseScheduleByID
  @ScheduleID int
AS
SET NOCOUNT ON
BEGIN
    SELECT ScheduleID, NurseID, MonthID, ShiftSlotID, isAvailable
    FROM NurseSchedule
    WHERE ScheduleID = @ScheduleID
END
GO