CREATE OR ALTER PROCEDURE sp_SelectPatientByName
	@FirstName nvarchar(128)
AS 
BEGIN 
SET NOCOUNT ON
	SELECT *
	FROM Patient
	WHERE FirstName LIKE '%'+@FirstName+'%'
		OR LastName LIKE '%'+@FirstName+'%'
	ORDER BY FirstName, LastName
END