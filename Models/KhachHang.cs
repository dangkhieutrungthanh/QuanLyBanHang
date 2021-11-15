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
        [StringLength(10)]
        public string MaKH { get; set; }

        [Required]
        [StringLength(50)]
        public string TenKH { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(20)]
        public string DienThoai { get; set; }
    }
}
