CREATE FUNCTION [dbo].[SF_GenerateSalt]
()
RETURNS CHAR(8)
AS
BEGIN
	DECLARE @generatedSalt NVARCHAR(8)
	DECLARE @randVal SMALLINT
	DECLARE @i SMALLINT
	SET @i = 0;
	WHILE @i < 8
	BEGIN
		SET @randVal = (SELECT RandomNb FROM V_RandomNb)
		SET @generatedSalt = CONCAT(@generatedSalt, @randVal)
		SET @i = @i + 1;
	END

	RETURN @generatedSalt
END
