namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHDBan")]
    public partial class ChiTietHDBan
    {
       [Key]
        [StringLength(30)]
        public string MaHDBan { get; set; }

        
        [Required]
        [StringLength(50)]
        public string MaHang { get; set; }

        [Required]
        public double SoLuong { get; set; }

       
        [Required]
        public double DonGia { get; set; }

       
        [Required] 
        public double GiamHia { get; set; }

        
        [Required]
        public double ThanhTien { get; set; }
    }
}
