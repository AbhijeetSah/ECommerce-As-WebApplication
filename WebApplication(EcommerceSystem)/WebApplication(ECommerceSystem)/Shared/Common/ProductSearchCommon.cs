using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common
{
    public class ProductSearchCommon : Common
    {
        public List<ClothesCommon> ClothesList { get; set; }
        public List<GroceriesCommon> GroceriesList { get; set; }
        public List<GadgetCommon> GadgetList { get; set; }
        public List<ComputerCommon> ComputerList { get; set; }
    }
}
