using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace UI
{
  public partial class FormCreateCharts : Form
  {
    public FormCreateCharts()
    {
      InitializeComponent();
    }

    private void FormCreateCharts_Load(object sender, EventArgs e)
    {
    }

    private void btnRunReport_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      try
      {
        int beginYear = Convert.ToInt32(txtBeginYear.Text);
        int endYear = Convert.ToInt32(txtEndYear.Text);

        this.FN_CHART_CPTDTableAdapter.Fill(this.SCIPDataSet.FN_CHART_CPTD, beginYear, endYear);
        this.FN_CHART_CPTFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_CPTF, beginYear, endYear);
        this.FN_CHART_CPADTableAdapter.Fill(this.SCIPDataSet.FN_CHART_CPAD, beginYear, endYear);
        this.FN_CHART_CPAFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_CPAF, beginYear, endYear);

        ReportParameter p1 = new ReportParameter("beginYear", txtBeginYear.Text);
        ReportParameter p2 = new ReportParameter("endYear", txtEndYear.Text);
        this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
        this.reportViewer1.RefreshReport();
      }
      finally
      {
        Cursor = Cursors.Default;
      }
    }
  }
}
