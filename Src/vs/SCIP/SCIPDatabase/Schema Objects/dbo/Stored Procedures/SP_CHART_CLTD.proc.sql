CREATE PROCEDURE [dbo].[SP_CHART_CLTD]
	@beginYear int = 2012, 
	@endYear int = 2023
AS
  SELECT fiscal_year, 
      ISNULL(SUM([Accelerated Area]), 0) AS [Accelerated Area],
      ISNULL(SUM([Preventive Maintenance]), 0) AS [Preventive Maintenance],
      ISNULL(SUM([Tractive Forces]), 0) AS [Tractive Forces], 
      ISNULL(SUM([Tractive Forces (>36 in)]), 0) AS [Tractive Forces (>36 in)]
  FROM (SELECT * FROM VW_CLEANING_ACTIVITIES_BY_DRIVER_TYPE_FISCAL_YEAR WHERE fiscal_year BETWEEN @beginYear AND @endYear) PS
  PIVOT
  (SUM(cost) FOR reporting_category IN 
    (
      [Accelerated Area],
      [Preventive Maintenance],
      [Tractive Forces], 
      [Tractive Forces (>36 in)]
    )) AS PVT
  GROUP BY fiscal_year
  ORDER BY fiscal_year