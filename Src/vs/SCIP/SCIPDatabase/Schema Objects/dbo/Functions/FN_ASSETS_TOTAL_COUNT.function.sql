CREATE FUNCTION [dbo].[FN_ASSETS_TOTAL_COUNT]
(
  @asset_set_id INT
)
RETURNS INT
AS
BEGIN
  DECLARE @result INT
  SELECT @result = COUNT(*)
  FROM ASSETS
  WHERE asset_set_id = @asset_set_id

  RETURN @result
END