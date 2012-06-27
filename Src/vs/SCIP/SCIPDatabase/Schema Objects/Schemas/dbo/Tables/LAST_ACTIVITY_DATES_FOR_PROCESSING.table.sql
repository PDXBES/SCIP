CREATE TABLE [dbo].[LAST_ACTIVITY_DATES_FOR_PROCESSING]
(
	 COMPKEY                   INT NOT NULL PRIMARY KEY
  ,last_inspection_date      DATETIME
  ,last_root_management_date DATETIME
  ,last_cleaning_date        DATETIME
)
