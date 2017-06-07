CREATE TABLE [dbo].[ASSETS] (
    [asset_id]                  INT           IDENTITY (1, 1) NOT NULL,
    [COMPKEY]                   INT           NOT NULL,
    [length_ft]                 INT           NOT NULL,
    [diamWidth_inches]          FLOAT (53)    NOT NULL,
    [height_inches]             FLOAT (53)    NULL,
    [basin_id]                  VARCHAR (3)   NOT NULL,
    [district_id]               VARCHAR (4)   NOT NULL,
    [unit_type]                 VARCHAR (10)  NOT NULL,
    [last_inspection_date]      DATETIME      NULL,
    [last_root_management_date] DATETIME      NULL,
    [last_root_inspection_date] DATETIME      NULL,
    [last_cleaning_date]        DATETIME      NULL,
    [structural_grade]          INT           NULL,
    [asset_set_id]              INT           NOT NULL,
    [unitid]                    NVARCHAR (50) NULL,
    [unitid2]                   NVARCHAR (50) NULL,
    [pipe_age_years]            INT           NULL,
    [material]                  NVARCHAR (50) NULL,
    [install_date]              DATETIME      NULL,
    CONSTRAINT [PK_ASSETS] PRIMARY KEY CLUSTERED ([asset_id] ASC) WITH (FILLFACTOR = 90)
);



