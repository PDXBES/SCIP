CREATE PROCEDURE [dbo].[SP_FILL_NEXT_ACTIVITIES]
AS
BEGIN
  EXEC SP_STATUS_MESSAGE "Begin SP_FILL_NEXT_ACTIVITIES"

  SET NOCOUNT ON
  TRUNCATE TABLE NEXT_ACTIVITIES

  EXEC SP_STATUS_MESSAGE "Filling activities"
  INSERT INTO NEXT_ACTIVITIES
    SELECT A.compkey, A.length_ft, A.diamwidth_inches, A.height_inches, C.name, D.name, B.inspection_activity, NULL, NULL, B.cleaning_activity, NULL, NULL, B.root_activity, NULL, NULL
    FROM ((ASSETS A INNER JOIN VW_NEXT_ACTIVITY_HANSEN_ACTIVITY_CODE_BY_COMPKEY B ON (A.COMPKEY = B.COMPKEY)) INNER JOIN BASINS C ON (A.basin_id = C.basin_id)) INNER JOIN DISTRICTS D ON (A.district_id = D.district_id)

  EXEC SP_STATUS_MESSAGE "Filling costs"
  UPDATE NEXT_ACTIVITIES 
    SET inspection_cost = A.inspection_cost, cleaning_cost = A.cleaning_cost, root_cost = A.root_cost
    FROM VW_NEXT_ACTIVITY_COST_BY_COMPKEY A
    WHERE NEXT_ACTIVITIES.compkey = A.compkey

  EXEC SP_STATUS_MESSAGE "Filling fiscal years"
  UPDATE NEXT_ACTIVITIES
    SET inspection_fiscal_year = A.inspection_fiscal_year, cleaning_fiscal_year = A.cleaning_fiscal_year, root_fiscal_year = A.root_fiscal_year
    FROM VW_NEXT_ACTIVITY_FISCAL_YEAR_BY_COMPKEY A
    WHERE NEXT_ACTIVITIES.compkey = A.compkey

  EXEC SP_STATUS_MESSAGE "End SP_FILL_NEXT_ACTIVITIES"
END