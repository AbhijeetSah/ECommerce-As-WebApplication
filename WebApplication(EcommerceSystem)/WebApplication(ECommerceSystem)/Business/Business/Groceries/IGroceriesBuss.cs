using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Groceries
{
    public interface IGroceriesBuss
    {
        List<GroceriesCommon> GetGridList(GridParam gridParam);
        List<GroceriesCommon> GetList(string User, string id);

        DbResponse Manage(GroceriesCommon model);
        DbResponse RecordDocument(string User, string docExt, string docName, string fulldocname, string ProductReferenceId, string ProductDistinctId, string View, string Color);
        List<ProductSearchCommon> ShowGroceries();
        List<GroceriesCommon> GetGroceries();

    }
}
