CREATE OR ALTER PROCEDURE sp_SelectDoctorGP
AS
BEGIN
SET NOCOUNT ON
    SELECT *
    FROM Doctor d, StaffMember s
    WHERE DoctorID = StaffID
    AND DoctorTypeID = 110
END
GO