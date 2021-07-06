using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Quan_Ao.Models
{
    public class GioHang
    {
        public List<CartItem> dsSp;

        // Khoi Tao Gio Hang
        public GioHang()
        {
            dsSp = new List<CartItem>();
        }

        public GioHang(List<CartItem> lst)
        {
            dsSp = lst;
        }

        public int Somathang()
        {
            if (dsSp == null)
                return 0;
            return dsSp.Count();
        }
        public int Tongsoluong()
        {
            if (dsSp == null)
                return 0;
            return dsSp.Sum(t => t.iSoLuong);
        }
        public double TongThanhTien()
        {
            if (dsSp == null)
                return 0;
            return dsSp.Sum(t => t.ThanhTien);
        }

        //pp Xu Ly
        public int Them(int ms)
        {
            //tim sp co trong ds gio hang hay khong
            CartItem a = dsSp.SingleOrDefault(i => i.iMaSP == ms);
            if (a == null)
            {
                CartItem sp = new CartItem(ms);
                if (sp == null)
                    return 0;
                dsSp.Add(sp);
            }
            else
            {
                a.iSoLuong += 1;
            }
            return 1;
        }

        // Xoa 1 mat hang
        public void Xoa(int msp)
        {
            //tim sp co trong ds gio hang hay khong
            CartItem a = dsSp.SingleOrDefault(i => i.iMaSP == msp);
            dsSp.Remove(a);

        }


    }
}