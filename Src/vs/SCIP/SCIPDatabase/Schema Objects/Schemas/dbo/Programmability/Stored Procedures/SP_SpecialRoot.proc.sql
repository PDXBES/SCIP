-- =============================================
-- Author:		Issac Gardner
-- Create date: 4/9/2012
-- Description:	Barebones 
-- =============================================
CREATE PROCEDURE [dbo].[SP_SpecialRoot]
  @asset_set_id INT = 1
AS
BEGIN

  DECLARE @statusMessage VARCHAR(200)
  SET @statusMessage = 'Begin SP_SpecialRoot, asset_set_id = ' + CONVERT(VARCHAR(10), @asset_set_id)
  EXEC SP_STATUS_MESSAGE @statusMessage

  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;

  --For the column ROOTPROB in the table COPSEWERMAIN
  DECLARE @ROOTPROB_N char --No Treatment- see notes
  DECLARE @ROOTPROB_H char --High priority
  DECLARE @ROOTPROB_L char --Low priority
  DECLARE @ROOTPROB_R char --Possible Roots(not verified)
  DECLARE @ROOTPROB_M char --Medium priority
  DECLARE @ROOTPROB_V char --Very low priority

  SET @ROOTPROB_N = 'N'
  SET @ROOTPROB_H = 'H'
  SET @ROOTPROB_L = 'L'
  SET @ROOTPROB_R = 'R'
  SET @ROOTPROB_M = 'M'
  SET @ROOTPROB_V = 'V'
	
  INSERT INTO SpecialRoot
  SELECT	B.*, @asset_set_id
  FROM	[HANSEN8].[ASSETMANAGEMENT_SEWER].[COMPSMN] AS A
		  INNER JOIN
		  [HANSEN8].[COPASSETMANAGEMENTSEWER].[COPSEWERMAIN] AS B
		  ON A.COMPKEY = B.COMPKEY
		  AND 
		  (	
			  ROOTPROB = @ROOTPROB_N
			  OR 
			  ROOTPROB = @ROOTPROB_H
			  OR
			  ROOTPROB = @ROOTPROB_L
			  OR
			  ROOTPROB = @ROOTPROB_R
			  OR
			  ROOTPROB = @ROOTPROB_M
			  OR
			  ROOTPROB = @ROOTPROB_V
		  )
  ORDER BY COMPKEY

  EXEC SP_STATUS_MESSAGE 'End SP_SpecialRoot'
END
