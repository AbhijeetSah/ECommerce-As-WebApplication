using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatory.Repository.StaticData
{
    public interface IStaticDataRepository
    {
        List<Shared.Common.StaticDataCommon> GetList(string User, string Id, string Search, int Pagesize);
        Shared.Common.DbResponse Manage(Shared.Common.StaticDataCommon model);
        Shared.Common.DbResponse Delete(string User, int id);
        Shared.Common.DbResponse InsertErrorLog(Shared.Common.ErrorLogsCommon log);
        List<Shared.Common.StaticDataCommon> GetGridList(Shared.Common.GridParam gridParam);
        
    }
}
