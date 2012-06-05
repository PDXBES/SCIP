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
  public partial class ChartsPage : ChildFormTemplate
  {
    public ChartsPage()
    {
      InitializeComponent();
    }

    private void SetProgressUIVisible(bool isVisible)
    {
      progress.Visible = isVisible;
      progress.Value = 0;
      Infragistics.Win.Layout.GridBagConstraint constraintRootButton = 
        pnlActionButtons.GetGridBagConstraint(btnRunRootReport);
      constraintRootButton.WeightX = isVisible ? 0 : 1;
    }
    private void FormCreateCharts_Load(object sender, EventArgs e)
    {
      SetProgressUIVisible(false);
    }

    private void btnRunCleaningReport_Click(object sender, EventArgs e)
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
        this.FN_CHART_CLTDTableAdapter.Fill(this.SCIPDataSet.FN_CHART_CLTD, beginYear, endYear);
        this.FN_CHART_CLTFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_CLTF, beginYear, endYear);

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

    private void btnRunInspectionReport_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      try
      {
        int beginYear = Convert.ToInt32(txtBeginYear.Text);
        int endYear = Convert.ToInt32(txtEndYear.Text);

        this.FN_CHART_ILTDTableAdapter.Fill(this.SCIPDataSet.FN_CHART_ILTD, beginYear, endYear);
        this.FN_CHART_ILTFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_ILTF, beginYear, endYear);
        this.FN_CHART_IPADTableAdapter.Fill(this.SCIPDataSet.FN_CHART_IPAD, beginYear, endYear);
        this.FN_CHART_IPAFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_IPAF, beginYear, endYear);
        this.FN_CHART_IPTDTableAdapter.Fill(this.SCIPDataSet.FN_CHART_IPTD, beginYear, endYear);
        this.FN_CHART_IPTFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_IPTF, beginYear, endYear);
        this.reportViewer2.RefreshReport();

        ReportParameter p1 = new ReportParameter("beginYear", txtBeginYear.Text);
        ReportParameter p2 = new ReportParameter("endYear", txtEndYear.Text);
        this.reportViewer2.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
        this.reportViewer2.RefreshReport();
      }
      finally
      {
        Cursor = Cursors.Default;
      }
    }

    private void btnRunRootReport_Click(object sender, EventArgs e)
    {

      Cursor = Cursors.WaitCursor;
      try
      {
        int beginYear = Convert.ToInt32(txtBeginYear.Text);
        int endYear = Convert.ToInt32(txtEndYear.Text);

        this.FN_CHART_RPTDTableAdapter.Fill(this.SCIPDataSet.FN_CHART_RPTD, beginYear, endYear);
        this.FN_CHART_RPTFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_RPTF, beginYear, endYear);
        this.FN_CHART_RPADTableAdapter.Fill(this.SCIPDataSet.FN_CHART_RPAD, beginYear, endYear);
        this.FN_CHART_RPAFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_RPAF, beginYear, endYear);
        this.FN_CHART_RLTDTableAdapter.Fill(this.SCIPDataSet.FN_CHART_RLTD, beginYear, endYear);
        this.FN_CHART_RLTFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_RLTF, beginYear, endYear);

        ReportParameter p1 = new ReportParameter("beginYear", txtBeginYear.Text);
        ReportParameter p2 = new ReportParameter("endYear", txtEndYear.Text);
        this.reportViewer3.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
        this.reportViewer3.RefreshReport();
      }
      finally
      {
        Cursor = Cursors.Default;
      }
    }

    private void btnRunAllReports_Click(object sender, EventArgs e)
    {
      SetProgressUIVisible(true);
      Refresh();

      btnRunCleaningReport_Click(sender, e);
      progress.Value = 33;
      Refresh();
      btnRunInspectionReport_Click(sender, e);
      progress.Value = 67;
      Refresh();
      btnRunRootReport_Click(sender, e);

      SetProgressUIVisible(false);
    }
  }
}
