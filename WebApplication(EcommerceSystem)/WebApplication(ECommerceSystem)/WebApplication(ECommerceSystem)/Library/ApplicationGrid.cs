using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication_ECommerceSystem_.Library
{
    public class ApplicationGrid
    {
        public static IDictionary<string, string> column { get; set; }


        public static string GetAddBreadCum(string breadcrumb, string controller, string AddFunctionId)
        {
            var label = breadcrumb.Split('|');
            string breadCum = "";
            breadCum += "<div class=\"page-header\">";
            breadCum += "<div class=\"row\">";
            breadCum += "<div class=\"col-sm-6 col-md-6 col-lg-6  col-xl-6\">";
            breadCum += "<ol class=\"breadcrumb float-lg-left\">";
            breadCum += "<li class=\"breadcrumb-item\" ><a href='#'>" + label[0] + "</a></li>";
            breadCum += "<li class=\"breadcrumb-item\"><a href='#'>" + label[1] + "</a></li>";
            breadCum += "<li class='breadcrumb-item active'>" + label[2] + "</li>";
            breadCum += "</ol>";
            breadCum += "</div>";
            breadCum += "<div class=\"col-sm-6 col-md-6 col-lg-6 col-xl-6\">";
            breadCum += "<div class=\"form-group form-action float-lg-right\">";
            breadCum += "<button class=\"btn btn-dark mr-1 \" onclick=\"GoBack();\"><i class=\"mdi mdi-arrow-left\"></i> Back</button>";           
            
            
            if (controller.ToLower() == "riclaimriderpayment" && AddFunctionId == "106340")
            {
                breadCum += "<a href=\"/" + controller + "/MIBManage\" class=\"btn btn-success\"><i class=\"mdi mdi-plus\"></i> Add New</a>";
            }
            else
            {
                breadCum += "<a href=\"/" + controller + "/Manage\" class=\"btn btn-success \"><i class=\"mdi mdi-plus\"></i> Add New</a>";
            }
            //else if (StaticData.HasRight(controller, AddFunctionId))
            //{
            //    breadCum += "<a href=\"/" + controller + "/Manage\" class=\"btn btn-success\"><i class=\"mdi mdi-plus\"></i> Add New</a>";
            //}

            breadCum += "</div></div></div></div><hr/>";

            return breadCum;
        }

        public static string GetBreadCum(string breadcrumb = "Home|Management|Manage", string ButtonName = "Submit")
        {
            var label = breadcrumb.Split('|');
            string breadCum = "";
            breadCum += "<div class='page-header' id='stickHeader'>";
            breadCum += "<div class='row'>";
            breadCum += "<div class='col-sm-6 col-md-6 col-lg-6  col-xl-6'>";
            breadCum += "<ol class='breadcrumb float-lg-left'>";
            breadCum += "<li class=\"breadcrumb-item\" ><a href='#'>" + label[0] + "</a></li>";
            breadCum += "<li class=\"breadcrumb-item\" ><a href='#'>" + label[1] + "</a></li>";
            breadCum += "<li class='breadcrumb-item active'>" + label[2] + "</li>";
            breadCum += "</ol>";
            breadCum += "</div>";
            breadCum += "<div class='col-sm-6 col-md-6 col-lg-6 col-xl-6'>";
            breadCum += "<div class='form-group form-action float-lg-right'>";
            breadCum += "<a onclick='GoBack();' class='btn btn-dark' style=\"color:white\"><i class='mdi mdi mdi-arrow-left'></i> Back </a>";
            //if (!string.IsNullOrWhiteSpace(ButtonName))
            //{
            //    breadCum += "<button type='submit' class='btn btn-primary'><i class='mdi mdi-check-circle-outline'></i> " + ButtonName + "</button>";
            //}

            //if (!string.IsNullOrWhiteSpace(ButtonName) && ButtonName == "ApproveTreaty")
            //{

            //    breadCum += "<a href='#' class='btn btn-danger'><i class='mdi mdi-check-circle-outline'></i> " + "RejectTreaty" + "</a>";
            //}

            //if (!string.IsNullOrWhiteSpace(ButtonName) && ButtonName == "RICitySetup")
            //{

            //    breadCum += "<a href='/RICitySetup/Manage' class='btn btn-danger'><i class='mdi mdi-check-circle-outline'></i> " + "Manage" + "</a>";
            //}
            breadCum += "</div>";
            breadCum += "</div>";
            breadCum += "</div>";
            breadCum += "</div>";
            return breadCum;

        }


    }
}