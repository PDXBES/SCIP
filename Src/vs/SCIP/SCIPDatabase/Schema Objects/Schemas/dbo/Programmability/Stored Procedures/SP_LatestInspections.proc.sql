-- =============================================
-- Author:		Issac Gardner
-- Create date: 4/9/2012
-- Description:	Barebones 
-- =============================================
CREATE PROCEDURE [dbo].[SP_LatestInspections]
AS
BEGIN

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

IF OBJECT_ID(N'[AllInspections]', N'U') IS NOT NULL
	DROP TABLE AllInspections

CREATE TABLE AllInspections
	(
		COMPKEY		int,			INSPKEY		int,		OBRATING		float,		
		[FROM]		float,			[TO]		float,	
		STARTDTTM	datetime,		COMPDTTM	datetime,	INSTDATE	datetime,
		SEVDESC nvarchar(300),		INSPNDX nvarchar(10),	INDEXVAL	float,
		OWN			varchar(4),		UNITTYPE	varchar(6),	SERVSTAT	varchar(4)
	)
			
-----------------------------------------------------------------------
--Fill LatestInspections with all of the valid 
--sanitary inspections
INSERT	INTO  AllInspections 
SELECT	C2.COMPKEY AS COMPKEY,
		C2.INSPKEY AS INSPKEY, 
		OBRATING AS OBRATING, 
		C3.DISTFROM AS [FROM], 
		C3.DISTTO	AS [TO], 
		STARTDTTM,		COMPDTTM,		INSTDATE,	
		C5.SEVDESC,		C6.INSPNDX,		INDEXVAL,	
		OWN,			UnitType,		ServStat
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

IF OBJECT_ID(N'[LatestInspections]', N'U') IS NOT NULL
	DROP TABLE LatestInspections
	
CREATE TABLE LatestInspections
	(
		COMPKEY		int,			LastInspected DateTime
	)

INSERT	INTO  LatestInspections 
SELECT     COMPKEY, MAX(STARTDTTM) AS LastInspected
FROM         dbo.AllInspections AS AllInspections_1
GROUP BY COMPKEY

END
