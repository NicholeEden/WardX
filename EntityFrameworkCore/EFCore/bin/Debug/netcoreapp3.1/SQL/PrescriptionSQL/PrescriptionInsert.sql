CREATE OR ALTER PROCEDURE sp_InsertPrescription 
@medicationID int, 
@DoctorID int,
@Dosage float,
@Instructions nvarchar(1024),
@AdmissionFileID int
AS
SET NOCOUNT ON
BEGIN
INSERT INTO Prescription(MedicationID, DoctorID, Dosage, DateIssued ,Instruction)
VALUES (@medicationID , @DoctorID , @Dosage , GETDATE() , @Instructions )

UPDATE AdmissionFile
SET PrescriptionID=SCOPE_IDENTITY()
WHERE AdmissionFileID=@AdmissionFileID
END