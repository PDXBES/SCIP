CREATE TABLE [dbo].[DWF_Flow_Statistics] (
    [qavg]             DECIMAL (38, 6) NULL,
    [qmin]             DECIMAL (7, 3)  NULL,
    [mst_link_mlinkid] INT             NOT NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [idx_MLinkID]
    ON [dbo].[DWF_Flow_Statistics]([mst_link_mlinkid] ASC);

