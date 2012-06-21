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
  public partial class ChildFormTemplate : Form
  {
    private Main _appForm;

    /// <summary>
    /// Constructor
    /// </summary>
    public ChildFormTemplate()
      : base()
    {
      SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.BackColor = Color.Transparent;

      InitializeComponent();
    }

    /// <summary>
    /// Initializes child form for embedding into parent main app form
    /// </summary>
    /// <param name="parentControl"></param>
    /// <param name="mainForm"></param>
    public virtual void Initialize(Control parentControl, Main mainForm)
    {
      SetParent(parentControl);
      SetAppForm(mainForm);
    }

    /// <summary>
    /// Sets the parent (main app form) for this form
    /// </summary>
    /// <param name="parentControl"></param>
    private void SetParent(Control parentControl)
    {
      TopLevel = false;
      parentControl.Controls.Add(this);
      Dock = DockStyle.Fill;
      Show();
    }

    /// <summary>
    /// Sets the application form for this form
    /// </summary>
    /// <param name="mainForm"></param>
    private void SetAppForm(Main mainForm)
    {
      _appForm = mainForm;
    }

    /// <summary>
    /// Gets the application form assigned to this form
    /// </summary>
    public Main AppForm
    {
      get { return _appForm; }
    }
  }
}
