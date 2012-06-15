CREATE PROCEDURE [dbo].[SP_CLEAN_UP_ALTERNATIVE]
(
  @alternative_id INT
)
AS
BEGIN
  SET NOCOUNT ON;

  DECLARE @statusMessage VARCHAR(200);
  SET @statusMessage = 'Begin SP_CLEAN_UP_ALTERNATIVE, alternative_id = ' + CONVERT(VARCHAR(10), @alternative_id);
  EXEC SP_STATUS_MESSAGE @statusMessage;

  DELETE FROM NEXT_ACTIVITIES WHERE alternative_id = @alternative_id;
  DELETE FROM ACTIVITIES WHERE alternative_id = @alternative_id;
  DELETE FROM DRIVERS WHERE alternative_id = @alternative_id;
  DELETE FROM DRIVER_TYPES WHERE alternative_id = @alternative_id;
  DELETE FROM ALTERNATIVES WHERE alternative_id = @alternative_id;
END