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
    public class FacturaDetailsController : Controller
    {
        private CarWashEntities db = new CarWashEntities();

        // GET: FacturaDetails
        public ActionResult Index()
        {
            var facturaDetails = db.FacturaDetails.Include(f => f.Factura).Include(f => f.TipoLavado).Include(f => f.Vehiculo);
            return View(facturaDetails.ToList());
        }

        // GET: FacturaDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetails facturaDetails = db.FacturaDetails.Find(id);
            if (facturaDetails == null)
            {
                return HttpNotFound();
            }
            return View(facturaDetails);
        }

        // GET: FacturaDetails/Create
        public ActionResult Create()
        {
            ViewBag.Codigo = new SelectList(db.Factura, "Codigo", "Codigo");
            ViewBag.Lavado = new SelectList(db.TipoLavado, "Codigo", "Descripcion_Lavado");
            ViewBag.VehiculoId = new SelectList(db.Vehiculo, "Codigo", "Placa");

            return View();
        }

        // POST: FacturaDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,VehiculoId,Descuento,Lavado,Precio,Cantidad,ITBIS,Total")] FacturaDetails facturaDetails)
        {
            if (ModelState.IsValid)
            {
                db.FacturaDetails.Add(facturaDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Codigo = new SelectList(db.Factura, "Codigo", "Codigo", facturaDetails.Codigo);
            ViewBag.Lavado = new SelectList(db.TipoLavado, "Codigo", "Descripcion_Lavado", facturaDetails.Lavado);
            ViewBag.VehiculoId = new SelectList(db.Vehiculo, "Codigo", "Placa", facturaDetails.VehiculoId);

            return View(facturaDetails);
        }

        // GET: FacturaDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetails facturaDetails = db.FacturaDetails.Find(id);
            if (facturaDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo = new SelectList(db.Factura, "Codigo", "Codigo", facturaDetails.Codigo);
            ViewBag.Lavado = new SelectList(db.TipoLavado, "Codigo", "Descripcion_Lavado", facturaDetails.Lavado);
            ViewBag.VehiculoId = new SelectList(db.Vehiculo, "Codigo", "Placa", facturaDetails.VehiculoId);
            return View(facturaDetails);
        }

        // POST: FacturaDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,VehiculoId,Descuento,Lavado,Precio,Cantidad,ITBIS,Total")] FacturaDetails facturaDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturaDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo = new SelectList(db.Factura, "Codigo", "Codigo", facturaDetails.Codigo);
            ViewBag.Lavado = new SelectList(db.TipoLavado, "Codigo", "Descripcion_Lavado", facturaDetails.Lavado);
            ViewBag.VehiculoId = new SelectList(db.Vehiculo, "Codigo", "Placa", facturaDetails.VehiculoId);
            return View(facturaDetails);
        }

        // GET: FacturaDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetails facturaDetails = db.FacturaDetails.Find(id);
            if (facturaDetails == null)
            {
                return HttpNotFound();
            }
            return View(facturaDetails);
        }

        // POST: FacturaDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FacturaDetails facturaDetails = db.FacturaDetails.Find(id);
            db.FacturaDetails.Remove(facturaDetails);
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
