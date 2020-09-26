using Business.Business.Common;
using Business.Business.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_ECommerceSystem_.Library;

namespace WebApplication_ECommerceSystem_.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        private const string ViewId = "";
        private const string AddEditId = "";
        private const string ControllerName = "Groceries";

        IUserProfileBuss buss;
        ICommonBuss ddl;
        public UserProfileController(IUserProfileBuss _buss, ICommonBuss _ddl)
        {
            buss = _buss;
            ddl = _ddl;
        }



        // GET: Groceries
        public ActionResult Index()
        {
            var user = StaticData.GetUser();
            //if (user == "")
            //{
            //    Uri action = Request.Url;
            //    Session["Action"] = action;
            //    return RedirectToAction("SignIn", "User");
            //}
            return View();
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}