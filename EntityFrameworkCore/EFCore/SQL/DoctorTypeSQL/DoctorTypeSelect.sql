﻿CREATE OR ALTER PROCEDURE sp_SelectDoctorType
AS
BEGIN
SET NOCOUNT ON
    SELECT *
    FROM DoctorType
END
GO