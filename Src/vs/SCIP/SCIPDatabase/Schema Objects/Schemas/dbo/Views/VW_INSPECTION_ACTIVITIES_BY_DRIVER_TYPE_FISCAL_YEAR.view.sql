CREATE VIEW [dbo].[VW_INSPECTION_ACTIVITIES_BY_DRIVER_TYPE_FISCAL_YEAR]
	AS
    SELECT driver_type, fiscal_year, SUM(cost) AS cost, SUM(length_ft) AS length_ft
    FROM VW_ALL_ACTIVITIES A INNER JOIN ACTIVITY_TYPES B ON (A.activity_type_id = B.activity_type_id)
    WHERE B.name = 'Inspection'
    GROUP BY driver_type, fiscal_year