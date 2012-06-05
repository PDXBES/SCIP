using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
  public partial class HomePage : UI.ChildFormTemplate
  {
    public HomePage()
    {
      InitializeComponent();
    }

    private void btnGeneric_Click(object sender, EventArgs e)
    {
      AppForm.SwitchToTab((sender as Control).Tag as string);
    }
  }
}
