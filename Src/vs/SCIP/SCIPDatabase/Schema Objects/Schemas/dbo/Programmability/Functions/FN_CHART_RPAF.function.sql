CREATE FUNCTION [dbo].[FN_CHART_RPAF]
(
	@beginYear int, 
	@endYear int
)
RETURNS TABLE 
AS
RETURN (
  SELECT reporting_category, AVG(length_ft) AS length_ft
  FROM VW_ROOT_ACTIVITIES_BY_DRIVER_TYPE_FISCAL_YEAR
  WHERE fiscal_year BETWEEN @beginYear AND @endYear
  GROUP BY reporting_category
)