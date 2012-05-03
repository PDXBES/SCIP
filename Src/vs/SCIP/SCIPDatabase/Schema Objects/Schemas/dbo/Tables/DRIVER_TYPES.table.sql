CREATE TABLE [dbo].[DRIVER_TYPES] (
    [driver_type_id]          INT           IDENTITY (1, 1) NOT NULL,
    [activity_type_id]        INT           NULL,
    [name]                    VARCHAR (50)  NULL,
    [description]             VARCHAR (100) NULL,
    [default_cost_per_ft]     MONEY         NULL,
    [default_frequency_years] FLOAT         NULL,
    [alternative_id]          INT           NULL
);

