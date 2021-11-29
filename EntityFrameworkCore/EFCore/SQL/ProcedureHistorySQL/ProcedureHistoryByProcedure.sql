
CREATE OR ALTER PROCEDURE sp_GetProcedureHistoryByProcedure
  @Procedure string
AS
SET NOCOUNT ON
BEGIN
    SELECT ProcedureID, AppointmentDate, Time, [Procedure] , PatientID, Notes
    FROM ProcedureHistory
    WHERE [Procedure] = @Procedure
END
GO