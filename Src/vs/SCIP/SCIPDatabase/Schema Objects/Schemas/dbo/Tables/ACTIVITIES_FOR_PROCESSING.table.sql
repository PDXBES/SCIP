CREATE TABLE [dbo].[ACTIVITIES_FOR_PROCESSING]
(
   [activity_id]             INT
  ,[compkey]                 INT
  ,[driver_id]               INT
  ,length_ft                 DECIMAL(10,2)
  ,diamwidth_inches          DECIMAL(5,2)
  ,height_inches             DECIMAL(5,2)
  ,basin                     VARCHAR(50)
  ,DISTRICT                  VARCHAR(50)
  ,[activity_date]           DATETIME
  ,[cost]                    MONEY
  ,[activity_type_id]        INT
  ,[alternative_id]          INT
  ,fiscal_year               INT
  ,driver_type               VARCHAR(50)
  ,reporting_category        VARCHAR(100)
  ,activity_type             VARCHAR(20)
  ,hansen_activity_code      VARCHAR(10)
  ,frequency_years           DECIMAL(5,2)
  ,last_inspection_date      DATETIME
  ,last_root_management_date DATETIME
  ,last_cleaning_date        DATETIME
)
