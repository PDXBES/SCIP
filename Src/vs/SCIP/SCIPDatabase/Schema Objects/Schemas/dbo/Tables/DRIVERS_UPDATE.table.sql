CREATE TABLE [dbo].[DRIVERS_UPDATE]
(
    [driver_id]                INT          IDENTITY (1,1) NOT NULL,
    [driver_type_id]           INT          NOT NULL,
    [compkey]                  INT          NOT NULL,
    [override_cost_per_ft]     MONEY        NULL,
    [override_frequency_years] FLOAT        NULL,
    [alternative_id]           INT          NOT NULL,
    [updated_by]               VARCHAR (20) NULL,
    [update_date]              DATETIME     NULL
)
