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

    public void SwitchToTab(string tabName)
    {
      tabMain.SelectedTab = tabMain.Tabs[tabName];
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
      _pages[pageBaseName].Dock = DockStyle.Fill;
    }

    private void tabMain_SelectedTabChanging(object sender, 
      Infragistics.Win.UltraWinTabControl.SelectedTabChangingEventArgs e)
    {
      switch (e.Tab.Key)
      {
        case "Home":
        case "Charts":
        case "DriverTypes":
        case "ExportDatabase":
        case "IndividualDrivers":
        case "Alternatives":
        case "Model":
          if (!_pages.ContainsKey(e.Tab.Key))
            InitializePage(e.Tab.Key);
          break;
      }

      lblPageTitle.Text = e.Tab.Text;
    }
    #endregion

    private void btnHome_Click(object sender, EventArgs e)
    {
      SwitchToTab("Home");
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void tabMain_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
    {
      btnHome.Enabled = tabMain.SelectedTab.Key != "Home";
    }

  }
}
