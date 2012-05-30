CREATE PROCEDURE [dbo].[SP_CHART_RPAD]
	@beginYear int = 2012, 
	@endYear int = 2023
AS
  SELECT reporting_category, AVG(cost) AS cost
  FROM VW_ROOT_ACTIVITIES_BY_DRIVER_TYPE_FISCAL_YEAR
  WHERE fiscal_year BETWEEN @beginYear AND @endYear
  GROUP BY reporting_category