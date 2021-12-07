namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPX")]
    public partial class CTPX
    {
        [Key]
        public string MaCTPX { get; set; }
        [Required]
        public string MaPX { get; set; }

        [Required]
        public string MaSP { get; set; }

        [Required, Display(Name = "Số lượng")]
        public int SoLuong { get; set; }

        [Required,DataType(DataType.Currency), Display(Name = "Đơn giá")]
        public int DonGia { get; set; }
        public PXuat PXuats { get; set; }
        public SanPham SanPhams { get; set; }
    }
}