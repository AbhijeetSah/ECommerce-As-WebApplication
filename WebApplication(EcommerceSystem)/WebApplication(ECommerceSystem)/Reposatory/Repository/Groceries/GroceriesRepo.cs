using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatory.Repository.Groceries
{
    public class GroceriesRepo:IGroceriesRepo
    {
        RepositoryDao dao;
        public GroceriesRepo()
        {
            dao = new RepositoryDao();
        }

        public List<GroceriesCommon> GetGridList(GridParam gridParam)
        {
            var list = new List<GroceriesCommon>();
            try
            {
                var sql = "EXEC proc_tblGroceries ";
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
                        var common = new GroceriesCommon()
                        {
                            UniqueId = Convert.ToInt32(item["RowId"]),
                            ProductReferenceId = item["ProductReferenceId"].ToString(),
                            ProductDestintId = item["ProductDestintId"].ToString(),
                            Brand = item["Brand"].ToString(),
                            ProductName = item["ProductName"].ToString(),
                            ProductPrice = item["ProductPrice"].ToString(),
                            DiscountPercent = item["DiscountPercent"].ToString(),                            
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


        public List<GroceriesCommon> GetList(string user, string id)
        {
            var list = new List<GroceriesCommon>();
            try
            {
                var sql = "EXEC proc_tblGroceries ";
                sql += " @FLAG = " + dao.FilterString((id != "0" ? "S" : "A"));
                sql += ",@User = " + dao.FilterString(user);
                sql += ",@RowId = " + dao.FilterString(id.ToString());

                var ds = dao.ExecuteDataset(sql);

                if (null != ds.Tables[0])
                {
                    int sn = 1;
                    foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                    {
                        var common = new GroceriesCommon()
                        {
                            UniqueId = Convert.ToInt32(item["RowId"]),
                            ProductReferenceId = item["ProductReferenceId"].ToString(),
                            ProductDestintId = item["ProductDestintId"].ToString(),
                            Brand = item["Brand"].ToString(),
                            ProductName = item["ProductName"].ToString(),
                            ProductUnit = item["ProductUnit"].ToString(),
                            QuntityUnit = item["QuntityUnit"].ToString(),
                            ProductVolume = item["ProductVolume"].ToString(),
                            QuantityPerVolume = item["QuantityPerVolume"].ToString(),
                            
                            ProductDescription = item["ProductDescription"].ToString(),                            
                            SupplierEmail = item["SupplierEmail"].ToString(),
                            SupplierAddress = item["SupplierAddress"].ToString(),
                            SupplierContactNo = item["SupplierContactNo"].ToString(),
                            ProductPrice = item["ProductPrice"].ToString(),
                            OfferedPrice = item["OfferedPrice"].ToString(),
                            DiscountPercent = item["DiscountPercent"].ToString(),
                            DiscountAmount = item["DiscountAmount"].ToString(),
                            Warrenty = item["Warrenty"].ToString(),
                            WarrentyCondition = item["WarrentyCondition"].ToString(),
                            WarrentyPeriod = item["WarrentyPeriod"].ToString(),
                            Highlights = item["Highlights"].ToString(),
                            Specification = item["Specification"].ToString(),
                            TermsAndConditions = item["TermsAndConditions"].ToString(),
                            QuickLinksSEOTag = item["QuickLinksSEOTag"].ToString(),
                            ProductReviewed = item["ProductReviewed"].ToString(),
                            User = item["CreatedBy"].ToString(),
                            CreatedDate = item["CreatedDate"].ToString(),
                            

                        };

                        
                        var DocList = new List<DocumentUpload>();
                        if (ds.Tables.Count > 1)
                        {
                            if (null != ds.Tables[1])
                            {
                                foreach (System.Data.DataRow item1 in ds.Tables[1].Rows)
                                {
                                    var Doc = new DocumentUpload()
                                    {
                                        View = item1["Viewof"].ToString(),
                                        Color = item1["Color"].ToString(),
                                        DocName = item1["DocName"].ToString(),


                                    };
                                    DocList.Add(Doc);
                                }
                            }
                        }
                        common.Doc = DocList;
                        


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

        public DbResponse Manage(GroceriesCommon model)
        {
           
            try
            {
                var sql = "EXEC proc_tblGroceries ";
                sql += " @flag = " + dao.FilterString((model.UniqueId > 0 ? "U" : "I"));
                sql += ",@User = " + dao.FilterString(model.User);
                sql += ",@RowId = " + dao.FilterString(model.UniqueId.ToString());
                sql += ",@ProductReferenceId = " + dao.FilterString(model.ProductReferenceId == null ? "" : model.ProductReferenceId.ToString());
                sql += ",@ProductDestintId=" + dao.FilterString(model.ProductDestintId == null ? "" : model.ProductDestintId.ToString());
                sql += ",@Brand=" + dao.FilterString(model.Brand == null ? "" : model.Brand.ToString());
                sql += ",@ProductName=" + dao.FilterString(model.ProductName == null ? "" : model.ProductName.ToString());
                sql += ",@ProductUnit=" + dao.FilterString(model.ProductUnit == null ? "" : model.ProductUnit.ToString());
                sql += ",@QuntityUnit=" + dao.FilterString(model.QuntityUnit == null ? "" : model.QuntityUnit.ToString());
                sql += ",@ProductVolume=" + dao.FilterString(model.ProductVolume == null ? "" : model.ProductVolume.ToString());
                sql += ",@QuantityPerVolume=" + dao.FilterString(model.QuantityPerVolume == null ? "" : model.QuantityPerVolume.ToString());
                
                sql += ",@OfferedPrice=" + dao.FilterString(model.OfferedPrice == null ? "" : model.OfferedPrice.ToString());
                sql += ",@DiscountPercent=" + dao.FilterString(model.DiscountPercent == null ? "" : model.DiscountPercent.ToString());
                sql += ",@DiscountAmount=" + dao.FilterString(model.DiscountAmount == null ? "" : model.DiscountAmount.ToString());
                sql += ",@ProductPrice=" + dao.FilterString(model.ProductPrice == null ? "" : model.ProductPrice.ToString());
                sql += ",@QuickLinksSEOTag=" + dao.FilterString(model.QuickLinksSEOTag == null ? "" : model.QuickLinksSEOTag.ToString());
                sql += ",@Warrenty=" + dao.FilterString(model.Warrenty == null ? "" : model.Warrenty.ToString());
                sql += ",@WarrentyPeriod=" + dao.FilterString(model.WarrentyPeriod == null ? "" : model.WarrentyPeriod.ToString());
                sql += ",@WarrentyCondition=" + dao.FilterString(model.WarrentyCondition == null ? "" : model.WarrentyCondition.ToString());
                sql += ",@ProductDescription=" + dao.FilterString(model.ProductDescription == null ? "" : model.ProductDescription.ToString());
                sql += ",@TermsAndConditions=" + dao.FilterString(model.TermsAndConditions == null ? "" : model.TermsAndConditions.ToString());
                sql += ",@Highlights=" + dao.FilterString(model.Highlights == null ? "" : model.Highlights.ToString());
                sql += ",@Specification=" + dao.FilterString(model.Specification == null ? "" : model.Specification.ToString());
                

                return dao.ParseDbResponse(sql);
            }
            catch (Exception ex)
            {
                return dao.ExceptionDbResponse(ex.Message);
            }

        }


        public DbResponse RecordDocument(string User, string docExt, string docName, string fulldocname, string ProductReferenceId, string ProductDistinctId, string View, string Color)
        {
            try
            {
                var sql = "EXEC proc_tblDocUpload ";
                sql += "@flag= " + dao.FilterString("DocUpload");
                sql += ",@User = " + dao.FilterString(User);
                sql += ",@DocFor = " + dao.FilterString("Groceries");
                sql += ",@DocExt = " + dao.FilterString(docExt);
                sql += ",@DocName = " + dao.FilterString(docName);
                sql += ",@DocPath = " + dao.FilterString(fulldocname);
                sql += ",@ProductReferenceId = " + dao.FilterString(ProductReferenceId);
                sql += ",@ProductDistinctId = " + dao.FilterString(ProductDistinctId);
                sql += ",@Viewof = " + dao.FilterString(View);
                sql += ",@Color = " + dao.FilterString(Color == null ? "" : Color);
                

                return dao.ParseDbResponse(sql);

            }
            catch (Exception ex)
            {
                return dao.ExceptionDbResponse(ex.Message);

            }
            
        }

        public List<ProductSearchCommon> ShowGroceries()
        {
            var list = new List<ProductSearchCommon>();
            var groceriesList = new List<GroceriesCommon>();
            var sql = "Exec proc_tblGroceries";
            sql += " @Flag = " + dao.FilterString("ShowGroceries");
            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var table = item["TableName"].ToString();
                    if (table == "tblGroceries")
                    {
                        var Groceries = new GroceriesCommon()
                        {
                            ProductReferenceId = item["ProductReferenceId"].ToString(),
                            ProductDestintId = item["ProductDestintId"].ToString(),
                            ProductName = item["ProductName"].ToString(),
                            Brand = item["Brand"].ToString(),
                            OfferedPrice = item["OfferedPrice"].ToString(),
                            ProductPrice = item["ProductPrice"].ToString(),
                            DiscountPercent = item["DiscountPercent"].ToString(),
                            DiscountAmount = item["DiscountAmount"].ToString(),
                            WarrentyPeriod = item["WarrentyPeriod"].ToString(),
                            //ProductReviewed=item["ProductReviewed"].ToString(),
                            Doc1 = item["Doc1"].ToString(),
                            Doc2 = item["Doc2"].ToString()

                        };
                        groceriesList.Add(Groceries);
                    }
                }
            }
            if (null != dt)
            {
                var productSearch = new ProductSearchCommon()
                {
                    GroceriesList = groceriesList

                };
                list.Add(productSearch);
            }
            return list;


        }
        public List<GroceriesCommon> GetGroceries()
        {
            
            var groceriesList = new List<GroceriesCommon>();
            var sql = "Exec proc_tblGroceries";
            sql += " @Flag = " + dao.FilterString("ShowGroceries");
            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var table = item["TableName"].ToString();
                    if (table == "tblGroceries")
                    {
                        var Groceries = new GroceriesCommon()
                        {
                            ProductReferenceId = item["ProductReferenceId"].ToString(),
                            ProductDestintId = item["ProductDestintId"].ToString(),
                            ProductName = item["ProductName"].ToString(),
                            Brand = item["Brand"].ToString(),
                            OfferedPrice = item["OfferedPrice"].ToString(),
                            ProductPrice = item["ProductPrice"].ToString(),
                            DiscountPercent = item["DiscountPercent"].ToString(),
                            DiscountAmount = item["DiscountAmount"].ToString(),
                            WarrentyPeriod = item["WarrentyPeriod"].ToString(),
                            //ProductReviewed=item["ProductReviewed"].ToString(),
                            Doc1 = item["Doc1"].ToString(),
                            Doc2 = item["Doc2"].ToString()

                        };
                        groceriesList.Add(Groceries);
                    }
                }
            }
            
            return groceriesList;


        }

    }
}
