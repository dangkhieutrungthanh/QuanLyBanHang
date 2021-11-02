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
    public class HangController : Controller
    {
        private Db db = new Db();
        public StringProcess SP = new StringProcess();
        // GET: Hangs
        public ActionResult Index()
        {
            return View(db.Hangs.ToList());
        }

        // GET: Hangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }

        // GET: Hangs/Create
        public ActionResult Create()
        {
            var model = db.Hangs.ToList();
            if (model.Count == 0)
            { ViewBag.Id = "HH001"; }
            else
            {
                var id = model.OrderByDescending(m => m.MaHang).FirstOrDefault().MaHang;
                var newKey = SP.AutoGennerateKey(id);
                ViewBag.Id = newKey;
            }
            return View();
        }

        // POST: Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHang,TenHang,SoLuong,DonGiaNhap,DonGiaBan,Anh,GhiChu")] Hang hang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Hangs.Add(hang);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception) { ModelState.AddModelError("", "Phat sinh loi."); }
            return View(hang);
        }

        // GET: Hangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }

        // POST: Hangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHang,TenHang,SoLuong,DonGiaNhap,DonGiaBan,Anh,GhiChu")] Hang hang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hang);
        }

        // GET: Hangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }

        // POST: Hangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hang hang = db.Hangs.Find(id);
            db.Hangs.Remove(hang);
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
