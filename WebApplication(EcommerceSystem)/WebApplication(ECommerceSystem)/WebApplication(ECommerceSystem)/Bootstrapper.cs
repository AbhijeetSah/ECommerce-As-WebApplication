using Microsoft.Practices.Unity;
using Unity.Mvc4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Business.User;
using Business.Business.Clothes;
using Business.Business.StaticData;
using Business.Business.Common;
using Business.Business.Groceries;
using Business.Business.Gadget;
using Business.Business.Computer;
using Business.Business.UserProfile;
using Business.Business.ProductDetail;
using Business.Business.UserCart;
using Business.Business.ProductOrder;

namespace WebApplication_ECommerceSystem_
{
    public class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            //throw new NotImplementedException();
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container= new UnityContainer();
            container.RegisterType<IUserBuss, UserBuss>();
            container.RegisterType<ICommonBuss, CommonBuss>();
            container.RegisterType<IClothesBuss, ClothesBuss>();
            container.RegisterType<IStaticDataBusiness, StaticDataBusiness>();
            container.RegisterType<IGroceriesBuss, GroceriesBuss>();
            container.RegisterType<IGadgetBuss, GadgetBuss>();
            container.RegisterType<IComputerBuss, ComputerBuss>();
            container.RegisterType<IUserProfileBuss, UserProfileBuss>();
            container.RegisterType<IProductDetailBuss,ProductDetailBuss>();
            container.RegisterType<IUserCartBuss, UserCartBuss>();
            container.RegisterType<IProductOrderBuss, ProductOrderBuss>();
            return container;
            //throw new NotImplementedException();
        }
    }

    
}