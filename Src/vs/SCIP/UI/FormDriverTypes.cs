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
            // TODO: This line of code loads data into the 'sCIPDataSet.DRIVER_TYPES_UPDATE' table. You can move, or remove it, as needed.
            this.dRIVER_TYPES_UPDATETableAdapter.Fill(this.sCIPDataSet.DRIVER_TYPES_UPDATE);
            // TODO: This line of code loads data into the 'sCIPDataSet.DRIVER_TYPES' table. You can move, or remove it, as needed.
            this.dRIVER_TYPESTableAdapter.Fill(this.sCIPDataSet.DRIVER_TYPES);

        }
    }
}
