using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_26_MVC_Filter.Models
{
    public class KullaniciFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Request.Cookies.Get("cerez") == null)
            {
                filterContext.HttpContext.Response.Redirect("/Home/GirisYap");
            }
        }
    }
}