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
  DECLARE @LargeRootLargePipeCompKeys TABLE (compkey int)

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

  INSERT INTO @LargeRootLargePipeCompKeys
    SELECT compkey
    FROM [dbo].[ASSETS]
    WHERE ([ASSETS].diamWidth_inches >= @LargeRootDiameterIn OR [ASSETS].height_inches >= @LargeRootDiameterIn)
      AND ([ASSETS].diamWidth_inches > @LargeDiameterIn OR [ASSETS].height_inches > @LargeDiameterIn)

  INSERT INTO @LargeRootCompKeys
    SELECT compkey
    FROM [dbo].[ASSETS]
    WHERE ([ASSETS].diamWidth_inches >= @LargeRootDiameterIn) OR ([ASSETS].height_inches >= @LargeRootDiameterIn)
    EXCEPT
      SELECT compkey
      FROM @LargeRootLargePipeCompKeys

  INSERT INTO @SmallRootCompKeys
    SELECT compkey
    FROM @AllCompKeys
    EXCEPT
      SELECT compkey
      FROM @LargeRootCompKeys
      UNION SELECT compkey
      FROM @LargeRootLargePipeCompKeys

  BEGIN TRANSACTION
    -- Insert normal inspection PM drivers
    PRINT 'Inserting normal inspection PM drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @SmallCompKeys, DRIVER_TYPES
      WHERE [DRIVER_TYPES].name = 'PM'

    -- Insert large inspection PM drivers
    PRINT 'Inserting large inspection PM drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeCompKeys, DRIVER_TYPES
      WHERE [DRIVER_TYPES].name = 'PMLarge'

    -- Insert normal cleaning PM drivers
    PRINT 'Inserting normal cleaning PM drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT compkey, driver_type_id, GETDATE(), 'System', 1 
      FROM @AllCompKeys, DRIVER_TYPES
      WHERE [DRIVER_TYPES].name = 'PMFaster'

    -- Insert H large root drivers
    PRINT 'Inserting H large root drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeRootCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES
      WHERE B.ROOTPROB IN ('H') AND [DRIVER_TYPES].name = 'RootControlHLarge'

    -- Insert H large root large pipe drivers
    PRINT 'Inserting H large root large pipe drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeRootLargePipeCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES
      WHERE B.ROOTPROB IN ('H') AND [DRIVER_TYPES].name = 'RootControlHLargePipe'

    -- Insert M large root drivers
    PRINT 'Inserting M large root drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeRootCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES
      WHERE B.ROOTPROB IN ('M') AND [DRIVER_TYPES].name = 'RootControlMLarge'

    -- Insert M large root large pipe drivers
    PRINT 'Inserting M large root large pipe drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeRootLargePipeCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES
      WHERE B.ROOTPROB IN ('M') AND [DRIVER_TYPES].name = 'RootControlMLargePipe'

    -- Insert H small root drivers
    PRINT 'Inserting H small root drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @SmallRootCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES
      WHERE B.ROOTPROB IN ('H') AND [DRIVER_TYPES].name = 'RootControlH'

    -- Insert M small root drivers
    PRINT 'Inserting M small root drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @SmallRootCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES
      WHERE B.ROOTPROB IN ('M') AND [DRIVER_TYPES].name = 'RootControlM'

    -- Insert Accelerated drivers
    PRINT 'Inserting Accelerated drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, override_frequency_years, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, B.frequency_years, GETDATE(), 'System', 1
      FROM ASSETS A INNER JOIN ACCELERATED_CLEANINGS B ON (A.COMPKEY = B.compkey), DRIVER_TYPES C
      WHERE C.name = 'AcceleratedArea'

    -- Insert Tractive Force drivers
    PRINT 'Inserting Tractive Force drivers (VH)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VH' AND D.name = 'TractiveForcesVH'

    PRINT 'Inserting Tractive Force drivers (H)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'H' AND D.name = 'TractiveForcesH'
    -- Insert Condition inspection drivers

    PRINT 'Inserting Tractive Force drivers (M)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'M' AND D.name = 'TractiveForcesM'

    PRINT 'Inserting Tractive Force drivers (L)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'L' AND D.name = 'TractiveForcesL'

    PRINT 'Inserting Tractive Force drivers (VL)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VL' AND D.name = 'TractiveForcesVL'

    PRINT 'Inserting Tractive Force drivers large (Large VH)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@LargeCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VH' AND D.name = 'TractiveForcesVHLarge'

    PRINT 'Inserting Tractive Force drivers large (Large H)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@LargeCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'H' AND D.name = 'TractiveForcesHLarge'
    -- Insert Condition inspection drivers

    PRINT 'Inserting Tractive Force drivers large (Large M)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@LargeCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'M' AND D.name = 'TractiveForcesMLarge'

    PRINT 'Inserting Tractive Force drivers large (Large L)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@LargeCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'L' AND D.name = 'TractiveForcesLLarge'

    PRINT 'Inserting Tractive Force drivers large (Large VL)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@LargeCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VL' AND D.name = 'TractiveForcesVLLarge'
  COMMIT TRANSACTION
END