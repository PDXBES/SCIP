CREATE VIEW [dbo].[VW_NEXT_ACTIVITY_COST_BY_COMPKEY]
	AS
  SELECT 
       [compkey]
      ,[1] as inspection_cost
      ,[2] as cleaning_cost
      ,[3] as root_cost
  FROM 
    (SELECT compkey, activity_type_id, cost FROM VW_ALL_ACTIVITIES) PS
    PIVOT (SUM(cost) for activity_type_id in ([1],[2],[3])) PVT