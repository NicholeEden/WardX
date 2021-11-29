USE HWMS06DB
GO
CREATE OR ALTER PROCEDURE sp_GetDoctorInspectionByPatient
	@PatientID int
AS
BEGIN
SET NOCOUNT ON
	SELECT DoctorID, PatientID, Date, Comments
	FROM DoctorInspection
	WHERE PatientID = @PatientID
END