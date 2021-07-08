using Shop_Quan_Ao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop_Quan_Ao.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (NguoiDungDangNhap)Session[NguoiDungSesstion.nguoiDung];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "DangNhap", action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }

    }
}
