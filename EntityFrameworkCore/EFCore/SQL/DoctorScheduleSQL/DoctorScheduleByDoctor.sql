
CREATE OR ALTER PROCEDURE sp_GetDoctorScheduleByDoctor
    @DoctorID int
AS
BEGIN 
SET NOCOUNT ON
    SELECT ScheduleID, DoctorID, MonthID, ShiftSlotID, isAvailable
    FROM DoctorSchedule
    WHERE DoctorID = @DoctorID
END