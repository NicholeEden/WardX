CREATE OR ALTER PROCEDURE sp_InsertReferral
           @PatientID int,
           @DiagnosisID int,
           @SpecialistID int,
           @ReferringDoctorID int,
           @Reason nvarchar(1024) = '',
           @AdmissionDate datetime2(7)
AS
BEGIN
	INSERT INTO [dbo].[Referral]
           ([PatientID]
           ,[DiagnosisID]
           ,[SpecialistID]
           ,[ReferringDoctorID]
           ,[Reason]
           ,[AdmissionDate]
           ,[isAdmitted])
	VALUES (@PatientID
           ,@DiagnosisID
           ,@SpecialistID
           ,@ReferringDoctorID
           ,@Reason
           ,@AdmissionDate
           ,'false')
END
GO