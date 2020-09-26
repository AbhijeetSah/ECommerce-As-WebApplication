using Reposatory.Repository.Computer;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Computer
{
    public class ComputerBuss: IComputerBuss
    {
        IComputerRepo repo;
        public ComputerBuss(ComputerRepo _repo)
        {
            repo = _repo;
        }
        public List<ComputerCommon> GetGridList(GridParam gridParam)
        {
            return repo.GetGridList(gridParam);
        }
        public List<ComputerCommon> GetList(string User, string id)
        {
            return repo.GetList(User, id);
        }

        public DbResponse Manage(ComputerCommon model)
        {
            return repo.Manage(model);
        }
        public DbResponse RecordDocument(string User, string docExt, string docName, string fulldocname, string ProductReferenceId, string ProductDistinctId, string View, string Color)
        {
            return repo.RecordDocument(User, docExt, docName, fulldocname, ProductReferenceId, ProductDistinctId, View, Color);
        }
        public List<ProductSearchCommon> ShowComputer()
        {
            return repo.ShowComputer();
        }
        public List<ComputerCommon> GetComputer()
        {
            return repo.GetComputer();
        }


    }
}
