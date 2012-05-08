-- =============================================
-- Author:		Issac Gardner
-- Create date: 4/9/2012
-- Description:	Barebones 
-- =============================================
CREATE PROCEDURE [dbo].[SP_SpecialRoot]
AS
BEGIN

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




IF OBJECT_ID(N'[SpecialRoot]', N'U') IS NOT NULL
	DROP TABLE SpecialRoot

CREATE TABLE SpecialRoot
	(
		[ABANBY] [nvarchar](10) NULL,
	[ABANDTTM] [datetime] NULL,
	[ADDBY] [nvarchar](30) NULL,
	[ADDDTTM] [datetime] NULL,
	[COMMENTS] [nvarchar](254) NULL,
	[COMPKEY] [int] NOT NULL,
	[COPSEWERMAINKEY] [int] NOT NULL,
	[DSOURCE] [nvarchar](8) NULL,
	[GRID1] [nvarchar](3) NULL,
	[GRID2] [nvarchar](3) NULL,
	[MAPPAGE] [int] NULL,
	[MARKBALL] [nvarchar](1) NULL,
	[MHTYPE] [nvarchar](10) NULL,
	[MODBY] [nvarchar](30) NULL,
	[MODDTTM] [datetime] NULL,
	[ROOTPROB] [nvarchar](10) NULL,
	[SHEETNO] [nvarchar](10) NULL
	)
	
INSERT INTO SpecialRoot
SELECT	B.*
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


END
