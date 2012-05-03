CREATE TABLE [dbo].[ASSETS] (
    [COMPKEY]                   INT         NULL,
    [length_ft]                 INT         NULL,
    [diamWidth_inches]          FLOAT       NULL,
    [height_inches]             FLOAT       NULL,
    [basin_id]                  VARCHAR (3) NULL,
    [last_inspection_date]      DATETIME    NULL,
    [last_root_management_date] DATETIME    NULL,
    [last_cleaning_date]        DATETIME    NULL
);

