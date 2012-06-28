CREATE TABLE [dbo].[SpecialRoot] (
    [ABANBY]          NVARCHAR (10)  NULL,
    [ABANDTTM]        DATETIME       NULL,
    [ADDBY]           NVARCHAR (30)  NULL,
    [ADDDTTM]         DATETIME       NULL,
    [COMMENTS]        NVARCHAR (254) NULL,
    [COMPKEY]         INT            NOT NULL,
    [COPSEWERMAINKEY] INT            NOT NULL,
    [DSOURCE]         NVARCHAR (8)   NULL,
    [GRID1]           NVARCHAR (3)   NULL,
    [GRID2]           NVARCHAR (3)   NULL,
    [MAPPAGE]         INT            NULL,
    [MARKBALL]        NVARCHAR (1)   NULL,
    [MHTYPE]          NVARCHAR (10)  NULL,
    [MODBY]           NVARCHAR (30)  NULL,
    [MODDTTM]         DATETIME       NULL,
    [ROOTPROB]        NVARCHAR (10)  NULL,
    [SHEETNO]         NVARCHAR (10)  NULL,
    [asset_set_id]    INT            NULL
);

