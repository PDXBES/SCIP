namespace UI
{
    partial class AlternativesPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.components = new System.ComponentModel.Container();
      Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ALTERNATIVES", -1);
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("alternative_id");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("name");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("description");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("asset_set_id", -1, "lstAssetSets");
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint5 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint3 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint4 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
      Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ASSET_SETS", -1);
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("asset_set_id");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("name");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("import_date");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("description");
      Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
      Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ASSET_SETS", -1);
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("asset_set_id");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("name");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("import_date");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("description");
      Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
      Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
      this.ultraGridAlternatives = new Infragistics.Win.UltraWinGrid.UltraGrid();
      this.aLTERNATIVESBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.sCIPDataSet = new UI.SCIPDataSet();
      this.btnSaveChanges = new Infragistics.Win.Misc.UltraButton();
      this.btnDiscardChanges = new Infragistics.Win.Misc.UltraButton();
      this.pnlAlternativesGrid = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
      this.pnlActionButtons = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
      this.btnEditAssetSets = new Infragistics.Win.Misc.UltraDropDownButton();
      this.popupAssetSets = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
      this.gridAssetSets = new Infragistics.Win.UltraWinGrid.UltraGrid();
      this.aSSETSETSBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.statusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
      this.lstAssetSets = new Infragistics.Win.UltraWinGrid.UltraDropDown();
      this.aLTERNATIVESTableAdapter = new UI.SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter();
      this.aSSET_SETSTableAdapter = new UI.SCIPDataSetTableAdapters.ASSET_SETSTableAdapter();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridAlternatives)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pnlAlternativesGrid)).BeginInit();
      this.pnlAlternativesGrid.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pnlActionButtons)).BeginInit();
      this.pnlActionButtons.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridAssetSets)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.aSSETSETSBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lstAssetSets)).BeginInit();
      this.SuspendLayout();
      // 
      // ultraGridAlternatives
      // 
      this.ultraGridAlternatives.DataSource = this.aLTERNATIVESBindingSource;
      this.ultraGridAlternatives.DisplayLayout.AddNewBox.Hidden = false;
      this.ultraGridAlternatives.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
      ultraGridColumn1.Header.VisiblePosition = 0;
      ultraGridColumn1.Width = 161;
      ultraGridColumn2.Header.VisiblePosition = 1;
      ultraGridColumn2.Width = 199;
      ultraGridColumn3.Header.VisiblePosition = 2;
      ultraGridColumn3.Width = 196;
      ultraGridColumn4.Header.Caption = "asset set";
      ultraGridColumn4.Header.VisiblePosition = 3;
      ultraGridColumn4.Width = 147;
      ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
      this.ultraGridAlternatives.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
      this.ultraGridAlternatives.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      gridBagConstraint5.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint5.Insets.Bottom = 8;
      gridBagConstraint5.OriginX = 0;
      gridBagConstraint5.OriginY = 0;
      gridBagConstraint5.WeightX = 1F;
      gridBagConstraint5.WeightY = 1F;
      this.pnlAlternativesGrid.SetGridBagConstraint(this.ultraGridAlternatives, gridBagConstraint5);
      this.ultraGridAlternatives.Location = new System.Drawing.Point(0, 0);
      this.ultraGridAlternatives.Name = "ultraGridAlternatives";
      this.pnlAlternativesGrid.SetPreferredSize(this.ultraGridAlternatives, new System.Drawing.Size(724, 143));
      this.ultraGridAlternatives.Size = new System.Drawing.Size(724, 536);
      this.ultraGridAlternatives.TabIndex = 0;
      this.ultraGridAlternatives.Text = "Alternatives";
      // 
      // aLTERNATIVESBindingSource
      // 
      this.aLTERNATIVESBindingSource.DataMember = "ALTERNATIVES";
      this.aLTERNATIVESBindingSource.DataSource = this.sCIPDataSet;
      // 
      // sCIPDataSet
      // 
      this.sCIPDataSet.DataSetName = "SCIPDataSet";
      this.sCIPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // btnSaveChanges
      // 
      this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      gridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint3.OriginX = 2;
      gridBagConstraint3.OriginY = 0;
      this.pnlActionButtons.SetGridBagConstraint(this.btnSaveChanges, gridBagConstraint3);
      this.btnSaveChanges.Location = new System.Drawing.Point(615, 0);
      this.btnSaveChanges.Name = "btnSaveChanges";
      this.pnlActionButtons.SetPreferredSize(this.btnSaveChanges, new System.Drawing.Size(109, 23));
      this.btnSaveChanges.Size = new System.Drawing.Size(109, 21);
      this.btnSaveChanges.TabIndex = 1;
      this.btnSaveChanges.Text = "Save Changes";
      this.btnSaveChanges.Click += new System.EventHandler(this.ultraButtonSaveChanges_Click);
      // 
      // btnDiscardChanges
      // 
      this.btnDiscardChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      gridBagConstraint2.Anchor = Infragistics.Win.Layout.AnchorType.Right;
      gridBagConstraint2.OriginX = 1;
      gridBagConstraint2.OriginY = 0;
      gridBagConstraint2.WeightX = 1F;
      this.pnlActionButtons.SetGridBagConstraint(this.btnDiscardChanges, gridBagConstraint2);
      this.btnDiscardChanges.Location = new System.Drawing.Point(506, -1);
      this.btnDiscardChanges.Name = "btnDiscardChanges";
      this.pnlActionButtons.SetPreferredSize(this.btnDiscardChanges, new System.Drawing.Size(109, 23));
      this.btnDiscardChanges.Size = new System.Drawing.Size(109, 23);
      this.btnDiscardChanges.TabIndex = 2;
      this.btnDiscardChanges.Text = "Discard Changes";
      this.btnDiscardChanges.Click += new System.EventHandler(this.ultraButtonDiscardChanges_Click);
      // 
      // pnlAlternativesGrid
      // 
      this.pnlAlternativesGrid.Controls.Add(this.pnlActionButtons);
      this.pnlAlternativesGrid.Controls.Add(this.ultraGridAlternatives);
      this.pnlAlternativesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlAlternativesGrid.Location = new System.Drawing.Point(0, 0);
      this.pnlAlternativesGrid.Name = "pnlAlternativesGrid";
      this.pnlAlternativesGrid.Size = new System.Drawing.Size(724, 565);
      this.pnlAlternativesGrid.TabIndex = 3;
      // 
      // pnlActionButtons
      // 
      this.pnlActionButtons.Controls.Add(this.btnEditAssetSets);
      this.pnlActionButtons.Controls.Add(this.btnDiscardChanges);
      this.pnlActionButtons.Controls.Add(this.btnSaveChanges);
      gridBagConstraint4.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint4.OriginX = 0;
      gridBagConstraint4.OriginY = 1;
      this.pnlAlternativesGrid.SetGridBagConstraint(this.pnlActionButtons, gridBagConstraint4);
      this.pnlActionButtons.Location = new System.Drawing.Point(0, 544);
      this.pnlActionButtons.Name = "pnlActionButtons";
      this.pnlAlternativesGrid.SetPreferredSize(this.pnlActionButtons, new System.Drawing.Size(724, 21));
      this.pnlActionButtons.Size = new System.Drawing.Size(724, 21);
      this.pnlActionButtons.TabIndex = 1;
      // 
      // btnEditAssetSets
      // 
      gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint1.OriginX = 0;
      gridBagConstraint1.OriginY = 0;
      this.pnlActionButtons.SetGridBagConstraint(this.btnEditAssetSets, gridBagConstraint1);
      this.btnEditAssetSets.Location = new System.Drawing.Point(0, 0);
      this.btnEditAssetSets.Name = "btnEditAssetSets";
      this.btnEditAssetSets.PopupItemKey = "gridAssetSets";
      this.btnEditAssetSets.PopupItemProvider = this.popupAssetSets;
      this.pnlActionButtons.SetPreferredSize(this.btnEditAssetSets, new System.Drawing.Size(144, 28));
      this.btnEditAssetSets.Size = new System.Drawing.Size(144, 21);
      this.btnEditAssetSets.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
      this.btnEditAssetSets.TabIndex = 3;
      this.btnEditAssetSets.Text = "Edit Asset Sets";
      // 
      // popupAssetSets
      // 
      this.popupAssetSets.PopupControl = this.gridAssetSets;
      // 
      // gridAssetSets
      // 
      this.gridAssetSets.DataSource = this.aSSETSETSBindingSource;
      this.gridAssetSets.DisplayLayout.AddNewBox.Hidden = false;
      appearance1.BackColor = System.Drawing.SystemColors.Window;
      appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
      this.gridAssetSets.DisplayLayout.Appearance = appearance1;
      this.gridAssetSets.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
      ultraGridColumn9.Header.VisiblePosition = 0;
      ultraGridColumn9.Hidden = true;
      ultraGridColumn9.Width = 51;
      ultraGridColumn10.Header.VisiblePosition = 1;
      ultraGridColumn10.Width = 72;
      ultraGridColumn11.Header.VisiblePosition = 2;
      ultraGridColumn11.Width = 69;
      ultraGridColumn12.Header.VisiblePosition = 3;
      ultraGridColumn12.Width = 71;
      ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12});
      this.gridAssetSets.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
      this.gridAssetSets.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
      this.gridAssetSets.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
      appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
      appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
      appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
      appearance2.BorderColor = System.Drawing.SystemColors.Window;
      this.gridAssetSets.DisplayLayout.GroupByBox.Appearance = appearance2;
      appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
      this.gridAssetSets.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
      this.gridAssetSets.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
      appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
      appearance4.BackColor2 = System.Drawing.SystemColors.Control;
      appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
      appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
      this.gridAssetSets.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
      this.gridAssetSets.DisplayLayout.MaxColScrollRegions = 1;
      this.gridAssetSets.DisplayLayout.MaxRowScrollRegions = 1;
      appearance5.BackColor = System.Drawing.SystemColors.Window;
      appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
      this.gridAssetSets.DisplayLayout.Override.ActiveCellAppearance = appearance5;
      appearance6.BackColor = System.Drawing.SystemColors.Highlight;
      appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
      this.gridAssetSets.DisplayLayout.Override.ActiveRowAppearance = appearance6;
      this.gridAssetSets.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
      this.gridAssetSets.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
      appearance7.BackColor = System.Drawing.SystemColors.Window;
      this.gridAssetSets.DisplayLayout.Override.CardAreaAppearance = appearance7;
      appearance8.BorderColor = System.Drawing.Color.Silver;
      appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
      this.gridAssetSets.DisplayLayout.Override.CellAppearance = appearance8;
      this.gridAssetSets.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
      this.gridAssetSets.DisplayLayout.Override.CellPadding = 0;
      appearance9.BackColor = System.Drawing.SystemColors.Control;
      appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
      appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
      appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
      appearance9.BorderColor = System.Drawing.SystemColors.Window;
      this.gridAssetSets.DisplayLayout.Override.GroupByRowAppearance = appearance9;
      appearance10.TextHAlignAsString = "Left";
      this.gridAssetSets.DisplayLayout.Override.HeaderAppearance = appearance10;
      this.gridAssetSets.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
      this.gridAssetSets.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
      appearance11.BackColor = System.Drawing.SystemColors.Window;
      appearance11.BorderColor = System.Drawing.Color.Silver;
      this.gridAssetSets.DisplayLayout.Override.RowAppearance = appearance11;
      this.gridAssetSets.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
      appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
      this.gridAssetSets.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
      this.gridAssetSets.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
      this.gridAssetSets.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
      this.gridAssetSets.DisplayLayout.UseFixedHeaders = true;
      this.gridAssetSets.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.gridAssetSets.Location = new System.Drawing.Point(442, 320);
      this.gridAssetSets.Name = "gridAssetSets";
      this.gridAssetSets.Size = new System.Drawing.Size(250, 133);
      this.gridAssetSets.TabIndex = 5;
      this.gridAssetSets.Text = "ultraGrid1";
      this.gridAssetSets.Visible = false;
      this.gridAssetSets.AfterRowsDeleted += new System.EventHandler(this.gridAssetSets_AfterRowsDeleted);
      this.gridAssetSets.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.gridAssetSets_AfterRowUpdate);
      // 
      // aSSETSETSBindingSource
      // 
      this.aSSETSETSBindingSource.DataMember = "ASSET_SETS";
      this.aSSETSETSBindingSource.DataSource = this.sCIPDataSet;
      // 
      // statusBar
      // 
      this.statusBar.Location = new System.Drawing.Point(0, 565);
      this.statusBar.Name = "statusBar";
      this.statusBar.Size = new System.Drawing.Size(724, 21);
      this.statusBar.TabIndex = 4;
      this.statusBar.Text = "ultraStatusBar1";
      // 
      // lstAssetSets
      // 
      this.lstAssetSets.DataSource = this.aSSETSETSBindingSource;
      this.lstAssetSets.DisplayLayout.AddNewBox.Hidden = false;
      appearance13.BackColor = System.Drawing.SystemColors.Window;
      appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption;
      this.lstAssetSets.DisplayLayout.Appearance = appearance13;
      this.lstAssetSets.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
      ultraGridColumn5.Header.VisiblePosition = 0;
      ultraGridColumn5.Hidden = true;
      ultraGridColumn5.Width = 101;
      ultraGridColumn6.Header.VisiblePosition = 1;
      ultraGridColumn6.Width = 137;
      ultraGridColumn7.Header.VisiblePosition = 2;
      ultraGridColumn7.Width = 133;
      ultraGridColumn8.Header.VisiblePosition = 3;
      ultraGridColumn8.Width = 135;
      ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
      this.lstAssetSets.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
      this.lstAssetSets.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
      this.lstAssetSets.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
      appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder;
      appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
      appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
      appearance14.BorderColor = System.Drawing.SystemColors.Window;
      this.lstAssetSets.DisplayLayout.GroupByBox.Appearance = appearance14;
      appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
      this.lstAssetSets.DisplayLayout.GroupByBox.BandLabelAppearance = appearance15;
      this.lstAssetSets.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
      appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight;
      appearance16.BackColor2 = System.Drawing.SystemColors.Control;
      appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
      appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
      this.lstAssetSets.DisplayLayout.GroupByBox.PromptAppearance = appearance16;
      this.lstAssetSets.DisplayLayout.MaxColScrollRegions = 1;
      this.lstAssetSets.DisplayLayout.MaxRowScrollRegions = 1;
      appearance17.BackColor = System.Drawing.SystemColors.Window;
      appearance17.ForeColor = System.Drawing.SystemColors.ControlText;
      this.lstAssetSets.DisplayLayout.Override.ActiveCellAppearance = appearance17;
      appearance18.BackColor = System.Drawing.SystemColors.Highlight;
      appearance18.ForeColor = System.Drawing.SystemColors.HighlightText;
      this.lstAssetSets.DisplayLayout.Override.ActiveRowAppearance = appearance18;
      this.lstAssetSets.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
      this.lstAssetSets.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
      appearance19.BackColor = System.Drawing.SystemColors.Window;
      this.lstAssetSets.DisplayLayout.Override.CardAreaAppearance = appearance19;
      appearance20.BorderColor = System.Drawing.Color.Silver;
      appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
      this.lstAssetSets.DisplayLayout.Override.CellAppearance = appearance20;
      this.lstAssetSets.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
      this.lstAssetSets.DisplayLayout.Override.CellPadding = 0;
      appearance21.BackColor = System.Drawing.SystemColors.Control;
      appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark;
      appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
      appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
      appearance21.BorderColor = System.Drawing.SystemColors.Window;
      this.lstAssetSets.DisplayLayout.Override.GroupByRowAppearance = appearance21;
      appearance22.TextHAlignAsString = "Left";
      this.lstAssetSets.DisplayLayout.Override.HeaderAppearance = appearance22;
      this.lstAssetSets.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
      this.lstAssetSets.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
      appearance23.BackColor = System.Drawing.SystemColors.Window;
      appearance23.BorderColor = System.Drawing.Color.Silver;
      this.lstAssetSets.DisplayLayout.Override.RowAppearance = appearance23;
      this.lstAssetSets.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
      appearance24.BackColor = System.Drawing.SystemColors.ControlLight;
      this.lstAssetSets.DisplayLayout.Override.TemplateAddRowAppearance = appearance24;
      this.lstAssetSets.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
      this.lstAssetSets.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
      this.lstAssetSets.DisplayLayout.UseFixedHeaders = true;
      this.lstAssetSets.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
      this.lstAssetSets.DisplayMember = "name";
      this.lstAssetSets.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lstAssetSets.Location = new System.Drawing.Point(12, 320);
      this.lstAssetSets.Name = "lstAssetSets";
      this.lstAssetSets.Size = new System.Drawing.Size(424, 80);
      this.lstAssetSets.TabIndex = 4;
      this.lstAssetSets.Text = "ultraDropDown1";
      this.lstAssetSets.ValueMember = "asset_set_id";
      this.lstAssetSets.Visible = false;
      // 
      // aLTERNATIVESTableAdapter
      // 
      this.aLTERNATIVESTableAdapter.ClearBeforeFill = true;
      // 
      // aSSET_SETSTableAdapter
      // 
      this.aSSET_SETSTableAdapter.ClearBeforeFill = true;
      // 
      // AlternativesPage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(724, 586);
      this.Controls.Add(this.gridAssetSets);
      this.Controls.Add(this.lstAssetSets);
      this.Controls.Add(this.pnlAlternativesGrid);
      this.Controls.Add(this.statusBar);
      this.Name = "AlternativesPage";
      this.Text = "Manage Alternatives";
      this.Load += new System.EventHandler(this.FormManageAlternatives_Load);
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridAlternatives)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pnlAlternativesGrid)).EndInit();
      this.pnlAlternativesGrid.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pnlActionButtons)).EndInit();
      this.pnlActionButtons.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridAssetSets)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.aSSETSETSBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lstAssetSets)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGridAlternatives;
        private SCIPDataSet sCIPDataSet;
        private System.Windows.Forms.BindingSource aLTERNATIVESBindingSource;
        private SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter aLTERNATIVESTableAdapter;
        private Infragistics.Win.Misc.UltraButton btnSaveChanges;
        private Infragistics.Win.Misc.UltraButton btnDiscardChanges;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel pnlAlternativesGrid;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel pnlActionButtons;
        private Infragistics.Win.UltraWinGrid.UltraDropDown lstAssetSets;
        private System.Windows.Forms.BindingSource aSSETSETSBindingSource;
        private SCIPDataSetTableAdapters.ASSET_SETSTableAdapter aSSET_SETSTableAdapter;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridAssetSets;
        private Infragistics.Win.Misc.UltraDropDownButton btnEditAssetSets;
        private Infragistics.Win.Misc.UltraPopupControlContainer popupAssetSets;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar statusBar;
    }
}