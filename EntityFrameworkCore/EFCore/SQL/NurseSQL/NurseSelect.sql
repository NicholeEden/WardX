CREATE OR ALTER PROCEDURE sp_SelectNurse
   
AS
BEGIN
    SELECT StaffID, FirstName, LastName, NurseID
    FROM Nurse, StaffMember
    WHERE StaffID = NurseID
END
