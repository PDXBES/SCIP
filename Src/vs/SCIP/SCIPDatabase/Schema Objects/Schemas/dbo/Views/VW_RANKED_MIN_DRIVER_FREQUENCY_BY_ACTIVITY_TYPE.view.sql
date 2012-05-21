CREATE VIEW [dbo].[VW_RANKED_MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE]
	AS
  SELECT A.[compkey]
      ,A.[activity_type]
      ,A.[min_frequency_years]
      ,MIN(B.[driver_rank]) AS min_driver_rank
  FROM [VW_MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE] A INNER JOIN [VW_ALL_DRIVERS] B ON (A.compkey = B.compkey AND A.activity_type = B.activity_type AND A.min_frequency_years = B.frequency_years)
  GROUP BY A.activity_type, A.compkey, A.min_frequency_years
