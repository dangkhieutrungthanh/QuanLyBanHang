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
    public class HDBanController : Controller
    {
        private Db db = new Db();

        // GET: HDBan
        public ActionResult Index()
        {
            return View(db.HDBans.ToList());
        }

        // GET: HDBan/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDBan hDBan = db.HDBans.Find(id);
            if (hDBan == null)
            {
                return HttpNotFound();
            }
            return View(hDBan);
        }

        // GET: HDBan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HDBan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHDBan,MaNhanVien,NgayBan,MaKhach,TongTien")] HDBan hDBan)
        {
            if (ModelState.IsValid)
            {
                db.HDBans.Add(hDBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hDBan);
        }

        // GET: HDBan/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDBan hDBan = db.HDBans.Find(id);
            if (hDBan == null)
            {
                return HttpNotFound();
            }
            return View(hDBan);
        }

        // POST: HDBan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHDBan,MaNhanVien,NgayBan,MaKhach,TongTien")] HDBan hDBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hDBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hDBan);
        }

        // GET: HDBan/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDBan hDBan = db.HDBans.Find(id);
            if (hDBan == null)
            {
                return HttpNotFound();
            }
            return View(hDBan);
        }

        // POST: HDBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HDBan hDBan = db.HDBans.Find(id);
            db.HDBans.Remove(hDBan);
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
