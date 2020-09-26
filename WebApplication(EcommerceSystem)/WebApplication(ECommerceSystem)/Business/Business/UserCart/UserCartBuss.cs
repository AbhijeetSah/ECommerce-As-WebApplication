using Reposatory.Repository.UserCart;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.UserCart
{
    public class UserCartBuss : IUserCartBuss
    {
        IUserCartRepo repo;
        public UserCartBuss(UserCartRepo _repo)
        {
            repo = _repo;
        }
        public UserCartCommon ClothesData(string ProductReferenceId, string User)
        {
            return repo.ClothesData(ProductReferenceId,User);
        }
        public UserCartCommon ComputerData(string ProductReferenceId, string User)
        {
            return repo.ComputerData(ProductReferenceId,User);
        }
        public UserCartCommon GadgetData(string ProductReferenceId, string User)
        {
            return repo.GadgetData(ProductReferenceId,User);
        }
        public UserCartCommon GroceriesData(string ProductReferenceId, string User)
        {
            return repo.GroceriesData(ProductReferenceId,User);
        }
        public string QuantityBySizeColor(string Color, string Size, string ProductReferenceId)
        {
            return repo.QuantityBySizeColor(Color, Size, ProductReferenceId);
        }
        public string CartItemCount(string User)
        {
            return repo.CartItemCount(User);
        }
        public List<UserCartCommon> showAll(string User)
        {
            return repo.showAll(User);
        }
        public DbResponse manage(UserCartCommon common)
        {
            return repo.manage(common);
        }


    }
}
