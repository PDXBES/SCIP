CREATE TABLE [dbo].[AllInspections] (
    [COMPKEY]      INT            NULL,
    [INSPKEY]      INT            NULL,
    [OBRATING]     FLOAT          NULL,
    [FROM]         FLOAT          NULL,
    [TO]           FLOAT          NULL,
    [STARTDTTM]    DATETIME       NULL,
    [COMPDTTM]     DATETIME       NULL,
    [INSTDATE]     DATETIME       NULL,
    [SEVDESC]      NVARCHAR (300) NULL,
    [INSPNDX]      NVARCHAR (10)  NULL,
    [INDEXVAL]     FLOAT          NULL,
    [OWN]          VARCHAR (4)    NULL,
    [UNITTYPE]     VARCHAR (6)    NULL,
    [SERVSTAT]     VARCHAR (4)    NULL,
    [asset_set_id] INT            NULL
);

