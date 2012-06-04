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
    #region Variables

    private Dictionary<string, ChildFormTemplate> _pages = 
      new Dictionary<string, ChildFormTemplate>();

    #endregion

    #region Methods

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
      tabMain.SelectedTab = tabMain.Tabs["ExportDatabase"];
    }

    private void btnManageAlternatives_Click(object sender, EventArgs e)
    {
      FormManageAlternatives child = new FormManageAlternatives();

      this.Enabled = false;
      child.ShowDialog();
      this.Enabled = true;
    }

    private void buttonEditDriverTypes_Click(object sender, EventArgs e)
    {
      tabMain.SelectedTab = tabMain.Tabs["DriverTypes"];
    }

    private void btnCreateCharts_Click(object sender, EventArgs e)
    {
      tabMain.SelectedTab = tabMain.Tabs["Charts"];
    }

    private void Main_Load(object sender, EventArgs e)
    {
      tabMain.SelectedTab = tabMain.Tabs["Home"];
      tabMain.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
    }

    private void InitializePage(string pageBaseName)
    {
      object[] pageConstructorParams = new object[] { };

      _pages.Add(
        pageBaseName,
        (Activator.CreateInstance(
          Type.GetType(string.Format("UI.{0}{1}", pageBaseName.Replace(" ", null), "Page")),
          pageConstructorParams) as ChildFormTemplate));
      _pages[pageBaseName].Initialize(tabMain.Tabs[pageBaseName].TabPage, this);
    }

    private void tabMain_SelectedTabChanging(object sender, 
      Infragistics.Win.UltraWinTabControl.SelectedTabChangingEventArgs e)
    {
      switch (e.Tab.Key)
      {
        case "Charts":
        case "DriverTypes":
        case "ExportDatabase":
          if (!_pages.ContainsKey(e.Tab.Key))
            InitializePage(e.Tab.Key);
          break;
      }
    }
    #endregion

  }
}
