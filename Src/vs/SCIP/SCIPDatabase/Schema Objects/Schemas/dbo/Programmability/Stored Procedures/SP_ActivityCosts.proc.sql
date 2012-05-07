-- =============================================
-- Author:		Issac Gardner
-- Create date: 4/9/2012
-- Description:	Barebones 
-- =============================================
CREATE PROCEDURE [dbo].[SP_ActivityCosts]
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

CREATE TABLE #_AllDue
(
	COMPKEY int,
	last_activity_date datetime,
	next_activity_date datetime,
	cost money,
	reason nvarchar(20)
)

INSERT INTO #_RootsDue (Compkey, last_service_date, next_service_date, cost)
SELECT	ASSETS.COMPKEY, 
        ASSETS.last_root_management_date,
        CASE WHEN	DATEADD(year, A.default_frequency_years, ASSETS.last_root_management_date) < GetDate() 
					/*OR 
					ASSETS.last_root_management_date IS NULL*/
        THEN		GetDate()
		ELSE		DATEADD(year, A.default_frequency_years, ASSETS.last_root_management_date) END
        AS next_service_date, 
        A.default_cost_per_ft * ASSETS.length_ft AS next_root_management_cost
FROM	ASSETS 
		INNER JOIN
		(
			/*Drivers For Root control H small pipes*/ SELECT DRIVER_TYPE_ID, ASSETS.COMPKEY, default_cost_per_ft, default_frequency_years
			FROM	(ASSETS INNER JOIN
								  DRIVER_TYPES ON (DRIVER_TYPES.activity_type_id = 2 AND DRIVER_TYPES.Driver_type_id = 33 AND 
								  (ASSETS.last_root_management_date IS NOT NULL) AND (ASSETS.diamWidth_inches <= 36 AND ASSETS.height_inches <= 36))) INNER JOIN
								  SpecialRoot ON ASSETS.COMPKEY = Specialroot.compkey AND Specialroot.ROOTPROB = 'H'
			/*Drivers For Root control H large pipes*/ UNION
			SELECT     DRIVER_TYPE_ID, ASSETS.COMPKEY, default_cost_per_ft, default_frequency_years
			FROM         (ASSETS INNER JOIN
								  DRIVER_TYPES ON (DRIVER_TYPES.activity_type_id = 2 AND DRIVER_TYPES.Driver_type_id = 34 AND 
								  (ASSETS.last_root_management_date IS NOT NULL) AND (ASSETS.diamWidth_inches > 36 OR
								  ASSETS.height_inches > 36))) INNER JOIN
								  SpecialRoot ON ASSETS.COMPKEY = Specialroot.compkey AND Specialroot.ROOTPROB = 'H'
			/*Drivers For Root control M small pipes*/ UNION
			SELECT     DRIVER_TYPE_ID, ASSETS.COMPKEY, default_cost_per_ft, default_frequency_years
			FROM         (ASSETS INNER JOIN
								  DRIVER_TYPES ON (DRIVER_TYPES.activity_type_id = 2 AND DRIVER_TYPES.Driver_type_id = 33 AND 
								  (ASSETS.last_root_management_date IS NOT NULL) AND (ASSETS.diamWidth_inches <= 36 AND ASSETS.height_inches <= 36))) INNER JOIN
								  SpecialRoot ON ASSETS.COMPKEY = Specialroot.compkey AND Specialroot.ROOTPROB = 'M'
			/*Drivers For Root control M large pipes*/ UNION
			SELECT     DRIVER_TYPE_ID, ASSETS.COMPKEY, default_cost_per_ft, default_frequency_years
			FROM         (ASSETS INNER JOIN
								  DRIVER_TYPES ON (DRIVER_TYPES.activity_type_id = 2 AND DRIVER_TYPES.Driver_type_id = 34 AND 
								  (ASSETS.last_root_management_date IS NOT NULL) AND (ASSETS.diamWidth_inches > 36 OR
								  ASSETS.height_inches > 36))) INNER JOIN
								  SpecialRoot ON ASSETS.COMPKEY = Specialroot.compkey AND Specialroot.ROOTPROB = 'M'
		) AS A 
		ON	A.COMPKEY = ASSETS.COMPKEY

                      
------------------------------------------------------------------------------------------
--Grease service dates and costs
------------------------------------------------------------------------------------------
INSERT INTO #_GreaseDue (Compkey, last_service_date, next_service_date, cost)
SELECT	dbo.ASSETS.COMPKEY, 
		dbo.ASSETS.last_cleaning_date AS last_service_date,
		CASE WHEN	DATEADD(year, A.default_frequency_years, dbo.ASSETS.last_cleaning_date) < GetDate()
					/*OR 
					ASSETS.last_cleaning_date IS NULL*/
		THEN		GetDate()
		ELSE		DATEADD(year, A.default_frequency_years, dbo.ASSETS.last_cleaning_date) END
		AS next_service_date, 
        A.default_cost_per_ft * dbo.ASSETS.length_ft AS next_service_cost
FROM	dbo.ASSETS 
		INNER JOIN
        (
			SELECT	dbo.DRIVER_TYPES.driver_type_id, 
					dbo.ASSETS.COMPKEY, 
					dbo.DRIVER_TYPES.default_cost_per_ft, 
                    dbo.DRIVER_TYPES.default_frequency_years
			FROM	dbo.ASSETS 
					INNER JOIN
					dbo.DRIVER_TYPES 
					ON	dbo.DRIVER_TYPES.activity_type_id = 3 
						AND 
						dbo.DRIVER_TYPES.driver_type_id = 25 
						AND 
						dbo.ASSETS.last_cleaning_date IS NOT NULL
		) AS A
		ON	A.COMPKEY = dbo.ASSETS.COMPKEY

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

