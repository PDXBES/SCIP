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
      SCIPDataSetTableAdapters.QueriesTableAdapter queriesAdapter = 
        new SCIPDataSetTableAdapters.QueriesTableAdapter();
      
      int? assetSetId = queriesAdapter.AssetSetIdOfAlternative((int)cmbAlternatives.Value);

      if (assetSetId != null)
        queriesAdapter.SP_ExposeData(assetSetId);
    }
  }
}
