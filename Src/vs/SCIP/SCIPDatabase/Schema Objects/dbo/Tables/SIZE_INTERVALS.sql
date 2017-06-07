CREATE TABLE [dbo].[SIZE_INTERVALS] (
    [Interval_ID] INT        IDENTITY (1, 1) NOT NULL,
    [Type]        NCHAR (10) NOT NULL,
    [Alternative] NCHAR (10) NULL,
    [Interval1]   FLOAT (53) NULL,
    [Interval2]   FLOAT (53) NULL,
    CONSTRAINT [PK_SIZE_INTERVALS] PRIMARY KEY CLUSTERED ([Interval_ID] ASC)
);

