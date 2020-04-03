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
    public class ForneceController : Controller
    {
        private ConstrucaoCivEntities db = new ConstrucaoCivEntities();

        // GET: Fornece
        public ActionResult Index()
        {
            var tblFornece = db.tblFornece.Include(t => t.tblEquipamento).Include(t => t.tblFornecedor);
            return View(tblFornece.ToList());
        }

        // GET: Fornece/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFornece tblFornece = db.tblFornece.Find(id);
            if (tblFornece == null)
            {
                return HttpNotFound();
            }
            return View(tblFornece);
        }

        // GET: Fornece/Create
        public ActionResult Create()
        {
            ViewBag.id_equip = new SelectList(db.tblEquipamento, "id_equip", "nome");
            ViewBag.id_fornecedor = new SelectList(db.tblFornecedor, "id_fornecedor", "nif");
            return View();
        }

        // POST: Fornece/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_fornece,id_fornecedor,id_equip,modo,quantidade,custo,data_inicio,data_fim,createdAt,updatedAt")] tblFornece tblFornece)
        {
            if (ModelState.IsValid)
            {
                db.tblFornece.Add(tblFornece);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_equip = new SelectList(db.tblEquipamento, "id_equip", "nome", tblFornece.id_equip);
            ViewBag.id_fornecedor = new SelectList(db.tblFornecedor, "id_fornecedor", "nif", tblFornece.id_fornecedor);
            return View(tblFornece);
        }

        // GET: Fornece/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFornece tblFornece = db.tblFornece.Find(id);
            if (tblFornece == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_equip = new SelectList(db.tblEquipamento, "id_equip", "nome", tblFornece.id_equip);
            ViewBag.id_fornecedor = new SelectList(db.tblFornecedor, "id_fornecedor", "nif", tblFornece.id_fornecedor);
            return View(tblFornece);
        }

        // POST: Fornece/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_fornece,id_fornecedor,id_equip,modo,quantidade,custo,data_inicio,data_fim,createdAt,updatedAt")] tblFornece tblFornece)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblFornece).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_equip = new SelectList(db.tblEquipamento, "id_equip", "nome", tblFornece.id_equip);
            ViewBag.id_fornecedor = new SelectList(db.tblFornecedor, "id_fornecedor", "nif", tblFornece.id_fornecedor);
            return View(tblFornece);
        }

        // GET: Fornece/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFornece tblFornece = db.tblFornece.Find(id);
            if (tblFornece == null)
            {
                return HttpNotFound();
            }
            return View(tblFornece);
        }

        // POST: Fornece/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblFornece tblFornece = db.tblFornece.Find(id);
            db.tblFornece.Remove(tblFornece);
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
