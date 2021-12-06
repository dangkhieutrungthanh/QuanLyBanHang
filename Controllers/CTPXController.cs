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

    public class CTPXController : Controller
    {
        private Db db = new Db();
        StringProcess strPro = new StringProcess();
        // GET: CTPX
        public ActionResult Index()
        {
            var cTPXs = db.CTPXs.Include(c => c.PXuats).Include(c => c.SanPhams);
            return View(cTPXs.ToList());
        }

        // GET: CTPX/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPX cTPX = db.CTPXs.Find(id);
            if (cTPX == null)
            {
                return HttpNotFound();
            }
            return View(cTPX);
        }

        // GET: CTPX/Create
        public ActionResult Create()
        {
            ViewBag.MaPX = new SelectList(db.PXuats, "MaPX", "MaKH");
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP");
            var model = db.CTPXs.ToList();
            if (model.Count == 0) ViewBag.id = "CTPX001";
            else
            {
                var id = model.OrderByDescending(s => s.MaCTPX).FirstOrDefault().MaCTPX; ViewBag.id = strPro.AutoGennerateKey(id);
            }

            return View();
        }

        // POST: CTPX/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTPX,MaPX,MaSP,SoLuong,DonGia")] CTPX cTPX)
        {
            if (ModelState.IsValid)
            {
                db.CTPXs.Add(cTPX);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPX = new SelectList(db.PXuats, "MaPX", "MaKH", cTPX.MaPX);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", cTPX.MaSP);
            return View(cTPX);
        }

        // GET: CTPX/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPX cTPX = db.CTPXs.Find(id);
            if (cTPX == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPX = new SelectList(db.PXuats, "MaPX", "MaKH", cTPX.MaPX);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", cTPX.MaSP);
            return View(cTPX);
        }

        // POST: CTPX/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTPX,MaPX,MaSP,SoLuong,DonGia")] CTPX cTPX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTPX).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPX = new SelectList(db.PXuats, "MaPX", "MaKH", cTPX.MaPX);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", cTPX.MaSP);
            return View(cTPX);
        }

        // GET: CTPX/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPX cTPX = db.CTPXs.Find(id);
            if (cTPX == null)
            {
                return HttpNotFound();
            }
            return View(cTPX);
        }

        // POST: CTPX/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CTPX cTPX = db.CTPXs.Find(id);
            db.CTPXs.Remove(cTPX);
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
