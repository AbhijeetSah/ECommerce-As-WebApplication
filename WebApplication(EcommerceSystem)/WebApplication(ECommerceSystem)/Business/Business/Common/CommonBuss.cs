using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reposatory.Repository.Common;

namespace Business.Business.Common
{
    public class CommonBuss : ICommonBuss
    {
        ICommonRepo repo;
        public CommonBuss(CommonRepo _repo)
        {
            repo = _repo;
        }
        public Dictionary<string, string> StaticDropdown(string ddlName)
        {
            return repo.StaticDropdown(ddlName);
        }
        public List<Dictionary<string, string>> SetDropdownList(string ddlName, string User)
        {
            return repo.DropdownList(ddlName, User);
        }
        public Dictionary<string, string> SetDropdown(string ddlName, string Param = "")
        {
            return repo.Dropdown(ddlName, Param);
        }
        public System.Data.DataSet GetDropDownLists(string flag)
        {
            return repo.GetDropDownLists(flag);
        }
        public List<object> LoadAutocomplete(string type, string param)
        {
            return repo.LoadAutocomplete(type, param);
        }
        public object GetDropdownForJQuery(string flag, string param, string User)
        {
            return repo.GetDropdownForJQuery(flag, param, User);
        }
        public object GetDropdownForJQueryForColor(string flag, string param, string User)
        {
            return repo.GetDropdownForJQueryForColor(flag, param, User);
        }
    }
}
