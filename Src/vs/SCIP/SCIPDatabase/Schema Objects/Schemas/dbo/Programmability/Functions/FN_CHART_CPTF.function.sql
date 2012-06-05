CREATE FUNCTION [dbo].[FN_CHART_CPTF]
(
	@beginYear int, 
	@endYear int
)
RETURNS TABLE 
AS
RETURN (
  SELECT reporting_category, SUM(length_ft) AS length_ft
  FROM VW_CLEANING_ACTIVITIES_BY_DRIVER_TYPE_FISCAL_YEAR
  WHERE fiscal_year BETWEEN @beginYear AND @endYear
  GROUP BY reporting_category
)