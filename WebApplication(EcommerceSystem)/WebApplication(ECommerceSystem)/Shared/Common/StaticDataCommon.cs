using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common
{
    public class StaticDataCommon:Common
    {
        public string TypeCode { get; set; }
        public string DataCode { get; set; }
        public string DataValue { get; set; }
        public string IsActive { get; set; }
    }

    public class GridParam
    {
        public string PageSize { get; set; }
        public int DisplayLength { get; set; }
        public int DisplayStart { get; set; }
        public string SortDir { get; set; }
        public int SortCol { get; set; }
        public string Flag { get; set; }
        public string Search { get; set; }
        public string UserName { get; set; }
    }
}
