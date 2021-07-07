using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_Quan_Ao.Models;

namespace Shop_Quan_Ao.Controllers
{
    public class DatHangController : Controller
    {
        //
        DataClasses2DataContext data = new DataClasses2DataContext();
        // GET: /DatHang/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XemGioHang()
        {
            GioHang gh = (GioHang)Session["gh"];
            if (gh==null)
            {
                return RedirectToAction("GioHangTrong","DatHang");
            }
           
            return View(gh);
        }
        public ActionResult GioHangTrong()
        {
            
            

            return View();
        }
        public ActionResult KhoiTaoLayout()
        {

            GioHang gio = (GioHang)Session["gh"];
            KhachHang Khach = (KhachHang)Session["kh"];
            return PartialView(gio);
        }

        public ActionResult Themmathang(int msp)
        {
            GioHang gh = (GioHang)Session["gh"];
            if (gh == null)
                gh = new GioHang();
            int kq = gh.Them(msp);
            Session["gh"] = gh;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Xoamathang(int id)
        {
            GioHang gh = (GioHang)Session["gh"];

            gh.Xoa(id);
            Session["gh"] = gh;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult XoaGioHang()
        {

            Session["gh"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult XacNhanDonHang()
        {
            KhachHang khach = Session["kh"] as KhachHang;
            if (khach == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.k = khach;
            GioHang gio = Session["gh"] as GioHang;
            return View(gio);
        }

        [HttpPost]
        public ActionResult LuuDonHang(FormCollection col)
        {
            GioHang gh = (GioHang)Session["gh"];
            KhachHang khach = (KhachHang)Session["kh"];
            if (Session["kh"] == null)
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            if (Session["gh"] == null || gh.dsSp.Count == 0)
            {
                return RedirectToAction("XemGioHang", "DatHang");
            }
            string ngaygiao = col["txtDate"];
            Random rd = new Random();
            int nn = rd.Next(1, 10000);
            HoaDon hd = new HoaDon();
            hd.MaHD = nn;

            hd.MaKH = khach.MaKH;
            hd.NgayBan = DateTime.Now;
            hd.Tinhtrang = 0;
            hd.NgayGiao = Convert.ToDateTime(ngaygiao);
            data.HoaDons.InsertOnSubmit(hd);

            data.SubmitChanges();

            //////////
            foreach (CartItem item in gh.dsSp)
            {
                ChiTietHD ct = new ChiTietHD();
                ct.MaHD = hd.MaHD;

                ct.SoLuong = item.iSoLuong;
                ct.ThanhTien = item.ThanhTien;

                data.ChiTietHDs.InsertOnSubmit(ct);
                data.SubmitChanges();
            }


            Session["gh"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
