using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UI
{
  public partial class ModelPage : UI.ChildFormTemplate
  {
    const decimal defaultYears = 24.0m;
    DateTime beginTime;
    DateTime endTime;

    private struct ModelRunArgs
    {
      public int AlternativeId;
      public bool FillDrivers;
      public bool FillActivities;
    }

    public ModelPage()
    {
      InitializeComponent();
      alternativesTableAdapter.Fill(scipDataSet.ALTERNATIVES);
      cmbAlternatives.Value = scipDataSet.ALTERNATIVES[0][0];
    }

    private void EnableUI(bool enabled = true)
    {
      cmbAlternatives.Enabled = enabled;
      txtNumYears.Enabled = enabled;
      btnExecuteAll.Enabled = enabled;
      btnExecuteRetrieveAssets.Enabled = enabled;
      btnExecuteFillDriversActivities.Enabled = enabled;
      chkFillDrivers.Enabled = enabled;
      chkFillActivities.Enabled = enabled;
    }

    private void ModelPage_Load(object sender, EventArgs e)
    {
      alternativesTableAdapter.Fill(scipDataSet.ALTERNATIVES);
      txtNumYears.Value = defaultYears;
    }

    private void btnExecuteAll_Click(object sender, EventArgs e)
    {
    }

    private void btnExecuteFillDriversActivities_Click(object sender, EventArgs e)
    {
      txtMessages.Clear();
      int alternativeId = (int)cmbAlternatives.Value;

      ModelRunArgs modelRunArgs = new ModelRunArgs
      {
        AlternativeId = alternativeId,
        FillDrivers = chkFillDrivers.Checked,
        FillActivities = chkFillActivities.Checked
      };

      EnableUI(false);
      activityIndicator.ResetAnimation();
      activityIndicator.Start();
      beginTime = DateTime.Now;
      bkgWorker.RunWorkerAsync(modelRunArgs);
    }

    private void bkgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      ModelRunArgs runArgs = (ModelRunArgs)e.Argument;

      var connection = new SqlConnection(SCIPUI.Default.ConnectionString);
      connection.InfoMessage += (s, evargs) =>
      {
        bkgWorker.ReportProgress(0, evargs.Message);
      };
      connection.FireInfoMessageEventOnUserErrors = true;

      var fillDriversCommand = new SqlCommand("SP_FILL_DRIVERS", connection)
      {
        CommandType = CommandType.StoredProcedure,
        CommandTimeout = 3600
      };
      fillDriversCommand.Parameters.Add("@alternative_id", SqlDbType.Int).Value = 
        runArgs.AlternativeId;

      var fillActivitiesCommand = new SqlCommand("SP_FILL_ACTIVITIES", connection)
      {
        CommandType = CommandType.StoredProcedure,
        CommandTimeout = 3600
      };
      fillActivitiesCommand.Parameters.Add("@alternative_id", SqlDbType.Int).Value = 
        runArgs.AlternativeId;
      fillActivitiesCommand.Parameters.Add("@years_to_process", SqlDbType.Decimal).Value = 
        (decimal)txtNumYears.Value;

      var fillNextActivitiesCommand = new SqlCommand("SP_FILL_NEXT_ACTIVITIES", connection)
      {
        CommandType = CommandType.StoredProcedure,
        CommandTimeout = 3600
      };
      fillNextActivitiesCommand.Parameters.Add("@alternative_id", SqlDbType.Int).Value = 
        runArgs.AlternativeId;

      try
      {
        connection.Open();
        if (runArgs.FillDrivers)
        {
          fillDriversCommand.ExecuteNonQuery();
        }

        if (runArgs.FillActivities)
        {
          fillActivitiesCommand.ExecuteNonQuery();
          fillNextActivitiesCommand.ExecuteNonQuery();
        }

      }
      finally
      {
        connection.Close();
      }
    }

    private void AddToMessages(string message)
    {
      txtMessages.AlwaysInEditMode = true;
      txtMessages.AppendText(message + "\r\n");
      txtMessages.Select(txtMessages.Text.Length + 1, 0);
      txtMessages.ScrollToCaret();
      txtMessages.AlwaysInEditMode = false;
    }
    private void bkgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      AddToMessages((string)e.UserState);
      Application.DoEvents();
    }

    private void bkgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      endTime = DateTime.Now;
      TimeSpan runTime = endTime - beginTime;
      AddToMessages(String.Format("Run time: {0:c}", runTime));
      activityIndicator.Stop();
      activityIndicator.ResetAnimation();
      EnableUI(true);
    }
  }
}
