CREATE FUNCTION [dbo].[FN_CHART_ILTF]
(
	@beginYear int, 
	@endYear int,
  @alternative_id INT
)
RETURNS TABLE 
AS
RETURN (
  SELECT fiscal_year, 
      ISNULL(SUM([Condition]), 0) AS [Condition],
      ISNULL(SUM([Condition (>36 in)]), 0) AS [Condition (>36 in)],
      ISNULL(SUM([Preventive Maintenance]), 0) AS [Preventive Maintenance], 
      ISNULL(SUM([Preventive Maintenance (>36 in)]), 0) AS [Preventive Maintenance (>36 in)],
      ISNULL(SUM([Root Control High]), 0) AS [Root Control High], 
      ISNULL(SUM([Root Control High (>15 in, <=36 in)]), 0) AS [Root Control High (>15 in, <=36 in)],
      ISNULL(SUM([Root Control High (>36 in)]), 0) AS [Root Control High (>36 in)],
      ISNULL(SUM([Root Control Medium]), 0) AS [Root Control Medium], 
      ISNULL(SUM([Root Control Medium (>15 in, <=36 in)]), 0) AS [Root Control Medium (>15 in, <=36 in)],
      ISNULL(SUM([Root Control Medium (>36 in)]), 0) AS [Root Control Medium (>36 in)]
  FROM (
    SELECT * FROM VW_INSPECTION_ACTIVITIES_BY_DRIVER_TYPE_FISCAL_YEAR 
    WHERE (fiscal_year BETWEEN @beginYear AND @endYear) AND
      (alternative_id = @alternative_id)) PS
  PIVOT
  (SUM(length_ft) FOR reporting_category IN 
    (
      [Condition],
      [Condition (>36 in)],
      [Preventive Maintenance], 
      [Preventive Maintenance (>36 in)],
      [Root Control High], 
      [Root Control High (>15 in, <=36 in)],
      [Root Control High (>36 in)],
      [Root Control Medium], 
      [Root Control Medium (>15 in, <=36 in)],
      [Root Control Medium (>36 in)]
    )) AS PVT
  GROUP BY fiscal_year
)