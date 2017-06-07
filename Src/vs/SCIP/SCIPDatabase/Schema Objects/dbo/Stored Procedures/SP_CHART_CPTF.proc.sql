CREATE PROCEDURE [dbo].[SP_CHART_CPTF]
	@beginYear int = 2012, 
	@endYear int = 2023
AS
  SELECT reporting_category, SUM(length_ft) AS length_ft
  FROM VW_CLEANING_ACTIVITIES_BY_DRIVER_TYPE_FISCAL_YEAR
  WHERE fiscal_year BETWEEN @beginYear AND @endYear
  GROUP BY reporting_category