
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
namespace QuanLyBanHang.Models
{
    [Table("LoaiSP")]
    public class LoaiSP
    {
        [Key]    
        public string MaLoaiSP { get; set; }
        [Required,Display(Name ="Tên loại sản phẩm")]
        public string TenLoaiSP { get; set; }
        public virtual  ICollection<SanPham> SanPhams { get; set; }
    }
}
