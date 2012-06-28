﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADOX;
using ADODB;

namespace UI
{
    public partial class ExportDatabasePage : ChildFormTemplate
    {
        string AccessDBLoc = "";

        public ExportDatabasePage()
        {
            InitializeComponent();
            // TODO: This line of code loads data into the 'sCIPDataSet.ALTERNATIVES' table. You can move, or remove it, as needed.
            this.aLTERNATIVESTableAdapter.Fill(this.sCIPDataSet.ALTERNATIVES);
            this.comboAlternativeID.Value = this.sCIPDataSet.ALTERNATIVES[0][0];
        }

        private void ultraButtonExport_Click(object sender, EventArgs e)
        {
            //This function should create a Microsoft Access Database and export the results
            //tables to that database.

            //Get the user to specify the output database location
            
            SaveFileDialog theAccessDialog = new SaveFileDialog();
            theAccessDialog.AddExtension = true;
            theAccessDialog.DefaultExt = "mdb";
            theAccessDialog.Filter = "(*.mdb)|*.mdb";

            DialogResult theResult = theAccessDialog.ShowDialog();
            AccessDBLoc = theAccessDialog.FileName;

            if (theResult == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                this.ultraButtonExport.Enabled = false;
                ultraActivityIndicator1.Start();
                backgroundWorkerExport.RunWorkerAsync();


                //backgroundWorkerExport.CancelAsync();

                this.Cursor = Cursors.Default;
            }
        }

        private void backgroundWorkerExport_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            object objAffected;
            int alternative_id = (int)comboAlternativeID.Value;

            try
            {
                string tmpStr;
                tmpStr = "Provider=Microsoft.Jet.OLEDB.4.0;";
                tmpStr += "Data Source=" + AccessDBLoc + ";User Id=admin;Password=;";

                ADOX.Catalog thecat = new Catalog();

                ADODB.Command cmd = new Command();

                thecat.Create(tmpStr);
                ADODB.Connection connection = thecat.ActiveConnection as ADODB.Connection;

                if (connection != null)
                {
                    connection.Close();
                }
                thecat.ActiveConnection = null;
                thecat = null;

                ADODB.Connection newConnection = new Connection();
                newConnection.ConnectionString = tmpStr;

                newConnection.Open();

                string strSQL = "SELECT * INTO NEXT_ACTIVITIES FROM [ODBC;DRIVER=SQL Server;SERVER=SIRTOBY;DATABASE=SCIP;Trusted_Connection=Yes].[NEXT_ACTIVITIES]";
                cmd.CommandText = strSQL;
                newConnection.Execute(strSQL, out objAffected, 0);

                strSQL = "SELECT * INTO ALL_ACTIVITIES FROM [ODBC;DRIVER=SQL Server;SERVER=SIRTOBY;DATABASE=SCIP;Trusted_Connection=Yes].[VW_ALL_ACTIVITIES] WHERE Alternative_ID = " + alternative_id.ToString();
                cmd.CommandText = strSQL;
                newConnection.Execute(strSQL, out objAffected, 0);

                strSQL = "SELECT * INTO ALL_DRIVERS FROM [ODBC;DRIVER=SQL Server;SERVER=SIRTOBY;DATABASE=SCIP;Trusted_Connection=Yes].[VW_ALL_DRIVERS] WHERE Alternative_ID = " + alternative_id.ToString();
                cmd.CommandText = strSQL;
                newConnection.Execute(strSQL, out objAffected, 0);

                strSQL = "SELECT * INTO DRIVER_TYPES FROM [ODBC;DRIVER=SQL Server;SERVER=SIRTOBY;DATABASE=SCIP;Trusted_Connection=Yes].[DRIVER_TYPES] WHERE Alternative_ID = " + alternative_id.ToString();
                cmd.CommandText = strSQL;
                newConnection.Execute(strSQL, out objAffected, 0);

                newConnection.Close();

                MessageBox.Show("Export process complete!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error!");
            }

        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ultraActivityIndicator1.Stop();
            this.ultraButtonExport.Enabled = true;
        }

        private void ExportDatabasePage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sCIPDataSet.ALTERNATIVES' table. You can move, or remove it, as needed.
            this.aLTERNATIVESTableAdapter.Fill(this.sCIPDataSet.ALTERNATIVES);

        }
    }
}
