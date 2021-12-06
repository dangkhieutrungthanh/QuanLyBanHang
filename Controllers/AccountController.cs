using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QuanLyBanHang.Models;

namespace DangKhieuTrungThanh.Controllers
{
    public class AccountController : Controller
    {
        Db db = new Db();
        Encrytion encry = new Encrytion();
        // GET: Account
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Account acc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    acc.PassWord = encry.PassEncrytion(acc.PassWord);
                    db.Accounts.Add(acc);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception) { ModelState.AddModelError("", "Tài khoản đã có người đăng ký"); }

            return View(acc);

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account acc)
        {
            if (ModelState.IsValid)
            {
                string encrytionn = encry.PassEncrytion(acc.PassWord);
                var model = db.Accounts.Where(m => m.UserName == acc.UserName && m.PassWord == encrytionn).ToList().Count();
                if (model == 1)
                {
                    FormsAuthentication.SetAuthCookie(acc.UserName, true);
                    return RedirectToAction("Index", "LoaiSP");
                }
                else { ModelState.AddModelError("", "Thông tin đăng nhập sai lệnh"); }
            }
            return View(acc);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "LoaiSP");
        }
    }
}