using System;
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
    }

    private void ultraButtonExport_Click(object sender, EventArgs e)
    {
      //This function should create a Microsoft Access Database and export the results
      //tables to that database.

      //Get the user to specify the output database location

      SaveFileDialog theAccessDialog = new SaveFileDialog()
      {
        AddExtension = true,
        DefaultExt = "mdb",
        Filter = "(*.mdb)|*.mdb"
      };

      DialogResult theResult = theAccessDialog.ShowDialog();
      AccessDBLoc = theAccessDialog.FileName;

      if (theResult == DialogResult.OK)
      {
        if (System.IO.File.Exists(AccessDBLoc))
          System.IO.File.Delete(AccessDBLoc);

        this.Cursor = Cursors.WaitCursor;

        this.ultraButtonExport.Enabled = false;
        lblStatus.Text = "Exporting...";
        progress.Value = 0;
        backgroundWorkerExport.RunWorkerAsync();

        this.Cursor = Cursors.Default;
      }
    }

    private void backgroundWorkerExport_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      object objAffected;

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
      worker.ReportProgress(25, "Exporting NEXT_ACTIVITIES");
      newConnection.Execute(strSQL, out objAffected, 0);

      strSQL = "SELECT * INTO ALL_ACTIVITIES FROM [ODBC;DRIVER=SQL Server;SERVER=SIRTOBY;DATABASE=SCIP;Trusted_Connection=Yes].[VW_ALL_ACTIVITIES]";
      cmd.CommandText = strSQL;
      worker.ReportProgress(50, "Exporting ALL_ACTIVITIES");
      newConnection.Execute(strSQL, out objAffected, 0);

      strSQL = "SELECT * INTO ALL_DRIVERS FROM [ODBC;DRIVER=SQL Server;SERVER=SIRTOBY;DATABASE=SCIP;Trusted_Connection=Yes].[VW_ALL_DRIVERS]";
      cmd.CommandText = strSQL;
      worker.ReportProgress(75, "Exporting ALL_DRIVERS");
      newConnection.Execute(strSQL, out objAffected, 0);

      newConnection.Close();

    }

    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      progress.Value = 0;
      this.ultraButtonExport.Enabled = true;
      lblStatus.Text = "Export complete: " + AccessDBLoc;
    }

    private void ExportDatabasePage_Load(object sender, EventArgs e)
    {
      lblStatus.Text = "";
      progress.Value = 0;
    }

    private void backgroundWorkerExport_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      progress.Value = e.ProgressPercentage;
      lblStatus.Text = e.UserState as string;
    }
  }
}
