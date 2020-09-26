using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WebApplication_ECommerceSystem_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //reading session data
            //var x = Session["UserId"];
            if(WebApplication_ECommerceSystem_.Library.StaticData.GetUser() !="" && Session["PANNO"] != "")
            {
                return RedirectToAction("SupplierDashboard", "User");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MyChartProduct()
        {
            double Jan = 10.00;
            double Feb = 5.00;
            double Mar = 6.00;
            double Apr = 7.00;
            double May = 3.00;
            double Jun = 2.00;
            double Jul = 9.00;
            double Aug = 3.00;
            double Sep = 4.00;
            double Oct = 5.00;
            double Nov = 6.00;
            double Dec = 7.00;
            new Chart(width: 600, height: 300, theme: ChartTheme.Yellow)
                .AddSeries(
                    chartType: "Column",
                    xValue: new[] { "Jan", "Feb", "Mar", "Apr", "May", "jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" },
                    yValues: new[] { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec }
                ).Write("png");
            return null;

        }
        public ActionResult MyChartBusiness()
        {
            double Jan = 10000.00;
            double Feb = 5000.00;
            double Mar = 6000.00;
            double Apr = 7000.00;
            double May = 3000.00;
            double Jun = 2000.00;
            double Jul = 9000.00;
            double Aug = 3000.00;
            double Sep = 4000.00;
            double Oct = 5000.00;
            double Nov = 6000.00;
            double Dec = 7000.00;
            new Chart(width: 600, height: 300, theme:ChartTheme.Green)
                .AddSeries(
                    chartType: "line",
                    xValue: new[] { "Jan", "Feb", "Mar", "Apr", "May", "jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" },
                    yValues: new[] { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec }
                ).Write("png");
            return null;

        }
        public ActionResult MyChart()
        {
            double Jan = 10000.00;
            double Feb = 5000.00;
            double Mar = 6000.00;
            double Apr = 7000.00;
            double May = 3000.00;
            double Jun = 2000.00;
            double Jul = 9000.00;
            //double Aug = 0.00;
            //double Sep = 0.00;
            //double Oct = 0.00;
            //double Nov = 0.00;
            //double Dec = 0.00;
            new Chart(width: 600, height: 300)
                .AddSeries(
                    chartType: "pie",
                    xValue: new[] { "Jan", "Feb", "Mar", "Apr", "May", "jun", "Jul"},
                    yValues: new[] { Jan, Feb, Mar, Apr, May, Jun, Jul}
                ).Write("png");
            return null;

        }


    }
}