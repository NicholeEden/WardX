CREATE OR ALTER PROCEDURE sp_SelectTreatmentTimeline
    @PatientID int
AS
BEGIN
SET NOCOUNT ON
    SELECT *
    FROM Treatment tr, TreatmentType ty, StaffMember st
    WHERE @PatientID = tr.PatientID
    AND tr.TreatmentTypeID = ty.TreatmentTypeID
    AND tr.NurseID = st.StaffID
END
GO