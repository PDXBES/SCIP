CREATE PROCEDURE [dbo].[SP_FILL_DRIVERS_UPDATE]
	@ImportCOMPKEY int
AS
BEGIN
  SET NOCOUNT ON
  EXEC SP_STATUS_MESSAGE 'Begin SP_FILL_DRIVERS_UPDATE'

  TRUNCATE TABLE [dbo].[DRIVERS_UPDATE]

  INSERT INTO DRIVERS_UPDATE ([driver_id],
    [driver_type_id],
    [compkey],
    [override_cost_per_ft],
    [override_frequency_years],
    [alternative_id],
    [updated_by],
    [update_date])
  SELECT [driver_id],
    [driver_type_id],
    [compkey],
    [override_cost_per_ft],
    [override_frequency_years],
    [alternative_id],
    [updated_by],
    [update_date]
    FROM  [dbo].[DRIVERS]
    WHERE [dbo].DRIVERS.COMPKEY = @ImportCOMPKEY

    EXEC SP_STATUS_MESSAGE 'End SP_FILL_DRIVERS_UPDATE'
END