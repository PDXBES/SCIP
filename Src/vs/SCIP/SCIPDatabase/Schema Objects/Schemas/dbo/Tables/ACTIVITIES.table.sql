CREATE TABLE [dbo].[ACTIVITIES] (
    [activity_id]          INT          IDENTITY(1,1) NOT NULL,
    [compkey]              INT          NOT NULL,
    [hansen_activity_code] VARCHAR (10) NULL,
    [driver_id]            INT          NULL,
    [activity_date]        DATETIME     NOT NULL,
    [cost]                 MONEY        NULL,
    [activity_type_id]     INT          NOT NULL,
    [alternative_id]       INT          NOT NULL
);

