namespace UI
{
  partial class HomePage
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
      this.ultraFlowLayoutManager1 = new Infragistics.Win.Misc.UltraFlowLayoutManager(this.components);
      this.btnExportDatabase = new Infragistics.Win.Misc.UltraButton();
      this.btnCharts = new Infragistics.Win.Misc.UltraButton();
      this.btnDrivers = new Infragistics.Win.Misc.UltraButton();
      this.btnDriverTypes = new Infragistics.Win.Misc.UltraButton();
      this.btnAlternatives = new Infragistics.Win.Misc.UltraButton();
      this.btnModel = new Infragistics.Win.Misc.UltraButton();
      ((System.ComponentModel.ISupportInitialize)(this.ultraFlowLayoutManager1)).BeginInit();
      this.SuspendLayout();
      // 
      // ultraFlowLayoutManager1
      // 
      this.ultraFlowLayoutManager1.ContainerControl = this;
      this.ultraFlowLayoutManager1.HorizontalAlignment = Infragistics.Win.Layout.DefaultableFlowLayoutAlignment.Near;
      this.ultraFlowLayoutManager1.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.ultraFlowLayoutManager1.VerticalAlignment = Infragistics.Win.Layout.DefaultableFlowLayoutAlignment.Near;
      // 
      // btnExportDatabase
      // 
      this.btnExportDatabase.Location = new System.Drawing.Point(5, 145);
      this.btnExportDatabase.Name = "btnExportDatabase";
      this.btnExportDatabase.Size = new System.Drawing.Size(100, 23);
      this.btnExportDatabase.TabIndex = 0;
      this.btnExportDatabase.Tag = "ExportDatabase";
      this.btnExportDatabase.Text = "Export Database";
      this.btnExportDatabase.Click += new System.EventHandler(this.btnGeneric_Click);
      // 
      // btnCharts
      // 
      this.btnCharts.Location = new System.Drawing.Point(5, 117);
      this.btnCharts.Name = "btnCharts";
      this.btnCharts.Size = new System.Drawing.Size(100, 23);
      this.btnCharts.TabIndex = 1;
      this.btnCharts.Tag = "Charts";
      this.btnCharts.Text = "Charts";
      this.btnCharts.Click += new System.EventHandler(this.btnGeneric_Click);
      // 
      // btnDrivers
      // 
      this.btnDrivers.Location = new System.Drawing.Point(5, 89);
      this.btnDrivers.Name = "btnDrivers";
      this.btnDrivers.Size = new System.Drawing.Size(100, 23);
      this.btnDrivers.TabIndex = 2;
      this.btnDrivers.Tag = "IndividualDrivers";
      this.btnDrivers.Text = "Drivers";
      this.btnDrivers.Click += new System.EventHandler(this.btnGeneric_Click);
      // 
      // btnDriverTypes
      // 
      this.btnDriverTypes.Location = new System.Drawing.Point(5, 33);
      this.btnDriverTypes.Name = "btnDriverTypes";
      this.btnDriverTypes.Size = new System.Drawing.Size(100, 23);
      this.btnDriverTypes.TabIndex = 3;
      this.btnDriverTypes.Tag = "DriverTypes";
      this.btnDriverTypes.Text = "Driver Types";
      this.btnDriverTypes.Click += new System.EventHandler(this.btnGeneric_Click);
      // 
      // btnAlternatives
      // 
      this.btnAlternatives.Location = new System.Drawing.Point(5, 5);
      this.btnAlternatives.Name = "btnAlternatives";
      this.btnAlternatives.Size = new System.Drawing.Size(100, 23);
      this.btnAlternatives.TabIndex = 4;
      this.btnAlternatives.Tag = "Alternatives";
      this.btnAlternatives.Text = "Alternatives";
      this.btnAlternatives.Click += new System.EventHandler(this.btnGeneric_Click);
      // 
      // btnModel
      // 
      this.btnModel.Location = new System.Drawing.Point(5, 61);
      this.btnModel.Name = "btnModel";
      this.btnModel.Size = new System.Drawing.Size(100, 23);
      this.btnModel.TabIndex = 5;
      this.btnModel.Tag = "Model";
      this.btnModel.Text = "Model";
      this.btnModel.Click += new System.EventHandler(this.btnGeneric_Click);
      // 
      // HomePage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.Controls.Add(this.btnAlternatives);
      this.Controls.Add(this.btnDriverTypes);
      this.Controls.Add(this.btnModel);
      this.Controls.Add(this.btnDrivers);
      this.Controls.Add(this.btnCharts);
      this.Controls.Add(this.btnExportDatabase);
      this.Name = "HomePage";
      ((System.ComponentModel.ISupportInitialize)(this.ultraFlowLayoutManager1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Infragistics.Win.Misc.UltraFlowLayoutManager ultraFlowLayoutManager1;
    private Infragistics.Win.Misc.UltraButton btnExportDatabase;
    private Infragistics.Win.Misc.UltraButton btnDriverTypes;
    private Infragistics.Win.Misc.UltraButton btnDrivers;
    private Infragistics.Win.Misc.UltraButton btnCharts;
    private Infragistics.Win.Misc.UltraButton btnAlternatives;
    private Infragistics.Win.Misc.UltraButton btnModel;
  }
}
