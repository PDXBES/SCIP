CREATE FUNCTION [dbo].[FN_GET_PIVOT_COLUMN_HEADERS]
(
  @activity_type VARCHAR(20),
  @aggregate_function VARCHAR(20)
)
RETURNS VARCHAR(MAX)
AS
BEGIN
  DECLARE @PivotColumnHeaders VARCHAR(MAX)
  IF @aggregate_function = ''
	  SELECT @PivotColumnHeaders =
      COALESCE(@PivotColumnHeaders + ',[' + CAST(reporting_category AS VARCHAR(50)) + ']', '[' + CAST(reporting_category AS VARCHAR(50)) + ']')
    FROM ACTIVITIES_FOR_PROCESSING 
    WHERE activity_type = @activity_type
    GROUP BY reporting_category
    ORDER BY reporting_category;
  ELSE
	  SELECT @PivotColumnHeaders =
      COALESCE(@PivotColumnHeaders + ',' + @aggregate_function + '([' + CAST(reporting_category AS VARCHAR(50)) + ']) AS [' + CAST(reporting_category AS VARCHAR(50)) + ']', @aggregate_function + '([' + CAST(reporting_category AS VARCHAR(50)) + ']) AS [' + CAST(reporting_category AS VARCHAR(50)) + ']')
    FROM ACTIVITIES_FOR_PROCESSING 
    WHERE activity_type = @activity_type
    GROUP BY reporting_category
    ORDER BY reporting_category;

  RETURN @PivotColumnHeaders;
END