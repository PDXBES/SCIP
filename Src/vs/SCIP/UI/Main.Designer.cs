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
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint7 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint6 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint3 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint4 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint5 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            this.btnRecalculateBaseCondition = new Infragistics.Win.Misc.UltraButton();
            this.btnCreateCharts = new Infragistics.Win.Misc.UltraButton();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.btnRunModel = new Infragistics.Win.Misc.UltraButton();
            this.btnManageAlternatives = new Infragistics.Win.Misc.UltraButton();
            this.btnExportDatabases = new Infragistics.Win.Misc.UltraButton();
            this.btnSetPreferences = new Infragistics.Win.Misc.UltraButton();
            this.buttonEditIndividualDrivers = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRecalculateBaseCondition
            // 
            gridBagConstraint7.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint7.OriginX = 0;
            gridBagConstraint7.OriginY = 2;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.btnRecalculateBaseCondition, gridBagConstraint7);
            this.btnRecalculateBaseCondition.Location = new System.Drawing.Point(234, 186);
            this.btnRecalculateBaseCondition.Name = "btnRecalculateBaseCondition";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.btnRecalculateBaseCondition, new System.Drawing.Size(155, 23));
            this.btnRecalculateBaseCondition.Size = new System.Drawing.Size(155, 23);
            this.btnRecalculateBaseCondition.TabIndex = 0;
            this.btnRecalculateBaseCondition.Text = "Recalculate Base Condition";
            // 
            // btnCreateCharts
            // 
            gridBagConstraint6.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint6.OriginX = 0;
            gridBagConstraint6.OriginY = 3;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.btnCreateCharts, gridBagConstraint6);
            this.btnCreateCharts.Location = new System.Drawing.Point(234, 209);
            this.btnCreateCharts.Name = "btnCreateCharts";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.btnCreateCharts, new System.Drawing.Size(75, 23));
            this.btnCreateCharts.Size = new System.Drawing.Size(155, 23);
            this.btnCreateCharts.TabIndex = 1;
            this.btnCreateCharts.Text = "Create Charts";
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.buttonEditIndividualDrivers);
            this.ultraGridBagLayoutPanel1.Controls.Add(this.btnRunModel);
            this.ultraGridBagLayoutPanel1.Controls.Add(this.btnManageAlternatives);
            this.ultraGridBagLayoutPanel1.Controls.Add(this.btnExportDatabases);
            this.ultraGridBagLayoutPanel1.Controls.Add(this.btnSetPreferences);
            this.ultraGridBagLayoutPanel1.Controls.Add(this.btnRecalculateBaseCondition);
            this.ultraGridBagLayoutPanel1.Controls.Add(this.btnCreateCharts);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(624, 442);
            this.ultraGridBagLayoutPanel1.TabIndex = 2;
            // 
            // btnRunModel
            // 
            gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint2.OriginX = 0;
            gridBagConstraint2.OriginY = 1;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.btnRunModel, gridBagConstraint2);
            this.btnRunModel.Location = new System.Drawing.Point(234, 163);
            this.btnRunModel.Name = "btnRunModel";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.btnRunModel, new System.Drawing.Size(75, 23));
            this.btnRunModel.Size = new System.Drawing.Size(155, 23);
            this.btnRunModel.TabIndex = 5;
            this.btnRunModel.Text = "Run Model";
            // 
            // btnManageAlternatives
            // 
            gridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint3.OriginX = 0;
            gridBagConstraint3.OriginY = 0;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.btnManageAlternatives, gridBagConstraint3);
            this.btnManageAlternatives.Location = new System.Drawing.Point(234, 140);
            this.btnManageAlternatives.Name = "btnManageAlternatives";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.btnManageAlternatives, new System.Drawing.Size(75, 23));
            this.btnManageAlternatives.Size = new System.Drawing.Size(155, 23);
            this.btnManageAlternatives.TabIndex = 4;
            this.btnManageAlternatives.Text = "Manage Alternatives";
            // 
            // btnExportDatabases
            // 
            gridBagConstraint4.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint4.OriginX = 0;
            gridBagConstraint4.OriginY = 4;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.btnExportDatabases, gridBagConstraint4);
            this.btnExportDatabases.Location = new System.Drawing.Point(234, 232);
            this.btnExportDatabases.Name = "btnExportDatabases";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.btnExportDatabases, new System.Drawing.Size(75, 23));
            this.btnExportDatabases.Size = new System.Drawing.Size(155, 23);
            this.btnExportDatabases.TabIndex = 3;
            this.btnExportDatabases.Text = "Export Databases...";
            // 
            // btnSetPreferences
            // 
            gridBagConstraint5.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint5.OriginX = 0;
            gridBagConstraint5.OriginY = 5;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.btnSetPreferences, gridBagConstraint5);
            this.btnSetPreferences.Location = new System.Drawing.Point(234, 255);
            this.btnSetPreferences.Name = "btnSetPreferences";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.btnSetPreferences, new System.Drawing.Size(75, 23));
            this.btnSetPreferences.Size = new System.Drawing.Size(155, 23);
            this.btnSetPreferences.TabIndex = 2;
            this.btnSetPreferences.Text = "Set Preferences...";
            // 
            // buttonEditIndividualDrivers
            // 
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.OriginX = 0;
            gridBagConstraint1.OriginY = 6;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.buttonEditIndividualDrivers, gridBagConstraint1);
            this.buttonEditIndividualDrivers.Location = new System.Drawing.Point(234, 278);
            this.buttonEditIndividualDrivers.Name = "buttonEditIndividualDrivers";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.buttonEditIndividualDrivers, new System.Drawing.Size(75, 23));
            this.buttonEditIndividualDrivers.Size = new System.Drawing.Size(155, 23);
            this.buttonEditIndividualDrivers.TabIndex = 6;
            this.buttonEditIndividualDrivers.Text = "Edit Individual Drivers";
            this.buttonEditIndividualDrivers.Click += new System.EventHandler(this.buttonEditIndividualDrivers_Click);
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

        private Infragistics.Win.Misc.UltraButton btnRecalculateBaseCondition;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private Infragistics.Win.Misc.UltraButton btnSetPreferences;
        private Infragistics.Win.Misc.UltraButton btnCreateCharts;
        private Infragistics.Win.Misc.UltraButton btnExportDatabases;
        private Infragistics.Win.Misc.UltraButton btnRunModel;
        private Infragistics.Win.Misc.UltraButton btnManageAlternatives;
        private Infragistics.Win.Misc.UltraButton buttonEditIndividualDrivers;
    }
}

