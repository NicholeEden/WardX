USE HWMS06DB
GO
CREATE OR ALTER PROCEDURE sp_GetDoctorInspection
AS
BEGIN
SET NOCOUNT ON
SELECT DoctorInspectionID, DoctorID, PatientID, Date, Comments
FROM DoctorInspection
END