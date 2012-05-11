CREATE VIEW [dbo].[VW_LAST_ACTIVITY_DATES]
	AS 
  SELECT 
   compkey
  ,CASE WHEN (A.last_inspection_date IS NULL) THEN GETDATE() ELSE A.last_inspection_date END AS last_inspection_date
  ,CASE WHEN (A.last_root_management_date IS NULL) THEN GETDATE() ELSE A.last_root_management_date END AS last_root_management_date
  ,CASE WHEN (A.last_cleaning_date IS NULL) THEN GETDATE() ELSE A.last_cleaning_date END AS last_cleaning_date
FROM ASSETS A