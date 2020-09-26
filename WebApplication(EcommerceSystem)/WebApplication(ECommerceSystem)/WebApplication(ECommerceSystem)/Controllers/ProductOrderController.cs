using Business.Business.Common;
using Business.Business.ProductOrder;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication_ECommerceSystem_.Library;

namespace WebApplication_ECommerceSystem_.Controllers
{
    public class ProductOrderController : Controller
    {
        // GET: ProductOrder
        private const string ViewId = "";
        private const string AddEditId = "";
        private const string ControllerName = "ProductOrder";
        IProductOrderBuss buss;
        ICommonBuss ddl;

        public ProductOrderController(IProductOrderBuss _buss,  ICommonBuss _ddl)
        {
            buss = _buss;
            ddl = _ddl;
        }


        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Clothes(string ProductReferenceId = null)
        {
            var user = StaticData.GetUser();
            if (user == "")
            {
                Uri action = Request.Url;
                Session["Action"] = action;
                return RedirectToAction("SignIn", "User");
            }
            var data = buss.ClothesData(ProductReferenceId, user);
            ViewData["ColorList"] = StaticData.SetDDLValue(ddl.SetDropdown("ColorList", ProductReferenceId), "", "Select Color");
            ViewData["SizeList"] = StaticData.SetDDLValue(ddl.SetDropdown("AvailableSizeList", ProductReferenceId), "", "Select Size");
            data.DocName = StaticData.GetFilePath() + data.DocName;

            return View(data);
        }
        [HttpPost]
        public ActionResult Clothes(ProductOrderCommon Common)
        {
            Common.User = StaticData.GetUser();
            Common.ProductLink = "/ProductDetail/ClothesDetail?ProductReferenceId=" + Common.ProductReferenceId;
            var response = buss.Manage(Common);

            if (response.ErrorCode != 0)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = response.ErrorCode;
                resp.Message = response.Message;
                StaticData.SetMessageInSession(resp);
                return View(Common);
            }
            var mailBody = "Dear Sir,<br/> Your Order is successfully placed . Thanks for ordering " + Common.ProductName + ", " + Common.ProductQuantity + " item. You will be get shipped your product soon.<br/> Thank you!";
            var emailResponse=SendEmail(StaticData.GetUser(), "Order Placement", mailBody);

            if (emailResponse == false)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = 1;
                resp.Message = "You email no doesnot found";
                StaticData.SetMessageInSession(resp);
                
            }


            var rootUrl= System.Configuration.ConfigurationManager.AppSettings["urlRoot"];
            mailBody = "Dear Supplier,<br/> Our Customer Mr./Mrs. "+Common.CustomerFullName +" has place the order for "+rootUrl +Common.ProductLink+"." + Common.ProductName + ", " + Common.ProductQuantity+ "item , " + Common.ProductSize+", "+Common.ProductColor+ "  is requested to supply immediately to the"+StaticData.GetUser()+". <br/>Thank you!";
            emailResponse = SendEmail(Common.SupplierEmail, "Order Placement", mailBody);

