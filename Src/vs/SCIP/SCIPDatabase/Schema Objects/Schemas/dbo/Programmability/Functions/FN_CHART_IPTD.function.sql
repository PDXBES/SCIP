CREATE FUNCTION [dbo].[FN_CHART_IPTD]
(
	@beginYear int, 
	@endYear int
)
RETURNS TABLE 
AS
RETURN (
  SELECT reporting_category, SUM(cost) AS cost
  FROM VW_INSPECTION_ACTIVITIES_BY_DRIVER_TYPE_FISCAL_YEAR
  WHERE fiscal_year BETWEEN @beginYear AND @endYear
  GROUP BY reporting_category
)