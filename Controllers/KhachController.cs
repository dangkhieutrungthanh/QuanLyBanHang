using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyBanHang.Models;

namespace QuanLyBanHang.Controllers
{
    public class KhachController : Controller
    {
        private Db db = new Db();
        StringProcess SP = new StringProcess();

        // GET: Khaches
        public ActionResult Index()
        {
            return View(db.Khachs.ToList());
        }

        // GET: Khaches/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khach khach = db.Khachs.Find(id);
            if (khach == null)
            {
                return HttpNotFound();
            }
            return View(khach);
        }

        // GET: Khaches/Create
        public ActionResult Create()
        {
            var model = db.Khachs.ToList();
            if (model.Count == 0)
            { ViewBag.Id = "KH001"; }
            else
            {
                var id = model.OrderByDescending(m => m.MaKhach).FirstOrDefault().MaKhach;
                var newKey = SP.AutoGennerateKey(id);
                ViewBag.Id = newKey;
            }
            return View();
        }

        // POST: Khaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhach,TenKhach,DiaChi,DienThoai")] Khach khach)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Khachs.Add(khach);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception) { ModelState.AddModelError("", "Phat sinh loi."); }
            return View(khach);
        }

        // GET: Khaches/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khach khach = db.Khachs.Find(id);
            if (khach == null)
            {
                return HttpNotFound();
            }
            return View(khach);
        }

        // POST: Khaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhach,TenKhach,DiaChi,DienThoai")] Khach khach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khach);
        }

        // GET: Khaches/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khach khach = db.Khachs.Find(id);
            if (khach == null)
            {
                return HttpNotFound();
            }
            return View(khach);
        }

        // POST: Khaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Khach khach = db.Khachs.Find(id);
            db.Khachs.Remove(khach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
