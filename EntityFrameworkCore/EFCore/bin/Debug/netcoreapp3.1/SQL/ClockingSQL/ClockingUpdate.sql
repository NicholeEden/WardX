CREATE OR ALTER PROCEDURE sp_ClockOut
	@NurseID int
AS
BEGIN
    UPDATE Clocking
	SET ClockOutTime = GETDATE(), isClockedIn = 'False'
	WHERE NurseID = @NurseID AND isClockedIn = 'True'
END