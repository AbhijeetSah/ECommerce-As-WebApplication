using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common
{
    public class NotificationCommon : Common
    {
       // public string RowId { get; set; }
        public string NotificationSubject { get; set; }
        public string NotificationBody { get; set; }
        public string NotificationFor { get; set; }
        public string NotificationBy { get; set; }
        public string NotificationStatus { get; set; }
        public string isRead { get; set; }
       
    }
}
