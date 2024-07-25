using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserControl_ShowInfo : System.Web.UI.UserControl
{
    public void ShowError(String Message)
    {
        lblError.Text = Message;
        mvwSysMessage.SetActiveView(vwError);
        mvwSysMessage.Visible = true;
    }

    public void ShowSuccess(String Message)
    {
        lblSuccess.Text = Message;
        mvwSysMessage.SetActiveView(vwSuccess);
        mvwSysMessage.Visible = true;
    }

    public void ShowInfo(String Message)
    {
        lblInfo.Text = Message;
        mvwSysMessage.SetActiveView(vwInfo);
        mvwSysMessage.Visible = true;
    }
}
