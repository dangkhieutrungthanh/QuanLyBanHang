using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace QuanLyBanHang.Models
{
    public class Encrytion
    {
        public string PassEncrytion(string pass)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pass.Trim(), "MD5");
        }
    }
}