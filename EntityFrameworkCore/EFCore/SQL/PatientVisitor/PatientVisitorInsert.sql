USE HWMS06DB
GO
CREATE OR ALTER PROCEDURE sp_InsertPatientVisitor

@AdmissionID nvarchar(50),
@VisitDate datetime,
@TimeIn datetime,
@TimeOut datetime,
@FirstName nvarchar(50),
@LastName nvarchar(50),
@isCheckedIn bit

AS
BEGIN

SET NOCOUNT ON
INSERT INTO PatientMovement (AdmissionID,TimeIn,TimeOut,FirstName,LastName,isCheckedOut)
VALUES (@AdmissionID,@VisitDate,@TimeIn,@TimeOut,@FirstName,@LastName,@isCheckedOut)
END