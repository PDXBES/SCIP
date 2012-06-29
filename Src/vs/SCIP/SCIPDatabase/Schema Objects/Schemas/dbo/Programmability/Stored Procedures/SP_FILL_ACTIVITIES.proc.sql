CREATE PROCEDURE [dbo].[SP_FILL_ACTIVITIES]
(
  @alternative_id INT = 1,
  @years_to_process DECIMAL(5,2) = 24.0
)
AS
BEGIN
  SET NOCOUNT ON

  DECLARE @statusMessage VARCHAR(200)
  SET @statusMessage = 'Begin SP_FILL_ACTIVITIES, alternative_id = ' + CONVERT(VARCHAR(10), @alternative_id)
  EXEC SP_STATUS_MESSAGE @statusMessage

  EXEC SP_STATUS_MESSAGE 'Preparing MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING'
  TRUNCATE TABLE MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING
  INSERT INTO MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING
    SELECT compkey, activity_type, MIN(frequency_years) AS min_frequency_years
    FROM VW_ALL_DRIVERS
    WHERE alternative_id = @alternative_id
    GROUP BY activity_type, compkey

  EXEC SP_STATUS_MESSAGE 'Preparing RANKED_MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING'
  TRUNCATE TABLE RANKED_MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING
  INSERT INTO RANKED_MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING
    SELECT A.[compkey]
        ,A.[activity_type]
        ,A.[min_frequency_years]
        ,MIN(B.[driver_rank]) AS min_driver_rank
    FROM [MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING] A INNER JOIN [VW_ALL_DRIVERS] B ON (A.compkey = B.compkey AND A.activity_type = B.activity_type AND A.min_frequency_years = B.frequency_years AND B.alternative_id = @alternative_id)
    GROUP BY A.activity_type, A.compkey, A.min_frequency_years
      
  EXEC SP_STATUS_MESSAGE 'Preparing CONTROLLING_DRIVERS_FOR_PROCESSING'
  TRUNCATE TABLE CONTROLLING_DRIVERS_FOR_PROCESSING
  INSERT INTO CONTROLLING_DRIVERS_FOR_PROCESSING
    SELECT A.driver_id, A.compkey, A.length_ft, A.diamwidth_inches, A.height_inches, A.basin, A.district, A.driver_type, A.reporting_category, A.driver_type_id, driver_rank, A.activity_type, A.activity_type_id, A.cost_per_ft, A.frequency_years, A.updated_by, A.update_date, A.driver_cost
    FROM VW_ALL_DRIVERS A INNER JOIN [RANKED_MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING] B ON (A.compkey = B.compkey AND A.activity_type = B.activity_type AND A.frequency_years = B.min_frequency_years AND A.driver_rank = B.min_driver_rank AND A.alternative_id = @alternative_id)

  EXEC SP_STATUS_MESSAGE 'Preparing CONTROLLING_DRIVER_FREQUENCIES_FOR_PROCESSING'
  TRUNCATE TABLE CONTROLLING_DRIVER_FREQUENCIES_FOR_PROCESSING
  INSERT INTO CONTROLLING_DRIVER_FREQUENCIES_FOR_PROCESSING
    SELECT compkey, [Inspection] AS inspection_frequency_years, [Cleaning] AS cleaning_frequency_years, [Root Management] AS root_frequency_years
    FROM 
    (SELECT compkey, activity_type, frequency_years FROM CONTROLLING_DRIVERS_FOR_PROCESSING) PS
    PIVOT (AVG(frequency_years) FOR activity_type IN ([Inspection], [Cleaning], [Root Management])) AS PVT

  EXEC SP_STATUS_MESSAGE 'Preparing CONTROLLING_DRIVER_FREQUENCIES'
  DELETE FROM CONTROLLING_DRIVER_FREQUENCIES WHERE alternative_id = @alternative_id
  INSERT INTO CONTROLLING_DRIVER_FREQUENCIES
    SELECT compkey, [Inspection] AS inspection_frequency_years, [Cleaning] AS cleaning_frequency_years, [Root Management] AS root_frequency_years, @alternative_id AS alternative_id
    FROM 
    (SELECT compkey, activity_type, frequency_years FROM CONTROLLING_DRIVERS_FOR_PROCESSING) PS
    PIVOT (AVG(frequency_years) FOR activity_type IN ([Inspection], [Cleaning], [Root Management])) AS PVT

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

  DELETE FROM ACTIVITIES WHERE alternative_id = @alternative_id

  DECLARE @MaxYears DECIMAL(5,2)
  SET @MaxYears = @years_to_process

  SET @statusMessage = 'Processing ' + CONVERT(VARCHAR(10), @MaxYears) + ' years'
  EXEC SP_STATUS_MESSAGE @statusMessage

  DECLARE @frequenciesTable TABLE
  (
    frequency_years DECIMAL(5,2),
    record_count INT
  )

  INSERT INTO @frequenciesTable
    SELECT frequency_years, COUNT(*)
    FROM VW_CONTROLLING_DRIVERS
    WHERE alternative_id = @alternative_id
    GROUP BY frequency_years

  DECLARE @InsertActivities TABLE
  (
	  COMPKEY int,
	  last_activity_date datetime,
	  next_activity_date datetime,
	  cost money,
	  reason nvarchar(20),
	  activity_type_id int, 
	  alternative_id int
  )

  DECLARE @CurrentDate DATETIME
  SET @CurrentDate = GETDATE()
  DECLARE @EndDate DATETIME
  SET @EndDate = DATEADD(year, @MaxYears, @CurrentDate)

  EXEC SP_STATUS_MESSAGE 'Inserting backlog condition inspections'

  INSERT INTO ACTIVITIES (compkey, driver_id, activity_date, cost, activity_type_id, alternative_id)
    SELECT A.compkey, A.driver_id, @currentDate, A.driver_cost, A.activity_type_id, @alternative_id
    FROM (CONTROLLING_DRIVERS_FOR_PROCESSING A INNER JOIN LAST_ACTIVITY_DATES_FOR_PROCESSING B ON (A.compkey = B.compkey))
    WHERE (A.frequency_years = 0) AND (A.activity_type = 'Inspection')
  SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records for inspection'
  EXEC SP_STATUS_MESSAGE @statusMessage

  EXEC SP_STATUS_MESSAGE 'Inserting activities'

  EXEC SP_INSERT_ACTIVITIES @alternative_id = @alternative_id, @numYears = @years_to_process

  EXEC SP_STATUS_MESSAGE 'End SP_FILL_ACTIVITIES'
END