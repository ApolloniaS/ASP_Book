﻿CREATE VIEW [dbo].[V_RandomNb]
	AS SELECT FLOOR(RAND()*10) AS RandomNb
