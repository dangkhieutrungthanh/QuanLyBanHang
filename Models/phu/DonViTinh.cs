
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace QuanLyBanHang.Models
{
    [Table("DonViTinh")]
    public class DonViTinh
    {
        [Key]
        public string MaDVT { get; set; }
        [Required, Display(Name = "Tên loại sản phẩm")]
        public string DonViTinh { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
