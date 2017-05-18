CREATE PROCEDURE [dbo].[SP_ALPHA_TABLE_A]
	@asset_set_ID INT = 1
AS
BEGIN

DECLARE @AverageMAUAge INT
DECLARE @MaxMAUAge INT

SELECT 
  @AverageMAUAge = [AverageAgeSum]/[MAUNumPipes] ,
  @MaxMAUAge = Intermed_MAU_AveragePipeAge.MaxAge 
FROM 
  (
  SELECT 
  Sum([AvgOfPIPE_AGE_YEARS]*[CountOfCompkey]) AS AverageAgeSum, 
  Max(AveragePipeAge.AvgOfPIPE_AGE_YEARS) AS MaxAge,
  Sum(AveragePipeAge.CountOfCompkey) AS MAUNumPipes
FROM 
  (
  SELECT 
  [Assets-MAU].MAU, 
  Avg([Assets-LastInspectionDate].PIPE_AGE_YEARS) AS AvgOfPIPE_AGE_YEARS, 
  Count([Assets-MAU].Compkey) AS CountOfCompkey
FROM 
  dbo.ASSETS AS [Assets-LastInspectionDate] INNER JOIN dbo.[DmeProjLinks] AS [Assets-MAU] 
    ON [Assets-LastInspectionDate].COMPKEY = [Assets-MAU].Compkey
GROUP BY 
  [Assets-MAU].MAU
HAVING 
  ((([Assets-MAU].MAU)>0) AND ((Avg([Assets-LastInspectionDate].PIPE_AGE_YEARS))>-1))
  ) AS AveragePipeAge) AS Intermed_MAU_AveragePipeAge;
  
  
SELECT  XXX.MAU ,
        [0-3] ,
        [4-6] ,
        [7-9] ,
        [>9] ,
        NoTV ,
        AGG*([AvgOfPIPE_AGE_YEARS]*1.0/@MaxMAUAge) AS AggScore,
        ([AvgOfPIPE_AGE_YEARS]*1.0/@MaxMAUAge) AS AgeFactor,
        RANK() OVER (ORDER BY AGG*([AvgOfPIPE_AGE_YEARS]*1.0/@MaxMAUAge) DESC) AS [RANK]
FROM    (  
          SELECT  MAU,
                  SUM([0-3])  AS [0-3],
                  SUM([4-6]) AS [4-6],
                  SUM([7-9]) AS [7-9],
                  SUM([>9]) AS [>9],
                  SUM([NoTV]) AS [NoTV],
                  SUM([0-3]+2*[4-6]+3*[7-9]+4*[>9]+5*[NoTV]) AS AGG
          FROM    (  
                    SELECT  MAU, 
                            CASE WHEN INSPECTION_AGE BETWEEN 0 AND 3 THEN length_ft*1.00 ELSE 0 END AS [0-3],
                            CASE WHEN INSPECTION_AGE BETWEEN 4 AND 6 THEN length_ft*1.00 ELSE 0 END AS [4-6],
                            CASE WHEN INSPECTION_AGE BETWEEN 7 AND 9 THEN length_ft*1.00 ELSE 0 END AS [7-9],
                            CASE WHEN INSPECTION_AGE > 9 THEN length_ft*1.00 ELSE 0 END AS [>9],
                            CASE WHEN INSPECTION_AGE = -1 THEN length_ft*1.00 ELSE 0 END AS [NoTV],
                            length_ft*1.00 AS length_ft
                    FROM    (
                              SELECT  LID.COMPKEY,
                                      LID.LENGTH_FT,
                                      LID.LAST_INSPECTION_DATE,
                                      MAU.MAU,
                                      DATEDIFF(YEAR,ISNULL(LID.[LAST_INSPECTION_DATE], DATEADD(YEAR,1,GETDATE())),GETDATE()) AS INSPECTION_AGE
                              FROM    dbo.ASSETS AS LID
                                      INNER JOIN 
                                      dbo.[DmeProjLinks] AS MAU
                                      ON  LID.COMPKEY = MAU.Compkey
                                          AND
                                          LID.asset_set_ID = @asset_set_ID
                                          AND
                                          MAU.MAU <> 0
                            ) AS X
                  ) AS XX
                  GROUP BY MAU
        ) AS XXX
        INNER JOIN 
        ( 
          SELECT  [DmeProjLinks].MAU, 
                  AVG([Assets].PIPE_AGE_YEARS) AS AvgOfPIPE_AGE_YEARS, 
                  COUNT([DmeProjLinks].Compkey) AS CountOfCompkey
          FROM    [Assets] 
                  INNER JOIN 
                  [DmeProjLinks] 
                  ON  [Assets].COMPKEY = [DmeProjLinks].Compkey
          GROUP BY  [DmeProjLinks].MAU
          HAVING  [DmeProjLinks].MAU>0
                  AND 
                  AVG([Assets].PIPE_AGE_YEARS)>-1
        ) AS AveragePipeAge 
    ON XXX.MAU = AveragePipeAge.MAU
    
END