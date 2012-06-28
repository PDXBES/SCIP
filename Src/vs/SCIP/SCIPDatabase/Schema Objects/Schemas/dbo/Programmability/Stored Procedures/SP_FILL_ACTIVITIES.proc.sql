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

  DELETE FROM ACTIVITIES WHERE alternative_id = @alternative_id

  DELETE FROM CONTROLLING_DRIVER_FREQUENCIES WHERE alternative_id = @alternative_id

  INSERT INTO CONTROLLING_DRIVER_FREQUENCIES
    SELECT compkey, [Inspection] AS inspection_frequency_years, [Cleaning] AS cleaning_frequency_years, [Root Management] AS root_frequency_years, @alternative_id
    FROM 
    (SELECT compkey, activity_type, frequency_years FROM VW_CONTROLLING_DRIVERS WHERE alternative_id = @alternative_id) PS
    PIVOT (AVG(frequency_years) FOR activity_type IN ([Inspection], [Cleaning], [Root Management])) AS PVT

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

  DECLARE @asset_set_id INT
  SELECT @asset_set_id = asset_set_id
  FROM ALTERNATIVES
  WHERE alternative_id = @alternative_id

  DECLARE @CurrentDate DATETIME
  SET @CurrentDate = GETDATE()
  DECLARE @EndDate DATETIME
  SET @EndDate = DATEADD(year, @MaxYears, @CurrentDate)

  EXEC SP_STATUS_MESSAGE 'Inserting backlog condition inspections'

  INSERT INTO ACTIVITIES (compkey, driver_id, activity_date, cost, activity_type_id, alternative_id)
    SELECT A.compkey, A.driver_id, @currentDate, A.driver_cost, A.activity_type_id, A.alternative_id
    FROM (VW_CONTROLLING_DRIVERS A INNER JOIN VW_LAST_ACTIVITY_DATES B ON (A.compkey = B.compkey))
    WHERE (A.frequency_years = 0) AND 
      (A.activity_type = 'Inspection') AND 
      (A.alternative_id = @alternative_id) AND
      (B.asset_set_id = @asset_set_id)
  SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records for inspection'
  EXEC SP_STATUS_MESSAGE @statusMessage

  EXEC SP_STATUS_MESSAGE 'Inserting activities'

  EXEC SP_INSERT_ACTIVITIES @alternative_id = @alternative_id, @numYears = @years_to_process

  EXEC SP_STATUS_MESSAGE 'End SP_FILL_ACTIVITIES'
END