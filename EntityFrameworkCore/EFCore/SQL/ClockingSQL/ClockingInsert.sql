CREATE OR ALTER PROCEDURE sp_ClockIn
	@NurseID int
AS
BEGIN
    INSERT INTO Clocking (NurseID, ClockInTime, ClockOutTime, isClockedIn)
	VALUES (@NurseID, GETDATE(), GETDATE(), 'True')
END