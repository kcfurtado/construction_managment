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
    public class PagamentosController : Controller
    {
        private ConstrucaoCivEntities db = new ConstrucaoCivEntities();

        // GET: Pagamentos
        public ActionResult Index()
        {
            var tblPagamento = db.tblPagamento.Include(t => t.tblFuncionario).Include(t => t.tblObra);
            return View(tblPagamento.ToList());
        }

        // GET: Pagamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPagamento tblPagamento = db.tblPagamento.Find(id);
            if (tblPagamento == null)
            {
                return HttpNotFound();
            }
            return View(tblPagamento);
        }

        // GET: Pagamentos/Create
        public ActionResult Create()
        {
            ViewBag.id_func = new SelectList(db.tblFuncionario, "id_func", "nome");
            ViewBag.id_obra = new SelectList(db.tblObra, "id_obra", "nome");
            return View();
        }

        // POST: Pagamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pagam,quantia,data,id_obra,id_func,tipo,createAt,updatedAt")] tblPagamento tblPagamento)
        {
            if (ModelState.IsValid)
            {
                db.tblPagamento.Add(tblPagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_func = new SelectList(db.tblFuncionario, "id_func", "nome", tblPagamento.id_func);
            ViewBag.id_obra = new SelectList(db.tblObra, "id_obra", "nome", tblPagamento.id_obra);
            return View(tblPagamento);
        }

        // GET: Pagamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPagamento tblPagamento = db.tblPagamento.Find(id);
            if (tblPagamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_func = new SelectList(db.tblFuncionario, "id_func", "nome", tblPagamento.id_func);
            ViewBag.id_obra = new SelectList(db.tblObra, "id_obra", "nome", tblPagamento.id_obra);
            return View(tblPagamento);
        }

        // POST: Pagamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pagam,quantia,data,id_obra,id_func,tipo,createAt,updatedAt")] tblPagamento tblPagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_func = new SelectList(db.tblFuncionario, "id_func", "nome", tblPagamento.id_func);
            ViewBag.id_obra = new SelectList(db.tblObra, "id_obra", "nome", tblPagamento.id_obra);
            return View(tblPagamento);
        }

        // GET: Pagamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPagamento tblPagamento = db.tblPagamento.Find(id);
            if (tblPagamento == null)
            {
                return HttpNotFound();
            }
            return View(tblPagamento);
        }

        // POST: Pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPagamento tblPagamento = db.tblPagamento.Find(id);
            db.tblPagamento.Remove(tblPagamento);
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
