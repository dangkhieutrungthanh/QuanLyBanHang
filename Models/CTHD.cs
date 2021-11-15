namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHD")]
    public partial class CTHD
    {
        [Key]
        [StringLength(30)]
        public string MaHD { get; set; }


        [Required]
        [StringLength(50)]
        public string MaSP { get; set; }

        [Required]
        public double SoLuong { get; set; }


        [Required]
        public double DonGiaBan { get; set; }

    }
}
