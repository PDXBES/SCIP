CREATE PROCEDURE [dbo].[SP_FILL_ASSETS_UPDATE]
	@ImportCOMPKEY int 
AS
BEGIN
  SET NOCOUNT ON
  EXEC SP_STATUS_MESSAGE 'Begin SP_FILL_ASSETS_UPDATE'

  TRUNCATE TABLE [dbo].[ASSETS_UPDATE]

  INSERT INTO ASSETS_UPDATE ([COMPKEY],
	[length_ft],
	[diamWidth_inches],
	[height_inches],
	[basin_id],
	[district_id],
	[unit_type],
	[last_inspection_date],
	[last_root_management_date],
	[last_cleaning_date],
	[structural_grade],
	[asset_set_id])
  SELECT [COMPKEY],
	[length_ft],
	[diamWidth_inches],
	[height_inches],
	[basin_id],
	[district_id],
	[unit_type],
	[last_inspection_date],
	[last_root_management_date],
	[last_cleaning_date],
	[structural_grade],
	[asset_set_id]
    FROM  [dbo].[ASSETS]
    WHERE [dbo].ASSETS.COMPKEY = @ImportCOMPKEY

    EXEC SP_STATUS_MESSAGE 'End SP_FILL_ASSETS_UPDATE'
END