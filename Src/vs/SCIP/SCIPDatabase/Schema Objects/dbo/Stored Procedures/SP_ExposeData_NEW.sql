-- =============================================
-- Author:		Issac Gardner
-- Create date: 4/9/2012
-- Description:	Barebones 
-- =============================================
CREATE PROCEDURE [dbo].[SP_ExposeData_NEW]
  @asset_set_id INT = 1
AS
BEGIN
  SET NOCOUNT ON

  DECLARE @statusMessage VARCHAR(200)
  SET @statusMessage = 'Begin SP_ExposeData, asset_set_id = ' + CONVERT(VARCHAR(10), @asset_set_id)
  EXEC SP_STATUS_MESSAGE @statusMessage

  --EXEC SP_STATUS_MESSAGE 'Inserting REHAB10FTSEGS'

  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;

  --------------------------------
  --For the column ROOTPROB in the table COPSEWERMAIN
  DECLARE @ROOTPROB_N char --No Treatment- see notes
  DECLARE @ROOTPROB_H char --High priority
  DECLARE @ROOTPROB_L char --Low priority
  DECLARE @ROOTPROB_R char --Possible Roots(not verified)
  DECLARE @ROOTPROB_M char --Medium priority
  DECLARE @ROOTPROB_V char --Very low priority

  -------------------------
  --OBKEY values for [HANSEN8].[ASSETMANAGEMENT_SEWER].[SMNSERVINSPTYPEOB]
  DECLARE @OBKEY_BP int--Broken pipe
  DECLARE @OBKEY_CR int--Crack
  DECLARE @OBKEY_DB int--Debris
  DECLARE @OBKEY_DS int--Structural Damage (concrete)
  DECLARE @OBKEY_GR int--Grease
  DECLARE @OBKEY_II int--Inflow/Infiltration
  DECLARE @OBKEY_IN int--Inspection
  DECLARE @OBKEY_OB int--Obstacle
  DECLARE @OBKEY_RT int--Roots

  --INDEXKEY values for [HANSEN8].[ASSETMANAGEMENT_SEWER].[SMNINDHIST]
  DECLARE @INDEXKEY_GreaseCount int
  DECLARE @INDEXKEY_GreateRating int
  DECLARE @INDEXKEY_GreaseScore int
  DECLARE @INDEXKEY_RootCount int
  DECLARE @INDEXKEY_RootRating int
  DECLARE @INDEXKEY_RootScore int
  DECLARE @INDEXKEY_StructuralCountStorm int --COMPTYPE FIELD = 31 means a storm pipe
  DECLARE @INDEXKEY_StructuralRatingStorm int --COMPTYPE FIELD = 31 means a storm pipe
  DECLARE @INDEXKEY_StructuralScoreStorm int --COMPTYPE FIELD = 31 means a storm pipe
  DECLARE @INDEXKEY_StructuralAverageEachStorm int --COMPTYPE FIELD = 31 means a storm pipe
  DECLARE @INDEXKEY_StructuralAverageFootStorm int --COMPTYPE FIELD = 31 means a storm pipe
  --DECLARE @INDEXKEY_StructuralRatingNode int --COMPTYPE FIELD = 30 means a node
  DECLARE @INDEXKEY_StructuralCountSanitary int --COMPTYPE FIELD = 21 means a sanitary pipe
  DECLARE @INDEXKEY_StructuralRatingSanitary int --COMPTYPE FIELD = 21 means a sanitary pipe
  DECLARE @INDEXKEY_StructuralScoreSanitary int --COMPTYPE FIELD = 21 means a sanitary pipe
  DECLARE @INDEXKEY_StructuralAverageEachSanitary int --COMPTYPE FIELD = 21 means a sanitary pipe
  DECLARE @INDEXKEY_StructuralAverageFootSanitary int --COMPTYPE FIELD = 21 means a sanitary pipe

  DECLARE @ACTKEY_RTCHEM int
  DECLARE @ACTKEY_SEWCLN int
  DECLARE @ACTKEY_SPCLN int

  SET @ROOTPROB_N = 'N'
  SET @ROOTPROB_H = 'H'
  SET @ROOTPROB_L = 'L'
  SET @ROOTPROB_R = 'R'
  SET @ROOTPROB_M = 'M'
  SET @ROOTPROB_V = 'V'

  SET @OBKEY_BP = 1000
  SET @OBKEY_CR = 1003
  SET @OBKEY_DB = 1004
  SET @OBKEY_DS = 1005
  SET @OBKEY_GR = 1007
  SET @OBKEY_II = 1008
  SET @OBKEY_IN = 1009
  SET @OBKEY_OB = 1013
  SET @OBKEY_RT = 1015

  --INDEXKEY values for [HANSEN8].[ASSETMANAGEMENT].[ASSETINSPINDEX]
  SET @INDEXKEY_GreaseCount = 1000
  SET @INDEXKEY_GreateRating = 1001
  SET @INDEXKEY_GreaseScore = 1002
  SET @INDEXKEY_RootCount = 1004
  SET @INDEXKEY_RootRating = 1005
  SET @INDEXKEY_RootScore = 1006
  SET @INDEXKEY_StructuralCountStorm = 1007
  SET @INDEXKEY_StructuralRatingStorm = 1008
  SET @INDEXKEY_StructuralScoreStorm = 1009
  SET @INDEXKEY_StructuralAverageEachStorm = 1010
  SET @INDEXKEY_StructuralAverageFootStorm = 1011
  SET @INDEXKEY_StructuralCountSanitary = 1014
  SET @INDEXKEY_StructuralRatingSanitary = 1015
  SET @INDEXKEY_StructuralScoreSanitary = 1016
  SET @INDEXKEY_StructuralAverageEachSanitary = 1017
  SET @INDEXKEY_StructuralAverageFootSanitary = 1018

  --These codes need a reference table
  SET @ACTKEY_RTCHEM = 1057
  SET @ACTKEY_SEWCLN = 1061
  SET @ACTKEY_SPCLN  = 1064

  --DELETE FROM RootInspections WHERE asset_set_id = @asset_set_id;
  --DELETE FROM AllInspections WHERE asset_set_id = @asset_set_id;
  --DELETE FROM LatestInspections WHERE asset_set_id = @asset_set_id;
  --DELETE FROM ASSETS WHERE asset_set_id = @asset_set_id;

  -----------------------------------------------------------------------
  --Fill RootInspections with all of the valid 
  --sanitary inspections for root evidence

