
CREATE OR ALTER PROCEDURE sp_GetNurseSchedule

AS
SET NOCOUNT ON
BEGIN
    SELECT *
    FROM [Month] m, NurseSchedule ns, StaffMember s, ShiftSlot sh
    WHERE ns.MonthID = m.MonthID
    AND ns.NurseID = s.StaffID
    AND ns.ShiftSlotID = sh.ShiftSlotID

END
GO