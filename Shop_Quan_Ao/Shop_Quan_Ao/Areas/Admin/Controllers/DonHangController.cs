using Shop_Quan_Ao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Quan_Ao.Areas.Admin.Controllers
{
    public class DonHangController : BaseController
    {
        //
        // GET: /Admin/DonHang/
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index(int id)
        {

            List<ChiTietHD> dm = data.ChiTietHDs.Where(m => m.MaHD == id).ToList();
            return View(dm);
        }

        public ActionResult Index2()
        {
            var sp = data.HoaDons.OrderBy(t => t.MaHD).Distinct().ToList();
            return View(sp);
        }
        public ActionResult XacNhanDon()
        {
            return View();
        }

    }
}
