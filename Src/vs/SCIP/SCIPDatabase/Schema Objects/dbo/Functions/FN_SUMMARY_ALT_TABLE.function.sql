CREATE FUNCTION [dbo].[FN_SUMMARY_ALT_TABLE]
(
  @alternative_id INT,
  @begin_year INT,
  @end_year INT,
  @activity_type VARCHAR(20)
)
RETURNS @returntable TABLE 
(
	reporting_category VARCHAR(100),
  expenditures MONEY,
  expenditures_per_year MONEY,
  footage DECIMAL(10,2),
  footage_per_year DECIMAL(10,2)
)
AS
BEGIN
  INSERT INTO @returntable
  SELECT A.reporting_category, ROUND(SUM(cost), 0) AS [Expenditures], ROUND(SUM(cost)/(@end_year-@begin_year+1),0) AS [ExpendituresPerYear], ROUND(SUM(length_ft),0) AS [Footage], ROUND(SUM(length_ft)/(@end_year-@begin_year+1),0) AS [FootagePerYear] 
  FROM ACTIVITIES_FOR_PROCESSING A
  WHERE (A.activity_type = @activity_type) AND (A.fiscal_year BETWEEN @begin_year AND @end_year)
  GROUP BY A.reporting_category
	RETURN 
END