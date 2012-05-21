CREATE PROCEDURE [dbo].[SP_ANNUALIZED_CLEANING_ACTIVITIES_COUNT_BY_DRIVER_TYPE]
	@beginYear int = 2012, 
	@endYear int = 2017
AS
	SELECT driver_type, AVG(count_assets_covered) AS annualized_count_assets_covered, CONVERT(decimal(5,2),ROUND(AVG(percent_assets_covered),2)) AS annualized_percent_assets_covered
  FROM VW_CLEANING_ACTIVITIES_COUNT_BY_DRIVER_TYPE_FISCAL_YEAR
  WHERE fiscal_year BETWEEN @beginYear AND @endYear
  GROUP BY driver_type
