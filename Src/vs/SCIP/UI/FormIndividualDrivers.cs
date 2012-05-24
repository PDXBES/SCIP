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
    public partial class FormIndividualDrivers : Form
    {
        public FormIndividualDrivers()
        {
            InitializeComponent();
        }

        private void FormIndividualDrivers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sCIPDataSet.DRIVERS_UPDATE' table. You can move, or remove it, as needed.
            this.dRIVERS_UPDATETableAdapter.Fill(this.sCIPDataSet.DRIVERS_UPDATE);

        }
    }
}
