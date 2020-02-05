using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace Sharmila_Textile_WebApp.HtmlEntities {

    public static class ActiveRouteTagHelper {
        public static string IsTabActive(ViewContext viewContext, string selectedController, string selectedAction) {
            string flag = "";

            string controller = viewContext.RouteData.Values["controller"].ToString();
            string action = viewContext.RouteData.Values["action"].ToString();

            if (controller == selectedController && action == selectedAction) {
                flag = "active";
            }

            return flag;
        }
    }
}
