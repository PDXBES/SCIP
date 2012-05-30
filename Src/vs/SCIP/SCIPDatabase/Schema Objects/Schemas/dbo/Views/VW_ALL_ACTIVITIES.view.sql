CREATE VIEW [dbo].[VW_ALL_ACTIVITIES]
	AS
  SELECT A.[activity_id]
      ,A.[compkey]
      ,A.[driver_id]
      ,E.length_ft
      ,E.diamwidth_inches
      ,E.height_inches
      ,F.name AS basin
      ,G.name AS DISTRICT
      ,A.[activity_date]
      ,A.[cost]
      ,A.[activity_type_id]
      ,A.[alternative_id]
      ,CASE WHEN DATEPART(q, A.activity_date) IN (1,2) THEN DATEPART(year, A.activity_date) ELSE DATEPART(year, A.activity_date) + 1 END AS fiscal_year
      ,C.name AS driver_type
      ,H.name AS activity_type
      ,C.hansen_activity_code
      ,B.frequency_years
      ,D.last_inspection_date
      ,D.last_root_management_date
      ,D.last_cleaning_date
  FROM (((((([ACTIVITIES] A INNER JOIN VW_CONTROLLING_DRIVERS B ON (A.driver_id = B.driver_id)) INNER JOIN DRIVER_TYPES C ON (B.driver_type_id = C.driver_type_id)) INNER JOIN VW_LAST_ACTIVITY_DATES D ON (A.compkey = D.compkey)) INNER JOIN ASSETS E ON (A.compkey = E.COMPKEY)) INNER JOIN BASINS F ON (E.basin_id = F.basin_id)) INNER JOIN DISTRICTS G ON (E.district_id = G.district_id)) INNER JOIN ACTIVITY_TYPES H ON (A.activity_type_id = H.activity_type_id)
