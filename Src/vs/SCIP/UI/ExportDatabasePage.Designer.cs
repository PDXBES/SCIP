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
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
      this.ultraButtonExport = new Infragistics.Win.Misc.UltraButton();
      this.ultraActivityIndicator1 = new Infragistics.Win.UltraActivityIndicator.UltraActivityIndicator();
      this.backgroundWorkerExport = new System.ComponentModel.BackgroundWorker();
      this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
      this.ultraGridBagLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // ultraButtonExport
      // 
      gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint2.Insets.Bottom = 8;
      gridBagConstraint2.OriginX = 0;
      gridBagConstraint2.OriginY = 0;
      gridBagConstraint2.WeightX = 1F;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ultraButtonExport, gridBagConstraint2);
      this.ultraButtonExport.Location = new System.Drawing.Point(0, 204);
      this.ultraButtonExport.Name = "ultraButtonExport";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ultraButtonExport, new System.Drawing.Size(75, 23));
      this.ultraButtonExport.Size = new System.Drawing.Size(606, 23);
      this.ultraButtonExport.TabIndex = 0;
      this.ultraButtonExport.Text = "Export!";
      this.ultraButtonExport.Click += new System.EventHandler(this.ultraButtonExport_Click);
      // 
      // ultraActivityIndicator1
      // 
      this.ultraActivityIndicator1.CausesValidation = true;
      gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint1.OriginX = 0;
      gridBagConstraint1.OriginY = 1;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ultraActivityIndicator1, gridBagConstraint1);
      this.ultraActivityIndicator1.Location = new System.Drawing.Point(0, 235);
      this.ultraActivityIndicator1.Name = "ultraActivityIndicator1";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ultraActivityIndicator1, new System.Drawing.Size(268, 23));
      this.ultraActivityIndicator1.Size = new System.Drawing.Size(606, 23);
      this.ultraActivityIndicator1.TabIndex = 1;
      this.ultraActivityIndicator1.TabStop = true;
      // 
      // backgroundWorkerExport
      // 
      this.backgroundWorkerExport.WorkerReportsProgress = true;
      this.backgroundWorkerExport.WorkerSupportsCancellation = true;
      this.backgroundWorkerExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerExport_DoWork);
      this.backgroundWorkerExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
      // 
      // ultraGridBagLayoutPanel1
      // 
      this.ultraGridBagLayoutPanel1.Controls.Add(this.ultraButtonExport);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.ultraActivityIndicator1);
      this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
      this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(606, 462);
      this.ultraGridBagLayoutPanel1.TabIndex = 2;
      // 
      // ExportDatabasePage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(606, 462);
      this.Controls.Add(this.ultraGridBagLayoutPanel1);
      this.Name = "ExportDatabasePage";
      this.Text = "FormExportDatabase";
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
      this.ultraGridBagLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton ultraButtonExport;
        private Infragistics.Win.UltraActivityIndicator.UltraActivityIndicator ultraActivityIndicator1;
        public System.ComponentModel.BackgroundWorker backgroundWorkerExport;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
    }
}