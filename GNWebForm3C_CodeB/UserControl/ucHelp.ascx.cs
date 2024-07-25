using GNForm3C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_ucHelp : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!CV.IsShowHelp)
            {
                HelpDiv.Attributes.Add("style", "display: none");
            }
           
        }
    }
    public void ShowHelp(String HelpText)
    {
        lblHelp.Text = HelpText;
        mvwSysMessage.SetActiveView(vwHelp);
        mvwSysMessage.Visible = true;
    }

}