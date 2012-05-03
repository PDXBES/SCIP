CREATE PROCEDURE [dbo].[SP_FILL_LOOKUPS]
AS
BEGIN
  TRUNCATE TABLE [SCIP].[dbo].[BASIN_TYPES];
  INSERT INTO BASIN_TYPES VALUES
    ('A','Abandoned/Nonfunc');
  INSERT INTO BASIN_TYPES VALUES
    ('C','Combined Basin');
  INSERT INTO BASIN_TYPES VALUES
    ('S','Sanitary Basin');
  INSERT INTO BASIN_TYPES VALUES
    ('I','Interceptor');
  INSERT INTO BASIN_TYPES VALUES
    ('T','Tunnel/Consolidation');

  TRUNCATE TABLE [SCIP].[dbo].[BASINS];
  INSERT INTO BASINS VALUES
    ('ALB','C','ALBINA');
  INSERT INTO BASINS VALUES
    ('ALD','C','ALDER');
  INSERT INTO BASINS VALUES
    ('BAY','C','BAYARD');
  INSERT INTO BASINS VALUES
    ('BCC','T','BCC');
  INSERT INTO BASINS VALUES
    ('BAL','C','BALCH COMB');
  INSERT INTO BASINS VALUES
    ('BEE','C','BEECH ESSX');
  INSERT INTO BASINS VALUES
    ('CAL','C','CALIFORNIA');
  INSERT INTO BASINS VALUES
    ('CAR','C','CAROLINA');
  INSERT INTO BASINS VALUES
    ('CBI','I','COL BL INT');
  INSERT INTO BASINS VALUES
    ('CBX','S','CBD DRAIN');
  INSERT INTO BASINS VALUES
    ('CBD','C','CBD');
  INSERT INTO BASINS VALUES
    ('CHA','C','CHAUTAUQUA');
  INSERT INTO BASINS VALUES
    ('COL','S','COLUMBIA');
  INSERT INTO BASINS VALUES
    ('CSC','T','CSCC');
  INSERT INTO BASINS VALUES
    ('DIV','C','DIVISION');
  INSERT INTO BASINS VALUES
    ('ECI','I','EC INT');
  INSERT INTO BASINS VALUES
    ('EST','T','EST');
  INSERT INTO BASINS VALUES
    ('FAN','S','FANNO SAN');
  INSERT INTO BASINS VALUES
    ('FAI','I','FANNO INT');
  INSERT INTO BASINS VALUES
    ('FEN','C','FENWICK');
  INSERT INTO BASINS VALUES
    ('FIS','C','FISKE');
  INSERT INTO BASINS VALUES
    ('FRE','C','FREMONT');
  INSERT INTO BASINS VALUES
    ('GHR','S','GLEN HARBR');
  INSERT INTO BASINS VALUES
    ('GUI','S','GUILDS LK');
  INSERT INTO BASINS VALUES
    ('HAY','S','HAYDEN SAN');
  INSERT INTO BASINS VALUES
    ('HOL','C','HOLLADAY');
  INSERT INTO BASINS VALUES
    ('INS','C','INSLEY');
  INSERT INTO BASINS VALUES
    ('INV','S','INVERNESS');
  INSERT INTO BASINS VALUES
    ('JCK','S','JOHNCK SAN');
  INSERT INTO BASINS VALUES
    ('JFX','C','JEFFERSON');
  INSERT INTO BASINS VALUES
    ('KEN','C','KENTON');
  INSERT INTO BASINS VALUES
    ('LE1','C','LENTS 1');
  INSERT INTO BASINS VALUES
    ('LE2','C','LENTS 2');
  INSERT INTO BASINS VALUES
    ('LIN','C','LINNTON');
  INSERT INTO BASINS VALUES
    ('LII','I','LINNTN INT');
  INSERT INTO BASINS VALUES
    ('LOW','C','LOWELL');
  INSERT INTO BASINS VALUES
    ('LOI','I','LOMBRD INT');
  INSERT INTO BASINS VALUES
    ('MET','S','METZGER');
  INSERT INTO BASINS VALUES
    ('MIL','C','MILL');
  INSERT INTO BASINS VALUES
    ('MIS','S','MILL SAN');
  INSERT INTO BASINS VALUES
    ('N13','C','13TH AVE');
  INSERT INTO BASINS VALUES
    ('NIC','C','NICOLAI');
  INSERT INTO BASINS VALUES
    ('NUL','A',' ');
  INSERT INTO BASINS VALUES
    ('ABA','A','ABANDONED');
  INSERT INTO BASINS VALUES
    ('OAK','C','OAK');
  INSERT INTO BASINS VALUES
    ('ORE','C','OREGONIAN');
  INSERT INTO BASINS VALUES
    ('OSW','C','OSWEGO');
  INSERT INTO BASINS VALUES
    ('PE1','S','PEN DRA 1');
  INSERT INTO BASINS VALUES
    ('PRG','S','PEN/RIVER');
  INSERT INTO BASINS VALUES
    ('RGI','I','RIVERG INT');
  INSERT INTO BASINS VALUES
    ('RVW','S','RIVERVIEW');
  INSERT INTO BASINS VALUES
    ('RIV','C','RIVERS COM');
  INSERT INTO BASINS VALUES
    ('STJ','C','STJOHN COM');
  INSERT INTO BASINS VALUES
    ('SEL','C','SELLWOOD');
  INSERT INTO BASINS VALUES
    ('SHE','C','SHERIDAN');
  INSERT INTO BASINS VALUES
    ('SJI','I','STJOHN INT');
  INSERT INTO BASINS VALUES
    ('SKE','S','SKYL E SAN');
  INSERT INTO BASINS VALUES
    ('SKW','S','SKYL W SAN');
  INSERT INTO BASINS VALUES
    ('SKS','A','SKYL E DRA');
  INSERT INTO BASINS VALUES
    ('SER','I','SE REL INT');
  INSERT INTO BASINS VALUES
    ('SEI','I','SE INT');
  INSERT INTO BASINS VALUES
    ('STA','C','STARK');
  INSERT INTO BASINS VALUES
    ('SWI','I','SW INT');
  INSERT INTO BASINS VALUES
    ('SUL','C','SULLIVAN');
  INSERT INTO BASINS VALUES
    ('SWW','S','SOUTHWEST');
  INSERT INTO BASINS VALUES
    ('SWP','I','SWPI');
  INSERT INTO BASINS VALUES
    ('TGA','C','TAGGART A');
  INSERT INTO BASINS VALUES
    ('TGB','C','TAGGART B');
  INSERT INTO BASINS VALUES
    ('TGC','C','TAGGART C');
  INSERT INTO BASINS VALUES
    ('TGD','C','TAGGART D');
  INSERT INTO BASINS VALUES
    ('TNA','C','TANNER A');
  INSERT INTO BASINS VALUES
    ('TNB','C','TANNER B');
  INSERT INTO BASINS VALUES
    ('TRI','I','TRYON INT');
  INSERT INTO BASINS VALUES
    ('TRY','S','TRYON SAN');
  INSERT INTO BASINS VALUES
    ('VAN','C','VANCOUVER');
  INSERT INTO BASINS VALUES
    ('WCI','I','WC INT');
  INSERT INTO BASINS VALUES
    ('WHE','C','WHEELER');
  INSERT INTO BASINS VALUES
    ('WII','I','WILL INT');
  INSERT INTO BASINS VALUES
    ('WOO','C','WOODS');
  INSERT INTO BASINS VALUES
    ('WST','T','WST');

  TRUNCATE TABLE [SCIP].[dbo].[ACTIVITY_TYPES];
  SET IDENTITY_INSERT ACTIVITY_TYPES ON;
  INSERT INTO ACTIVITY_TYPES ([activity_type_id], [name], [description]) VALUES
    (1,'Inspection', 'CCTV inspections');
  INSERT INTO ACTIVITY_TYPES ([activity_type_id], [name], [description]) VALUES
    (2,'Root Management', 'Clearing of pipes for roots');
  INSERT INTO ACTIVITY_TYPES ([activity_type_id], [name], [description]) VALUES
    (3,'Cleaning', 'Sewer cleaning');
  SET IDENTITY_INSERT ACTIVITY_TYPES OFF;

  TRUNCATE TABLE [SCIP].[dbo].[ALTERNATIVES];
  SET IDENTITY_INSERT ALTERNATIVES ON;
  INSERT INTO ALTERNATIVES ([alternative_id], [name], [description]) VALUES
    (1, 'Current', NULL);
  SET IDENTITY_INSERT ALTERNATIVES OFF;

  TRUNCATE TABLE [SCIP].[dbo].[DRIVER_TYPES];
  SET IDENTITY_INSERT DRIVER_TYPES ON;
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (1,1,'PM',NULL,0.80,12,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (2,1,'PMLarge',NULL,2.00,12,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (3,1,'RootControlH',NULL,1.25,6,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (4,1,'RootControlM',NULL,1.25,9,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (5,1,'Condition',NULL,0.80,12,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (6,1,'ConditionLarge',NULL,2.00,12,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (7,2,'RootControlH',NULL,1.20,2,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (8,2,'RootControlHLarge',NULL,2.93,3,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (9,2,'RootControlM',NULL,1.20,3,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (10,2,'RootControlMLarge',NULL,2.93,3,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (11,3,'PM',NULL,0.85,6,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (12,3,'AcceleratedFOGApartments',NULL,1.73,5,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (13,3,'AcceleratedFOGRestaurants',NULL,1.73,5,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (14,3,'AcceleratedSediment',NULL,1.73,5,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (15,3,'AcceleratedSag',NULL,1.73,5,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (16,3,'AcceleratedPump',NULL,1.73,5,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (17,3,'TractiveForces',NULL,1.73,5,1);
  INSERT INTO DRIVER_TYPES ([driver_type_id], [activity_type_id], [name], [description], [default_cost_per_ft], [default_frequency_years], [alternative_id]) VALUES
    (18,3,'TractiveForcesLarge',NULL,1.73,5,1);
  SET IDENTITY_INSERT DRIVER_TYPES OFF;

END