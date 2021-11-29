USE HWMS06DB
GO
CREATE OR ALTER PROCEDURE sp_GetDoctorInspectionByDoctor
	@DoctorID int
AS
BEGIN
SET NOCOUNT ON
	SELECT DoctorID, PatientID, Date, Comments
	FROM DoctorInspection
	WHERE DoctorID = @DoctorID
END