namespace UI
{
    partial class FormDriverTypes
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("driver_type_id");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("activity_type_id");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("name");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("description");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("hansen_activity_code");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("default_cost_per_ft");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("default_frequency_years");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("rank");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("alternative_id");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ALTERNATIVES", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("alternative_id");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("name");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("description");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("asset_set_id");
            this.ultraGridDriverTypes = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.dRIVERTYPESUPDATEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sCIPDataSet = new UI.SCIPDataSet();
            this.dRIVERTYPESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dRIVER_TYPESTableAdapter = new UI.SCIPDataSetTableAdapters.DRIVER_TYPESTableAdapter();
            this.dRIVER_TYPES_UPDATETableAdapter = new UI.SCIPDataSetTableAdapters.DRIVER_TYPES_UPDATETableAdapter();
            this.aLTERNATIVESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aLTERNATIVESTableAdapter = new UI.SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter();
            this.aLTERNATIVESBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ultraComboAlternative = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.ultraButtonUpdateDriverTypes = new Infragistics.Win.Misc.UltraButton();
            this.ultraButtonRevertDriverTypes = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridDriverTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dRIVERTYPESUPDATEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dRIVERTYPESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboAlternative)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGridDriverTypes
            // 
            this.ultraGridDriverTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraGridDriverTypes.DataSource = this.dRIVERTYPESUPDATEBindingSource;
            ultraGridBand1.CardSettings.CaptionLines = 2;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn1.Header.Caption = "driver type id";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn2.Header.Caption = "activity type id";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn3.Header.Caption = "Name";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn4.Header.Caption = "Description";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn5.Header.Caption = "Hansen activity code";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.Caption = "default cost per ft";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.Header.Caption = "default frequency years";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn9.Header.Caption = "alternative id";
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
            this.ultraGridDriverTypes.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraGridDriverTypes.Location = new System.Drawing.Point(13, 138);
            this.ultraGridDriverTypes.Name = "ultraGridDriverTypes";
            this.ultraGridDriverTypes.Size = new System.Drawing.Size(905, 187);
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
            // dRIVERTYPESBindingSource
            // 
            this.dRIVERTYPESBindingSource.DataMember = "DRIVER_TYPES";
            this.dRIVERTYPESBindingSource.DataSource = this.sCIPDataSet;
            // 
            // dRIVER_TYPESTableAdapter
            // 
            this.dRIVER_TYPESTableAdapter.ClearBeforeFill = true;
            // 
            // dRIVER_TYPES_UPDATETableAdapter
            // 
            this.dRIVER_TYPES_UPDATETableAdapter.ClearBeforeFill = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.dRIVERTYPESUPDATEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dRIVERTYPESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboAlternative)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGridDriverTypes;
        private SCIPDataSet sCIPDataSet;
        private System.Windows.Forms.BindingSource dRIVERTYPESBindingSource;
        private SCIPDataSetTableAdapters.DRIVER_TYPESTableAdapter dRIVER_TYPESTableAdapter;
        private System.Windows.Forms.BindingSource dRIVERTYPESUPDATEBindingSource;
        private SCIPDataSetTableAdapters.DRIVER_TYPES_UPDATETableAdapter dRIVER_TYPES_UPDATETableAdapter;
        private System.Windows.Forms.BindingSource aLTERNATIVESBindingSource;
        private SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter aLTERNATIVESTableAdapter;
        private System.Windows.Forms.BindingSource aLTERNATIVESBindingSource1;
        private Infragistics.Win.UltraWinGrid.UltraCombo ultraComboAlternative;
        private Infragistics.Win.Misc.UltraButton ultraButtonUpdateDriverTypes;
        private Infragistics.Win.Misc.UltraButton ultraButtonRevertDriverTypes;
    }
}