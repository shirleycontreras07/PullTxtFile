using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pull.Models;

namespace Pull.Controllers
{
    public class DatosEmpresasController : Controller
    {
        private PullContext db = new PullContext();

        // GET: DatosEmpresas
        public ActionResult Index()
        {
            return View(db.DatosEmpresa.ToList());
        }

        // GET: DatosEmpresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosEmpresa datosEmpresa = db.DatosEmpresa.Find(id);
            if (datosEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(datosEmpresa);
        }

        // GET: DatosEmpresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DatosEmpresas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DatosEmpresaID,TipoRegistro,TipoArchivo,Identificacion,Periodo")] DatosEmpresa datosEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.DatosEmpresa.Add(datosEmpresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datosEmpresa);
        }

        // GET: DatosEmpresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosEmpresa datosEmpresa = db.DatosEmpresa.Find(id);
            if (datosEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(datosEmpresa);
        }

        // POST: DatosEmpresas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DatosEmpresaID,TipoRegistro,TipoArchivo,Identificacion,Periodo")] DatosEmpresa datosEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosEmpresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datosEmpresa);
        }

        // GET: DatosEmpresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosEmpresa datosEmpresa = db.DatosEmpresa.Find(id);
            if (datosEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(datosEmpresa);
        }

        // POST: DatosEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatosEmpresa datosEmpresa = db.DatosEmpresa.Find(id);
            db.DatosEmpresa.Remove(datosEmpresa);
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
