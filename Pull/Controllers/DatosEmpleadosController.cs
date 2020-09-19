using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pull.Models;

namespace Pull.Controllers
{
    public class DatosEmpleadosController : Controller
    {
        private PullContext db = new PullContext();

        // GET: DatosEmpleados
        public ActionResult Index()
        {
            return View(db.DatosEmpleado.ToList());
        }

        // GET: DatosEmpleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosEmpleado datosEmpleado = db.DatosEmpleado.Find(id);
            if (datosEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(datosEmpleado);
        }

        // GET: DatosEmpleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DatosEmpleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DatosEmpleadoId,IdEmpresa,TipoRegistro,TipoIdEmpleado,EmpleadoId,Sueldo,SueldoNeto,NoSeguridadSocial")] DatosEmpleado datosEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.DatosEmpleado.Add(datosEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datosEmpleado);
        }

        // GET: DatosEmpleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosEmpleado datosEmpleado = db.DatosEmpleado.Find(id);
            if (datosEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(datosEmpleado);
        }

        // POST: DatosEmpleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DatosEmpleadoId,IdEmpresa,TipoRegistro,TipoIdEmpleado,EmpleadoId,Sueldo,SueldoNeto,NoSeguridadSocial")] DatosEmpleado datosEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datosEmpleado);
        }

        // GET: DatosEmpleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosEmpleado datosEmpleado = db.DatosEmpleado.Find(id);
            if (datosEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(datosEmpleado);
        }

        // POST: DatosEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatosEmpleado datosEmpleado = db.DatosEmpleado.Find(id);
            db.DatosEmpleado.Remove(datosEmpleado);
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
