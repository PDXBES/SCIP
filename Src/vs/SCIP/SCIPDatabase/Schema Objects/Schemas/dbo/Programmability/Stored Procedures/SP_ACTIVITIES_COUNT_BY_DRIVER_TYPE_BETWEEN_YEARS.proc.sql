CREATE PROCEDURE [dbo].[SP_ACTIVITIES_COUNT_BY_DRIVER_TYPE_BETWEEN_YEARS]
	@beginYear int = 2012, 
	@endYear int = 2017
AS
	SELECT A.activity_type, A.driver_type, A.reporting_category, count(*) AS compkey_count, CONVERT(decimal(5,2),ROUND(CONVERT(decimal(10,2), count(*))/[dbo].FN_ASSETS_TOTAL_COUNT()*100, 2)) AS compkey_percent_covered, CONVERT(decimal(10,2), CONVERT(decimal(10,2), count(*))/(ABS(@endYear-@beginYear)+1)) AS annualized_compkey_count, CONVERT(decimal(5,2),ROUND(CONVERT(decimal(10,2), count(*))/[dbo].FN_ASSETS_TOTAL_COUNT()/(ABS(@endYear-@beginYear)+1)*100, 2)) AS annualized_compkey_covered
  FROM
  (SELECT activity_type, driver_type, reporting_category, compkey
  FROM VW_ALL_ACTIVITIES
  WHERE fiscal_year BETWEEN @beginYear AND @endYear
  GROUP BY activity_type, driver_type, reporting_category, compkey) AS A
  GROUP BY A.activity_type, A.driver_type, A.reporting_category
  ORDER BY A.activity_type, A.driver_type, A.reporting_category