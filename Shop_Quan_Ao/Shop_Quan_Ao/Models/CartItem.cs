using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop_Quan_Ao.Models;

namespace Shop_Quan_Ao.Models
{
    public class CartItem
    {

        public int iMaSP { get; set; }
        public string sTenSp { get; set; }
        public string sAnhBia { get; set; }
        public double sDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * sDonGia; }
        }
        DataClasses2DataContext data = new DataClasses2DataContext();
        public CartItem(int MaSp)
        {
            SanPham sp = data.SanPhams.Single(n => n.MaSP == MaSp);
            if (sp != null)
            {
                iMaSP = MaSp;
                sTenSp = sp.TenSP;
                sAnhBia = sp.HinhAnh;
                sDonGia = double.Parse(sp.DonGia.ToString());
                iSoLuong = 1;
            }
        }
    }
}