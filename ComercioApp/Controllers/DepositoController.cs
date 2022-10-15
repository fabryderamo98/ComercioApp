using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComercioApp.Models;

namespace ComercioApp.Controllers
{
    public class DepositoController : Controller
    {
        private ComercioEntities db = new ComercioEntities();

        // GET: Deposito
        public ActionResult Index()
        {
            return View(db.Deposito.ToList());
        }

        // GET: Deposito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deposito deposito = db.Deposito.Find(id);
            if (deposito == null)
            {
                return HttpNotFound();
            }
            return View(deposito);
        }

        // GET: Deposito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deposito/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoDeposito,Descripcion")] Deposito deposito)
        {
            if (ModelState.IsValid)
            {
                db.Deposito.Add(deposito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deposito);
        }

        // GET: Deposito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deposito deposito = db.Deposito.Find(id);
            if (deposito == null)
            {
                return HttpNotFound();
            }
            return View(deposito);
        }

        // POST: Deposito/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoDeposito,Descripcion")] Deposito deposito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deposito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deposito);
        }

        // GET: Deposito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deposito deposito = db.Deposito.Find(id);
            if (deposito == null)
            {
                return HttpNotFound();
            }
            return View(deposito);
        }

        // POST: Deposito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deposito deposito = db.Deposito.Find(id);
            db.Deposito.Remove(deposito);
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
