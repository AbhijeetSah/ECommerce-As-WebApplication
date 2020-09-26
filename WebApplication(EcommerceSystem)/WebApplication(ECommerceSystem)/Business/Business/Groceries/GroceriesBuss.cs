using Reposatory.Repository.Groceries;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Groceries
{
    public class GroceriesBuss : IGroceriesBuss
    {
        IGroceriesRepo repo;
        public GroceriesBuss(GroceriesRepo _repo)
        {
            repo = _repo;
        }
        public List<GroceriesCommon> GetGridList(GridParam gridParam)
        {
            return repo.GetGridList(gridParam);
        }
        public List<GroceriesCommon> GetList(string User, string id)
        {
            return repo.GetList(User, id);
        }

        public DbResponse Manage(GroceriesCommon model)
        {
            return repo.Manage(model);
        }
        public DbResponse RecordDocument(string User, string docExt, string docName, string fulldocname, string ProductReferenceId, string ProductDistinctId, string View, string Color)
        {
            return repo.RecordDocument(User, docExt, docName, fulldocname, ProductReferenceId, ProductDistinctId, View, Color);
        }
        public List<ProductSearchCommon> ShowGroceries()
        {
            return repo.ShowGroceries();
        }
        public List<GroceriesCommon> GetGroceries()
        {
            return repo.GetGroceries();
        }

    }
}
