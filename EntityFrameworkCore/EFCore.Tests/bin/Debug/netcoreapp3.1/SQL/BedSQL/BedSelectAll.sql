CREATE OR ALTER PROCEDURE sp_SelectAllBeds

AS
SET NOCOUNT ON
BEGIN
    SELECT *
    FROM Bed
END
GO