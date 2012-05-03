CREATE TABLE [dbo].[DRIVER_SUBTYPES] (
    [driver_subtype_id]       INT           IDENTITY (1, 1) NOT NULL,
    [driver_type_id]          INT           NULL,
    [name]                    VARCHAR (20)  NULL,
    [description]             VARCHAR (100) NULL,
    [hansen_activity_code]    VARCHAR (15)  NULL,
    [default_cost_per_ft]     FLOAT         NULL,
    [default_frequency_years] FLOAT         NULL
);

