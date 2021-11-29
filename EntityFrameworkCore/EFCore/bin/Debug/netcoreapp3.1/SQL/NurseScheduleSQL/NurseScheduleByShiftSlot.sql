
CREATE OR ALTER PROCEDURE sp_GetNurseScheduleByShiftSlot

  @ShiftSlotID int

AS
SET NOCOUNT ON
BEGIN
    SELECT *
    FROM NurseSchedule ns, StaffMember sm, [Month] m, Nurse n, ShiftSlot s
    WHERE ns.NurseID = n.NurseID 
    AND ns.MonthID = m.MonthID 
    AND ns.ShiftSlotID = s.ShiftSlotID 
    AND sm.StaffID = n.NurseID
    AND ns.ShiftSlotID = @ShiftSlotID
END
GO