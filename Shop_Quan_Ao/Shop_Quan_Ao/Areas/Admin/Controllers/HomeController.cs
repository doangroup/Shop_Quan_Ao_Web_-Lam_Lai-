using Shop_Quan_Ao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
namespace Shop_Quan_Ao.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Admin/Home/
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index()
        {
            List<SanPham> dm = data.SanPhams.OrderBy(t => t.MaSP).ToList();
            return View(dm);
        }
        

    }
}
