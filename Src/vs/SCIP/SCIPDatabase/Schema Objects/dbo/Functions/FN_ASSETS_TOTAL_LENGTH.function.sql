CREATE FUNCTION [dbo].[FN_ASSETS_TOTAL_LENGTH]
(
  @asset_set_id INT
)
RETURNS INT
AS
BEGIN
  DECLARE @result INT
  SELECT @result = SUM(length_ft)
  FROM ASSETS
  WHERE asset_set_id = @asset_set_id

  RETURN @result
END