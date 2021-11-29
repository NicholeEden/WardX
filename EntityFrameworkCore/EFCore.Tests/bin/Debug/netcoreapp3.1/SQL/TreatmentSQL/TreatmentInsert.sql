CREATE OR ALTER PROCEDURE sp_InsertTreatment 
@NurseID int, 
@PatientID int,
@TreatmentTypeID int,
@ObservationNotes nvarchar(1024) = ''
AS
SET NOCOUNT ON
BEGIN
INSERT INTO Treatment(NurseID, PatientID, TreatmentTypeID, ObservationNotes )
VALUES (@NurseID , @PatientID , @TreatmentTypeID , @ObservationNotes )
END