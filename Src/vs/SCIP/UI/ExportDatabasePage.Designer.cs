namespace UI
{
    partial class ExportDatabasePage
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
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint5 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint3 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ALTERNATIVES", -1);
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("alternative_id");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("name");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("description");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("asset_set_id");
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint4 = new Infragistics.Win.Layout.GridBagConstraint();
      this.ultraButtonExport = new Infragistics.Win.Misc.UltraButton();
      this.backgroundWorkerExport = new System.ComponentModel.BackgroundWorker();
      this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
      this.lblStatus = new Infragistics.Win.Misc.UltraLabel();
      this.progress = new Infragistics.Win.UltraWinProgressBar.UltraProgressBar();
      this.labelSelectAlternative = new Infragistics.Win.Misc.UltraLabel();
      this.comboAlternativeID = new Infragistics.Win.UltraWinGrid.UltraCombo();
      this.aLTERNATIVESBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.sCIPDataSet = new UI.SCIPDataSet();
      this.aLTERNATIVESTableAdapter = new UI.SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
      this.ultraGridBagLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.comboAlternativeID)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).BeginInit();
      this.SuspendLayout();
      // 
      // ultraButtonExport
      // 
      gridBagConstraint5.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint5.Insets.Bottom = 8;
      gridBagConstraint5.OriginX = 0;
      gridBagConstraint5.OriginY = 2;
      gridBagConstraint5.WeightX = 1F;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ultraButtonExport, gridBagConstraint5);
      this.ultraButtonExport.Location = new System.Drawing.Point(0, 216);
      this.ultraButtonExport.Name = "ultraButtonExport";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ultraButtonExport, new System.Drawing.Size(75, 23));
      this.ultraButtonExport.Size = new System.Drawing.Size(606, 23);
      this.ultraButtonExport.TabIndex = 0;
      this.ultraButtonExport.Text = "Export!";
      this.ultraButtonExport.Click += new System.EventHandler(this.ultraButtonExport_Click);
      // 
      // backgroundWorkerExport
      // 
      this.backgroundWorkerExport.WorkerReportsProgress = true;
      this.backgroundWorkerExport.WorkerSupportsCancellation = true;
      this.backgroundWorkerExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerExport_DoWork);
      this.backgroundWorkerExport.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerExport_ProgressChanged);
      this.backgroundWorkerExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
      // 
      // ultraGridBagLayoutPanel1
      // 
      this.ultraGridBagLayoutPanel1.Controls.Add(this.lblStatus);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.progress);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.labelSelectAlternative);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.comboAlternativeID);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.ultraButtonExport);
      this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
      this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(606, 462);
      this.ultraGridBagLayoutPanel1.TabIndex = 2;
      // 
      // lblStatus
      // 
      gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint1.OriginX = 0;
      gridBagConstraint1.OriginY = 4;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.lblStatus, gridBagConstraint1);
      this.lblStatus.Location = new System.Drawing.Point(0, 278);
      this.lblStatus.Name = "lblStatus";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.lblStatus, new System.Drawing.Size(100, 23));
      this.lblStatus.Size = new System.Drawing.Size(606, 23);
      this.lblStatus.TabIndex = 5;
      this.lblStatus.Text = "ultraLabel1";
      // 
      // progress
      // 
      gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint2.Insets.Bottom = 8;
      gridBagConstraint2.OriginX = 0;
      gridBagConstraint2.OriginY = 3;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.progress, gridBagConstraint2);
      this.progress.Location = new System.Drawing.Point(0, 247);
      this.progress.Name = "progress";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.progress, new System.Drawing.Size(75, 23));
      this.progress.Size = new System.Drawing.Size(606, 23);
      this.progress.TabIndex = 4;
      this.progress.Text = "[Formatted]";
      // 
      // labelSelectAlternative
      // 
      gridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint3.OriginX = 0;
      gridBagConstraint3.OriginY = 0;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.labelSelectAlternative, gridBagConstraint3);
      this.labelSelectAlternative.Location = new System.Drawing.Point(0, 160);
      this.labelSelectAlternative.Name = "labelSelectAlternative";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.labelSelectAlternative, new System.Drawing.Size(100, 23));
      this.labelSelectAlternative.Size = new System.Drawing.Size(606, 23);
      this.labelSelectAlternative.TabIndex = 3;
      this.labelSelectAlternative.Text = "Select Alternative";
      // 
      // comboAlternativeID
      // 
      this.comboAlternativeID.DataSource = this.aLTERNATIVESBindingSource;
      ultraGridColumn9.Header.VisiblePosition = 0;
      ultraGridColumn10.Header.VisiblePosition = 1;
      ultraGridColumn11.Header.VisiblePosition = 2;
      ultraGridColumn12.Header.VisiblePosition = 3;
      ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12});
      this.comboAlternativeID.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
      this.comboAlternativeID.DisplayMember = "name";
      this.comboAlternativeID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      gridBagConstraint4.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint4.Insets.Bottom = 8;
      gridBagConstraint4.OriginX = 0;
      gridBagConstraint4.OriginY = 1;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.comboAlternativeID, gridBagConstraint4);
      this.comboAlternativeID.Location = new System.Drawing.Point(0, 183);
      this.comboAlternativeID.Name = "comboAlternativeID";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.comboAlternativeID, new System.Drawing.Size(100, 25));
      this.comboAlternativeID.Size = new System.Drawing.Size(606, 25);
      this.comboAlternativeID.TabIndex = 2;
      this.comboAlternativeID.Text = "Select Alternative";
      this.comboAlternativeID.ValueMember = "alternative_id";
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
      // ExportDatabasePage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(606, 462);
      this.Controls.Add(this.ultraGridBagLayoutPanel1);
      this.Name = "ExportDatabasePage";
      this.Text = "FormExportDatabase";
      this.Load += new System.EventHandler(this.ExportDatabasePage_Load);
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
      this.ultraGridBagLayoutPanel1.ResumeLayout(false);
      this.ultraGridBagLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.comboAlternativeID)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton ultraButtonExport;
        public System.ComponentModel.BackgroundWorker backgroundWorkerExport;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private Infragistics.Win.UltraWinGrid.UltraCombo comboAlternativeID;
        private SCIPDataSet sCIPDataSet;
        private System.Windows.Forms.BindingSource aLTERNATIVESBindingSource;
        private SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter aLTERNATIVESTableAdapter;
        private Infragistics.Win.Misc.UltraLabel labelSelectAlternative;
        private Infragistics.Win.UltraWinProgressBar.UltraProgressBar progress;
        private Infragistics.Win.Misc.UltraLabel lblStatus;
    }
}