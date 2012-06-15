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
      asseT_SETSTableAdapter.Fill(scipDataSet.ASSET_SETS);


      SqlConnection sqlConnection = new SqlConnection(SCIPUI.Default.ConnectionString);
      SqlCommand exposeData = new SqlCommand() {
        Connection = sqlConnection, 
        CommandText = "SP_ExposeData", 
        CommandType = CommandType.StoredProcedure };
      exposeData.Parameters["asset_set_id"].Value = 1;
    }
  }
}
