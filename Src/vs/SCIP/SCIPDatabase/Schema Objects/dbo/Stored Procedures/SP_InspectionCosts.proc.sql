-- =============================================
-- Author:		Issac Gardner
-- Create date: 4/9/2012
-- Description:	Barebones 
-- =============================================
CREATE PROCEDURE [dbo].[SP_InspectionCosts]
AS
BEGIN

CREATE TABLE #_GreaseDue
(
	COMPKEY int,
	last_service_date datetime,
	next_service_date datetime,
	cost money
)

CREATE TABLE #_RootsDue
(
	COMPKEY int,
	last_service_date datetime,
	next_service_date datetime,
	cost money
)

CREATE TABLE #_InspectionsDuePM
(
	COMPKEY int,
	last_inspection_date datetime,
	next_inspection_date datetime,
	cost money
)

CREATE TABLE #_InspectionsDueCondition
(
	COMPKEY int,
	last_inspection_date datetime,
	next_inspection_date datetime,
	cost money
)

CREATE TABLE #_InspectionsDue
(
	COMPKEY int,
	last_inspection_date datetime,
	next_inspection_date datetime,
	cost money,
	reason nvarchar(20)
)

------------------------------------------------------------------------------------------
--Inspections dates and costs for PM
------------------------------------------------------------------------------------------
INSERT INTO #_InspectionsDuePM (COMPKEY, last_inspection_date, next_inspection_date, cost)
(
	SELECT	COMPKEY, 
			last_inspection_date, 
			CASE WHEN	
					(
						DATEADD(year, default_frequency_years, last_inspection_date) < GetDate() 
						OR 
						last_inspection_date IS NULL
					) 
			THEN	GetDate() 
			ELSE	DATEADD(year, default_frequency_years, last_inspection_date) 
			END AS	next_inspection_date,
			default_cost_per_ft * length_ft AS COST
	FROM	ASSETS 
			INNER JOIN
			DRIVER_TYPES 
			ON (
					DRIVER_TYPES.activity_type_id = 1 
					AND 
					DRIVER_TYPES.Driver_type_id = 19 
					AND 
					(
						ASSETS.diamWidth_inches <= 36 
						AND 
						ASSETS.height_inches <= 36
					)
				)
	/*Drivers For large diameter PM inspections*/ 
	UNION
	SELECT	COMPKEY, 
			last_inspection_date, 
			CASE WHEN 
					(	
						DATEADD(year, default_frequency_years, last_inspection_date) < GetDate() 
						OR 
						last_inspection_date IS NULL
					) 
			THEN	GetDate() 
			ELSE	DATEADD(year, default_frequency_years, last_inspection_date) 
			END AS	next_inspection_date, 
			default_cost_per_ft * length_ft AS COST
	FROM	ASSETS 
			INNER JOIN
			DRIVER_TYPES 
			ON (
					DRIVER_TYPES.activity_type_id = 1 
					AND 
					DRIVER_TYPES.Driver_type_id = 20 
					AND 
					(
						ASSETS.diamWidth_inches > 36 
						OR
						ASSETS.height_inches > 36
					)
				)
)

------------------------------------------------------------------------------------------
--Inspections dates and costs for Condition
------------------------------------------------------------------------------------------                      
INSERT INTO #_InspectionsDueCondition (COMPKEY, last_inspection_date, next_inspection_date, cost)
/*Drivers for small diameter PM inspections*/
(
	SELECT	ASSETS.COMPKEY, 
			last_inspection_date, 
            CASE WHEN
					(
						DATEADD(year, default_frequency_years, last_inspection_date) < GetDate() 
						OR 
						last_inspection_date IS NULL
					)
			THEN	GetDate() 
			ELSE	DATEADD(year, default_frequency_years, last_inspection_date) 
			END AS	next_inspection_date, 
					default_cost_per_ft * length_ft AS COST
	FROM    (
				ASSETS 
				INNER JOIN
                DRIVER_TYPES 
                ON
					(
						DRIVER_TYPES.activity_type_id = 1 
						AND 
						DRIVER_TYPES.Driver_type_id = 23 
						AND 
						(
							ASSETS.diamWidth_inches <= 36 
							AND 
							ASSETS.height_inches <= 36
						)
					)
			) INNER JOIN
					(	
						SELECT	compkey, ACCUM_RISK_INSPECT_YEAR
                        FROM	REHAB10FTSEGS
                        WHERE	mlinkid < 40000000 
								AND 
								(
									remarks = N'BES' 
									OR
                                    remarks = N'DNRV'
                                 ) 
                                 AND 
                                 ACCUM_RISK_INSPECT_YEAR IS NOT NULL
                     ) AS X 
                     ON	ASSETS.COMPKEY = X.COMPKEY
/*Drivers For large diameter PM inspections*/ 
	UNION
	SELECT	ASSETS.COMPKEY, 
			last_inspection_date, 
			CASE WHEN 
					(
						DATEADD(year, default_frequency_years, last_inspection_date) < GetDate() 
						OR 
						last_inspection_date IS NULL
					)
			THEN	GetDate() 
			ELSE	DATEADD(year, default_frequency_years, last_inspection_date) 
            END AS	next_inspection_date, 
            default_cost_per_ft * length_ft AS COST
	FROM	ASSETS 
			INNER JOIN
            DRIVER_TYPES 
            ON	
				(
					DRIVER_TYPES.activity_type_id = 1 
					AND 
					DRIVER_TYPES.Driver_type_id = 24 
					AND 
					(
						ASSETS.diamWidth_inches > 36 
						OR
						ASSETS.height_inches > 36
					)
				) 
				INNER JOIN
                (
					SELECT	compkey, ACCUM_RISK_INSPECT_YEAR
                    FROM	REHAB10FTSEGS
                    WHERE   mlinkid < 40000000 
							AND 
							(
								remarks = N'BES' 
								OR
                                remarks = N'DNRV'
                            )
                            AND
                            ACCUM_RISK_INSPECT_YEAR IS NOT NULL
				) AS X 
				ON	ASSETS.COMPKEY = X.COMPKEY
)

INSERT INTO #_InspectionsDue(COMPKEY, next_inspection_date)
SELECT	COMPKEY, MIN(next_inspection_date)
FROM
		(
			SELECT Compkey, next_inspection_date FROM #_InspectionsDuePM
			UNION
			SELECT Compkey, next_inspection_date FROM #_InspectionsDueCondition
		) AS A
GROUP BY COMPKEY

UPDATE	#_InspectionsDue
SET		reason = 'PM', 
		#_InspectionsDue.last_inspection_date = #_InspectionsDuePM.last_inspection_date, 
		#_InspectionsDue.cost = #_InspectionsDuePM.cost
FROM	#_InspectionsDue
		INNER JOIN
		#_InspectionsDuePM
		ON	#_InspectionsDue.COMPKEY = #_InspectionsDuePM.COMPKEY
			AND 
			#_InspectionsDue.next_inspection_date = #_InspectionsDuePM.next_inspection_date

UPDATE	#_InspectionsDue
SET		reason = 'Condition', 
		#_InspectionsDue.last_inspection_date = #_InspectionsDueCondition.last_inspection_date,
		#_InspectionsDue.cost = #_InspectionsDueCondition.cost
FROM	#_InspectionsDue
		INNER JOIN
		#_InspectionsDueCondition
		ON	#_InspectionsDue.COMPKEY = #_InspectionsDueCondition.COMPKEY
			AND 
			#_InspectionsDue.next_inspection_date = #_InspectionsDueCondition.next_inspection_date

SELECT	* 
FROM	#_InspectionsDue


END

