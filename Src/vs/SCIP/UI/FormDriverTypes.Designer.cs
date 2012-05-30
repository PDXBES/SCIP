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
            this.ultraGridDriverTypes = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.dRIVERTYPESUPDATEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sCIPDataSet = new UI.SCIPDataSet();
            this.dRIVERTYPESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dRIVER_TYPESTableAdapter = new UI.SCIPDataSetTableAdapters.DRIVER_TYPESTableAdapter();
            this.dRIVER_TYPES_UPDATETableAdapter = new UI.SCIPDataSetTableAdapters.DRIVER_TYPES_UPDATETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridDriverTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dRIVERTYPESUPDATEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dRIVERTYPESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGridDriverTypes
            // 
            this.ultraGridDriverTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraGridDriverTypes.DataSource = this.dRIVERTYPESUPDATEBindingSource;
            ultraGridBand1.CardSettings.CaptionLines = 2;
            ultraGridColumn1.Header.Caption = "driver type id";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.Caption = "activity type id";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.Caption = "Name";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.Caption = "Description";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.Caption = "Hansen activity code";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.Caption = "default cost per ft";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.Header.Caption = "default frequency years";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn8.Header.VisiblePosition = 7;
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
            this.ultraGridDriverTypes.Location = new System.Drawing.Point(13, 67);
            this.ultraGridDriverTypes.Name = "ultraGridDriverTypes";
            this.ultraGridDriverTypes.Size = new System.Drawing.Size(778, 187);
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
            // FormDriverTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 266);
            this.Controls.Add(this.ultraGridDriverTypes);
            this.Name = "FormDriverTypes";
            this.Text = "Driver Types";
            this.Load += new System.EventHandler(this.FormDriverTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridDriverTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dRIVERTYPESUPDATEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dRIVERTYPESBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGridDriverTypes;
        private SCIPDataSet sCIPDataSet;
        private System.Windows.Forms.BindingSource dRIVERTYPESBindingSource;
        private SCIPDataSetTableAdapters.DRIVER_TYPESTableAdapter dRIVER_TYPESTableAdapter;
        private System.Windows.Forms.BindingSource dRIVERTYPESUPDATEBindingSource;
        private SCIPDataSetTableAdapters.DRIVER_TYPES_UPDATETableAdapter dRIVER_TYPES_UPDATETableAdapter;
    }
}