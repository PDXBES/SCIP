CREATE FUNCTION [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS]
(
	@sourceDate DATETIME,
  @years DECIMAL(7,2)
)
RETURNS DATETIME
AS
BEGIN
	DECLARE @wholeYears DECIMAL(7,2)
  SET @wholeYears = CEILING(ABS(@years))*SIGN(@years)

  DECLARE @numDaysAvailable INT
  SET @numDaysAvailable = DATEDIFF(day, @sourceDate, DATEADD(year, @wholeYears, @sourceDate))

  DECLARE @resultDate DATETIME

  IF @years = 0
    SET @resultDate = @sourceDate
  ELSE
    SET @resultDate = DATEADD(DAY, CONVERT(DECIMAL(7,2), @numDaysAvailable) * @years / @wholeYears, @sourceDate)

  return @resultDate
END