using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Gadget
{
    public interface IGadgetBuss 
    {
        List<GadgetCommon> GetGridList(GridParam gridParam);
        List<GadgetCommon> GetList(string User, string id);

        DbResponse Manage(GadgetCommon model);
        DbResponse RecordDocument(string User, string docExt, string docName, string fulldocname, string ProductReferenceId, string ProductDistinctId, string View, string Color);
        List<ProductSearchCommon> ShowGadget();
        List<GadgetCommon> GetGadget();

    }
}