------------------------------------------------------------------------------------------
--Combine inspections data
------------------------------------------------------------------------------------------ 
INSERT INTO #_InspectionsDue(COMPKEY, next_inspection_date, reason, last_inspection_date, cost)
SELECT	COMPKEY, next_inspection_date, 'PMInsp', last_inspection_date, cost
FROM    #_InspectionsDuePM

INSERT INTO #_InspectionsDue(COMPKEY, next_inspection_date, reason, last_inspection_date, cost)
SELECT	COMPKEY, next_inspection_date, 'CondInsp', last_inspection_date, cost
FROM    #_InspectionsDueCondition

/*INSERT INTO #_InspectionsDue(COMPKEY, next_inspection_date)
SELECT	COMPKEY, MIN(next_inspection_date)
FROM
		(
			SELECT Compkey, next_inspection_date FROM #_InspectionsDuePM
			UNION
			SELECT Compkey, next_inspection_date FROM #_InspectionsDueCondition
		) AS A
GROUP BY COMPKEY

UPDATE	#_InspectionsDue
SET		reason = 'PMInsp', 
		#_InspectionsDue.last_inspection_date = #_InspectionsDuePM.last_inspection_date, 
		#_InspectionsDue.cost = #_InspectionsDuePM.cost
FROM	#_InspectionsDue
		INNER JOIN
		#_InspectionsDuePM
		ON	#_InspectionsDue.COMPKEY = #_InspectionsDuePM.COMPKEY
			AND 
			#_InspectionsDue.next_inspection_date = #_InspectionsDuePM.next_inspection_date

UPDATE	#_InspectionsDue
SET		reason = 'CondInsp', 
		#_InspectionsDue.last_inspection_date = #_InspectionsDueCondition.last_inspection_date,
		#_InspectionsDue.cost = #_InspectionsDueCondition.cost
FROM	#_InspectionsDue
		INNER JOIN
		#_InspectionsDueCondition
		ON	#_InspectionsDue.COMPKEY = #_InspectionsDueCondition.COMPKEY
			AND 
			#_InspectionsDue.next_inspection_date = #_InspectionsDueCondition.next_inspection_date
			*/
------------------------------------------------------------------------------------------
--Combine all data
------------------------------------------------------------------------------------------   
INSERT INTO #_AllDue(COMPKEY, next_activity_date, reason, last_activity_date, cost)
SELECT	COMPKEY, next_inspection_date, 'PMInsp', last_inspection_date, cost
FROM    #_InspectionsDuePM

INSERT INTO #_AllDue(COMPKEY, next_activity_date, reason, last_activity_date, cost)
SELECT	COMPKEY, next_inspection_date, 'CondInsp', last_inspection_date, cost
FROM    #_InspectionsDueCondition

INSERT INTO #_AllDue(COMPKEY, next_activity_date, reason, last_activity_date, cost)
SELECT	COMPKEY, next_service_date, 'Grease', last_service_date, cost
FROM    #_GreaseDue

INSERT INTO #_AllDue(COMPKEY, next_activity_date, reason, last_activity_date, cost)
SELECT	COMPKEY, next_service_date, 'Roots', last_service_date, cost
FROM    #_RootsDue

/*INSERT INTO #_AllDue(COMPKEY, next_activity_date)
SELECT	COMPKEY, MIN(next_activity_date)
FROM
		(
			SELECT Compkey, next_inspection_date AS next_activity_date FROM #_InspectionsDue
			UNION
			SELECT Compkey, next_service_date AS next_activity_date FROM #_GreaseDue
			UNION
			SELECT Compkey, next_service_date AS next_activity_date FROM #_RootsDue
		) AS A
GROUP BY COMPKEY

UPDATE	#_AllDue
SET		#_AllDue.reason = #_InspectionsDue.reason, 
		#_AllDue.last_activity_date = #_InspectionsDue.last_inspection_date, 
		#_AllDue.cost = #_InspectionsDue.cost
FROM	#_AllDue
		INNER JOIN
		#_InspectionsDue
		ON	#_AllDue.COMPKEY = #_InspectionsDue.COMPKEY
			AND 
			#_AllDue.next_activity_date = #_InspectionsDue.next_inspection_date

UPDATE	#_AllDue
SET		#_AllDue.reason = 'Grease', 
		#_AllDue.last_activity_date = #_GreaseDue.last_service_date, 
		#_AllDue.cost = #_GreaseDue.cost
FROM	#_AllDue
		INNER JOIN
		#_GreaseDue
		ON	#_AllDue.COMPKEY = #_GreaseDue.COMPKEY
			AND 
			#_AllDue.next_activity_date = #_GreaseDue.next_service_date

UPDATE	#_AllDue
SET		#_AllDue.reason = 'Roots', 
		#_AllDue.last_activity_date = #_RootsDue.last_service_date, 
		#_AllDue.cost = #_RootsDue.cost
FROM	#_AllDue
		INNER JOIN
		#_RootsDue
		ON	#_AllDue.COMPKEY = #_RootsDue.COMPKEY
			AND 
			#_AllDue.next_activity_date = #_RootsDue.next_service_date
			*/
DELETE FROM ACTIVITIES

INSERT INTO ACTIVITIES (COMPKEY, hansen_activity_code, activity_date, cost)
SELECT COMPKEY, Reason, next_activity_date, cost
FROM #_AllDue

/*
SELECT	* 
FROM	#_InspectionsDue

SELECT	*
FROM	#_GreaseDue

SELECT	*
FROM	#_RootsDue*/


END

