
CREATE OR ALTER PROCEDURE sp_SelectVitalSign
AS
BEGIN 
SET NOCOUNT ON
SELECT  VitalSignID,[Date],Hypoglycemia,BodyTemperature,PulseRate,BloodPressure
FROM VitalSign
END