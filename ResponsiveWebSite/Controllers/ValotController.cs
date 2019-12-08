using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResponsiveWebSite.Models;

namespace ResponsiveWebSite.Controllers
{
    public class ValotController : Controller
    {
        private AlytaloBaseDataEntities db = new AlytaloBaseDataEntities();

        // GET: Valot
        public ActionResult Index()
        {
            var valo = db.Valo.Include(v => v.Huone);
            return View(valo.ToList());
        }

        // GET: Valot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valo valo = db.Valo.Find(id);
            if (valo == null)
            {
                return HttpNotFound();
            }
            return View(valo);
        }

        // GET: Valot/Create
        public ActionResult Create()
        {
            ViewBag.HuoneID = new SelectList(db.Huone, "HuoneID", "HuoneenNimi");
            return View();
        }

        // POST: Valot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ValoID,HuoneID,ValoOff,ValoOn33,ValoOn66,ValoOn100,ValoDate33,ValoDate66,ValoDate100,ValoDateOff,ValoTila,ValonNimi")] Valo valo)
        {
            if (ModelState.IsValid)
            {
                db.Valo.Add(valo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HuoneID = new SelectList(db.Huone, "HuoneID", "HuoneenNimi", valo.HuoneID);
            return View(valo);
        }

        // GET: Valot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valo valo = db.Valo.Find(id);
            if (valo == null)
            {
                return HttpNotFound();
            }
            ViewBag.HuoneID = new SelectList(db.Huone, "HuoneID", "HuoneenNimi", valo.HuoneID);
            return View(valo);
        }

        // POST: Valot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ValoID,HuoneID,ValoOff,ValoOn33,ValoOn66,ValoOn100,ValoDate33,ValoDate66,ValoDate100,ValoDateOff,ValoTila,ValonNimi")] Valo valo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HuoneID = new SelectList(db.Huone, "HuoneID", "HuoneenNimi", valo.HuoneID);
            return View(valo);
        }

        // GET: Valot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valo valo = db.Valo.Find(id);
            if (valo == null)
            {
                return HttpNotFound();
            }
            return View(valo);
        }

        // POST: Valot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Valo valo = db.Valo.Find(id);
            db.Valo.Remove(valo);
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
