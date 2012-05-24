CREATE VIEW [dbo].[VW_ROOT_ACTIVITIES_COUNT_BY_DRIVER_TYPE_FISCAL_YEAR]
	AS
  SELECT driver_type, fiscal_year, COUNT(compkey) AS count_assets_covered, CONVERT(decimal(5,2), ROUND(CONVERT(decimal(7,2), COUNT(compkey))/[dbo].FN_ASSETS_TOTAL_COUNT()*100, 2)) AS percent_assets_covered
  FROM VW_ALL_ACTIVITIES A INNER JOIN ACTIVITY_TYPES B ON (A.activity_type_id = B.activity_type_id)
  WHERE B.name = 'Root Management'
  GROUP BY driver_type, fiscal_year