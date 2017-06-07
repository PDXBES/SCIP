CREATE FUNCTION [dbo].[FN_CHART_RLTF]
(
	@beginYear int, 
	@endYear int,
  @alternative_id INT
)
RETURNS TABLE 
AS
RETURN (
  SELECT fiscal_year, 
      ISNULL(SUM([Root Control High]), 0) AS [Root Control High],
      ISNULL(SUM([Root Control High (>15 in)]), 0) AS [Root Control High (>15 in)],
      ISNULL(SUM([Root Control Medium]), 0) AS [Root Control Medium], 
      ISNULL(SUM([Root Control Medium (>15 in)]), 0) AS [Root Control Medium (>15 in)]
  FROM (
    SELECT * FROM VW_ROOT_ACTIVITIES_BY_DRIVER_TYPE_FISCAL_YEAR 
    WHERE (fiscal_year BETWEEN @beginYear AND @endYear) AND
      (alternative_id = @alternative_id)) PS
  PIVOT
  (SUM(length_ft) FOR reporting_category IN 
    (
      [Root Control High],
      [Root Control High (>15 in)],
      [Root Control Medium], 
      [Root Control Medium (>15 in)]
    )) AS PVT
  GROUP BY fiscal_year

)