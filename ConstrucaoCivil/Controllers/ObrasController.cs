using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstrucaoCivil.Models;

namespace ConstrucaoCivil.Controllers
{
    public class ObrasController : Controller
    {
        private ConstrucaoCivEntities db = new ConstrucaoCivEntities();

        // GET: Obras
        public ActionResult Index()
        {
            var tblObra = db.tblObra.Include(t => t.tblCliente);
            return View(tblObra.ToList());
        }

        // GET: Obras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblObra tblObra = db.tblObra.Find(id);
            if (tblObra == null)
            {
                return HttpNotFound();
            }
            return View(tblObra);
        }

        // GET: Obras/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.tblCliente, "id_cliente", "nome");
            return View();
        }

        // POST: Obras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_obra,nome,local,orçamento,estado,data_inicio,data_fim,custo_total,id_cliente,decriçao,createdAt,updatedAt")] tblObra tblObra)
        {
            if (ModelState.IsValid)
            {
                db.tblObra.Add(tblObra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.tblCliente, "id_cliente", "nome", tblObra.id_cliente);
            return View(tblObra);
        }

        // GET: Obras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblObra tblObra = db.tblObra.Find(id);
            if (tblObra == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.tblCliente, "id_cliente", "nome", tblObra.id_cliente);
            return View(tblObra);
        }

        // POST: Obras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_obra,nome,local,orçamento,estado,data_inicio,data_fim,custo_total,id_cliente,decriçao,createdAt,updatedAt")] tblObra tblObra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblObra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.tblCliente, "id_cliente", "nome", tblObra.id_cliente);
            return View(tblObra);
        }

        // GET: Obras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblObra tblObra = db.tblObra.Find(id);
            if (tblObra == null)
            {
                return HttpNotFound();
            }
            return View(tblObra);
        }

        // POST: Obras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblObra tblObra = db.tblObra.Find(id);
            db.tblObra.Remove(tblObra);
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
