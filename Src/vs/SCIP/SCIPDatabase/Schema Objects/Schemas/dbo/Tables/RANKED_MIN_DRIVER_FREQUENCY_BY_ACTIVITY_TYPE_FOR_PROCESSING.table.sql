CREATE TABLE [dbo].[RANKED_MIN_DRIVER_FREQUENCY_BY_ACTIVITY_TYPE_FOR_PROCESSING]
(
   compkey             INT
  ,activity_type       VARCHAR(20)
  ,min_frequency_years DECIMAL(5,2)
  ,min_driver_rank     INT
)
