CREATE PROCEDURE [dbo].[SP_FILL_DRIVERS]
AS
BEGIN
  TRUNCATE TABLE [dbo].[DRIVERS]

  DECLARE @AllCompKeys TABLE (compkey int)
  DECLARE @LargeCompKeys TABLE (compkey int)
  DECLARE @SmallCompKeys TABLE (compkey int)
  DECLARE @LargeRootCompKeys TABLE (compkey int)
  DECLARE @SmallRootCompKeys TABLE (compkey int)
  DECLARE @LargeDiameterIn int
  SET @LargeDiameterIn = 36
  DECLARE @LargeRootDiameterIn int
  SET @LargeRootDiameterIn = 16

  INSERT INTO @AllCompKeys
    SELECT compkey
    FROM [dbo].[ASSETS]

  INSERT INTO @LargeCompKeys
    SELECT compkey
    FROM [dbo].[ASSETS]
    WHERE ([ASSETS].diamWidth_inches > @LargeDiameterIn) OR ([ASSETS].height_inches > @LargeDiameterIn)

  INSERT INTO @SmallCompKeys
    SELECT compkey
    FROM @AllCompKeys
    EXCEPT
    SELECT compkey
    FROM @LargeCompKeys

  INSERT INTO @LargeRootCompKeys
    SELECT compkey
    FROM [dbo].[ASSETS]
    WHERE ([ASSETS].diamWidth_inches >= @LargeRootDiameterIn) OR ([ASSETS].height_inches >= @LargeRootDiameterIn)

  INSERT INTO @SmallRootCompKeys
    SELECT compkey
    FROM @AllCompKeys
    EXCEPT
    SELECT compkey
    FROM @LargeRootCompKeys

  BEGIN TRANSACTION
    -- Insert normal inspection PM drivers
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by)
      SELECT compkey, driver_type_id, GETDATE(), 'System'
      FROM @SmallCompKeys, DRIVER_TYPES
      WHERE [DRIVER_TYPES].name = 'PM'

    -- Insert large inspection PM drivers
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by)
      SELECT compkey, driver_type_id, GETDATE(), 'System'
      FROM @LargeCompKeys, DRIVER_TYPES
      WHERE [DRIVER_TYPES].name = 'PMLarge'

    -- Insert normal cleaning PM drivers
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by)
      SELECT compkey, driver_type_id, GETDATE(), 'System'
      FROM @AllCompKeys, DRIVER_TYPES
      WHERE [DRIVER_TYPES].name = 'PMFaster'

    -- Insert H large root drivers
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System'
      FROM @LargeRootCompKeys A, SpecialRoot, DRIVER_TYPES
      WHERE SpecialRoot.ROOTPROB IN ('H') AND [DRIVER_TYPES].name = 'RootControlHLarge'

    -- Insert M large root drivers
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System'
      FROM @LargeRootCompKeys A, SpecialRoot, DRIVER_TYPES
      WHERE SpecialRoot.ROOTPROB IN ('M') AND [DRIVER_TYPES].name = 'RootControlMLarge'

    -- Insert H small root drivers
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System'
      FROM @SmallRootCompKeys A, SpecialRoot, DRIVER_TYPES
      WHERE SpecialRoot.ROOTPROB IN ('H') AND [DRIVER_TYPES].name = 'RootControlHSmall'

    -- Insert M small root drivers
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System'
      FROM @SmallRootCompKeys A, SpecialRoot, DRIVER_TYPES
      WHERE SpecialRoot.ROOTPROB IN ('M') AND [DRIVER_TYPES].name = 'RootControlMSmall'

    -- Insert Accelerated drivers
    INSERT INTO [DRIVERS] (compkey, driver_type_id, override_frequency_years, update_date, updated_by)
      SELECT A.compkey, driver_type_id, B.frequency_years, GETDATE(), 'System'
      FROM ASSETS A INNER JOIN ACCELERATED_CLEANINGS B ON (A.COMPKEY = B.compkey), DRIVER_TYPES C
      WHERE C.name = 'AcceleratedArea'

  COMMIT TRANSACTION
END