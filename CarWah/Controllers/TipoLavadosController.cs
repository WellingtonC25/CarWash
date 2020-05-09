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
    public class TipoLavadosController : Controller
    {
        private CarWashEntities db = new CarWashEntities();

        // GET: TipoLavados
        public ActionResult Index()
        {
            return View(db.TipoLavado.ToList());
        }

        // GET: TipoLavados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLavado tipoLavado = db.TipoLavado.Find(id);
            if (tipoLavado == null)
            {
                return HttpNotFound();
            }
            return View(tipoLavado);
        }

        // GET: TipoLavados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoLavados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Descripcion_Lavado,Precio")] TipoLavado tipoLavado)
        {
            if (ModelState.IsValid)
            {
                db.TipoLavado.Add(tipoLavado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoLavado);
        }

        // GET: TipoLavados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLavado tipoLavado = db.TipoLavado.Find(id);
            if (tipoLavado == null)
            {
                return HttpNotFound();
            }
            return View(tipoLavado);
        }

        // POST: TipoLavados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Descripcion_Lavado,Precio")] TipoLavado tipoLavado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoLavado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoLavado);
        }

        // GET: TipoLavados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLavado tipoLavado = db.TipoLavado.Find(id);
            if (tipoLavado == null)
            {
                return HttpNotFound();
            }
            return View(tipoLavado);
        }

        // POST: TipoLavados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoLavado tipoLavado = db.TipoLavado.Find(id);
            db.TipoLavado.Remove(tipoLavado);
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
