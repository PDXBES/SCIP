CREATE FUNCTION [dbo].[FN_CHART_CPTD]
(
	@beginYear int, 
	@endYear int,
  @alternative_id INT
)
RETURNS TABLE 
AS
RETURN (
  SELECT reporting_category, SUM(cost) AS cost
  FROM VW_CLEANING_ACTIVITIES_BY_DRIVER_TYPE_FISCAL_YEAR
  WHERE (fiscal_year BETWEEN @beginYear AND @endYear) AND (alternative_id = @alternative_id)
  GROUP BY reporting_category
)