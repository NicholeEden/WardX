

CREATE OR ALTER PROCEDURE sp_SelectAdmissionFile
AS
SET NOCOUNT ON
	BEGIN
		SELECT *
		FROM AdmissionFile
	END
GO