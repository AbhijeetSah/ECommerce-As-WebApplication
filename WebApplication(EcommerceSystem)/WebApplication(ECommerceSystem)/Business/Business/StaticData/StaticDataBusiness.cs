using Reposatory.Repository.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Common;

namespace Business.Business.StaticData
{
    public class StaticDataBusiness : IStaticDataBusiness
    {
        IStaticDataRepository repo;
        public StaticDataBusiness(StaticDataRepository _repo)
        {
            repo = _repo;
        }
        public StaticDataBusiness()
        {
            // TODO: Complete member initialization
        }

        public List<StaticDataCommon> GetList(string User, string Id, string Search, int Pagesize)
        {
            return repo.GetList(User, Id, Search, Pagesize);
        }


        public DbResponse Manage(StaticDataCommon model)
        {
            return repo.Manage(model);
        }
        public DbResponse Delete(string User, int id)
        {
            return repo.Delete(User, id);
        }
        public Shared.Common.DbResponse InsertErrorLog(Shared.Common.ErrorLogsCommon log)
        {
            if (null == repo)
                repo = new StaticDataRepository();

            return repo.InsertErrorLog(log);
        }
        public List<Shared.Common.StaticDataCommon> GetGridList(GridParam gridParam)
        {
            return repo.GetGridList(gridParam);
        }
    }
}
