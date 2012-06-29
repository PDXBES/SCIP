CREATE PROCEDURE [dbo].[SP_INSERT_ACTIVITIES]
  @alternative_id INT,
  @numYears DECIMAL(5,2)
AS
BEGIN
  DECLARE @asset_set_id INT;
  SELECT @asset_set_id = asset_set_id FROM ALTERNATIVES WHERE alternative_id = @alternative_id;

  DECLARE @statusMessage VARCHAR(200);

  INSERT INTO ACTIVITIES (compkey, driver_id, activity_date, cost, activity_type_id, alternative_id)
    SELECT compkey, driver_id, activity_date, cost, activity_type_id, @alternative_id
    FROM dbo.FN_ACTIVITIES_TO_INSERT(@alternative_id, 'Inspection', @numYears)
  SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records for inspection'
  EXEC SP_STATUS_MESSAGE @statusMessage

  INSERT INTO ACTIVITIES (compkey, driver_id, activity_date, cost, activity_type_id, alternative_id)
    SELECT compkey, driver_id, activity_date, cost, activity_type_id, @alternative_id
    FROM dbo.FN_ACTIVITIES_TO_INSERT(@alternative_id, 'Root Management', @numYears)
  SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records for root management'
  EXEC SP_STATUS_MESSAGE @statusMessage

  INSERT INTO ACTIVITIES (compkey, driver_id, activity_date, cost, activity_type_id, alternative_id)
    SELECT compkey, driver_id, activity_date, cost, activity_type_id, @alternative_id
    FROM dbo.FN_ACTIVITIES_TO_INSERT(@alternative_id, 'Cleaning', @numYears)
  SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records for cleaning'
  EXEC SP_STATUS_MESSAGE @statusMessage
END