
CREATE PROCEDURE SP_DATA_READOUT @asset_set_ID INT = 1
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT  A.COMPKEY,
            A.length_ft,
            CONVERT(NVARCHAR(30), A.last_inspection_date, 101) AS LAST_INSPECTION_DATE,
            A.pipe_age_years AS PIPE_AGE_YEARS
    FROM    dbo.ASSETS A
    WHERE   A.asset_set_id = @asset_set_ID

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
               
 
 /*             
    SELECT  [Assets-MAU-InspDate].[MAU],
            SUM([Assets-MAU-InspDate].[LENGTH_FT]) AS [Total Of LENGTH_FT]
    FROM    [Assets-MAU-InspDate]
    GROUP BY [Assets-MAU-InspDate].[MAU]
     
            TRANSFORM
  Nz(Sum([Assets-MAU-InspDate].[LENGTH_FT]))+0 AS SumOfLENGTH_FT
SELECT
  [Assets-MAU-InspDate].[MAU],
  Sum([Assets-MAU-InspDate].[LENGTH_FT]) AS [Total Of LENGTH_FT]
FROM
  [Assets-MAU-InspDate]
GROUP BY
  [Assets-MAU-InspDate].[MAU]
PIVOT
  [Assets-MAU-InspDate].[INSPECTION_AGE];    
  */
  
END