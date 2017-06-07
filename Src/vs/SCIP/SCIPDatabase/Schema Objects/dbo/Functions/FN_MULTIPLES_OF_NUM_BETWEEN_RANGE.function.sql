CREATE FUNCTION [dbo].[FN_MULTIPLES_OF_NUM_BETWEEN_RANGE]
(
	@multiplier decimal(10,5),
	@begin_range decimal(10,5),
  @end_range decimal(10,5)
)
RETURNS @returnTable TABLE 
(
  value decimal(10,5)
)
AS
BEGIN
  INSERT INTO @returnTable VALUES(@begin_range)

  INSERT INTO @returnTable
  SELECT @multiplier * n + @begin_range
  FROM NUMS
  WHERE n <= (@end_range - @begin_range) / @multiplier

  RETURN
END