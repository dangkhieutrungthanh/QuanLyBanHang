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

    public class NCCController : Controller
    {
        private Db db = new Db();
        StringProcess strPro = new StringProcess();
        // GET: NCC
        public ActionResult Index()
        {
            return View(db.NCCs.ToList());
        }

        // GET: NCC/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NCC nCC = db.NCCs.Find(id);
            if (nCC == null)
            {
                return HttpNotFound();
            }
            return View(nCC);
        }

        // GET: NCC/Create
        public ActionResult Create()
        {
            var model = db.NCCs.ToList();
            if (model.Count == 0) ViewBag.id = "NCC001";
            else
            {
                var id = model.OrderByDescending(s => s.MaNCC).FirstOrDefault().MaNCC; ViewBag.id = strPro.AutoGennerateKey(id);
            }

            return View();
        }

        // POST: NCC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNCC,TenNCC,DiaChi,DienThoai,Email")] NCC nCC)
        {
            if (ModelState.IsValid)
            {
                db.NCCs.Add(nCC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nCC);
        }

        // GET: NCC/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NCC nCC = db.NCCs.Find(id);
            if (nCC == null)
            {
                return HttpNotFound();
            }
            return View(nCC);
        }

        // POST: NCC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNCC,TenNCC,DiaChi,DienThoai,Email")] NCC nCC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nCC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nCC);
        }

        // GET: NCC/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NCC nCC = db.NCCs.Find(id);
            if (nCC == null)
            {
                return HttpNotFound();
            }
            return View(nCC);
        }

        // POST: NCC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NCC nCC = db.NCCs.Find(id);
            db.NCCs.Remove(nCC);
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
