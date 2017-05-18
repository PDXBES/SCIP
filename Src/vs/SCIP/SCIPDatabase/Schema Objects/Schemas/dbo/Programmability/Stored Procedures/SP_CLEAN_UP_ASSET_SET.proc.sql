CREATE PROCEDURE [dbo].[SP_CLEAN_UP_ASSET_SET]
(
  @asset_set_id INT
)
AS
BEGIN
  SET NOCOUNT ON;

  DECLARE @statusMessage VARCHAR(200);
  SET @statusMessage = 'Begin SP_CLEAN_UP_ASSET_SET, asset_set_id = ' + CONVERT(VARCHAR(10), @asset_set_id);
  EXEC SP_STATUS_MESSAGE @statusMessage;

  DECLARE @dependentAlternatives TABLE
    ( alternative_id INT )
  INSERT INTO @dependentAlternatives
    SELECT alternative_id
    FROM ALTERNATIVES
    WHERE asset_set_id = @asset_set_id

  DECLARE dependent_alts_cursor CURSOR FOR
  SELECT alternative_id
  FROM @dependentAlternatives

  DECLARE @current_alternative_id INT
  OPEN dependent_alts_cursor
    FETCH NEXT FROM dependent_alts_cursor INTO @current_alternative_id
    WHILE @@FETCH_STATUS = 0
    BEGIN
      SET @statusMessage = 'Deleting dependent alternative ' + CONVERT(VARCHAR(10), @current_alternative_id);
      EXEC SP_STATUS_MESSAGE @statusMessage;
      EXEC SP_CLEAN_UP_ALTERNATIVE @alternative_id = @current_alternative_id
      FETCH NEXT FROM dependent_alts_cursor INTO @current_alternative_id
    END
  CLOSE dependent_alts_cursor

  EXEC SP_STATUS_MESSAGE 'Deleting from asset set tables'

  DELETE FROM ASSETS WHERE asset_set_id = @asset_set_id
  --DELETE FROM AllInspections WHERE asset_set_id = @asset_set_id
  DELETE FROM LatestInspections WHERE asset_set_id = @asset_set_id
  DELETE FROM RootInspections WHERE asset_set_id = @asset_set_id
  DELETE FROM SpecialRoot WHERE asset_set_id = @asset_set_id
  DELETE FROM ASSET_SETS WHERE asset_set_id = @asset_set_id

  EXEC SP_STATUS_MESSAGE 'End SP_CLEAN_UP_ASSET_SET';

END