---############################################################
---############################################################
--@RootInspectionsInsert
/*SELECT C.COMPKEY, 
    S3.INSPKEY, 
    S2.OBRATING, 
    S2.DISTFROM, 
    S2.DISTTO, 
    S3.STARTDTTM, 
    S3.COMPDTTM, 
    C.INSTDATE,
    OBSEV.SEVDESC, 
    A.INSPNDX, 
    S.INDEXVAL, 
    C.OWN, 
    C.UNITTYPE, 
    C.SERVSTAT,
    S2.OBSEVKEY,
    @asset_set_id
FROM 
    HANSEN8.ASSETMANAGEMENT_SEWER.SMNINDHIST S 
    INNER JOIN 
    HANSEN8.ASSETMANAGEMENT.ASSETINSPINDEX A 
    ON  S.INDEXKEY = A.INSPNDXKEY 
    INNER JOIN 
    HANSEN8.ASSETMANAGEMENT_SEWER.SMNSERVINSPOB S2 
    ON  S.INSPKEY = S2.INSPKEY
    INNER JOIN 
    HANSEN8.ASSETMANAGEMENT_SEWER.SMNSERVICEINSP S3 
    ON  S3.INSPKEY = S.INSPKEY
    INNER JOIN 
    HANSEN8.ASSETMANAGEMENT_SEWER.COMPSMN C 
    ON  C.COMPKEY = S3.COMPKEY
    LEFT  JOIN 
    HANSEN8.ASSETMANAGEMENT_SEWER.SMNSERVINSPTYPEOBSEV AS OBSEV 
    ON  S2.OBSEVKEY = OBSEV.OBSEVKEY
WHERE  
    S.INDEXKEY IN (@INDEXKEY_RootCount, @INDEXKEY_RootRating, @INDEXKEY_RootScore)
    AND 
    S2.OBKEY = @OBKEY_RT*/


