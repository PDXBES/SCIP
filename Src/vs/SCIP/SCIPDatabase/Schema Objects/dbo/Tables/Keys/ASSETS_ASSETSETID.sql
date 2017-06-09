CREATE INDEX [ASSETS_ASSETSETID]
  ON [dbo].[ASSETS] ([asset_set_id])
  INCLUDE ([COMPKEY],[length_ft],[diamWidth_inches],[height_inches],[basin_id],[district_id])
