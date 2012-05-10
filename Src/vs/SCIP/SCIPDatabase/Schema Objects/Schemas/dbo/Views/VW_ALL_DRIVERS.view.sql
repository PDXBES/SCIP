CREATE VIEW [dbo].[VW_ALL_DRIVERS]
	AS
  SELECT A.[driver_id]
        ,A.[compkey]
        ,D.length_ft
        ,D.diamwidth_inches
        ,D.height_inches
        ,E.name AS basin
        ,F.name AS district
        ,B.name AS driver_type
        ,B.[rank] as driver_rank
        ,C.name AS activity_type
        ,CASE WHEN A.[override_cost_per_ft] IS NULL THEN B.default_cost_per_ft ELSE A.[override_cost_per_ft] END AS cost_per_ft
        ,CASE WHEN A.[override_frequency_years] IS NULL THEN B.default_frequency_years ELSE A.[override_frequency_years] END AS frequency_years
        ,A.[alternative_id]
        ,A.[updated_by]
        ,A.[update_date]
  FROM (((([DRIVERS] A INNER JOIN DRIVER_TYPES B ON A.driver_type_id = B.driver_type_id) INNER JOIN ACTIVITY_TYPES C ON B.activity_type_id = C.activity_type_id) INNER JOIN ASSETS D ON A.compkey = D.compkey) INNER JOIN BASINS E ON (E.basin_id = D.basin_id)) INNER JOIN DISTRICTS F ON (F.district_id = D.district_id)
