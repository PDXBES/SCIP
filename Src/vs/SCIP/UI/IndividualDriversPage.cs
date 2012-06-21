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
    public partial class IndividualDriversPage : ChildFormTemplate
    {
        public IndividualDriversPage()
        {
            InitializeComponent();
        }

        private void FormIndividualDrivers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sCIPDataSet.ALTERNATIVES' table. You can move, or remove it, as needed.
            this.aLTERNATIVESTableAdapter.Fill(this.sCIPDataSet.ALTERNATIVES);
            // TODO: This line of code loads data into the 'sCIPDataSet.DRIVERS_UPDATE' table. You can move, or remove it, as needed.
            this.dRIVERS_UPDATETableAdapter.DriversUpdate_Empty();

            ultraComboAlternatives.Value = this.sCIPDataSet.ALTERNATIVES[0][0];
            this.dRIVERS_UPDATETableAdapter.Fill(this.sCIPDataSet.DRIVERS_UPDATE);
        }

        private void buttonFetchCompkey_Click(object sender, EventArgs e)
        {
           //Fill the Assets_Update table and the Drivers_Update table with
            //data related to the compkey in the textbox.
            //If there is no compkey related to the compkey in the textbox,
            //send a message to the user.

            //SELECT * FROM ASSETS WHERE ASSETS.COMPKEY = Int32.Parse(COMPKEYtextbox.Text);
            try
            {
                this.dRIVERS_UPDATETableAdapter.ClearBeforeFill = true;
                this.dRIVERS_UPDATETableAdapter.UpdateByCompkey(Int32.Parse(TextEditorCompkey.Text), (int)ultraComboAlternatives.Value);
                this.sCIPDataSet.AcceptChanges();
                this.dRIVERS_UPDATETableAdapter.Fill(this.sCIPDataSet.DRIVERS_UPDATE);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Compkey/alternative combination!");
            }
        }

        private void buttonRevertDrivers_Click(object sender, EventArgs e)
        {
            try
            {
                this.dRIVERS_UPDATETableAdapter.ClearBeforeFill = true;
                this.dRIVERS_UPDATETableAdapter.UpdateByCompkey(Int32.Parse(TextEditorCompkey.Text), (int)ultraComboAlternatives.Value);
                this.sCIPDataSet.AcceptChanges();
                this.dRIVERS_UPDATETableAdapter.Fill(this.sCIPDataSet.DRIVERS_UPDATE);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Compkey/alternative combination!");
            }
        }

        private void buttonUpdateDrivers_Click(object sender, EventArgs e)
        {
            int results;
            try
            {
                ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                ultraGrid1.UpdateData();
                CurrencyManager cm = (CurrencyManager)ultraGrid1.BindingContext[ultraGrid1.DataSource, ultraGrid1.DataMember];
                cm.EndCurrentEdit();

                results = this.dRIVERS_UPDATETableAdapter.Update(this.sCIPDataSet.DRIVERS_UPDATE);
                this.sCIPDataSet.DRIVERS_UPDATE.AcceptChanges();

                this.dRIVERSTableAdapter = new SCIPDataSetTableAdapters.DRIVERSTableAdapter();

                results = this.dRIVERSTableAdapter.UpdateDriversFromDriversUpdate();

                this.dRIVERS_UPDATETableAdapter.ClearBeforeFill = true;
                this.dRIVERS_UPDATETableAdapter.UpdateByCompkey(Int32.Parse(TextEditorCompkey.Text), (int)ultraComboAlternatives.Value);
                this.sCIPDataSet.AcceptChanges();
                this.dRIVERS_UPDATETableAdapter.Fill(this.sCIPDataSet.DRIVERS_UPDATE);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Compkey/alternative combination!");
            }

        }
    }
}
