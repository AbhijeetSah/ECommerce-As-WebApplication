using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Common;

namespace Reposatory.Repository.Clothes
{
    public class ClothesRepo: IClothesRepo
    {
        RepositoryDao dao;
        public ClothesRepo()
        {
            dao = new RepositoryDao();
        }

        public List<ClothesCommon> GetGridList(GridParam gridParam)
        {
            var list = new List<ClothesCommon>();
            try
            {
                var sql = "EXEC proc_tblClothes ";
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
                        var common = new ClothesCommon()
                        {
                            UniqueId = Convert.ToInt32(item["RowId"]),
                            ProductReferenceId = item["ProductReferenceId"].ToString(),
                            ProductDestintId = item["ProductDestintId"].ToString(),
                            Brand = item["Brand"].ToString(),
                            ProductName = item["ProductName"].ToString(),
                            ProductPrice = item["ProductPrice"].ToString(),
                            DiscountPercent = item["DiscountPercent"].ToString(),
                            ProductFor = item["ProductFor"].ToString(),
                            //ProductName = item["ProductName"].ToString(),
                            //ProductName = item["ProductName"].ToString(),
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


        public List<ClothesCommon> GetList(string user, string id)
        {
            var list = new List<ClothesCommon>();
            try
            {
                var sql = "EXEC proc_tblClothes ";
                sql += " @FLAG = " + dao.FilterString((id != "0" ? "S" : "A"));
                sql += ",@User = " + dao.FilterString(user);
                sql += ",@RowId = " + dao.FilterString(id.ToString());

                var ds = dao.ExecuteDataset(sql);

                if (null != ds.Tables[0])
                {
                    int sn = 1;
                    foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                    {
                        var common = new ClothesCommon()
                        {
                            UniqueId = Convert.ToInt32(item["RowId"]),
                            ProductReferenceId = item["ProductReferenceId"].ToString(),
                            ProductDestintId = item["ProductDestintId"].ToString(),
                            Brand = item["Brand"].ToString(),
                            ProductName = item["ProductName"].ToString(),
                            CreatedDate = item["CreatedDate"].ToString(),
                            ProductDescription = item["ProductDescription"].ToString(),
                            ProductFor = item["ProductFor"].ToString(),
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
                            //CreatedDate = item["CreatedDate"].ToString(),
                            //CreatedDate = item["CreatedDate"].ToString(),
                            

                        };

                        var ProductSizeList = new List<ProductSizeCommon>();
                        if (ds.Tables.Count > 1)
                        {
                            if (null != ds.Tables[1])
                            {
                                foreach (System.Data.DataRow item1 in ds.Tables[1].Rows)
                                {
                                    var ProductSizes = new ProductSizeCommon()
                                    {

                                        ProductReferenceId = item1["ProductReferenceId"].ToString(),
                                        ProductId = item1["ProductId"].ToString(),
                                        ScaleType = item1["ScaleType"].ToString(),
                                        Size = item1["Size"].ToString(),
                                        BrandSize = item1["BrandSize"].ToString(),
                                        SizeDescription = item1["SizeDescription"].ToString(),
                                       
                                        

                                    };
                                    ProductSizeList.Add(ProductSizes);
                                }
                            }
                        }
                        common.ProductSizes = ProductSizeList;

                        var QBySizeAndColorList = new List<QuantityBySizeAndColorCommon>();
                        if (ds.Tables.Count > 2)
                        {
                            if (null != ds.Tables[2])
                            {
                                foreach (System.Data.DataRow item1 in ds.Tables[2].Rows)
                                {
                                    var QBySizeAndColor = new QuantityBySizeAndColorCommon()
                                    {
                                        QBySizeAndColorId = item1["QBySizeAndColorId"].ToString(),
                                        ProductReferenceId = item1["ProductReferenceId"].ToString(),
                                        ProductDestintId = item1["ProductDestintId"].ToString(),
                                        ColorId = item1["ColorId"].ToString(),
                                        SizeId = item1["SizeId"].ToString(),
                                        Quantity = item1["Quantity"].ToString(),
                                       
                                    };
                                    QBySizeAndColorList.Add(QBySizeAndColor);
                                }
                            }
                        }
                        common.QBySizeAndColor = QBySizeAndColorList;

                        var DocList = new List<DocumentUpload>();
                        if (ds.Tables.Count > 3)
                        {
                            if(null != ds.Tables[3])
                            {
                                foreach(System.Data.DataRow item2 in ds.Tables[3].Rows)
                                {
                                    var Doc = new DocumentUpload()
                                    {
                                        View=item2["Viewof"].ToString(),
                                        Color=item2["Color"].ToString(),
                                        DocName = item2["DocName"].ToString(),


                                    };
                                    DocList.Add(Doc);
                                }
                            }
                        }
                        common.Doc = DocList;
                        //var ColorsList = new List<ColorsCommon>();
                        //if (ds.Tables.Count > 3)
                        //{
                        //    if (null != ds.Tables[3])
                        //    {
                        //        foreach (System.Data.DataRow item1 in ds.Tables[3].Rows)
                        //        {
                        //            var Colors = new ColorsCommon()
                        //            {

                        //                //ThirdPartyName = item1["ThirdPartyName"].ToString(),
                        //                //ThirdPartyAmount = item1["ThirdPartyAmount"].ToString()

                        //            };
                        //            ColorsList.Add(Colors);
                        //        }
                        //    }
                        //}
                        //common.Colors = ColorsList;

                        
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

        public DbResponse Manage(ClothesCommon model)
        {
            string strProductSize = null;
            string strProductQuantity = null;
            //string strEngineeringInstalmentPremiumList = null;
            var strProductSizeList = model.ProductSizes.Select(m => new
            {
                ScaleType = m.ScaleType == null ? "0" : m.ScaleType,
                Size = m.Size == null ? "0" : m.Size,
                BrandSize = m.BrandSize == null ? "0" : m.BrandSize,
                SizeDescription = m.SizeDescription==null? "0":m.SizeDescription

            }).ToList();
            strProductSize = this.dao.GetDataTableToString(dao.ToDataTable(strProductSizeList));

            if (model.QBySizeAndColor != null)
            {
                var QBySizeAndColorList = model.QBySizeAndColor.Select(m => new
                {
                    ColorId = m.ColorId == null ? "0" : m.ColorId,
                    SizeId = m.SizeId == null ? "0" : m.SizeId,
                    Quantity = m.Quantity == null ? "0" : m.Quantity,

                }).ToList();
                strProductQuantity = this.dao.GetDataTableToString(dao.ToDataTable(QBySizeAndColorList));
            }
            

            try
            {
                var sql = "EXEC proc_tblClothes ";
                sql += " @flag = " + dao.FilterString((model.UniqueId > 0 ? "U" : "I"));
                sql += ",@User = " + dao.FilterString(model.User);
                sql += ",@RowId = " + dao.FilterString(model.UniqueId.ToString());
                sql += ",@ProductReferenceId = " + dao.FilterString(model.ProductReferenceId == null ? "" : model.ProductReferenceId.ToString());
                sql += ",@ProductDestintId=" + dao.FilterString(model.ProductDestintId == null ? "" : model.ProductDestintId.ToString());
                sql += ",@Brand=" + dao.FilterString(model.Brand == null ? "" : model.Brand.ToString());
                sql += ",@ProductName=" + dao.FilterString(model.ProductName == null ? "" : model.ProductName.ToString());
                sql += ",@ProductFor=" + dao.FilterString(model.ProductFor == null ? "" : model.ProductFor.ToString());
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
                sql += ",@strProductSizeListInXML = " + dao.FilterString(strProductSize);
                sql += ",@strProductQuantityListInXML = " + dao.FilterString(strProductQuantity);

                


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
                sql+= "@flag= " + dao.FilterString("DocUpload");
                sql += ",@User = " + dao.FilterString(User);
                sql += ",@DocFor = " + dao.FilterString("Clothes");
                sql += ",@DocExt = " + dao.FilterString(docExt);
                sql += ",@DocName = " + dao.FilterString(docName);
                sql += ",@DocPath = " + dao.FilterString(fulldocname);
                sql += ",@ProductReferenceId = " + dao.FilterString(ProductReferenceId);
                sql += ",@ProductDistinctId = " + dao.FilterString(ProductDistinctId);
                sql += ",@Viewof = " + dao.FilterString(View);
                sql += ",@Color = " + dao.FilterString(Color);
                //sql += ",@User = " + dao.FilterString(ProductDistinctId);

                return dao.ParseDbResponse(sql);

            }
            catch(Exception ex)
            {
                return dao.ExceptionDbResponse(ex.Message);

            }
            //return dao.RecordDocument(User, docExt, docName, fulldocname, ProductReferenceId, ProductDistinctId, View, Color);
        }

        public List<ProductSearchCommon> ShowClothes()
        {
            var list = new List<ProductSearchCommon>();
            var clotheslist =new  List<ClothesCommon>();
            var sql = "Exec proc_tblClothes";
            sql += " @Flag = " + dao.FilterString("ShowClothes");
            var dt = dao.ExecuteDataTable(sql);
            if(null != dt)
            {
                foreach(System.Data.DataRow item in dt.Rows)
                {
                    var table = item["TableName"].ToString();
                    if (table == "tblClothes")
                    {
                        var clothes = new ClothesCommon()
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
                        clotheslist.Add(clothes);
                    }
                }
            }
            if (null != dt)
            {
                var productSearch = new ProductSearchCommon()
                {
                    ClothesList = clotheslist
                    
                };
                list.Add(productSearch);
            }
            return list;


        }

        public List<ClothesCommon> GetClothes()
        {
           // var list = new List<ProductSearchCommon>();
            var clotheslist = new List<ClothesCommon>();
            var sql = "Exec proc_tblClothes";
            sql += " @Flag = " + dao.FilterString("ShowClothes");
            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var table = item["TableName"].ToString();
                    if (table == "tblClothes")
                    {
                        var clothes = new ClothesCommon()
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
                        clotheslist.Add(clothes);
                    }
                }
            }
           
            return clotheslist;


        }
        public List<ClothesCommon> GetTopClothes()
        {
           
            var clotheslist = new List<ClothesCommon>();
            var sql = "Exec proc_tblClothes";
            sql += " @Flag = " + dao.FilterString("ShowClothes");
            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var table = item["TableName"].ToString();
                    if (table == "tblClothes")
                    {
                        var clothes = new ClothesCommon()
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
                        clotheslist.Add(clothes);
                    }
                }
            }
           
            return clotheslist;


        }


    }
}
