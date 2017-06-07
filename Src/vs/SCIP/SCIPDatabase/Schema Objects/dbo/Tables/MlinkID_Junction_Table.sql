CREATE TABLE [dbo].[MlinkID_Junction_Table] (
    [mst_link_mlinkid] INT NOT NULL,
    [model_mlinkid]    INT NOT NULL,
    CONSTRAINT [PK_MlinkID_Junction_Table] PRIMARY KEY CLUSTERED ([mst_link_mlinkid] ASC, [model_mlinkid] ASC)
);

