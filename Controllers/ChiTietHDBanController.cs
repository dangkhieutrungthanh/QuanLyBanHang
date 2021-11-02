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
    public class ChiTietHDBanController : Controller
    {
        private Db db = new Db();

        // GET: ChiTietHDBans
        public ActionResult Index()
        {
            return View(db.ChiTietHDBans.ToList());
        }

        // GET: ChiTietHDBans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHDBan chiTietHDBan = db.ChiTietHDBans.Find(id);
            if (chiTietHDBan == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHDBan);
        }

        // GET: ChiTietHDBans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChiTietHDBans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHDBan,MaHang,SoLuong,DonGia,GiamHia,ThanhTien")] ChiTietHDBan chiTietHDBan)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHDBans.Add(chiTietHDBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chiTietHDBan);
        }

        // GET: ChiTietHDBans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHDBan chiTietHDBan = db.ChiTietHDBans.Find(id);
            if (chiTietHDBan == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHDBan);
        }

        // POST: ChiTietHDBans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHDBan,MaHang,SoLuong,DonGia,GiamHia,ThanhTien")] ChiTietHDBan chiTietHDBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietHDBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chiTietHDBan);
        }

        // GET: ChiTietHDBans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHDBan chiTietHDBan = db.ChiTietHDBans.Find(id);
            if (chiTietHDBan == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHDBan);
        }

        // POST: ChiTietHDBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietHDBan chiTietHDBan = db.ChiTietHDBans.Find(id);
            db.ChiTietHDBans.Remove(chiTietHDBan);
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
