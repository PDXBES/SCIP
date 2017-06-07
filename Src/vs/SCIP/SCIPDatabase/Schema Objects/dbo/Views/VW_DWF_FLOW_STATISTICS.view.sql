CREATE VIEW [dbo].[VW_DWF_FLOW_STATISTICS] AS
  SELECT TOP (100) PERCENT mlinkid, simlinkid, ROUND(AVG(flow_value_cfs), 4) AS qavg, MAX(flow_value_cfs) AS qmin
  FROM  dbo.DWF_FLOW_DATA
  WHERE (mlinkid <> - 1)
  GROUP BY mlinkid, simlinkid
  ORDER BY mlinkid
