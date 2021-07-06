using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Quan_Ao.Models
{
    public partial class SanPham
    {
        int maSanPham { get; set; }
        int maDM { get; set; }
        int soLuong { get; set; }



        double donGia { get; set; }


        string tenSanPham { get; set; }
        string hinhAnh { get; set; }
        string ghiChu { get; set; }


    }
}