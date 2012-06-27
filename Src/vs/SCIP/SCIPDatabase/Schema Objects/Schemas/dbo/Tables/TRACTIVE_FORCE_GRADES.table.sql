CREATE TABLE [dbo].[TRACTIVE_FORCE_GRADES]
(
	[rank]                 int NOT NULL,
  [grade]                varchar(2) NOT NULL,
  [description]          varchar(100) NULL,
  [min_particle_size_mm] decimal(7,4) NULL,
  [max_particle_size_mm] decimal(7,4) NULL
)
