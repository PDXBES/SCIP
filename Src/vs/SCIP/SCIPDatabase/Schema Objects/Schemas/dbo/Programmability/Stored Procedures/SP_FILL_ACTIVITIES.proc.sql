CREATE PROCEDURE [dbo].[SP_FILL_ACTIVITIES]
AS
BEGIN
  TRUNCATE TABLE ACTIVITIES

  DECLARE ControllingDriversCursor CURSOR FOR
  SELECT * FROM VW_CONTROLLING_DRIVERS

  DECLARE @MaxYears INT
  SET @MaxYears = 12

  DECLARE @CurrentDate DATETIME
  DECLARE @EndDate DATETIME
  SET @EndDate = DATEADD(year, @MaxYears, @CurrentDate)

  DECLARE @cd_driver_id INT
  DECLARE @cd_compkey INT
  DECLARE @cd_length_ft INT
  DECLARE @cd_diamwidth_inches DECIMAL(5,2)
  DECLARE @cd_height_inches DECIMAL(5,2)
  DECLARE @cd_basin VARCHAR(50)
  DECLARE @cd_district VARCHAR(50)
  DECLARE @cd_driver_type VARCHAR(20)
  DECLARE @cd_driver_type_id INT
  DECLARE @cd_driver_rank INT
  DECLARE @cd_activity_type VARCHAR(20)
  DECLARE @cd_activity_type_id INT
  DECLARE @cd_cost_per_ft MONEY
  DECLARE @cd_frequency_years DECIMAL(5,2)
  DECLARE @cd_alternative_id INT
  DECLARE @cd_updated_by VARCHAR(20)
  DECLARE @cd_update_date DATETIME
  DECLARE @cd_driver_cost MONEY
  DECLARE @ModelDate DATETIME
  SET @ModelDate = GETDATE()
  
  EXEC SP_STATUS_MESSAGE 'Begin SP_FILL_ACTIVITIES'

  DECLARE @driversCount BIGINT
  SET @driversCount = [dbo].[FN_RECORD_COUNT]('DRIVERS')
  DECLARE @currentRecordNum BIGINT
  DECLARE @statusMessage VARCHAR(100)

  OPEN ControllingDriversCursor
    FETCH NEXT FROM ControllingDriversCursor
    INTO @cd_driver_id, @cd_compkey, @cd_length_ft, @cd_diamwidth_inches, @cd_height_inches,
      @cd_basin, @cd_district, @cd_driver_type, @cd_driver_type_id, @cd_driver_rank, 
      @cd_activity_type, @cd_activity_type_id, @cd_cost_per_ft, @cd_frequency_years, 
      @cd_alternative_id, @cd_updated_by, @cd_update_date, @cd_driver_cost
    SET @currentRecordNum = 1

    SET @CurrentDate = @ModelDate
    WHILE @@FETCH_STATUS = 0
    BEGIN
      IF @driversCount % 1000 = 0
      BEGIN
        SET @statusMessage = 'Driver ' + CONVERT(VARCHAR(15), @currentRecordNum) + ' of ' + CONVERT(VARCHAR(15), @driversCount)
        EXEC SP_STATUS_MESSAGE @statusMessage
      END
      WHILE @CurrentDate < @EndDate
      BEGIN
        INSERT INTO ACTIVITIES 
          (
             compkey
            ,hansen_activity_code
            ,driver_id
            ,activity_date
            ,cost
            ,activity_type_id
            ,alternative_id
          )
          VALUES
          (
             @cd_compkey
            ,@cd_driver_type
            ,@cd_driver_id
            ,@CurrentDate
            ,@cd_driver_cost
            ,@cd_activity_type_id
            ,1
          )
        SET @CurrentDate = DATEADD(year, @cd_frequency_years ,@CurrentDate)
        SET @currentRecordNum = @currentRecordNum + 1
      END
      FETCH NEXT FROM Employee_Cursor
    END
  CLOSE ControllingDriversCursor
  DEALLOCATE ControllingDriversCursor
  EXEC SP_STATUS_MESSAGE 'End SP_FILL_ACTIVITIES'
END