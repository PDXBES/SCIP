namespace UI
{
  partial class FormCreateCharts
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
      Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
      Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
      Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
      Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
      this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
      this.SCIPDataSet = new UI.SCIPDataSet();
      this.FN_CHART_CPTDBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.FN_CHART_CPTDTableAdapter = new UI.SCIPDataSetTableAdapters.FN_CHART_CPTDTableAdapter();
      this.FN_CHART_CPTFBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.FN_CHART_CPTFTableAdapter = new UI.SCIPDataSetTableAdapters.FN_CHART_CPTFTableAdapter();
      this.FN_CHART_CPADBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.FN_CHART_CPADTableAdapter = new UI.SCIPDataSetTableAdapters.FN_CHART_CPADTableAdapter();
      this.FN_CHART_CPAFBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.FN_CHART_CPAFTableAdapter = new UI.SCIPDataSetTableAdapters.FN_CHART_CPAFTableAdapter();
      this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
      this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
      this.txtBeginYear = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
      this.txtEndYear = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
      this.btnRunReport = new Infragistics.Win.Misc.UltraButton();
      ((System.ComponentModel.ISupportInitialize)(this.SCIPDataSet)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.FN_CHART_CPTDBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.FN_CHART_CPTFBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.FN_CHART_CPADBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.FN_CHART_CPAFBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtBeginYear)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtEndYear)).BeginInit();
      this.SuspendLayout();
      // 
      // reportViewer1
      // 
      this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      reportDataSource5.Name = "CPTD";
      reportDataSource5.Value = this.FN_CHART_CPTDBindingSource;
      reportDataSource6.Name = "CPTF";
      reportDataSource6.Value = this.FN_CHART_CPTFBindingSource;
      reportDataSource7.Name = "CPAD";
      reportDataSource7.Value = this.FN_CHART_CPADBindingSource;
      reportDataSource8.Name = "CPAF";
      reportDataSource8.Value = this.FN_CHART_CPAFBindingSource;
      this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
      this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
      this.reportViewer1.LocalReport.DataSources.Add(reportDataSource7);
      this.reportViewer1.LocalReport.DataSources.Add(reportDataSource8);
      this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Cleaning.rdlc";
      this.reportViewer1.Location = new System.Drawing.Point(12, 52);
      this.reportViewer1.Name = "reportViewer1";
      this.reportViewer1.Size = new System.Drawing.Size(691, 363);
      this.reportViewer1.TabIndex = 0;
      // 
      // SCIPDataSet
      // 
      this.SCIPDataSet.DataSetName = "SCIPDataSet";
      this.SCIPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // FN_CHART_CPTDBindingSource
      // 
      this.FN_CHART_CPTDBindingSource.DataMember = "FN_CHART_CPTD";
      this.FN_CHART_CPTDBindingSource.DataSource = this.SCIPDataSet;
      // 
      // FN_CHART_CPTDTableAdapter
      // 
      this.FN_CHART_CPTDTableAdapter.ClearBeforeFill = true;
      // 
      // FN_CHART_CPTFBindingSource
      // 
      this.FN_CHART_CPTFBindingSource.DataMember = "FN_CHART_CPTF";
      this.FN_CHART_CPTFBindingSource.DataSource = this.SCIPDataSet;
      // 
      // FN_CHART_CPTFTableAdapter
      // 
      this.FN_CHART_CPTFTableAdapter.ClearBeforeFill = true;
      // 
      // FN_CHART_CPADBindingSource
      // 
      this.FN_CHART_CPADBindingSource.DataMember = "FN_CHART_CPAD";
      this.FN_CHART_CPADBindingSource.DataSource = this.SCIPDataSet;
      // 
      // FN_CHART_CPADTableAdapter
      // 
      this.FN_CHART_CPADTableAdapter.ClearBeforeFill = true;
      // 
      // FN_CHART_CPAFBindingSource
      // 
      this.FN_CHART_CPAFBindingSource.DataMember = "FN_CHART_CPAF";
      this.FN_CHART_CPAFBindingSource.DataSource = this.SCIPDataSet;
      // 
      // FN_CHART_CPAFTableAdapter
      // 
      this.FN_CHART_CPAFTableAdapter.ClearBeforeFill = true;
      // 
      // ultraLabel1
      // 
      this.ultraLabel1.AutoSize = true;
      this.ultraLabel1.Location = new System.Drawing.Point(184, 14);
      this.ultraLabel1.Name = "ultraLabel1";
      this.ultraLabel1.Size = new System.Drawing.Size(51, 14);
      this.ultraLabel1.TabIndex = 3;
      this.ultraLabel1.Text = "End Year";
      // 
      // ultraLabel2
      // 
      this.ultraLabel2.AutoSize = true;
      this.ultraLabel2.Location = new System.Drawing.Point(12, 14);
      this.ultraLabel2.Name = "ultraLabel2";
      this.ultraLabel2.Size = new System.Drawing.Size(60, 14);
      this.ultraLabel2.TabIndex = 4;
      this.ultraLabel2.Text = "Begin Year";
      // 
      // txtBeginYear
      // 
      this.txtBeginYear.Location = new System.Drawing.Point(78, 10);
      this.txtBeginYear.Name = "txtBeginYear";
      this.txtBeginYear.Size = new System.Drawing.Size(100, 21);
      this.txtBeginYear.TabIndex = 5;
      this.txtBeginYear.Text = "2012";
      // 
      // txtEndYear
      // 
      this.txtEndYear.Location = new System.Drawing.Point(241, 10);
      this.txtEndYear.Name = "txtEndYear";
      this.txtEndYear.Size = new System.Drawing.Size(100, 21);
      this.txtEndYear.TabIndex = 6;
      this.txtEndYear.Text = "2023";
      // 
      // btnRunReport
      // 
      this.btnRunReport.Location = new System.Drawing.Point(347, 10);
      this.btnRunReport.Name = "btnRunReport";
      this.btnRunReport.Size = new System.Drawing.Size(75, 23);
      this.btnRunReport.TabIndex = 7;
      this.btnRunReport.Text = "Run Report";
      this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);
      // 
      // FormCreateCharts
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(715, 427);
      this.Controls.Add(this.btnRunReport);
      this.Controls.Add(this.txtEndYear);
      this.Controls.Add(this.txtBeginYear);
      this.Controls.Add(this.ultraLabel2);
      this.Controls.Add(this.ultraLabel1);
      this.Controls.Add(this.reportViewer1);
      this.Name = "FormCreateCharts";
      this.Text = "FormCreateCharts";
      this.Load += new System.EventHandler(this.FormCreateCharts_Load);
      ((System.ComponentModel.ISupportInitialize)(this.SCIPDataSet)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.FN_CHART_CPTDBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.FN_CHART_CPTFBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.FN_CHART_CPADBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.FN_CHART_CPAFBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtBeginYear)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtEndYear)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    private System.Windows.Forms.BindingSource FN_CHART_CPTDBindingSource;
    private SCIPDataSet SCIPDataSet;
    private System.Windows.Forms.BindingSource FN_CHART_CPTFBindingSource;
    private System.Windows.Forms.BindingSource FN_CHART_CPADBindingSource;
    private System.Windows.Forms.BindingSource FN_CHART_CPAFBindingSource;
    private SCIPDataSetTableAdapters.FN_CHART_CPTDTableAdapter FN_CHART_CPTDTableAdapter;
    private SCIPDataSetTableAdapters.FN_CHART_CPTFTableAdapter FN_CHART_CPTFTableAdapter;
    private SCIPDataSetTableAdapters.FN_CHART_CPADTableAdapter FN_CHART_CPADTableAdapter;
    private SCIPDataSetTableAdapters.FN_CHART_CPAFTableAdapter FN_CHART_CPAFTableAdapter;
    private Infragistics.Win.Misc.UltraLabel ultraLabel1;
    private Infragistics.Win.Misc.UltraLabel ultraLabel2;
    private Infragistics.Win.UltraWinEditors.UltraTextEditor txtBeginYear;
    private Infragistics.Win.UltraWinEditors.UltraTextEditor txtEndYear;
    private Infragistics.Win.Misc.UltraButton btnRunReport;






  }
}