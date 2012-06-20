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
      Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
      Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ASSET_SETS", -1);
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("asset_set_id", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("name");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("import_date");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("description");
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
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
      this.ultraGridAlternatives = new Infragistics.Win.UltraWinGrid.UltraGrid();
      this.aLTERNATIVESBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.sCIPDataSet = new UI.SCIPDataSet();
      this.aLTERNATIVESTableAdapter = new UI.SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter();
      this.ultraButtonSaveChanges = new Infragistics.Win.Misc.UltraButton();
      this.ultraButtonDiscardChanges = new Infragistics.Win.Misc.UltraButton();
      this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
      this.ultraGridBagLayoutPanel2 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
      this.lstAssetSets = new Infragistics.Win.UltraWinGrid.UltraDropDown();
      this.aSSETSETSBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.aSSET_SETSTableAdapter = new UI.SCIPDataSetTableAdapters.ASSET_SETSTableAdapter();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridAlternatives)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
      this.ultraGridBagLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).BeginInit();
      this.ultraGridBagLayoutPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.lstAssetSets)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.aSSETSETSBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // ultraGridAlternatives
      // 
      this.ultraGridAlternatives.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ultraGridAlternatives.DataSource = this.aLTERNATIVESBindingSource;
      this.ultraGridAlternatives.DisplayLayout.AddNewBox.Hidden = false;
      this.ultraGridAlternatives.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
      ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
      ultraGridColumn1.Header.VisiblePosition = 0;
      ultraGridColumn1.Hidden = true;
      ultraGridColumn1.Width = 166;
      ultraGridColumn2.Header.VisiblePosition = 1;
      ultraGridColumn2.Width = 255;
      ultraGridColumn3.Header.VisiblePosition = 2;
      ultraGridColumn3.Width = 253;
      ultraGridColumn4.Header.VisiblePosition = 3;
      ultraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
      ultraGridColumn4.Width = 195;
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
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ultraGridAlternatives, gridBagConstraint5);
      this.ultraGridAlternatives.Location = new System.Drawing.Point(0, 0);
      this.ultraGridAlternatives.Name = "ultraGridAlternatives";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ultraGridAlternatives, new System.Drawing.Size(700, 143));
      this.ultraGridAlternatives.Size = new System.Drawing.Size(724, 518);
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
      // aLTERNATIVESTableAdapter
      // 
      this.aLTERNATIVESTableAdapter.ClearBeforeFill = true;
      // 
      // ultraButtonSaveChanges
      // 
      this.ultraButtonSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      gridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint3.OriginX = 1;
      gridBagConstraint3.OriginY = 0;
      this.ultraGridBagLayoutPanel2.SetGridBagConstraint(this.ultraButtonSaveChanges, gridBagConstraint3);
      this.ultraButtonSaveChanges.Location = new System.Drawing.Point(615, 0);
      this.ultraButtonSaveChanges.Name = "ultraButtonSaveChanges";
      this.ultraGridBagLayoutPanel2.SetPreferredSize(this.ultraButtonSaveChanges, new System.Drawing.Size(109, 23));
      this.ultraButtonSaveChanges.Size = new System.Drawing.Size(109, 23);
      this.ultraButtonSaveChanges.TabIndex = 1;
      this.ultraButtonSaveChanges.Text = "Save Changes";
      this.ultraButtonSaveChanges.Click += new System.EventHandler(this.ultraButtonSaveChanges_Click);
      // 
      // ultraButtonDiscardChanges
      // 
      this.ultraButtonDiscardChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      gridBagConstraint2.Anchor = Infragistics.Win.Layout.AnchorType.Right;
      gridBagConstraint2.OriginX = 0;
      gridBagConstraint2.OriginY = 0;
      gridBagConstraint2.WeightX = 1F;
      this.ultraGridBagLayoutPanel2.SetGridBagConstraint(this.ultraButtonDiscardChanges, gridBagConstraint2);
      this.ultraButtonDiscardChanges.Location = new System.Drawing.Point(506, 0);
      this.ultraButtonDiscardChanges.Name = "ultraButtonDiscardChanges";
      this.ultraGridBagLayoutPanel2.SetPreferredSize(this.ultraButtonDiscardChanges, new System.Drawing.Size(109, 23));
      this.ultraButtonDiscardChanges.Size = new System.Drawing.Size(109, 23);
      this.ultraButtonDiscardChanges.TabIndex = 2;
      this.ultraButtonDiscardChanges.Text = "Discard Changes";
      this.ultraButtonDiscardChanges.Click += new System.EventHandler(this.ultraButtonDiscardChanges_Click);
      // 
      // ultraGridBagLayoutPanel1
      // 
      this.ultraGridBagLayoutPanel1.Controls.Add(this.ultraGridBagLayoutPanel2);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.ultraGridAlternatives);
      this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
      this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(724, 549);
      this.ultraGridBagLayoutPanel1.TabIndex = 3;
      // 
      // ultraGridBagLayoutPanel2
      // 
      this.ultraGridBagLayoutPanel2.Controls.Add(this.lstAssetSets);
      this.ultraGridBagLayoutPanel2.Controls.Add(this.ultraButtonDiscardChanges);
      this.ultraGridBagLayoutPanel2.Controls.Add(this.ultraButtonSaveChanges);
      gridBagConstraint4.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint4.OriginX = 0;
      gridBagConstraint4.OriginY = 1;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ultraGridBagLayoutPanel2, gridBagConstraint4);
      this.ultraGridBagLayoutPanel2.Location = new System.Drawing.Point(0, 526);
      this.ultraGridBagLayoutPanel2.Name = "ultraGridBagLayoutPanel2";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ultraGridBagLayoutPanel2, new System.Drawing.Size(200, 23));
      this.ultraGridBagLayoutPanel2.Size = new System.Drawing.Size(724, 23);
      this.ultraGridBagLayoutPanel2.TabIndex = 1;
      // 
      // lstAssetSets
      // 
      this.lstAssetSets.DataSource = this.aSSETSETSBindingSource;
      this.lstAssetSets.DisplayLayout.AddNewBox.Hidden = false;
      appearance1.BackColor = System.Drawing.SystemColors.Window;
      appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
      this.lstAssetSets.DisplayLayout.Appearance = appearance1;
      this.lstAssetSets.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
      ultraGridColumn5.Header.VisiblePosition = 0;
      ultraGridColumn5.Hidden = true;
      ultraGridColumn5.Width = 249;
      ultraGridColumn6.Header.VisiblePosition = 1;
      ultraGridColumn6.Width = 136;
      ultraGridColumn7.Header.VisiblePosition = 2;
      ultraGridColumn7.Width = 134;
      ultraGridColumn8.Header.VisiblePosition = 3;
      ultraGridColumn8.Width = 135;
      ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
      this.lstAssetSets.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
      this.lstAssetSets.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
      this.lstAssetSets.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
      appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
      appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
      appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
      appearance2.BorderColor = System.Drawing.SystemColors.Window;
      this.lstAssetSets.DisplayLayout.GroupByBox.Appearance = appearance2;
      appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
      this.lstAssetSets.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
      this.lstAssetSets.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
      appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
      appearance4.BackColor2 = System.Drawing.SystemColors.Control;
      appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
      appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
      this.lstAssetSets.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
      this.lstAssetSets.DisplayLayout.MaxColScrollRegions = 1;
      this.lstAssetSets.DisplayLayout.MaxRowScrollRegions = 1;
      appearance5.BackColor = System.Drawing.SystemColors.Window;
      appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
      this.lstAssetSets.DisplayLayout.Override.ActiveCellAppearance = appearance5;
      appearance6.BackColor = System.Drawing.SystemColors.Highlight;
      appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
      this.lstAssetSets.DisplayLayout.Override.ActiveRowAppearance = appearance6;
      this.lstAssetSets.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
      this.lstAssetSets.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
      appearance7.BackColor = System.Drawing.SystemColors.Window;
      this.lstAssetSets.DisplayLayout.Override.CardAreaAppearance = appearance7;
      appearance8.BorderColor = System.Drawing.Color.Silver;
      appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
      this.lstAssetSets.DisplayLayout.Override.CellAppearance = appearance8;
      this.lstAssetSets.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
      this.lstAssetSets.DisplayLayout.Override.CellPadding = 0;
      appearance9.BackColor = System.Drawing.SystemColors.Control;
      appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
      appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
      appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
      appearance9.BorderColor = System.Drawing.SystemColors.Window;
      this.lstAssetSets.DisplayLayout.Override.GroupByRowAppearance = appearance9;
      appearance10.TextHAlignAsString = "Left";
      this.lstAssetSets.DisplayLayout.Override.HeaderAppearance = appearance10;
      this.lstAssetSets.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
      this.lstAssetSets.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
      appearance11.BackColor = System.Drawing.SystemColors.Window;
      appearance11.BorderColor = System.Drawing.Color.Silver;
      this.lstAssetSets.DisplayLayout.Override.RowAppearance = appearance11;
      this.lstAssetSets.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
      appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
      this.lstAssetSets.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
      this.lstAssetSets.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
      this.lstAssetSets.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
      this.lstAssetSets.DisplayLayout.UseFixedHeaders = true;
      this.lstAssetSets.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
      this.lstAssetSets.DisplayMember = "name";
      this.lstAssetSets.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
      this.ultraGridBagLayoutPanel2.SetGridBagConstraint(this.lstAssetSets, gridBagConstraint1);
      this.ultraGridBagLayoutPanel2.SetIncludeInLayout(this.lstAssetSets, false);
      this.lstAssetSets.Location = new System.Drawing.Point(43, -58);
      this.lstAssetSets.Name = "lstAssetSets";
      this.ultraGridBagLayoutPanel2.SetPreferredSize(this.lstAssetSets, new System.Drawing.Size(424, 80));
      this.lstAssetSets.Size = new System.Drawing.Size(424, 80);
      this.lstAssetSets.TabIndex = 4;
      this.lstAssetSets.Text = "ultraDropDown1";
      this.lstAssetSets.ValueMember = "asset_set_id";
      this.lstAssetSets.Visible = false;
      // 
      // aSSETSETSBindingSource
      // 
      this.aSSETSETSBindingSource.DataMember = "ASSET_SETS";
      this.aSSETSETSBindingSource.DataSource = this.sCIPDataSet;
      // 
      // aSSET_SETSTableAdapter
      // 
      this.aSSET_SETSTableAdapter.ClearBeforeFill = true;
      // 
      // AlternativesPage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(724, 549);
      this.Controls.Add(this.ultraGridBagLayoutPanel1);
      this.Name = "AlternativesPage";
      this.Text = "Manage Alternatives";
      this.Load += new System.EventHandler(this.FormManageAlternatives_Load);
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridAlternatives)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
      this.ultraGridBagLayoutPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).EndInit();
      this.ultraGridBagLayoutPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.lstAssetSets)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.aSSETSETSBindingSource)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGridAlternatives;
        private SCIPDataSet sCIPDataSet;
        private System.Windows.Forms.BindingSource aLTERNATIVESBindingSource;
        private SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter aLTERNATIVESTableAdapter;
        private Infragistics.Win.Misc.UltraButton ultraButtonSaveChanges;
        private Infragistics.Win.Misc.UltraButton ultraButtonDiscardChanges;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel2;
        private Infragistics.Win.UltraWinGrid.UltraDropDown lstAssetSets;
        private System.Windows.Forms.BindingSource aSSETSETSBindingSource;
        private SCIPDataSetTableAdapters.ASSET_SETSTableAdapter aSSET_SETSTableAdapter;
    }
}