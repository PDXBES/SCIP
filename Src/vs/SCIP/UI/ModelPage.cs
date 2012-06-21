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

      int alternativeId = (int)cmbAlternatives.Value;

      Cursor = Cursors.WaitCursor;
      try
      {
        if (chkFillDrivers.Checked)
        {
          queriesAdapter.SP_FILL_DRIVERS(alternativeId);
        }

        if (chkFillActivities.Checked)
        {
          queriesAdapter.SP_FILL_ACTIVITIES(alternativeId, (decimal)txtNumYears.Value);
          queriesAdapter.SP_FILL_NEXT_ACTIVITIES(alternativeId);
        }

      }
      finally
      {
        Cursor = Cursors.Default;
      }
    }
  }
}
