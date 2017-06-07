-- =============================================
-- Author:		Mike Szwaya
-- Create date: 5/1/2012
-- Description:	Inserts flow values
-- =============================================
CREATE PROCEDURE [dbo].[SP_INSERT_DWF_FLOW_DATA]
	(
	@mlinkid  int,
	@simlinkid  nvarchar(16),
	@model_source  nvarchar(20),
	@flow_date  datetime,
	@flow_value_cfs  real
	)
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;

  -- Insert statements for procedure here
  INSERT INTO [dbo].[DWF_FLOW_DATA]
    (
     [mlinkid]
    ,[simlinkid]
    ,[model_source]
    ,[flow_date]
    ,[flow_value_cfs]
    )
  VALUES
    (
     @mlinkid
    ,@simlinkid 
    ,@model_source
    ,@flow_date
    ,@flow_value_cfs
    )
END