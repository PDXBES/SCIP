CREATE PROCEDURE [dbo].[SPTEST_FILL_DRIVERS]
(
  @alternative_id INT = 1
)
AS
BEGIN
    SET NOCOUNT ON
  DECLARE @statusMessage VARCHAR(200)
  DECLARE @queryStatement VARCHAR(2000)
  SET @statusMessage = 'Begin SP_FILL_DRIVERS, alternative_id = ' + CONVERT(VARCHAR(10), @alternative_id)
  EXEC SP_STATUS_MESSAGE @statusMessage

  DELETE FROM DRIVERS WHERE alternative_id = @alternative_id

  --Anything equal to or greater than LargeDiameterIn is considered a large pipe
  DECLARE @LargeDiameterIn float
  SET @LargeDiameterIn = 36.01
  
  DECLARE @LowerBounds float
  DECLARE @UpperBounds float
  DECLARE @UpperBoundsSign varchar(2)
  DECLARE @LowerBoundsSign varchar(2)
  DECLARE @SizeInterval varchar(200)
  DECLARE @Activity_Type_id int
  DECLARE @DriverType int
  DECLARE @Interval_ID int 
  DECLARE @JoinTable varchar(100)
  DECLARE @JoinColumn varchar(50)
  DECLARE @JoinValue varchar(100)
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
  
  --The Upper and Lower bounds are the size in inches
  --That a pipe would have to fall between in order to
  --Be placed in the table.
  SET @LowerBounds = 0
  SET @UpperBounds = 1000000
  SET @LowerBoundsSign = '>'
  SET @UpperBoundsSign = '>='
  SET @JoinTable = ''
  SET @JoinColumn = ''
  --JoinValue, if the datatype to be joined with is a string, MUST be enclosed with single quotes (').
  SET @JoinValue = ''

  --So our table would hold values that looked like this: ([0,>][7,>][10, >=][1000000, >])
  --and this would mean that set one would be those values greater than or equal to 
  --zero and less than or equal to 7, set two would be those values greater than 7 and 
  --less than 10, set three would be those values greater than or equal to 10 and 
  --less than or equal to 1000000.

  --Signs can only be GT or GTE.  This reduces the liklihood of someone having a 
  --logic problem.
  --Entries into this table should not need to be entered in the correct order, but
  --they should be queried in the correct order and presented to the user in the correct order.
  
  --DELETE all previous _COMPKEYS_FOR_PROCESSING tables
  DECLARE @tableName  varchar(128) 
  DECLARE @cmd varchar(1000) 
  DECLARE cmds cursor for 
    SELECT 'DROP TABLE [' + Table_Name + ']' 
    FROM   INFORMATION_SCHEMA.TABLES 
    WHERE  Table_Name like '%_COMPKEYS_FOR_PROCESSING' 
      OPEN cmds
      WHILE 1=1 
        BEGIN 
          FETCH cmds INTO @cmd 
          IF @@fetch_status != 0 BREAK 
            EXEC(@cmd) 
        END 
      CLOSE cmds 
  DEALLOCATE cmds
  
  /*
  DECLARE @Driver_Type_ID int 
  SET ROWCOUNT 0
  SELECT DRIVER_TYPES.Driver_type_id, 
         DRIVER_TYPES.activity_type_id, 
         DRIVER_TYPES.interval_id, 
         DRIVER_TYPES.Join_Table,
         DRIVER_TYPES.Join_Column,
         DRIVER_TYPES.Join_Value INTO #mytemp 
  FROM DRIVER_TYPES INNER JOIN Size_Intervals ON DRIVER_TYPES.Interval_ID = Size_Intervals.Interval_ID
  WHERE alternative_id = @alternative_id

  SET ROWCOUNT 1

  SELECT @Driver_Type_ID = driver_type_id, 
         @Interval_ID = interval_id,
         @Activity_type_id = activity_type_id,
         @JoinTable = Join_Table,
         @JoinColumn = Join_Column,
         @JoinValue = Join_Value
  FROM   #mytemp
  
  WHILE @@rowcount <> 0
  BEGIN
    SET ROWCOUNT 0
    
    --Get the pipe size restrictions (even an unrestricted pipe should have
    --size restrictions of SIZE>=0 AND SIZE <=10000
    SELECT @LowerBounds = IntervalStart, 
           @UpperBounds = IntervalEnd, 
           @LowerBoundsSign = intervalStartSymbol, 
           @UpperBoundsSign = intervalEndSymbol 
    FROM   SIZE_INTERVALS 
    WHERE  interval_ID = @Interval_ID
    
    --Create the table to hold the driver data associated with the 
    --Required pipe size restrictions
    SET @queryStatement = 'CREATE TABLE DRIVERS_' + 
	    CONVERT(varchar(12),@Interval_ID) + 
	    '_' + 
	    CONVERT(varchar(12),@Activity_Type_id) +
	    '_'+ 
	    CONVERT(varchar(12),@Driver_Type_ID) +
		'_COMPKEYS_FOR_PROCESSING ( '+
	    '[compkey] [int] NOT NULL, '+
        'PRIMARY KEY CLUSTERED '+
        '( '+
	    '[compkey] ASC '+
        ')WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] '+
        ') ON [PRIMARY]' 
        
	print @queryStatement
	execute(@queryStatement)	
    
    --This query statement inserts the data to the drivers table we just created
    --that is associated with the required pipe size restrictions
    SET @queryStatement = 
	  'INSERT INTO DRIVERS_' + 
	  CONVERT(varchar(12),@Interval_ID) + '_' + 
	  CONVERT(varchar(12),@Activity_Type_id) +'_'+ 
	  CONVERT(varchar(12),@Driver_Type_ID) +
	  '_COMPKEYS_FOR_PROCESSING SELECT compkey ' +
	  ' FROM [dbo].[ASSETS], DRIVER_TYPES ' +
	  ' WHERE ' +
	  ' (  ( ([dbo].[ASSETS].diamWidth_inches > [dbo].[ASSETS].height_inches OR [dbo].[ASSETS].height_inches IS NULL)' +
	  '      AND ' +
	  '      (  ([dbo].[ASSETS].diamWidth_inches ' + 
	              @LowerBoundsSign + 
	              CONVERT(varchar(12),@LowerBounds) + 
	          ' ) ' +
	          ' AND ' +
	          ' ([dbo].[ASSETS].diamWidth_inches ' + 
	             @UpperBoundsSign + 
	             CONVERT(varchar(12),@UpperBounds) + 
	          ' ) ' +
	       ' ) ' +
	     ' ) ' +
	     ' OR ' +
	     ' ( ([dbo].[ASSETS].height_inches > [dbo].[ASSETS].diamWidth_inches OR [dbo].[ASSETS].diamWidth_inches IS NULL)' +
	       ' AND ' +
	      ' (  ([dbo].[ASSETS].height_inches ' + 
	             @LowerBoundsSign + 
	             CONVERT(varchar(12),@LowerBounds) + 
	          ' ) ' +
	          ' AND ' +
	          ' ([dbo].[ASSETS].height_inches ' + 
	             @UpperBoundsSign + 
	             CONVERT(varchar(12),@UpperBounds) + 
	          ' ) ' +
	       ' ) ' +
	     ' ) ' +
	   ' ) ' +
	  ' AND (asset_set_id = ' + 
	  CONVERT(varchar(12),@asset_set_id) + 
	  ')' +
	  ' AND [DRIVER_TYPES].driver_type_id = ' + 
	  CONVERT(varchar(12),@Driver_Type_ID) + 
	  ' AND alternative_id = ' + 
	  CONVERT(varchar(12),@alternative_id)
	print @queryStatement
	execute(@queryStatement)
	
	--Check to see if we are joining against a table
	IF @JoinTable IS NOT NULL
	  BEGIN
	  --Check to see if the table we are about to join against has an asset_set_id column
	  IF @JoinColumn IS NOT NULL
	    BEGIN
	    IF COL_LENGTH(@JoinTable, 'asset_set_id') IS NOT NULL
		  BEGIN
		  --Create the query string
		  SET @queryStatement = 'INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id) ' +
            'SELECT A.compkey, driver_type_id, GETDATE(), ''System'', ' + CONVERT(varchar(12),@alternative_id) + ' '+
            'FROM (DRIVERS_' + 
	               CONVERT(varchar(12),@Interval_ID) + '_' + 
	               CONVERT(varchar(12),@Activity_Type_id) +'_'+ 
	               CONVERT(varchar(12),@Driver_Type_ID) +
	               '_COMPKEYS_FOR_PROCESSING A '+
            'INNER JOIN ' + @JoinTable +' B ON (A.COMPKEY = B.COMPKEY AND B.asset_set_id = ' + CONVERT(varchar(12),@asset_set_id) + ' '+
                       'DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id) '+
            'WHERE B.' + @JoinColumn  +' IN (' + @JoinValue + ') AND C.driver_type_id = '+CONVERT(varchar(12),@Driver_Type_ID)+
              ' AND D.activity_type_id = '+CONVERT(varchar(12),@Activity_Type_id)+' AND C.alternative_id = ' + CONVERT(varchar(12),@alternative_id) 
    
		  END
	    ELSE
	      BEGIN
	      --Create the query string
		  SET @queryStatement = 'INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id) ' +
            'SELECT A.compkey, driver_type_id, GETDATE(), ''System'', '+ CONVERT(varchar(12),@alternative_id) + ' '+
            'FROM (DRIVERS_' + 
	               CONVERT(varchar(12),@Interval_ID) + '_' + 
	               CONVERT(varchar(12),@Activity_Type_id) +'_'+ 
	               CONVERT(varchar(12),@Driver_Type_ID) +
	               '_COMPKEYS_FOR_PROCESSING A '+
            'INNER JOIN ' + @JoinTable +' B ON A.COMPKEY = B.COMPKEY ), '+
                       'DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id) '+
            'WHERE B.' + @JoinColumn  +' IN (' + @JoinValue + ') AND C.driver_type_id = '+CONVERT(varchar(12),@Driver_Type_ID)+
              ' AND D.activity_type_id = '+CONVERT(varchar(12),@Activity_Type_id)+' AND C.alternative_id = ' + CONVERT(varchar(12),@alternative_id)
	      END
	    END
	  --@JoinColumn is null, so we are just joining with @JoinTable on Compkey
	  ELSE
	    BEGIN
	    IF COL_LENGTH(@JoinTable, 'asset_set_id') IS NOT NULL
		  BEGIN
		  --Create the query string
		  SET @queryStatement = 'INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id) ' +
            'SELECT A.compkey, driver_type_id, GETDATE(), ''System'', ' + CONVERT(varchar(12),@alternative_id) + ' '+
            'FROM (DRIVERS_' + 
	               CONVERT(varchar(12),@Interval_ID) + '_' + 
	               CONVERT(varchar(12),@Activity_Type_id) +'_'+ 
	               CONVERT(varchar(12),@Driver_Type_ID) +
	               '_COMPKEYS_FOR_PROCESSING A '+
            'INNER JOIN ' + @JoinTable +' B ON (A.COMPKEY = B.COMPKEY AND B.asset_set_id = ' + CONVERT(varchar(12),@asset_set_id) + ' '+
                       'DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id) '+
            'WHERE C.driver_type_id = '+CONVERT(varchar(12),@Driver_Type_ID)+
              ' AND D.activity_type_id = '+CONVERT(varchar(12),@Activity_Type_id)+' AND C.alternative_id = ' + CONVERT(varchar(12),@alternative_id) 
    
		  END
	    ELSE
	      BEGIN
	      --Create the query string
		  SET @queryStatement = 'INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id) ' +
            'SELECT A.compkey, driver_type_id, GETDATE(), ''System'', '+ CONVERT(varchar(12),@alternative_id) + ' '+
            'FROM (DRIVERS_' + 
	               CONVERT(varchar(12),@Interval_ID) + '_' + 
	               CONVERT(varchar(12),@Activity_Type_id) +'_'+ 
	               CONVERT(varchar(12),@Driver_Type_ID) +
	               '_COMPKEYS_FOR_PROCESSING A '+
            'INNER JOIN ' + @JoinTable +' B ON A.COMPKEY = B.COMPKEY ), '+
                       'DRIVER_TYPES C INNER JOIN ACTIVITY_TYPES D ON (C.activity_type_id = D.activity_type_id) '+
            'WHERE C.driver_type_id = '+CONVERT(varchar(12),@Driver_Type_ID)+
              ' AND D.activity_type_id = '+CONVERT(varchar(12),@Activity_Type_id)+' AND C.alternative_id = ' + CONVERT(varchar(12),@alternative_id)
	      END
	    END
	  END
	ELSE
	  BEGIN	
	  SET @queryStatement = 'INSERT INTO [DRIVERS] (compkey, driver_type_id, update_date, updated_by, alternative_id) '+
        'SELECT compkey, driver_type_id, GETDATE(), ''System'', ' + CONVERT(varchar(12),@alternative_id) + ' '+
        'FROM DRIVERS_' + 
	             CONVERT(varchar(12),@Interval_ID) + '_' + 
	             CONVERT(varchar(12),@Activity_Type_id) +'_'+ 
	             CONVERT(varchar(12),@Driver_Type_ID) +
	             '_COMPKEYS_FOR_PROCESSING, DRIVER_TYPES '+
        'WHERE C.driver_type_id = '+CONVERT(varchar(12),@Driver_Type_ID)+' AND alternative_id = ' + CONVERT(varchar(12),@alternative_id)
	  END
	

    --Get rid of the row that we were just using
    DELETE #mytemp WHERE @Driver_Type_ID = driver_type_id

    SET ROWCOUNT 1
    
    --Get the variables associated with the next row
    SELECT @Driver_Type_ID = driver_type_id, 
           @activity_type_id = activity_type_id, 
           @Interval_ID = interval_id ,
           @JoinTable = Join_Table,
           @JoinColumn = Join_Column, 
           @JoinValue = Join_Value
    FROM #mytemp
    
  END
  SET ROWCOUNT 0
  
	  
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
    */
END