CREATE PROCEDURE [dbo].[SP_RECORD_COUNT]
	@tableName NVARCHAR(100) 
AS
BEGIN
	DECLARE @recordCount BIGINT, @sql NVARCHAR(512)
  SET @sql = N'SELECT @recordCount = COUNT(*) FROM ' + @tableName

  EXEC sp_executesql
    @query = @sql,
    @params = N'@recordcount INT OUTPUT',
    @recordCount = @recordCount OUTPUT

  RETURN @recordCount
END