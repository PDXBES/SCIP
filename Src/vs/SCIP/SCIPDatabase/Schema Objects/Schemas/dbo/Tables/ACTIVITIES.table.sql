CREATE TABLE [dbo].[ACTIVITIES] (
    [activity_id]          INT          NULL,
    [compkey]              INT          NULL,
    [hansen_activity_code] VARCHAR (10) NULL,
    [driver_id]            INT          NULL,
    [activity_date]        DATETIME     NULL,
    [cost]                 MONEY        NULL,
    [activity_type_id]     INT          NULL,
    [alternative_id]       INT          NULL
);

