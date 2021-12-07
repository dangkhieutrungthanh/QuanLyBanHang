namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key, Display(Name = "Mã Nhân viên")]
        public string MaNV { get; set; }

        [Required, Display(Name = "Tên Nhân viên")]
        public string TenNV { get; set; }
        [Required, Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Required, Display(Name = "Điện thoại")]
        public string DienThoai { get; set; }
    }
}