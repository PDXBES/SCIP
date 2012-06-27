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
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint3 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint4 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint5 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint6 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
      Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ALTERNATIVES", -1);
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("alternative_id");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("name");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("description");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("asset_set_id");
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
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint7 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint8 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint9 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint10 = new Infragistics.Win.Layout.GridBagConstraint();
      this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
      this.activityIndicator = new Infragistics.Win.UltraActivityIndicator.UltraActivityIndicator();
      this.txtMessages = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
      this.chkFillActivities = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
      this.chkFillDrivers = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
      this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
      this.txtNumYears = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
      this.cmbAlternatives = new Infragistics.Win.UltraWinGrid.UltraCombo();
      this.alternativesBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.scipDataSet = new UI.SCIPDataSet();
      this.btnExecuteFillDriversActivities = new Infragistics.Win.Misc.UltraButton();
      this.btnExecuteRetrieveAssets = new Infragistics.Win.Misc.UltraButton();
      this.btnExecuteAll = new Infragistics.Win.Misc.UltraButton();
      this.alternativesTableAdapter = new UI.SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter();
      this.bkgWorker = new System.ComponentModel.BackgroundWorker();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
      this.ultraGridBagLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtMessages)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chkFillActivities)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chkFillDrivers)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtNumYears)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cmbAlternatives)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.alternativesBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.scipDataSet)).BeginInit();
      this.SuspendLayout();
      // 
      // ultraGridBagLayoutPanel1
      // 
      this.ultraGridBagLayoutPanel1.Controls.Add(this.activityIndicator);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.txtMessages);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.chkFillActivities);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.chkFillDrivers);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.ultraLabel1);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.txtNumYears);
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
      // activityIndicator
      // 
      this.activityIndicator.AnimationSpeed = 20;
      this.activityIndicator.CausesValidation = true;
      gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint1.Insets.Bottom = 8;
      gridBagConstraint1.OriginX = 0;
      gridBagConstraint1.OriginY = 7;
      gridBagConstraint1.SpanX = 2;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.activityIndicator, gridBagConstraint1);
      this.activityIndicator.Location = new System.Drawing.Point(0, 210);
      this.activityIndicator.MarqueeAnimationStyle = Infragistics.Win.UltraActivityIndicator.MarqueeAnimationStyle.BounceBack;
      this.activityIndicator.Name = "activityIndicator";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.activityIndicator, new System.Drawing.Size(100, 23));
      this.activityIndicator.Size = new System.Drawing.Size(485, 23);
      this.activityIndicator.TabIndex = 12;
      this.activityIndicator.TabStop = true;
      // 
      // txtMessages
      // 
      gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint2.OriginX = 0;
      gridBagConstraint2.OriginY = 8;
      gridBagConstraint2.SpanX = 2;
      gridBagConstraint2.WeightY = 1F;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.txtMessages, gridBagConstraint2);
      this.txtMessages.Location = new System.Drawing.Point(0, 241);
      this.txtMessages.Multiline = true;
      this.txtMessages.Name = "txtMessages";
      this.txtMessages.NullText = "Waiting for activity.";
      appearance1.FontData.ItalicAsString = "True";
      appearance1.ForeColor = System.Drawing.Color.Silver;
      this.txtMessages.NullTextAppearance = appearance1;
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.txtMessages, new System.Drawing.Size(100, 24));
      this.txtMessages.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtMessages.Size = new System.Drawing.Size(485, 187);
      this.txtMessages.TabIndex = 11;
      // 
      // chkFillActivities
      // 
      this.chkFillActivities.Checked = true;
      this.chkFillActivities.CheckState = System.Windows.Forms.CheckState.Checked;
      gridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint3.Insets.Bottom = 8;
      gridBagConstraint3.OriginX = 0;
      gridBagConstraint3.OriginY = 6;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.chkFillActivities, gridBagConstraint3);
      this.chkFillActivities.Location = new System.Drawing.Point(0, 182);
      this.chkFillActivities.Name = "chkFillActivities";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.chkFillActivities, new System.Drawing.Size(120, 20));
      this.chkFillActivities.Size = new System.Drawing.Size(120, 20);
      this.chkFillActivities.TabIndex = 7;
      this.chkFillActivities.Text = "Fill activities";
      // 
      // chkFillDrivers
      // 
      this.chkFillDrivers.Checked = true;
      this.chkFillDrivers.CheckState = System.Windows.Forms.CheckState.Checked;
      gridBagConstraint4.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint4.Insets.Bottom = 4;
      gridBagConstraint4.OriginX = 0;
      gridBagConstraint4.OriginY = 5;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.chkFillDrivers, gridBagConstraint4);
      this.chkFillDrivers.Location = new System.Drawing.Point(0, 158);
      this.chkFillDrivers.Name = "chkFillDrivers";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.chkFillDrivers, new System.Drawing.Size(120, 20));
      this.chkFillDrivers.Size = new System.Drawing.Size(120, 20);
      this.chkFillDrivers.TabIndex = 6;
      this.chkFillDrivers.Text = "Fill drivers";
      // 
      // ultraLabel1
      // 
      this.ultraLabel1.AutoSize = true;
      gridBagConstraint5.OriginX = 0;
      gridBagConstraint5.OriginY = 1;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ultraLabel1, gridBagConstraint5);
      this.ultraLabel1.Location = new System.Drawing.Point(10, 37);
      this.ultraLabel1.Name = "ultraLabel1";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ultraLabel1, new System.Drawing.Size(100, 23));
      this.ultraLabel1.Size = new System.Drawing.Size(88, 17);
      this.ultraLabel1.TabIndex = 5;
      this.ultraLabel1.Text = "Number of Years";
      // 
      // txtNumYears
      // 
      gridBagConstraint6.Anchor = Infragistics.Win.Layout.AnchorType.Left;
      gridBagConstraint6.Insets.Bottom = 8;
      gridBagConstraint6.OriginX = 1;
      gridBagConstraint6.OriginY = 1;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.txtNumYears, gridBagConstraint6);
      this.txtNumYears.Location = new System.Drawing.Point(120, 33);
      this.txtNumYears.MaskInput = "nnn.nn";
      this.txtNumYears.Name = "txtNumYears";
      this.txtNumYears.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.txtNumYears, new System.Drawing.Size(100, 24));
      this.txtNumYears.Size = new System.Drawing.Size(100, 24);
      this.txtNumYears.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
      this.txtNumYears.SpinIncrement = 1;
      this.txtNumYears.TabIndex = 4;
      // 
      // cmbAlternatives
      // 
      this.cmbAlternatives.DataSource = this.alternativesBindingSource;
      appearance2.BackColor = System.Drawing.SystemColors.Window;
      appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
      this.cmbAlternatives.DisplayLayout.Appearance = appearance2;
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
      appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
      appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
      appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
      appearance3.BorderColor = System.Drawing.SystemColors.Window;
      this.cmbAlternatives.DisplayLayout.GroupByBox.Appearance = appearance3;
      appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
      this.cmbAlternatives.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
      this.cmbAlternatives.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
      appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
      appearance5.BackColor2 = System.Drawing.SystemColors.Control;
      appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
      appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
      this.cmbAlternatives.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
      this.cmbAlternatives.DisplayLayout.MaxColScrollRegions = 1;
      this.cmbAlternatives.DisplayLayout.MaxRowScrollRegions = 1;
      appearance6.BackColor = System.Drawing.SystemColors.Window;
      appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
      this.cmbAlternatives.DisplayLayout.Override.ActiveCellAppearance = appearance6;
      appearance7.BackColor = System.Drawing.SystemColors.Highlight;
      appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
      this.cmbAlternatives.DisplayLayout.Override.ActiveRowAppearance = appearance7;
      this.cmbAlternatives.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
      this.cmbAlternatives.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
      appearance8.BackColor = System.Drawing.SystemColors.Window;
      this.cmbAlternatives.DisplayLayout.Override.CardAreaAppearance = appearance8;
      appearance9.BorderColor = System.Drawing.Color.Silver;
      appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
      this.cmbAlternatives.DisplayLayout.Override.CellAppearance = appearance9;
      this.cmbAlternatives.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
      this.cmbAlternatives.DisplayLayout.Override.CellPadding = 0;
      appearance10.BackColor = System.Drawing.SystemColors.Control;
      appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
      appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
      appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
      appearance10.BorderColor = System.Drawing.SystemColors.Window;
      this.cmbAlternatives.DisplayLayout.Override.GroupByRowAppearance = appearance10;
      appearance11.TextHAlignAsString = "Left";
      this.cmbAlternatives.DisplayLayout.Override.HeaderAppearance = appearance11;
      this.cmbAlternatives.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
      this.cmbAlternatives.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
      appearance12.BackColor = System.Drawing.SystemColors.Window;
      appearance12.BorderColor = System.Drawing.Color.Silver;
      this.cmbAlternatives.DisplayLayout.Override.RowAppearance = appearance12;
      this.cmbAlternatives.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
      appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
      this.cmbAlternatives.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
      this.cmbAlternatives.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
      this.cmbAlternatives.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
      this.cmbAlternatives.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
      gridBagConstraint7.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint7.Insets.Bottom = 8;
      gridBagConstraint7.OriginX = 0;
      gridBagConstraint7.OriginY = 0;
      gridBagConstraint7.SpanX = 2;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.cmbAlternatives, gridBagConstraint7);
      this.cmbAlternatives.Location = new System.Drawing.Point(0, 0);
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
      gridBagConstraint8.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint8.Insets.Bottom = 8;
      gridBagConstraint8.OriginX = 0;
      gridBagConstraint8.OriginY = 4;
      gridBagConstraint8.SpanX = 2;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.btnExecuteFillDriversActivities, gridBagConstraint8);
      this.btnExecuteFillDriversActivities.Location = new System.Drawing.Point(0, 127);
      this.btnExecuteFillDriversActivities.Name = "btnExecuteFillDriversActivities";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.btnExecuteFillDriversActivities, new System.Drawing.Size(75, 23));
      this.btnExecuteFillDriversActivities.Size = new System.Drawing.Size(485, 23);
      this.btnExecuteFillDriversActivities.TabIndex = 2;
      this.btnExecuteFillDriversActivities.Text = "Fill Drivers and Activities";
      this.btnExecuteFillDriversActivities.Click += new System.EventHandler(this.btnExecuteFillDriversActivities_Click);
      // 
      // btnExecuteRetrieveAssets
      // 
      gridBagConstraint9.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint9.Insets.Bottom = 8;
      gridBagConstraint9.OriginX = 0;
      gridBagConstraint9.OriginY = 3;
      gridBagConstraint9.SpanX = 2;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.btnExecuteRetrieveAssets, gridBagConstraint9);
      this.btnExecuteRetrieveAssets.Location = new System.Drawing.Point(0, 96);
      this.btnExecuteRetrieveAssets.Name = "btnExecuteRetrieveAssets";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.btnExecuteRetrieveAssets, new System.Drawing.Size(75, 23));
      this.btnExecuteRetrieveAssets.Size = new System.Drawing.Size(485, 23);
      this.btnExecuteRetrieveAssets.TabIndex = 1;
      this.btnExecuteRetrieveAssets.Text = "Retrieve Assets";
      // 
      // btnExecuteAll
      // 
      gridBagConstraint10.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint10.Insets.Bottom = 8;
      gridBagConstraint10.OriginX = 0;
      gridBagConstraint10.OriginY = 2;
      gridBagConstraint10.SpanX = 2;
      gridBagConstraint10.WeightX = 1F;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.btnExecuteAll, gridBagConstraint10);
      this.btnExecuteAll.Location = new System.Drawing.Point(0, 65);
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
      // bkgWorker
      // 
      this.bkgWorker.WorkerReportsProgress = true;
      this.bkgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgWorker_DoWork);
      this.bkgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bkgWorker_ProgressChanged);
      this.bkgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgWorker_RunWorkerCompleted);
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
      ((System.ComponentModel.ISupportInitialize)(this.txtMessages)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chkFillActivities)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chkFillDrivers)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtNumYears)).EndInit();
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
    private Infragistics.Win.Misc.UltraLabel ultraLabel1;
    private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtNumYears;
    private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkFillActivities;
    private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkFillDrivers;
    private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMessages;
    private System.ComponentModel.BackgroundWorker bkgWorker;
    private Infragistics.Win.UltraActivityIndicator.UltraActivityIndicator activityIndicator;
  }
}
