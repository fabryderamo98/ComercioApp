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
    public class ProductoController : Controller
    {
        private ComercioEntities db = new ComercioEntities();

        // GET: Producto
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.Deposito).Include(p => p.Proveedor);
            return View(producto.ToList());
        }

        // GET: Producto/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.CodigoDeposito = new SelectList(db.Deposito, "CodigoDeposito", "Descripcion");
            ViewBag.CodigoProveedor = new SelectList(db.Proveedor, "CodigoProveedor", "RazonSocial");
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumeroSerie,Nombre,Cantidad,Precio,CodigoDeposito,CodigoProveedor")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoDeposito = new SelectList(db.Deposito, "CodigoDeposito", "Descripcion", producto.CodigoDeposito);
            ViewBag.CodigoProveedor = new SelectList(db.Proveedor, "CodigoProveedor", "RazonSocial", producto.CodigoProveedor);
            return View(producto);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoDeposito = new SelectList(db.Deposito, "CodigoDeposito", "Descripcion", producto.CodigoDeposito);
            ViewBag.CodigoProveedor = new SelectList(db.Proveedor, "CodigoProveedor", "RazonSocial", producto.CodigoProveedor);
            return View(producto);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumeroSerie,Nombre,Cantidad,Precio,CodigoDeposito,CodigoProveedor")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoDeposito = new SelectList(db.Deposito, "CodigoDeposito", "Descripcion", producto.CodigoDeposito);
            ViewBag.CodigoProveedor = new SelectList(db.Proveedor, "CodigoProveedor", "RazonSocial", producto.CodigoProveedor);
            return View(producto);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
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
