CREATE OR ALTER PROCEDURE sp_InsertMedicalAid
    @MedicalAidSchemeID INT,
    @MedicalAidPlanID INT,
    @MemberNumber NVARCHAR(128),
    @PrincipalFirstName NVARCHAR(1024),
    @PrincipalLastName NVARCHAR(1024),
    @DependantCode NVARCHAR(128),
    @PatientID INT
AS
BEGIN
    INSERT INTO MedicalAid ( MedicalAidPlanID, MedicalAidSchemeID, MemberNumber, PrincipalFirstName, PrincipalLastName, DependantCode, PatientID )
    VALUES ( @MedicalAidPlanID, @MedicalAidSchemeID, @MemberNumber, @PrincipalFirstName, @PrincipalLastName, @DependantCode, @PatientID )
END
GO