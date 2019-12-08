using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ResponsiveWebSite.Models;

namespace ResponsiveWebSite.Controllers
{
    public class ValoPaneeliController : Controller
    {
        private AlytaloBaseDataEntities db = new AlytaloBaseDataEntities();

        // GET: ValoPaneeli
        public ActionResult Index()
        {
            var valo = db.Valo.Include(v => v.Huone);
            return View(valo.ToList());
        }

        public JsonResult GetList()
        {
            AlytaloBaseDataEntities entities = new AlytaloBaseDataEntities();
            var model = (from v in entities.Valo
                         from h in entities.Huone
                         select new
                         {
                             v.ValoID,
                             v.HuoneID,    
                             v.ValoOff,
                             v.ValoOn33,
                             v.ValoOn66,
                             v.ValoOn100,
                             v.ValoDate33,
                             v.ValoDate66,
                             v.ValoDate100,
                             v.ValoDateOff,
                             v.ValoTila,
                             v.ValonNimi,
                             h.HuoneenNimi
                         }).ToList();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();
            //välimuistin hallinta
            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValotOff(string id)
        {
            AlytaloBaseDataEntities entities = new AlytaloBaseDataEntities();

            bool OK = false;
            Valo dbItem = (from v in entities.Valo
                               where v.ValoID.ToString() == id
                               select v).FirstOrDefault();

            if (dbItem != null)
            {
                dbItem.ValoOff = true;
                dbItem.ValoTila = "OFF";
                dbItem.ValoDateOff = DateTime.Now;

                entities.SaveChanges();
                OK = true;
            }

            //entiteettiolion muistin vapauttaminen
            entities.Dispose();

            // palautetaan 'json' muotoista dataa
            return Json(OK, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Valot33(string id)
        {
            AlytaloBaseDataEntities entities = new AlytaloBaseDataEntities();

            bool OK = false;
            Valo dbItem = (from v in entities.Valo
                               where v.ValoID.ToString() == id
                               select v).FirstOrDefault();

            if (dbItem != null)
            {
                dbItem.ValoOn33 = true;
                dbItem.ValoTila = "33";
                dbItem.ValoDate33 = DateTime.Now;

                entities.SaveChanges();
                OK = true;
            }

            //entiteettiolion muistin vapauttaminen
            entities.Dispose();

            // palautetaan 'json' muodotoista dataa
            return Json(OK, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Valot66(string id)
        {
            AlytaloBaseDataEntities entities = new AlytaloBaseDataEntities();

            bool OK = false;
            Valo dbItem = (from v in entities.Valo
                               where v.ValoID.ToString() == id
                               select v).FirstOrDefault();

            if (dbItem != null)
            {
                dbItem.ValoOn66 = true;
                dbItem.ValoTila = "66";
                dbItem.ValoDate66 = DateTime.Now;

                entities.SaveChanges();
                OK = true;
            }

            //entiteettiolion mistin vapauttaminen
            entities.Dispose();

            // palautetaan 'json' muotoista dataa
            return Json(OK, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Valot100(string id)
        {
            AlytaloBaseDataEntities entities = new AlytaloBaseDataEntities();

            bool OK = false;
            Valo dbItem = (from v in entities.Valo
                               where v.ValoID.ToString() == id
                               select v).FirstOrDefault();

            if (dbItem != null)
            {
                dbItem.ValoOn100 = true;
                dbItem.ValoTila = "100";
                dbItem.ValoDate100 = DateTime.Now;

                entities.SaveChanges();
                OK = true;
            }

            //entiteettiolion muistin vapauttaminen
            entities.Dispose();

            // palautetaan 'json' muotoista dataa
            return Json(OK, JsonRequestBehavior.AllowGet);
        }















        // GET: ValoPaneeli/Details/5
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

        // GET: ValoPaneeli/Create
        public ActionResult Create()
        {
            ViewBag.HuoneID = new SelectList(db.Huone, "HuoneID", "HuoneenNimi");
            return View();
        }

        // POST: ValoPaneeli/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ValoID,HuoneID,ValoOff,ValoOn33,ValoOn66,ValoOn100,ValoDate33,ValoDate66,ValoDate100,ValoDateOff")] Valo valo)
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

        // GET: ValoPaneeli/Edit/5
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

        // POST: ValoPaneeli/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ValoID,HuoneID,ValoOff,ValoOn33,ValoOn66,ValoOn100,ValoDate33,ValoDate66,ValoDate100,ValoDateOff")] Valo valo)
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

        // GET: ValoPaneeli/Delete/5
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

        // POST: ValoPaneeli/Delete/5
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
