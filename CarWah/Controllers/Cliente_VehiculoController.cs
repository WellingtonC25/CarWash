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
    public class Cliente_VehiculoController : Controller
    {
        /// <summary>
        /// A client vehicle controller
        /// </summary>
        private CarWashEntities db = new CarWashEntities();

        // GET: Cliente_Vehiculo
        public ActionResult Index()
        {
            var cliente_Vehiculo = db.Cliente_Vehiculo.Include(c => c.Cliente).Include(c => c.Vehiculo);
            return View(cliente_Vehiculo.ToList());
        }

        // GET: Cliente_Vehiculo/Details/5
        public ActionResult Details([Range(1, int.MaxValue)]int id)
        {
            var cliente_Vehiculo = db.Cliente_Vehiculo.Find(id);
            if (cliente_Vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(cliente_Vehiculo);
        }

        // GET: Cliente_Vehiculo/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Cliente, "Codigo", "Nombre");
            ViewBag.VehiculoId = new SelectList(db.Vehiculo, "Codigo", "Placa");
            return View();
        }

        // POST: Cliente_Vehiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,ClienteId,VehiculoId")] Cliente_Vehiculo cliente_Vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Cliente_Vehiculo.Add(cliente_Vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "Codigo", "Nombre", cliente_Vehiculo.ClienteId);
            ViewBag.VehiculoId = new SelectList(db.Vehiculo, "Codigo", "Placa", cliente_Vehiculo.VehiculoId);
            return View(cliente_Vehiculo);
        }

        // GET: Cliente_Vehiculo/Edit/5
        public ActionResult Edit([Range(1, int.MaxValue)]int id)
        {
            var cliente_Vehiculo = db.Cliente_Vehiculo.Find(id);
            if (cliente_Vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "Codigo", "Nombre", cliente_Vehiculo.ClienteId);
            ViewBag.VehiculoId = new SelectList(db.Vehiculo, "Codigo", "Placa", cliente_Vehiculo.VehiculoId);
            return View(cliente_Vehiculo);
        }

        // POST: Cliente_Vehiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,ClienteId,VehiculoId")] Cliente_Vehiculo cliente_Vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente_Vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "Codigo", "Nombre", cliente_Vehiculo.ClienteId);
            ViewBag.VehiculoId = new SelectList(db.Vehiculo, "Codigo", "Placa", cliente_Vehiculo.VehiculoId);
            return View(cliente_Vehiculo);
        }

        // GET: Cliente_Vehiculo/Delete/5
        public ActionResult Delete([Range(1, int.MaxValue)]int id)
        {
            var cliente_Vehiculo = db.Cliente_Vehiculo.Find(id);
            if (cliente_Vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(cliente_Vehiculo);
        }

        // POST: Cliente_Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Range(1, int.MaxValue)]int id)
        {
            var cliente_Vehiculo = db.Cliente_Vehiculo.Find(id);
            db.Cliente_Vehiculo.Remove(cliente_Vehiculo);
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
