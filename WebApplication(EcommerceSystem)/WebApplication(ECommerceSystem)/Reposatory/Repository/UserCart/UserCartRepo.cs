using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatory.Repository.UserCart
{
    public class UserCartRepo : IUserCartRepo
    {
        RepositoryDao dao;
        public UserCartRepo()
        {
            dao = new RepositoryDao();
        }
        public UserCartCommon ClothesData(string ProductReferenceId,string User)
        {
            var data = new UserCartCommon();
            var sql = "Exec Proc_UserCart ";
            sql += " @flag= " + dao.FilterString("ClothesInfo");
            sql += " ,@ProductReferenceId =" + dao.FilterString(ProductReferenceId);
            sql += " ,@User =" + dao.FilterString(User);

            var ds = dao.ExecuteDataset(sql);
            if (ds.Tables[0] != null)
            {
                 foreach(System.Data.DataRow item in ds.Tables[0].Rows)
                {
                    data.CartId = item["CartId"].ToString();
                    data.ProductReferenceId = item["ProductReferenceId"].ToString();
                    data.ProductDistinctId = item["ProductDistinctId"].ToString();
                    data.CreatedBy = item["CreatedBy"].ToString();
                    //data.DocName = item["DocName"].ToString();
                    //data.ProductColor = item["ProductColor"].ToString();
                    data.ProductName = item["ProductName"].ToString();
                    data.ProductPrice = item["ProductPrice"].ToString();
                    //data.ProductQuantity = item["ProductQuantity"].ToString();
                    //data.ProductSize = item["ProductSize"].ToString();
                    data.ProductStatus = item["ProductStatus"].ToString();
                    data.DocName = item["DocName"].ToString();
                    
                }
            }

            return data;

        }
        public UserCartCommon ComputerData(string ProductReferenceId, string User)
        {
            var data = new UserCartCommon();
            
            var sql = "Exec Proc_UserCart ";
            sql += " @flag= " + dao.FilterString("ComputerInfo");
            sql += " ,@ProductReferenceId =" + dao.FilterString(ProductReferenceId);
            sql += " ,@User =" + dao.FilterString(User);

            var ds = dao.ExecuteDataset(sql);
            if (ds.Tables[0] != null)
            {
                foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                {
                    data.CartId = item["CartId"].ToString();
                    data.ProductReferenceId = item["ProductReferenceId"].ToString();
                    data.ProductDistinctId = item["ProductDistinctId"].ToString();
                    data.CreatedBy = item["CreatedBy"].ToString();
                   // data.DocName = item["DocName"].ToString();
                    //data.ProductColor = item["ProductColor"].ToString();
                    data.ProductName = item["ProductName"].ToString();
                    data.ProductPrice = item["ProductPrice"].ToString();
                    data.ProductQuantity = item["ProductQuantity"].ToString();
                    //data.ProductSize = item["ProductSize"].ToString();
                    data.ProductStatus = item["ProductStatus"].ToString();
                    data.DocName = item["DocName"].ToString();
                }
            }

            return data;
        }
        public UserCartCommon GroceriesData(string ProductReferenceId, string User)
        {
            var data = new UserCartCommon();
            var sql = "Exec Proc_UserCart ";
            sql += " @flag= " + dao.FilterString("GroceriesInfo");
            sql += " ,@ProductReferenceId =" + dao.FilterString(ProductReferenceId);
            sql += " ,@User =" + dao.FilterString(User);

            var ds = dao.ExecuteDataset(sql);
            if (ds.Tables[0] != null)
            {
                foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                {
                    data.CartId = item["CartId"].ToString();
                    data.ProductReferenceId = item["ProductReferenceId"].ToString();
                    data.ProductDistinctId = item["ProductDistinctId"].ToString();
                    data.CreatedBy = item["CreatedBy"].ToString();
                    //data.DocName = item["DocName"].ToString();
                    //data.ProductColor = item["ProductColor"].ToString();
                    data.ProductName = item["ProductName"].ToString();
                    data.ProductPrice = item["ProductPrice"].ToString();
                    data.ProductQuantity = item["ProductQuantity"].ToString();
                    //data.ProductSize = item["ProductSize"].ToString();
                    data.ProductStatus = item["ProductStatus"].ToString();
                    data.DocName = item["DocName"].ToString();

                }
            }

            return data;
        }
        public UserCartCommon GadgetData(string ProductReferenceId,string User)
        {
            var data = new UserCartCommon();
            var sql = "Exec Proc_UserCart ";
            sql += " @flag= " + dao.FilterString("GadgetInfo");
            sql += " ,@ProductReferenceId =" + dao.FilterString(ProductReferenceId);
            sql += " ,@User =" + dao.FilterString(User);

            var ds = dao.ExecuteDataset(sql);
            if (ds.Tables[0] != null)
            {
                foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                {
                    data.CartId = item["CartId"].ToString();
                    data.ProductReferenceId = item["ProductReferenceId"].ToString();
                    data.ProductDistinctId = item["ProductDistinctId"].ToString();
                    data.CreatedBy = item["CreatedBy"].ToString();
                    //data.DocName = item["DocName"].ToString();
                    //data.ProductColor = item["ProductColor"].ToString();
                    data.ProductName = item["ProductName"].ToString();
                    data.ProductPrice = item["ProductPrice"].ToString();
                    data.ProductQuantity = item["ProductQuantity"].ToString();
                    //data.ProductSize = item["ProductSize"].ToString();
                    data.ProductStatus = item["ProductStatus"].ToString();
                    data.DocName = item["DocName"].ToString();

                }
            }

            return data;
        }
        public string QuantityBySizeColor(string Color, string Size , string ProductReferenceId)
        {
            var sql = "Exec Proc_UserCart ";
            sql += " @flag= " + dao.FilterString("ClothesQuantityInfo");
            sql += " ,@ProductColor =" + dao.FilterString(Color);
            sql += " ,@ProductSize =" + dao.FilterString(Size);
            sql += ", @ProductReferenceId=" + dao.FilterString(ProductReferenceId);
            var dr = dao.ExecuteDataRow(sql);
            string QuantityBySizeColor = dr.Table.Rows[0]["Quantity"].ToString();  //dr.Rows[0].
            return QuantityBySizeColor;
        }

        public string CartItemCount(string User)
        {
            var sql = "Exec Proc_UserCart ";
            sql += " @flag= " + dao.FilterString("CartItemCount");
            sql += " ,@User =" + dao.FilterString(User);
            
            var dr = dao.ExecuteDataRow(sql);
            string CartCountItem = dr.Table.Rows[0]["CartCountItem"].ToString();  //dr.Rows[0].
            return CartCountItem;
        }
        public List<UserCartCommon> showAll(string User)
        {
            var list = new List<UserCartCommon>();
            var sql = "Exec Proc_UserCart ";
            sql += " @flag= " + dao.FilterString("showAll");
            sql += " ,@User =" + dao.FilterString(User);
            var dt = dao.ExecuteDataTable(sql);

            if (null != dt)
            {
                int sn = 1;
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var common = new UserCartCommon()
                    {
                        RowId = Convert.ToInt32(item["RowId"]),
                        ProductReferenceId=item["ProductReferenceId"].ToString(),
                        ProductDistinctId=item["ProductDistinctId"].ToString(),
                        ProductName=item["ProductName"].ToString(),
                        ProductStatus=item["ProductStatus"].ToString(),
                        ProductQuantity=item["ProductQuantity"].ToString(),
                        ProductSize=item["ProductSize"].ToString(),
                        ProductColor=item["ProductColor"].ToString(),
                        ProductPrice=item["ProductPrice"].ToString(),
                        ProductCartStatus=item["ProductCartStatus"].ToString(),
                        ProductLink=item["ProductLink"].ToString(),
                       
                        CreatedBy = item["CreatedBy"].ToString(),
                        CreatedDate = item["CreatedDate"].ToString()

                    };
                    sn++;
                    list.Add(common);
                }
            }
            return list;

        }

        public DbResponse manage(UserCartCommon common)
        {
            var sql = "Exec Proc_UserCart   @flag= 'I' ";
            sql += ", @ProductReferenceId=" + dao.FilterString(common.ProductReferenceId == null ? "" : common.ProductReferenceId);
            sql += ", @ProductDistinctId=" + dao.FilterString(common.ProductDistinctId == null ? "" : common.ProductDistinctId);
            sql += ", @CartId=" + dao.FilterString(common.CartId == null ? "" : common.CartId);
            sql += ", @ProductName=" + dao.FilterString(common.ProductName == null ? "" : common.ProductName);
            sql += ", @ProductStatus=" + dao.FilterString(common.ProductStatus == null ? "" : common.ProductStatus);
            sql += ", @ProductQuantity=" + dao.FilterString(common.ProductQuantity == null ? "" : common.ProductQuantity);
            sql += ", @ProductSize=" + dao.FilterString(common.ProductSize == null ? "" : common.ProductSize);
            sql += ", @ProductColor=" + dao.FilterString(common.ProductColor == null ? "" : common.ProductColor);
            sql += ", @ProductPrice=" + dao.FilterString(common.ProductPrice == null ? "" : common.ProductPrice);
            sql += ", @ProductCartStatus=" + dao.FilterString(common.ProductCartStatus == null ? "" : common.ProductCartStatus);
            sql += ", @ProductLink=" + dao.FilterString(common.ProductLink == null ? "" : common.ProductLink);
            sql += ", @User=" + dao.FilterString(common.User == null ? "" : common.User);
            
            var response = dao.ParseDbResponse(sql);

            return response;
        }





    }
}
