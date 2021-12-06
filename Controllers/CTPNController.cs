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
    public class CTPNController : Controller
    {
        private Db db = new Db();
        StringProcess strPro = new StringProcess();
        // GET: CTPN
        public ActionResult Index()
        {
            var cTPNs = db.CTPNs.Include(c => c.PNhaps).Include(c => c.SanPhams);
            return View(cTPNs.ToList());
        }

        // GET: CTPN/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPN cTPN = db.CTPNs.Find(id);
            if (cTPN == null)
            {
                return HttpNotFound();
            }
            return View(cTPN);
        }

        // GET: CTPN/Create
        public ActionResult Create()
        {
            ViewBag.MaPN = new SelectList(db.PNhaps, "MaPN", "MaNCC");
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP");
            var model = db.CTPNs.ToList();
            if (model.Count == 0) ViewBag.id = "CTPN001";
            else
            {
                var id = model.OrderByDescending(s => s.MaCTPN).FirstOrDefault().MaCTPN; ViewBag.id = strPro.AutoGennerateKey(id);
            }

            return View();
        }

        // POST: CTPN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTPN,MaPN,MaSP,SoLuong,DonGia")] CTPN cTPN)
        {
            if (ModelState.IsValid)
            {
                db.CTPNs.Add(cTPN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPN = new SelectList(db.PNhaps, "MaPN", "MaNCC", cTPN.MaPN);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", cTPN.MaSP);
            return View(cTPN);
        }

        // GET: CTPN/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPN cTPN = db.CTPNs.Find(id);
            if (cTPN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPN = new SelectList(db.PNhaps, "MaPN", "MaNCC", cTPN.MaPN);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", cTPN.MaSP);
            return View(cTPN);
        }

        // POST: CTPN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTPN,MaPN,MaSP,SoLuong,DonGia")] CTPN cTPN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTPN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPN = new SelectList(db.PNhaps, "MaPN", "MaNCC", cTPN.MaPN);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", cTPN.MaSP);
            return View(cTPN);
        }

        // GET: CTPN/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPN cTPN = db.CTPNs.Find(id);
            if (cTPN == null)
            {
                return HttpNotFound();
            }
            return View(cTPN);
        }

        // POST: CTPN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CTPN cTPN = db.CTPNs.Find(id);
            db.CTPNs.Remove(cTPN);
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
