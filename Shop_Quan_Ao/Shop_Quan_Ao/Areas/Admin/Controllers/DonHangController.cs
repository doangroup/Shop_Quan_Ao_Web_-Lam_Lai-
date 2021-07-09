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
            var dm = data.ChiTietHDs.Where(m => m.MaHD == id).ToList();
            return View(dm);
        }

        public ActionResult Index2()
        {
            var sp = data.HoaDons.Where(z => z.NgayGiao == null && z.Tinhtrang == 0).OrderBy(t => t.MaHD).Distinct().ToList();
            return View(sp);
        }
        public ActionResult XacNhanDon(int id)
        {
            if (ModelState.IsValid)
            {

                var maTK = Sua(id);
                if (maTK)
                {
                    return RedirectToAction("Index2", "DonHang");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa thất bại !");
                }
            }
            return View("Index2");
        }
        public bool Sua(int id)
        {
            try
            {
                var sanPham = data.HoaDons.SingleOrDefault(t => t.MaHD== id);
                sanPham.Tinhtrang = 1;
                data.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
