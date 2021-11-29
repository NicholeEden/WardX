CREATE OR ALTER PROCEDURE sp_SelectAllNurse
   
AS
BEGIN
    SELECT *
    FROM Nurse n, StaffMember s, NurseType nt, Specialization sp
    WHERE n.NurseID = s.StaffID
    AND n.NurseTypeID = nt.NurseTypeID
    AND n.SpecializationID = sp.SpecializationID
END
