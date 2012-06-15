-- =============================================
-- Author:		Issac Gardner
-- Create date: 4/9/2012
-- Description:	Barebones 
-- =============================================
CREATE PROCEDURE [dbo].[SP_ExposeData]
  @asset_set_id INT = 1
AS
BEGIN
  SET NOCOUNT ON

  DECLARE @statusMessage VARCHAR(200)
  SET @statusMessage = 'Begin SP_ExposeData, asset_set_id = ' + CONVERT(VARCHAR(10), @asset_set_id)
  EXEC SP_STATUS_MESSAGE @statusMessage

  EXEC SP_STATUS_MESSAGE 'Inserting REHAB10FTSEGS'
		
  INSERT INTO [REHAB10FTSEGS]
  SELECT *, @asset_set_id FROM [REHAB].[GIS].[REHAB10FTSEGS]
  WHERE MlinkID < 40000000

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
  --OBKEY values for [HANSEN8].[ASSETMANAGEMENT_SEWER].[SMNSERVINSPOB]
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

  --INDEXKEY values for [HANSEN8].[ASSETMANAGEMENT_SEWER].[SMNINDHIST]
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
  --SET @INDEXKEY_StructuralRatingNode = 
  SET @INDEXKEY_StructuralCountSanitary = 1014
  SET @INDEXKEY_StructuralRatingSanitary = 1015
  SET @INDEXKEY_StructuralScoreSanitary = 1016
  SET @INDEXKEY_StructuralAverageEachSanitary = 1017
  SET @INDEXKEY_StructuralAverageFootSanitary = 1018

  SET @ACTKEY_RTCHEM = 1057
  SET @ACTKEY_SEWCLN = 1061
  SET @ACTKEY_SPCLN = 1064

  DELETE FROM RootInspections WHERE asset_set_id = @asset_set_id;
  DELETE FROM AllInspections WHERE asset_set_id = @asset_set_id;
  DELETE FROM LatestInspections WHERE asset_set_id = @asset_set_id;
  DELETE FROM ASSETS WHERE asset_set_id = @asset_set_id;

  -----------------------------------------------------------------------
  --Fill RootInspections with all of the valid 
  --sanitary inspections for root evidence
  EXEC SP_STATUS_MESSAGE 'Inserting RootInspections'

  INSERT	INTO  RootInspections 
  SELECT	C2.COMPKEY AS COMPKEY,
		  C2.INSPKEY AS INSPKEY, 
		  OBRATING AS OBRATING, 
		  C3.DISTFROM AS [FROM], 
		  C3.DISTTO	AS [TO], 
		  STARTDTTM,		
      COMPDTTM,		
      INSTDATE,	
		  C5.SEVDESC,		
      C6.INSPNDX,		
      INDEXVAL,	
		  OWN,			
      UnitType,		
      ServStat, 
      @asset_set_id
	  FROM(
			  (
				  (
					  [HANSEN8].[ASSETMANAGEMENT_SEWER].COMPSMN AS C1 
					  INNER JOIN 
					  (
						  [HANSEN8].[ASSETMANAGEMENT_SEWER].[SMNSERVICEINSP] AS C2 
						  INNER JOIN 
						  [HANSEN8].[ASSETMANAGEMENT_SEWER].[SMNSERVINSPOB] AS C3
						  ON C2.INSPKEY=C3.INSPKEY
					  ) 
					  ON C1.COMPKEY=C2.COMPKEY
				  ) 
				  INNER JOIN 
				  [HANSEN8].[ASSETMANAGEMENT_SEWER].[SMNINDHIST] AS C4 
				  ON	C3.INSPKEY = C4.INSPKEY 
					  AND 
					  (
						  C4.INDEXKEY = @INDEXKEY_RootCount OR
						  C4.INDEXKEY = @INDEXKEY_RootRating OR
						  C4.INDEXKEY = @INDEXKEY_RootScore 
					  )
			  ) 
			  INNER JOIN 
			  [HANSEN8].[ASSETMANAGEMENT_SEWER].[SMNSERVINSPTYPEOBSEV] AS C5
			  ON	C5.OBSEVKEY = C3.OBSEVKEY
		  ) 
		  INNER JOIN 
		  [HANSEN8].[ASSETMANAGEMENT].[ASSETINSPINDEX] AS C6
		  ON C6.INSPNDXKEY = C4.INDEXKEY
  WHERE C3.OBKEY = @OBKEY_RT

  -----------------------------------------------------------------------
  --Fill LatestInspections with all of the valid 
  --sanitary inspections
  EXEC SP_STATUS_MESSAGE 'Inserting AllInspections'

  INSERT	INTO  AllInspections 
  SELECT	C2.COMPKEY AS COMPKEY,
		  C2.INSPKEY AS INSPKEY, 
		  OBRATING AS OBRATING, 
		  C3.DISTFROM AS [FROM], 
		  C3.DISTTO	AS [TO], 
		  STARTDTTM,		
      COMPDTTM,		
      INSTDATE,	
		  C5.SEVDESC,		
      C6.INSPNDX,		
      INDEXVAL,	
		  OWN,			
      UnitType,		
      ServStat,
      @asset_set_id
	  FROM(
			  (
				  (
					  [HANSEN8].[ASSETMANAGEMENT_SEWER].COMPSMN AS C1 
					  INNER JOIN 
					  (
						  [HANSEN8].[ASSETMANAGEMENT_SEWER].[SMNSERVICEINSP] AS C2 
						  INNER JOIN 
						  [HANSEN8].[ASSETMANAGEMENT_SEWER].[SMNSERVINSPOB] AS C3
						  ON C2.INSPKEY=C3.INSPKEY
					  ) 
					  ON C1.COMPKEY=C2.COMPKEY
				  ) 
				  INNER JOIN 
				  [HANSEN8].[ASSETMANAGEMENT_SEWER].[SMNINDHIST] AS C4 
				  ON	C3.INSPKEY = C4.INSPKEY 
			  ) 
			  INNER JOIN 
			  [HANSEN8].[ASSETMANAGEMENT_SEWER].[SMNSERVINSPTYPEOBSEV] AS C5
			  ON	C5.OBSEVKEY = C3.OBSEVKEY
		  ) 
		  INNER JOIN 
		  [HANSEN8].[ASSETMANAGEMENT].[ASSETINSPINDEX] AS C6
		  ON C6.INSPNDXKEY = C4.INDEXKEY

  EXEC SP_STATUS_MESSAGE 'Inserting LatestInspections'

  INSERT	INTO  LatestInspections 
  SELECT  COMPKEY, 
    MAX(STARTDTTM) AS LastInspected, 
    @asset_set_id
  FROM    dbo.AllInspections AS AllInspections_1
  GROUP BY COMPKEY

  EXEC SP_STATUS_MESSAGE 'Inserting Assets'

  INSERT INTO [dbo].[ASSETS] (COMPKEY, length_ft, diamWidth_inches, height_inches, unit_type, basin_id, district_id, asset_set_id)
  SELECT	A.COMPKEY ,
		  A.PIPELEN,
		  A.PIPEDIAM,
		  A.PIPEHT,
      A.UNITTYPE,
      'NUL',
      'NULL',
      @asset_set_id
  FROM	([HANSEN8].[ASSETMANAGEMENT_SEWER].COMPSMN A INNER JOIN [HANSEN8].[ASSETMANAGEMENT_SEWER].COMPSMH B ON (A.UNITID = B.UNITID)) INNER JOIN [HANSEN8].[ASSETMANAGEMENT_SEWER].COMPSMH C ON (A.UNITID2 = C.UNITID)
  WHERE	(A.OWN = 'BES' OR A.OWN = 'DNRV')
		  AND A.UNITTYPE IN ('CSINT', 'CSML', 'CSOTN', 'SAINT', 'SAML')
      AND A.SERVSTAT NOT IN ('ABAN', 'DNE', 'TBAB')


  EXEC SP_STATUS_MESSAGE 'Updating ASSETS (last_inspection_date)'
		
  UPDATE	[dbo].[ASSETS]
  SET		[last_inspection_date] = LastInspected
  FROM	[dbo].[ASSETS]
		  INNER JOIN
		  LatestInspections
		  ON [dbo].[ASSETS].COMPKEY = LatestInspections.COMPKEY
  WHERE ASSETS.asset_set_id = @asset_set_id

  --Update the root management date
  EXEC SP_STATUS_MESSAGE 'Updating ASSETS (last_rot_management_date)'
		
  UPDATE [dbo].[ASSETS]
  SET		last_root_management_date = COMPDTTM
  FROM	[dbo].[ASSETS] AS C
		  INNER JOIN
		  (
			  SELECT	A.COMPKEY, A.ACTKEY, A.RES, A.ACTUALQTY, A.COMPDTTM
			  FROM	[HANSEN8].[WORKMANAGEMENT].[HISTORY] AS A
					  INNER JOIN 
					  [HANSEN8].[ASSETMANAGEMENT_SEWER].[COMPSMN] AS B
					  ON	A.COMPKEY = B.COMPKEY
					  WHERE ACTKEY = @ACTKEY_RTCHEM
					
		  )AS D
		  ON	C.COMPKEY = D.COMPKEY
  WHERE C.asset_set_id = @asset_set_id

  --Update the root management date	if RES available
  EXEC SP_STATUS_MESSAGE 'Updating ASSETS (last_inspection_date if work order results available)'
		
  UPDATE [dbo].[ASSETS]
  SET		last_root_management_date = COMPDTTM
  FROM	[dbo].[ASSETS] AS C
		  INNER JOIN
		  (
			  SELECT	A.COMPKEY, A.ACTKEY, A.RES, A.ACTUALQTY, A.COMPDTTM
			  FROM	[HANSEN8].[WORKMANAGEMENT].[HISTORY] AS A
					  INNER JOIN 
					  [HANSEN8].[ASSETMANAGEMENT_SEWER].[COMPSMN] AS B
					  ON	A.COMPKEY = B.COMPKEY
					  WHERE ACTKEY = @ACTKEY_RTCHEM
					
		  )AS D
		  ON	C.COMPKEY = D.COMPKEY
			  AND 
			  (
				  (
					  D.RES = 'COMPLTED'
					  OR 
					  D.RES = 'OTHERS'
				  )
				  OR 
				  (
					  D.RES = 'INCMPLT'
					  AND 
					  D.ACTUALQTY > 0
				  )
			  )
  WHERE C.asset_set_id = @asset_set_id
			
  --Update the special cleaning date
  EXEC SP_STATUS_MESSAGE 'Updating ASSETS (last_cleaning_date)'
		
  UPDATE  [dbo].[ASSETS]
  SET		last_cleaning_date = COMPDTTM
  FROM	[dbo].[ASSETS] AS C
		  INNER JOIN
		  (
			  SELECT	A.COMPKEY, A.ACTKEY, A.RES, A.ACTUALQTY, A.COMPDTTM
			  FROM	[HANSEN8].[WORKMANAGEMENT].[HISTORY] AS A
					  INNER JOIN 
					  [HANSEN8].[ASSETMANAGEMENT_SEWER].[COMPSMN] AS B
					  ON	A.COMPKEY = B.COMPKEY
					  WHERE 
						  (		
							  ACTKEY = @ACTKEY_SPCLN
							  OR
							  ACTKEY = @ACTKEY_SEWCLN
						  )
					
		  )AS D
		  ON	C.COMPKEY = D.COMPKEY
  WHERE C.asset_set_id = @asset_set_id

  --Update the special cleaning date if RES available
		
  EXEC SP_STATUS_MESSAGE 'Updating ASSETS (last_cleaning_date if work order results available)'
		
  UPDATE  [dbo].[ASSETS]
  SET		last_cleaning_date = COMPDTTM
  FROM	[dbo].[ASSETS] AS C
		  INNER JOIN
		  (
			  SELECT	A.COMPKEY, A.ACTKEY, A.RES, A.ACTUALQTY, A.COMPDTTM
			  FROM	[HANSEN8].[WORKMANAGEMENT].[HISTORY] AS A
					  INNER JOIN 
					  [HANSEN8].[ASSETMANAGEMENT_SEWER].[COMPSMN] AS B
					  ON	A.COMPKEY = B.COMPKEY
					  WHERE 
						  (		
							  ACTKEY = @ACTKEY_SPCLN
							  OR
							  ACTKEY = @ACTKEY_SEWCLN
						  )
					
		  )AS D
		  ON	C.COMPKEY = D.COMPKEY
			  AND 
			  (
				  (
					  D.RES = 'COMPLTED'
					  OR 
					  D.RES = 'OTHERS'
				  )
				  OR 
				  (
					  D.RES = 'INCMPLT'
					  AND 
					  D.ACTUALQTY > 0 --C.length_ft * 0.8
				  )
			  )
  WHERE C.asset_set_id = @asset_set_id
			
  EXEC SP_STATUS_MESSAGE 'Updating ASSETS (basin_id)'
		
  UPDATE	[dbo].[ASSETS]
  SET		BASIN_ID = D.basin_id
  FROM	[dbo].[ASSETS] AS A
		  INNER JOIN
		  (
			  SELECT	B.COMPKEY, C.BASIN_ID
			  FROM	[HANSEN8].[ASSETMANAGEMENT_SEWER].[COMPSMN] AS B
					  INNER JOIN
					  BASINS AS C
					  ON	B.AREA = C.hansen_area
		  ) AS D
		  ON	A.COMPKEY = D.COMPKEY
  WHERE A.asset_set_id = @asset_set_id

  EXEC SP_STATUS_MESSAGE 'Updating ASSETS (district_id)'
		
  UPDATE	[dbo].[ASSETS]
  SET		DISTRICT_ID = D.district_id
  FROM	[dbo].[ASSETS] AS A
		  INNER JOIN
		  (
			  SELECT	B.COMPKEY, C.DISTRICT_ID
			  FROM	[HANSEN8].[ASSETMANAGEMENT_SEWER].[COMPSMN] AS B
					  INNER JOIN
					  DISTRICTS AS C
					  ON	B.DISTRICT = C.district_id
		  ) AS D
		  ON	A.COMPKEY = D.COMPKEY
  WHERE A.asset_set_id = @asset_set_id

  EXEC SP_STATUS_MESSAGE 'Updating ASSETS (structural_grade)'
		
  UPDATE [dbo].[ASSETS]
  SET structural_grade = B.grade_h5
  FROM [dbo].[ASSETS] A INNER JOIN REHAB10FTSEGS B ON (A.COMPKEY = B.compkey)
  WHERE A.asset_set_id = @asset_set_id AND B.asset_set_id = @asset_set_id

  EXEC SP_STATUS_MESSAGE 'End SP_ExposeData'

END
