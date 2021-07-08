namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ChiTietHD")]
    public partial class ChiTietHD
    {
        [Key]
        public int MaCTHD { get; set; }

        public int? MaHD { get; set; }

        public int? MaSP { get; set; }

        public int? SoLuong { get; set; }

        public double? ThanhTien { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
