-- =============================================
-- Author:		<Issac Gardner>
-- Create date: <11/27/2013>
-- Description:	<Initializes Variables for SCIP Processing>
-- =============================================
CREATE PROCEDURE dbo.SP_INIT_VARIABLES 

AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;

  DECLARE @statusMessage VARCHAR(200)
  SET @statusMessage = 'Begin SP_INIT_VARIABLES'
  EXEC SP_STATUS_MESSAGE @statusMessage

  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;
  
  DELETE FROM dbo.VARIABLES

  --------------------------------
  --For the column ROOTPROB in the table COPSEWERMAIN
  DECLARE @ROOTPROB_N char --No Treatment- see notes
  DECLARE @ROOTPROB_H char --High priority
  DECLARE @ROOTPROB_L char --Low priority
  DECLARE @ROOTPROB_R char --Possible Roots(not verified)
  DECLARE @ROOTPROB_M char --Medium priority
  DECLARE @ROOTPROB_V char --Very low priority

  -------------------------
  --OBKEY values for [HANSEN83].[ASSETMANAGEMENT_SEWER].[SMNSERVINSPTYPEOB]
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
  INSERT INTO VARIABLES (VariableName, VariableString) VALUES ('ROOTPROB_N', 'N')
  SET @ROOTPROB_H = 'H'
  INSERT INTO VARIABLES (VariableName, VariableString) VALUES ('ROOTPROB_H', 'H')
  SET @ROOTPROB_L = 'L'
  INSERT INTO VARIABLES (VariableName, VariableString) VALUES ('ROOTPROB_L', 'L')
  SET @ROOTPROB_R = 'R'
  INSERT INTO VARIABLES (VariableName, VariableString) VALUES ('ROOTPROB_R', 'R')
  SET @ROOTPROB_M = 'M'
  INSERT INTO VARIABLES (VariableName, VariableString) VALUES ('ROOTPROB_M', 'M')
  SET @ROOTPROB_V = 'V'
  INSERT INTO VARIABLES (VariableName, VariableString) VALUES ('ROOTPROB_V', 'V')
  ------------------------
  

  SET @OBKEY_BP = 1000
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('OBKEY_BP', 1000)
  SET @OBKEY_CR = 1003
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('OBKEY_CR', 1003)
  SET @OBKEY_DB = 1004
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('OBKEY_DB', 1004)
  SET @OBKEY_DS = 1005
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('OBKEY_DS', 1005)
  SET @OBKEY_GR = 1007
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('OBKEY_GR', 1007)
  SET @OBKEY_II = 1008
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('OBKEY_II', 1008)
  SET @OBKEY_IN = 1009
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('OBKEY_IN', 1009)
  SET @OBKEY_OB = 1013
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('OBKEY_OB', 1013)
  SET @OBKEY_RT = 1015
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('OBKEY_RT', 1015)
  ------------------------

  --INDEXKEY values for [HANSEN83].[ASSETMANAGEMENT].[ASSETINSPINDEX]
  SET @INDEXKEY_GreaseCount = 1000
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('INDEXKEY_GreaseCount', 1000)
  SET @INDEXKEY_GreateRating = 1001
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('INDEXKEY_GreateRating', 1001)
  SET @INDEXKEY_GreaseScore = 1002
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('INDEXKEY_GreaseScore', 1002)
  SET @INDEXKEY_RootCount = 1004
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('INDEXKEY_RootCount', 1004)
  SET @INDEXKEY_RootRating = 1005
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('INDEXKEY_RootRating', 1005)
  SET @INDEXKEY_RootScore = 1006
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('INDEXKEY_RootScore', 1006)
  SET @INDEXKEY_StructuralCountStorm = 1007
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('INDEXKEY_StructuralCountStorm', 1007)
  SET @INDEXKEY_StructuralRatingStorm = 1008
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('INDEXKEY_StructuralRatingStorm', 1008)
  SET @INDEXKEY_StructuralScoreStorm = 1009
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('INDEXKEY_StructuralScoreStorm', 1009)
  SET @INDEXKEY_StructuralAverageEachStorm = 1010
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('INDEXKEY_StructuralAverageEachStorm', 1010)
  SET @INDEXKEY_StructuralAverageFootStorm = 1011
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('INDEXKEY_StructuralAverageFootStorm', 1011)
  SET @INDEXKEY_StructuralCountSanitary = 1014
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('INDEXKEY_StructuralCountSanitary', 1014)
  SET @INDEXKEY_StructuralRatingSanitary = 1015
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('INDEXKEY_StructuralRatingSanitary', 1015)
  SET @INDEXKEY_StructuralScoreSanitary = 1016
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('INDEXKEY_StructuralScoreSanitary', 1016)
  SET @INDEXKEY_StructuralAverageEachSanitary = 1017
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('INDEXKEY_StructuralAverageEachSanitary', 1017)
  SET @INDEXKEY_StructuralAverageFootSanitary = 1018
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('INDEXKEY_StructuralAverageFootSanitary', 1018)

  --These codes need a reference table
  SET @ACTKEY_RTCHEM = 1057
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('ACTKEY_RTCHEM', 1057)
  SET @ACTKEY_SEWCLN = 1061
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('ACTKEY_SEWCLN', 1061)
  SET @ACTKEY_SPCLN  = 1064
  INSERT INTO VARIABLES (VariableName, VariableValue) VALUES ('ACTKEY_SPCLN', 1064)
END