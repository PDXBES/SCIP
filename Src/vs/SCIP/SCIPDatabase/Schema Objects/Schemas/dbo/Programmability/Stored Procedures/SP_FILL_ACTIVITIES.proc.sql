CREATE PROCEDURE [dbo].[SP_FILL_ACTIVITIES]
(
  @alternative_id INT = 1
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
  SET @MaxYears = 24

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

  -- Get the set of frequencies
  DECLARE activity_cursor CURSOR FOR
  SELECT frequency_years
  FROM @frequenciesTable
  
  DECLARE @currentFrequency DECIMAL(5,2)
  DECLARE @currentYear DECIMAL(5,2)
  DECLARE @nextYearDate DATETIME

  OPEN activity_cursor
    FETCH NEXT FROM activity_cursor INTO @currentFrequency
    WHILE @@FETCH_STATUS = 0
    BEGIN
      IF @currentFrequency > @MaxYears
      BREAK

      SET @statusMessage = 'Inserting for frequency of ' + CONVERT(VARCHAR(6), @currentFrequency) + ' years'
      EXEC SP_STATUS_MESSAGE @statusMessage
      
      SET @currentYear = 0

      WHILE (@currentYear < @MaxYears)
      BEGIN
        SET @currentYear = @currentYear + @currentFrequency
        IF @currentFrequency = 0
        BEGIN
        INSERT INTO ACTIVITIES (compkey, driver_id, activity_date, cost, activity_type_id, alternative_id)
          SELECT A.compkey, A.driver_id, @currentDate, A.driver_cost, A.activity_type_id, A.alternative_id
          FROM (VW_CONTROLLING_DRIVERS A INNER JOIN VW_LAST_ACTIVITY_DATES B ON (A.compkey = B.compkey))
          WHERE (A.frequency_years = @currentFrequency) AND 
            (A.activity_type = 'Inspection') AND 
            (A.alternative_id = @alternative_id)
        INSERT INTO ACTIVITIES (compkey, driver_id, activity_date, cost, activity_type_id, alternative_id)
          SELECT A.compkey, A.driver_id, @currentDate, A.driver_cost, A.activity_type_id, A.alternative_id
          FROM (VW_CONTROLLING_DRIVERS A INNER JOIN VW_LAST_ACTIVITY_DATES B ON (A.compkey = B.compkey))
          WHERE (A.frequency_years = @currentFrequency) AND 
            (A.activity_type = 'Cleaning') AND 
            (A.alternative_id = @alternative_id)
        INSERT INTO ACTIVITIES (compkey, driver_id, activity_date, cost, activity_type_id, alternative_id)
          SELECT A.compkey, A.driver_id, @currentDate, A.driver_cost, A.activity_type_id, A.alternative_id
          FROM (VW_CONTROLLING_DRIVERS A INNER JOIN VW_LAST_ACTIVITY_DATES B ON (A.compkey = B.compkey))
          WHERE (A.frequency_years = @currentFrequency) AND 
            (A.activity_type = 'Root Management') AND 
            (A.alternative_id = @alternative_id)
        BREAK
        END
        ELSE
        BEGIN
          INSERT INTO ACTIVITIES (compkey, driver_id, activity_date, cost, activity_type_id, alternative_id)
            SELECT A.compkey, A.driver_id, [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](B.last_inspection_date, @currentYear), A.driver_cost, A.activity_type_id, A.alternative_id
            FROM (VW_CONTROLLING_DRIVERS A INNER JOIN VW_LAST_ACTIVITY_DATES B ON (A.compkey = B.compkey))
            WHERE (A.frequency_years = @currentFrequency) AND 
              (A.activity_type = 'Inspection') AND
              (A.alternative_id = @alternative_id)
          INSERT INTO ACTIVITIES (compkey, driver_id, activity_date, cost, activity_type_id, alternative_id)
            SELECT A.compkey, A.driver_id, [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](B.last_cleaning_date, @currentYear), A.driver_cost, A.activity_type_id, A.alternative_id
            FROM (VW_CONTROLLING_DRIVERS A INNER JOIN VW_LAST_ACTIVITY_DATES B ON (A.compkey = B.compkey))
            WHERE (A.frequency_years = @currentFrequency) AND 
              (A.activity_type = 'Cleaning') AND
              (A.alternative_id = @alternative_id)
          INSERT INTO ACTIVITIES (compkey, driver_id, activity_date, cost, activity_type_id, alternative_id)
            SELECT A.compkey, A.driver_id, [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](B.last_root_management_date, @currentYear), A.driver_cost, A.activity_type_id, A.alternative_id
            FROM (VW_CONTROLLING_DRIVERS A INNER JOIN VW_LAST_ACTIVITY_DATES B ON (A.compkey = B.compkey))
            WHERE (A.frequency_years = @currentFrequency) AND 
              (A.activity_type = 'Root Management') AND
              (A.alternative_id = @alternative_id)
        END
      END
      FETCH NEXT FROM activity_cursor INTO @currentFrequency
    END
  CLOSE activity_cursor
  DEALLOCATE activity_cursor

  EXEC SP_STATUS_MESSAGE 'End SP_FILL_ACTIVITIES'
END