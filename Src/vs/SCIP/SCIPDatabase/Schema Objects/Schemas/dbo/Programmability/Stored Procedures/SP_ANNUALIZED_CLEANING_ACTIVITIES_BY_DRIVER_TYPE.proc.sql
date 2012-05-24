CREATE PROCEDURE [dbo].[SP_ANNUALIZED_CLEANING_ACTIVITIES_BY_DRIVER_TYPE]
	@beginYear int = 2012, 
	@endYear int = 2017
AS
	SELECT driver_type, AVG(cost) AS annualized_cost, AVG(length_ft) AS annualized_length_ft
  FROM VW_CLEANING_ACTIVITIES_BY_DRIVER_TYPE_FISCAL_YEAR
  WHERE fiscal_year BETWEEN @beginYear AND @endYear
  GROUP BY driver_type
