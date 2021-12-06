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
    [Authorize]

    public class PNhapController : Controller
    {
        private Db db = new Db();
        StringProcess strPro = new StringProcess();
        // GET: PNhap
        public ActionResult Index()
        {
            var pNhaps = db.PNhaps.Include(p => p.NCCs).Include(p => p.NhanViens);
            return View(pNhaps.ToList());
        }

        // GET: PNhap/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNhap pNhap = db.PNhaps.Find(id);
            if (pNhap == null)
            {
                return HttpNotFound();
            }
            return View(pNhap);
        }

        // GET: PNhap/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.NCCs, "MaNCC", "TenNCC");
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV");
            var model = db.PNhaps.ToList();
            if (model.Count == 0) ViewBag.id = "PN001";
            else
            {
                var id = model.OrderByDescending(s => s.MaPN).FirstOrDefault().MaPN; ViewBag.id = strPro.AutoGennerateKey(id);
            }

            return View();
        }

        // POST: PNhap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPN,MaNCC,MaNV,NgayLapHD,NgayGiaoHang")] PNhap pNhap)
        {
            if (ModelState.IsValid)
            {
                db.PNhaps.Add(pNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(db.NCCs, "MaNCC", "TenNCC", pNhap.MaNCC);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", pNhap.MaNV);
            return View(pNhap);
        }

        // GET: PNhap/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNhap pNhap = db.PNhaps.Find(id);
            if (pNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NCCs, "MaNCC", "TenNCC", pNhap.MaNCC);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", pNhap.MaNV);
            return View(pNhap);
        }

        // POST: PNhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPN,MaNCC,MaNV,NgayLapHD,NgayGiaoHang")] PNhap pNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NCCs, "MaNCC", "TenNCC", pNhap.MaNCC);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", pNhap.MaNV);
            return View(pNhap);
        }

        // GET: PNhap/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNhap pNhap = db.PNhaps.Find(id);
            if (pNhap == null)
            {
                return HttpNotFound();
            }
            return View(pNhap);
        }

        // POST: PNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PNhap pNhap = db.PNhaps.Find(id);
            db.PNhaps.Remove(pNhap);
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
