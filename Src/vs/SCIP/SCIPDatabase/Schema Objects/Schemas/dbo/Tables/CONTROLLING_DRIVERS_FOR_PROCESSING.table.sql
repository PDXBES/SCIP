CREATE TABLE [dbo].[CONTROLLING_DRIVERS_FOR_PROCESSING]
(
	 driver_id          INT
  ,compkey            INT
  ,length_ft          INT
  ,diamwidth_inches   DECIMAL(5,2)
  ,height_inches      DECIMAL(5,2)
  ,basin              VARCHAR(50)
  ,district           VARCHAR(50)
  ,driver_type        VARCHAR(50)
  ,reporting_category VARCHAR(100)
  ,driver_type_id     INT
  ,driver_rank        INT
  ,activity_type      VARCHAR(20)
  ,activity_type_id   INT
  ,cost_per_ft        MONEY
  ,frequency_years    DECIMAL(5,2)
  ,updated_by         VARCHAR(20)
  ,update_date        DATETIME
  ,driver_cost        MONEY
)
