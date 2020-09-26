using Business.Business.Common;
using Business.Business.Gadget;
using Newtonsoft.Json;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_ECommerceSystem_.Library;

namespace WebApplication_ECommerceSystem_.Controllers
{
    public class GadgetController : Controller
    {

        // GET: Gadget
        private const string ViewId = "";
        private const string AddEditId = "";
        private const string ControllerName = "Gadget";

        IGadgetBuss buss;
        ICommonBuss ddl;
        public GadgetController(IGadgetBuss _buss, ICommonBuss _ddl)
        {
            buss = _buss;
            ddl = _ddl;
        }

        public ActionResult Index()
        {
            var user = StaticData.GetUser();
            if (user == "")
            {
                Uri action = Request.Url;
                Session["Action"] = action;
                return RedirectToAction("SignIn", "User");
            }
            ViewData["BreadCrumb"] = ApplicationGrid.GetAddBreadCum("Gadget|Gadget Registration|Registered Gadget List", ControllerName, ViewId);
            return View();
        }
        public string GetGridDetails(GridDetails param)
        {
            var accountDetails = new GridParam
            {
                DisplayLength = param.length,
                DisplayStart = param.start,
                SortDir = param.order[0].dir,
                SortCol = param.order[0].column,
                Flag = "A",
                Search = param.search.value,
                UserName = StaticData.GetUser()
            };
            var gridList = buss.GetGridList(accountDetails);
            foreach (var item in gridList)
            {
                item.Action = StaticData.GetActions(ControllerName, item.UniqueId, "", AddEditId);
                //item.CreatedDate = StaticData.DBToFrontDate(item.CreatedDate);
            }
            HtmlGrid<GadgetCommon> companyGrid = new HtmlGrid<GadgetCommon>();
            var firstDefault = gridList.FirstOrDefault();
            companyGrid.aaData = gridList;
            if (firstDefault != null)
            {
                companyGrid.iTotalDisplayRecords = Convert.ToInt32(firstDefault.FilterCount);
                companyGrid.iTotalRecords = Convert.ToInt32(firstDefault.FilterCount);
            }

            var result = JsonConvert.SerializeObject(companyGrid).ToString();
            return result;
        }

        public ActionResult Manage()
        {
            var user = StaticData.GetUser();
            if (user == "")
            {
                Uri action = Request.Url;
                Session["Action"] = action;
                return RedirectToAction("SignIn", "User");
            }
            var id = StaticData.GetIdFromQuery();
            var data = buss.GetList(StaticData.GetUser(), id);
            if (data.Count == 0)
            {
                GadgetCommon model = new GadgetCommon();
                


                model.BreadCum = ApplicationGrid.GetBreadCum("Gadget |Gadget Regestration |Manage ");
                return View(model);
            }

            


            foreach (var item in data[0].Doc)
            {
                item.DocName = StaticData.GetDocumentPath() + (item.DocName);
            }
            data[0].BreadCum = ApplicationGrid.GetBreadCum("Gadget |Gadget Regestration |Manage ");
            return View(data[0]);
            //return View();

        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Manage(GadgetCommon model)
        {
            if (model != null)
            {
                model.User = StaticData.GetUser();

                var response = buss.Manage(model);
                var imgref = response.Id.Split(';');
                model.ProductReferenceId = imgref[0];
                model.ProductDestintId = imgref[1];

                StaticData.SetMessageInSession(response);
                if (response.ErrorCode == 1)
                {
                    ModelState.AddModelError("", response.Message);
                    model.BreadCum = ApplicationGrid.GetBreadCum("Gadget |Gadget Regestration |Manage ");
                   
                    return View(model);
                }
                else if (model.Doc != null)
                {
                    foreach (var item in model.Doc)
                    {
                        if (item.Img != null)
                        {
                            var uploaded = UploadDoc(model.ProductReferenceId, model.ProductDestintId, item.View, item.Color, item.Img, "");
                            if (uploaded.ErrorCode == 1)
                            {
                                StaticData.SetMessageInSession(0, "Data Saved but " + uploaded.Message);
                            }
                        }

                    }
                }



            }

            return RedirectToAction("Index");
        }


        public DbResponse UploadDoc(string ProductReferenceId, string ProductDistinctId, string View, string Color, HttpPostedFileBase file, string path, bool CheckContentType = true)    //public DbResponse UploadDoc(HttpPostedFileBase file, string path, string remarks, string valueId, string check, bool CheckContentType = true)
        {
            var response = new DbResponse();
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    if (CheckContentType)
                    {
                        var fileType = file.ContentType;
                        if (fileType == "image/jpeg" || fileType == "image/png" || fileType == "application/pdf" || fileType == "image/jpg" || fileType == "imae/gif" || fileType == "image/tiff" || fileType == "application/psd" || fileType == "application/ai" || fileType == "image/raw")
                        {
                            var docPath = StaticData.GetFilePath();

                            if (!Directory.Exists(docPath))
                                Directory.CreateDirectory(docPath);

                            if (!Directory.Exists(docPath + "\\" + path))
                                Directory.CreateDirectory(docPath + "\\" + path);

                            string docOrgName = file.FileName;
                            var docExt = Path.GetExtension(docOrgName);
                            docExt = docExt.ToLower();

                        docName:
                            var docName = DateTime.Now.Ticks + docExt;
                            var storeDocName = docName;
                            var fulldocname = @docPath + docName;
                            var docToCreate = fulldocname;

                            if (System.IO.File.Exists(docToCreate))
                                goto docName;

                            var resp = buss.RecordDocument(StaticData.GetUser(), docExt, docName, fulldocname, ProductReferenceId, ProductDistinctId, View, Color);

                            if (!string.IsNullOrEmpty(docName))
                            {
                                if (resp.ErrorCode == 0)
                                {
                                    string rootpath = Server.MapPath("~");
                                    file.SaveAs(Server.MapPath(docToCreate));
                                    response.ErrorCode = 0;
                                    response.Message = docName;
                                }
                            }
                        }
                    }
                    else
                    {
                        response.ErrorCode = 1;
                        response.Message = "Invalid file format";
                        return response;
                    }
                }
                catch (Exception e)
                {
                    response.ErrorCode = 1;
                    response.Message = e.Message;
                }
            }
            return response;
        }
        [HttpGet]
        public ActionResult ShowGadget()
        {
            //var list = new List<ProductSearchCommon>();

            var list = buss.ShowGadget();


            if (list.Count == 0)
            {
                var modal = new ProductSearchCommon();
                var clothesList = new List<ClothesCommon>();
                var GroceriesList = new List<GroceriesCommon>();
                var GadgetList = new List<GadgetCommon>();
                var Computerlist = new List<ComputerCommon>();

                modal.ClothesList = clothesList;
                modal.GroceriesList = GroceriesList;
                modal.ComputerList = Computerlist;
                modal.GadgetList = GadgetList;
                return View(modal);

            }
            return View(list[0]);
        }
        public ActionResult GetGadget()
        {
            var list = buss.GetGadget();
            foreach (var item in list)
            {
                item.Doc1 = StaticData.GetDocumentPath() + item.Doc1;
                item.Doc2 = StaticData.GetDocumentPath() + item.Doc2;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }






    }
}