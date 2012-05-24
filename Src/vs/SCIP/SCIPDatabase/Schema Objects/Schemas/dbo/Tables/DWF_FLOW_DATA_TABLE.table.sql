CREATE TABLE [dbo].[DWF_FLOW_DATA]
(
  [dwf_flow_data_id] [int] IDENTITY(1,1) NOT NULL,
  [mlinkid] [int] NOT NULL,
  [simlinkid] [varchar](16) NOT NULL,
  [model_source] [varchar](20) NOT NULL,
  [flow_date] [smalldatetime] NOT NULL,
  [flow_value_cfs] [decimal](7,3) NOT NULL,
  CONSTRAINT [PK_DWF_FLOW_DATA] PRIMARY KEY CLUSTERED 
  (
    [dwf_flow_data_id] ASC
  )
  WITH
  (
    PAD_INDEX  = OFF, 
    STATISTICS_NORECOMPUTE  = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS  = ON,
    ALLOW_PAGE_LOCKS  = ON
  )
)

