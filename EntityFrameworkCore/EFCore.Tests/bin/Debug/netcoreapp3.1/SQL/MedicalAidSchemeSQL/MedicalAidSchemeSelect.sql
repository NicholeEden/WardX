CREATE OR ALTER PROCEDURE sp_SelectMedicalAidScheme
AS
BEGIN
SET NOCOUNT ON
    SELECT *
    FROM MedicalAidScheme
END
GO