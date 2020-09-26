using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Shared.Common
{
    public class DocumentUpload:Common
    {
        public string View { get; set; }
        public string Color { get; set; }
        public HttpPostedFileBase Img { get; set; }       
        public string Preview { get; set; }
        public string DocName { get; set; }

    }
}
