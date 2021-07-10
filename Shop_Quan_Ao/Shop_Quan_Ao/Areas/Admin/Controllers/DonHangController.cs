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
                    TempData["message1"] = "Xác nhận đơn thành công";
                    return RedirectToAction("Index2", "DonHang");
                }
                else
                {
                    TempData["message2"] = "Xác nhận thất bại";
                    ModelState.AddModelError("", "Sửa thất bại !");
                }
            }
            return View("Index2");
        }
        public ActionResult HuyDonHang(int id)
        {
            if (ModelState.IsValid)
            {

                var maTK = Xoa(id);
                if (maTK)
                {
                    TempData["message3"] = "Hủy đơn thành công";
                    return RedirectToAction("Index2", "DonHang");
                }
                else
                {
                    TempData["message4"] = "Hủy thất bại";
                    ModelState.AddModelError("", "Sửa thất bại !");
                }
            }
            return View("Index2");
        }
        public ActionResult LichSuMuaHang(int id)
        {
            var lsKH = data.HoaDons.Where(t => t.MaKH == id).Distinct().OrderBy(z => z.MaHD).ToList();
            return View(lsKH);
        }
        public bool Sua(int id)
        {
            try
            {
                var sanPham = data.HoaDons.SingleOrDefault(t => t.MaHD== id);
                sanPham.Tinhtrang = 1;
                DateTime dateTime = DateTime.Now;
                sanPham.NgayGiao = dateTime.AddDays(3);
                data.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool Xoa(int id)
        {
            try
            {
                var ctHD = data.ChiTietHDs.SingleOrDefault(t => t.MaHD== id);
                data.ChiTietHDs.DeleteOnSubmit(ctHD);
                data.SubmitChanges();
                var hd = data.HoaDons.SingleOrDefault(t => t.MaHD == id);
                data.HoaDons.DeleteOnSubmit(hd);
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
