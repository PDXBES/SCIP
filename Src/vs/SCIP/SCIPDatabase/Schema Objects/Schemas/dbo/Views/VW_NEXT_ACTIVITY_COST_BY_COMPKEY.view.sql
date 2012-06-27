CREATE VIEW [dbo].[VW_NEXT_ACTIVITY_COST_BY_COMPKEY]
	AS
  SELECT 
       [compkey]
      ,[1] as inspection_cost
      ,[2] as root_cost
      ,[3] as cleaning_cost
  FROM 
    (SELECT compkey, activity_type_id, cost FROM ACTIVITIES_FOR_PROCESSING) PS
    PIVOT (SUM(cost) for activity_type_id in ([1],[2],[3])) PVT