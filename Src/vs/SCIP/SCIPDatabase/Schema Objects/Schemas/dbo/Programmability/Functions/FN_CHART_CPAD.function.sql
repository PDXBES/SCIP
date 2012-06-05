CREATE FUNCTION [dbo].[FN_CHART_CPAD]
(
	@beginYear int, 
	@endYear int
)
RETURNS TABLE 
AS
RETURN (
  SELECT reporting_category, AVG(cost) AS cost
  FROM VW_CLEANING_ACTIVITIES_BY_DRIVER_TYPE_FISCAL_YEAR
  WHERE fiscal_year BETWEEN @beginYear AND @endYear
  GROUP BY reporting_category
)