CREATE OR ALTER PROCEDURE sp_InsertDiagnosis
           @MedicalConditionID int,
           @DiagnosedBy int,
           @DiagnosisDetals nvarchar(1024) = '',
           @DiagnosisDate datetime2(7),
           @DiagnosisID int OUTPUT
AS
BEGIN
	INSERT INTO [dbo].[Diagnosis]
           ([MedicalConditionID]
           ,[DiagnosedBy]
           ,[DiagnosisDetals]
           ,[DiagnosisDate])
	VALUES (@MedicalConditionID
           ,@DiagnosedBy
           ,@DiagnosisDetals
           ,@DiagnosisDate)
    SET @DiagnosisID = SCOPE_IDENTITY()
END
GO