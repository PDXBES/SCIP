using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ADOX;
using ADODB;


namespace UI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void buttonEditIndividualDrivers_Click(object sender, EventArgs e)
        {
            FormIndividualDrivers child = new FormIndividualDrivers();

            this.Enabled = false;
            child.ShowDialog();
            this.Enabled = true;

        }

        private void btnExportDatabases_Click(object sender, EventArgs e)
        {
            FormExportDatabase child = new FormExportDatabase();

            this.Enabled = false;
            child.ShowDialog();
            this.Enabled = true;
        }

        private void btnManageAlternatives_Click(object sender, EventArgs e)
        {

        }

        private void buttonEditDriverTypes_Click(object sender, EventArgs e)
        {
            FormDriverTypes child = new FormDriverTypes();

            this.Enabled = false;
            child.ShowDialog();
            this.Enabled = true;
        }
            
    }
}
