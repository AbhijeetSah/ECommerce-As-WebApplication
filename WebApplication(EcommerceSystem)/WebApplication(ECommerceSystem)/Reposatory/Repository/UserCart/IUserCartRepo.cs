using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatory.Repository.UserCart
{
    public interface IUserCartRepo
    {
        UserCartCommon ClothesData(string ProductReferenceId, string User);
        UserCartCommon ComputerData(string ProductReferenceId, string User);
        UserCartCommon GroceriesData(string ProductReferenceId, string User);
        UserCartCommon GadgetData(string ProductReferenceId, string User);
        string QuantityBySizeColor(string Color, string Size,string ProductreferenceId);
        string CartItemCount(string User);
        List<UserCartCommon> showAll(string User);
        DbResponse manage(UserCartCommon common);





    }
}
