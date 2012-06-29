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
    public partial class DriverTypesPage : ChildFormTemplate
    {
        public DriverTypesPage()
        {
            InitializeComponent();
        }

        private void UpdateTableAdapters()
        {
          this.dRIVER_TYPES_UPDATETableAdapter.Fill(this.sCIPDataSet.DRIVER_TYPES_UPDATE);
          this.aLTERNATIVESTableAdapter.Fill(this.sCIPDataSet.ALTERNATIVES);
        }

        private void FormDriverTypes_Load(object sender, EventArgs e)
        {
          UpdateTableAdapters();
          ultraComboAlternative.Value = this.sCIPDataSet.ALTERNATIVES[0][0];
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
            try
            {
                ultraGridDriverTypes.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                ultraGridDriverTypes.UpdateData();
                CurrencyManager cm = (CurrencyManager)ultraGridDriverTypes.BindingContext[ultraGridDriverTypes.DataSource, ultraGridDriverTypes.DataMember];
                cm.EndCurrentEdit();

                this.dRIVER_TYPES_UPDATETableAdapter.Update(this.sCIPDataSet.DRIVER_TYPES_UPDATE);
                this.sCIPDataSet.DRIVER_TYPES_UPDATE.AcceptChanges();


                SCIPDataSetTableAdapters.DRIVER_TYPESTableAdapter dRIVER_TYPESTableAdapter = new SCIPDataSetTableAdapters.DRIVER_TYPESTableAdapter();

                dRIVER_TYPESTableAdapter.GetDataByUpdateDriverTypesFromDriverTypesUpdate();

                this.dRIVER_TYPES_UPDATETableAdapter.ClearBeforeFill = true;
                this.dRIVER_TYPES_UPDATETableAdapter.FillByAlternativeID(this.sCIPDataSet.DRIVER_TYPES_UPDATE, (int)ultraComboAlternative.Value);
                this.sCIPDataSet.AcceptChanges();
                this.dRIVER_TYPES_UPDATETableAdapter.Fill(this.sCIPDataSet.DRIVER_TYPES_UPDATE);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid alternative!");
            }
        }

        private void ultraComboAlternative_BeforeDropDown(object sender, CancelEventArgs e)
        {
          UpdateTableAdapters();
        }
    }
}
