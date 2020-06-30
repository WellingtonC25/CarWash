using CarWah.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace CarWah.Controllers
{
    public class EmpleadosController : Controller
    {
        private CarWashEntities db = new CarWashEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult Login(Empleado empleado)
        {
            if (string.IsNullOrEmpty(empleado.Contraseña))
            {
                return Json(new { status = false, message = "El campo contraseña no puede estar vacio" });
            }

            Encriptacion(empleado);

            var pr = db.UserInRol(empleado.Usuario, empleado.Contraseña).ToList();

            var _empleado = db.Empleado.Where(e => e.Usuario == empleado.Usuario);

            if (_empleado.Any())
            {
                if (_empleado.Where(e => e.Contraseña == empleado.Contraseña).Any() && pr.Where(e => e.Descripcion == "Adm").Any())
                {
                    return RedirectToAction("Index", "Home");
                }

                if (_empleado.Where(e => e.Contraseña == empleado.Contraseña).Any() && pr.Where(e => e.Descripcion == "User").Any())
                {
                    return RedirectToAction("Usuario","Empleados");
                }

                if (_empleado.Where(e => e.Contraseña == empleado.Contraseña).Any() && pr.Where(e => e.Descripcion == "Customer").Any())
                {
                    return Json(new { status = true, message = "Customer Page" });
                }
                else
                {
                    return Json(new { status = false, message = "Contraseña Invalida" });
                }
                }
                else
                {
                    return Json(new { status = false, message = "Usuario Invalido" });
                }
        }

        public ActionResult Usuario()
        {
            return View();
        }
            // GET: Empleados
        public ActionResult Index()
        {
            var a = db.Empleado.ToList();
            return View(a);
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nombre,Apellidos,Cedula,Direccion,Contacto,Usuario,Contraseña")] Empleado empleado)
        {
            try
            {
                Encriptacion(empleado);
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex )
            {
                if (ex.GetBaseException().GetType() == typeof(SqlException))
                {
                    return Json(new { status = false, message = "Cedula correspondiente a otro usuario"});
                }
            }
            return View();
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nombre,Apellidos,Cedula,Direccion,Contacto,Usuario,Contraseña")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public static string Encriptacion(Empleado clearText)
        {
            string EncryptionKey = "abc123";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText.Contraseña);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText.Contraseña = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText.Contraseña;
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
