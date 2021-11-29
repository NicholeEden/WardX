CREATE OR ALTER PROCEDURE sp_GetClocking
	@MonthID int,
	@NurseID int
AS
SET NOCOUNT ON
BEGIN
    SELECT *
	FROM Clocking c, StaffMember s, [Month] m, NurseSchedule ns
    WHERE m.MonthID = ns.MonthID
    AND ns.NurseID = s.StaffID
    AND ns.NurseID = c.NurseID
    AND ns.MonthID = @MonthID
END