using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shop_Quan_Ao.Areas.Admin.Models;
using Shop_Quan_Ao.Models;


namespace Shop_Quan_Ao.Areas.Admin.Controllers
{
    public class DangNhapController : Controller
    {
        //
        // GET: /Admin/DangNhap/
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TaiKhoan tk)
        {
            if (ModelState.IsValid)
            {


                var fpw = MaHoaMD5.MD5Hash(tk.matKhau);
                var rs = data.NhanViens.Where(x => x.TenDN == tk.tenDN && x.MatKhau == fpw);
                if (rs.Count() > 0)
                {
                    var nguoidung = layTKTheoTen(tk.tenDN);
                    var nguoiDungSesstion = new NguoiDungDangNhap();
                    nguoiDungSesstion.tenDN = nguoidung.TenDN;
                    nguoiDungSesstion.maNV = nguoidung.MaNV;
                    Session.Add(NguoiDungSesstion.nguoiDung, nguoiDungSesstion);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu sai !");
                }
            }
            return View("Index");
        }
        public ActionResult KhoiTaoKhach()
        {


            NhanVien Khach = (NhanVien)Session["nv"];

            //ViewBag.khach = Khach;
            return PartialView(Khach);
        }
        public ActionResult DangXuat()
        {

            Session["nv"] = null;
            return RedirectToAction("Index", "Home");

        }
        public NhanVien layTKTheoTen(string tenDN)
        {
            return data.NhanViens.SingleOrDefault(t => t.TenDN == tenDN);
        }
        //public bool DangNhap(string tenDN, string mK)
        //{

        //    var res = db.NhanVien.Count(x => x.TenDN== tenDN && x.MatKhau == mK);
        //    if (res > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
