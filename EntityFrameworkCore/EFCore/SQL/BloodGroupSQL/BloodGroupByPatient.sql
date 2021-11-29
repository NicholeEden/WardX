USE HWMS06DB
GO
CREATE OR ALTER PROCEDURE sp_SelectBloodGroupByID
@PatientID int

AS
SET NOCOUNT ON
	BEGIN
      SELECT BloodGroupName, [Description]
      FROM BloodGroup, MedicalHistory 
      WHERE BloodGroup.BloodGroupID = MedicalHistory.BloodGroupID AND
      PatientID=@PatientID
    END
GO