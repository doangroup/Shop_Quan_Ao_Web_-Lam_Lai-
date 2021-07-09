using PagedList;
using Shop_Quan_Ao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Quan_Ao.Areas.Admin.Controllers
{
    public class SanPhamController : BaseController
    {
        //
        // GET: /Admin/SanPham/
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index()
        {
            var sp = data.SanPhams.OrderBy(t => t.MaSP).ToList();
            return View(sp);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int ma)
        {
            var model = xemChiTiet(ma);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(SanPham dm)
        {
            if (ModelState.IsValid)
            {
                
                long maTK =Them(dm);
                if (maTK > 0)
                {
                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại !");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(SanPham dm)
        {
            if (ModelState.IsValid)
            {
                
                var maTK = Sua(dm);
                if (maTK)
                {
                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa thành công !");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            SanPham sach = data.SanPhams.SingleOrDefault(n => n.MaSP == id);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.SanPhams.DeleteOnSubmit(sach);
            data.SubmitChanges();
            return RedirectToAction("Index","Home");
        }
       
        

        
        public long Them(SanPham ncc)
        {
            data.SanPhams.InsertOnSubmit(ncc);
            data.SubmitChanges();
            return ncc.MaSP;
        }
        public bool Sua(SanPham sp)
        {
            try
            {
                SanPham sanPham = data.SanPhams.SingleOrDefault(t => t.MaSP == sp.MaSP);


               
                sanPham.MaDM = sp.MaDM;
                sanPham.TenSP = sp.TenSP;
                sanPham.SoLuong = sp.SoLuong;
                sanPham.DonGia = sp.DonGia;
                sanPham.HinhAnh = sp.HinhAnh;
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
                SanPham sanPham = data.SanPhams.SingleOrDefault(t => t.MaSP == id);
                data.SanPhams.DeleteOnSubmit(sanPham);
                data.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public SanPham xemChiTiet(int ma)
        {
            return data.SanPhams.Where(t => t.MaSP == ma).FirstOrDefault();
        }
        public SanPham laySPTheoTen(string ten)
        {
            return data.SanPhams.SingleOrDefault(t => t.TenSP == ten);
        }

    }
}
