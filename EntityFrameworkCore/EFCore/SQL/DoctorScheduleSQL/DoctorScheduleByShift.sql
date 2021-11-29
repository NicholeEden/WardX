
CREATE OR ALTER PROCEDURE sp_GetDoctorScheduleByShift
    @ShiftSlotID int
AS
BEGIN 
SET NOCOUNT ON
    SELECT ScheduleID, DoctorID, MonthID, ShiftSlotID, isAvailable
    FROM DoctorSchedule
    WHERE ShiftSlotID = @ShiftSlotID
END