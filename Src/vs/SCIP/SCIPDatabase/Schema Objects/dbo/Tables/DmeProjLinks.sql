CREATE TABLE [dbo].[DmeProjLinks] (
    [MAPINFO_ID] INT           NOT NULL,
    [Compkey]    INT           NULL,
    [MLINKID]    INT           NULL,
    [Globalid]   INT           NULL,
    [USNODE]     NVARCHAR (20) NULL,
    [DSNODE]     NVARCHAR (20) NULL,
    [DIAM]       FLOAT (53)    NULL,
    [pLEN]       FLOAT (53)    NULL,
    [JOBNO]      NVARCHAR (25) NULL,
    [LyrGrp]     NVARCHAR (50) NULL,
    [LDPA]       NVARCHAR (25) NULL,
    [CIPRPA]     NVARCHAR (25) NULL,
    [CITYWIDE]   NVARCHAR (25) NULL,
    [RACTION]    NVARCHAR (25) NULL,
    [Basin]      NVARCHAR (9)  NULL,
    [CIPRPA00]   NVARCHAR (25) NULL,
    [MAU]        INT           NULL,
    [JOINTYPE]   NVARCHAR (50) NULL,
    [INSP_YRS]   SMALLINT      NULL,
    [Lat_Count]  SMALLINT      NULL
);

