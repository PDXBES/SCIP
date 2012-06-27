CREATE PROCEDURE [dbo].[SP_STATUS_MESSAGE]
	@message VARCHAR(200)
AS
BEGIN
  DECLARE @StatusMessage VARCHAR(223)
	SET @StatusMessage = CONVERT(VARCHAR(23), GETDATE(), 121) + ' ' + @message 
  RAISERROR(@StatusMessage, 0, 1) WITH NOWAIT
END