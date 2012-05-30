CREATE PROCEDURE [dbo].[SP_CHART_ILTD]
	@beginYear int = 2012, 
	@endYear int = 2023
AS
  SELECT fiscal_year, 
      SUM([Condition]) AS [Condition],
      SUM([Condition (>36 in)]) AS [Condition (>36 in)],
      SUM([Preventive Maintenance]) AS [Preventive Maintenance], 
      SUM([Preventive Maintenance (>36in)]) AS [Preventive Maintenance (>36in)],
      SUM([Root Control High]) AS [Root Control High], 
      SUM([Root Control High (>15 in, <=36 in)]) AS [Root Control High (>15 in, <=36 in)],
      SUM([Root Control High (>36 in)]) AS [Root Control High (>36 in)],
      SUM([Root Control Medium]) AS [Root Control Medium], 
      SUM([Root Control Medium (>15 in, <=36 in)]) AS [Root Control Medium (>15 in, <=36 in)],
      SUM([Root Control Medium (>36 in)]) AS [Root Control Medium (>36 in)]
  FROM (SELECT * FROM VW_INSPECTION_ACTIVITIES_BY_DRIVER_TYPE_FISCAL_YEAR WHERE fiscal_year BETWEEN @beginYear AND @endYear) PS
  PIVOT
  (SUM(cost) FOR reporting_category IN 
    (
      [Condition],
      [Condition (>36 in)],
      [Preventive Maintenance], 
      [Preventive Maintenance (>36in)],
      [Root Control High], 
      [Root Control High (>15 in, <=36 in)],
      [Root Control High (>36 in)],
      [Root Control Medium], 
      [Root Control Medium (>15 in, <=36 in)],
      [Root Control Medium (>36 in)]
    )) AS PVT
  GROUP BY fiscal_year
  ORDER BY fiscal_year