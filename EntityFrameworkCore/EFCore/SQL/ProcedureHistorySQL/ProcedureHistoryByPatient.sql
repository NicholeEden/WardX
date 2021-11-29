
CREATE OR ALTER PROCEDURE sp_GetProcedureHistoryByPatient
  @PatientID int
AS
SET NOCOUNT ON
BEGIN
    SELECT ProcedureID, AppointmentDate, Time, [Procedure] , PatientID, Notes
    FROM ProcedureHistory
    WHERE PatientID = @PatientID
END
GO