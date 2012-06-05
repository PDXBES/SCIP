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
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint3 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
      this.ultraButtonExport = new Infragistics.Win.Misc.UltraButton();
      this.backgroundWorkerExport = new System.ComponentModel.BackgroundWorker();
      this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
      this.lblStatus = new Infragistics.Win.Misc.UltraLabel();
      this.progress = new Infragistics.Win.UltraWinProgressBar.UltraProgressBar();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
      this.ultraGridBagLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // ultraButtonExport
      // 
      gridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint3.Insets.Bottom = 8;
      gridBagConstraint3.OriginX = 0;
      gridBagConstraint3.OriginY = 0;
      gridBagConstraint3.WeightX = 1F;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ultraButtonExport, gridBagConstraint3);
      this.ultraButtonExport.Location = new System.Drawing.Point(0, 0);
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
      this.ultraGridBagLayoutPanel1.Controls.Add(this.progress);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.lblStatus);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.ultraButtonExport);
      this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
      this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(606, 462);
      this.ultraGridBagLayoutPanel1.TabIndex = 2;
      // 
      // lblStatus
      // 
      gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint2.OriginX = 0;
      gridBagConstraint2.OriginY = 2;
      gridBagConstraint2.WeightY = 1F;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.lblStatus, gridBagConstraint2);
      this.lblStatus.Location = new System.Drawing.Point(0, 62);
      this.lblStatus.Name = "lblStatus";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.lblStatus, new System.Drawing.Size(100, 23));
      this.lblStatus.Size = new System.Drawing.Size(606, 400);
      this.lblStatus.TabIndex = 2;
      this.lblStatus.Text = "ultraLabel1";
      // 
      // progress
      // 
      gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint1.Insets.Bottom = 8;
      gridBagConstraint1.OriginX = 0;
      gridBagConstraint1.OriginY = 1;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.progress, gridBagConstraint1);
      this.progress.Location = new System.Drawing.Point(0, 31);
      this.progress.Name = "progress";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.progress, new System.Drawing.Size(75, 23));
      this.progress.Size = new System.Drawing.Size(606, 23);
      this.progress.TabIndex = 3;
      this.progress.Text = "[Formatted]";
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
      this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton ultraButtonExport;
        public System.ComponentModel.BackgroundWorker backgroundWorkerExport;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private Infragistics.Win.Misc.UltraLabel lblStatus;
        private Infragistics.Win.UltraWinProgressBar.UltraProgressBar progress;
    }
}