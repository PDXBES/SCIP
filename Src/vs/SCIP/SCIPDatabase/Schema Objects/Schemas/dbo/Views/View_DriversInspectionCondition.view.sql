CREATE VIEW dbo.View_DriversInspectionCondition
AS
/*Drivers for small diameter PM inspections*/ SELECT DRIVER_TYPE_ID, ASSETS.COMPKEY AS COMPKEY, default_cost_per_ft, default_frequency_years, 

CASE WHEN DATEADD(year, 
                      default_frequency_years, last_inspection_date)< GetDate() THEN GetDate() ELSE DATEADD(year, 
                      default_frequency_years, last_inspection_date) END AS next_inspection_date
FROM         (ASSETS INNER JOIN
                      DRIVER_TYPES ON (DRIVER_TYPES.activity_type_id = 1 AND DRIVER_TYPES.Driver_type_id = 23 AND (ASSETS.diamWidth_inches <= 36 AND 
                      ASSETS.height_inches <= 36))) INNER JOIN
                          (SELECT     compkey, ACCUM_RISK_INSPECT_YEAR
                            FROM          REHAB10FTSEGS
                            WHERE      (mlinkid < 40000000) AND (remarks = N'BES' OR
                                                   remarks = N'DNRV') AND (ACCUM_RISK_INSPECT_YEAR IS NOT NULL)) AS X ON 
                      ASSETS.COMPKEY = X.COMPKEY
/*Drivers For large diameter PM inspections*/ UNION
SELECT     DRIVER_TYPE_ID, ASSETS.COMPKEY AS COMPKEY, default_cost_per_ft, default_frequency_years, 

CASE WHEN DATEADD(year, default_frequency_years, last_inspection_date) < GetDate() THEN GetDate() ELSE DATEADD(year, default_frequency_years, last_inspection_date) END
                      AS next_inspection_date
FROM         ASSETS INNER JOIN
                      DRIVER_TYPES ON (DRIVER_TYPES.activity_type_id = 1 AND DRIVER_TYPES.Driver_type_id = 24 AND (ASSETS.diamWidth_inches > 36 OR
                      ASSETS.height_inches > 36)) INNER JOIN
                          (SELECT     compkey, ACCUM_RISK_INSPECT_YEAR
                            FROM          REHAB10FTSEGS
                            WHERE      (mlinkid < 40000000) AND (remarks = N'BES' OR
                                                   remarks = N'DNRV') AND (ACCUM_RISK_INSPECT_YEAR IS NOT NULL)) AS X ON ASSETS.COMPKEY = X.COMPKEY

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[12] 4[26] 2[42] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = -1029
      End
      Begin Tables = 
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 2130
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'View_DriversInspectionCondition';




GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'View_DriversInspectionCondition';

