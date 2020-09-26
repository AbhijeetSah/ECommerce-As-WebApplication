using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_ECommerceSystem_.Library;
using Business.Business.StaticData;
using Business.Business.Common;
using Shared.Common;
using Newtonsoft.Json;

namespace WebApplication_ECommerceSystem_.Controllers
{
    public class StaticDataController : Controller
    {
        

        IStaticDataBusiness buss;
        ICommonBuss ddl;
        private const string AddEditId = "";
        private const string ViewId = "";
        string ControllerName = "StaticData";

        public StaticDataController(IStaticDataBusiness _buss, ICommonBuss _ddl)
        {
            buss = _buss;
            ddl = _ddl;
        }

        public ActionResult Index()
        {
            ViewData["BreadCrumb"] = ApplicationGrid.GetAddBreadCum("Setup|System Setup|Static Data List", ControllerName , ViewId);
            return View();
        }
        [HttpPost]
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
                item.Action = StaticData.GetActions(ControllerName, item.UniqueId, item.TypeCode, AddEditId);
                //item.CreatedDate = StaticData.DBToFrontDate(item.CreatedDate);
            }
            HtmlGrid<StaticDataCommon> companyGrid = new HtmlGrid<StaticDataCommon>();
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


        public ActionResult Manage(string code, string id)
        {
            //StaticData.CheckFunctionId(AddEditId);
            id = StaticData.GetIdFromQuery();
            var data = buss.GetList(StaticData.GetUser(), id, "", 0);
            if (data.Count == 0)
            {
                StaticDataCommon model = new StaticDataCommon();
                model.BreadCum = ApplicationGrid.GetBreadCum("SetUp |Static Data |Manage ");
                return View(model);
            }
            data[0].BreadCum = ApplicationGrid.GetBreadCum("SetUp |Static Data |Manage");
            return View(data[0]);
        }
        //
        // POST: /Branch/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(StaticDataCommon model)
        {
            //StaticData.CheckFunctionId(AddEditId);
            if (ModelState.IsValid)
            {
                model.User = StaticData.GetUser();
                var response = buss.Manage(model);
                if (response.ErrorCode == 1)
                {
                    ModelState.AddModelError("", response.Message);
                    return View(model);
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public ActionResult Delete(int id = 0)
        {
            var response = buss.Delete(StaticData.GetUser(), id);
            if (response.ErrorCode == 1)
            {
                ModelState.AddModelError("", response.Message);
                return View("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult LoadAutocomplete(string type, string param)
        {
            var list = ddl.LoadAutocomplete(type, param);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDropdownForJQuery(string flag, string param)
        {
            var list = ddl.GetDropdownForJQuery(flag, param, StaticData.GetUser());
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDropdownForJQueryForColor(string flag, string param)
        {
            var list = ddl.GetDropdownForJQueryForColor(flag, param, StaticData.GetUser());
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}