CREATE PROCEDURE [dbo].[SP_PREPARE_CONTROLLING_DRIVERS_FOR_PROCESSING]
	@alternative_id INT
AS
BEGIN
  EXEC SP_STATUS_MESSAGE 'Begin SP_PREPARE_CONTROLLING_DRIVERS_FOR_PROCESSING'

  EXEC SP_STATUS_MESSAGE 'Preparing MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING'
  
  DECLARE @MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING TABLE (
	[compkey] [INT] NULL,
	[activity_type] [VARCHAR](20) NULL,
	[min_frequency_years] [DECIMAL](5, 2) NULL
)

  INSERT INTO @MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING
    SELECT compkey, activity_type, MIN(frequency_years) AS min_frequency_years
    FROM VW_ALL_DRIVERS
    WHERE alternative_id = @alternative_id
    GROUP BY activity_type, compkey

  EXEC SP_STATUS_MESSAGE 'Preparing RANKED_MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING'
  
  DECLARE  @RANKED_MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING TABLE(
	[compkey] [INT] NULL,
	[activity_type] [VARCHAR](20) NULL,
	[min_frequency_years] [DECIMAL](5, 2) NULL,
	[min_driver_rank] [INT] NULL
)
  INSERT INTO @RANKED_MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING
    SELECT A.[compkey]
        ,A.[activity_type]
        ,A.[min_frequency_years]
        ,MIN(B.[driver_rank]) AS min_driver_rank
    FROM @MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING A INNER JOIN [VW_ALL_DRIVERS] B ON (A.compkey = B.compkey AND A.activity_type = B.activity_type AND A.min_frequency_years = B.frequency_years AND B.alternative_id = @alternative_id)
    GROUP BY A.activity_type, A.compkey, A.min_frequency_years

  EXEC SP_STATUS_MESSAGE 'Preparing CONTROLLING_DRIVERS_FOR_PROCESSING'
  
  DECLARE @CONTROLLING_DRIVERS_FOR_PROCESSING TABLE(
	[driver_id] [INT] NULL,
	[compkey] [INT] NULL,
	[length_ft] [INT] NULL,
	[diamwidth_inches] [DECIMAL](5, 2) NULL,
	[height_inches] [DECIMAL](5, 2) NULL,
	[basin] [VARCHAR](50) NULL,
	[district] [VARCHAR](50) NULL,
	[driver_type] [VARCHAR](50) NULL,
	[reporting_category] [VARCHAR](100) NULL,
	[driver_type_id] [INT] NULL,
	[driver_rank] [INT] NULL,
	[activity_type] [VARCHAR](20) NULL,
	[activity_type_id] [INT] NULL,
	[cost_per_ft] [MONEY] NULL,
	[frequency_years] [DECIMAL](5, 2) NULL,
	[updated_by] [VARCHAR](20) NULL,
	[update_date] [DATETIME] NULL,
	[driver_cost] [MONEY] NULL
)

  INSERT INTO @CONTROLLING_DRIVERS_FOR_PROCESSING
    SELECT A.driver_id, A.compkey, A.length_ft, A.diamwidth_inches, A.height_inches, A.basin, A.district, A.driver_type, A.reporting_category, A.driver_type_id, driver_rank, A.activity_type, A.activity_type_id, A.cost_per_ft, A.frequency_years, A.updated_by, A.update_date, A.driver_cost
    FROM VW_ALL_DRIVERS A INNER JOIN @RANKED_MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING B ON (A.compkey = B.compkey AND A.activity_type = B.activity_type AND A.frequency_years = B.min_frequency_years AND A.driver_rank = B.min_driver_rank AND A.alternative_id = @alternative_id)

  DECLARE @asset_set_id INT
  SELECT @asset_set_id = asset_set_id
  FROM ALTERNATIVES
  WHERE alternative_id = @alternative_id

  EXEC SP_STATUS_MESSAGE 'Preparing LAST_ACTIVITY_DATES_FOR_PROCESSING'
  TRUNCATE TABLE LAST_ACTIVITY_DATES_FOR_PROCESSING
  INSERT INTO LAST_ACTIVITY_DATES_FOR_PROCESSING
    SELECT 
     A.COMPKEY
    ,CASE WHEN (A.last_inspection_date IS NULL)
      THEN [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), -B.inspection_frequency_years) 
      ELSE CASE WHEN (A.last_inspection_date < [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), -B.inspection_frequency_years)) 
        THEN [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), -B.inspection_frequency_years) 
        ELSE A.last_inspection_date END END AS last_inspection_date
    ,CASE WHEN (A.last_root_management_date IS NULL) 
      THEN [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), -B.root_frequency_years) 
      ELSE CASE WHEN (A.last_root_management_date < [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), -B.root_frequency_years)) 
        THEN [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), -B.root_frequency_years) 
        ELSE A.last_root_management_date END END AS last_root_management_date
    ,CASE WHEN (A.last_cleaning_date IS NULL) 
      THEN [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), -B.cleaning_frequency_years) 
      ELSE CASE WHEN (A.last_cleaning_date < [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), -B.cleaning_frequency_years)) THEN [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), -B.cleaning_frequency_years) 
        ELSE A.last_cleaning_date END  END AS last_cleaning_date
    FROM CONTROLLING_DRIVER_FREQUENCIES_FOR_PROCESSING B INNER JOIN ASSETS A ON (B.compkey = A.compkey AND A.asset_set_id = @asset_set_id)

  EXEC SP_STATUS_MESSAGE 'End SP_PREPARE_CONTROLLING_DRIVERS_FOR_PROCESSING'
END