using Business.Business.Common;
using Business.Business.UserCart;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_ECommerceSystem_.Library;

namespace WebApplication_ECommerceSystem_.Controllers
{
    public class UserCartController : Controller
    {
        // GET: UserCart
        private const string ViewId = "";
        private const string AddEditId = "";
        private const string ControllerName = "UserCart";

        IUserCartBuss buss;
        ICommonBuss ddl;
        public UserCartController(IUserCartBuss _buss, ICommonBuss _ddl)
        {
            buss = _buss;
            ddl = _ddl;
        }


        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ClothesCart( string ProductReferenceId=null)
        {
            var user = StaticData.GetUser();
            if (user == "")
            {
                Uri action = Request.Url;
                Session["Action"] = action;
                return RedirectToAction("SignIn", "User");
            }
            var data = buss.ClothesData(ProductReferenceId,user);
            ViewData["ColorList"] = StaticData.SetDDLValue(ddl.SetDropdown("ColorList", ProductReferenceId), "", "Select Color");
            ViewData["SizeList"] = StaticData.SetDDLValue(ddl.SetDropdown("AvailableSizeList", ProductReferenceId), "", "Select Size");
            data.DocName = StaticData.GetFilePath() + data.DocName;

            return View(data);
        }
        [HttpPost]
        public ActionResult ClothesCart(UserCartCommon Common)
        {
            Common.User = StaticData.GetUser();
            Common.ProductLink = "/ProductDetail/ClothesDetail?ProductReferenceId=" + Common.ProductReferenceId;
            var response = buss.manage(Common);
            if (response.ErrorCode == 0)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = response.ErrorCode;
                resp.Message = response.Message;
                StaticData.SetMessageInSession(resp);
            }
            return RedirectToAction("Index", "Home");

           
        }


        [HttpGet]
        public ActionResult ComputerCart(string ProductReferenceId = null)
        {
            var user = StaticData.GetUser();
            if (user == "")
            {
                var action = Request.UrlReferrer.LocalPath;             //Uri action = Request.Url;
                Session["Action"] = action;
                return RedirectToAction("SignIn", "User");
            }
            var data = buss.ComputerData(ProductReferenceId, user);
            data.DocName = StaticData.GetFilePath() + data.DocName;

            return View(data);
        }
        [HttpPost]
        public ActionResult ComputerCart(UserCartCommon Common)
        {
            Common.User = StaticData.GetUser();
            Common.ProductLink = "/ProductDetail/ComputerDetail?ProductReferenceId=" + Common.ProductReferenceId;
            var response = buss.manage(Common);
            if (response.ErrorCode == 0)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = response.ErrorCode;
                resp.Message = response.Message;
                StaticData.SetMessageInSession(resp);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult GroceriesCart(string ProductReferenceId = null)
        {
            var user = StaticData.GetUser();
            if (user == "")
            {
                var action = Request.UrlReferrer.LocalPath;             //Uri action = Request.Url;
                Session["Action"] = action;
                return RedirectToAction("SignIn", "User");
            }
            var data = buss.GroceriesData(ProductReferenceId, user);
            data.DocName = StaticData.GetFilePath() + data.DocName;

            return View(data);
        }



        [HttpPost]
        public ActionResult GroceriesCart(UserCartCommon Common)
        {
            Common.User = StaticData.GetUser();
            Common.ProductLink = "/ProductDetail/GroceriesDetail?ProductReferenceId=" + Common.ProductReferenceId;
            var response = buss.manage(Common);
            if (response.ErrorCode == 0)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = response.ErrorCode;
                resp.Message = response.Message;
                StaticData.SetMessageInSession(resp);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult GadgetCart(string ProductReferenceId = null)
        {
            var user = StaticData.GetUser();
            if (user == "")
            {
                var action = Request.UrlReferrer.LocalPath;             //Uri action = Request.Url;
                Session["Action"] = action;
                return RedirectToAction("SignIn", "User");
            }
            var data = buss.GadgetData(ProductReferenceId, user);
            data.DocName = StaticData.GetFilePath() + data.DocName;

            return View(data);
        }

        [HttpPost]
        public ActionResult GadgetCart(UserCartCommon Common)
        {
            Common.User = StaticData.GetUser();
            Common.ProductLink = "/ProductDetail/GadgetDetail?ProductReferenceId=" + Common.ProductReferenceId;
            var response = buss.manage(Common);
            if (response.ErrorCode == 0)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = response.ErrorCode;
                resp.Message = response.Message;
                StaticData.SetMessageInSession(resp);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult QuantityBySizeColor(string Color, string Size, string ProductReferenceId)
        {
            var data = buss.QuantityBySizeColor(Color, Size, ProductReferenceId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult CartItemCount()
        {
            var user = StaticData.GetUser();

            if (user == "")
            {
                string dat = "0";
                return Json(dat, JsonRequestBehavior.AllowGet);
            }
            var data = buss.CartItemCount(user);
            return Json(data, JsonRequestBehavior.AllowGet);


        }
        public ActionResult ShowAll()
        {
            var user = StaticData.GetUser();
           
            if (user == "")
            {

                Uri action = Request.Url;
                Session["Action"] = action;
                return RedirectToAction("SignIn", "User");
            }
            var list = buss.showAll(user);
            return View(list);
        }

        



    }
}