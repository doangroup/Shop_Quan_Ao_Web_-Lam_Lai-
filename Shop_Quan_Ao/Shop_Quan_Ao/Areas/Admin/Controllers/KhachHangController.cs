using Shop_Quan_Ao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Quan_Ao.Areas.Admin.Controllers
{
    public class KhachHangController : BaseController
    {
        //
        // GET: /Admin/KhachHang/
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index()
        {
            var kh = data.KhachHangs.Distinct().OrderBy(t => t.MaKH).ToList();
            return View(kh);
        }

    }
}
