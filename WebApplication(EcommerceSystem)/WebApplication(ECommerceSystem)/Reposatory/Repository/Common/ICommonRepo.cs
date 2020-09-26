using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatory.Repository.Common
{
    public interface ICommonRepo
    {
        Dictionary<string, string> StaticDropdown(string ddlName);
        List<Dictionary<string, string>> DropdownList(string ddlName, string User);
        Dictionary<string, string> Dropdown(string ddlName, string Param);
        System.Data.DataSet GetDropDownLists(string flag);
        List<object> LoadAutocomplete(string type, string param);
        object GetDropdownForJQuery(string flag, string param, string User);
        object GetDropdownForJQueryForColor(string flag, string param, string User);
    }
}
