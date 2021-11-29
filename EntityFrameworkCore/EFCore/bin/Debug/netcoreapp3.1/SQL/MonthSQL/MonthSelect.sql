CREATE OR ALTER PROCEDURE sp_SelectMonth
    @MonthID int
AS
SET NOCOUNT ON
BEGIN
    SELECT *
    FROM [Month] m
    WHERE m.MonthID = @MonthID
END
GO