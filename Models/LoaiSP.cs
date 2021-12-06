namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiSP")]
    public partial class LoaiSP
    {
        [Key]
        public string MaLoaiSP { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Loại sản phẩm")]
        public string TenSP { get; set; }

        public ICollection<SanPham> SanPhams { get; set; }
    }
}