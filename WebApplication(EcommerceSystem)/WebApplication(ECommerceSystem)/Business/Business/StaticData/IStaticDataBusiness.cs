using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Business.Business.StaticData
{
    public interface IStaticDataBusiness
    {

        //List<StaticDataCommon> GetSubList(string User, string Id);
        List<StaticDataCommon> GetList(string User, string Id, string Search, int Pagesize);
        DbResponse Manage(StaticDataCommon model);
        DbResponse Delete(string User, int id);
        DbResponse InsertErrorLog(ErrorLogsCommon log);      
        List<StaticDataCommon> GetGridList(GridParam gridParam);

    }
}
