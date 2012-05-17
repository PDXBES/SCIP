CREATE TABLE [dbo].[ALTERNATIVES] (
    [alternative_id] INT            IDENTITY (1,1) NOT NULL,
    [name]           VARCHAR (20)   NOT NULL,
    [description]    VARCHAR (1000) NULL,
    [asset_set_id]   INT            NOT NULL
);

