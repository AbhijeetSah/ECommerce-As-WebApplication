using Reposatory.Repository.ProductOrder;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.ProductOrder
{
    public class ProductOrderBuss : IProductOrderBuss
    {
        IProductOrderRepo repo;
        public ProductOrderBuss(ProductOrderRepo _repo)
        {
            repo = _repo;
        }
        public ProductOrderCommon ClothesData(string ProductReferenceId, string User)
        {
            return repo.ClothesData(ProductReferenceId, User);
        }
        public ProductOrderCommon ComputerData(string ProductReferenceId, string User)
        {
            return repo.ComputerData(ProductReferenceId, User);
        }
        public ProductOrderCommon GadgetData(string ProductReferenceId, string User)
        {
            return repo.GadgetData(ProductReferenceId, User);
        }
        public ProductOrderCommon GroceriesData(string ProductReferenceId, string User)
        {
            return repo.GroceriesData(ProductReferenceId, User);
        }



        public DbResponse Manage(ProductOrderCommon common)
        {
            return repo.Manage(common);
        }
        public DbResponse MakePayment(string OrderId, string TotalPrice, string User)
        {
            return repo.MakePayment(OrderId, TotalPrice, User);
        }

        
    }
}