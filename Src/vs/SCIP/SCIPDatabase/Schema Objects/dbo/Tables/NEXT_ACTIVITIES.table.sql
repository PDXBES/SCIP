CREATE TABLE [dbo].[NEXT_ACTIVITIES]
(
	 compkey INT NOT NULL
  ,length_ft INT NOT NULL
  ,diamwidth_inches DECIMAL(5,2) NOT NULL
  ,height_inches DECIMAL(5,2) NOT NULL
  ,basin VARCHAR(50) NULL
  ,district VARCHAR(50) NULL
  ,inspection_activity VARCHAR(10) NULL
  ,inspection_fiscal_year INT
  ,inspection_cost MONEY
  ,cleaning_activity VARCHAR(10) NULL
  ,cleaning_fiscal_year INT
  ,cleaning_cost MONEY
  ,root_activity VARCHAR(10) NULL
  ,root_fiscal_year INT
  ,root_cost MONEY
  ,alternative_id INT
)