            if (emailResponse == false)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = 1;
                resp.Message = "You email no doesnot found";
                StaticData.SetMessageInSession(resp);

            }
            var orderid = response.Id;

            return RedirectToAction("MakePayment" , new { OrderId=orderid, TotalPrice =Common.TotalPrice});

            //return RedirectToAction("Index", "Home");


        }

        [HttpGet]
        public ActionResult Computer(string ProductReferenceId = null)
        {
            var user = StaticData.GetUser();
            if (user == "")
            {
                Uri action = Request.Url;
                Session["Action"] = action;
                return RedirectToAction("SignIn", "User");
            }
            var data = buss.ComputerData(ProductReferenceId, user);
            //ViewData["ColorList"] = StaticData.SetDDLValue(ddl.SetDropdown("ColorList", ProductReferenceId), "", "Select Color");
            //ViewData["SizeList"] = StaticData.SetDDLValue(ddl.SetDropdown("AvailableSizeList", ProductReferenceId), "", "Select Size");
            data.DocName = StaticData.GetFilePath() + data.DocName;

            return View(data);
        }
        [HttpPost]
        public ActionResult Computer(ProductOrderCommon Common)
        {
            Common.User = StaticData.GetUser();
            Common.ProductLink = "/ProductDetail/ComputerDetail?ProductReferenceId=" + Common.ProductReferenceId;
            var response = buss.Manage(Common);

            if (response.ErrorCode != 0)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = response.ErrorCode;
                resp.Message = response.Message;
                StaticData.SetMessageInSession(resp);
                return View(Common);
            }
            var mailBody = "Dear Sir,<br/> Your Order is successfully placed . Thanks for ordering " + Common.ProductName + ", " + Common.ProductQuantity + " item. You will be get shipped your product soon.<br/> Thank you!";
            var emailResponse = SendEmail(StaticData.GetUser(), "Order Placement", mailBody);

            if (emailResponse == false)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = 1;
                resp.Message = "You email no doesnot found";
                StaticData.SetMessageInSession(resp);

            }


            var rootUrl = System.Configuration.ConfigurationManager.AppSettings["urlRoot"];
            mailBody = "Dear Supplier,<br/> Our Customer Mr./Mrs. " + Common.CustomerFullName + " has place the order for " + rootUrl + Common.ProductLink + "." + Common.ProductName + ", " + Common.ProductQuantity + "item , " + Common.ProductSize + ", " + Common.ProductColor + "  is requested to supply immediately to the" + StaticData.GetUser() + ". <br/>Thank you!";
            emailResponse = SendEmail(Common.SupplierEmail, "Order Placement", mailBody);

            if (emailResponse == false)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = 1;
                resp.Message = "You email no doesnot found";
                StaticData.SetMessageInSession(resp);

            }
            var orderid = response.Id;

            return RedirectToAction("MakePayment", new { OrderId = orderid, TotalPrice = Common.TotalPrice });

            //return RedirectToAction("Index", "Home");


        }

        [HttpGet]
        public ActionResult Gadget(string ProductReferenceId = null)
        {
            var user = StaticData.GetUser();
            if (user == "")
            {
                Uri action = Request.Url;
                Session["Action"] = action;
                return RedirectToAction("SignIn", "User");
            }
            var data = buss.GadgetData(ProductReferenceId, user);
            //ViewData["ColorList"] = StaticData.SetDDLValue(ddl.SetDropdown("ColorList", ProductReferenceId), "", "Select Color");
            //ViewData["SizeList"] = StaticData.SetDDLValue(ddl.SetDropdown("AvailableSizeList", ProductReferenceId), "", "Select Size");
            data.DocName = StaticData.GetFilePath() + data.DocName;

            return View(data);
        }
        [HttpPost]
        public ActionResult Gadget(ProductOrderCommon Common)
        {
            Common.User = StaticData.GetUser();
            Common.ProductLink = "/ProductDetail/GadgetDetail?ProductReferenceId=" + Common.ProductReferenceId;
            var response = buss.Manage(Common);

            if (response.ErrorCode != 0)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = response.ErrorCode;
                resp.Message = response.Message;
                StaticData.SetMessageInSession(resp);
                return View(Common);
            }
            var mailBody = "Dear Sir,<br/> Your Order is successfully placed . Thanks for ordering " + Common.ProductName + ", " + Common.ProductQuantity + " item. You will be get shipped your product soon.<br/> Thank you!";
            var emailResponse = SendEmail(StaticData.GetUser(), "Order Placement", mailBody);

            if (emailResponse == false)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = 1;
                resp.Message = "You email no doesnot found";
                StaticData.SetMessageInSession(resp);

            }


            var rootUrl = System.Configuration.ConfigurationManager.AppSettings["urlRoot"];
            mailBody = "Dear Supplier,<br/> Our Customer Mr./Mrs. " + Common.CustomerFullName + " has place the order for " + rootUrl + Common.ProductLink + "." + Common.ProductName + ", " + Common.ProductQuantity + "item , " + Common.ProductSize + ", " + Common.ProductColor + "  is requested to supply immediately to the" + StaticData.GetUser() + ". <br/>Thank you!";
            emailResponse = SendEmail(Common.SupplierEmail, "Order Placement", mailBody);

            if (emailResponse == false)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = 1;
                resp.Message = "You email no doesnot found";
                StaticData.SetMessageInSession(resp);

            }
            var orderid = response.Id;

            return RedirectToAction("MakePayment", new { OrderId = orderid, TotalPrice = Common.TotalPrice });

            //return RedirectToAction("Index", "Home");


        }
        [HttpGet]
        public ActionResult Groceries(string ProductReferenceId = null)
        {
            var user = StaticData.GetUser();
            if (user == "")
            {
                Uri action = Request.Url;
                Session["Action"] = action;
                return RedirectToAction("SignIn", "User");
            }
            var data = buss.GroceriesData(ProductReferenceId, user);
            //ViewData["ColorList"] = StaticData.SetDDLValue(ddl.SetDropdown("ColorList", ProductReferenceId), "", "Select Color");
            //ViewData["SizeList"] = StaticData.SetDDLValue(ddl.SetDropdown("AvailableSizeList", ProductReferenceId), "", "Select Size");
            data.DocName = StaticData.GetFilePath() + data.DocName;

            return View(data);
        }
        [HttpPost]
        public ActionResult Groceries(ProductOrderCommon Common)
        {
            Common.User = StaticData.GetUser();
            Common.ProductLink = "/ProductDetail/GroceriesDetail?ProductReferenceId=" + Common.ProductReferenceId;
            var response = buss.Manage(Common);

            if (response.ErrorCode != 0)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = response.ErrorCode;
                resp.Message = response.Message;
                StaticData.SetMessageInSession(resp);
                return View(Common);
            }
            var mailBody = "Dear Sir,<br/> Your Order is successfully placed . Thanks for ordering " + Common.ProductName + ", " + Common.ProductQuantity + " item. You will be get shipped your product soon.<br/> Thank you!";
            var emailResponse = SendEmail(StaticData.GetUser(), "Order Placement", mailBody);

            if (emailResponse == false)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = 1;
                resp.Message = "You email no doesnot found";
                StaticData.SetMessageInSession(resp);

            }


            var rootUrl = System.Configuration.ConfigurationManager.AppSettings["urlRoot"];
            mailBody = "Dear Supplier,<br/> Our Customer Mr./Mrs. " + Common.CustomerFullName + " has place the order for " + rootUrl + Common.ProductLink + "." + Common.ProductName + ", " + Common.ProductQuantity + "item , " + Common.ProductSize + ", " + Common.ProductColor + "  is requested to supply immediately to the" + StaticData.GetUser() + ". <br/>Thank you!";
            emailResponse = SendEmail(Common.SupplierEmail, "Order Placement", mailBody);

            if (emailResponse == false)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = 1;
                resp.Message = "You email no doesnot found";
                StaticData.SetMessageInSession(resp);

            }
            var orderid = response.Id;

            return RedirectToAction("MakePayment", new { OrderId = orderid, TotalPrice = Common.TotalPrice });

            //return RedirectToAction("Index", "Home");


        }

        public bool SendEmail(string Email, string Subject, string Body)
        {
            try
            {
                var senderEmail = System.Configuration.ConfigurationManager.AppSettings["senderEmail"];
                var password = System.Configuration.ConfigurationManager.AppSettings["password"];
                SmtpClient client = new SmtpClient("smpt.gmail.com", 587);
                Email = Email.TrimEnd(' ').TrimStart(' ');
                senderEmail = senderEmail.TrimEnd(' ').TrimStart(' ');
                client.EnableSsl = true;
                client.Timeout = 120000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, password);
                MailMessage mailMessage = new MailMessage(senderEmail, Email, Subject, Body);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public ActionResult MakePayment(string OrderId="0", string TotalPrice="0")
        {
            ViewData["OrderId"] = OrderId;
            ViewData["TotalPrice"] = TotalPrice;
            return View();
        }
        public ActionResult PayOnDelivery()
        {
            var OrderId = Request.Form["OrderId"];
            var TotalPrice = Request.Form["TotalPrice"];
            var User = StaticData.GetUser();
            var response = buss.MakePayment(OrderId,TotalPrice,User);
            DbResponse resp = new DbResponse();
            resp.ErrorCode = response.ErrorCode;
            resp.Message = response.Message;
            StaticData.SetMessageInSession(resp);
            return RedirectToAction("Index", "Home");
        }



    }
}