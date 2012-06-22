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
    public ModelPage()
    {
      InitializeComponent();
      alternativesTableAdapter.Fill(scipDataSet.ALTERNATIVES);
      cmbAlternatives.Value = scipDataSet.ALTERNATIVES[0][0];
    }

    private void ModelPage_Load(object sender, EventArgs e)
    {
      alternativesTableAdapter.Fill(scipDataSet.ALTERNATIVES);
    }

    private void btnExecuteAll_Click(object sender, EventArgs e)
    {
    }

    private void btnTestMessages_Click(object sender, EventArgs e)
    {
      var connection = new SqlConnection(SCIPUI.Default.ConnectionString);
      var command = new SqlCommand("SP_TEST_SEND_MESSAGES", connection) 
      {
        CommandType = CommandType.StoredProcedure
      };

      connection.InfoMessage += (s, evargs) => 
      { 
        lblCurrentMessage.Text = evargs.Message;
        lblCurrentMessage.Update();
      };
      connection.FireInfoMessageEventOnUserErrors = true;
      connection.Open();
      command.ExecuteNonQuery();
      connection.Close();
    }

    private void btnExecuteFillDriversActivities_Click(object sender, EventArgs e)
    {
      var connection = new SqlConnection(SCIPUI.Default.ConnectionString);
      connection.InfoMessage += (s, evargs) =>
      {
        lblCurrentMessage.Text = evargs.Message;
        lblCurrentMessage.Update();
      };
      connection.FireInfoMessageEventOnUserErrors = true;

      int alternativeId = (int)cmbAlternatives.Value;

      var fillDriversCommand = new SqlCommand("SP_FILL_DRIVERS", connection)
      {
        CommandType = CommandType.StoredProcedure,
        CommandTimeout = 3600
      };
      fillDriversCommand.Parameters.Add("@alternative_id", SqlDbType.Int).Value = alternativeId;

      var fillActivitiesCommand = new SqlCommand("SP_FILL_ACTIVITIES", connection)
      {
        CommandType = CommandType.StoredProcedure,
        CommandTimeout = 3600
      };
      fillActivitiesCommand.Parameters.Add("@alternative_id", SqlDbType.Int).Value = alternativeId;
      fillActivitiesCommand.Parameters.Add("@years_to_process", SqlDbType.Decimal).Value = (decimal)txtNumYears.Value;

      var fillNextActivitiesCommand = new SqlCommand("SP_FILL_NEXT_ACTIVITIES", connection)
      {
        CommandType = CommandType.StoredProcedure,
        CommandTimeout = 3600
      };
      fillNextActivitiesCommand.Parameters.Add("@alternative_id", SqlDbType.Int).Value = alternativeId;

      try
      {
        Cursor = Cursors.WaitCursor;
        connection.Open();
        if (chkFillDrivers.Checked)
        {
          lblCurrentProcedure.Text = "Filling drivers";
          lblCurrentProcedure.Update();
          fillDriversCommand.ExecuteNonQuery();
        }

        if (chkFillActivities.Checked)
        {
          lblCurrentProcedure.Text = "Filling activities";
          lblCurrentProcedure.Update();
          fillActivitiesCommand.ExecuteNonQuery();
          lblCurrentProcedure.Text = "Filling next activities";
          lblCurrentProcedure.Update();
          fillNextActivitiesCommand.ExecuteNonQuery();
        }

      }
      finally
      {
        connection.Close();
        Cursor = Cursors.Default;
      }
    }
  }
}
