CREATE FUNCTION [dbo].[FN_COMPARE_TO_CURRENT_DATE]
(
	@compareDate DATETIME,
  @currentDate DATETIME
)
RETURNS DATETIME
AS
BEGIN
	RETURN CASE WHEN (@compareDate < @currentDate) THEN @currentDate ELSE @compareDATE END
END