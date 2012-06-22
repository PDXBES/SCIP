using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UI
{
  public partial class AlternativesPage : ChildFormTemplate
  {
    public AlternativesPage()
    {
      InitializeComponent();
    }

    private void FormManageAlternatives_Load(object sender, EventArgs e)
    {
      this.aSSET_SETSTableAdapter.Fill(this.sCIPDataSet.ASSET_SETS);
      this.aLTERNATIVESTableAdapter.Fill(this.sCIPDataSet.ALTERNATIVES);
    }

    private void ultraButtonDiscardChanges_Click(object sender, EventArgs e)
    {
      this.aLTERNATIVESTableAdapter.ClearBeforeFill = true;
      this.aLTERNATIVESTableAdapter.Fill(this.sCIPDataSet.ALTERNATIVES);
    }

    private void ultraButtonSaveChanges_Click(object sender, EventArgs e)
    {
      try
      {
        ultraGridAlternatives.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
        ultraGridAlternatives.UpdateData();
        CurrencyManager cm = (CurrencyManager)ultraGridAlternatives.BindingContext[ultraGridAlternatives.DataSource, ultraGridAlternatives.DataMember];
        cm.EndCurrentEdit();

        if (sCIPDataSet.HasChanges(DataRowState.Added))
        {
          var connection = new SqlConnection(SCIPUI.Default.ConnectionString);
          connection.InfoMessage += (s, evargs) =>
          {
            statusBar.Text = evargs.Message;
            statusBar.Update();
          };
          connection.FireInfoMessageEventOnUserErrors = true;

          var addedRows = sCIPDataSet.ALTERNATIVES.GetChanges(DataRowState.Added);
          var initAssetSetCommand = new SqlCommand("SP_FILL_DRIVER_TYPES", connection)
          {
            CommandTimeout = 30,
            CommandType = CommandType.StoredProcedure
          };

          try
          {
            connection.Open();
            Cursor = Cursors.WaitCursor;
            foreach (DataRow row in addedRows.Rows)
            {
              int alternativeId = (int)row["alternative_id"];
              initAssetSetCommand.Parameters.Add("@alternative_id", SqlDbType.Int).Value = alternativeId;
              initAssetSetCommand.ExecuteNonQuery();
            }
          }
          finally
          {
            connection.Close();
            Cursor = Cursors.Default;
          }
        }

        this.aLTERNATIVESTableAdapter.Update(this.sCIPDataSet.ALTERNATIVES);
        this.sCIPDataSet.ALTERNATIVES.AcceptChanges();

        this.aLTERNATIVESTableAdapter.ClearBeforeFill = true;
        this.aLTERNATIVESTableAdapter.Fill(this.sCIPDataSet.ALTERNATIVES);
      }
      catch (Exception ex)
      {
        MessageBox.Show("Invalid alternative!");
      }
    }

    private void gridAssetSets_AfterRowUpdate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
    {
      var connection = new SqlConnection(SCIPUI.Default.ConnectionString);
      connection.InfoMessage += (s, evargs) =>
      {
        statusBar.Text = evargs.Message;
        statusBar.Update();
      };
      connection.FireInfoMessageEventOnUserErrors = true;

      Cursor = Cursors.WaitCursor;
      try
      {
        aSSET_SETSTableAdapter.Update(sCIPDataSet);

        int assetSetId = (int)e.Row.Cells["asset_set_id"].Value;
        var initAssetSetCommand = new SqlCommand("SP_ExposeData", connection)
        { 
          CommandTimeout = 3600, 
          CommandType = CommandType.StoredProcedure
        };
        initAssetSetCommand.Parameters.Add("@asset_set_id", SqlDbType.Int).Value = assetSetId;

        connection.Open();
        initAssetSetCommand.ExecuteNonQuery();
      }
      finally
      {
        connection.Close();
        Cursor = Cursors.Default;
      }
    }

    private void gridAssetSets_AfterRowsDeleted(object sender, EventArgs e)
    {
      aSSET_SETSTableAdapter.Update(sCIPDataSet);
    }
  }
}
