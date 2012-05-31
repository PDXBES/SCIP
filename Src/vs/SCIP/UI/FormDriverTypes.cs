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
    public partial class FormDriverTypes : Form
    {
        public FormDriverTypes()
        {
            InitializeComponent();
        }

        private void FormDriverTypes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sCIPDataSet.ALTERNATIVES' table. You can move, or remove it, as needed.
            this.aLTERNATIVESTableAdapter.Fill(this.sCIPDataSet.ALTERNATIVES);
            // TODO: This line of code loads data into the 'sCIPDataSet.DRIVER_TYPES_UPDATE' table. You can move, or remove it, as needed.
            this.dRIVER_TYPES_UPDATETableAdapter.Fill(this.sCIPDataSet.DRIVER_TYPES_UPDATE);
            // TODO: This line of code loads data into the 'sCIPDataSet.DRIVER_TYPES' table. You can move, or remove it, as needed.
            this.dRIVER_TYPESTableAdapter.Fill(this.sCIPDataSet.DRIVER_TYPES);
        }

        private void ComboAlternativeChanged(object sender, EventArgs e)
        {
            this.dRIVER_TYPES_UPDATETableAdapter.Empty(this.sCIPDataSet.DRIVER_TYPES_UPDATE);
            try
            {
                this.dRIVER_TYPES_UPDATETableAdapter.FillByAlternativeID(this.sCIPDataSet.DRIVER_TYPES_UPDATE, (int)ultraComboAlternative.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid alternative");
            }
        }

        private void ultraButtonRevertDriverTypes_Click(object sender, EventArgs e)
        {
            try
            {
                this.dRIVER_TYPES_UPDATETableAdapter.FillByAlternativeID(this.sCIPDataSet.DRIVER_TYPES_UPDATE, (int)ultraComboAlternative.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid alternative");
            }
        }

        private void ultraButtonUpdateDriverTypes_Click(object sender, EventArgs e)
        {
            int results;

            ultraGridDriverTypes.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            ultraGridDriverTypes.UpdateData();
            CurrencyManager cm = (CurrencyManager)ultraGridDriverTypes.BindingContext[ultraGridDriverTypes.DataSource, ultraGridDriverTypes.DataMember];
            cm.EndCurrentEdit();

            this.dRIVER_TYPES_UPDATETableAdapter.Update(this.sCIPDataSet.DRIVER_TYPES_UPDATE);
            this.sCIPDataSet.DRIVER_TYPES_UPDATE.AcceptChanges();

            this.dRIVER_TYPESTableAdapter = new SCIPDataSetTableAdapters.DRIVER_TYPESTableAdapter();

            results = this.dRIVER_TYPESTableAdapter.UpdateDriverTypesFromDriverTypesUpdate();

            this.dRIVER_TYPES_UPDATETableAdapter.ClearBeforeFill = true;
            this.dRIVER_TYPES_UPDATETableAdapter.FillByAlternativeID(this.sCIPDataSet.DRIVER_TYPES_UPDATE,  (int)ultraComboAlternative.Value);
            this.sCIPDataSet.AcceptChanges();
            this.dRIVER_TYPES_UPDATETableAdapter.Fill(this.sCIPDataSet.DRIVER_TYPES_UPDATE);
        }
    }
}
