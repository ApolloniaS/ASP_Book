﻿CREATE FUNCTION [dbo].[SF_PassWordEncryption]
(
	@password NVARCHAR(MAX),
	@salt CHAR(8)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	RETURN HASHBYTES('SHA2_256', CONCAT(SUBSTRING(@salt,0,4), @password, SUBSTRING(@salt, 4,4)))
END
