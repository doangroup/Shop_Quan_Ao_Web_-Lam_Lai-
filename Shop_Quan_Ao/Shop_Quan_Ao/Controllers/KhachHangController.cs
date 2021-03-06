using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_Quan_Ao.Models;

namespace Shop_Quan_Ao.Controllers
{
    public class KhachHangController : Controller
    {
        //
        DataClasses1DataContext data = new DataClasses1DataContext();
        // GET: /KhachHang/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DangKy()
        {
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection col)
        {
            string ten = col["Username"];
            string mk = col["Password"];
            KhachHang khach = data.KhachHangs.FirstOrDefault
               (k => k.SDT == ten && k.MatKhau == mk);
            if (khach == null)
            {
                TempData["message2"] = "Sai Mật Khẩu";
                return View();
                

            }
            Session["kh"] = khach;
            TempData["message1"] = "Chào Mừng Bạn Đến Với Logan Store";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection col)
        {
            string Ten = col["Name"];
            string DiaChi = col["DiaChi"];
            string SDT = col["Phone"];
            string MatKhau = col["PassWord"];
            Random rd = new Random();
            int ma = rd.Next(1, 1000);

            KhachHang khach = new KhachHang();
            khach.MaKH = ma;
            khach.TenKH = Ten;
            khach.DiaChi = DiaChi;
            khach.SDT = SDT;
            khach.MatKhau = MatKhau;

            data.KhachHangs.InsertOnSubmit(khach);
            data.SubmitChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult KhoiTaoKhach()
        {
            KhachHang Khach = (KhachHang)Session["kh"];

            //ViewBag.khach = Khach;
            return PartialView(Khach);
        }
        public ActionResult DangXuat()
        {

            Session["kh"] = null;
            return RedirectToAction("Index", "Home");
           
        }
        public ActionResult DaDangNhap()
        {

          
            KhachHang kh = (KhachHang)Session["kh"];
              
            if (kh == null)
            {
                
                return RedirectToAction("DangNhap", "KhachHang");
            }
          
                
            List<HoaDon> hd = data.HoaDons.Where(m => m.MaKH == kh.MaKH).ToList();
            
            ViewBag.Khach = kh;
            return View(hd);
        }
        
    }
}
