namespace UI
{
    partial class FormExportDatabase
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
            this.ultraButtonExport = new Infragistics.Win.Misc.UltraButton();
            this.ultraActivityIndicator1 = new Infragistics.Win.UltraActivityIndicator.UltraActivityIndicator();
            this.backgroundWorkerExport = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // ultraButtonExport
            // 
            this.ultraButtonExport.Location = new System.Drawing.Point(205, 13);
            this.ultraButtonExport.Name = "ultraButtonExport";
            this.ultraButtonExport.Size = new System.Drawing.Size(75, 23);
            this.ultraButtonExport.TabIndex = 0;
            this.ultraButtonExport.Text = "Export!";
            this.ultraButtonExport.Click += new System.EventHandler(this.ultraButtonExport_Click);
            // 
            // ultraActivityIndicator1
            // 
            this.ultraActivityIndicator1.CausesValidation = true;
            this.ultraActivityIndicator1.Location = new System.Drawing.Point(12, 150);
            this.ultraActivityIndicator1.Name = "ultraActivityIndicator1";
            this.ultraActivityIndicator1.Size = new System.Drawing.Size(268, 23);
            this.ultraActivityIndicator1.TabIndex = 1;
            this.ultraActivityIndicator1.TabStop = true;
            // 
            // backgroundWorkerExport
            // 
            this.backgroundWorkerExport.WorkerReportsProgress = true;
            this.backgroundWorkerExport.WorkerSupportsCancellation = true;
            this.backgroundWorkerExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerExport_DoWork);
            this.backgroundWorkerExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            // 
            // FormExportDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.ultraActivityIndicator1);
            this.Controls.Add(this.ultraButtonExport);
            this.Name = "FormExportDatabase";
            this.Text = "FormExportDatabase";
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton ultraButtonExport;
        private Infragistics.Win.UltraActivityIndicator.UltraActivityIndicator ultraActivityIndicator1;
        public System.ComponentModel.BackgroundWorker backgroundWorkerExport;
    }
}