using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_ucFieldHelp : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void ShowFieldHelp(String HelpText)
    {
        lblFieldHelp.Attributes.Add("data-content", HelpText);

    }
    public void ShowFieldHelp(String HelpTextHeader, String HelpText)
    {
        lblFieldHelp.Attributes.Add("data-original-title", HelpTextHeader);
        lblFieldHelp.Attributes.Add("data-content", HelpText);
    }
}