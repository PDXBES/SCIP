CREATE PROCEDURE [dbo].[SP_FILL_DRIVERS]
(
  @alternative_id INT = 1,
  @override_cleaning_PM_for_small_size_low_tractive_force BIT = 'FALSE'
)
AS
BEGIN
  SET NOCOUNT ON
  DECLARE @statusMessage VARCHAR(200)
  SET @statusMessage = 'Begin SP_FILL_DRIVERS, alternative_id = ' + CONVERT(VARCHAR(10), @alternative_id)
  EXEC SP_STATUS_MESSAGE @statusMessage

  TRUNCATE TABLE DRIVERS_ALL_COMPKEYS_FOR_PROCESSING
  TRUNCATE TABLE DRIVERS_LARGE_COMPKEYS_FOR_PROCESSING
  TRUNCATE TABLE DRIVERS_LARGE_ROOT_LARGE_PIPE_COMPKEYS_FOR_PROCESSING
  TRUNCATE TABLE DRIVERS_LARGE_ROOT_XOR_LARGE_PIPE_COMPKEYS_FOR_PROCESSING
  TRUNCATE TABLE DRIVERS_LARGE_TRACTIVE_COMPKEYS_FOR_PROCESSING
  TRUNCATE TABLE DRIVERS_SMALL_COMPKEYS_FOR_PROCESSING
  TRUNCATE TABLE DRIVERS_SMALL_ROOT_COMPKEYS_FOR_PROCESSING
  TRUNCATE TABLE DRIVERS_SMALL_TRACTIVE_COMBO_COMPKEYS_FOR_PROCESSING
  TRUNCATE TABLE DRIVERS_SMALL_TRACTIVE_COMPKEYS_FOR_PROCESSING
  TRUNCATE TABLE DRIVERS_SMALL_TRACTIVE_SANITARY_COMPKEYS_FOR_PROCESSING

  DELETE FROM DRIVERS WHERE alternative_id = @alternative_id

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

  DECLARE @asset_set_id INT
  SELECT @asset_set_id = asset_set_id
  FROM ALTERNATIVES
  WHERE alternative_id = @alternative_id

  ------------------------------------------------------------------------------------------------
  -- Create Lists
  ------------------------------------------------------------------------------------------------

  --Create a list of every compkey
  EXEC SP_STATUS_MESSAGE 'Creating list of all compkeys'
  INSERT INTO DRIVERS_ALL_COMPKEYS_FOR_PROCESSING
    SELECT compkey
    FROM [dbo].[ASSETS]
    WHERE asset_set_id = @asset_set_id

  --Create a list of compkeys for pipes with dimensions greater than @LargeDiameterIn
  EXEC SP_STATUS_MESSAGE 'Creating list of large compkeys'
  INSERT INTO DRIVERS_LARGE_COMPKEYS_FOR_PROCESSING
    SELECT compkey
    FROM [dbo].[ASSETS]
    WHERE 
      (([dbo].[ASSETS].diamWidth_inches >= @LargeDiameterIn) 
	      OR 
		    ([dbo].[ASSETS].height_inches >= @LargeDiameterIn))
      AND (asset_set_id = @asset_set_id)

  --Create a list of compkeys for pipes with dimensions LTE @LargeDiameterIn
  EXEC SP_STATUS_MESSAGE 'Creating list of small compkeys'
  INSERT INTO DRIVERS_SMALL_COMPKEYS_FOR_PROCESSING
    SELECT compkey
    FROM [dbo].[ASSETS]
    WHERE 
      ([dbo].[ASSETS].diamWidth_inches < @LargeDiameterIn OR [dbo].[ASSETS].diamWidth_inches IS NULL) 
	      AND 
		    ([dbo].[ASSETS].height_inches < @LargeDiameterIn OR [dbo].[ASSETS].height_inches IS NULL)
      AND (asset_set_id = @asset_set_id)

  --Create a list of compkeys for pipes with dimensions GTE
  --the greater of (@largeRootDiameterIn and @LargeDiameterIn)
  EXEC SP_STATUS_MESSAGE 'Creating list of large root, large pipe compkeys'
  INSERT INTO DRIVERS_LARGE_ROOT_LARGE_PIPE_COMPKEYS_FOR_PROCESSING
    SELECT compkey
    FROM [dbo].[ASSETS]
    WHERE 
      (([dbo].[ASSETS].diamWidth_inches >= @LargeRootDiameterIn OR [dbo].[ASSETS].height_inches >= @LargeRootDiameterIn)
        AND 
		    ([dbo].[ASSETS].diamWidth_inches >= @LargeDiameterIn OR [dbo].[ASSETS].height_inches >= @LargeDiameterIn))
      AND (asset_set_id = @asset_set_id)

  --Create a list of compkeys for pipes with dimensions between the large root cutoff and the large pipe cutoff
  --NOTE: it may occur at some point in the future that the large pipe cutoff is actually lower than the
  --large root cutoff
  --NOTE2: We use AND in the less than function because BOTH must be less than, while only one needed to be greater than
  --NOTE3: root cutoff and pipe cutoff are based upon different equality formats
  EXEC SP_STATUS_MESSAGE 'Creating list of large root or large pipe (but not both) compkeys'
  INSERT INTO DRIVERS_LARGE_ROOT_XOR_LARGE_PIPE_COMPKEYS_FOR_PROCESSING
    SELECT DISTINCT compkey
    FROM [dbo].[ASSETS]
    WHERE 
      (
	      (([dbo].[ASSETS].diamWidth_inches >= @LargeRootDiameterIn) 
			    OR 
			    ([dbo].[ASSETS].height_inches >= @LargeRootDiameterIn))
        AND
			  (
          ([dbo].[ASSETS].diamWidth_inches < @LargeDiameterIn OR [dbo].[ASSETS].diamWidth_inches IS NULL) 
			      AND 
			    ([dbo].[ASSETS].height_inches < @LargeDiameterIn OR [dbo].[ASSETS].height_inches IS NULL)
			  )
		  )
		  OR
		  (
	      (([dbo].[ASSETS].diamWidth_inches < @LargeRootDiameterIn OR [dbo].[ASSETS].diamWidth_inches IS NULL) 
			    AND 
			    ([dbo].[ASSETS].height_inches < @LargeRootDiameterIn OR [dbo].[ASSETS].height_inches IS NULL))
        AND
			  (([dbo].[ASSETS].diamWidth_inches >= @LargeDiameterIn) 
			    OR 
			    ([dbo].[ASSETS].height_inches >= @LargeDiameterIn))
		  )
      AND (asset_set_id = @asset_set_id)

  --Create a list of compkeys for pipes that are smaller than both the large root pipes cutoff and
  --the large pipe cutoff
  EXEC SP_STATUS_MESSAGE 'Creating list of small root compkeys'
  INSERT INTO DRIVERS_SMALL_ROOT_COMPKEYS_FOR_PROCESSING
    SELECT compkey
    FROM [dbo].[ASSETS]
    WHERE 
      (
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
      AND (asset_set_id = @asset_set_id)

  --Create a list of compkeys for pipes that are GT the @LargeTractiveDiameterIn cutoff
  EXEC SP_STATUS_MESSAGE 'Creating list of large tractive compkeys'
  INSERT INTO DRIVERS_LARGE_TRACTIVE_COMPKEYS_FOR_PROCESSING
  SELECT compkey
  FROM [dbo].[ASSETS]
  WHERE ([ASSETS].diamWidth_inches >= @LargeTractiveDiameterIn OR [ASSETS].height_inches >= @LargeTractiveDiameterIn)
    AND (asset_set_id = @asset_set_id)

  --Create a list of compkeys for pipes that are LTE the @LargeTractiveDiameterIn cutoff
  EXEC SP_STATUS_MESSAGE 'Creating list of small tractive compkeys'
  INSERT INTO DRIVERS_SMALL_TRACTIVE_COMPKEYS_FOR_PROCESSING
  SELECT compkey
  FROM [dbo].[ASSETS]
  WHERE (([ASSETS].diamWidth_inches < @LargeTractiveDiameterIn OR [ASSETS].diamWidth_inches IS NULL)AND ([ASSETS].height_inches < @LargeTractiveDiameterIn OR [ASSETS].height_inches IS NULL)) AND (asset_set_id = @asset_set_id)

  --Create a list of compkeys for pipes that are in @SmallTractiveCompkeys and are sanitary interceptors or sanitary mainlines
  EXEC SP_STATUS_MESSAGE 'Creating list of small tractive sanitary compkeys'
  INSERT INTO DRIVERS_SMALL_TRACTIVE_SANITARY_COMPKEYS_FOR_PROCESSING
  SELECT A.compkey
  FROM DRIVERS_SMALL_TRACTIVE_COMPKEYS_FOR_PROCESSING A INNER JOIN ASSETS B ON 
    ((A.compkey = B.COMPKEY AND B.unit_type IN ('SAINT', 'SAML')) AND (B.asset_set_id = @asset_set_id))

  --Create a list of compkeys for pipes that are in @SmallTractiveCompkeys and are not sanitary interceptors or sanitary mainlines
  --(which technically leaves combined pipes, for our assumptions of the ASSETS table as of 5/21/2012)
  EXEC SP_STATUS_MESSAGE 'Creating list of small tractive combo compkeys'
  INSERT INTO DRIVERS_SMALL_TRACTIVE_COMBO_COMPKEYS_FOR_PROCESSING
  SELECT A.compkey
  FROM DRIVERS_SMALL_TRACTIVE_COMPKEYS_FOR_PROCESSING A INNER JOIN ASSETS B ON 
    ((A.compkey = B.COMPKEY AND B.unit_type NOT IN ('SAINT', 'SAML')) AND (B.asset_set_id = @asset_set_id))

  ------------------------------------------------------------------------------------------------
  -- Filling Routine
  ------------------------------------------------------------------------------------------------

    ----------------------------------------------------------------------------------------------
    -- Inspection Activities
    ----------------------------------------------------------------------------------------------

    -- Insert normal inspection PM drivers
    EXEC SP_STATUS_MESSAGE 'Inserting normal inspection PM drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM DRIVERS_SMALL_COMPKEYS_FOR_PROCESSING, DRIVER_TYPES
      WHERE [DRIVER_TYPES].name = 'PM' AND alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    -- Insert large inspection PM drivers
    EXEC SP_STATUS_MESSAGE 'Inserting large inspection PM drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM DRIVERS_LARGE_COMPKEYS_FOR_PROCESSING, DRIVER_TYPES
      WHERE [DRIVER_TYPES].name = 'PMLarge' AND alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    -- Insert root control inspection drivers
    EXEC SP_STATUS_MESSAGE 'Inserting H root control inspection drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM (DRIVERS_SMALL_ROOT_COMPKEYS_FOR_PROCESSING A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY AND B.asset_set_id = @asset_set_id)), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlH' AND D.name = 'Inspection' AND C.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    --@LargeRootXORLargePipeCompKeys
	IF @LargeRootDiameterIn < @LargeDiameterIn
	  BEGIN
      EXEC SP_STATUS_MESSAGE 'Inserting H large root control inspection drivers'
      INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
        SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
        FROM DRIVERS_LARGE_ROOT_XOR_LARGE_PIPE_COMPKEYS_FOR_PROCESSING A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY AND B.asset_set_id = @asset_set_id), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
        WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlHLarge' AND D.name = 'Inspection' AND C.alternative_id = @alternative_id
        SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
        EXEC SP_STATUS_MESSAGE @statusMessage
	  END
	ELSE
	  EXEC SP_STATUS_MESSAGE 'H large root control inspection drivers do not apply (@LargeRootDiameterIn >= @LargeDiameterIn'

    EXEC SP_STATUS_MESSAGE 'Inserting H large, large piperoot control inspection drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM DRIVERS_LARGE_ROOT_LARGE_PIPE_COMPKEYS_FOR_PROCESSING A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY AND B.asset_set_id = @asset_set_id), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlHLargePipe' AND D.name = 'Inspection' AND C.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Inserting M root control inspection drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM DRIVERS_SMALL_ROOT_COMPKEYS_FOR_PROCESSING A INNER JOIN SpecialRoot B ON (A.COMPKEY = B.COMPKEY AND B.asset_set_id = @asset_set_id), DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlM' AND D.name = 'Inspection' AND C.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage
    
	--@LargeRootXORLargePipeCompKeys
	IF @LargeRootDiameterIn < @LargeDiameterIn
	  BEGIN
      EXEC SP_STATUS_MESSAGE 'Inserting M large root control inspection drivers'
      INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
        SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
        FROM DRIVERS_LARGE_ROOT_XOR_LARGE_PIPE_COMPKEYS_FOR_PROCESSING A INNER JOIN SpecialRoot B ON ((A.COMPKEY = B.COMPKEY) AND (B.asset_set_id = @asset_set_id)),
          DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
        WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlMLarge' AND D.name = 'Inspection' AND C.alternative_id = @alternative_id
      SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
      EXEC SP_STATUS_MESSAGE @statusMessage
	  END
	ELSE
	  EXEC SP_STATUS_MESSAGE 'M large root control inspection drivers do not apply (@LargeRootDiameterIn >= @LargeDiameterIn'

    EXEC SP_STATUS_MESSAGE 'Inserting M large, large piperoot control inspection drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM DRIVERS_LARGE_ROOT_LARGE_PIPE_COMPKEYS_FOR_PROCESSING A INNER JOIN SpecialRoot B ON ((A.COMPKEY = B.COMPKEY) AND (B.asset_set_id = @asset_set_id)),
        DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlMLargePipe' AND D.name = 'Inspection' AND C.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    -- Insert Condition inspection drivers
    EXEC SP_STATUS_MESSAGE 'Preparing condition inspection (large) drivers insert'
    DECLARE @LargeConditionInspectionDrivers TABLE 
      (compkey INT, driver_type_id INT, override_frequency_years DECIMAL (7,2), update_date DATETIME, updated_by VARCHAR(20), alternative_id INT)
    INSERT INTO @LargeConditionInspectionDrivers (compkey, driver_type_id, override_frequency_years, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, B.next_condition_inspection_interval_years, GETDATE(), 'System', @alternative_id
      FROM DRIVERS_LARGE_COMPKEYS_FOR_PROCESSING A INNER JOIN VW_NEXT_CONDITION_INSPECTION_INTERVAL B ON ((A.compkey = B.compkey) AND (B.asset_set_id = @asset_set_id)), DRIVER_TYPES D
      WHERE D.name = 'ConditionLarge' AND D.alternative_id = @alternative_id

    EXEC SP_STATUS_MESSAGE 'Inserting condition inspections (large)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, override_frequency_years, update_date, updated_by, alternative_id)
      SELECT * FROM @LargeConditionInspectionDrivers
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Preparing condition inspection (non-large) drivers insert'
    DECLARE @SmallConditionInspectionDrivers TABLE 
      (compkey INT, driver_type_id INT, override_frequency_years DECIMAL (7,2), update_date DATETIME, updated_by VARCHAR(20), alternative_id INT)
    INSERT INTO @SmallConditionInspectionDrivers (compkey, driver_type_id, override_frequency_years, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, B.next_condition_inspection_interval_years, GETDATE(), 'System', @alternative_id
      FROM DRIVERS_SMALL_COMPKEYS_FOR_PROCESSING A INNER JOIN VW_NEXT_CONDITION_INSPECTION_INTERVAL B ON ((A.compkey = B.compkey) AND (B.asset_set_id = @asset_set_id)), DRIVER_TYPES D
      WHERE D.name = 'Condition' AND D.alternative_id = @alternative_id

    EXEC SP_STATUS_MESSAGE 'Inserting condition inspections (non-large)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, override_frequency_years, update_date, updated_by, alternative_id)
      SELECT * FROM @SmallConditionInspectionDrivers
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    -- Delete Grade 5 Inspections
    EXEC SP_STATUS_MESSAGE 'Deleting Grade 5 Inspections'
    DELETE FROM [DRIVERS]
    WHERE driver_id IN
      (
        SELECT driver_id
        FROM ((DRIVERS A INNER JOIN ASSETS B ON (A.compkey = B.COMPKEY)) INNER JOIN DRIVER_TYPES C ON (A.driver_type_id = C.driver_type_id)) INNER JOIN ACTIVITY_TYPES D ON (D.activity_type_id = C.activity_type_id)
        WHERE (B.structural_grade = 5 AND (D.name = 'Inspection')) AND C.alternative_id = @alternative_id
      )
      AND alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    ----------------------------------------------------------------------------------------------
    -- Root Management Activities
    ----------------------------------------------------------------------------------------------

    -- Insert H large root drivers
	--@LargeRootXORLargePipeCompKeys
	IF @LargeRootDiameterIn < @LargeDiameterIn
	  BEGIN
	  EXEC SP_STATUS_MESSAGE 'Inserting H large root drivers'
	  INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
	    SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
	    FROM DRIVERS_LARGE_ROOT_XOR_LARGE_PIPE_COMPKEYS_FOR_PROCESSING A INNER JOIN SpecialRoot B ON ((A.COMPKEY = B.COMPKEY) AND (B.asset_set_id = @asset_set_id)),
        DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
	    WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlHLarge' AND D.name = 'Root Management' AND C.alternative_id = @alternative_id
      SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
      EXEC SP_STATUS_MESSAGE @statusMessage
	  END
	ELSE
	  EXEC SP_STATUS_MESSAGE 'H large root drivers do not apply (@LargeRootDiameterIn >= @LargeDiameterIn'

    -- Insert H large root large pipe drivers
    EXEC SP_STATUS_MESSAGE 'Inserting H large root large pipe drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM DRIVERS_LARGE_ROOT_LARGE_PIPE_COMPKEYS_FOR_PROCESSING A INNER JOIN SpecialRoot B ON ((A.COMPKEY = B.COMPKEY) AND (B.asset_set_id = @asset_set_id)),
        DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlHLarge' AND D.name = 'Root Management' AND C.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    -- Insert M large root drivers
	--@LargeRootXORLargePipeCompKeys
	IF @LargeRootDiameterIn < @LargeDiameterIn
	  BEGIN
      EXEC SP_STATUS_MESSAGE 'Inserting M large root drivers'
      INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
        SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
        FROM DRIVERS_LARGE_ROOT_XOR_LARGE_PIPE_COMPKEYS_FOR_PROCESSING A INNER JOIN SpecialRoot B ON ((A.COMPKEY = B.COMPKEY) AND (B.asset_set_id = @asset_set_id)),
          DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
        WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlMLarge' AND D.name = 'Root Management' AND C.alternative_id = @alternative_id
      SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
      EXEC SP_STATUS_MESSAGE @statusMessage
	  END
	ELSE
	  EXEC SP_STATUS_MESSAGE 'M large root drivers do not apply (@LargeRootDiameterIn >= @LargeDiameterIn'

    -- Insert M large root large pipe drivers
    EXEC SP_STATUS_MESSAGE 'Inserting M large root large pipe drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM DRIVERS_LARGE_ROOT_LARGE_PIPE_COMPKEYS_FOR_PROCESSING A INNER JOIN SpecialRoot B ON ((A.COMPKEY = B.COMPKEY) AND (B.asset_set_id = @asset_set_id)),
        DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlMLarge' AND D.name = 'Root Management' AND C.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    -- Insert H small root drivers
    EXEC SP_STATUS_MESSAGE 'Inserting H small root drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM DRIVERS_SMALL_ROOT_COMPKEYS_FOR_PROCESSING A INNER JOIN SpecialRoot B ON ((A.COMPKEY = B.COMPKEY) AND (B.asset_set_id = @asset_set_id)),
        DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('H') AND C.name = 'RootControlH' AND D.name = 'Root Management' AND C.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    -- Insert M small root drivers
    EXEC SP_STATUS_MESSAGE 'Inserting M small root drivers'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM DRIVERS_SMALL_ROOT_COMPKEYS_FOR_PROCESSING A INNER JOIN SpecialRoot B ON ((A.COMPKEY = B.COMPKEY) AND (B.asset_set_id = @asset_set_id)),
        DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id)
      WHERE B.ROOTPROB IN ('M') AND C.name = 'RootControlM' AND D.name = 'Root Management' AND C.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    ----------------------------------------------------------------------------------------------
    -- Cleaning Activities
    ----------------------------------------------------------------------------------------------

    -- Insert normal cleaning PM drivers
    EXEC SP_STATUS_MESSAGE 'Inserting normal cleaning PM drivers (non-large)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT compkey, driver_type_id, GETDATE(), 'System', @alternative_id 
      FROM DRIVERS_SMALL_COMPKEYS_FOR_PROCESSING, DRIVER_TYPES
      WHERE [DRIVER_TYPES].name = 'PMFaster' AND alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    -- Insert Accelerated drivers
    EXEC SP_STATUS_MESSAGE 'Inserting Accelerated drivers (non-large)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, override_frequency_years, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, B.frequency_years, GETDATE(), 'System', @alternative_id
      FROM DRIVERS_SMALL_COMPKEYS_FOR_PROCESSING A INNER JOIN ACCELERATED_CLEANINGS B ON (A.COMPKEY = B.compkey), DRIVER_TYPES C
      WHERE C.name = 'AcceleratedArea' AND alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Inserting Accelerated drivers (large)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, override_frequency_years, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, B.frequency_years, GETDATE(), 'System', @alternative_id
      FROM DRIVERS_LARGE_COMPKEYS_FOR_PROCESSING A INNER JOIN ACCELERATED_CLEANINGS B ON (A.COMPKEY = B.compkey), DRIVER_TYPES C
      WHERE C.name = 'AcceleratedAreaLarge' AND alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    -- Insert Tractive Force drivers
    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers sanitary (VH)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM (DRIVERS_SMALL_TRACTIVE_SANITARY_COMPKEYS_FOR_PROCESSING A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VH' AND D.name = 'TractiveForcesSanVH' AND D.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers sanitary (H)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM (DRIVERS_SMALL_TRACTIVE_SANITARY_COMPKEYS_FOR_PROCESSING A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'H' AND D.name = 'TractiveForcesSanH' AND D.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers sanitary (M)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM (DRIVERS_SMALL_TRACTIVE_SANITARY_COMPKEYS_FOR_PROCESSING A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'M' AND D.name = 'TractiveForcesSanM' AND D.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers sanitary (L)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM (DRIVERS_SMALL_TRACTIVE_SANITARY_COMPKEYS_FOR_PROCESSING A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'L' AND D.name = 'TractiveForcesSanL' AND D.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers sanitary (VL)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM (DRIVERS_SMALL_TRACTIVE_SANITARY_COMPKEYS_FOR_PROCESSING A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VL' AND D.name = 'TractiveForcesSanVL' AND D.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers combo (VH)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM (DRIVERS_SMALL_TRACTIVE_COMBO_COMPKEYS_FOR_PROCESSING A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VH' AND D.name = 'TractiveForcesCmbVH' AND D.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers combo (H)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM (DRIVERS_SMALL_TRACTIVE_COMBO_COMPKEYS_FOR_PROCESSING A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'H' AND D.name = 'TractiveForcesCmbH' AND D.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers combo (M)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM (DRIVERS_SMALL_TRACTIVE_COMBO_COMPKEYS_FOR_PROCESSING A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'M' AND D.name = 'TractiveForcesCmbM' AND D.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers combo (L)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM (DRIVERS_SMALL_TRACTIVE_COMBO_COMPKEYS_FOR_PROCESSING A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'L' AND D.name = 'TractiveForcesCmbL' AND D.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers combo (VL)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM (DRIVERS_SMALL_TRACTIVE_COMBO_COMPKEYS_FOR_PROCESSING A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VL' AND D.name = 'TractiveForcesCmbVL' AND D.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers large (Large VH)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM (DRIVERS_LARGE_TRACTIVE_COMPKEYS_FOR_PROCESSING A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VH' AND D.name = 'TractiveForcesVHLarge' AND D.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers large (Large H)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM (DRIVERS_LARGE_TRACTIVE_COMPKEYS_FOR_PROCESSING A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'H' AND D.name = 'TractiveForcesHLarge' AND D.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers large (Large M)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM (DRIVERS_LARGE_TRACTIVE_COMPKEYS_FOR_PROCESSING A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'M' AND D.name = 'TractiveForcesMLarge' AND D.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers large (Large L)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM (DRIVERS_LARGE_TRACTIVE_COMPKEYS_FOR_PROCESSING A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'L' AND D.name = 'TractiveForcesLLarge' AND D.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'Inserting Tractive Force drivers large (Large VL)'
    INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id)
      SELECT A.compkey, driver_type_id, GETDATE(), 'System', @alternative_id
      FROM (DRIVERS_LARGE_TRACTIVE_COMPKEYS_FOR_PROCESSING A INNER JOIN TRACTIVE_FORCE_MODEL_INPUTS B ON (A.COMPKEY = B.compkey)) INNER JOIN TRACTIVE_FORCE_GRADES C ON(B.particle_size_mm <= C.max_particle_size_mm AND B.particle_size_mm >= C.min_particle_size_mm), DRIVER_TYPES D
      WHERE C.grade = 'VL' AND D.name = 'TractiveForcesVLLarge' AND D.alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    -- Delete PM cleanings with tractive forces L or VL, cmb or san, non-large

    IF @override_cleaning_PM_for_small_size_low_tractive_force = 'TRUE'
    BEGIN
      DECLARE @PMFasterDriverTypeId INT
      SELECT @PMFasterDriverTypeId = driver_type_id FROM DRIVER_TYPES WHERE name = 'PMFaster' AND alternative_id = @alternative_id
      DECLARE @SanTFLDriverTypeID INT
      SELECT @SanTFLDriverTypeID = driver_type_id FROM DRIVER_TYPES WHERE name = 'TractiveForcesSanL' AND alternative_id = @alternative_id
      DECLARE @SanTFVLDriverTypeID INT
      SELECT @SanTFVLDriverTypeID = driver_type_id FROM DRIVER_TYPES WHERE name = 'TractiveForcesSanVL' AND alternative_id = @alternative_id
      DECLARE @ComboTFLDriverTypeID INT
      SELECT @ComboTFLDriverTypeID = driver_type_id FROM DRIVER_TYPES WHERE name = 'TractiveForcesCmbL' AND alternative_id = @alternative_id
      DECLARE @ComboTFVLDriverTypeID INT
      SELECT @ComboTFVLDriverTypeID = driver_type_id FROM DRIVER_TYPES WHERE name = 'TractiveForcesCmbVL' AND alternative_id = @alternative_id

      DELETE FROM DRIVERS WHERE (alternative_id = @alternative_id) AND (compkey in (SELECT A.compkey FROM DRIVERS_SMALL_TRACTIVE_COMBO_COMPKEYS_FOR_PROCESSING A INNER JOIN DRIVERS B ON (A.compkey = B.compkey AND B.alternative_id = @alternative_id AND B.driver_type_id IN (@ComboTFLDriverTypeID, @ComboTFVLDriverTypeID)))) AND driver_type_id = @PMFasterDriverTypeId
      SET @statusMessage = 'Deleted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' combo cleaning records - override PM with tractive'
      EXEC SP_STATUS_MESSAGE @statusMessage

      DELETE FROM DRIVERS WHERE (alternative_id = @alternative_id) AND (compkey in (SELECT A.compkey FROM DRIVERS_SMALL_TRACTIVE_SANITARY_COMPKEYS_FOR_PROCESSING A INNER JOIN DRIVERS B ON (A.compkey = B.compkey AND B.alternative_id = @alternative_id AND B.driver_type_id IN (@SanTFLDriverTypeID, @SanTFVLDriverTypeID)))) AND driver_type_id = @PMFasterDriverTypeId
      SET @statusMessage = 'Deleted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' sanitary cleaning records - override PM with tractive'
      EXEC SP_STATUS_MESSAGE @statusMessage
    END

    -- Delete Grade 5 Cleanings
    EXEC SP_STATUS_MESSAGE 'Deleting Grade 5 Cleanings'
    DELETE FROM [DRIVERS]
    WHERE driver_id IN
      (
        SELECT driver_id
        FROM ((DRIVERS A INNER JOIN ASSETS B ON (A.compkey = B.COMPKEY)) INNER JOIN DRIVER_TYPES C ON (A.driver_type_id = C.driver_type_id)) INNER JOIN ACTIVITY_TYPES D ON (D.activity_type_id = C.activity_type_id)
        WHERE (B.structural_grade = 5 AND (D.name = 'Cleaning')) AND C.alternative_id = @alternative_id
      )
      AND alternative_id = @alternative_id
    SET @statusMessage = 'Inserted ' + CONVERT(VARCHAR(10), @@ROWCOUNT) + ' records'
    EXEC SP_STATUS_MESSAGE @statusMessage

    EXEC SP_STATUS_MESSAGE 'End SP_FILL_DRIVERS'
END