
CREATE OR ALTER PROCEDURE sp_GetDoctorScheduleByID
    @ScheduleID int
AS
BEGIN 
SET NOCOUNT ON
    SELECT ScheduleID, DoctorID, MonthID, ShiftSlotID, isAvailable
    FROM DoctorSchedule
    WHERE ScheduleID = @ScheduleID
END