-- =============================================
-- Author:		Mike Szwaya
-- Create date: 4/25/2012
-- Description:	Inserts a record containing pipe data and results of the Tractive Force Analysis
-- =============================================
CREATE PROCEDURE [dbo].[SP_INSERT_TRACTIVE_FORCE_DATA]
	-- Add the parameters for the stored procedure here
	@simlinkid varchar(16) = ND, 
	@mlinkid int = 99999,
	@compkey int = 99999,
	@diamwidth_in decimal(8,3) = 0,
	@material varchar(6) = 0,
	@slope decimal(8, 5) = 0,
	@qmin decimal(7, 3) = 0,
	@qavg1 decimal(7, 3) = 0,
	@angle_of_sewer_invert_from_horiz_rad decimal(5, 3) = 0,
	@flow_depth_ft decimal(5, 3) = 0,
	@depth_to_diameter_ratio decimal(4, 3) = 0,
	@flow_area_sqft decimal(6, 3) = 0,
	@hydraulic_ratio_ft decimal(6, 3) = 0,
	@shear_stress_psf decimal(8, 5) = 0,
	@particle_size_mm decimal(10, 4) = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	INSERT INTO [dbo].[TRACTIVE_FORCE_MODEL_INPUTS]
    (
     simlinkid
    ,mlinkid
    ,compkey
    ,diamwidth_in
    ,material
    ,slope
    ,qmin
    ,qavg1
    ,angle_of_sewer_invert_from_horiz_rad
    ,flow_depth_ft
    ,depth_to_diameter_ratio
    ,flow_area_sqft
    ,hydraulic_ratio_ft
    ,shear_stress_psf
    ,particle_size_mm
    )
  VALUES
    (
     @simlinkid
    ,@mlinkid
    ,@compkey
    ,@diamwidth_in
    ,@material
    ,@slope
    ,@qmin
    ,@qavg1
    ,@angle_of_sewer_invert_from_horiz_rad
    ,@flow_depth_ft
    ,@depth_to_diameter_ratio
    ,@flow_area_sqft
    ,@hydraulic_ratio_ft
    ,@shear_stress_psf
    ,@particle_size_mm
    )
END
