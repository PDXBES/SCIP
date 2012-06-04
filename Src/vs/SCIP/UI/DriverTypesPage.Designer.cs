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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ALTERNATIVES", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("alternative_id");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("name");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("description");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("asset_set_id");
            this.ultraGridDriverTypes = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.sCIPDataSet = new UI.SCIPDataSet();
            this.aLTERNATIVESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aLTERNATIVESTableAdapter = new UI.SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter();
            this.aLTERNATIVESBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ultraComboAlternative = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.ultraButtonUpdateDriverTypes = new Infragistics.Win.Misc.UltraButton();
            this.ultraButtonRevertDriverTypes = new Infragistics.Win.Misc.UltraButton();
            this.dRIVERTYPESUPDATEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dRIVER_TYPES_UPDATETableAdapter = new UI.SCIPDataSetTableAdapters.DRIVER_TYPES_UPDATETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridDriverTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboAlternative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dRIVERTYPESUPDATEBindingSource)).BeginInit();
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
            this.ultraGridDriverTypes.Location = new System.Drawing.Point(13, 138);
            this.ultraGridDriverTypes.Name = "ultraGridDriverTypes";
            this.ultraGridDriverTypes.Size = new System.Drawing.Size(905, 187);
            this.ultraGridDriverTypes.TabIndex = 0;
            this.ultraGridDriverTypes.Text = "Driver Types";
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
            ultraGridColumn14.Header.VisiblePosition = 0;
            ultraGridColumn15.Header.VisiblePosition = 1;
            ultraGridColumn16.Header.VisiblePosition = 2;
            ultraGridColumn17.Header.VisiblePosition = 3;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17});
            this.ultraComboAlternative.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.ultraComboAlternative.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraComboAlternative.Location = new System.Drawing.Point(660, 13);
            this.ultraComboAlternative.Name = "ultraComboAlternative";
            this.ultraComboAlternative.Size = new System.Drawing.Size(131, 22);
            this.ultraComboAlternative.TabIndex = 1;
            this.ultraComboAlternative.Text = "Select Alternative";
            this.ultraComboAlternative.ValueChanged += new System.EventHandler(this.ComboAlternativeChanged);
            // 
            // ultraButtonUpdateDriverTypes
            // 
            this.ultraButtonUpdateDriverTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraButtonUpdateDriverTypes.Location = new System.Drawing.Point(772, 331);
            this.ultraButtonUpdateDriverTypes.Name = "ultraButtonUpdateDriverTypes";
            this.ultraButtonUpdateDriverTypes.Size = new System.Drawing.Size(145, 37);
            this.ultraButtonUpdateDriverTypes.TabIndex = 2;
            this.ultraButtonUpdateDriverTypes.Text = "Update Driver Types";
            this.ultraButtonUpdateDriverTypes.Click += new System.EventHandler(this.ultraButtonUpdateDriverTypes_Click);
            // 
            // ultraButtonRevertDriverTypes
            // 
            this.ultraButtonRevertDriverTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraButtonRevertDriverTypes.Location = new System.Drawing.Point(621, 331);
            this.ultraButtonRevertDriverTypes.Name = "ultraButtonRevertDriverTypes";
            this.ultraButtonRevertDriverTypes.Size = new System.Drawing.Size(145, 37);
            this.ultraButtonRevertDriverTypes.TabIndex = 3;
            this.ultraButtonRevertDriverTypes.Text = "Revert Driver Types";
            this.ultraButtonRevertDriverTypes.Click += new System.EventHandler(this.ultraButtonRevertDriverTypes_Click);
            // 
            // dRIVERTYPESUPDATEBindingSource
            // 
            this.dRIVERTYPESUPDATEBindingSource.DataMember = "DRIVER_TYPES_UPDATE";
            this.dRIVERTYPESUPDATEBindingSource.DataSource = this.sCIPDataSet;
            // 
            // dRIVER_TYPES_UPDATETableAdapter
            // 
            this.dRIVER_TYPES_UPDATETableAdapter.ClearBeforeFill = true;
            // 
            // FormDriverTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 380);
            this.Controls.Add(this.ultraButtonRevertDriverTypes);
            this.Controls.Add(this.ultraButtonUpdateDriverTypes);
            this.Controls.Add(this.ultraComboAlternative);
            this.Controls.Add(this.ultraGridDriverTypes);
            this.Name = "FormDriverTypes";
            this.Text = "Driver Types";
            this.Load += new System.EventHandler(this.FormDriverTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridDriverTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboAlternative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dRIVERTYPESUPDATEBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}