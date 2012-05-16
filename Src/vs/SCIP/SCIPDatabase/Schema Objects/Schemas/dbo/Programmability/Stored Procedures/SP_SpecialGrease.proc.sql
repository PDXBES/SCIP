-- =============================================
-- Author:		Issac Gardner
-- Create date: 4/9/2012
-- Description:	Barebones 
-- =============================================
CREATE PROCEDURE [dbo].[SP_SpecialGrease]
AS
BEGIN

-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

IF OBJECT_ID(N'[SpecialGrease]', N'U') IS NOT NULL
	DROP TABLE SpecialGrease

CREATE TABLE SpecialGrease
	(
		ADDBY nvarchar(30),
		ADDDTTM datetime,
		COMPKEY int,
		DISTFROMFT float,
		DISTFROMM float,
		DISTTOFT float,
		DISTTOM float,
		GROUPITEMKEY int,
		INDEXNO int,
		MODBY nvarchar(30),
		MODDTTM datetime,
		RWFEATUREKEY int,
		RWFEATURETYPE int,
		RWROMP nvarchar(10),
		GROUPID nvarchar(16)
	)
	
INSERT INTO SpecialGrease
  SELECT A.[ADDBY]
      ,A.[ADDDTTM]
      ,A.[COMPKEY]
      ,A.[DISTFROMFT]
      ,A.[DISTFROMM]
      ,A.[DISTTOFT]
      ,A.[DISTTOM]
      ,A.[GROUPITEMKEY]
      ,A.[INDEXNO]
      ,A.[MODBY]
      ,A.[MODDTTM]
      ,A.[RWFEATUREKEY]
      ,A.[RWFEATURETYPE]
      ,A.[RWROWP], B.GROUPID
  FROM	[HANSEN8].[ASSETMANAGEMENT].[GRPCOMP] AS A
		INNER JOIN
		[HANSEN8].[ASSETMANAGEMENT].[ASSETGRP] AS B
		ON	A.GROUPKEY = B.GROUPKEY
			AND
			B.GROUPID like 'SP_GREASE%'
END