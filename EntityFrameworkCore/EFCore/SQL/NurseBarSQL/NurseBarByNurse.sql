﻿
CREATE OR ALTER PROCEDURE sp_GetNurseBarByNurse
  @NurseID int
AS
SET NOCOUNT ON
BEGIN
    SELECT  BarID
    FROM NurseBar
    WHERE NurseID = @NurseID
END
GO