---############################################################
---############################################################
--@AllInspections
/*SELECT C.COMPKEY, 
    S3.INSPKEY, 
    S2.OBRATING, 
    S2.DISTFROM, 
    S2.DISTTO, 
    S3.STARTDTTM, 
    S3.COMPDTTM, 
    C.INSTDATE, 
    NULL,
    A.INSPNDX, 
    S.INDEXVAL, 
    C.OWN, 
    C.UNITTYPE, 
    C.SERVSTAT,
    S2.OBSEVKEY
FROM 
    HANSEN8.ASSETMANAGEMENT_SEWER.SMNINDHIST S 
    INNER JOIN 
    HANSEN8.ASSETMANAGEMENT.ASSETINSPINDEX A 
    ON S.INDEXKEY = A.INSPNDXKEY 
    INNER JOIN 
    HANSEN8.ASSETMANAGEMENT_SEWER.SMNSERVINSPOB S2 
    ON S.INSPKEY = S2.INSPKEY
    INNER JOIN 
    HANSEN8.ASSETMANAGEMENT_SEWER.SMNSERVICEINSP S3 
    ON S3.INSPKEY = S.INSPKEY 
    INNER JOIN 
    HANSEN8.ASSETMANAGEMENT_SEWER.COMPSMN C 
    ON C.COMPKEY = S3.COMPKEY
    LEFT  JOIN 
    HANSEN8.ASSETMANAGEMENT_SEWER.SMNSERVINSPTYPEOBSEV AS OBSEV 
    ON  S2.OBSEVKEY = OBSEV.OBSEVKEY
WHERE S.INDEXKEY IN (@INDEXKEY_RootCount, @INDEXKEY_RootRating, @INDEXKEY_RootScore)
      AND 
      S2.OBKEY = @OBKEY_RT*/



---############################################################
---############################################################
--LatestInspections
/*SELECT  COMPKEY, 
        MAX(STARTDTTM) AS LastInspected
FROM    (
           SELECT  C.COMPKEY, 
                   S3.STARTDTTM 
           FROM    HANSEN8.ASSETMANAGEMENT_SEWER.SMNINDHIST S 
                   INNER JOIN 
                   HANSEN8.ASSETMANAGEMENT.ASSETINSPINDEX A 
                   ON S.INDEXKEY = A.INSPNDXKEY 
                   INNER JOIN 
                   HANSEN8.ASSETMANAGEMENT_SEWER.SMNSERVINSPOB S2 
                   ON S.INSPKEY = S2.INSPKEY
                   INNER JOIN 
                   HANSEN8.ASSETMANAGEMENT_SEWER.SMNSERVICEINSP S3 
                   ON S3.INSPKEY = S.INSPKEY 
                   INNER JOIN 
                   HANSEN8.ASSETMANAGEMENT_SEWER.COMPSMN C 
                   ON C.COMPKEY = S3.COMPKEY
                   LEFT JOIN 
                   HANSEN8.ASSETMANAGEMENT_SEWER.SMNSERVINSPTYPEOBSEV AS OBSEV 
                   ON  S2.OBSEVKEY = OBSEV.OBSEVKEY
           WHERE   S.INDEXKEY IN (@INDEXKEY_RootCount, @INDEXKEY_RootRating, @INDEXKEY_RootScore)
                   AND 
                   S2.OBKEY = @OBKEY_RT
        ) AS A
GROUP BY COMPKEY*/


