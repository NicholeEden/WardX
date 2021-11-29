
CREATE OR ALTER PROCEDURE sp_GetClockingByNurseID
	@NurseID int,
	@StartDate datetime2(7),
	@EndDate datetime2(7)

AS
BEGIN
SET NOCOUNT ON
	SELECT *
	FROM Clocking c, StaffMember s
	WHERE c.ClockInTime BETWEEN @StartDate AND @EndDate
	AND c.NurseID = @NurseID
	AND c.NurseID = s.StaffID
END