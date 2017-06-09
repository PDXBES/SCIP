﻿CREATE VIEW [dbo].[VW_NEXT_ACTIVITIES_BY_COMPKEY]
	AS
  SELECT A.compkey AS COMPKEY, A.driver_id AS DRIVER_ID, C.activity_type_id AS ACTIVITY_TYPE_ID, MIN(A.activity_date) AS NEXTACTIVI
FROM (ACTIVITIES_FOR_PROCESSING A INNER JOIN BASINS B ON (A.basin = B.name)) INNER JOIN ACTIVITY_TYPES C ON (A.activity_type = C.name)
GROUP BY COMPKEY, DRIVER_ID, C.activity_type_id