---############################################################
---############################################################
DELETE FROM dbo.ASSETS
--[dbo].[ASSETS]
EXEC SP_STATUS_MESSAGE 'Inserting Assets'
INSERT INTO [dbo].[ASSETS] (COMPKEY, length_ft, diamWidth_inches, height_inches, unit_type, basin_id, district_id, last_inspection_date, last_root_management_date, last_root_inspection_date, last_cleaning_date, structural_grade, asset_set_id, unitid, unitid2, pipe_age_years, [material], [install_date])
SELECT	A.COMPKEY,
        A.PIPELEN,
        A.PIPEDIAM,
        A.PIPEHT,
        A.UNITTYPE,
        Basin_ID,
        District_ID,
        MaxDates.LastInspected AS last_inspection_date,
        ISNULL(Res_Dates.COMPDTTM, RootDates.COMPDTTM) AS last_root_management_date,
        MaxRootDates.LastInspected AS last_root_inspection_date,
        ISNULL(last_cleaning_res.COMPDTTM, last_cleaning.COMPDTTM) AS last_cleaning_date,
        structural_grade,
        @asset_set_id,
        A.UNITID,
        A.UNITID2,
        DATEDIFF(YEAR, A.INSTDATE, GETDATE()) AS pipe_age_years,
	    A.PIPETYPE,
	    A.INSTDATE
