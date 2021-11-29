
CREATE OR ALTER PROCEDURE sp_GetNurseScheduleByNurse
  @NurseID int,
  @MonthID int
AS
SET NOCOUNT ON
BEGIN
    SELECT *
    FROM [Month] m, NurseSchedule ns, StaffMember s, ShiftSlot sh
    WHERE m.MonthID = ns.MonthID
    AND ns.NurseID = s.StaffID
    AND ns.ShiftSlotID = sh.ShiftSlotID
    AND ns.MonthID = @MonthID
    AND ns.NurseID = @NurseID
END
GO