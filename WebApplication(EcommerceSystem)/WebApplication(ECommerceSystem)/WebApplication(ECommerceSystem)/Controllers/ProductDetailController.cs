using Business.Business.Common;
using Business.Business.ProductDetail;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_ECommerceSystem_.Library;

namespace WebApplication_ECommerceSystem_.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        private const string ViewId = "";
        private const string AddEditId = "";
        private const string ControllerName = "ProductDetail";

        IProductDetailBuss buss;
        ICommonBuss ddl;

        public ProductDetailController(IProductDetailBuss _buss, ICommonBuss _ddl)
        {
            buss = _buss;
            ddl = _ddl;
        }

        //public ActionResult Index()
        //{
        //    var SearchData = Request["Search"];
        //    var list = buss.Search(SearchData.ToString());
        //    return View("SearchedResult", list[0]);
        //}

        //============================Product Search=====================================
        #region Search
            [HttpPost]
            public ActionResult Search(string search)
            {
                var SearchData = Request["Search"];               
                var list = buss.Search(SearchData.ToString());
                if (list == null && search==null)
                {
                    var action = Request.UrlReferrer.LocalPath; //provides the path of previous url
                    return Redirect(action);
                }
                else if (list.Count == 0 && search == "")
                {
                    var action = Request.UrlReferrer.LocalPath; //provides the path of previous url
                    return Redirect("/Home/Index");
                }
                else if(list.Count==0)
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
                        return View("SearchedResult", modal);

                }
                    return View("SearchedResult", list[0]);
            }


            public ActionResult GetSearchFilterOptionForComputer(string flag)
            {
                var listname = flag;
                var list = buss.GetSearchFilterForComputer(flag);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            public ActionResult GetSearchFilterOptionForClothes(string flag)
            {
                var listname = flag;
                var list = buss.GetSearchFilterForClothes(flag);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            public ActionResult GetSearchFilterOptionForGroceries(string flag)
            {
                var listname = flag;
                var list = buss.GetSearchFilterForGroceries(flag);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            public ActionResult GetSearchFilterOptionForGadget(string flag)
            {
                var listname = flag;
                var list = buss.GetSearchFilterForGadget(flag);
                return Json(list, JsonRequestBehavior.AllowGet);
            }

            [HttpPost]
            public ActionResult FilterClothes(string minPrice, string maxPrice, string[] Brand, string[] ProductName, string[] ProductSize, string[] ProductFor, string[] Color)
            {


                var list = buss.FilterClothes(minPrice, maxPrice, Brand, ProductName, ProductSize, ProductFor, Color);
                foreach (var item in list)
                {
                    item.Doc1 = WebApplication_ECommerceSystem_.Library.StaticData.GetDocumentPath() + item.Doc1;
                    item.Doc2 = WebApplication_ECommerceSystem_.Library.StaticData.GetDocumentPath() + item.Doc2;

                }

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            [HttpPost]
            public ActionResult FilterComputer(string minPrice, string maxPrice, string[] Brand, string[] Series, string[] ProcessorBrand, string[] ScreenSize, string[] OpeatingSystem, string[] GraphicProcessorCapacity, string[] HDDCapacity, string[] SuitableFor, string[] GraphicProcessorBrand, string[] TouchScreen, string[] RamType, string[] ProcessorGeneration, string[] RAM, string[] GraphicProcessorGen, string[] SSD, string[] SSDVersiom, string[] SSDCapacity)
            {


                var list = buss.FilterComputer(minPrice, maxPrice, Brand, Series, ProcessorBrand, ScreenSize, OpeatingSystem, GraphicProcessorCapacity, HDDCapacity, SuitableFor, GraphicProcessorBrand, TouchScreen, RamType, ProcessorGeneration, RAM, GraphicProcessorGen, SSD, SSDVersiom, SSDCapacity);
                foreach (var item in list)
                {
                    item.Doc1 = WebApplication_ECommerceSystem_.Library.StaticData.GetDocumentPath() + item.Doc1;
                    item.Doc2 = WebApplication_ECommerceSystem_.Library.StaticData.GetDocumentPath() + item.Doc2;

                }

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            [HttpPost]
            public ActionResult FilterGroceries(string minPrice, string maxPrice, string[] Brand, string[] ProductName, string[] QuantityPerVolume)
            {


                var list = buss.FilterGroceries(minPrice, maxPrice, Brand, ProductName, QuantityPerVolume);
                foreach (var item in list)
                {
                    item.Doc1 = WebApplication_ECommerceSystem_.Library.StaticData.GetDocumentPath() + item.Doc1;
                    item.Doc2 = WebApplication_ECommerceSystem_.Library.StaticData.GetDocumentPath() + item.Doc2;

                }

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            [HttpPost]
            public ActionResult FilterGadget(string minPrice, string maxPrice, string[] Brand, string[] ProductName, string[] BrowseType, string[] SimType, string[] TouchScreen, string[] Color, string[] InternalStorage, string[] OpeatingSystem, string[] ProcessorCore, string[] PrimaryCameraDetail, string[] FrontCameraDetail, string[] DisplaySize, string[] Resolution, string[] BatteryCapacity, string[] BatteryRemovable, string[] NetworkType, string[] InternetConnectivity)
            {
                var list = buss.FilterGadget(minPrice, maxPrice, Brand, ProductName, BrowseType, SimType, TouchScreen, Color, InternalStorage, OpeatingSystem, ProcessorCore, PrimaryCameraDetail, FrontCameraDetail, DisplaySize, Resolution, BatteryCapacity, BatteryRemovable, NetworkType, InternetConnectivity);
                foreach (var item in list)
                {
                    item.Doc1 = WebApplication_ECommerceSystem_.Library.StaticData.GetDocumentPath() + item.Doc1;
                    item.Doc2 = WebApplication_ECommerceSystem_.Library.StaticData.GetDocumentPath() + item.Doc2;

                }
                return Json(list, JsonRequestBehavior.AllowGet);
            }


        #endregion

        //=============================End Product Search================================

        //===========================Product Detail Visualizer ==============================
        [HttpGet]
        public ActionResult ClothesDetail( string ProductReferenceId)
        {
            //var ProductReferenceId = StaticData.GetIdFromQuery();
            var data = buss.GetClothesDetail(ProductReferenceId);
            if(data.Count == 0)
            {
                ClothesCommon model = new ClothesCommon();
                return View(model);
            }
            else
            {
                
                foreach(var item in data[0].Doc)
                {
                    item.DocName = StaticData.GetFilePath() + item.DocName;
                }
            }


            return View(data[0]);

        }


        [HttpGet]
        public ActionResult ComputerDetail(string ProductReferenceId)
        {
            //var ProductReferenceId = StaticData.GetIdFromQuery();
            var data = buss.GetComputerDetail(ProductReferenceId);
            if (data.Count == 0)
            {
                ClothesCommon model = new ClothesCommon();
                return View(model);
            }
            else
            {

                foreach (var item in data[0].Doc)
                {
                    item.DocName = StaticData.GetFilePath() + item.DocName;
                }
            }


            return View(data[0]);

        }

        [HttpGet]
        public ActionResult GroceriesDetail(string ProductReferenceId)
        {
            //var ProductReferenceId = StaticData.GetIdFromQuery();
            var data = buss.GetGroceriesDetail(ProductReferenceId);
            if (data.Count == 0)
            {
                ClothesCommon model = new ClothesCommon();
                return View(model);
            }
            else
            {

                foreach (var item in data[0].Doc)
                {
                    item.DocName = StaticData.GetFilePath() + item.DocName;
                }
            }


            return View(data[0]);

        }
        [HttpGet]
        public ActionResult GadgetDetail(string ProductReferenceId)
        {
            //var ProductReferenceId = StaticData.GetIdFromQuery();
            var data = buss.GetGadgetDetail(ProductReferenceId);
            if (data.Count == 0)
            {
                ClothesCommon model = new ClothesCommon();
                return View(model);
            }
            else
            {

                foreach (var item in data[0].Doc)
                {
                    item.DocName = StaticData.GetFilePath() + item.DocName;
                }
            }


            return View(data[0]);

        }



        //==========================product Detail Visualizer==================================
        public ActionResult ProductRating(string id)
        {
            var data = buss.ProductRating(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PushNewComment(string ProductReferenceId, string CommentTo, string NewComment)
        {
            var user = StaticData.GetUser();
            var response = buss.PushComment(ProductReferenceId, CommentTo, NewComment,user);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoadComment(string ProductReferenceId)
        {
            var comment = buss.LoadComment(ProductReferenceId);
            return Json(comment, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RateNow(string ProductReferenceId, string rating)
        {
            var user = StaticData.GetUser();
            var response = buss.RateNow(ProductReferenceId, rating, user);

            return Json(response, JsonRequestBehavior.AllowGet);
        }




    }
}