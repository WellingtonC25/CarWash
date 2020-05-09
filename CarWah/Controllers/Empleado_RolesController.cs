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
    public class Empleado_RolesController : Controller
    {
        private CarWashEntities db = new CarWashEntities();

        // GET: Empleado_Roles
        public ActionResult Index()
        {
            var empleado_Roles = db.Empleado_Roles.Include(e => e.Empleado).Include(e => e.Role);
            return View(empleado_Roles.ToList());
        }

        // GET: Empleado_Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado_Roles empleado_Roles = db.Empleado_Roles.Find(id);
            if (empleado_Roles == null)
            {
                return HttpNotFound();
            }
            return View(empleado_Roles);
        }

        // GET: Empleado_Roles/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleado, "Codigo", "Nombre");
            ViewBag.RoleId = new SelectList(db.Role, "Codigo", "Descripcion");
            return View();
        }

        // POST: Empleado_Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,EmpleadoId,RoleId")] Empleado_Roles empleado_Roles)
        {
            if (ModelState.IsValid)
            {
                db.Empleado_Roles.Add(empleado_Roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleado, "Codigo", "Nombre", empleado_Roles.EmpleadoId);
            ViewBag.RoleId = new SelectList(db.Role, "Codigo", "Descripcion", empleado_Roles.RoleId);
            return View(empleado_Roles);
        }

        // GET: Empleado_Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado_Roles empleado_Roles = db.Empleado_Roles.Find(id);
            if (empleado_Roles == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleado, "Codigo", "Nombre", empleado_Roles.EmpleadoId);
            ViewBag.RoleId = new SelectList(db.Role, "Codigo", "Descripcion", empleado_Roles.RoleId);
            return View(empleado_Roles);
        }

        // POST: Empleado_Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,EmpleadoId,RoleId")] Empleado_Roles empleado_Roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado_Roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleado, "Codigo", "Nombre", empleado_Roles.EmpleadoId);
            ViewBag.RoleId = new SelectList(db.Role, "Codigo", "Descripcion", empleado_Roles.RoleId);
            return View(empleado_Roles);
        }

        // GET: Empleado_Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado_Roles empleado_Roles = db.Empleado_Roles.Find(id);
            if (empleado_Roles == null)
            {
                return HttpNotFound();
            }
            return View(empleado_Roles);
        }

        // POST: Empleado_Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado_Roles empleado_Roles = db.Empleado_Roles.Find(id);
            db.Empleado_Roles.Remove(empleado_Roles);
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
