using GNForm3C.BAL;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Web.Script.Services;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
[ScriptService]

public  class AutoCompleteService : System.Web.Services.WebService
{
    [WebMethod]
    public   List<string> GetSuggestions(string prefixText)
    {
        EMP_EmployeeDetailBAL balEMP_EmployeeDetail = new EMP_EmployeeDetailBAL();
        // Sample data source
        List<string> suggestions = balEMP_EmployeeDetail.GetEmployeeNames(prefixText, 200);

        // Filter suggestions based on the prefixText
        return suggestions;
    }
}
