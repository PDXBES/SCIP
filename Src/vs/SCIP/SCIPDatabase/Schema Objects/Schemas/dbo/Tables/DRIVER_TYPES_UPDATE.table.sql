CREATE TABLE [dbo].[DRIVER_TYPES_UPDATE](
    [driver_type_id]          INT           IDENTITY (1, 1) NOT NULL,
    [activity_type_id]        INT           NOT NULL,
    [name]                    VARCHAR (50)  NOT NULL,
    [description]             VARCHAR (100) NULL,
    [hansen_activity_code]    VARCHAR (10)  NULL,
    [default_cost_per_ft]     MONEY         NOT NULL,
    [default_frequency_years] FLOAT         NOT NULL,
    [rank]                    INT           NOT NULL DEFAULT 1,
    [alternative_id]          INT           NOT NULL 
);
