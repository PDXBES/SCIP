CREATE VIEW [dbo].[VW_EXPORT_ALL_ACTIVITIES_FOR_MAPPING]
	AS
  SELECT A.COMPKEY, DATEPART(year, A.activity_date) AS NEXTACTIVI, A.driver_type + ' ' + A.activity_type AS ACTIVITY, A.activity_type, A.cost, E.basin_id
  FROM ((VW_ALL_ACTIVITIES A INNER JOIN DRIVERS B ON (A.DRIVER_ID = B.driver_id AND A.alternative_id = B.alternative_id)) INNER JOIN ACTIVITY_TYPES C ON (A.ACTIVITY_TYPE_ID = C.activity_type_id)) INNER JOIN BASINS E ON (A.basin = E.name)
