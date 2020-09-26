using Business.Business.User;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using WebApplication_ECommerceSystem_.Library;

namespace WebApplication_ECommerceSystem_.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        //public UserController() { }
        IUserBuss buss;
        public UserController(IUserBuss _buss)
        {
            buss = _buss;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            UserCommon model = new UserCommon();
           //Uri url = Request.Url;
            var resp = new DbResponse();
            resp.ErrorCode = 1;
            resp.Message = "testing message in session";
            StaticData.SetMessageInSession(resp);
            return View(model);

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SignUp(UserCommon model) {
            if (model != null)
            {
                model.Password = EncryptionHelper.Encrypt(model.Password);
                model.VerificationFor = "NewAccount";
                model.VerificationSuccess = "0";
                
                string Letter = "abcdefghijklmnopqrstuvwxyz";
                char[] AlphaNumeric = (Letter + Letter.ToUpper() + "1234567890!@#$%^&*").ToCharArray();
                var code = "";
                Random ran = new Random();
                for(int i=0; i < 6; i++)
                {
                    code = code + AlphaNumeric[ran.Next(0, 71)].ToString();
                }
                
                var Subject = "Verification Code";
                var rootUrl = System.Configuration.ConfigurationManager.AppSettings["urlRoot"];
                var Body = "Your verification Code is<br/><button style=\"background-color:rebeccapurple; padding:10px; border-radius: 12px\"><a href='" + rootUrl + "/User/Verification?Email=" + model.Email + "&VerificationCode=" + code + "'  style=\"color:white;font-size:10px;\">Click Here to Verify Your Account</a></button>";
                var emailResponse = SendEmail(model.Email,Subject, Body);
                if (emailResponse == false)
                {
                    DbResponse resp = new DbResponse();
                    resp.ErrorCode = 1;
                    resp.Message = "You email no doesnot found";
                    StaticData.SetMessageInSession(resp);
                    return View(model);
                }
                model.VerificationCode = code;
                //Uri url = Request.Url;
                var response = buss.SignUp(model);
                if (response.ErrorCode != 0)
                {
                    DbResponse resp = new DbResponse();
                    resp.ErrorCode = response.ErrorCode;
                    resp.Message = response.Message;
                    StaticData.SetMessageInSession(resp);
                    return View(model);
                }
                else
                {
                    StaticData.SetMessageInSession(response);
                }               
               
            }
            

            return RedirectToAction("SignIn");
        }
        public bool SendEmail(string Email, string Subject, string Body)
        {
            try
            {
                var senderEmail = System.Configuration.ConfigurationManager.AppSettings["senderEmail"];
                var password = System.Configuration.ConfigurationManager.AppSettings["password"];
                SmtpClient client = new SmtpClient("smpt.gmail.com", 587);
                Email = Email.TrimEnd(' ').TrimStart(' ') ;
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

        public ActionResult Verification(string Email, string VerificationCode)
        {
            Email = Email.TrimEnd(' ').TrimStart(' ');
            var response = buss.Verify(Email,VerificationCode);
            if (response.ErrorCode == 1)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = response.ErrorCode;
                resp.Message = response.Message;
                StaticData.SetMessageInSession(resp);
            }
            return RedirectToAction("SignIn");
        }

        public ActionResult SignIn()
        {
            if (Session["Action"] == null)
            {
                if (Request.UrlReferrer.LocalPath != null)
                {
                    var action = Request.UrlReferrer.LocalPath; //provides the path of previous url
                    Session["Action"] = action;
                }
                
            }
            
            UserCommon model = new UserCommon();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(UserCommon model)
        {
           
            //Uri myUrl= Request.Url;           //to get working url
            //var action = myUrl.LocalPath;
            //RedirectToRoute(action);
            string ip = Request.ServerVariables["REMOTE_ADDR"];
            string browser = Request.Browser.Browser + " Version :" + Request.Browser.Version;

            var user = model.Email;
            var password = EncryptionHelper.Encrypt(model.Password);
            var response = buss.SignIn(user, password);
            if (response.UserId != null)
            {
                Session["AccountType"] = response.AccountType;
                Session["FirstName"] = response.FirstName;
                Session["MiddleName"] = response.MiddleName;
                Session["LastName"] = response.LastName;
                Session["UserId"] = response.UserId;
                Session["User"] = response.User;
                Session["Address"] = response.Address;
                Session["District"] = response.District;
                Session["State"] = response.State;
                Session["Country"] = response.Country;
                Session["MobileNo"] = response.MobileNo;
                Session["Email"] = response.Email;
                Session["BirthDate"] = response.BirthDate;
                Session["Gender"] = response.Gender;
                Session["ShopAddress"] = response.ShopAddress;
                Session["Language"] = response.Language;
                Session["StoreName"] = response.StoreName;
                Session["StoreAddress"] = response.StoreAddress;
                Session["StoreNo"] = response.StoreNo;
                Session["PANNO"] = response.PANNO;
                Session["ProductType"] = response.ProductType;
                Session["StoreContactNo"] = response.StoreContactNo;
                Session["Longitude"] = response.Longitude;
                Session["Latitude"] = response.Latitude;
                int check = this.HttpContext.Session.Timeout=40;
            }
            else
            {
                ViewData["msg"] = "The user name or password provided is incorrect.";
                //DbResponse resp = new DbResponse();
                //resp.ErrorCode = 1;
                //resp.Message = "Email Or Password Is Not valid";
                //StaticData.SetMessageInSession(resp);
                return View(model);


            }

            var action = Session["Action"].ToString();
            if(response.PANNO != "" && action=="/") {
                return RedirectToAction("SupplierDashboard");// View("SupplierDashboard");
            }
            if (action == "/ProductDetail/Search")
            {
                return RedirectToAction("Index", "Home");
            }
            return Redirect(action);
        }
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            UserCommon model = new UserCommon();
            return View(model);
        }
        [HttpPost]
        public ActionResult ForgotPassword(UserCommon model)
        {
            model.VerificationFor = "ForgotPassword";
            model.VerificationSuccess = "0";

            string Letter = "abcdefghijklmnopqrstuvwxyz";
            char[] AlphaNumeric = (Letter + Letter.ToUpper() + "1234567890!@#$%^&*").ToCharArray();
            var code = "";
            Random ran = new Random();
            for (int i = 0; i < 6; i++)
            {
                code = code + AlphaNumeric[ran.Next(0, 71)].ToString();
            }
            model.VerificationCode = code;
            var Subject = "Verification Code";
            var rootUrl = System.Configuration.ConfigurationManager.AppSettings["urlRoot"];
            var Body = "Your verification Code is<br/><button style=\"background-color:rebeccapurple; padding:10px; border-radius: 12px\"><a href='" + rootUrl + "/User/ForcePasswordChange?Email=" + model.Email + "&VerificationCode=" + code + "'  style=\"color:white;font-size:10px;\">Click Here to Verify Your Account</a></button>";
            var response = buss.ForgotPassword(model);
            if (response.ErrorCode == 1)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = response.ErrorCode;
                resp.Message = response.Message;
                StaticData.SetMessageInSession(resp);
                return View(model);
            }
            var emailResponse = SendEmail(model.Email, Subject, Body);
            if (emailResponse == false)
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = 1;
                resp.Message = "You email no doesnot found";
                StaticData.SetMessageInSession(resp);
                return View(model);
            }
            else
            {
                DbResponse resp = new DbResponse();
                resp.ErrorCode = 0;
                resp.Message = "You Verify Your Email";
                StaticData.SetMessageInSession(resp);
            }
            return RedirectToAction("SignIn");

        }

        public ActionResult LogOff()
        {
            //Uri myUrl = Request.Url;
            //var action = Request.UrlReferrer.LocalPath; //provides the path of previous url
            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();
            return RedirectToAction("SignIn"); //trying for reloading the same page

        }


        public ActionResult NotificationCount()
        {
            var user = StaticData.GetUser();

            if (user == "")
            {
                string dat = "0";
                return Json(dat, JsonRequestBehavior.AllowGet);
            }
            var data = buss.NotificationCount(user);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ShowAllNotification()
        {
           var user = StaticData.GetUser();
            if(user != "")
            {
                var list = buss.ShowNotification(user);
                return View(list);
            }
            var common = new List<NotificationCommon>();
            return View(common);

        }

        public ActionResult SupplierDashboard()
        {
            return View();
        }



    }
}