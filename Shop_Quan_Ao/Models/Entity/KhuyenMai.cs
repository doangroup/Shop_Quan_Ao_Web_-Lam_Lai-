namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KhuyenMai")]
    public partial class KhuyenMai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaKM { get; set; }

        [StringLength(50)]
        public string TenKM { get; set; }

        public string LinkKM { get; set; }
    }
}
