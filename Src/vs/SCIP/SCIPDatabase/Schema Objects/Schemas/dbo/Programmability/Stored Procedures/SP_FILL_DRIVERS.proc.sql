CREATE PROCEDURE [dbo].[SP_FILL_DRIVERS]
AS
BEGIN
  SET NOCOUNT ON
  EXEC SP_STATUS_MESSAGE 'Begin SP_FILL_DRIVERS'

  TRUNCATE TABLE [dbo].[DRIVERS]

  DECLARE @AllCompKeys TABLE (compkey int)
  DECLARE @LargeCompKeys TABLE (compkey int)
  DECLARE @SmallCompKeys TABLE (compkey int)
  DECLARE @LargeRootXORLargePipeCompKeys TABLE (compkey int)
  DECLARE @SmallRootCompKeys TABLE (compkey int)
  DECLARE @LargePipeCompkeys TABLE (compkey int)
  DECLARE @LargeTractiveCompKeys TABLE (compkey int)
  DECLARE @SmallTractiveCompKeys TABLE (compkey int)
  DECLARE @SmallTractiveSanCompKeys TABLE (compkey int)
  DECLARE @SmallTractiveCmbCompKeys TABLE (compkey int)
  --Anything equal to or greater than LargeDiameterIn is considered a large pipe
  DECLARE @LargeDiameterIn float
  SET @LargeDiameterIn = 36.01
  --Anything equal to or greater than LargeRootDiameterIn is considered a large root control pipe
  DECLARE @LargeRootDiameterIn float
  SET @LargeRootDiameterIn = 16
  DECLARE @LargeRootLargePipeCompKeys TABLE (compkey int)
  --Anything equal to or greater than LargeTractiveDiamterIn is considered a large tractive pipe
  DECLARE @LargeTractiveDiameterIn float
  SET @LargeTractiveDiameterIn = 24.01
  DECLARE @StatusMessage VARCHAR(100)

  RAISERROR(@StatusMessage, 0, 1) WITH NOWAIT

  --Create a list of every compkey
  INSERT INTO @AllCompKeys
    SELECT compkey
    FROM [dbo].[ASSETS]

  --Create a list of compkeys for pipes with dimensions greater than @LargeDiameterIn
  INSERT INTO @LargeCompKeys
    SELECT compkey
    FROM [dbo].[ASSETS]
    WHERE ([dbo].[ASSETS].diamWidth_inches >= @LargeDiameterIn) 
	      OR 
		  ([dbo].[ASSETS].height_inches >= @LargeDiameterIn)

  --Create a list of compkeys for pipes with dimensions LTE @LargeDiameterIn
  INSERT INTO @SmallCompKeys
    SELECT compkey
    FROM [dbo].[ASSETS]
    WHERE ([dbo].[ASSETS].diamWidth_inches < @LargeDiameterIn OR [dbo].[ASSETS].diamWidth_inches IS NULL) 
	      AND 
		  ([dbo].[ASSETS].height_inches < @LargeDiameterIn OR [dbo].[ASSETS].height_inches IS NULL)

  --Create a list of compkeys for pipes with dimensions GTE
  --the greater of (@largeRootDiameterIn and @LargeDiameterIn)
  INSERT INTO @LargeRootLargePipeCompKeys
    SELECT compkey
    FROM [dbo].[ASSETS]
    WHERE ([dbo].[ASSETS].diamWidth_inches >= @LargeRootDiameterIn OR [dbo].[ASSETS].height_inches >= @LargeRootDiameterIn)
          AND 
		  ([dbo].[ASSETS].diamWidth_inches >= @LargeDiameterIn OR [dbo].[ASSETS].height_inches >= @LargeDiameterIn)

  --Create a list of compkeys for pipes with dimensions between the large root cutoff and the large pipe cutoff
  --NOTE: it may occur at some point in the future that the large pipe cutoff is actually lower than the
  --large root cutoff
  --NOTE2: We use AND in the less than function because BOTH must be less than, while only one needed to be greater than
  --NOTE3: root cutoff and pipe cutoff are based upon different equality formats
  INSERT INTO @LargeRootXORLargePipeCompKeys
    SELECT compkey
    FROM [dbo].[ASSETS]
    WHERE (
	        (
			  ([dbo].[ASSETS].diamWidth_inches >= @LargeRootDiameterIn) 
			  OR 
			  ([dbo].[ASSETS].height_inches >= @LargeRootDiameterIn)
		    )
            AND
			(
              ([dbo].[ASSETS].diamWidth_inches < @LargeDiameterIn OR [dbo].[ASSETS].diamWidth_inches IS NULL) 
			  AND 
			  ([dbo].[ASSETS].height_inches < @LargeDiameterIn OR [dbo].[ASSETS].height_inches IS NULL)
			)
		  )
		  OR
		  (
	        (
			  ([dbo].[ASSETS].diamWidth_inches < @LargeRootDiameterIn OR [dbo].[ASSETS].diamWidth_inches IS NULL) 
			  AND 
			  ([dbo].[ASSETS].height_inches < @LargeRootDiameterIn OR [dbo].[ASSETS].height_inches IS NULL)
			)
            AND
			(
              ([dbo].[ASSETS].diamWidth_inches >= @LargeDiameterIn) 
			  OR 
			  ([dbo].[ASSETS].height_inches >= @LargeDiameterIn)
		    )
		  )

  --Create a list of compkeys for pipes that are smaller than both the large root pipes cutoff and
  --the large pipe cutoff
  INSERT INTO @SmallRootCompKeys
    SELECT compkey
    FROM [dbo].[ASSETS]
    WHERE (
	        ([ASSETS].diamWidth_inches < @LargeRootDiameterIn OR [dbo].[ASSETS].diamWidth_inches IS NULL) 
			AND 
			([ASSETS].height_inches < @LargeRootDiameterIn OR [dbo].[ASSETS].height_inches IS NULL)
		  )
	      AND
		  (
		    ([ASSETS].diamWidth_inches < @LargeDiameterIn OR [dbo].[ASSETS].diamWidth_inches IS NULL) 
			AND 
			([ASSETS].height_inches < @LargeDiameterIn OR [dbo].[ASSETS].height_inches IS NULL)
		  )

  --Create a list of compkeys for pipes that are GT the @LargeTractiveDiameterIn cutoff
  INSERT INTO @LargeTractiveCompKeys
  SELECT compkey
  FROM [dbo].[ASSETS]
  WHERE ([ASSETS].diamWidth_inches >= @LargeTractiveDiameterIn OR [ASSETS].height_inches >= @LargeTractiveDiameterIn)

  --Create a list of compkeys for pipes that are LTE the @LargeTractiveDiameterIn cutoff
  INSERT INTO @SmallTractiveCompKeys
  SELECT compkey
  FROM [dbo].[ASSETS]
  EXCEPT
    SELECT compkey
    FROM @LargeTractiveCompKeys

  --Create a list of compkeys for pipes that are in @SmallTractiveCompkeys and are sanitary interceptors or sanitary mainlines
  INSERT INTO @SmallTractiveSanCompKeys
  SELECT A.compkey
  FROM @SmallTractiveCompKeys A INNER JOIN ASSETS B ON (A.compkey = B.COMPKEY AND B.unit_type IN ('SAINT', 'SAML'))

  --Create a list of compkeys for pipes that are in @SmallTractiveCompkeys and are not sanitary interceptors or sanitary mainlines
  --(which technically leaves combined pipes, for our assumptions of the ASSETS table as of 5/21/2012)
  INSERT INTO @SmallTractiveCmbCompKeys
  SELECT compkey
  FROM @SmallTractiveCompKeys
  EXCEPT
    SELECT compkey
    FROM @SmallTractiveSanCompKeys

  -- Filling Routine
    -- Insert normal inspection PM drivers
    EXEC SP_STATUS_MESSAGE 'Inserting normal inspection PM drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @SmallCompKeys, DRIVER_TYPES
      WHERE [DRIVER_TYPES].name = 'PM'

    -- Insert large inspection PM drivers
    EXEC SP_STATUS_MESSAGE 'Inserting large inspection PM drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeCompKeys, DRIVER_TYPES
      WHERE [DRIVER_TYPES].name = 'PMLarge'

    -- Insert root control inspection drivers
    EXEC SP_STATUS_MESSAGE 'Inserting H root control inspection drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallRootCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY)), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlH' AND D.name = 'Inspection'

    --@LargeRootXORLargePipeCompKeys
	IF @LargeRootDiameterIn < @LargeDiameterIn
	  BEGIN
      EXEC SP_STATUS_MESSAGE 'Inserting H large root control inspection drivers'
      INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
        SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
        FROM @LargeRootXORLargePipeCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
        WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlHLarge' AND D.name = 'Inspection'
	  END
	ELSE
	  EXEC SP_STATUS_MESSAGE 'H large root control inspection drivers do not apply (@LargeRootDiameterIn >= @LargeDiameterIn'

    EXEC SP_STATUS_MESSAGE 'Inserting H large, large piperoot control inspection drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeRootLargePipeCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlHLargePipe' AND D.name = 'Inspection'

    EXEC SP_STATUS_MESSAGE 'Inserting M root control inspection drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @SmallRootCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlM' AND D.name = 'Inspection'
    
	--@LargeRootXORLargePipeCompKeys
	IF @LargeRootDiameterIn < @LargeDiameterIn
	  BEGIN
      EXEC SP_STATUS_MESSAGE 'Inserting M large root control inspection drivers'
      INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
        SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
        FROM @LargeRootXORLargePipeCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
        WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlMLarge' AND D.name = 'Inspection'
	  END
	ELSE
	  EXEC SP_STATUS_MESSAGE 'M large root control inspection drivers do not apply (@LargeRootDiameterIn >= @LargeDiameterIn'

    EXEC SP_STATUS_MESSAGE 'Inserting M large, large piperoot control inspection drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeRootLargePipeCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlMLargePipe' AND D.name = 'Inspection'

    -- Insert Condition inspection drivers
    EXEC SP_STATUS_MESSAGE 'Inserting condition inspections (non-large)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, override_frequency_years, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, B.next_condition_inspection_interval_years, GETDATE(), 'System', 1
      FROM @SmallCompKeys A INNER JOIN VW_NEXT_CONDITION_INSPECTION_INTERVAL B ON (A.compkey = B.compkey), DRIVER_TYPES D
      WHERE D.name = 'Condition'

    EXEC SP_STATUS_MESSAGE 'Inserting condition inspections (large)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, override_frequency_years, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, B.next_condition_inspection_interval_years, GETDATE(), 'System', 1
      FROM @LargeCompKeys A INNER JOIN VW_NEXT_CONDITION_INSPECTION_INTERVAL B ON (A.compkey = B.compkey), DRIVER_TYPES D
      WHERE D.name = 'ConditionLarge'

    -- Delete Grade 5 Inspections
    EXEC SP_STATUS_MESSAGE 'Deleting Grade 5 Inspections'
    DELETE FROM [DRIVERS]
    WHERE driver_id IN
      (
        SELECT driver_id
        FROM ((DRIVERS A INNER JOIN ASSETS B ON (A.compkey = B.COMPKEY)) INNER JOIN DRIVER_TYPES C ON (A.driver_type_id = C.driver_type_id)) INNER JOIN ACTIVITY_TYPES D ON (D.activity_type_id = C.activity_type_id)
        WHERE (B.structural_grade = 5 AND (D.name = 'Inspection'))
      )

   ---------------------------------------------------------------------------

    -- Insert H large root drivers
	--@LargeRootXORLargePipeCompKeys
	IF @LargeRootDiameterIn < @LargeDiameterIn
	  BEGIN
	  EXEC SP_STATUS_MESSAGE 'Inserting H large root drivers'
	  INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
	    SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
	    FROM @LargeRootXORLargePipeCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
	    WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlHLarge' AND D.name = 'Root Management'
	  END
	ELSE
	  EXEC SP_STATUS_MESSAGE 'H large root drivers do not apply (@LargeRootDiameterIn >= @LargeDiameterIn'

    -- Insert H large root large pipe drivers
    EXEC SP_STATUS_MESSAGE 'Inserting H large root large pipe drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeRootLargePipeCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlHLarge' AND D.name = 'Root Management'

    -- Insert M large root drivers
	--@LargeRootXORLargePipeCompKeys
	IF @LargeRootDiameterIn < @LargeDiameterIn
	  BEGIN
      EXEC SP_STATUS_MESSAGE 'Inserting M large root drivers'
      INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
        SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
        FROM @LargeRootXORLargePipeCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
        WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlMLarge' AND D.name = 'Root Management'
	  END
	ELSE
	  EXEC SP_STATUS_MESSAGE 'M large root drivers do not apply (@LargeRootDiameterIn >= @LargeDiameterIn'

    -- Insert M large root large pipe drivers
    EXEC SP_STATUS_MESSAGE 'Inserting M large root large pipe drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @LargeRootLargePipeCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlMLarge' AND D.name = 'Root Management'

    -- Insert H small root drivers
    EXEC SP_STATUS_MESSAGE 'Inserting H small root drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @SmallRootCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlH' AND D.name = 'Root Management'

    -- Insert M small root drivers
    EXEC SP_STATUS_MESSAGE 'Inserting M small root drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM @SmallRootCompKeys A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlM' AND D.name = 'Root Management'

    ---------------------------------------------------------------------------

    -- Insert normal cleaning PM drivers
    EXEC SP_STATUS_MESSAGE 'Inserting normal cleaning PM drivers (non-large)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT compkey, driver_type_id, GETDATE(), 'System', 1 
      FROM @SmallCompKeys, DRIVER_TYPES
      WHERE [DRIVER_TYPES].name = 'PMFaster'

    -- Insert Accelerated drivers
    EXEC SP_STATUS_MESSAGE 'Inserting Accelerated drivers (non-large)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, override_frequency_years, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, B.frequency_years, GETDATE(), 'System', 1
      FROM @SmallCompKeys A INNER JOIN ACCELERATED_CLEANINGS B ON (A.COMPKEY = B.compkey), DRIVER_TYPES C
      WHERE C.name = 'AcceleratedArea'

    EXEC SP_STATUS_MESSAGE 'Inserting Accelerated drivers (large)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, override_frequency_years, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, B.frequency_years, GETDATE(), 'System', 1
      FROM @LargeCompKeys A INNER JOIN ACCELERATED_CLEANINGS B ON (A.COMPKEY = B.compkey), DRIVER_TYPES C
      WHERE C.name = 'AcceleratedAreaLarge'

    -- Insert Tractive Force drivers
    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers sanitary (VH)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveSanCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VH' AND D.name = 'TractiveForcesSanVH'

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers sanitary (H)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveSanCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'H' AND D.name = 'TractiveForcesSanH'

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers sanitary (M)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveSanCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'M' AND D.name = 'TractiveForcesSanM'

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers sanitary (L)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveSanCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'L' AND D.name = 'TractiveForcesSanL'

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers sanitary (VL)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveSanCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VL' AND D.name = 'TractiveForcesSanVL'

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers combo (VH)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveCmbCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VH' AND D.name = 'TractiveForcesCmbVH'

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers combo (H)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveCmbCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'H' AND D.name = 'TractiveForcesCmbH'

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers combo (M)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveCmbCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'M' AND D.name = 'TractiveForcesCmbM'

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers combo (L)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveCmbCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'L' AND D.name = 'TractiveForcesCmbL'

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers combo (VL)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@SmallTractiveCmbCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VL' AND D.name = 'TractiveForcesCmbVL'

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers large (Large VH)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@LargeTractiveCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VH' AND D.name = 'TractiveForcesVHLarge'

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers large (Large H)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@LargeTractiveCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'H' AND D.name = 'TractiveForcesHLarge'
    -- Insert Condition inspection drivers

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers large (Large M)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@LargeTractiveCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'M' AND D.name = 'TractiveForcesMLarge'

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers large (Large L)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@LargeTractiveCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'L' AND D.name = 'TractiveForcesLLarge'

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers large (Large VL)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', 1
      FROM (@LargeTractiveCompKeys A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VL' AND D.name = 'TractiveForcesVLLarge'

    -- Delete Grade 5 Cleanings
    EXEC SP_STATUS_MESSAGE 'Deleting Grade 5 Cleanings'
    DELETE FROM [DRIVERS]
    WHERE driver_id IN
      (
        SELECT driver_id
        FROM ((DRIVERS A INNER JOIN ASSETS B ON (A.compkey = B.COMPKEY)) INNER JOIN DRIVER_TYPES C ON (A.driver_type_id = C.driver_type_id)) INNER JOIN ACTIVITY_TYPES D ON (D.activity_type_id = C.activity_type_id)
        WHERE (B.structural_grade = 5 AND (D.name = 'Cleaning'))
      )

    EXEC SP_STATUS_MESSAGE 'End SP_FILL_DRIVERS'
END