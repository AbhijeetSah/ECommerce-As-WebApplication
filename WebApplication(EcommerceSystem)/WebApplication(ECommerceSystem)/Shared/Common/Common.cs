using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Shared.Common
{
    public class Common
    {
        public int RowId { get; set; }
        public int RowNum { get; set; }
        public int UniqueId { get; set; }
        public string User { get; set; }
        public string CreatedDate { get; set; }
        public string Action { get; set; }
        public string BreadCum { get; set; }
        public string Code { get; set; }
        public string Msg { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public int SN { get; set; }

        public string Flag { get; set; }
        public string FilterCount { get; set; }
    }
}
