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
    public class VehiculoesController : Controller
    {
        private CarWashEntities db = new CarWashEntities();

        // GET: Vehiculoes
        public ActionResult Index()
        {
            var vehiculo = db.Vehiculo.Include(v => v.Marca).Include(v => v.Modelo).Include(v => v.TipoVehiculo);
            return View(vehiculo.ToList());
        }

        // GET: Vehiculoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: Vehiculoes/Create
        public ActionResult Create()
        {
            ViewBag.MarcaId = new SelectList(db.Marca, "Codigo", "Descripcion");
            ViewBag.ModeloId = new SelectList(db.Modelo, "Codigo", "Descripcion");
            ViewBag.Tipo_de_Vehiculo = new SelectList(db.TipoVehiculo, "Codigo", "Descripcion");
            return View();
        }

        // POST: Vehiculoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,ModeloId,MarcaId,Placa,Tipo_de_Vehiculo")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Vehiculo.Add(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarcaId = new SelectList(db.Marca, "Codigo", "Descripcion", vehiculo.MarcaId);
            ViewBag.ModeloId = new SelectList(db.Modelo, "Codigo", "Descripcion", vehiculo.ModeloId);
            ViewBag.Tipo_de_Vehiculo = new SelectList(db.TipoVehiculo, "Codigo", "Descripcion", vehiculo.Tipo_de_Vehiculo);
            return View(vehiculo);
        }

        // GET: Vehiculoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarcaId = new SelectList(db.Marca, "Codigo", "Descripcion", vehiculo.MarcaId);
            ViewBag.ModeloId = new SelectList(db.Modelo, "Codigo", "Descripcion", vehiculo.ModeloId);
            ViewBag.Tipo_de_Vehiculo = new SelectList(db.TipoVehiculo, "Codigo", "Descripcion", vehiculo.Tipo_de_Vehiculo);
            return View(vehiculo);
        }

        // POST: Vehiculoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,ModeloId,MarcaId,Placa,Tipo_de_Vehiculo")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarcaId = new SelectList(db.Marca, "Codigo", "Descripcion", vehiculo.MarcaId);
            ViewBag.ModeloId = new SelectList(db.Modelo, "Codigo", "Descripcion", vehiculo.ModeloId);
            ViewBag.Tipo_de_Vehiculo = new SelectList(db.TipoVehiculo, "Codigo", "Descripcion", vehiculo.Tipo_de_Vehiculo);
            return View(vehiculo);
        }

        // GET: Vehiculoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            db.Vehiculo.Remove(vehiculo);
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
