using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_Quan_Ao.Models;

namespace Shop_Quan_Ao.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        DataClasses2DataContext data = new DataClasses2DataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSach_DanhMuc_SanPham()
        {
            List<DanhMuc> dmsp = data.DanhMucs.ToList();
            return PartialView(dmsp);
        }
        public ActionResult DanhSach_DanhMuc_SanPham_2()
        {
            List<DanhMuc> dmsp = data.DanhMucs.ToList();
            return PartialView(dmsp);
        }
        public ActionResult Hien_Thi_DS_DanhMuc(int id)
        {
            List<SanPham> dm = data.SanPhams.Where(m => m.MaDM == id).ToList();
            return View(dm);
        }
        public ActionResult ChiTietSP(int id)
        {
            SanPham sp = data.SanPhams.SingleOrDefault(x => x.MaSP == id);
            List<SanPham> ds_danhmuc = data.SanPhams.Where(s => s.MaDM == sp.MaDM).Take(4).ToList();

            ViewBag.SanPham = sp;
            ViewBag.ds_DM = ds_danhmuc;

            return View(sp);
        }

    }
}
