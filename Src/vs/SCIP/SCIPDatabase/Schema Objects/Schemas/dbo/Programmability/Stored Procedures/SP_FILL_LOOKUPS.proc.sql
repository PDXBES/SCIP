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
    ('ALB','C','ALBINA','Albina');
  INSERT INTO BASINS VALUES
    ('ALD','C','ALDER','Alder');
  INSERT INTO BASINS VALUES
    ('BAY','C','BAYARD','Bayard');
  INSERT INTO BASINS VALUES
    ('BCC','T','BCC','Balch Consolidation Conduit');
  INSERT INTO BASINS VALUES
    ('BAL','C','BALCH COMB','Balch');
  INSERT INTO BASINS VALUES
    ('BEE','C','BEECH ESSX','Beech/Essex');
  INSERT INTO BASINS VALUES
    ('CAL','C','CALIFORNIA','California');
  INSERT INTO BASINS VALUES
    ('CAR','C','CAROLINA','Carolina');
  INSERT INTO BASINS VALUES
    ('CBI','I','COL BL INT','Columbia Blvd Interceptor');
  INSERT INTO BASINS VALUES
    ('CBX','S','CBD DRAIN','CBD Drainage');
  INSERT INTO BASINS VALUES
    ('CBD','C','CBD','Central Business District');
  INSERT INTO BASINS VALUES
    ('CHA','C','CHAUTAUQUA','Chautauqua');
  INSERT INTO BASINS VALUES
    ('COL','S','COLUMBIA','Columbia');
  INSERT INTO BASINS VALUES
    ('CSC','T','CSCC','CSCC');
  INSERT INTO BASINS VALUES
    ('DIV','C','DIVISION','Division');
  INSERT INTO BASINS VALUES
    ('ECI','I','EC INT','East-Central Interceptor');
  INSERT INTO BASINS VALUES
    ('EST','T','EST','ESCSO Tunnel');
  INSERT INTO BASINS VALUES
    ('FAN','S','FANNO SAN','Fanno');
  INSERT INTO BASINS VALUES
    ('FAI','I','FANNO INT','Fanno Interceptor');
  INSERT INTO BASINS VALUES
    ('FEN','C','FENWICK','Fenwick');
  INSERT INTO BASINS VALUES
    ('FIS','C','FISKE','Fiske');
  INSERT INTO BASINS VALUES
    ('FRE','C','FREMONT','Fremont');
  INSERT INTO BASINS VALUES
    ('GHR','S','GLEN HARBR','Glen Harbor');
  INSERT INTO BASINS VALUES
    ('GUI','S','GUILDS LK','Guilds Lake');
  INSERT INTO BASINS VALUES
    ('HAY','S','HAYDEN SAN','Hayden Island');
  INSERT INTO BASINS VALUES
    ('HOL','C','HOLLADAY','Holladay');
  INSERT INTO BASINS VALUES
    ('INS','C','INSLEY','Insley');
  INSERT INTO BASINS VALUES
    ('INV','S','INVERNESS','Inverness');
  INSERT INTO BASINS VALUES
    ('JCK','S','JOHNCK SAN','Johnson Creek');
  INSERT INTO BASINS VALUES
    ('JFX','C','JEFFERSON','Jefferson');
  INSERT INTO BASINS VALUES
    ('KEN','C','KENTON','Kenton');
  INSERT INTO BASINS VALUES
    ('LE1','C','LENTS 1','Western Lents');
  INSERT INTO BASINS VALUES
    ('LE2','C','LENTS 2','Lents');
  INSERT INTO BASINS VALUES
    ('LIN','C','LINNTON','Linnton');
  INSERT INTO BASINS VALUES
    ('LII','I','LINNTN INT','Linnton Interceptor');
  INSERT INTO BASINS VALUES
    ('LOW','C','LOWELL','Lowell');
  INSERT INTO BASINS VALUES
    ('LOI','I','LOMBRD INT','Lombard Interceptor');
  INSERT INTO BASINS VALUES
    ('MET','S','METZGER','Metzger');
  INSERT INTO BASINS VALUES
    ('MIL','C','MILL','Mill');
  INSERT INTO BASINS VALUES
    ('MIS','S','MILL SAN','Mill Sanitary');
  INSERT INTO BASINS VALUES
    ('N13','C','13TH AVE','NE 13th Avenue');
  INSERT INTO BASINS VALUES
    ('NIC','C','NICOLAI','Nicolai');
  INSERT INTO BASINS VALUES
    ('NUL','A',' ','Null');
  INSERT INTO BASINS VALUES
    ('ABA','A','ABANDONED','Abandoned');
  INSERT INTO BASINS VALUES
    ('OAK','C','OAK','Oak');
  INSERT INTO BASINS VALUES
    ('ORE','C','OREGONIAN','Oregonian');
  INSERT INTO BASINS VALUES
    ('OSW','C','OSWEGO','Oswego');
  INSERT INTO BASINS VALUES
    ('PE1','S','PEN DRA 1','Peninsula District 1');
  INSERT INTO BASINS VALUES
    ('PRG','S','PEN/RIVER','Peninsula/Rivergate');
  INSERT INTO BASINS VALUES
    ('RGI','I','RIVERG INT','Rivergate Interceptor');
  INSERT INTO BASINS VALUES
    ('RVW','S','RIVERVIEW','Riverview');
  INSERT INTO BASINS VALUES
    ('RIV','C','RIVERS COM','Riverside');
  INSERT INTO BASINS VALUES
    ('STJ','C','STJOHN COM','St. Johns');
  INSERT INTO BASINS VALUES
    ('SEL','C','SELLWOOD','Sellwood');
  INSERT INTO BASINS VALUES
    ('SHE','C','SHERIDAN','Sheridan');
  INSERT INTO BASINS VALUES
    ('SJI','I','STJOHN INT','St. Johns Interceptor');
  INSERT INTO BASINS VALUES
    ('SKE','S','SKYL E SAN','Skyline East');
  INSERT INTO BASINS VALUES
    ('SKW','S','SKYL W SAN','Skyline West');
  INSERT INTO BASINS VALUES
    ('SKS','A','SKYL E DRA','Skyline East Drainage');
  INSERT INTO BASINS VALUES
    ('SER','I','SE REL INT','SE Relieving Interceptor');
  INSERT INTO BASINS VALUES
    ('SEI','I','SE INT','SE Interceptor');
  INSERT INTO BASINS VALUES
    ('STA','C','STARK','Stark');
  INSERT INTO BASINS VALUES
    ('SWI','I','SW INT','SW Interceptor');
  INSERT INTO BASINS VALUES
    ('SUL','C','SULLIVAN','Sullivan');
  INSERT INTO BASINS VALUES
    ('SWW','S','SOUTHWEST','Southwest');
  INSERT INTO BASINS VALUES
    ('SWP','I','SWPI','SW Parallel Interceptor');
  INSERT INTO BASINS VALUES
    ('TGA','C','TAGGART A','Taggart A');
  INSERT INTO BASINS VALUES
    ('TGB','C','TAGGART B','Taggart B');
  INSERT INTO BASINS VALUES
    ('TGC','C','TAGGART C','Taggart C');
  INSERT INTO BASINS VALUES
    ('TGD','C','TAGGART D','Taggart D');
  INSERT INTO BASINS VALUES
    ('TNA','C','TANNER A','Tanner A');
  INSERT INTO BASINS VALUES
    ('TNB','C','TANNER B','Tanner B');
  INSERT INTO BASINS VALUES
    ('TRI','I','TRYON INT','Tryon Interceptor');
  INSERT INTO BASINS VALUES
    ('TRY','S','TRYON SAN','Tryon');
  INSERT INTO BASINS VALUES
    ('VAN','C','VANCOUVER','Vancouver');
  INSERT INTO BASINS VALUES
    ('WCI','I','WC INT','West-Central Interceptor');
  INSERT INTO BASINS VALUES
    ('WHE','C','WHEELER','Wheeler');
  INSERT INTO BASINS VALUES
    ('WII','I','WILL INT','Willamette Interceptor');
  INSERT INTO BASINS VALUES
    ('WOO','C','WOODS','Woods');
  INSERT INTO BASINS VALUES
    ('WST','T','WST','WSCSO Tunnel');

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