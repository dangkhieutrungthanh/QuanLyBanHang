namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChatLieu")]
    public partial class ChatLieu
    {
        [Key]
        [StringLength(50)]
        
        public string MaChatLieu { get; set; }

        [Required]
        [StringLength(50)]
        public string TenChatLieu { get; set; }
    }
}
