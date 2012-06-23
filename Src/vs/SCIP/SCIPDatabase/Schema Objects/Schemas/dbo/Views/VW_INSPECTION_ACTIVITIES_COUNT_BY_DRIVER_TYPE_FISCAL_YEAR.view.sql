CREATE VIEW [dbo].[VW_INSPECTION_ACTIVITIES_COUNT_BY_DRIVER_TYPE_FISCAL_YEAR]
	AS
  SELECT driver_type, reporting_category, fiscal_year, COUNT(compkey) AS count_assets_covered, 
    CONVERT(decimal(5,2), ROUND(CONVERT(decimal(7,2), COUNT(compkey))/[dbo].FN_ASSETS_TOTAL_COUNT(C.asset_set_id)*100, 2)) AS percent_assets_covered
  FROM (ACTIVITIES_FOR_PROCESSING A INNER JOIN ACTIVITY_TYPES B ON (A.activity_type_id = B.activity_type_id)) INNER JOIN ALTERNATIVES C ON (A.alternative_id = C.alternative_id)
  WHERE B.name = 'Inspection'
  GROUP BY C.asset_set_id, driver_type, reporting_category, fiscal_year