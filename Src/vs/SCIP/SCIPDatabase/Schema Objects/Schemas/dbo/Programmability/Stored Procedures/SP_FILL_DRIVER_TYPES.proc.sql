CREATE PROCEDURE [dbo].[SP_FILL_DRIVER_TYPES]
	@alternative_id INT = 1
AS
  SET NOCOUNT ON

  DECLARE @statusMessage VARCHAR(200)
  SET @statusMessage = 'Begin SP_FILL_DRIVER_TYPES, alternative_id = ' + CONVERT(VARCHAR(10), @alternative_id)
  EXEC SP_STATUS_MESSAGE @statusMessage

  DELETE FROM DRIVER_TYPES WHERE alternative_id = @alternative_id

  DECLARE @inspection_type_id INT
  SELECT @inspection_type_id = activity_type_id FROM ACTIVITY_TYPES WHERE name = 'Inspection'
  DECLARE @root_type_id INT
  SELECT @root_type_id = activity_type_id FROM ACTIVITY_TYPES WHERE name = 'Root Management'
  DECLARE @cleaning_type_id INT
  SELECT @cleaning_type_id = activity_type_id FROM ACTIVITY_TYPES WHERE name = 'Cleaning'

  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@inspection_type_id,'PM','Preventive Maintenance','Preventive Maintenance',0.80,12,@alternative_id,1,'TVSEWS');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@inspection_type_id,'PMLarge','Preventive Maintenance (>36 in)','Preventive Maintenance (>36 in)',2.00,12,@alternative_id,2,'TVSEWS');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@inspection_type_id,'RootControlH','Root Control High','Root Control High',1.25,6,@alternative_id,7,'SPSWTV');
  INSERT INTO DRIVER_TYPES ( [activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@inspection_type_id,'RootControlHLarge','Root Control High (>15 in, <=36 in)','Root Control High (>15 in, <=36 in)',1.25,9,@alternative_id,6,'SPSWTV');
  INSERT INTO DRIVER_TYPES ( [activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@inspection_type_id,'RootControlHLargePipe','Root Control High (>36 in)','Root Control High (>36 in)',2.50,9,@alternative_id,5,'SPSWTV');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@inspection_type_id,'RootControlM','Root Control Medium','Root Control Medium',1.25,9,@alternative_id,10,'SPSWTV');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@inspection_type_id,'RootControlMLarge','Root Control Medium (>15 in, <=36 in)','Root Control Medium (>15 in, <=36 in)',1.25,12,@alternative_id,9,'SPSWTV');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@inspection_type_id,'RootControlMLargePipe','Root Control Medium (>36 in)','Root Control Medium (>36 in)',2.50,12,@alternative_id,8,'SPSWTV');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@inspection_type_id,'Condition','Condition','Condition',0.80,12,@alternative_id,3,'SPSWTV');
  INSERT INTO DRIVER_TYPES ( [activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@inspection_type_id,'ConditionLarge','Condition (>36 in)','Condition (>36 in)',2.00,12,@alternative_id,4,'SPSWTV');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@root_type_id,'RootControlH','Root Control High','Root Control High',1.20,2,@alternative_id,1,'RTCHEM');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@root_type_id,'RootControlHLarge','Root Control High (>15 in)','Root Control High (>15 in)',2.93,3,@alternative_id,2,'RTCHEM');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@root_type_id,'RootControlM','Root Control Medium','Root Control Medium',1.20,3,@alternative_id,3,'RTCHEM');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@root_type_id,'RootControlMLarge','Root Control Medium (>15 in)','Root Control Medium (>15 in)',2.93,3,@alternative_id,4,'RTCHEM');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'PMFaster','Preventive Maintenance','Preventive Maintenance',0.85,6,@alternative_id,1,'SEWCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'AcceleratedArea','Accelerated Area','Accelerated Area',1.73,5,@alternative_id,3,'SPCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'AcceleratedAreaLarge','Accelerated Area (>36 in)','Accelerated Area (>36 in)',50.00,5,@alternative_id,2,'SPCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'TractiveForcesSanVH','Tractive Forces Sanitary Very High','Tractive Forces',1.73,4,@alternative_id,6,'SPCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'TractiveForcesSanH','Tractive Forces Sanitary High','Tractive Forces',1.73,8,@alternative_id,9,'SPCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'TractiveForcesSanM','Tractive Forces Sanitary Medium','Tractive Forces',1.73,12,@alternative_id,12,'SPCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'TractiveForcesSanL','Tractive Forces Sanitary Low','Tractive Forces',1.73,16,@alternative_id,15,'SPCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'TractiveForcesSanVL','Tractive Forces Sanitary Very Low','Tractive Forces',1.73,20,@alternative_id,18,'SPCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'TractiveForcesVHLarge','Tractive Forces Very High (>36 in)','Tractive Forces (>36 in)',50.00,6,@alternative_id,4,'SPCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'TractiveForcesHLarge','Tractive Forces High (>36 in)','Tractive Forces (>36 in)',50.00,12,@alternative_id,7,'SPCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'TractiveForcesMLarge','Tractive Forces Medium (>36 in)','Tractive Forces (>36 in)',50.00,18,@alternative_id,10,'SPCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'TractiveForcesLLarge','Tractive Forces Low (>36 in)','Tractive Forces (>36 in)',50.00,24,@alternative_id,13,'SPCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'TractiveForcesVLLarge','Tractive Forces Very Low (>36 in)','Tractive Forces (>36 in)',50.00,30,@alternative_id,16,'SPCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'TractiveForcesCmbVH','Tractive Forces Combined Very High','Tractive Forces',1.73,2,@alternative_id,5,'SPCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'TractiveForcesCmbH','Tractive Forces Combined High','Tractive Forces',1.73,4,@alternative_id,8,'SPCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'TractiveForcesCmbM','Tractive Forces Combined Medium','Tractive Forces',1.73,6,@alternative_id,11,'SPCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'TractiveForcesCmbL','Tractive Forces Combined Low','Tractive Forces',1.73,8,@alternative_id,14,'SPCLN');
  INSERT INTO DRIVER_TYPES ([activity_type_id], [name], [description], [reporting_category], [default_cost_per_ft], [default_frequency_years], [alternative_id], [rank], [hansen_activity_code]) VALUES
    (@cleaning_type_id,'TractiveForcesCmbVL','Tractive Forces Combined Very Low','Tractive Forces',1.73,10,@alternative_id,17,'SPCLN');

  EXEC SP_STATUS_MESSAGE 'End SP_FILL_DRIVER_TYPES'

RETURN 0