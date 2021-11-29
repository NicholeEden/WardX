USE HWMS06DB
GO
CREATE OR ALTER PROCEDURE sp_GetDoctorInspectionByID
	@DoctorInspectionID int
AS
BEGIN
SET NOCOUNT ON
	SELECT DoctorID, PatientID, Date, Comments
	FROM DoctorInspection
	WHERE DoctorInspectionID = @DoctorInspectionID
END