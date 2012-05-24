CREATE PROCEDURE [dbo].[SP_ACTIVITIES_COUNT_BY_DRIVER_TYPE_BETWEEN_YEARS]
	@beginYear int = 2012, 
	@endYear int = 2017
AS
	SELECT A.activity_type, A.driver_type, count(*) AS compkey_count
  FROM
  (SELECT activity_type, driver_type, compkey
  FROM VW_ALL_ACTIVITIES
  WHERE fiscal_year BETWEEN @beginYear AND @endYear
  GROUP BY activity_type, driver_type, compkey) AS A
  GROUP BY A.activity_type, A.driver_type
  ORDER BY A.activity_type, A.driver_type