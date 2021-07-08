using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Shop_Quan_Ao.Areas.Admin.Models
{
    public class TaiKhoan
    {
        [Required(ErrorMessage = "Bạn phải nhập tài khoản")]
        public string tenDN { set; get; }
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string matKhau { set; get; }
        public bool nhoMK { set; get; }
    }
}