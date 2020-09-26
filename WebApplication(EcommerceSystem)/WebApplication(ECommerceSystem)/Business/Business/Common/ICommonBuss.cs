using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Common
{
    public interface ICommonBuss
    {
        Dictionary<string, string> StaticDropdown(string ddlName);
        List<Dictionary<string, string>> SetDropdownList(string ddlName, string User);
        Dictionary<string, string> SetDropdown(string ddlName, string Param = "");
        DataSet GetDropDownLists(string flag);
        List<object> LoadAutocomplete(string type, string param);
        object GetDropdownForJQuery(string flag, string param, string User);
        object GetDropdownForJQueryForColor(string flag, string param, string User);

    }
}
