CREATE VIEW [dbo].[VW_NEXT_ACTIVITY_FISCAL_YEAR_BY_COMPKEY]
	AS
  SELECT 
       [compkey]
      ,[1] as inspection_fiscal_year
      ,[2] as root_fiscal_year
      ,[3] as cleaning_fiscal_year
  FROM 
    (SELECT compkey, activity_type_id, fiscal_year FROM ACTIVITIES_FOR_PROCESSING) PS
    PIVOT (MIN(fiscal_year) for activity_type_id in ([1],[2],[3])) PVT