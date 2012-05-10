﻿CREATE PROCEDURE [dbo].[SP_FILL_DRIVERS]
AS
BEGIN
  TRUNCATE TABLE [dbo].[DRIVERS]

  DECLARE @AllCompKeys TABLE (compkey int)
  DECLARE @LargeCompKeys TABLE (compkey int)
  DECLARE @SmallCompKeys TABLE (compkey int)
  DECLARE @LargeRootCompKeys TABLE (compkey int)
  DECLARE @SmallRootCompKeys TABLE (compkey int)
  DECLARE @LargeTractiveCompKeys TABLE (compkey int)
  DECLARE @SmallTractiveCompKeys TABLE (compkey int)
  DECLARE @SmallTractiveSanCompKeys TABLE (compkey int)
  DECLARE @SmallTractiveCmbCompKeys TABLE (compkey int)
  DECLARE @LargeDiameterIn int
  SET @LargeDiameterIn = 36
  DECLARE @LargeRootDiameterIn int
  SET @LargeRootDiameterIn = 16
  DECLARE @LargeRootLargePipeCompKeys TABLE (compkey int)
  DECLARE @LargeTractiveDiameterIn int
  SET @LargeTractiveDiameterIn = 24

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

  INSERT INTO @LargeTractiveCompKeys
  SELECT compkey
  FROM [dbo].[ASSETS]
  WHERE ([ASSETS].diamWidth_inches > @LargeTractiveDiameterIn OR [ASSETS].height_inches > @LargeTractiveDiameterIn)

  INSERT INTO @SmallTractiveCompKeys
  SELECT compkey
  FROM [dbo].[ASSETS]
  EXCEPT
    SELECT compkey
    FROM @LargeTractiveCompKeys

  INSERT INTO @SmallTractiveSanCompKeys
  SELECT A.compkey
  FROM @SmallTractiveCompKeys A INNER JOIN ASSETS B ON (A.compkey = B.COMPKEY AND B.unit_type IN ('SAINT', 'SAML'))

  INSERT INTO @SmallTractiveCmbCompKeys
  SELECT compkey
  FROM @SmallTractiveCompKeys
  EXCEPT
    SELECT compkey
    FROM @SmallTractiveSanCompKeys

  -- Filling Routine
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

    -- Insert root control inspection drivers
    PRINT 'Inserting H root control inspection drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallRootCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY)), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlH' AND D.name = 'Inspection'

    PRINT 'Inserting H large root control inspection drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeRootCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlHLarge' AND D.name = 'Inspection'

    PRINT 'Inserting H large, large piperoot control inspection drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeRootLargePipeCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlHLargePipe' AND D.name = 'Inspection'

    PRINT 'Inserting M root control inspection drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @SmallRootCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlM' AND D.name = 'Inspection'

    PRINT 'Inserting M large root control inspection drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeRootCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlMLarge' AND D.name = 'Inspection'

    PRINT 'Inserting M large, large piperoot control inspection drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeRootLargePipeCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlMLargePipe' AND D.name = 'Inspection'

    ---------------------------------------------------------------------------

    -- Insert H large root drivers
    PRINT 'Inserting H large root drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeRootCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlHLarge' AND D.name = 'Root Management'

    -- Insert H large root large pipe drivers
    PRINT 'Inserting H large root large pipe drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeRootLargePipeCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlHLarge' AND D.name = 'Root Management'

    -- Insert M large root drivers
    PRINT 'Inserting M large root drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeRootCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlMLarge' AND D.name = 'Root Management'

    -- Insert M large root large pipe drivers
    PRINT 'Inserting M large root large pipe drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeRootLargePipeCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlMLarge' AND D.name = 'Root Management'

    -- Insert H small root drivers
    PRINT 'Inserting H small root drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @SmallRootCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlH' AND D.name = 'Root Management'

    -- Insert M small root drivers
    PRINT 'Inserting M small root drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @SmallRootCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlM' AND D.name = 'Root Management'

    ---------------------------------------------------------------------------

    -- Insert normal cleaning PM drivers
    PRINT 'Inserting normal cleaning PM drivers (non-large)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT compkey, driver_type_id, GETDATE(), 'System', 1 
      FROM @SmallCompKeys, DRIVER_TYPES
      WHERE [DRIVER_TYPES].name = 'PMFaster'

    -- Insert Accelerated drivers
    PRINT 'Inserting Accelerated drivers (non-large)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, override_frequency_years, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, B.frequency_years, GETDATE(), 'System', 1
      FROM @SmallCompKeys A INNER JOIN ACCELERATED_CLEANINGS B ON (A.COMPKEY = B.compkey), DRIVER_TYPES C
      WHERE C.name = 'AcceleratedArea'

    PRINT 'Inserting Accelerated drivers (large)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, override_frequency_years, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, B.frequency_years, GETDATE(), 'System', 1
      FROM @LargeCompKeys A INNER JOIN ACCELERATED_CLEANINGS B ON (A.COMPKEY = B.compkey), DRIVER_TYPES C
      WHERE C.name = 'AcceleratedAreaLarge'

    -- Insert Tractive Force drivers
    PRINT 'Inserting Tractive Force drivers sanitary (VH)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveSanCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VH' AND D.name = 'TractiveForcesSanVH'

    PRINT 'Inserting Tractive Force drivers sanitary (H)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveSanCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'H' AND D.name = 'TractiveForcesSanH'

    PRINT 'Inserting Tractive Force drivers sanitary (M)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveSanCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'M' AND D.name = 'TractiveForcesSanM'

    PRINT 'Inserting Tractive Force drivers sanitary (L)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveSanCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'L' AND D.name = 'TractiveForcesSanL'

    PRINT 'Inserting Tractive Force drivers sanitary (VL)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveSanCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VL' AND D.name = 'TractiveForcesCmbVL'

    PRINT 'Inserting Tractive Force drivers combo (VH)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveCmbCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VH' AND D.name = 'TractiveForcesCmbVH'

    PRINT 'Inserting Tractive Force drivers combo (H)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveCmbCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'H' AND D.name = 'TractiveForcesCmbH'

    PRINT 'Inserting Tractive Force drivers combo (M)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveCmbCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'M' AND D.name = 'TractiveForcesCmbM'

    PRINT 'Inserting Tractive Force drivers combo (L)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveCmbCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'L' AND D.name = 'TractiveForcesCmbL'

    PRINT 'Inserting Tractive Force drivers combo (VL)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveCmbCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VL' AND D.name = 'TractiveForcesCmbVL'

    PRINT 'Inserting Tractive Force drivers large (Large VH)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@LargeTractiveCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VH' AND D.name = 'TractiveForcesVHLarge'

    PRINT 'Inserting Tractive Force drivers large (Large H)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@LargeTractiveCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'H' AND D.name = 'TractiveForcesHLarge'
    -- Insert Condition inspection drivers

    PRINT 'Inserting Tractive Force drivers large (Large M)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@LargeTractiveCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'M' AND D.name = 'TractiveForcesMLarge'

    PRINT 'Inserting Tractive Force drivers large (Large L)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@LargeTractiveCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'L' AND D.name = 'TractiveForcesLLarge'

    PRINT 'Inserting Tractive Force drivers large (Large VL)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@LargeTractiveCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VL' AND D.name = 'TractiveForcesVLLarge'

    -- Insert Condition inspection drivers
    PRINT 'Inserting condition inspections (non-large)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, override_frequency_years, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, B.next_condition_inspection_interval_years, GETDATE(), 'System', 1
      FROM @SmallCompKeys A INNER JOIN VW_NEXT_CONDITON_INSPECTION_INTERVAL B ON (A.compkey = B.compkey), DRIVER_TYPES D
      WHERE D.name = 'Condition'

    PRINT 'Inserting condition inspections (large)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, override_frequency_years, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, B.next_condition_inspection_interval_years, GETDATE(), 'System', 1
      FROM @LargeCompKeys A INNER JOIN VW_NEXT_CONDITON_INSPECTION_INTERVAL B ON (A.compkey = B.compkey), DRIVER_TYPES D
      WHERE D.name = 'ConditionLarge'

  COMMIT TRANSACTION
END