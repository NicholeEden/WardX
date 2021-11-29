
CREATE OR ALTER PROCEDURE sp_InsertVitalSign
   @BloodGroupID int,
   @BloodPressure nvarchar(50),
   @BMI nvarchar(50),
   @BodyTemperature nvarchar(50),
   @Hypoglycemia nvarchar(50),
   @PulseRate nvarchar(50),
   @Weight nvarchar(50),
   @VitalSignID int OUTPUT
AS
SET NOCOUNT ON
	BEGIN
       INSERT INTO VitalSign (BloodGroupID, BloodPressure, BMI, BodyTemperature, DateRecorded, Hypoglycemia, PulseRate, [Weight])
       VALUES (@BloodGroupID, @BloodPressure, @BMI, @BodyTemperature, GETDATE(), @Hypoglycemia, @PulseRate, @Weight)
       SET @VitalSignID = SCOPE_IDENTITY()
    END
GO
