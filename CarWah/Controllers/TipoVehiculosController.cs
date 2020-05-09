using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarWah.Models;

namespace CarWah.Controllers
{
    public class TipoVehiculosController : Controller
    {
        private CarWashEntities db = new CarWashEntities();

        // GET: TipoVehiculos
        public ActionResult Index()
        {
            return View(db.TipoVehiculo.ToList());
        }

        // GET: TipoVehiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVehiculo tipoVehiculo = db.TipoVehiculo.Find(id);
            if (tipoVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipoVehiculo);
        }

        // GET: TipoVehiculos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoVehiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Descripcion")] TipoVehiculo tipoVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.TipoVehiculo.Add(tipoVehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoVehiculo);
        }

        // GET: TipoVehiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVehiculo tipoVehiculo = db.TipoVehiculo.Find(id);
            if (tipoVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipoVehiculo);
        }

        // POST: TipoVehiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Descripcion")] TipoVehiculo tipoVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoVehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoVehiculo);
        }

        // GET: TipoVehiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVehiculo tipoVehiculo = db.TipoVehiculo.Find(id);
            if (tipoVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipoVehiculo);
        }

        // POST: TipoVehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoVehiculo tipoVehiculo = db.TipoVehiculo.Find(id);
            db.TipoVehiculo.Remove(tipoVehiculo);
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
