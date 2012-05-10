CREATE TABLE [dbo].[DRIVER_TYPES] (
    [driver_type_id]          INT           IDENTITY (1, 1) NOT NULL,
    [activity_type_id]        INT           NOT NULL,
    [name]                    VARCHAR (50)  NOT NULL,
    [description]             VARCHAR (100) NULL,
    [default_cost_per_ft]     MONEY         NOT NULL,
    [default_frequency_years] FLOAT         NOT NULL,
    [rank]                    INT           NOT NULL DEFAULT 1,
    [alternative_id]          INT           NOT NULL
);

