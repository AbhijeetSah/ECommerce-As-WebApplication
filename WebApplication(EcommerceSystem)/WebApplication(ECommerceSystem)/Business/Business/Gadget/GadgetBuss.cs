using Reposatory.Repository.Gadget;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Gadget
{
    public class GadgetBuss :IGadgetBuss
    {
        IGadgetRepo repo;
        public GadgetBuss(GadgetRepo _repo)
        {
            repo = _repo;
        }
        public List<GadgetCommon> GetGridList(GridParam gridParam)
        {
            return repo.GetGridList(gridParam);
        }
        public List<GadgetCommon> GetList(string User, string id)
        {
            return repo.GetList(User, id);
        }

        public DbResponse Manage(GadgetCommon model)
        {
            return repo.Manage(model);
        }
        public DbResponse RecordDocument(string User, string docExt, string docName, string fulldocname, string ProductReferenceId, string ProductDistinctId, string View, string Color)
        {
            return repo.RecordDocument(User, docExt, docName, fulldocname, ProductReferenceId, ProductDistinctId, View, Color);
        }
        public List<ProductSearchCommon> ShowGadget()
        {
            return repo.ShowGadget();
        }
        public List<GadgetCommon> GetGadget()
        {
            return repo.GetGadget();
        }
        


    }
}
