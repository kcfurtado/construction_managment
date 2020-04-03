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
    public class EquipamentosController : Controller
    {
        private ConstrucaoCivEntities db = new ConstrucaoCivEntities();

        // GET: Equipamentos
        public ActionResult Index()
        {
            return View(db.tblEquipamento.ToList());
        }

        // GET: Equipamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEquipamento tblEquipamento = db.tblEquipamento.Find(id);
            if (tblEquipamento == null)
            {
                return HttpNotFound();
            }
            return View(tblEquipamento);
        }

        // GET: Equipamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_equip,nome,marca,modelo,aquisicao,categoria,preco,quantidade,createdAt,updatedAt")] tblEquipamento tblEquipamento)
        {
            if (ModelState.IsValid)
            {
                db.tblEquipamento.Add(tblEquipamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEquipamento);
        }

        // GET: Equipamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEquipamento tblEquipamento = db.tblEquipamento.Find(id);
            if (tblEquipamento == null)
            {
                return HttpNotFound();
            }
            return View(tblEquipamento);
        }

        // POST: Equipamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_equip,nome,marca,modelo,aquisicao,categoria,preco,quantidade,createdAt,updatedAt")] tblEquipamento tblEquipamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEquipamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEquipamento);
        }

        // GET: Equipamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEquipamento tblEquipamento = db.tblEquipamento.Find(id);
            if (tblEquipamento == null)
            {
                return HttpNotFound();
            }
            return View(tblEquipamento);
        }

        // POST: Equipamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEquipamento tblEquipamento = db.tblEquipamento.Find(id);
            db.tblEquipamento.Remove(tblEquipamento);
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
