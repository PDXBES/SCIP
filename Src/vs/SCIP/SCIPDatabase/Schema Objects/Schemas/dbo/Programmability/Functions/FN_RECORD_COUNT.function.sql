CREATE FUNCTION [dbo].[FN_RECORD_COUNT]
(
	@tableName VARCHAR(100) 
)
RETURNS BIGINT
AS
BEGIN
	DECLARE @recordCount BIGINT, @sql VARCHAR(512)
  SET @sql = 'SQLECT @recordCount = COUNT(*) FROM ' + @tableName

  EXEC sp_executesql
    @query = @sql,
    @params = '@i INT OUTPUT',
    @recordCount = @recordCount OUTPUT

  RETURN @recordCount
END