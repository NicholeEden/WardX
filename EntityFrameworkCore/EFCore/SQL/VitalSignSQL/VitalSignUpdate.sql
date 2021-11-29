
USE HWMS06DB
GO
CREATE OR ALTER PROCEDURE sp_UpdateVitalSign
	@VitalSignID int
AS
BEGIN
SET NOCOUNT ON
UPDATE VitalSign
	 SET [Date]=@Date,Hypoglycemia=@Hypoglycemia,BodyTemperature=@BodyTemperature,
	PulseRate=@PulseRate,BloodPressure=@BloodPressure
	WHERE VitalSignID=@VitalSignID
END