
CREATE OR ALTER PROCEDURE sp_GetProcedureHistoryByID
  @ProcedureID int
AS
SET NOCOUNT ON
BEGIN
    SELECT ProcedureID, AppointmentDate, Time, [Procedure] , PatientID, Notes
    FROM ProcedureHistory
    WHERE ProcedureID = @ProcedureID
END
GO