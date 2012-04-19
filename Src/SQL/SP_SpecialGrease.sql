USE [SCIP]
GO

/****** Object:  StoredProcedure [dbo].[SP_SpecialGrease]    Script Date: 04/19/2012 10:35:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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

IF OBJECT_ID(N'[TBL_SpecialGrease]', N'U') IS NOT NULL
	DROP TABLE RootInspections

CREATE TABLE TBL_SpecialGrease
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
	
INSERT INTO TBL_SpecialGrease
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

GO

