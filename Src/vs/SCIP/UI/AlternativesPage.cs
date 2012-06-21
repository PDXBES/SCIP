using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
      Cursor = Cursors.WaitCursor;
      try
      {
        aSSET_SETSTableAdapter.Update(sCIPDataSet);

        SCIPDataSetTableAdapters.QueriesTableAdapter queriesAdapter =
          new SCIPDataSetTableAdapters.QueriesTableAdapter();
        int assetSetId = (int)e.Row.Cells["asset_set_id"].Value;

        int originalTimeoutSeconds = queriesAdapter.SelectCommandTimeOut;
        const int exposeDataTimeoutSeconds = 1800;

        queriesAdapter.SelectCommandTimeOut = exposeDataTimeoutSeconds;
        queriesAdapter.SP_ExposeData(assetSetId);
        queriesAdapter.SelectCommandTimeOut = originalTimeoutSeconds;
      }
      finally
      {
        Cursor = Cursors.Default;
      }
    }

    private void gridAssetSets_AfterRowsDeleted(object sender, EventArgs e)
    {
      aSSET_SETSTableAdapter.Update(sCIPDataSet);
    }
  }
}
