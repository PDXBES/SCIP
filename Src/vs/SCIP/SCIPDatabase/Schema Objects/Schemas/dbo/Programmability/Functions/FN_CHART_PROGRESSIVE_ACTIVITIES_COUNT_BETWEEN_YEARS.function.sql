CREATE FUNCTION [dbo].[FN_CHART_PROGRESSIVE_ACTIVITIES_COUNT_BETWEEN_YEARS]
(
	@beginYear INT, 
	@endYear INT,
  @activityType VARCHAR(50)
)
RETURNS @resultTable TABLE 
(
  fiscal_year INT,
  activity_type VARCHAR(50),
  driver_type VARCHAR(50),
  reporting_category VARCHAR(50),
  compkey_count INT,
  compkey_percent_covered DECIMAL(5,2),
  annualized_compkey_count INT,
  annualized_compkey_percent_covered DECIMAL(5,2)
)
AS
BEGIN

DECLARE @currentYear INT;
SET @currentYear = @beginYear
WHILE @currentYear <= @endYear
BEGIN

  INSERT INTO @resultTable
  SELECT @currentYear, activity_type, driver_type, reporting_category, compkey_count,
    compkey_percent_covered, annualized_compkey_count, annualized_compkey_percent_covered
  FROM dbo.FN_CHART_ACTIVITIES_COUNT_BETWEEN_YEARS(@beginYear, @currentYear, @activityType)

  SET @currentYear = @currentYear + 1

END

RETURN

END