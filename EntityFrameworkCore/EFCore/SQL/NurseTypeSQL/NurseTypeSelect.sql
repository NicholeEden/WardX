
CREATE OR ALTER PROCEDURE sp_SelectNurseType
AS
SET NOCOUNT ON
BEGIN
    SELECT NurseTypeID, [Description]
    FROM NurseType
END
GO