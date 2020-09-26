using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatory.Repository.ProductOrder
{
    public class ProductOrderRepo : IProductOrderRepo
    {

        RepositoryDao dao;
        public ProductOrderRepo()
        {
            dao = new RepositoryDao();
        }

        public ProductOrderCommon ClothesData(string ProductReferenceId, string User)
        {
            var data = new ProductOrderCommon();
            var sql = "Exec proc_PlaceOrder ";
            sql += " @flag= " + dao.FilterString("ClothesInfo");
            sql += " ,@ProductReferenceId =" + dao.FilterString(ProductReferenceId);
            sql += " ,@User =" + dao.FilterString(User);

            var ds = dao.ExecuteDataset(sql);
            if (ds.Tables[0] != null)
            {
                foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                {
                    data.ProductReferenceId = item["ProductReferenceId"].ToString();
                    data.ProductDistinctId = item["ProductDistinctId"].ToString();                    
                                       
                    data.ProductName = item["ProductName"].ToString();
                    data.ProductPrice = item["ProductPrice"].ToString();
                    
                    data.SupplierEmail = item["SupplierEmail"].ToString();
                    data.SupplierName = item["SupplierName"].ToString();
                    data.SupplierContactNo = item["SupplierContactNo"].ToString();
                    data.SupplierAddress = item["SupplierAddress"].ToString();
                    data.SupplierLatitude = item["SupplierLatitude"].ToString();
                    data.SupplierLongitude = item["SupplierLongitude"].ToString();
                    data.DocName = item["DocName"].ToString();

                }
            }

            return data;

        }

        public ProductOrderCommon ComputerData(string ProductReferenceId, string User)
        {
            var data = new ProductOrderCommon();
            var sql = "Exec proc_PlaceOrder ";
            sql += " @flag= " + dao.FilterString("ComputerInfo");
            sql += " ,@ProductReferenceId =" + dao.FilterString(ProductReferenceId);
            sql += " ,@User =" + dao.FilterString(User);

            var ds = dao.ExecuteDataset(sql);
            if (ds.Tables[0] != null)
            {
                foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                {
                    data.ProductReferenceId = item["ProductReferenceId"].ToString();
                    data.ProductDistinctId = item["ProductDistinctId"].ToString();
                    data.ProductQuantity = item["ProductQuantity"].ToString();
                    data.ProductName = item["ProductName"].ToString();
                    data.ProductPrice = item["ProductPrice"].ToString();
                    
                    data.SupplierEmail = item["SupplierEmail"].ToString();
                    data.SupplierName = item["SupplierName"].ToString();
                    data.SupplierContactNo = item["SupplierContactNo"].ToString();
                    data.SupplierAddress = item["SupplierAddress"].ToString();
                    data.SupplierLatitude = item["SupplierLatitude"].ToString();
                    data.SupplierLongitude = item["SupplierLongitude"].ToString();
                    data.DocName = item["DocName"].ToString();

                }
            }

            return data;

        }

        public ProductOrderCommon GadgetData(string ProductReferenceId, string User)
        {
            var data = new ProductOrderCommon();
            var sql = "Exec proc_PlaceOrder ";
            sql += " @flag= " + dao.FilterString("GadgetInfo");
            sql += " ,@ProductReferenceId =" + dao.FilterString(ProductReferenceId);
            sql += " ,@User =" + dao.FilterString(User);

            var ds = dao.ExecuteDataset(sql);
            if (ds.Tables[0] != null)
            {
                foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                {
                    data.ProductReferenceId = item["ProductReferenceId"].ToString();
                    data.ProductDistinctId = item["ProductDistinctId"].ToString();
                    data.ProductQuantity = item["ProductQuantity"].ToString();
                    data.ProductName = item["ProductName"].ToString();
                    data.ProductPrice = item["ProductPrice"].ToString();

                    data.SupplierEmail = item["SupplierEmail"].ToString();
                    data.SupplierName = item["SupplierName"].ToString();
                    data.SupplierContactNo = item["SupplierContactNo"].ToString();
                    data.SupplierAddress = item["SupplierAddress"].ToString();
                    data.SupplierLatitude = item["SupplierLatitude"].ToString();
                    data.SupplierLongitude = item["SupplierLongitude"].ToString();
                    data.DocName = item["DocName"].ToString();

                }
            }

            return data;

        }
        public ProductOrderCommon GroceriesData(string ProductReferenceId, string User)
        {
            var data = new ProductOrderCommon();
            var sql = "Exec proc_PlaceOrder ";
            sql += " @flag= " + dao.FilterString("GroceriesInfo");
            sql += " ,@ProductReferenceId =" + dao.FilterString(ProductReferenceId);
            sql += " ,@User =" + dao.FilterString(User);

            var ds = dao.ExecuteDataset(sql);
            if (ds.Tables[0] != null)
            {
                foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                {
                    data.ProductReferenceId = item["ProductReferenceId"].ToString();
                    data.ProductDistinctId = item["ProductDistinctId"].ToString();
                    
                    data.ProductName = item["ProductName"].ToString();
                    data.ProductPrice = item["ProductPrice"].ToString();
                    data.ProductQuantity = item["ProductQuantity"].ToString();
                    data.SupplierEmail = item["SupplierEmail"].ToString();
                    data.SupplierName = item["SupplierName"].ToString();
                    data.SupplierContactNo = item["SupplierContactNo"].ToString();
                    data.SupplierAddress = item["SupplierAddress"].ToString();
                    data.SupplierLatitude = item["SupplierLatitude"].ToString();
                    data.SupplierLongitude = item["SupplierLongitude"].ToString();
                    data.DocName = item["DocName"].ToString();

                }
            }

            return data;

        }



        public DbResponse Manage(ProductOrderCommon common)
        {
            var sql = "Exec proc_PlaceOrder   @flag= 'I' ";
            sql += ", @ProductReferenceId=" + dao.FilterString(common.ProductReferenceId == null ? "" : common.ProductReferenceId);
            sql += ", @ProductDistinctId=" + dao.FilterString(common.ProductDistinctId == null ? "" : common.ProductDistinctId);
            //sql += ", @CartId=" + dao.FilterString(common.CartId == null ? "" : common.CartId);
            sql += ", @ProductName=" + dao.FilterString(common.ProductName == null ? "" : common.ProductName);
            //sql += ", @ProductStatus=" + dao.FilterString(common.ProductStatus == null ? "" : common.ProductStatus);
            sql += ", @ProductQuantity=" + dao.FilterString(common.ProductQuantity == null ? "" : common.ProductQuantity);
            sql += ", @ProductSize=" + dao.FilterString(common.ProductSize == null ? "" : common.ProductSize);
            sql += ", @ProductColor=" + dao.FilterString(common.ProductColor == null ? "" : common.ProductColor);
            sql += ", @ProductPrice=" + dao.FilterString(common.ProductPrice == null ? "" : common.ProductPrice);
            //sql += ", @ProductCartStatus=" + dao.FilterString(common.ProductCartStatus == null ? "" : common.ProductCartStatus);
            
            sql += ", @ProductLink=" + dao.FilterString(common.ProductLink == null ? "" : common.ProductLink);
            sql += ", @CustomerContactNo=" + dao.FilterString(common.CustomerContactNo == null ? "" : common.CustomerContactNo);
            sql += ", @CustomerFullName=" + dao.FilterString(common.CustomerFullName == null ? "" : common.CustomerFullName);
            sql += ", @DeliveryAddress=" + dao.FilterString(common.DeliveryAddress == null ? "" : common.DeliveryAddress);
            sql += ", @DeliveryLatitude=" + dao.FilterString(common.DeliveryLatitude == null ? "" : common.DeliveryLatitude);
            sql += ", @DeliveryLongitude=" + dao.FilterString(common.DeliveryLongitude == null ? "" : common.DeliveryLongitude);
            sql += ", @SupplierName=" + dao.FilterString(common.SupplierName == null ? "" : common.SupplierName);
            sql += ", @SupplierAddress=" + dao.FilterString(common.SupplierAddress == null ? "" : common.SupplierAddress);
            sql += ", @SupplierContactNo=" + dao.FilterString(common.SupplierContactNo == null ? "" : common.SupplierContactNo);
            sql += ", @SupplierLatitude=" + dao.FilterString(common.SupplierLatitude == null ? "" : common.SupplierLatitude);
            sql += ", @SupplierLongitude=" + dao.FilterString(common.SupplierLongitude == null ? "" : common.SupplierLongitude);
            sql += ", @SupplierEmail=" + dao.FilterString(common.SupplierEmail == null ? "" : common.SupplierEmail);

            sql += ", @ShippingDistance=" + dao.FilterString(common.ShippingDistance == null ? "" : common.ShippingDistance);
            sql += ", @ShippingCharge=" + dao.FilterString(common.ShippingCharge == null ? "" : common.ShippingCharge);
            sql += ", @TotalPrice=" + dao.FilterString(common.TotalPrice == null ? "" : common.TotalPrice);
            sql += ", @User=" + dao.FilterString(common.User == null ? "" : common.User);



            var response = dao.ParseDbResponse(sql);

            return response;
        }

        public DbResponse MakePayment(string OrderId, string TotalPrice, string User)
        {
            var sql= "Exec proc_PlaceOrder   @flag= 'PayOnDelivery' ";
            sql += ", @OrderId= " + dao.FilterString(OrderId);
            sql += ", @TotalPrice= " + dao.FilterString(TotalPrice);
            sql += ", @User= " + dao.FilterString(User);
            var response = dao.ParseDbResponse(sql);
            return response;




        }



    }
}
