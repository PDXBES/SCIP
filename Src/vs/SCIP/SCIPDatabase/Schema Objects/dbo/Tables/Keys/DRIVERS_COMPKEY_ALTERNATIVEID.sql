CREATE INDEX [DRIVERS_COMPKEY_ALTERNATIVEID]
  ON [dbo].[DRIVERS] ([compkey],[alternative_id])
  INCLUDE ([driver_id],[driver_type_id],[override_cost_per_ft],[override_frequency_years],[updated_by],[update_date])

