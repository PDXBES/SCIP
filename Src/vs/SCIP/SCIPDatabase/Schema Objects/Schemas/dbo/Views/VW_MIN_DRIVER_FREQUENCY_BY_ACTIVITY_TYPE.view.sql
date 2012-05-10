CREATE VIEW [dbo].[VW_MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE]
	AS
    SELECT compkey, activity_type, MIN(frequency_years) AS min_frequency_years
    FROM VW_ALL_DRIVERS
    GROUP BY activity_type, compkey