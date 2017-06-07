CREATE TABLE [dbo].[ASSET_SETS]
(
	 asset_set_id  int IDENTITY(1,1) NOT NULL
  ,name          varchar(50) NOT NULL
  ,import_date   datetime NOT NULL
  ,description   varchar(250) NULL
)
