﻿
CREATE OR ALTER PROCEDURE sp_GetDoctorSchedule
AS
BEGIN 
SET NOCOUNT ON
    SELECT *
    FROM DoctorSchedule
END