FROM	(
        (
        (
        (
        (
        (
        (
        (
        (
			HCOMPSMN A 
			INNER JOIN 
			HCOMPSMH B 
			ON	A.UNITID = B.UNITID
		) 
		INNER JOIN 
		HCOMPSMH C 
		ON	A.UNITID2 = C.UNITID
		)
		LEFT JOIN
		(
		  SELECT  C.COMPKEY, 
                  MAX(S3.STARTDTTM) AS LastInspected
          FROM    HSMNINDHIST S 
                  INNER JOIN 
                  HASSETINSPINDEX A 
                  ON S.INDEXKEY = A.INSPNDXKEY 
                  INNER JOIN 
                  HSMNSERVINSPOB S2 
                  ON S.INSPKEY = S2.INSPKEY
                  INNER JOIN 
                  HSMNSERVICEINSP S3 
                  ON S3.INSPKEY = S.INSPKEY 
                  INNER JOIN 
                  HCOMPSMN C 
                  ON C.COMPKEY = S3.COMPKEY
                  LEFT JOIN 
                  HSMNSERVINSPTYPEOBSEV AS OBSEV 
                  ON  S2.OBSEVKEY = OBSEV.OBSEVKEY
          --WHERE   S.INDEXKEY IN (@INDEXKEY_RootCount, @INDEXKEY_RootRating, @INDEXKEY_RootScore)
          --        AND 
                  --S2.OBKEY = @OBKEY_RT
          GROUP BY C.COMPKEY
        ) AS MaxDates
        ON  MaxDates.COMPKEY = A.COMPKEY
        LEFT JOIN
		(
		  SELECT  C.COMPKEY, 
                  MAX(S3.STARTDTTM) AS LastInspected
          FROM    HSMNINDHIST S 
                  INNER JOIN 
                  HASSETINSPINDEX A 
                  ON S.INDEXKEY = A.INSPNDXKEY 
                  INNER JOIN 
                  HSMNSERVINSPOB S2 
                  ON S.INSPKEY = S2.INSPKEY
                  INNER JOIN 
                  HSMNSERVICEINSP S3 
                  ON S3.INSPKEY = S.INSPKEY 
                  INNER JOIN 
                  HCOMPSMN C 
                  ON C.COMPKEY = S3.COMPKEY
                  LEFT JOIN 
                  HSMNSERVINSPTYPEOBSEV AS OBSEV 
                  ON  S2.OBSEVKEY = OBSEV.OBSEVKEY
          WHERE   S.INDEXKEY IN (@INDEXKEY_RootCount, @INDEXKEY_RootRating, @INDEXKEY_RootScore)
                  AND 
                  S2.OBKEY = @OBKEY_RT
          GROUP BY C.COMPKEY
        ) AS MaxRootDates
        ON  MaxRootDates.COMPKEY = A.COMPKEY
        )
        LEFT JOIN
		  (
		    SELECT	A.COMPKEY, MAX(A.COMPDTTM) AS COMPDTTM--A.ACTKEY, A.RES, A.ACTUALQTY, 
		    FROM	HHISTORY AS A
		            INNER JOIN
		            HCOMPSMN AS B
		            ON  A.COMPKEY = B.COMPKEY
		    WHERE   ACTKEY = @ACTKEY_RTCHEM
		    GROUP BY A.COMPKEY
          )AS RootDates
        ON  A.COMPKEY = RootDates.COMPKEY
        )
        LEFT JOIN
        (
            SELECT  A.COMPKEY, MAX(A.COMPDTTM) AS COMPDTTM
            FROM    HHISTORY AS A
                    INNER JOIN 
                    HCOMPSMN AS B
                    ON  A.COMPKEY = B.COMPKEY
                        AND
                        (
                          (
                            A.RES = 'COMPLTED'
                            OR 
                            A.RES = 'OTHERS'
                          )
                          OR 
                          (
                            A.RES = 'INCMPLT'
                            AND 
                            A.ACTUALQTY > 0
                          )
                        )
            WHERE   ACTKEY = @ACTKEY_RTCHEM	
            GROUP BY A.COMPKEY
          )AS Res_dates
          ON A.COMPKEY = Res_dates.COMPKEY
          )
          LEFT JOIN
		  (
		    SELECT  A.COMPKEY, MAX(A.COMPDTTM) AS COMPDTTM
		    FROM    HHISTORY AS A
		            INNER JOIN 
		            HCOMPSMN AS B
		            ON  A.COMPKEY = B.COMPKEY
		    WHERE   ACTKEY = @ACTKEY_SPCLN
		            OR
		            ACTKEY = @ACTKEY_SEWCLN
		    GROUP BY A.COMPKEY
		  )AS last_cleaning
		  ON A.COMPKEY = last_cleaning.COMPKEY
		  )
		  LEFT JOIN
		  (
		    SELECT  A1.COMPKEY, MAX(A1.COMPDTTM) AS COMPDTTM
		    FROM    HHISTORY AS A1
		            INNER JOIN 
		            HCOMPSMN AS B1
		            ON  A1.COMPKEY = B1.COMPKEY
		    WHERE   (
		              ACTKEY = @ACTKEY_SPCLN
		              OR
		              ACTKEY = @ACTKEY_SEWCLN
		            )
		            AND
		            (
		              (
		                A1.RES = 'COMPLTED'
		                OR 
		                A1.RES = 'OTHERS'
		              )
		              OR 
		              (
		                A1.RES = 'INCMPLT'
		                AND 
		                A1.ACTUALQTY > 0 
		              )
		            )
		    GROUP BY A1.COMPKEY
		  ) AS last_cleaning_res
		  ON A.COMPKEY = last_cleaning_res.COMPKEY
		  )
		  LEFT JOIN
		  (
			  SELECT  B.COMPKEY, C.BASIN_ID
			  FROM    HCOMPSMN AS B
			          INNER JOIN
			          BASINS AS C
			          ON  B.AREA = C.hansen_area
		  ) AS theBasins
		  ON  A.COMPKEY = theBasins.COMPKEY
		  )
		  LEFT JOIN
		  (
		    SELECT  B.COMPKEY, C.DISTRICT_ID
		    FROM    HCOMPSMN AS B
		            INNER JOIN
		            DISTRICTS AS C
		            ON  B.DISTRICT = C.district_id
		  ) AS theDistricts
		  ON A.COMPKEY = theDistricts.COMPKEY
		  )
		  LEFT JOIN
		  (
		    SELECT  COMPKEY, MAX(grade_h5) as STRUCTURAL_GRADE
		    FROM    REHAB10FTSEGS
		    GROUP BY COMPKEY
		  ) AS StructGrades
		  ON A.COMPKEY = StructGrades.COMPKEY
WHERE	(
			A.OWN = 'BES' 
			OR 
			A.OWN = 'DNRV'
		)
		AND 
		A.UNITTYPE IN ('CSINT', 'CSML', 'CSOTN', 'SAINT', 'SAML')
		AND 
		A.SERVSTAT NOT IN ('ABAN', 'DNE', 'TBAB')
EXEC SP_STATUS_MESSAGE 'Completed.'

END