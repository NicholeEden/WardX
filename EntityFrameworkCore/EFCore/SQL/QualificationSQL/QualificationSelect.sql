
CREATE OR ALTER PROCEDURE sp_SelectQualification
AS
BEGIN
SET NOCOUNT ON
    SELECT QualificationID, Title, [Description]
    FROM Qualification
END