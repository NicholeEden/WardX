
CREATE OR ALTER PROCEDURE sp_NurseByID
  @NurseID int
AS
SET NOCOUNT ON
BEGIN
    SELECT *
    FROM Nurse
    WHERE NurseID = @NurseID
END
GO