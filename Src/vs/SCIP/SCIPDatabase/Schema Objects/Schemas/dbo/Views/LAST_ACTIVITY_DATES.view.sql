CREATE VIEW [dbo].[LAST_ACTIVITY_DATES]
AS
  SELECT
    A.COMPKEY, 
    A.asset_set_id, 
    CASE WHEN (A.last_inspection_date IS NULL) 
      THEN [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), - B.inspection_frequency_years) 
      ELSE CASE WHEN (A.last_inspection_date < [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), - B.inspection_frequency_years)) 
        THEN [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), - B.inspection_frequency_years) 
        ELSE A.last_inspection_date 
        END 
      END AS last_inspection_date,
    CASE WHEN (A.last_root_management_date IS NULL) 
      THEN [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), - B.root_frequency_years) 
      ELSE CASE WHEN (A.last_root_management_date < [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), - B.root_frequency_years)) 
        THEN [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), - B.root_frequency_years) 
        ELSE A.last_root_management_date 
        END 
      END AS last_root_management_date, 
    CASE WHEN (A.last_cleaning_date IS NULL) 
      THEN [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), - B.cleaning_frequency_years) 
      ELSE CASE WHEN (A.last_cleaning_date < [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), - B.cleaning_frequency_years)) 
        THEN [dbo].[FN_DATE_ADD_FRACTIONAL_YEARS](GETDATE(), - B.cleaning_frequency_years) 
        ELSE A.last_cleaning_date 
        END 
      END AS last_cleaning_date
  FROM dbo.CONTROLLING_DRIVER_FREQUENCIES AS B INNER JOIN
    dbo.ALTERNATIVES AS C ON B.alternative_id = C.alternative_id INNER JOIN
    dbo.ASSETS AS A ON B.compkey = A.COMPKEY AND A.asset_set_id = C.asset_set_id