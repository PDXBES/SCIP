CREATE PROCEDURE [dbo].[SP_ALPHA_TABLE_B]
	@asset_set_ID INT = 1
AS
BEGIN

DECLARE @Assets_MAU_InspDate TABLE
(
  COMPKEY int,
  LENGTH_FT int,
  LAST_INSPECTION_DATE datetime,
  MAU int,
  INSPECTION_AGE int
)
INSERT INTO @Assets_MAU_InspDate
(
  COMPKEY,
  LENGTH_FT,
  LAST_INSPECTION_DATE,
  MAU,
  INSPECTION_AGE
)
SELECT  LID.COMPKEY,
            LID.LENGTH_FT,
            LID.LAST_INSPECTION_DATE,
            MAU.MAU,
            --IIf(IsNull(LID.[LAST_INSPECTION_DATE]),-1,DateDiff("yyyy",LID.[LAST_INSPECTION_DATE],Now())) AS INSPECTION_AGE,
            DATEDIFF(YEAR,ISNULL(LID.[LAST_INSPECTION_DATE], DATEADD(YEAR,1,GETDATE())),GETDATE()) AS INSPECTION_AGE
    FROM    dbo.ASSETS AS LID
            INNER JOIN 
            dbo.[DmeProjLinks] AS MAU
            ON  LID.COMPKEY = MAU.Compkey
                AND
                LID.asset_set_ID = @asset_set_ID
                AND
                MAU.MAU <> 0

SELECT  MAU,
        TotalFt,
        [>=0],
        [>3],
        [>6],
        [>9],
        [NoTV],
        [Pct >=0], 
        [Pct >3], 
        [Pct >6], 
        [Pct >9], 
        [Pct NoTV],
        Threshold33,
        Threshold50,
        Threshold67,
        CASE WHEN Threshold50 <> Threshold33 THEN -1 ELSE 0 END AS Changed33to50, 
        CASE WHEN Threshold67 <> Threshold50 THEN -1 ELSE 0 END AS Changed50to67
FROM    (
          SELECT  MAU,
                  TotalFt,
                  [>=0],
                  [>3],
                  [>6],
                  [>9],
                  [NoTV],
                  [>=0]/[TotalFt]*100 AS [Pct >=0], 
                  [>3]/[TotalFt]*100 AS [Pct >3], 
                  [>6]/[TotalFt]*100 AS [Pct >6], 
                  [>9]/[TotalFt]*100 AS [Pct >9], 
                  [NoTV]/[TotalFt]*100 AS [Pct NoTV],
                  CASE WHEN [NoTV]/[TotalFt] >= .33 THEN 'NoTV' ELSE CASE WHEN [>9]/[TotalFt] >= .33 THEN '>9' ELSE CASE WHEN [>6]/[TotalFt] >= .33 THEN '>6' ELSE CASE WHEN [>3]/[TotalFt] >= .33 THEN '>3' ELSE '>=0' END END END END AS Threshold33,
                  CASE WHEN [NoTV]/[TotalFt] >= .50 THEN 'NoTV' ELSE CASE WHEN [>9]/[TotalFt] >= .50 THEN '>9' ELSE CASE WHEN [>6]/[TotalFt] >= .50 THEN '>6' ELSE CASE WHEN [>3]/[TotalFt] >= .50 THEN '>3' ELSE '>=0' END END END END AS Threshold50,
                  CASE WHEN [NoTV]/[TotalFt] >= .67 THEN 'NoTV' ELSE CASE WHEN [>9]/[TotalFt] >= .67 THEN '>9' ELSE CASE WHEN [>6]/[TotalFt] >= .67 THEN '>6' ELSE CASE WHEN [>3]/[TotalFt] >= .67 THEN '>3' ELSE '>=0' END END END END AS Threshold67
          FROM    (  
                    SELECT  A.MAU, 
                            SUM(A.LENGTH_FT) AS TotalFt, 
                            SUM(CASE WHEN INSPECTION_AGE = -1 OR INSPECTION_AGE >=0 THEN length_ft*1.00 ELSE 0 END) AS [>=0],
                            SUM(CASE WHEN INSPECTION_AGE = -1 OR INSPECTION_AGE >3 THEN length_ft*1.00 ELSE 0 END) AS [>3],
                            SUM(CASE WHEN INSPECTION_AGE = -1 OR INSPECTION_AGE >6 THEN length_ft*1.00 ELSE 0 END) AS [>6],
                            SUM(CASE WHEN INSPECTION_AGE = -1 OR INSPECTION_AGE >9 THEN length_ft*1.00 ELSE 0 END) AS [>9],
                            SUM(CASE WHEN INSPECTION_AGE = -1 THEN length_ft*1.00 ELSE 0 END) AS [NoTV]
                    FROM    @Assets_MAU_InspDate AS A
                    GROUP BY A.MAU
                    HAVING A.MAU>0
                  ) AS A
        ) AS X
END