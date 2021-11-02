namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HDBan")]
    public partial class HDBan
    {
        [Key]
        [StringLength(30)]
        public string MaHDBan { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhanVien { get; set; }

        public DateTime NgayBan { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKhach { get; set; }

        public double TongTien { get; set; }
    }
}
