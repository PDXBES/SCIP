CREATE VIEW [dbo].[VW_CLEANING_ACTIVITIES_BY_DRIVER_TYPE_FISCAL_YEAR]
	AS
    SELECT alternative_id, driver_type, reporting_category, fiscal_year, SUM(cost) AS cost, SUM(length_ft) AS length_ft
    FROM ACTIVITIES_FOR_PROCESSING A INNER JOIN ACTIVITY_TYPES B ON (A.activity_type_id = B.activity_type_id)
    WHERE B.name = 'Cleaning'
    GROUP BY alternative_id, driver_type, reporting_category, fiscal_year