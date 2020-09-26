using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Computer
{
    public interface IComputerBuss
    {
        List<ComputerCommon> GetGridList(GridParam gridParam);
        List<ComputerCommon> GetList(string User, string id);

        DbResponse Manage(ComputerCommon model);
        DbResponse RecordDocument(string User, string docExt, string docName, string fulldocname, string ProductReferenceId, string ProductDistinctId, string View, string Color);
        List<ProductSearchCommon> ShowComputer();
        List<ComputerCommon> GetComputer();
    }
}
