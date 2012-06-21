namespace UI
{
  partial class ModelPage
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
      Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
      Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ALTERNATIVES", -1);
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("alternative_id");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("name");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("description");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("asset_set_id");
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
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint3 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint4 = new Infragistics.Win.Layout.GridBagConstraint();
      this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
      this.cmbAlternatives = new Infragistics.Win.UltraWinGrid.UltraCombo();
      this.alternativesBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.scipDataSet = new UI.SCIPDataSet();
      this.btnExecuteFillDriversActivities = new Infragistics.Win.Misc.UltraButton();
      this.btnExecuteRetrieveAssets = new Infragistics.Win.Misc.UltraButton();
      this.btnExecuteAll = new Infragistics.Win.Misc.UltraButton();
      this.alternativesTableAdapter = new UI.SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
      this.ultraGridBagLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmbAlternatives)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.alternativesBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.scipDataSet)).BeginInit();
      this.SuspendLayout();
      // 
      // ultraGridBagLayoutPanel1
      // 
      this.ultraGridBagLayoutPanel1.Controls.Add(this.cmbAlternatives);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.btnExecuteFillDriversActivities);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.btnExecuteRetrieveAssets);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.btnExecuteAll);
      this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
      this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(485, 428);
      this.ultraGridBagLayoutPanel1.TabIndex = 0;
      // 
      // cmbAlternatives
      // 
      this.cmbAlternatives.DataSource = this.alternativesBindingSource;
      appearance1.BackColor = System.Drawing.SystemColors.Window;
      appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
      this.cmbAlternatives.DisplayLayout.Appearance = appearance1;
      ultraGridColumn1.Header.VisiblePosition = 0;
      ultraGridColumn2.Header.VisiblePosition = 1;
      ultraGridColumn3.Header.VisiblePosition = 2;
      ultraGridColumn4.Header.VisiblePosition = 3;
      ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
      this.cmbAlternatives.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
      this.cmbAlternatives.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
      this.cmbAlternatives.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
      appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
      appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
      appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
      appearance2.BorderColor = System.Drawing.SystemColors.Window;
      this.cmbAlternatives.DisplayLayout.GroupByBox.Appearance = appearance2;
      appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
      this.cmbAlternatives.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
      this.cmbAlternatives.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
      appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
      appearance4.BackColor2 = System.Drawing.SystemColors.Control;
      appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
      appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
      this.cmbAlternatives.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
      this.cmbAlternatives.DisplayLayout.MaxColScrollRegions = 1;
      this.cmbAlternatives.DisplayLayout.MaxRowScrollRegions = 1;
      appearance5.BackColor = System.Drawing.SystemColors.Window;
      appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
      this.cmbAlternatives.DisplayLayout.Override.ActiveCellAppearance = appearance5;
      appearance6.BackColor = System.Drawing.SystemColors.Highlight;
      appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
      this.cmbAlternatives.DisplayLayout.Override.ActiveRowAppearance = appearance6;
      this.cmbAlternatives.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
      this.cmbAlternatives.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
      appearance7.BackColor = System.Drawing.SystemColors.Window;
      this.cmbAlternatives.DisplayLayout.Override.CardAreaAppearance = appearance7;
      appearance8.BorderColor = System.Drawing.Color.Silver;
      appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
      this.cmbAlternatives.DisplayLayout.Override.CellAppearance = appearance8;
      this.cmbAlternatives.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
      this.cmbAlternatives.DisplayLayout.Override.CellPadding = 0;
      appearance9.BackColor = System.Drawing.SystemColors.Control;
      appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
      appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
      appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
      appearance9.BorderColor = System.Drawing.SystemColors.Window;
      this.cmbAlternatives.DisplayLayout.Override.GroupByRowAppearance = appearance9;
      appearance10.TextHAlignAsString = "Left";
      this.cmbAlternatives.DisplayLayout.Override.HeaderAppearance = appearance10;
      this.cmbAlternatives.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
      this.cmbAlternatives.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
      appearance11.BackColor = System.Drawing.SystemColors.Window;
      appearance11.BorderColor = System.Drawing.Color.Silver;
      this.cmbAlternatives.DisplayLayout.Override.RowAppearance = appearance11;
      this.cmbAlternatives.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
      appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
      this.cmbAlternatives.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
      this.cmbAlternatives.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
      this.cmbAlternatives.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
      this.cmbAlternatives.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
      gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint1.Insets.Bottom = 8;
      gridBagConstraint1.OriginX = 0;
      gridBagConstraint1.OriginY = 0;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.cmbAlternatives, gridBagConstraint1);
      this.cmbAlternatives.Location = new System.Drawing.Point(0, 155);
      this.cmbAlternatives.Name = "cmbAlternatives";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.cmbAlternatives, new System.Drawing.Size(100, 25));
      this.cmbAlternatives.Size = new System.Drawing.Size(485, 25);
      this.cmbAlternatives.TabIndex = 3;
      this.cmbAlternatives.Text = "ultraCombo1";
      // 
      // alternativesBindingSource
      // 
      this.alternativesBindingSource.DataMember = "ALTERNATIVES";
      this.alternativesBindingSource.DataSource = this.scipDataSet;
      // 
      // scipDataSet
      // 
      this.scipDataSet.DataSetName = "SCIPDataSet";
      this.scipDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // btnExecuteFillDriversActivities
      // 
      gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint2.OriginX = 0;
      gridBagConstraint2.OriginY = 3;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.btnExecuteFillDriversActivities, gridBagConstraint2);
      this.btnExecuteFillDriversActivities.Location = new System.Drawing.Point(0, 250);
      this.btnExecuteFillDriversActivities.Name = "btnExecuteFillDriversActivities";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.btnExecuteFillDriversActivities, new System.Drawing.Size(75, 23));
      this.btnExecuteFillDriversActivities.Size = new System.Drawing.Size(485, 23);
      this.btnExecuteFillDriversActivities.TabIndex = 2;
      this.btnExecuteFillDriversActivities.Text = "Fill Drivers and Activities";
      // 
      // btnExecuteRetrieveAssets
      // 
      gridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint3.Insets.Bottom = 8;
      gridBagConstraint3.OriginX = 0;
      gridBagConstraint3.OriginY = 2;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.btnExecuteRetrieveAssets, gridBagConstraint3);
      this.btnExecuteRetrieveAssets.Location = new System.Drawing.Point(0, 219);
      this.btnExecuteRetrieveAssets.Name = "btnExecuteRetrieveAssets";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.btnExecuteRetrieveAssets, new System.Drawing.Size(75, 23));
      this.btnExecuteRetrieveAssets.Size = new System.Drawing.Size(485, 23);
      this.btnExecuteRetrieveAssets.TabIndex = 1;
      this.btnExecuteRetrieveAssets.Text = "Retrieve Assets";
      // 
      // btnExecuteAll
      // 
      gridBagConstraint4.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint4.Insets.Bottom = 8;
      gridBagConstraint4.OriginX = 0;
      gridBagConstraint4.OriginY = 1;
      gridBagConstraint4.WeightX = 1F;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.btnExecuteAll, gridBagConstraint4);
      this.btnExecuteAll.Location = new System.Drawing.Point(0, 188);
      this.btnExecuteAll.Name = "btnExecuteAll";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.btnExecuteAll, new System.Drawing.Size(75, 23));
      this.btnExecuteAll.Size = new System.Drawing.Size(485, 23);
      this.btnExecuteAll.TabIndex = 0;
      this.btnExecuteAll.Text = "Run Entire Model";
      this.btnExecuteAll.Click += new System.EventHandler(this.btnExecuteAll_Click);
      // 
      // alternativesTableAdapter
      // 
      this.alternativesTableAdapter.ClearBeforeFill = true;
      // 
      // ModelPage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(485, 428);
      this.Controls.Add(this.ultraGridBagLayoutPanel1);
      this.Name = "ModelPage";
      this.Load += new System.EventHandler(this.ModelPage_Load);
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
      this.ultraGridBagLayoutPanel1.ResumeLayout(false);
      this.ultraGridBagLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmbAlternatives)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.alternativesBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.scipDataSet)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
    private Infragistics.Win.Misc.UltraButton btnExecuteFillDriversActivities;
    private Infragistics.Win.Misc.UltraButton btnExecuteRetrieveAssets;
    private Infragistics.Win.Misc.UltraButton btnExecuteAll;
    private Infragistics.Win.UltraWinGrid.UltraCombo cmbAlternatives;
    private SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter alternativesTableAdapter;
    private System.Windows.Forms.BindingSource alternativesBindingSource;
    private SCIPDataSet scipDataSet;
  }
}
