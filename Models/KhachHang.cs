namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        public string MaKH { get; set; }

        [Required,Display(Name ="Tên khách hàng")]
        public string TenKH { get; set; }

        [Required,MinLength(10)]
        public string DiaChi { get; set; }
        [Required, MinLength(10)]
        public string DienThoai { get; set; }

        public string Email { get; set; }

        public ICollection<PXuat> PXuats { get; set; }
    }
}