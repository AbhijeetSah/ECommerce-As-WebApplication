using Shared.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatory.Repository.StaticData
{
    public class StaticDataRepository : IStaticDataRepository
    {
        RepositoryDao dao;
        public StaticDataRepository()
        {
            dao = new RepositoryDao();
        }
        public List<StaticDataCommon> GetList(string user, string id, string Search, int Pagesize)
        {
            var list = new List<StaticDataCommon>();
            try
            {

                var sql = "EXEC proc_tblStaticData ";
                sql += " @FLAG = " + dao.FilterString(id != "0" ? "S" : "A");
                sql += ",@User = " + dao.FilterString(user);
                sql += ",@ID = " + dao.FilterString(id.ToString());
                sql += ",@Search = " + dao.FilterString(Search);
                sql += ",@Pagesize = " + dao.FilterString(Pagesize.ToString());

                var dt = dao.ExecuteDataTable(sql);
                if (null != dt)
                {
                    int sn = 1;
                    foreach (DataRow item in dt.Rows)
                    {
                        var common = new StaticDataCommon()
                        {

                            UniqueId = Convert.ToInt32(item["Id"]),
                            TypeCode = item["StaticCode"].ToString(),
                            //StaticData = item["StaticData"].ToString(),
                            DataCode = item["Code"].ToString(),
                            DataValue = item["Value"].ToString(),
                            IsActive = item["IsActive"].ToString(),
                            User = item["CreatedBy"].ToString(),
                            CreatedDate = item["CreatedDate"].ToString()
                        };
                        sn++;
                        list.Add(common);
                    }
                }
            }
            catch (Exception e)
            {

                return list;
            }

            return list;
        }
        public DbResponse Manage(StaticDataCommon model)
        {
            var sql = "EXEC proc_tblStaticData ";
            sql += " @FLAG = " + dao.FilterString((model.UniqueId > 0 ? "U" : "I"));
            sql += ",@User = " + dao.FilterString(model.User);
            sql += ",@Id = " + dao.FilterString(model.UniqueId.ToString());
            sql += ",@StaticCode = " + dao.FilterString(model.TypeCode);
            sql += ",@Code = " + dao.FilterString(model.DataCode);
            sql += ",@Value = " + dao.FilterString(model.DataValue);
            sql += ",@IsActive= " + dao.FilterString(model.IsActive); ;
            //ssql += ",@NepValue = " + dao.FilterString_NVARCHAR(model.NepValue);
            return dao.ParseDbResponse(sql);
        }

        public DbResponse Delete(string User, int id)
        {
            var sql = "EXEC proc_tblStaticData ";
            sql += " @FLAG = " + dao.FilterString("D");
            sql += ",@User = " + dao.FilterString(User);
            sql += ",@Id = " + dao.FilterString(id.ToString());
            return dao.ParseDbResponse(sql);
        }
        public DbResponse InsertErrorLog(ErrorLogsCommon log)
        {
            var sql = "EXEC proc_tblErrors ";
            sql += " @FLAG = " + dao.FilterString("I");
            sql += ",@User = " + dao.FilterString(log.User);
            sql += ",@ErrorPage = " + dao.FilterString(log.ErrorPage);
            sql += ",@ErrorMsg = " + dao.FilterString(log.ErrorMsg);
            sql += ",@ErrorDetail = " + dao.FilterString(log.ErrorDetail);
            return dao.ParseDbResponse(sql);
        }
        public List<StaticDataCommon> GetGridList(GridParam gridParam)
        {
            var list = new List<StaticDataCommon>();
            try
            {
                var sql = "EXEC proc_tblStaticData ";
                sql += " @FLAG = " + dao.FilterString("A");
                sql += ",@User = " + dao.FilterString(gridParam.UserName);
                sql += ",@Search = " + dao.FilterString(gridParam.Search);
                sql += ",@DisplayLength = " + dao.FilterString(gridParam.DisplayLength.ToString());
                sql += ",@DisplayStart = " + dao.FilterString(gridParam.DisplayStart.ToString());
                sql += ",@SortDir = " + dao.FilterString(gridParam.SortDir);
                sql += ",@SortCol = " + dao.FilterString(gridParam.SortCol.ToString());
                var dt = dao.ExecuteDataTable(sql);

                if (null != dt)
                {
                    int sn = 1;
                    foreach (System.Data.DataRow item in dt.Rows)
                    {
                        var common = new StaticDataCommon()
                        {
                            UniqueId = Convert.ToInt32(item["RowNum"]),
                            TypeCode = item["StaticCode"].ToString(),
                            DataCode = item["Code"].ToString(),
                            DataValue = item["Value"].ToString(),
                            IsActive = item["IsActive"].ToString(),
                            User = item["CreatedBy"].ToString(),
                            CreatedDate = item["CreatedDate"].ToString(),
                            FilterCount = item["FilterCount"].ToString(),
                        };
                        sn++;
                        list.Add(common);
                    }
                }
                return list;
            }

            catch (Exception e)
            {
                return list;
            }

        }

    }
}
