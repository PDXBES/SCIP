CREATE TABLE [dbo].[TRACTIVE_FORCE_MODEL_INPUTS]
(
  [simlinkid] [varchar](16) NOT NULL,
  [mlinkid] [int] NOT NULL,
  [compkey] [int] NOT NULL,
  [diamwidth_in] [decimal](8, 3) NOT NULL,
  [material] [varchar](6) NOT NULL,
  [slope] [decimal](8, 5) NOT NULL,
  [qmin] [decimal](7, 3) NOT NULL,
  [qavg1] [decimal](7, 3) NOT NULL,
  [qmax] [decimal](7, 3) NULL,
  [qavg2] [decimal](7, 3) NULL,
  [angle_of_sewer_invert_from_horiz_rad] [decimal](5, 3) NOT NULL,
  [flow_depth_ft] [decimal](5, 3) NOT NULL,
  [depth_to_diameter_ratio] [decimal](4, 3) NOT NULL,
  [flow_area_sqft] [decimal](6, 3) NOT NULL,
  [hydraulic_ratio_ft] [decimal](6, 3) NOT NULL,
  [shear_stress_psf] [decimal](8, 5) NOT NULL,
  [particle_size_mm] [decimal](10, 4) NOT NULL
  CONSTRAINT [PK_TRACTIVE_FORCE_MODEL_INPUTS] PRIMARY KEY CLUSTERED 
  (
    [simlinkid] ASC
  )
)
