﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace UI
{
  public partial class ChartsPage : ChildFormTemplate
  {
    bool insertedActivitiesForProcessing = false;

    const int chartTimeOutSeconds = 300;
    public ChartsPage()
    {
      InitializeComponent();
    }

    private void SetProgressUIVisible(bool isVisible)
    {
      progress.Visible = isVisible;
      progress.Value = 0;
    }

    private void FormCreateCharts_Load(object sender, EventArgs e)
    {
      // TODO: This line of code loads data into the 'SCIPDataSet.ALTERNATIVES' table. You can move, or remove it, as needed.
      this.aLTERNATIVESTableAdapter.Fill(this.SCIPDataSet.ALTERNATIVES);
      SetProgressUIVisible(false);
    }

    private void InsertActivitiesForProcessing()
    {
      var connection = new SqlConnection(SCIPUI.Default.ConnectionString);
      try
      {
        Cursor = Cursors.WaitCursor;
        var command = new SqlCommand("SP_INSERT_ACTIVITIES_FOR_PROCESSING", connection)
        {
          CommandType = CommandType.StoredProcedure
        };
        command.Parameters.Add("@alternative_id", SqlDbType.Int).Value = (int)cmbAlternative.Value;
        command.CommandTimeout = chartTimeOutSeconds;
        connection.Open();
        command.ExecuteNonQuery();
        insertedActivitiesForProcessing = true;
      }
      finally
      {
        connection.Close();
        Cursor = Cursors.Default;
      }
    }

    private void RunCleaningReport()
    {
      if (!insertedActivitiesForProcessing)
      {
        InsertActivitiesForProcessing();
      }

      int beginYear = Convert.ToInt32(txtBeginYear.Text);
      int endYear = Convert.ToInt32(txtEndYear.Text);

      this.FN_CHART_CPTDTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_CPTFTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_CPADTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_CPAFTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_CLTDTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_CLTFTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_CPTDTableAdapter.Fill(this.SCIPDataSet.FN_CHART_CPTD, beginYear, endYear, (int)cmbAlternative.Value);
      this.FN_CHART_CPTFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_CPTF, beginYear, endYear, (int)cmbAlternative.Value);
      this.FN_CHART_CPADTableAdapter.Fill(this.SCIPDataSet.FN_CHART_CPAD, beginYear, endYear, (int)cmbAlternative.Value);
      this.FN_CHART_CPAFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_CPAF, beginYear, endYear, (int)cmbAlternative.Value);
      this.FN_CHART_CLTDTableAdapter.Fill(this.SCIPDataSet.FN_CHART_CLTD, beginYear, endYear, (int)cmbAlternative.Value);
      this.FN_CHART_CLTFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_CLTF, beginYear, endYear, (int)cmbAlternative.Value);

      ReportParameter p1 = new ReportParameter("beginYear", txtBeginYear.Text);
      ReportParameter p2 = new ReportParameter("endYear", txtEndYear.Text);
      this.rptvwCleaning.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
      this.rptvwCleaning.RefreshReport();
    }

    private void btnRunCleaningReport_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      try
      {
        SetProgressUIVisible(true);
        Refresh();
        RunCleaningReport();
        tabReports.SelectedTab = tabReports.Tabs["Cleaning"];
      }
      finally
      {
        Cursor = Cursors.Default;
        SetProgressUIVisible(false);
      }
    }

    private void RunInspectionReport()
    {
      if (!insertedActivitiesForProcessing)
      {
        InsertActivitiesForProcessing();
      }

      int beginYear = Convert.ToInt32(txtBeginYear.Text);
      int endYear = Convert.ToInt32(txtEndYear.Text);

      this.FN_CHART_IPTDTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_IPTFTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_IPADTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_IPAFTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_ILTDTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_ILTFTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_ILTDTableAdapter.Fill(this.SCIPDataSet.FN_CHART_ILTD, beginYear, endYear, (int)cmbAlternative.Value);
      this.FN_CHART_ILTFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_ILTF, beginYear, endYear, (int)cmbAlternative.Value);
      this.FN_CHART_IPADTableAdapter.Fill(this.SCIPDataSet.FN_CHART_IPAD, beginYear, endYear, (int)cmbAlternative.Value);
      this.FN_CHART_IPAFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_IPAF, beginYear, endYear, (int)cmbAlternative.Value);
      this.FN_CHART_IPTDTableAdapter.Fill(this.SCIPDataSet.FN_CHART_IPTD, beginYear, endYear, (int)cmbAlternative.Value);
      this.FN_CHART_IPTFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_IPTF, beginYear, endYear, (int)cmbAlternative.Value);
      this.rptvwInspection.RefreshReport();

      ReportParameter p1 = new ReportParameter("beginYear", txtBeginYear.Text);
      ReportParameter p2 = new ReportParameter("endYear", txtEndYear.Text);
      this.rptvwInspection.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
      this.rptvwInspection.RefreshReport();
    }

    private void btnRunInspectionReport_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      try
      {
        SetProgressUIVisible(true);
        Refresh();
        RunInspectionReport();
        tabReports.SelectedTab = tabReports.Tabs["Inspection"];
      }
      finally
      {
        Cursor = Cursors.Default;
        SetProgressUIVisible(false);
      }
    }

    private void RunRootReport()
    {
      if (!insertedActivitiesForProcessing)
      {
        InsertActivitiesForProcessing();
      }

      int beginYear = Convert.ToInt32(txtBeginYear.Text);
      int endYear = Convert.ToInt32(txtEndYear.Text);

      this.FN_CHART_RPTDTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_RPTFTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_RPADTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_RPAFTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_RLTDTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_RLTFTableAdapter.SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_RPTDTableAdapter.Fill(this.SCIPDataSet.FN_CHART_RPTD, beginYear, endYear, (int)cmbAlternative.Value);
      this.FN_CHART_RPTFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_RPTF, beginYear, endYear, (int)cmbAlternative.Value);
      this.FN_CHART_RPADTableAdapter.Fill(this.SCIPDataSet.FN_CHART_RPAD, beginYear, endYear, (int)cmbAlternative.Value);
      this.FN_CHART_RPAFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_RPAF, beginYear, endYear, (int)cmbAlternative.Value);
      this.FN_CHART_RLTDTableAdapter.Fill(this.SCIPDataSet.FN_CHART_RLTD, beginYear, endYear, (int)cmbAlternative.Value);
      this.FN_CHART_RLTFTableAdapter.Fill(this.SCIPDataSet.FN_CHART_RLTF, beginYear, endYear, (int)cmbAlternative.Value);

      ReportParameter p1 = new ReportParameter("beginYear", txtBeginYear.Text);
      ReportParameter p2 = new ReportParameter("endYear", txtEndYear.Text);
      this.rptvwRoot.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
      this.rptvwRoot.RefreshReport();
    }

    private void btnRunRootReport_Click(object sender, EventArgs e)
    {

      Cursor = Cursors.WaitCursor;
      try
      {
        SetProgressUIVisible(true);
        Refresh();

        RunRootReport();

        tabReports.SelectedTab = tabReports.Tabs["RootManagement"];
      }
      finally
      {
        Cursor = Cursors.Default;
        SetProgressUIVisible(false);
      }
    }

    private void btnRunAllReports_Click(object sender, EventArgs e)
    {
      SetProgressUIVisible(true);
      Refresh();

      btnRunCoverageReport_Click(sender, e);
      progress.Value = 25;
      Refresh();
      btnRunCleaningReport_Click(sender, e);
      progress.Value = 50;
      Refresh();
      btnRunInspectionReport_Click(sender, e);
      progress.Value = 75;
      Refresh();
      btnRunRootReport_Click(sender, e);
      tabReports.SelectedTab = tabReports.Tabs["Cleaning"];
      SetProgressUIVisible(false);
    }

    private void RunCoverageReport()
    {
      if (!insertedActivitiesForProcessing)
      {
        InsertActivitiesForProcessing();
      }

      int beginYear = Convert.ToInt32(txtBeginYear.Text);
      int endYear = Convert.ToInt32(txtEndYear.Text);
      this.FN_CHART_ACTIVITIES_COUNT_BETWEEN_YEARSCleaningTableAdapter.Fill(
        this.SCIPDataSet.FN_CHART_ACTIVITIES_COUNT_BETWEEN_YEARSCleaning, beginYear, endYear, (int)cmbAlternative.Value);
      progress.Value = 17;
      Refresh();

      this.FN_CHART_ACTIVITIES_COUNT_BETWEEN_YEARSInspectionTableAdapter.Fill(
        this.SCIPDataSet.FN_CHART_ACTIVITIES_COUNT_BETWEEN_YEARSInspection, beginYear, endYear, (int)cmbAlternative.Value);
      progress.Value = 33;
      Refresh();

      this.FN_CHART_ACTIVITIES_COUNT_BETWEEN_YEARSRootTableAdapter.Fill(
        this.SCIPDataSet.FN_CHART_ACTIVITIES_COUNT_BETWEEN_YEARSRoot, beginYear, endYear, (int)cmbAlternative.Value);
      progress.Value = 50;
      Refresh();


      this.FN_CHART_PROGRESSIVE_ACTIVITIES_COUNT_BETWEEN_YEARSInspectionTableAdapter.
        SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_PROGRESSIVE_ACTIVITIES_COUNT_BETWEEN_YEARSInspectionTableAdapter.Fill(
        this.SCIPDataSet.FN_CHART_PROGRESSIVE_ACTIVITIES_COUNT_BETWEEN_YEARSInspection,
        beginYear, endYear, (int)cmbAlternative.Value);
      progress.Value = 67;
      Refresh();

      this.FN_CHART_PROGRESSIVE_ACTIVITIES_COUNT_BETWEEN_YEARSCleaningTableAdapter.
        SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_PROGRESSIVE_ACTIVITIES_COUNT_BETWEEN_YEARSCleaningTableAdapter.Fill(
        this.SCIPDataSet.FN_CHART_PROGRESSIVE_ACTIVITIES_COUNT_BETWEEN_YEARSCleaning,
        beginYear, endYear, (int)cmbAlternative.Value);
      progress.Value = 83;
      Refresh();

      this.FN_CHART_PROGRESSIVE_ACTIVITIES_COUNT_BETWEEN_YEARSRootTableAdapter.
        SelectCommandTimeOut = chartTimeOutSeconds;
      this.FN_CHART_PROGRESSIVE_ACTIVITIES_COUNT_BETWEEN_YEARSRootTableAdapter.Fill(
        this.SCIPDataSet.FN_CHART_PROGRESSIVE_ACTIVITIES_COUNT_BETWEEN_YEARSRoot,
        beginYear, endYear, (int)cmbAlternative.Value);
      progress.Value = 95;
      Refresh();


      ReportParameter p1 = new ReportParameter("beginYear", txtBeginYear.Text);
      ReportParameter p2 = new ReportParameter("endYear", txtEndYear.Text);
      this.rptvwCoverage.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
      this.rptvwCoverage.RefreshReport();
    }

    private void btnRunCoverageReport_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      try
      {
        SetProgressUIVisible(true);
        Refresh();

        RunCoverageReport();
        tabReports.SelectedTab = tabReports.Tabs["Coverage"];

      }
      finally
      {
        SetProgressUIVisible(false);
        Cursor = Cursors.Default;
      }
    }

    private void txtEndYear_ValueChanged(object sender, EventArgs e)
    {
      if ((int)txtEndYear.Value  < (int)txtBeginYear.Value)
        txtEndYear.Value = txtBeginYear.Value;
    }

    private void comboAlternative_ValueChanged(object sender, EventArgs e)
    {
      insertedActivitiesForProcessing = false;
    }
  }
}
