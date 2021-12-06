namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NCC")]
    public partial class NCC
    {
        [Key]
        public string MaNCC { get; set; }

        [Required, Display(Name = "Tên nhà cung cấp")]
        public string TenNCC { get; set; }

        [Required, MinLength(10)]
        public string DiaChi { get; set; }
        [Required, MinLength(10)]
        public string DienThoai { get; set; }

        public string Email { get; set; }

        public ICollection<PNhap> PNhaps { get; set; }
    }
}