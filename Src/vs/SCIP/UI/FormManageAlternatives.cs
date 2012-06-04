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
    public partial class FormManageAlternatives : Form
    {
        public FormManageAlternatives()
        {
            InitializeComponent();
        }

        private void FormManageAlternatives_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sCIPDataSet.ALTERNATIVES' table. You can move, or remove it, as needed.
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
    }
}
