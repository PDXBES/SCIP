CREATE FUNCTION [dbo].[FN_CHART_ACTIVITIES_COUNT_BETWEEN_YEARS]
(
	@beginYear INT, 
	@endYear INT,
  @activityType VARCHAR(50),
  @alternative_id INT
)
RETURNS @resultTable TABLE 
(
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
  DECLARE
    @totalActivityCompkeyCount INT,
    @totalActivityPercentCovered DECIMAL(5,2),
    @totalAnnualizedActivityCompkeyCount INT,
    @totalAnnualizedActivityPercentCovered DECIMAL(5,2)

  DECLARE @tempResults TABLE
  (
    activity_type VARCHAR(50),
    driver_type VARCHAR(50),
    reporting_category VARCHAR(50),
    compkey_count INT,
    compkey_percent_covered DECIMAL(5,2),
    annualized_compkey_count INT,
    annualized_compkey_percent_covered DECIMAL(5,2)
  )

  DECLARE @current_asset_set_id INT
  SELECT @current_asset_set_id = asset_set_id
  FROM ALTERNATIVES
  WHERE alternative_id = @alternative_id

  DECLARE @totalAssetsCount INT;
  SET @totalAssetsCount = dbo.FN_ASSETS_TOTAL_COUNT(@current_asset_set_id);

  INSERT INTO @tempResults
    SELECT
      A.activity_type, 
      A.driver_type, 
      A.reporting_category, 
      COUNT(*) AS compkey_count, 
      CONVERT(decimal(5,2), ROUND(CONVERT(decimal(10,2), count(*))/@totalAssetsCount*100, 2)) 
        AS compkey_percent_covered, 
      CONVERT(decimal(10,2), CONVERT(decimal(10,2), count(*))/(ABS(@endYear-@beginYear)+1)) 
        AS annualized_compkey_count, 
      CONVERT(decimal(5,2),ROUND(CONVERT(decimal(10,2), count(*))/
        @totalAssetsCount/(ABS(@endYear-@beginYear)+1)*100, 2)) AS annualized_compkey_percent_covered
    FROM
    (SELECT activity_type, driver_type, reporting_category, compkey
    FROM ACTIVITIES_FOR_PROCESSING
    WHERE fiscal_year BETWEEN @beginYear AND @endYear AND activity_type = @activityType AND alternative_id = @alternative_id
    GROUP BY activity_type, driver_type, reporting_category, compkey) AS A
    GROUP BY A.activity_type, A.driver_type, A.reporting_category

  SELECT
    @totalActivityCompkeyCount = SUM(compkey_count), 
    @totalActivityPercentCovered = SUM(compkey_percent_covered), 
    @totalAnnualizedActivityCompkeyCount = SUM(annualized_compkey_count), 
    @totalAnnualizedActivityPercentCovered = SUM(annualized_compkey_percent_covered)
  FROM
    @tempResults

  INSERT INTO @resultTable (activity_type, driver_type, reporting_category, compkey_count, compkey_percent_covered, annualized_compkey_count, annualized_compkey_percent_covered)
	SELECT
    A.activity_type, 
    A.driver_type, 
    A.reporting_category, 
    COUNT(*) AS compkey_count, 
    CONVERT(decimal(5,2), ROUND(CONVERT(decimal(10,2), count(*))/@totalAssetsCount*100, 2)) 
      AS compkey_percent_covered, 
    CONVERT(decimal(10,2), CONVERT(decimal(10,2), count(*))/(ABS(@endYear-@beginYear)+1)) 
      AS annualized_compkey_count, 
    CONVERT(decimal(5,2),ROUND(CONVERT(decimal(10,2), count(*))/
      @totalAssetsCount/(ABS(@endYear-@beginYear)+1)*100, 2)) AS annualized_compkey_covered
  FROM
  (SELECT activity_type, driver_type, reporting_category, compkey
  FROM ACTIVITIES_FOR_PROCESSING
  WHERE fiscal_year BETWEEN @beginYear AND @endYear AND activity_type = @activityType AND alternative_id = @alternative_id
  GROUP BY activity_type, driver_type, reporting_category, compkey) AS A
  GROUP BY A.activity_type, A.driver_type, A.reporting_category

  INSERT INTO @resultTable (activity_type, driver_type, reporting_category, compkey_count, compkey_percent_covered, annualized_compkey_count, annualized_compkey_percent_covered)
  VALUES (@activityType , 'Nonactivity', 'Nonactivity',
    @totalAssetsCount-@totalActivityCompkeyCount, 
    100-@totalActivityPercentCovered, 
    @totalAssetsCount-@totalAnnualizedActivityCompkeyCount, 
    100-@totalAnnualizedActivityPercentCovered)

  RETURN
END