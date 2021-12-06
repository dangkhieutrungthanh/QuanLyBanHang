using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Security;

namespace QuanLyBanHang.Models
{
    public class Account
    {
        [Key]
        [Required(ErrorMessage = "Chưa điền tài khoản")]
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Chưa điền mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string PassWord { get; set; }

    }
}