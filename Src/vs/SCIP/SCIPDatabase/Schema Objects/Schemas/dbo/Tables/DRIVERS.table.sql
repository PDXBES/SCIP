CREATE TABLE [dbo].[DRIVERS] (
    [driver_id]                INT          NULL,
    [driver_type_id]           INT          NULL,
    [compkey]                  INT          NULL,
    [override_cost_per_ft]     MONEY        NULL,
    [override_frequency_years] FLOAT        NULL,
    [alternative_id]           INT          NULL,
    [updated_by]               VARCHAR (20) NULL,
    [update_date]              DATETIME     NULL
);

