CREATE VIEW [dbo].[VW_NEXT_ACTIVITY_HANSEN_ACTIVITY_CODE_BY_COMPKEY]
	AS
  SELECT 
       [compkey]
      ,[1] as inspection_activity
      ,[2] as root_activity
      ,[3] as cleaning_activity
  FROM 
    (SELECT compkey, activity_type_id, hansen_activity_code FROM VW_ALL_ACTIVITIES) PS
    PIVOT (MIN(hansen_activity_code) for activity_type_id in ([1],[2],[3])) PVT