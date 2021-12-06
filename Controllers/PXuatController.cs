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

    public class PXuatController : Controller
    {
        private Db db = new Db();
        StringProcess strPro = new StringProcess();
        // GET: PXuat
        public ActionResult Index()
        {
            var pXuats = db.PXuats.Include(p => p.KhachHangs).Include(p => p.NhanViens);
            return View(pXuats.ToList());
        }

        // GET: PXuat/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PXuat pXuat = db.PXuats.Find(id);
            if (pXuat == null)
            {
                return HttpNotFound();
            }
            return View(pXuat);
        }

        // GET: PXuat/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH");
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV");
            var model = db.PXuats.ToList();
            if (model.Count == 0) ViewBag.id = "PX001";
            else
            {
                var id = model.OrderByDescending(s => s.MaPX).FirstOrDefault().MaPX; ViewBag.id = strPro.AutoGennerateKey(id);
            }
            return View();
        }

        // POST: PXuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPX,MaKH,MaNV,NgayLapHD,NgayGiaoHang")] PXuat pXuat)
        {
            if (ModelState.IsValid)
            {
                db.PXuats.Add(pXuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", pXuat.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", pXuat.MaNV);
            return View(pXuat);
        }

        // GET: PXuat/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PXuat pXuat = db.PXuats.Find(id);
            if (pXuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", pXuat.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", pXuat.MaNV);
            return View(pXuat);
        }

        // POST: PXuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPX,MaKH,MaNV,NgayLapHD,NgayGiaoHang")] PXuat pXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", pXuat.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", pXuat.MaNV);
            return View(pXuat);
        }

        // GET: PXuat/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PXuat pXuat = db.PXuats.Find(id);
            if (pXuat == null)
            {
                return HttpNotFound();
            }
            return View(pXuat);
        }

        // POST: PXuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PXuat pXuat = db.PXuats.Find(id);
            db.PXuats.Remove(pXuat);
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
