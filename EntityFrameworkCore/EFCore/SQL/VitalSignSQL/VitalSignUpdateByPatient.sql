
CREATE OR ALTER PROCEDURE sp_UpdateVitalSignByID
	@PatientID int
AS
BEGIN
SET NOCOUNT ON
	UPDATE VitalSign SET [Date]=@Date,Hypoglycemia=@Hypoglycemia,BodyTemperature=@BodyTemperature,
	PulseRate=@PulseRate,BloodPressure=@BloodPressure
	WHERE Patient.VitalSign = VitalSign.VitalSign AND PatientID=@PatientID
	
END