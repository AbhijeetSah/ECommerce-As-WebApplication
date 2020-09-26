using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common
{
    public class UserCartCommon : Common
    {
        //public string RowId { get; set; }
        public string CartId { get; set; }
        public string ProductReferenceId { get; set; }
        public string ProductDistinctId { get; set; }
        public string ProductName { get; set; }
        public string ProductStatus { get; set; }
        public string ProductQuantity { get; set; }
        public string ProductSize { get; set; }
        public string ProductColor { get; set; }
        public string ProductPrice { get; set; }
        public string ProductCartStatus { get; set; }
        public string ProductLink { get; set; }
        public string DocName { get; set; }  //required for displaying produt image
        //public string User { get; set; }
        //public string CreatedDate { get; set; }
        
    }
}
