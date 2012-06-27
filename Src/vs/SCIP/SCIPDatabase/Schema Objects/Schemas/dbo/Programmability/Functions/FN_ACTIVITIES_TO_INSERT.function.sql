-- Do not use this function alone. Always use the SP_INSERT_ACTIVITIES stored procedure. This
-- function depends on the LAST_ACTIVITY_DATES_FOR_PROCESSING table being filled properly.
CREATE FUNCTION [dbo].[FN_ACTIVITIES_TO_INSERT]
(
  @alternative_id int,
	@activity_type VARCHAR(50), 
	@numYears decimal(5,2)
)
RETURNS @returntable TABLE 
(
  compkey int,
  driver_id int,
  activity_date datetime,
  cost money,
  activity_type_id int,
  alternative_id int
)
AS
BEGIN
  WITH FrequencyTable(frequency_years) AS
  (
    SELECT frequency_years
    FROM VW_CONTROLLING_DRIVERS
    WHERE alternative_id = @alternative_id
    GROUP BY activity_type_id, frequency_years
  )
	INSERT @returntable
  SELECT
    C.compkey,
    C.driver_id, 
    [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](
      CASE @activity_type
        WHEN 'Inspection' THEN D.last_inspection_date
        WHEN 'Root Management' THEN D.last_root_management_date
        WHEN 'Cleaning' THEN D.last_cleaning_date
      END
      , B.value), 
    C.driver_cost, 
    C.activity_type_id, 
    C.alternative_id
  FROM
    (
      (SELECT DISTINCT *
      FROM FrequencyTable A
        CROSS APPLY
          dbo.FN_MULTIPLES_OF_NUM_BETWEEN_RANGE(A.frequency_years, 
            A.frequency_years, A.frequency_years + @numYears - 1)
      WHERE A.frequency_years > 0) B 
        INNER JOIN
          VW_CONTROLLING_DRIVERS C ON (B.frequency_years = C.frequency_years)
    ) INNER JOIN LAST_ACTIVITY_DATES_FOR_PROCESSING D ON (C.compkey = D.compkey)
  WHERE  
    (C.activity_type = @activity_type) AND 
    (C.alternative_id = @alternative_id)
  ORDER BY value

	RETURN 
END