using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pruebatec;

namespace pruebatec.Controllers
{
    public class trabajadoresController : Controller
    {
        private EmpresaABCDEntities db = new EmpresaABCDEntities();

        // GET: trabajadores
        public ActionResult Index()
        {
            var trabajadores = db.trabajadores.Include(t => t.trabajadores2);
            return View(trabajadores.ToList());
        }

        // GET: trabajadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabajadores trabajadores = db.trabajadores.Find(id);
            if (trabajadores == null)
            {
                return HttpNotFound();
            }
            return View(trabajadores);
        }

        // GET: trabajadores/Create
        public ActionResult Create()
        {
            ViewBag.idboss = new SelectList(db.trabajadores, "id", "fullname");
            return View();
        }

        // POST: trabajadores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fullname,dni,idboss")] trabajadores trabajadores)
        {
            if (ModelState.IsValid)
            {
                db.trabajadores.Add(trabajadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idboss = new SelectList(db.trabajadores, "id", "fullname", trabajadores.idboss);
            return View(trabajadores);
        }

        // GET: trabajadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabajadores trabajadores = db.trabajadores.Find(id);
            if (trabajadores == null)
            {
                return HttpNotFound();
            }
            ViewBag.idboss = new SelectList(db.trabajadores, "id", "fullname", trabajadores.idboss);
            return View(trabajadores);
        }

        // POST: trabajadores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fullname,dni,idboss")] trabajadores trabajadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idboss = new SelectList(db.trabajadores, "id", "fullname", trabajadores.idboss);
            return View(trabajadores);
        }

        // GET: trabajadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabajadores trabajadores = db.trabajadores.Find(id);
            if (trabajadores == null)
            {
                return HttpNotFound();
            }
            return View(trabajadores);
        }

        // POST: trabajadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trabajadores trabajadores = db.trabajadores.Find(id);
            db.trabajadores.Remove(trabajadores);
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
