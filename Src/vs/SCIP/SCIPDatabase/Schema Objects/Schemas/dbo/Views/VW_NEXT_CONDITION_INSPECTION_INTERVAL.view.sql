CREATE VIEW [dbo].[VW_NEXT_CONDITION_INSPECTION_INTERVAL]
	AS
    SELECT 
     A.compkey
    ,CASE WHEN (ACCUM_RISK_INSPECT_YEAR - DATEPART(year, GetDate())) < 0 THEN 0 ELSE ACCUM_RISK_INSPECT_YEAR - DATEPART(year, GetDate()) END AS next_condition_inspection_interval_years
  FROM (ASSETS A INNER JOIN DRIVER_TYPES ON (DRIVER_TYPES.name = 'Condition' AND (A.diamWidth_inches <= 36 AND A.height_inches <= 36))) INNER JOIN
    (SELECT	compkey, ACCUM_RISK_INSPECT_YEAR
     FROM	REHAB10FTSEGS
     WHERE	mlinkid < 40000000 AND (remarks = N'BES' OR remarks = N'DNRV') AND ACCUM_RISK_INSPECT_YEAR IS NOT NULL) AS X ON	A.COMPKEY = X.COMPKEY
  UNION
  SELECT
     A.compkey
    ,CASE WHEN (ACCUM_RISK_INSPECT_YEAR - DATEPART(year, GetDate())) < 0 THEN 0 ELSE ACCUM_RISK_INSPECT_YEAR - DATEPART(year, GetDate()) END AS next_condition_inspection_interval_years
  FROM	ASSETS A INNER JOIN DRIVER_TYPES ON	(DRIVER_TYPES.name = 'ConditionLarge' AND (A.diamWidth_inches > 36 OR A.height_inches > 36)) INNER JOIN
    (SELECT	compkey, ACCUM_RISK_INSPECT_YEAR
     FROM	REHAB10FTSEGS
     WHERE mlinkid < 40000000 AND (remarks = N'BES' OR remarks = N'DNRV') AND ACCUM_RISK_INSPECT_YEAR IS NOT NULL) AS X ON	A.COMPKEY = X.COMPKEY