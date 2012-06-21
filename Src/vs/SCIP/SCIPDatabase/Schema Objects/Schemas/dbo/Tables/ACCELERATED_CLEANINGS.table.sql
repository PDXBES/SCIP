CREATE TABLE [dbo].[ACCELERATED_CLEANINGS]
(
  [accelerated_cleaning_id] int IDENTITY(1,1) NOT NULL,
  [compkey]                 int NOT NULL,
  [last_cleaning_date]      datetime NULL,
  [last_inspection_date]    datetime NULL,
  [frequency_years]         decimal(5,2) NOT NULL,
  [cleaning_group]          varchar(50) NULL
)
