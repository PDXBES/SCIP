CREATE PROCEDURE [dbo].[SP_CHART_RLTD]
	@beginYear int = 2012, 
	@endYear int = 2023
AS
  SELECT fiscal_year, 
      SUM([Root Control High]) AS [Root Control High],
      SUM([Root Control High (>15 in)]) AS [Root Control High (>15 in)],
      SUM([Root Control Medium]) AS [Root Control Medium], 
      SUM([Root Control Medium (>15 in)]) AS [Root Control Medium]
  FROM (SELECT * FROM VW_ROOT_ACTIVITIES_BY_DRIVER_TYPE_FISCAL_YEAR WHERE fiscal_year BETWEEN 2012 AND 2023) PS
  PIVOT
  (SUM(cost) FOR reporting_category IN 
    (
      [Root Control High],
      [Root Control High (>15 in)],
      [Root Control Medium], 
      [Root Control Medium (>15 in)]
    )) AS PVT
  GROUP BY fiscal_year
  ORDER BY fiscal_year