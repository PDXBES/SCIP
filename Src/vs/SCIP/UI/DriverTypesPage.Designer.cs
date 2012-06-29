namespace UI
{
    partial class DriverTypesPage
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
      Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DRIVER_TYPES_UPDATE", -1);
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("driver_type_id");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("activity_type_id");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("name");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("description");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("reporting_category");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("hansen_activity_code");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("default_cost_per_ft");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("default_frequency_years");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("rank");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("alternative_id");
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint6 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ALTERNATIVES", -1);
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("alternative_id");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("name");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("description");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("asset_set_id");
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint5 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint3 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint4 = new Infragistics.Win.Layout.GridBagConstraint();
      this.ultraGridDriverTypes = new Infragistics.Win.UltraWinGrid.UltraGrid();
      this.dRIVERTYPESUPDATEBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.sCIPDataSet = new UI.SCIPDataSet();
      this.aLTERNATIVESBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.aLTERNATIVESTableAdapter = new UI.SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter();
      this.aLTERNATIVESBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
      this.ultraComboAlternative = new Infragistics.Win.UltraWinGrid.UltraCombo();
      this.ultraButtonUpdateDriverTypes = new Infragistics.Win.Misc.UltraButton();
      this.ultraButtonRevertDriverTypes = new Infragistics.Win.Misc.UltraButton();
      this.dRIVER_TYPES_UPDATETableAdapter = new UI.SCIPDataSetTableAdapters.DRIVER_TYPES_UPDATETableAdapter();
      this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
      this.pnlActionButtons = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
      this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridDriverTypes)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dRIVERTYPESUPDATEBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ultraComboAlternative)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
      this.ultraGridBagLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pnlActionButtons)).BeginInit();
      this.pnlActionButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // ultraGridDriverTypes
      // 
      this.ultraGridDriverTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ultraGridDriverTypes.DataSource = this.dRIVERTYPESUPDATEBindingSource;
      ultraGridBand1.CardSettings.CaptionLines = 2;
      ultraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
      ultraGridColumn11.Header.Caption = "driver type id";
      ultraGridColumn11.Header.VisiblePosition = 0;
      ultraGridColumn11.Hidden = true;
      ultraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
      ultraGridColumn12.Header.Caption = "activity type id";
      ultraGridColumn12.Header.VisiblePosition = 1;
      ultraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
      ultraGridColumn13.Header.Caption = "Name";
      ultraGridColumn13.Header.VisiblePosition = 2;
      ultraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
      ultraGridColumn18.Header.Caption = "Description";
      ultraGridColumn18.Header.VisiblePosition = 3;
      ultraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
      ultraGridColumn19.Header.VisiblePosition = 4;
      ultraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
      ultraGridColumn20.Header.Caption = "Hansen activity code";
      ultraGridColumn20.Header.VisiblePosition = 5;
      ultraGridColumn21.Header.Caption = "default cost per ft";
      ultraGridColumn21.Header.VisiblePosition = 6;
      ultraGridColumn22.Header.Caption = "default frequency years";
      ultraGridColumn22.Header.VisiblePosition = 7;
      ultraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
      ultraGridColumn23.Header.VisiblePosition = 8;
      ultraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
      ultraGridColumn24.Header.Caption = "alternative id";
      ultraGridColumn24.Header.VisiblePosition = 9;
      ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24});
      this.ultraGridDriverTypes.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
      gridBagConstraint6.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint6.Insets.Bottom = 4;
      gridBagConstraint6.OriginX = 0;
      gridBagConstraint6.OriginY = 1;
      gridBagConstraint6.SpanX = 3;
      gridBagConstraint6.WeightY = 1F;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ultraGridDriverTypes, gridBagConstraint6);
      this.ultraGridDriverTypes.Location = new System.Drawing.Point(0, 31);
      this.ultraGridDriverTypes.Name = "ultraGridDriverTypes";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ultraGridDriverTypes, new System.Drawing.Size(905, 187));
      this.ultraGridDriverTypes.Size = new System.Drawing.Size(620, 322);
      this.ultraGridDriverTypes.TabIndex = 0;
      this.ultraGridDriverTypes.Text = "Driver Types";
      // 
      // dRIVERTYPESUPDATEBindingSource
      // 
      this.dRIVERTYPESUPDATEBindingSource.DataMember = "DRIVER_TYPES_UPDATE";
      this.dRIVERTYPESUPDATEBindingSource.DataSource = this.sCIPDataSet;
      // 
      // sCIPDataSet
      // 
      this.sCIPDataSet.DataSetName = "SCIPDataSet";
      this.sCIPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // aLTERNATIVESBindingSource
      // 
      this.aLTERNATIVESBindingSource.DataMember = "ALTERNATIVES";
      this.aLTERNATIVESBindingSource.DataSource = this.sCIPDataSet;
      // 
      // aLTERNATIVESTableAdapter
      // 
      this.aLTERNATIVESTableAdapter.ClearBeforeFill = true;
      // 
      // aLTERNATIVESBindingSource1
      // 
      this.aLTERNATIVESBindingSource1.DataMember = "ALTERNATIVES";
      this.aLTERNATIVESBindingSource1.DataSource = this.sCIPDataSet;
      // 
      // ultraComboAlternative
      // 
      this.ultraComboAlternative.DataSource = this.aLTERNATIVESBindingSource;
      ultraGridColumn1.Header.VisiblePosition = 0;
      ultraGridColumn2.Header.VisiblePosition = 1;
      ultraGridColumn3.Header.VisiblePosition = 2;
      ultraGridColumn4.Header.VisiblePosition = 3;
      ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
      this.ultraComboAlternative.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
      this.ultraComboAlternative.DisplayMember = "description";
      this.ultraComboAlternative.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      gridBagConstraint5.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint5.Insets.Bottom = 8;
      gridBagConstraint5.OriginX = 1;
      gridBagConstraint5.OriginY = 0;
      gridBagConstraint5.WeightX = 1F;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ultraComboAlternative, gridBagConstraint5);
      this.ultraComboAlternative.Location = new System.Drawing.Point(100, 0);
      this.ultraComboAlternative.Name = "ultraComboAlternative";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ultraComboAlternative, new System.Drawing.Size(131, 22));
      this.ultraComboAlternative.Size = new System.Drawing.Size(520, 25);
      this.ultraComboAlternative.TabIndex = 1;
      this.ultraComboAlternative.Text = "Select Alternative";
      this.ultraComboAlternative.ValueMember = "alternative_id";
      this.ultraComboAlternative.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.ultraComboAlternative_BeforeDropDown);
      this.ultraComboAlternative.ValueChanged += new System.EventHandler(this.ComboAlternativeChanged);
      // 
      // ultraButtonUpdateDriverTypes
      // 
      this.ultraButtonUpdateDriverTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint1.OriginX = 1;
      gridBagConstraint1.OriginY = 0;
      this.pnlActionButtons.SetGridBagConstraint(this.ultraButtonUpdateDriverTypes, gridBagConstraint1);
      this.ultraButtonUpdateDriverTypes.Location = new System.Drawing.Point(501, 0);
      this.ultraButtonUpdateDriverTypes.Name = "ultraButtonUpdateDriverTypes";
      this.pnlActionButtons.SetPreferredSize(this.ultraButtonUpdateDriverTypes, new System.Drawing.Size(119, 23));
      this.ultraButtonUpdateDriverTypes.Size = new System.Drawing.Size(119, 23);
      this.ultraButtonUpdateDriverTypes.TabIndex = 2;
      this.ultraButtonUpdateDriverTypes.Text = "Update";
      this.ultraButtonUpdateDriverTypes.Click += new System.EventHandler(this.ultraButtonUpdateDriverTypes_Click);
      // 
      // ultraButtonRevertDriverTypes
      // 
      this.ultraButtonRevertDriverTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      gridBagConstraint2.Anchor = Infragistics.Win.Layout.AnchorType.Right;
      gridBagConstraint2.OriginX = 0;
      gridBagConstraint2.OriginY = 0;
      gridBagConstraint2.WeightX = 1F;
      this.pnlActionButtons.SetGridBagConstraint(this.ultraButtonRevertDriverTypes, gridBagConstraint2);
      this.ultraButtonRevertDriverTypes.Location = new System.Drawing.Point(382, 0);
      this.ultraButtonRevertDriverTypes.Name = "ultraButtonRevertDriverTypes";
      this.pnlActionButtons.SetPreferredSize(this.ultraButtonRevertDriverTypes, new System.Drawing.Size(119, 23));
      this.ultraButtonRevertDriverTypes.Size = new System.Drawing.Size(119, 23);
      this.ultraButtonRevertDriverTypes.TabIndex = 3;
      this.ultraButtonRevertDriverTypes.Text = "Revert";
      this.ultraButtonRevertDriverTypes.Click += new System.EventHandler(this.ultraButtonRevertDriverTypes_Click);
      // 
      // dRIVER_TYPES_UPDATETableAdapter
      // 
      this.dRIVER_TYPES_UPDATETableAdapter.ClearBeforeFill = true;
      // 
      // ultraGridBagLayoutPanel1
      // 
      this.ultraGridBagLayoutPanel1.Controls.Add(this.pnlActionButtons);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.ultraLabel1);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.ultraComboAlternative);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.ultraGridDriverTypes);
      this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
      this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(620, 380);
      this.ultraGridBagLayoutPanel1.TabIndex = 4;
      // 
      // pnlActionButtons
      // 
      this.pnlActionButtons.Controls.Add(this.ultraButtonUpdateDriverTypes);
      this.pnlActionButtons.Controls.Add(this.ultraButtonRevertDriverTypes);
      gridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint3.OriginX = 0;
      gridBagConstraint3.OriginY = 2;
      gridBagConstraint3.SpanX = 3;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.pnlActionButtons, gridBagConstraint3);
      this.pnlActionButtons.Location = new System.Drawing.Point(0, 357);
      this.pnlActionButtons.Name = "pnlActionButtons";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.pnlActionButtons, new System.Drawing.Size(200, 23));
      this.pnlActionButtons.Size = new System.Drawing.Size(620, 23);
      this.pnlActionButtons.TabIndex = 5;
      // 
      // ultraLabel1
      // 
      appearance1.TextVAlignAsString = "Middle";
      this.ultraLabel1.Appearance = appearance1;
      gridBagConstraint4.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint4.Insets.Bottom = 8;
      gridBagConstraint4.OriginX = 0;
      gridBagConstraint4.OriginY = 0;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ultraLabel1, gridBagConstraint4);
      this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
      this.ultraLabel1.Name = "ultraLabel1";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ultraLabel1, new System.Drawing.Size(100, 23));
      this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
      this.ultraLabel1.TabIndex = 4;
      this.ultraLabel1.Text = "Alternative";
      // 
      // DriverTypesPage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(620, 380);
      this.Controls.Add(this.ultraGridBagLayoutPanel1);
      this.Name = "DriverTypesPage";
      this.Text = "Driver Types";
      
      this.Load += new System.EventHandler(this.FormDriverTypes_Load);
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridDriverTypes)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dRIVERTYPESUPDATEBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ultraComboAlternative)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
      this.ultraGridBagLayoutPanel1.ResumeLayout(false);
      this.ultraGridBagLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pnlActionButtons)).EndInit();
      this.pnlActionButtons.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGridDriverTypes;
        private SCIPDataSet sCIPDataSet;
        private System.Windows.Forms.BindingSource aLTERNATIVESBindingSource;
        private SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter aLTERNATIVESTableAdapter;
        private System.Windows.Forms.BindingSource aLTERNATIVESBindingSource1;
        private Infragistics.Win.UltraWinGrid.UltraCombo ultraComboAlternative;
        private Infragistics.Win.Misc.UltraButton ultraButtonUpdateDriverTypes;
        private Infragistics.Win.Misc.UltraButton ultraButtonRevertDriverTypes;
        private System.Windows.Forms.BindingSource dRIVERTYPESUPDATEBindingSource;
        private SCIPDataSetTableAdapters.DRIVER_TYPES_UPDATETableAdapter dRIVER_TYPES_UPDATETableAdapter;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel pnlActionButtons;
    }
}