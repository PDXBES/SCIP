CREATE VIEW [dbo].[VW_CONTROLLING_DRIVERS]
	AS
  SELECT A.*
  FROM VW_ALL_DRIVERS A INNER JOIN VW_MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE B ON (A.compkey = B.compkey AND A.activity_type = B.activity_type AND A.frequency_years = B.min_frequency_years AND A.[driver_rank] = B.[min_rank])

