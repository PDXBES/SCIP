namespace UI
{
    partial class Main
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
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint4 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint3 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
      this.btnRecalculateBase = new Infragistics.Win.Misc.UltraButton();
      this.btnCreateCharts = new Infragistics.Win.Misc.UltraButton();
      this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
      this.btnSetPreferences = new Infragistics.Win.Misc.UltraButton();
      this.btnExportDatabases = new Infragistics.Win.Misc.UltraButton();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
      this.ultraGridBagLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnRecalculateBase
      // 
      gridBagConstraint4.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint4.OriginX = 0;
      gridBagConstraint4.OriginY = 0;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.btnRecalculateBase, gridBagConstraint4);
      this.btnRecalculateBase.Location = new System.Drawing.Point(234, 175);
      this.btnRecalculateBase.Name = "btnRecalculateBase";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.btnRecalculateBase, new System.Drawing.Size(155, 23));
      this.btnRecalculateBase.Size = new System.Drawing.Size(155, 23);
      this.btnRecalculateBase.TabIndex = 0;
      this.btnRecalculateBase.Text = "Recalculate Base Condition";
      // 
      // btnCreateCharts
      // 
      gridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint3.OriginX = 0;
      gridBagConstraint3.OriginY = 1;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.btnCreateCharts, gridBagConstraint3);
      this.btnCreateCharts.Location = new System.Drawing.Point(234, 198);
      this.btnCreateCharts.Name = "btnCreateCharts";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.btnCreateCharts, new System.Drawing.Size(75, 23));
      this.btnCreateCharts.Size = new System.Drawing.Size(155, 23);
      this.btnCreateCharts.TabIndex = 1;
      this.btnCreateCharts.Text = "Create Charts";
      // 
      // ultraGridBagLayoutPanel1
      // 
      this.ultraGridBagLayoutPanel1.Controls.Add(this.btnExportDatabases);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.btnSetPreferences);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.btnRecalculateBase);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.btnCreateCharts);
      this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
      this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(624, 442);
      this.ultraGridBagLayoutPanel1.TabIndex = 2;
      // 
      // btnSetPreferences
      // 
      gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint2.OriginX = 0;
      gridBagConstraint2.OriginY = 3;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.btnSetPreferences, gridBagConstraint2);
      this.btnSetPreferences.Location = new System.Drawing.Point(234, 244);
      this.btnSetPreferences.Name = "btnSetPreferences";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.btnSetPreferences, new System.Drawing.Size(75, 23));
      this.btnSetPreferences.Size = new System.Drawing.Size(155, 23);
      this.btnSetPreferences.TabIndex = 2;
      this.btnSetPreferences.Text = "Set Preferences...";
      // 
      // btnExportDatabases
      // 
      gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint1.OriginX = 0;
      gridBagConstraint1.OriginY = 2;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.btnExportDatabases, gridBagConstraint1);
      this.btnExportDatabases.Location = new System.Drawing.Point(234, 221);
      this.btnExportDatabases.Name = "btnExportDatabases";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.btnExportDatabases, new System.Drawing.Size(75, 23));
      this.btnExportDatabases.Size = new System.Drawing.Size(155, 23);
      this.btnExportDatabases.TabIndex = 3;
      this.btnExportDatabases.Text = "Export Databases...";
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(624, 442);
      this.Controls.Add(this.ultraGridBagLayoutPanel1);
      this.Name = "Main";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
      this.ultraGridBagLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton btnRecalculateBase;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private Infragistics.Win.Misc.UltraButton btnSetPreferences;
        private Infragistics.Win.Misc.UltraButton btnCreateCharts;
        private Infragistics.Win.Misc.UltraButton btnExportDatabases;
    }
}

